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
    public partial class ancPending : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ancPending";
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
                cmd = new MySqlCommand("SELECT a.assis_id,a.pw_crf_1_13 AS block, CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid, a.pw_crf_1_09 AS woman_nm, a.pw_crf_1_10 AS husband_nm,b.pw_crf1_02 AS screening_date,CONCAT(z.pw_crf_1_30_week,'.',z.pw_crf_1_30_days) AS ultrasound_Weeks, CONCAT(SUBSTRING_INDEX(ABS(	(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))))	/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(	(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))))	),'.',1)-SUBSTRING_INDEX(ABS(		(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))))	)/7,'.',1)*7) AS current_ga 		,(SELECT (CASE WHEN z.study_code!='' THEN 'Enrolled' ELSE '' END)  FROM view_crf3a AS z WHERE z.`assis_id`=a.`assis_id`) AS STATUS         FROM pregnant_woman AS a LEFT JOIN (SELECT * FROM form_crf_1 WHERE form_crf_1_id IN (SELECT MAX(form_crf_1_id) AS form_crf_1_id FROM form_crf_1 GROUP BY pw_id)) AS b ON a.assis_id=b.pw_assist_code LEFT JOIN (SELECT * FROM ultrasound_examination WHERE examination_id IN (SELECT MAX(examination_id) FROM ultrasound_examination GROUP BY pw_assist_code)) AS z ON z.form_crf1_id=b.form_crf_1_id 	WHERE 		(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))) ) <301		AND	(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days)	 +	 (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y')))  ) > 70 		AND NOT EXISTS (SELECT * FROM  anc_form AS c WHERE a.assis_id=c.pw_assist_code) AND CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%'                   AND a.`pw_id` NOT IN (SELECT pw_id FROM form_crf_6a)                AND CONCAT(z.pw_crf_1_30_week,'.',z.pw_crf_1_30_days)!='00.0' GROUP BY a.assis_id  ORDER BY  a.pw_crf_1_13,a.pw_crf_1_14,STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y')", con);
               // cmd = new MySqlCommand("select a.assis_id, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid, a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm,b.pw_crf1_02 as screening_date,concat(z.pw_crf_1_30_week,'.',z.pw_crf_1_30_days) as ultrasound_Weeks,	(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (to_days(curdate()) - to_days(str_to_date(b.pw_crf1_02,'%d-%m-%Y'))))	AS currentPW_days		   from pregnant_woman as a left join (select * from form_crf_1 where form_crf_1_id in (select max(form_crf_1_id) as form_crf_1_id from form_crf_1 group by pw_id)) as b on a.assis_id=b.pw_assist_code left join (select * from ultrasound_examination where examination_id in (select max(examination_id) from ultrasound_examination group by pw_assist_code)) as z on z.form_crf1_id=b.form_crf_1_id 	where 		(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (to_days(curdate()) - to_days(str_to_date(b.pw_crf1_02,'%d-%m-%Y'))) ) <301		and	(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days)	 +	 (to_days(curdate()) - to_days(str_to_date(b.pw_crf1_02,'%d-%m-%Y')))  ) > 70 		and not exists (select * from  anc_form as c where a.assis_id=c.pw_assist_code) and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%' group by a.assis_id  order by  str_to_date(b.pw_crf1_02,'%d-%m-%Y')", con);
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
            GridView2.Caption = "<h3>Ultrasound done but ANC Visit Pending";
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT a.assis_id,a.pw_crf_1_13 AS block, CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid, a.pw_crf_1_09 AS woman_nm, a.pw_crf_1_10 AS husband_nm,b.pw_crf1_02 AS screening_date,CONCAT(z.pw_crf_1_30_week,'.',z.pw_crf_1_30_days) AS ultrasound_Weeks, CONCAT(SUBSTRING_INDEX(ABS(	(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))))	/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(	(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))))	),'.',1)-SUBSTRING_INDEX(ABS(		(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))))	)/7,'.',1)*7) AS current_ga 		,(SELECT (CASE WHEN z.study_code!='' THEN 'Enrolled' ELSE '' END)  FROM view_crf3a AS z WHERE z.`assis_id`=a.`assis_id`) AS STATUS         FROM pregnant_woman AS a LEFT JOIN (SELECT * FROM form_crf_1 WHERE form_crf_1_id IN (SELECT MAX(form_crf_1_id) AS form_crf_1_id FROM form_crf_1 GROUP BY pw_id)) AS b ON a.assis_id=b.pw_assist_code LEFT JOIN (SELECT * FROM ultrasound_examination WHERE examination_id IN (SELECT MAX(examination_id) FROM ultrasound_examination GROUP BY pw_assist_code)) AS z ON z.form_crf1_id=b.form_crf_1_id 	WHERE 		(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y'))) ) <301		AND	(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days)	 +	 (TO_DAYS(CURDATE()) - TO_DAYS(STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y')))  ) > 70 		AND NOT EXISTS (SELECT * FROM  anc_form AS c WHERE a.assis_id=c.pw_assist_code) AND CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%'              AND a.`pw_id` NOT IN (SELECT pw_id FROM form_crf_6a)                     AND CONCAT(z.pw_crf_1_30_week,'.',z.pw_crf_1_30_days)!='00.0' GROUP BY a.assis_id  ORDER BY  a.pw_crf_1_13,a.pw_crf_1_14,STR_TO_DATE(b.pw_crf1_02,'%d-%m-%Y')", con);
                // cmd = new MySqlCommand("select a.assis_id, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid, a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm,b.pw_crf1_02 as screening_date,concat(z.pw_crf_1_30_week,'.',z.pw_crf_1_30_days) as ultrasound_Weeks,	(((z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (to_days(curdate()) - to_days(str_to_date(b.pw_crf1_02,'%d-%m-%Y'))))	AS currentPW_days		   from pregnant_woman as a left join (select * from form_crf_1 where form_crf_1_id in (select max(form_crf_1_id) as form_crf_1_id from form_crf_1 group by pw_id)) as b on a.assis_id=b.pw_assist_code left join (select * from ultrasound_examination where examination_id in (select max(examination_id) from ultrasound_examination group by pw_assist_code)) as z on z.form_crf1_id=b.form_crf_1_id 	where 		(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days) + (to_days(curdate()) - to_days(str_to_date(b.pw_crf1_02,'%d-%m-%Y'))) ) <301		and	(( (z.pw_crf_1_30_week * 7) + z.pw_crf_1_30_days)	 +	 (to_days(curdate()) - to_days(str_to_date(b.pw_crf1_02,'%d-%m-%Y')))  ) > 70 		and not exists (select * from  anc_form as c where a.assis_id=c.pw_assist_code) and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%' group by a.assis_id  order by  str_to_date(b.pw_crf1_02,'%d-%m-%Y')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=ANC Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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