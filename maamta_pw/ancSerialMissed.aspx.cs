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
    public partial class ancSerialMissed : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ancSerialNo";
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
                cmd = new MySqlCommand("select a.anc_visit_id,a.date_of_attempt as DOV,b.assis_id,b.pw_crf_1_09 as woman_nm,b.pw_crf_1_10 as husband_nm,concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) as dssid,b.pw_status,a.anc_visit_48, c.study_code,c.pw_crf_3a_2 as Enrollment_Date from anc_visit_details as a left join pregnant_woman as b on a.pw_id=b.pw_id left join form_crf_3a as c on c.pw_id=b.pw_id where (LENGTH(a.anc_visit_48)!=11 or a.anc_visit_48 like '%00000/00/00%') and concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) like '%" + txtdssid.Text + "%' and  b.assis_id not in (select a.pw_assist_id from  anc_visit_details as a where (LENGTH(a.anc_visit_48)=11 and a.anc_visit_48 not like '%00000/00/00%') group by a.pw_assist_id)  			order by STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y'),assis_id", con);
                //cmd = new MySqlCommand("select a.anc_visit_id,a.date_of_attempt as DOV,b.assis_id,b.pw_crf_1_09 as woman_nm,b.pw_crf_1_10 as husband_nm,concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) as dssid,b.pw_status,a.anc_visit_48, c.study_code,c.pw_crf_3a_2 as Enrollment_Date from anc_visit_details as a left join pregnant_woman as b on a.pw_id=b.pw_id left join form_crf_3a as c on c.pw_id=b.pw_id where (LENGTH(a.anc_visit_48)!=11 or a.anc_visit_48 like '%00000/00/00%') and concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) like '%" + txtdssid.Text + "%' order by STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y'),assis_id", con);
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
            GridView2.Caption = "<h3>Serial Number Incomplete or Missed";
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.anc_visit_id,a.date_of_attempt as DOV,b.assis_id,b.pw_crf_1_09 as woman_nm,b.pw_crf_1_10 as husband_nm,concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) as dssid,b.pw_status,a.anc_visit_48, c.study_code,c.pw_crf_3a_2 as Enrollment_Date from anc_visit_details as a left join pregnant_woman as b on a.pw_id=b.pw_id left join form_crf_3a as c on c.pw_id=b.pw_id where (LENGTH(a.anc_visit_48)!=11 or a.anc_visit_48 like '%00000/00/00%') and concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) like '%" + txtdssid.Text + "%' and  b.assis_id not in (select a.pw_assist_id from  anc_visit_details as a where (LENGTH(a.anc_visit_48)=11 and a.anc_visit_48 not like '%00000/00/00%') group by a.pw_assist_id)  			order by STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y'),assis_id", con);
                //cmd = new MySqlCommand("select a.anc_visit_id,a.date_of_attempt as DOV,b.assis_id,b.pw_crf_1_09 as woman_nm,b.pw_crf_1_10 as husband_nm,concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) as dssid,b.pw_status,a.anc_visit_48, c.study_code,c.pw_crf_3a_2 as Enrollment_Date from anc_visit_details as a left join pregnant_woman as b on a.pw_id=b.pw_id left join form_crf_3a as c on c.pw_id=b.pw_id where (LENGTH(a.anc_visit_48)!=11 or a.anc_visit_48 like '%00000/00/00%') and concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) like '%" + txtdssid.Text + "%' order by STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y'),assis_id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=ANC Serial Missed (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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