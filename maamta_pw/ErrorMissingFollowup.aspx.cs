using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace maamta_pw
{
    public partial class ErrorMissingFollowup : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ErrorMissingFollowup";
                ShowData();
            }

        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }






        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT * FROM (SELECT pw_assid,study_id,arm,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,pw_name,husband_name,COUNT(study_id) AS total FROM followups   WHERE study_id!='' AND form!='6' GROUP BY study_id) AS TableA 	WHERE (total<97 AND arm!=4)  OR (total<98 AND arm=4)", con);
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
                cmd = new MySqlCommand("SELECT * FROM (SELECT pw_assid,study_id,arm,concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,pw_name,husband_name,COUNT(study_id) AS total FROM followups   WHERE study_id!='' AND form!='6' GROUP BY study_id) AS TableA 	WHERE (total<97 AND arm!=4)  OR (total<98 AND arm=4)", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
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
                Response.AddHeader("content-disposition", "attachment;filename=Error Compliance (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#e17055");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                    GridView2.HeaderRow.Cells[i].Style.Add("font-size", "15px");
                    GridView2.HeaderRow.Cells[i].Style.Add("height", "30px");
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