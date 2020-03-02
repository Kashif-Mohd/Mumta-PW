﻿using System;
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
    public partial class dashUltra : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashUltra";
                txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                lbeUname.Text = Convert.ToString(Session["MPusernamePW"]);
                txtCalndrDate.Attributes.Add("readonly", "readonly");
                txtCalndrDate1.Attributes.Add("readonly", "readonly");
                ShowData();
            }
        }




        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
                ShowDuplicate();
            }
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select b.sra_name,count(*) as total from form_crf_1 as a left join team as b on a.team_id=b.team_id where (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) group by a.team_id", con);

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


        private void ShowDuplicate()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT count(*) AS duplicate FROM (SELECT count(*) as total,concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) as dssid from form_crf_1 as a left join pregnant_woman as b on a.pw_id=b.pw_id where (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) group by concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16),pw_crf1_02 having count(concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16))>1 ) AS t", con);
                {
                    dreader = cmd.ExecuteReader();
                    if (dreader.Read())
                    {
                        linkDuplicate.Text = dreader["duplicate"].ToString();
                    }
                    con.Close();
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


        Int32 total = 0;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total = total + Convert.ToInt32(e.Row.Cells[2].Text);
                lbeTotal.Text = total.ToString();
            }
        }


        protected void Link_Duplicate(object sender, EventArgs e)
        {
            //if (((LinkButton)sender).Text != "0")
            //{
            //    Session["showcrf1Hide"] = "showcrf1Hide";
            //    Session["FirstEDate"] = txtCalndrDate.Text;
            //    Session["SecEDate"] = txtCalndrDate1.Text;
            //    Response.Redirect("showcrf1.aspx");
            //}
        }





















        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
        }

        public void ExcelExportMessage()
        {
            GridView2.Caption = "<h2/>MAAMTA PW trial<br/>   <h4/>Pregnant Women (PW) Screened and Enrolled <br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
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
                //Date Wise
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT  (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AS z) AS   'Ultrasound between Dates', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ( 	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)    + DATEDIFF(STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'),STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y'))  )<56   GROUP BY a.form_crf_1_id) AS z) AS 'G.A <8 weeks', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND  	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)>=133   GROUP BY a.form_crf_1_id) AS z) AS 'G.A >19 weeks', (SELECT COUNT(form_crf_1_id)   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND pw_crf_1_30_week=0 	AND pw_crf_1_30_days=0	)		AS 'Other Exclusion (0 weeks)', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus>1 GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))   GROUP BY a.form_crf_1_id) AS z) AS 'More than one Fetus', (SELECT COUNT(a.form_crf_1_id)   FROM view_crf1 AS a WHERE 		a.form_crf_1_id NOT IN (SELECT form_crf_1_id   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND pw_crf_1_30_week=0 	AND pw_crf_1_30_days=0	)	AND 	 a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND	 ((pw_crf_1_30_week * 7)+pw_crf_1_30_days)<133		AND		((pw_crf_1_30_week * 7)+pw_crf_1_30_days   	)>=56 		)		AS 'G.A >8 weeks and <19 weeks and Singleton', (SELECT COUNT(form_crf_1_id) FROM (SELECT *  FROM view_crf1 AS a WHERE 	a.form_crf_1_id NOT IN (SELECT form_crf_1_id   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND pw_crf_1_30_week=0 	AND pw_crf_1_30_days=0	)	AND 	a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND 	(	DATE_ADD(STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y'), INTERVAL 56-( (pw_crf_1_30_week * 7)+pw_crf_1_30_days) DAY)		BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ( 	((pw_crf_1_30_week * 7) + pw_crf_1_30_days)      )<56  		AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y')		BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))		 GROUP BY a.form_crf_1_id) AS z) AS 'G.A < 8 weeks Now Eligible (b/w Date)', (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3'  AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE  a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT a.assis_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id)  AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') < STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') )))  AS 'Previous Ultrasound, G.A < 8 weeks Now Eligible', (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3'  AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id)  AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') < STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') ))) AS 'Total Ultrasound, Now G.A >8 weeks and <19 weeks and Singleton', (SELECT COUNT(crf2_id) FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))) AS   'Women Approached',   (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3' AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') ))            AND aa.pw_assid NOT IN                     (SELECT pw_assid	 FROM followups AS aa WHERE group_title='3' AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN        (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') )))	) AS '(Over Age) Ultrasound, G.A >8 weeks and <19 weeks and Singleton',  (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3' AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') ))) AS '(Pending) Ultrasound, G.A >8 weeks and <19 weeks and Singleton'", con);

                // Before 29-02-2020
                //MySqlCommand cmd = new MySqlCommand("SELECT (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AS z) AS   'Ultrasound between Dates', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ( 	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)    + DATEDIFF(STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'),STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y'))  )<56   GROUP BY a.form_crf_1_id) AS z) AS 'G.A <8 weeks',(SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND  	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)>=133   GROUP BY a.form_crf_1_id) AS z) AS 'G.A >19 weeks',(SELECT COUNT(form_crf_1_id)   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND pw_crf_1_30_week=0 	AND pw_crf_1_30_days=0	)		AS 'Other Exclusion (0 weeks)',(SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus>1 GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))   GROUP BY a.form_crf_1_id) AS z) AS 'More than one Fetus',(SELECT COUNT(a.form_crf_1_id)   FROM view_crf1 AS a WHERE 		a.form_crf_1_id NOT IN (SELECT form_crf_1_id   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND pw_crf_1_30_week=0 	AND pw_crf_1_30_days=0	)	AND 	 a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND	 ((pw_crf_1_30_week * 7)+pw_crf_1_30_days)<133		AND		((pw_crf_1_30_week * 7)+pw_crf_1_30_days   	)>=56 		)		AS 'G.A >8 weeks and <19 weeks and Singleton',(SELECT COUNT(form_crf_1_id) FROM (SELECT *  FROM view_crf1 AS a WHERE 	a.form_crf_1_id NOT IN (SELECT form_crf_1_id   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND pw_crf_1_30_week=0 	AND pw_crf_1_30_days=0	)	AND 	a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND 	(	DATE_ADD(STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y'), INTERVAL 56-( (pw_crf_1_30_week * 7)+pw_crf_1_30_days) DAY)		BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ( 	((pw_crf_1_30_week * 7) + pw_crf_1_30_days)      )<56  		AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y')		BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))		 GROUP BY a.form_crf_1_id) AS z) AS 'G.A < 8 weeks Now Eligible (b/w Date)',(SELECT COUNT(*) FROM followups AS aa WHERE group_title='3'  AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE  a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT a.assis_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id)  AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') < STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') )))  AS 'Previous Ultrasound, G.A < 8 weeks Now Eligible',(SELECT COUNT(*) FROM followups AS aa WHERE group_title='3'  AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id)  AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') < STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') ))) AS 'Total Ultrasound, Now G.A >8 weeks and <19 weeks and Singleton',(SELECT COUNT(crf2_id) FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))) AS   'Women Approached',(SELECT COUNT(*) FROM followups AS aa WHERE group_title='3' AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') ))) AS '(Pending) Ultrasound Now G.A >8 weeks and <19 weeks and Singleton'", con);

                // Before 22-02-2020
                //MySqlCommand cmd = new MySqlCommand("SELECT (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AS z) AS   'Ultrasound between Dates', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ( 	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)    + DATEDIFF(STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'),STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y'))  )<56   GROUP BY a.form_crf_1_id) AS z) AS 'G.A <8 weeks', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND  	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)>=133   GROUP BY a.form_crf_1_id) AS z) AS 'G.A >19 weeks', (SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus>1 GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))   GROUP BY a.form_crf_1_id) AS z) AS 'More than one Fetus', (SELECT COUNT(form_crf_1_id)   FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ((pw_crf_1_30_week * 7)+pw_crf_1_30_days)<133		AND	(	((pw_crf_1_30_week * 7)+pw_crf_1_30_days   	)>=56 		))		AS 'G.A >8 weeks and <19 weeks and Singleton',  ((SELECT COUNT(form_crf_1_id) FROM (SELECT a.form_crf_1_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z WHERE z.no_of_fetus='1' GROUP BY z.assis_id) AND 	(	DATE_ADD(STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y'), INTERVAL 56-( (pw_crf_1_30_week * 7)+pw_crf_1_30_days) DAY)		BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  AND ( 	((pw_crf_1_30_week * 7) + pw_crf_1_30_days)      )<56  		AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y')		BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))		 GROUP BY a.form_crf_1_id) AS z)        +            (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3'  AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT a.assis_id  FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id)  AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') < STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') )))) AS 'Previous Ultrasound, G.A < 8 weeks Now Eligible', (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3'  AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id)  AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') < STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') ))) AS 'Total Ultrasound, Now G.A >8 weeks and <19 weeks and Singleton', (SELECT COUNT(crf2_id) FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  AND (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))) AS   'Women Approached', (SELECT COUNT(*) FROM followups AS aa WHERE group_title='3' AND   	 STR_TO_DATE(aa.end_date, '%d-%m-%Y') >= STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y') AND STR_TO_DATE(aa.start_date, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   AND aa.pw_assid IN (SELECT a.assis_id FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z  GROUP BY z.assis_id) AND (STR_TO_DATE(a.pw_crf1_02, '%d-%m-%Y') >= STR_TO_DATE('17-04-2019', '%d-%m-%Y'))  GROUP BY a.form_crf_1_id) AND aa.pw_assid NOT IN (SELECT assist_code FROM form_crf_2 AS a WHERE (STR_TO_DATE(a.pw_crf2_2, '%d-%m-%Y') <= STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y') ))) AS '(Pending) Ultrasound Now G.A >8 weeks and <19 weeks and Singleton'", con);
                
                // Before 12-02-2020
                //MySqlCommand cmd = new MySqlCommand("select (select count(form_crf_1_id) from (select a.form_crf_1_id  from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z  group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  group by a.form_crf_1_id) as z) as   'Ultrasound between Dates', (select count(form_crf_1_id) from (select a.form_crf_1_id  from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z where z.no_of_fetus='1' group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  and ( 	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)    + DATEDIFF(str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'),str_to_date(a.pw_crf1_02, '%d-%m-%Y'))  )<56   group by a.form_crf_1_id) as z) as 'G.A <8 weeks', (select count(form_crf_1_id) from (select a.form_crf_1_id  from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z where z.no_of_fetus='1' group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  and  	((pw_crf_1_30_week * 7)+pw_crf_1_30_days)>=133   group by a.form_crf_1_id) as z) as 'G.A >19 weeks', (select count(form_crf_1_id) from (select a.form_crf_1_id  from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z where z.no_of_fetus>1 group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))   group by a.form_crf_1_id) as z) as 'More than one Fetus', (select count(form_crf_1_id)   from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z where z.no_of_fetus='1' group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  and ((pw_crf_1_30_week * 7)+pw_crf_1_30_days)<133		and	(	((pw_crf_1_30_week * 7)+pw_crf_1_30_days   	)>=56 		))		as 'G.A >8 weeks and <19 weeks and Singleton', (select count(form_crf_1_id) from (select a.form_crf_1_id  from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z where z.no_of_fetus='1' group by z.assis_id) and 	(	DATE_ADD(str_to_date(a.pw_crf1_02, '%d-%m-%Y'), INTERVAL 56-( (pw_crf_1_30_week * 7)+pw_crf_1_30_days) DAY)		between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  and ( 	((pw_crf_1_30_week * 7) + pw_crf_1_30_days)      )<56  		and (str_to_date(a.pw_crf1_02, '%d-%m-%Y')		between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))		 group by a.form_crf_1_id) as z) as 'G.A < 8 weeks Now Eligible', (select count(*) from followups as aa where group_title='3'  and   	 str_to_date(aa.end_date, '%d-%m-%Y') >= str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date(aa.start_date, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   and aa.pw_assid in (select a.assis_id from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z  group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  group by a.form_crf_1_id) and aa.pw_assid not in (select a.assis_id  from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z  group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  group by a.form_crf_1_id)  and aa.pw_assid not in (select assist_code from form_crf_2 as a where (str_to_date(a.pw_crf2_2, '%d-%m-%Y') < str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') ))) as 'Previous Ultrasound, Now G.A >8 weeks and <19 weeks and Singleton', (select count(*) from followups as aa where group_title='3'  and   	 str_to_date(aa.end_date, '%d-%m-%Y') >= str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date(aa.start_date, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   and aa.pw_assid in (select a.assis_id from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z  group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  group by a.form_crf_1_id)  and aa.pw_assid not in (select assist_code from form_crf_2 as a where (str_to_date(a.pw_crf2_2, '%d-%m-%Y') < str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') ))) as 'Total Ultrasound, Now G.A >8 weeks and <19 weeks and Singleton', (select count(crf2_id) from form_crf_2 as a where (str_to_date(a.pw_crf2_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and (str_to_date(a.pw_crf2_2, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))) as   'Women Approached', (select count(*) from followups as aa where group_title='3' and   	 str_to_date(aa.end_date, '%d-%m-%Y') >= str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date(aa.start_date, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   and aa.pw_assid in (select a.assis_id from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z  group by z.assis_id) and (str_to_date(a.pw_crf1_02, '%d-%m-%Y') >= str_to_date('18-03-2019', '%d-%m-%Y'))  group by a.form_crf_1_id) and aa.pw_assid not in (select assist_code from form_crf_2 as a where (str_to_date(a.pw_crf2_2, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') ))) as '(Pending) Ultrasound Now G.A >8 weeks and <19 weeks and Singleton'", con);

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
                Response.AddHeader("content-disposition", "attachment;filename=Screening Report (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                    GridView2.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView2.HeaderRow.Cells[i].Style.Add("height", "80px");
                    //GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
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