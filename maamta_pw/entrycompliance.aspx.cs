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
    public partial class entrycompliance : System.Web.UI.Page
    {

        string ConDataBase = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "entrycompliance";
                txtSearchStudyID.Focus();
            }
        }




        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchStudyID.Text == "")
            {
                showalert("Enter Study ID");
                txtSearchStudyID.Focus();
            }
            else
            {
                ShowData();
                txtSearchStudyID.Focus();
            }
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select *, DATE_FORMAT((str_to_date(pw_crf_3a_2, '%d-%m-%Y')),'%d-%m-%Y') as DOV from view_crf3a where pw_crf_3a_19!='1' and study_code like  '%" + txtSearchStudyID.Text.ToUpper() + "%'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }







        private void Clear()
        {
            txtStudyID.Text = "";
            txtDSSID.Text = "";
            txtLastDOV.Text = "";
            txtDOV.Text = "";
            txtremarks.InnerText = "";
            txtEmptySac.Text = "";
            txtActualEmptySac.Text = "";
        }





        protected void Link_EditForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["RolePW"]) == "web_sup_admin")
            {
                Clear();
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                txtStudyID.Text = commandArgs[0];
                txtDSSID.Text = commandArgs[1];
                txtLastDOV.Text = commandArgs[2];
                LastDOV();

                Panel2.Visible = false;
                Panel1.Visible = true;
                txtDOV.Focus();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }





        public void LastDOV()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            MySqlCommand cmd = new MySqlCommand("select DATE_FORMAT((str_to_date(date_of_attempt, '%d-%m-%Y')),'%d-%m-%Y') as date_of_attempt from compliance_sachet where DATE_FORMAT((str_to_date(date_of_attempt, '%d-%m-%Y')),'%d-%m-%Y')=(select DATE_FORMAT(max(str_to_date(date_of_attempt, '%d-%m-%Y')),'%d-%m-%Y') from compliance_sachet where 	study_code='" + txtStudyID.Text + "' )		and 	study_code='" + txtStudyID.Text + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtLastDOV.Text = dr["date_of_attempt"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }














        protected void submit_Click(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {
                if (DateTime.ParseExact(txtDOV.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Enter Less than Current Date!");
                    txtDOV.Focus();
                }
                else if (DateTime.ParseExact(txtDOV.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(Convert.ToString(txtLastDOV.Text), "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Enter Greater than Enrollemnt or Last Visit: " + txtLastDOV.Text);
                    txtDOV.Focus();
                }
                else
                {
                    MySqlConnection cn = new MySqlConnection(ConDataBase);
                    try
                    {
                        if (SachetDataCheck() == false && CheckCRF4() == true)
                        {
                            cn.Open();
                            MySqlCommand cmd1 = new MySqlCommand("insert into compliance_sachet(study_code,	last_date_of_attempt,	date_of_attempt,	empty_sachet,   actual_empty_sachet,	remarks,	entry_date,	entry_nm) values ('" + txtStudyID.Text.ToUpper() + "','" + txtLastDOV.Text + "','" + txtDOV.Text + "','" + txtEmptySac.Text + "','" + txtActualEmptySac.Text + "','" + txtremarks.InnerText.ToUpper() + "','" + DateTime.Now.ToString("dd-MM-yyyy HH:mm") + "','" + Convert.ToString(Session["MPusernamePW"]) + "')", cn);

                            cmd1.ExecuteNonQuery();
                            cn.Close();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Saved Successfully!');window.location.href='entrycompliance.aspx';", true);
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
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtDOV.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }

        }



        public bool CheckCRF4()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(ConDataBase);
            MySqlCommand cmd = new MySqlCommand("select * from form_crf_4 where  study_code='" + txtStudyID.Text.ToUpper() + "' and DATE_FORMAT((str_to_date(pw_crf4_2, '%d-%m-%Y')),'%d-%m-%Y')= DATE_FORMAT((str_to_date('" + txtDOV.Text + "', '%d-%m-%Y')),'%d-%m-%Y') and pw_crf4_18='1'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record does not exist in CRF4, according to given DOV');", true);
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        public bool SachetDataCheck()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(ConDataBase);
            MySqlCommand cmd = new MySqlCommand("select * from compliance_sachet where study_code='" + txtStudyID.Text.ToUpper() + "' and date_of_attempt='" + txtDOV.Text + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record already exist!');window.location.href='entrycompliance.aspx';", true);
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