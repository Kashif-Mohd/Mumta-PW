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
    public partial class showcrf4Compliance : System.Web.UI.Page
    {



        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                Session["WebForm"] = "showcrf4Compliance";
               // ShowData();
                txtdssid.Focus();
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
            txtdssid.Focus();
        }





        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {

                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_crf4 WHERE pw_crf4_22b='2' and DSSID LIKE '%" + txtdssid.Text + "%' 	order by str_to_date(pw_crf4_2, '%d-%m-%Y'), STR_TO_DATE(pw_crf4_3,  '%H:%i')", con);
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




        //protected void Link_Assis(object sender, EventArgs e)
        //{
        //    string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
        //    string form_crf_2 = commandArgs[0];
        //    string AssismentId = commandArgs[1];

        //    Session["form_crf_2"] = form_crf_2;
        //    Session["AssismentIdCRF2"] = AssismentId;
        //    Response.Redirect("showcrf1byid.aspx");
        //}




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
            txtdssid.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
            }
        }



        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }



        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_crf4 WHERE pw_crf4_22b='2' and DSSID LIKE '%" + txtdssid.Text + "%' 	order by str_to_date(pw_crf4_2, '%d-%m-%Y'), STR_TO_DATE(pw_crf4_3,  '%H:%i')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=CRF4 Compliance (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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





































        protected void btn_Unmatched_Click(object sender, EventArgs e)
        {
            ExcelExportUnmatched();
            txtdssid.Focus();
        }



        private void ExcelDataUnmatched()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.form_crf_4_id,b.study_code,a.followup_num,b.date_of_attempt, a.woman_nm,a.husband_nm,a.dssid,a.pw_crf4_27 as Q27_ReceivedbyField,b.empty_sachet as empty_sachet_DIO, b.actual_empty_sachet as Actual_empty_sachet_DIO,a.sra_name  from view_crf4 as a left join compliance_sachet as b on a.study_code=b.study_code and STR_TO_DATE(a.pw_crf4_2,'%d-%m-%Y')=STR_TO_DATE(b.date_of_attempt,'%d-%m-%Y') where a.pw_crf4_27!='' and b.empty_sachet and ( (a.pw_crf4_27-b.actual_empty_sachet)!=0 or (b.actual_empty_sachet is null or b.actual_empty_sachet =''))", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewExportUnmatched.DataSource = dt;
                        GridViewExportUnmatched.DataBind();
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




        public void ExcelExportUnmatched()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Unmatched Empty Sachet (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridViewExportUnmatched.AllowPaging = false;
                ExcelExportMessage();
                GridViewExportUnmatched.CaptionAlign = TableCaptionAlign.Top;

                ExcelDataUnmatched();
                for (int i = 0; i < GridViewExportUnmatched.HeaderRow.Cells.Count; i++)
                {
                    GridViewExportUnmatched.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridViewExportUnmatched.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridViewExportUnmatched.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }

























        protected void btn_Pending_Click(object sender, EventArgs e)
        {
            ExcelExportPending();
            txtdssid.Focus();
        }




        private void ExcelDataPending()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.form_crf_4_id,a.study_code,a.followup_num,a.pw_crf4_2 as DOV, a.woman_nm,a.husband_nm,a.dssid,a.pw_crf4_27 as Q27_ReceivedbyField,b.empty_sachet as empty_sachet_DIO, b.actual_empty_sachet as Actual_empty_sachet_DIO,a.sra_name  from view_crf4 as a left join compliance_sachet as b on a.study_code=b.study_code and STR_TO_DATE(a.pw_crf4_2,'%d-%m-%Y')=STR_TO_DATE(b.date_of_attempt,'%d-%m-%Y') where a.pw_crf4_27!='' and  (b.empty_sachet is null or b.empty_sachet ='') order by STR_TO_DATE(a.pw_crf4_2,'%d-%m-%Y') ", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewExportPending.DataSource = dt;
                        GridViewExportPending.DataBind();
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




        public void ExcelExportPending()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Pending Empty Sachet (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridViewExportPending.AllowPaging = false;
                GridViewExportPending.CaptionAlign = TableCaptionAlign.Top;

                ExcelDataPending();
                for (int i = 0; i < GridViewExportPending.HeaderRow.Cells.Count; i++)
                {
                    GridViewExportPending.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridViewExportPending.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridViewExportPending.RenderControl(htmlWrite);
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