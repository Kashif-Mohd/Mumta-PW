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
    public partial class updatecrf8a : System.Web.UI.Page
    {
        string currentdate;

        //MySQL 
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf8";
                FieldFill();
                txtq4.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        // Check Button:







        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where id=" + Request.QueryString["FormID"] + " and status='1'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txt_Study_ID.Text = dr["study_id"].ToString();
                    txtq4.Text = dr["q4"].ToString();
                    txtq5.Text = dr["q5"].ToString();

                    txtq6WomanNm.Text = dr["q6"].ToString();
                    txtq7HusbandNm.Text = dr["q7"].ToString();
                    txtdssidQ8toQ13.Text = dr["dssid"].ToString();

                    txtq14.SelectedValue = dr["q14"].ToString();
                    txtq15.Text = dr["q15"].ToString();
                    txtq17.Text = dr["q17"].ToString();
                    txtq18.Text = dr["q18"].ToString();
                    txtq19.Text = dr["q19"].ToString();
                    txtq20.Text = dr["q20"].ToString();
                    txtq21.Text = dr["q21"].ToString();
                    txtq22.Text = dr["q22"].ToString();
                    txtq23.Text = dr["q23"].ToString();
                    txtq24.Text = dr["q24"].ToString();
                    txtq25.Text = dr["q25"].ToString();
                    txtq26.Text = dr["q26"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }











        protected void next_Click(object sender, EventArgs e)
        {
            currentdate = DateTime.Now.ToString("dd-MM-yyyy");

            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                //// Q2:
                //if (DateTime.ParseExact(txtq2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                //{
                //    showalert("Incorrect Date, Should be Less than Current Date!");
                //    txtq2.Focus();
                //}
                //else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                //{
                //    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                //    txtq2.Focus();
                //}

                // Q17:

                if (DateTime.ParseExact(txtq17.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq17.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq17.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq17.Focus();
                }

                // Q19:
                else if (txtq19.Text != "88-88-8888" && (DateTime.ParseExact(txtq19.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq19.Focus();
                }
                else if (txtq19.Text != "88-88-8888" && (DateTime.ParseExact(txtq17.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq19.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Should be Greater than Q16 Date (" + txtq17.Text + ")");
                    txtq19.Focus();
                }

                // Q21:
                else if (DateTime.ParseExact(txtq21.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq21.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq21.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq21.Focus();
                }

                // Q23:
                else if (DateTime.ParseExact(txtq23.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq23.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq23.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq23.Focus();
                }
                // Q25:
                else if (DateTime.ParseExact(txtq25.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq25.Focus();
                }
                else if (DateTime.ParseExact(txtq25.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq23.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq25.Focus();
                }

                else if (check_CRF6a_ForQ14() == false && txtq14.SelectedValue == "2")
                {
                    showalert("CRF6a is not, First fill CRF6a and CRF6b then enter SAEs form");
                    txtq14.Focus();
                }
                else
                {
                    //FindFormID();

                    //string TimeQ26 = Convert.ToString(Convert.ToDateTime(txtq24.Text).AddMinutes(10).TimeOfDay);
                    //TimeQ26 = TimeQ26.Substring(0, 5);

                    int Age = Convert.ToInt32((Convert.ToDateTime(txtq17.Text) - Convert.ToDateTime(txtq15.Text)).TotalDays);


                    MySqlCommand cmd = new MySqlCommand("update crf8 set q4='" + txtq4.Text + "'	,q5='" + txtq5.Text + "'	,q6='" + txtq6WomanNm.Text + "'	,q7='" + txtq7HusbandNm.Text + "'	,dssid='" + txtdssidQ8toQ13.Text + "'	,q14='" + txtq14.SelectedValue + "'	,q15='" + txtq15.Text + "'	,q16='" + Age + "'	,q17='" + txtq17.Text + "'	,q18='" + txtq18.Text + "'	,q19='" + txtq19.Text + "'	,q20='" + txtq20.Text + "', q21='" + txtq21.Text + "'	,q22='" + txtq22.Text + "'	,q23='" + txtq23.Text + "'	,q24='" + txtq22.Text + "',q25='" + txtq25.Text + "'	,q26='" + txtq26.Text + "', update_dt='" + DateTime.Now.ToString("dd-MM-yyyy") + "', update_nm='" + Convert.ToString(Session["MPusernamePW"]) + "'  where  id='" + Request.QueryString["FormID"] + "'  and status=1", cn);
                    cmd.ExecuteNonQuery();                    
                    cn.Close();
                    Response.Redirect("updatecrf8b.aspx?&FormID=" + Request.QueryString["FormID"]);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtq17.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }
            finally
            {
                cn.Close();
            }
        }



        public bool check_CRF6a_ForQ14()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_6a WHERE study_code='" + txt_Study_ID.Text + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }












    }
}