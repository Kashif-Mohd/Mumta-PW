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
    public partial class expectedOutcomeEnrolled : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "expectedOutcomeEnrolled";
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
                cmd = new MySqlCommand("SELECT a.assis_id,c.study_code,a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm, a.dssid,  a.Block,			 DATE_FORMAT((str_to_date(a.pw_crf1_02, '%d-%m-%Y') + INTERVAL (280 - ((a.pw_crf_1_30_week * 7) + a.pw_crf_1_30_days)) DAY),'%d-%m-%Y')  as Expected_Date  FROM view_crf1 as a  left join pregnant_woman as b on a.assis_id=b.assis_id left join studies as c on c.pw_id=b.pw_id	   where 	 str_to_date(DATE_FORMAT((str_to_date(a.pw_crf1_02, '%d-%m-%Y') + INTERVAL (280 - ((a.pw_crf_1_30_week * 7) +a.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y')  <= (CURDATE() + INTERVAL 90 DAY)								and a.examination_id in (select min(b.examination_id) from view_crf1 as b where a.assis_id=b.assis_id and a.pw_crf1_02=b.pw_crf1_02 GROUP by b.assis_id) and a.dssid like '%" + txtdssid.Text + "%'  and a.assis_id not in (select z.assis_id from form_crf_6b as x left join studies as y on x.study_id=y.study_id left join pregnant_woman as z on y.pw_id=z.pw_id) and a.assis_id in (select z.assis_id from form_crf_3a as x left join studies as y on x.study_id=y.study_id left join pregnant_woman as z on y.pw_id=z.pw_id) group by a.assis_id order by a.Block", con);
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
            GridView2.Caption = "<h3>Expected Outcome by Ultrasound";
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT a.assis_id,c.study_code,a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm, a.dssid,  a.Block,			 DATE_FORMAT((str_to_date(a.pw_crf1_02, '%d-%m-%Y') + INTERVAL (280 - ((a.pw_crf_1_30_week * 7) + a.pw_crf_1_30_days)) DAY),'%d-%m-%Y')  as Expected_Date  FROM view_crf1 as a  left join pregnant_woman as b on a.assis_id=b.assis_id left join studies as c on c.pw_id=b.pw_id	   where 	 str_to_date(DATE_FORMAT((str_to_date(a.pw_crf1_02, '%d-%m-%Y') + INTERVAL (280 - ((a.pw_crf_1_30_week * 7) +a.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y')  <= (CURDATE() + INTERVAL 90 DAY)								and a.examination_id in (select min(b.examination_id) from view_crf1 as b where a.assis_id=b.assis_id and a.pw_crf1_02=b.pw_crf1_02 GROUP by b.assis_id) and a.dssid like '%" + txtdssid.Text + "%'  and a.assis_id not in (select z.assis_id from form_crf_6b as x left join studies as y on x.study_id=y.study_id left join pregnant_woman as z on y.pw_id=z.pw_id) and a.assis_id in (select z.assis_id from form_crf_3a as x left join studies as y on x.study_id=y.study_id left join pregnant_woman as z on y.pw_id=z.pw_id) group by a.assis_id order by a.Block", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Outcome List Enrolled (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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