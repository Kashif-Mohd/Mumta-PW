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
    public partial class checkcompliance : System.Web.UI.Page
    {
        string ConDataBase = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        static string form_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "checkcompliance";
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
            ShowData();
            txtSearchStudyID.Focus();
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.id,b.study_code,c.pw_crf_1_09 as woman_nm,c.pw_crf_1_10 as husband_nm,concat(c.pw_crf_1_11,c.pw_crf_1_12,c.pw_crf_1_13,c.pw_crf_1_14,c.pw_crf_1_15,c.pw_crf_1_16) as dssid, a.last_date_of_attempt,a.date_of_attempt,                     (to_days(str_to_date(a.date_of_attempt,'%d-%m-%Y')) - to_days(str_to_date(a.last_date_of_attempt,'%d-%m-%Y')))*2 	AS Required,        a.empty_sachet,a.actual_empty_sachet,a.remarks,a.entry_nm,a.entry_date from compliance_sachet	as a left join studies as b on a.study_code=b.study_code left join pregnant_woman as c on b.pw_id=c.pw_id where a.study_code like  '%" + txtSearchStudyID.Text.ToUpper() + "%'  order by str_to_date(a.date_of_attempt, '%d-%m-%Y')", con);
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
            form_id = null;
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
                txtDOV.Text = commandArgs[3];
                txtEmptySac.Text = commandArgs[4];
                txtActualEmptySac.Text = commandArgs[5];
                txtremarks.InnerText = commandArgs[6];
                form_id = commandArgs[7];

                Panel2.Visible = false;
                Panel1.Visible = true;
                txtDOV.Focus();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }





        //public void LastDOV()
        //{
        //    MySqlConnection con = new MySqlConnection(ConDataBase);
        //    MySqlCommand cmd = new MySqlCommand("select DATE_FORMAT((str_to_date(date_of_attempt, '%d-%m-%Y')),'%d-%m-%Y') as date_of_attempt from compliance_sachet where DATE_FORMAT((str_to_date(date_of_attempt, '%d-%m-%Y')),'%d-%m-%Y')=(select DATE_FORMAT(max(str_to_date(date_of_attempt, '%d-%m-%Y')),'%d-%m-%Y') from compliance_sachet where 	study_code='" + txtStudyID.Text + "' )		and 	study_code='" + txtStudyID.Text + "'", con);
        //    con.Open();
        //    try
        //    {
        //        MySqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.Read() == true)
        //        {
        //            txtLastDOV.Text = dr["date_of_attempt"].ToString();
        //        }
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}














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
                            MySqlCommand cmd1 = new MySqlCommand("update compliance_sachet set date_of_attempt='" + txtDOV.Text + "', empty_sachet='" + txtEmptySac.Text + "', actual_empty_sachet='" + txtActualEmptySac.Text + "', remarks='" + txtremarks.InnerText + "',	update_date='" + DateTime.Now.ToString("dd-MM-yyyy HH:mm") + "',	update_nm='" + Convert.ToString(Session["MPusernamePW"]) + "' where id='" + form_id + "'", cn);

                            cmd1.ExecuteNonQuery();
                            cn.Close();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record Update Successfully!');window.location.href='checkcompliance.aspx';", true);
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
            MySqlCommand cmd = new MySqlCommand("select * from compliance_sachet where study_code='" + txtStudyID.Text + "' and date_of_attempt='" + txtDOV.Text + "' and id!='" + form_id + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record already exist!');", true);
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



        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtSearchStudyID.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtSearchStudyID.Text != "")
            {
                GridView2.Caption = "Study ID, Search by: " + txtSearchStudyID.Text;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(ConDataBase);
            try
            {

                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.id,b.study_code,c.pw_crf_1_09 as woman_nm,c.pw_crf_1_10 as husband_nm,concat(c.pw_crf_1_11,c.pw_crf_1_12,c.pw_crf_1_13,c.pw_crf_1_14,c.pw_crf_1_15,c.pw_crf_1_16) as dssid, a.last_date_of_attempt,a.date_of_attempt,                     (to_days(str_to_date(a.date_of_attempt,'%d-%m-%Y')) - to_days(str_to_date(a.last_date_of_attempt,'%d-%m-%Y')))*2 	AS Required,        a.empty_sachet,a.actual_empty_sachet,a.remarks,a.entry_nm,a.entry_date from compliance_sachet	as a left join studies as b on a.study_code=b.study_code left join pregnant_woman as c on b.pw_id=c.pw_id where a.study_code like  '%" + txtSearchStudyID.Text.ToUpper() + "%'  order by str_to_date(a.date_of_attempt, '%d-%m-%Y')", con);
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




        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=PW Empty Sachet (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }


    }
}