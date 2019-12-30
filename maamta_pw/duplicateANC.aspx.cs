using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta_pw
{
    public partial class duplicateANC : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        string AssismentID;
        string date_of_attempt;


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "duplicateANC";

            if (!IsPostBack)
            {
                divBackButton.Visible = false;
                ShowData();
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("duplicateANC.aspx");
        }





        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                //Duplicate ANC Visit (on Same Date) : 
                MySqlCommand cmd = new MySqlCommand("select assis_id,dssid,count(dssid) as Duplicate,date_of_attempt,husband_nm,woman_nm from view_anc group by assis_id,date_of_attempt having (count(assis_id)>1) and (count(date_of_attempt)>1)", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
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






        private void ShowDetails()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                //Duplicate ANC Visit (on Same Date) : 
                MySqlCommand cmd = new MySqlCommand("select * from view_anc where assis_id='" + AssismentID + "' and  str_to_date(date_of_attempt, '%d-%m-%Y')=str_to_date('" + date_of_attempt + "', '%d-%m-%Y')", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            con.Close();
                            AssismentID = null;
                            date_of_attempt = null;
                        }
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




        protected void Link_AssismentID(object sender, EventArgs e)
        {

            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            AssismentID = commandArgs[0];
            date_of_attempt = commandArgs[1];

            DivShowData.Visible = false;
            
            DivShowDetails.Visible = true;
            divBackButton.Visible = true;
        
         
            ShowDetails();
        }

    }
}