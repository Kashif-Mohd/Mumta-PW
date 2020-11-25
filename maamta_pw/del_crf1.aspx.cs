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
    public partial class del_crf1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        string del_crf1_assis_id;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["RolePW"]) != "web_sup_admin")
            {
                Response.Redirect("dashUltra.aspx");
            }
            Session["WebForm"] = "del_crf1";
            ShowData();
            txtdssid.Focus();
        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtdssid.Focus();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_crf1_dummy where dssid like '%" + txtdssid.Text + "%'", con);
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
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }



        protected void Link_Delete(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');
            del_crf1_assis_id = arg[0];

            if (Convert.ToString(Session["MPusernamePW"]).ToUpper() != "KASHIF" && Convert.ToString(Session["MPusernamePW"]).ToUpper() != "WAQAS" && Convert.ToString(Session["MPusernamePW"]).ToUpper() != "SAMEER" && Convert.ToString(Session["MPusernamePW"]).ToUpper() != "OWAIS")
            {
                showalert("Only IT team has rights to delete the record");
            }
            else if (CheckCRF2() == false)
            {
                DeleteRec();
            }
        }




        private void DeleteRec()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (del_crf1_assis_id != null)
                {

                    //Delete Form pregnant_woman:
                    con.Open();
                    MySqlCommand for_pregnant_woman;
                    for_pregnant_woman = new MySqlCommand("delete from pregnant_woman where  assis_id='" + del_crf1_assis_id + "'", con);
                    for_pregnant_woman.ExecuteNonQuery();
                    con.Close();


                    //Delete form_crf_1:
                    con.Open();
                    MySqlCommand for_form_crf_1;
                    for_form_crf_1 = new MySqlCommand("delete from form_crf_1 where pw_assist_code='" + del_crf1_assis_id + "'", con);
                    for_form_crf_1.ExecuteNonQuery();
                    con.Close();


                    //Delete ultrasound_examination:
                    con.Open();
                    MySqlCommand for_ultrasound_examination;
                    for_ultrasound_examination = new MySqlCommand("delete from ultrasound_examination where  pw_assist_code='" + del_crf1_assis_id + "'", con);
                    for_ultrasound_examination.ExecuteNonQuery();
                    con.Close();


                    //Delete followups:
                    con.Open();
                    MySqlCommand for_followups;
                    for_followups = new MySqlCommand("delete from followups where pw_assid='" + del_crf1_assis_id + "'", con);
                    for_followups.ExecuteNonQuery();
                    con.Close();

                    //Show Dummy Dataset:

                    ShowData();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                del_crf1_assis_id = null;

                con.Close();
            }
        }




        public bool CheckCRF2()
        {
            MySqlConnection con = new MySqlConnection(constr);

            bool exist = false;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_2 WHERE assist_code='" + del_crf1_assis_id + "'", con);
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                    showalert("CRF-2 (ELIGIBILITY FORM) is filled according to this Assessment-id");
                    txtdssid.Focus();
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }




    }
}