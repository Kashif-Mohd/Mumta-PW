using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta_pw
{
    public partial class updatecrf8c : System.Web.UI.Page
    {
        static string AD_Start_Date;
        static string AD_Stop_Date;

        //MySQL 
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf8";
                FieldFill();
                FieldFill_Only_Q44();
                txtq38.Focus();
            }

        }




        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void next_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                //q42
                if (txtq42.Text != "88-88-8888" && txtq42.Text != "__-__-____" && (DateTime.ParseExact(txtq42.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq42.Focus();
                }
                else if (txtq42.Text != "88-88-8888" && txtq42.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq42.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq42.Focus();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update crf8 set q38='" + txtq38.SelectedValue + "',q38_other='" + txtq38_other.Text + "',q39_01='" + (chkQ39_01.Checked == true ? "1" : "") + "',q39_02='" + (chkQ39_02.Checked == true ? "2" : "") + "',q39_03='" + (chkQ39_03.Checked == true ? "3" : "") + "',q39_04='" + (chkQ39_04.Checked == true ? "4" : "") + "',q39_05='" + (chkQ39_05.Checked == true ? "5" : "") + "',q39_06='" + (chkQ39_06.Checked == true ? "6" : "") + "',q39_07='" + (chkQ39_07.Checked == true ? "7" : "") + "',q39_08='" + (chkQ39_08.Checked == true ? "8" : "") + "',  q40='" + txtq40.SelectedValue + "',q40_other='" + txtq40_other.Text + "',q41='" + txtq41.SelectedValue + "',q42='" + txtq42.Text + "',q43='" + txtq43.Text + "',q44='" + txtq44.Text + "', status='1'          where  id='" + Request.QueryString["FormID"] + "' and status=1", cn);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Update Successfully!');window.location.href='dashboardCRF8.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }





        public void FieldFill_Only_Q44()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT CONCAT ( (CASE WHEN pw_crf_6b_28='1' THEN 'KGH' WHEN pw_crf_6b_28 LIKE '2' THEN 'AKHWC Kharadar' WHEN pw_crf_6b_28 LIKE '3' THEN 'JPMC' WHEN pw_crf_6b_28 LIKE '4' THEN 'Civil' WHEN pw_crf_6b_28 LIKE '5:%' THEN 'Other government hospital' WHEN pw_crf_6b_28 LIKE '6:%' THEN 'Private hospital'  WHEN pw_crf_6b_28 LIKE '7:%' THEN 'Maternity center' WHEN pw_crf_6b_28 LIKE '8:%' THEN 'Clinic' WHEN pw_crf_6b_28 LIKE '9' THEN 'Don’t know' WHEN pw_crf_6b_28 LIKE '10' THEN 'Home' WHEN pw_crf_6b_28 LIKE '11:%' THEN 'On the way' WHEN pw_crf_6b_28 LIKE '12:%' THEN 'Other ' WHEN pw_crf_6b_28 LIKE '13' THEN 'AKU Main' WHEN pw_crf_6b_28 LIKE '14' THEN 'VPT Center' WHEN pw_crf_6b_28 LIKE '15' THEN 'Attiya' ELSE pw_crf_6b_28 END)			,' - ',			SUBSTRING_INDEX(SUBSTRING_INDEX(pw_crf_6b_28,':',2),':',-(1)) )	 AS pw_crf_6b_28  FROM form_crf_6b WHERE study_code='" + Request.QueryString["Study_ID"] + "'", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtq44.Text = dr["pw_crf_6b_28"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }





        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where  id='" + Request.QueryString["FormID"] + "' and status=1", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    AD_Start_Date = dr["q17"].ToString();
                    AD_Stop_Date = dr["q19"].ToString();

                    txtq38.SelectedValue = dr["q38"].ToString();
                    txtq38_other.Text = dr["q38_other"].ToString();

                    chkQ39_01.Checked = (dr["q39_01"].Equals("1"));
                    chkQ39_02.Checked = (dr["q39_02"].Equals("2"));
                    chkQ39_03.Checked = (dr["q39_03"].Equals("3"));
                    chkQ39_04.Checked = (dr["q39_04"].Equals("4"));
                    chkQ39_05.Checked = (dr["q39_05"].Equals("5"));
                    chkQ39_06.Checked = (dr["q39_06"].Equals("6"));
                    chkQ39_07.Checked = (dr["q39_07"].Equals("7"));
                    chkQ39_08.Checked = (dr["q39_08"].Equals("8"));

                    txtq40.SelectedValue = dr["q40"].ToString();
                    txtq40_other.Text = dr["q40_other"].ToString();

                    txtq41.SelectedValue = dr["q41"].ToString();

                    txtq42.Text = dr["q42"].ToString();
                    txtq43.Text = dr["q43"].ToString();

                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}