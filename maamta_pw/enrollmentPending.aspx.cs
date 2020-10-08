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
    public partial class enrollmentPending : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "enrollmentPending";
                ShowData();
                txtdssid.Focus();
            }
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
                cmd = new MySqlCommand("SELECT a.*, CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE(),			DATE_SUB(STR_TO_DATE(b.`date_of_attempt`,'%d-%m-%Y'),INTERVAL 	((b.`pw_crf_1_30_week` * 7) + b.`pw_crf_1_30_days`)	 DAY))/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(			CURDATE()		,DATE_SUB(STR_TO_DATE(b.`date_of_attempt`,'%d-%m-%Y'),INTERVAL 	((b.`pw_crf_1_30_week` * 7) + b.`pw_crf_1_30_days`)	 DAY))),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(			CURDATE()		,DATE_SUB(STR_TO_DATE(b.`date_of_attempt`,'%d-%m-%Y'),INTERVAL 		((b.`pw_crf_1_30_week` * 7) + b.`pw_crf_1_30_days`)	 DAY) ))/7,'.',1)*7) AS Current_GA, SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) AS block, REPLACE(dss_id,':','') AS dssid FROM followups AS a LEFT JOIN ultrasound_examination AS b ON a.`pw_assid`=b.`pw_assist_code` WHERE a.group_title='3'       AND STR_TO_DATE(a.end_date, '%d-%m-%Y') >= CURDATE()          AND STR_TO_DATE(a.start_date, '%d-%m-%Y') <= CURDATE()      AND a.status='3'  AND REPLACE(dss_id,':','')  LIKE '%" + txtdssid.Text + "%'  GROUP BY b.`pw_assist_code` ORDER BY STR_TO_DATE(end_date, '%d-%m-%Y'),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1)", con);
       //       cmd = new MySqlCommand("select *	,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,	concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid  from followups where group_title='3'       and str_to_date(end_date, '%d-%m-%Y') >= CURDATE()          and str_to_date(start_date, '%d-%m-%Y') <= CURDATE()      and status='3'  and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtdssid.Text + "%' order by str_to_date(end_date, '%d-%m-%Y'),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1)", con);
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




        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }




        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssid.Focus();
        }





        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }



        public void ExcelExportMessage()
        {
            GridView2.Caption = "<h3>Enrollment Pending";
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT a.*, CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE(),			DATE_SUB(STR_TO_DATE(b.`date_of_attempt`,'%d-%m-%Y'),INTERVAL 	((b.`pw_crf_1_30_week` * 7) + b.`pw_crf_1_30_days`)	 DAY))/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(			CURDATE()		,DATE_SUB(STR_TO_DATE(b.`date_of_attempt`,'%d-%m-%Y'),INTERVAL 	((b.`pw_crf_1_30_week` * 7) + b.`pw_crf_1_30_days`)	 DAY))),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(			CURDATE()		,DATE_SUB(STR_TO_DATE(b.`date_of_attempt`,'%d-%m-%Y'),INTERVAL 		((b.`pw_crf_1_30_week` * 7) + b.`pw_crf_1_30_days`)	 DAY) ))/7,'.',1)*7) AS Current_GA, SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) AS block, REPLACE(dss_id,':','') AS dssid FROM followups AS a LEFT JOIN ultrasound_examination AS b ON a.`pw_assid`=b.`pw_assist_code` WHERE a.group_title='3'       AND STR_TO_DATE(a.end_date, '%d-%m-%Y') >= CURDATE()          AND STR_TO_DATE(a.start_date, '%d-%m-%Y') <= (CURDATE() - INTERVAL 3 DAY)        AND a.status='3'  AND REPLACE(dss_id,':','')  LIKE '%" + txtdssid.Text + "%'  GROUP BY b.`pw_assist_code` ORDER BY STR_TO_DATE(end_date, '%d-%m-%Y'),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1)", con);
                // cmd = new MySqlCommand("select *	,SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) as block,	concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) as dssid  from followups where group_title='3' and str_to_date(end_date, '%d-%m-%Y') >= CURDATE()          and str_to_date(start_date, '%d-%m-%Y') <= CURDATE()       and status='3'   and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1)) like '%" + txtdssid.Text + "%' order by str_to_date(end_date, '%d-%m-%Y'),SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1)", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Enrollment Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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