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
    public partial class CumulativeReport : System.Web.UI.Page
    {




        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "CumulativeDatasets";
               // ShowData();
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
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, d.pw_crf_3a_19 AS ARM		 , (CASE WHEN e.`study_code`!='' THEN 		CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(		STR_TO_DATE(e.pw_crf_6a_19, '%d-%m-%Y')	,ea.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(		STR_TO_DATE(e.pw_crf_6a_19, '%d-%m-%Y')	,ea.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(		STR_TO_DATE(e.pw_crf_6a_19, '%d-%m-%Y')	,ea.LMP))/7,'.',1)*7) 	ELSE 			CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE()	,ea.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE()	,ea.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE()	,ea.LMP))/7,'.',1)*7) END) AS gestational_age,	 	(CASE WHEN e.`study_code`!='' THEN 'Outcome Filled' ELSE 'Ongoing' END) AS Pregnancy_Status 	 ,Table_Azo_20.gestational_age AS AZO_GA_20_Weeks ,Table_Azo_28.gestational_age AS AZO_GA_28_Weeks ,(SELECT 	CONCAT(ROUND(((SUM(z.pw_crf4_28)/SUM(		IF((z.pw_crf4_24 IS NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(STR_TO_DATE(z.pw_crf4_2, '%d-%m-%Y'), STR_TO_DATE(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    FROM     form_crf_3a AS Y    WHERE y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  FROM form_crf_4 AS z WHERE z.study_id=c.study_id AND z.pw_crf4_18='1') AS LNS_Cumulative ,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_18b_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Choline_Cumulative ,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19b_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Nicotinamide_Cumulative FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	 LEFT JOIN form_crf_6a AS e ON e.`study_code`=d.`study_code`   	LEFT JOIN (SELECT * FROM (SELECT b.form_crf_1_id,b.`pw_id`,b.`pw_assist_code`,	 DATE_SUB((STR_TO_DATE(b.pw_crf1_02, '%d-%m-%Y')), INTERVAL ((c.pw_crf_1_30_week*7)+c.pw_crf_1_30_days)  DAY) AS LMP  FROM form_crf_1 AS b LEFT JOIN ultrasound_examination AS c ON c.form_crf1_id=b.form_crf_1_id ) AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM form_crf_1 AS z GROUP BY z.pw_assist_code)) AS ea ON ea.pw_id=a.pw_id      	 LEFT JOIN  (SELECT z.* , CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP))/7,'.',1)*7) AS gestational_age FROM form_crf_5a AS z LEFT JOIN studies AS za ON za.study_id=z.study_id	 LEFT JOIN (SELECT * FROM (SELECT b.form_crf_1_id,b.`pw_id`,b.`pw_assist_code`,	 DATE_SUB((STR_TO_DATE(b.pw_crf1_02, '%d-%m-%Y')), INTERVAL ((c.pw_crf_1_30_week*7)+c.pw_crf_1_30_days)  DAY) AS LMP  FROM form_crf_1 AS b LEFT JOIN ultrasound_examination AS c ON c.form_crf1_id=b.form_crf_1_id ) AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM form_crf_1 AS z GROUP BY z.pw_assist_code)) AS e ON e.pw_id=za.pw_id              WHERE z.followup_num BETWEEN '1' AND '6' AND z.pw_crf5a_36='1'         GROUP BY z.study_code ORDER BY z.study_code) AS Table_Azo_20 ON Table_Azo_20.study_id=c.study_id LEFT JOIN  (SELECT z.* , CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP))/7,'.',1)*7) AS gestational_age FROM form_crf_5a AS z LEFT JOIN studies AS za ON za.study_id=z.study_id	 LEFT JOIN (SELECT * FROM (SELECT b.form_crf_1_id,b.`pw_id`,b.`pw_assist_code`,	 DATE_SUB((STR_TO_DATE(b.pw_crf1_02, '%d-%m-%Y')), INTERVAL ((c.pw_crf_1_30_week*7)+c.pw_crf_1_30_days)  DAY) AS LMP  FROM form_crf_1 AS b LEFT JOIN ultrasound_examination AS c ON c.form_crf1_id=b.form_crf_1_id ) AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM form_crf_1 AS z GROUP BY z.pw_assist_code)) AS e ON e.pw_id=za.pw_id              WHERE z.followup_num BETWEEN '7' AND '14' AND z.pw_crf5a_36='1'         GROUP BY z.study_code ORDER BY z.study_code) AS Table_Azo_28  ON Table_Azo_28.study_id=c.study_id WHERE c.study_code IS NOT NULL AND CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%' ORDER BY c.study_code;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
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
            GridView2.Caption = "<h3>Cumulative Datasets (PW-Trial)";
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, d.pw_crf_3a_19 AS ARM		 , (CASE WHEN e.`study_code`!='' THEN 		CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(		STR_TO_DATE(e.pw_crf_6a_19, '%d-%m-%Y')	,ea.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(		STR_TO_DATE(e.pw_crf_6a_19, '%d-%m-%Y')	,ea.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(		STR_TO_DATE(e.pw_crf_6a_19, '%d-%m-%Y')	,ea.LMP))/7,'.',1)*7) 	ELSE 			CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE()	,ea.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE()	,ea.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(		CURDATE()	,ea.LMP))/7,'.',1)*7) END) AS gestational_age,	 	(CASE WHEN e.`study_code`!='' THEN 'Outcome Filled' ELSE 'Ongoing' END) AS Pregnancy_Status 	 ,Table_Azo_20.gestational_age AS AZO_GA_20_Weeks ,Table_Azo_28.gestational_age AS AZO_GA_28_Weeks ,(SELECT 	CONCAT(ROUND(((SUM(z.pw_crf4_28)/SUM(		IF((z.pw_crf4_24 IS NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(STR_TO_DATE(z.pw_crf4_2, '%d-%m-%Y'), STR_TO_DATE(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    FROM     form_crf_3a AS Y    WHERE y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  FROM form_crf_4 AS z WHERE z.study_id=c.study_id AND z.pw_crf4_18='1') AS LNS_Cumulative ,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_18b_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Choline_Cumulative ,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19b_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Nicotinamide_Cumulative FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	 LEFT JOIN form_crf_6a AS e ON e.`study_code`=d.`study_code`   	LEFT JOIN (SELECT * FROM (SELECT b.form_crf_1_id,b.`pw_id`,b.`pw_assist_code`,	 DATE_SUB((STR_TO_DATE(b.pw_crf1_02, '%d-%m-%Y')), INTERVAL ((c.pw_crf_1_30_week*7)+c.pw_crf_1_30_days)  DAY) AS LMP  FROM form_crf_1 AS b LEFT JOIN ultrasound_examination AS c ON c.form_crf1_id=b.form_crf_1_id ) AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM form_crf_1 AS z GROUP BY z.pw_assist_code)) AS ea ON ea.pw_id=a.pw_id      	 LEFT JOIN  (SELECT z.* , CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP))/7,'.',1)*7) AS gestational_age FROM form_crf_5a AS z LEFT JOIN studies AS za ON za.study_id=z.study_id	 LEFT JOIN (SELECT * FROM (SELECT b.form_crf_1_id,b.`pw_id`,b.`pw_assist_code`,	 DATE_SUB((STR_TO_DATE(b.pw_crf1_02, '%d-%m-%Y')), INTERVAL ((c.pw_crf_1_30_week*7)+c.pw_crf_1_30_days)  DAY) AS LMP  FROM form_crf_1 AS b LEFT JOIN ultrasound_examination AS c ON c.form_crf1_id=b.form_crf_1_id ) AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM form_crf_1 AS z GROUP BY z.pw_assist_code)) AS e ON e.pw_id=za.pw_id              WHERE z.followup_num BETWEEN '1' AND '6' AND z.pw_crf5a_36='1'         GROUP BY z.study_code ORDER BY z.study_code) AS Table_Azo_20 ON Table_Azo_20.study_id=c.study_id LEFT JOIN  (SELECT z.* , CONCAT(SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)/7),'.',1)		,'.',    SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP)),'.',1)-SUBSTRING_INDEX(ABS(DATEDIFF(STR_TO_DATE(z.pw_crf5a_02,'%d-%m-%Y'),e.LMP))/7,'.',1)*7) AS gestational_age FROM form_crf_5a AS z LEFT JOIN studies AS za ON za.study_id=z.study_id	 LEFT JOIN (SELECT * FROM (SELECT b.form_crf_1_id,b.`pw_id`,b.`pw_assist_code`,	 DATE_SUB((STR_TO_DATE(b.pw_crf1_02, '%d-%m-%Y')), INTERVAL ((c.pw_crf_1_30_week*7)+c.pw_crf_1_30_days)  DAY) AS LMP  FROM form_crf_1 AS b LEFT JOIN ultrasound_examination AS c ON c.form_crf1_id=b.form_crf_1_id ) AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM form_crf_1 AS z GROUP BY z.pw_assist_code)) AS e ON e.pw_id=za.pw_id              WHERE z.followup_num BETWEEN '7' AND '14' AND z.pw_crf5a_36='1'         GROUP BY z.study_code ORDER BY z.study_code) AS Table_Azo_28  ON Table_Azo_28.study_id=c.study_id WHERE c.study_code IS NOT NULL AND CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%' ORDER BY c.study_code;", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Cumulative Datasets (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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