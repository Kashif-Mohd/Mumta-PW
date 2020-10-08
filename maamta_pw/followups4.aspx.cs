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
    public partial class followups4 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "followups4";
                ShowData();
                txtdssid.Focus();
            }
        }

        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = true;
            txtCalndrDate1.Enabled = true;
            CheckBox1.Checked = false;
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false && DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
                txtdssid.Focus();
            }
        }



        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;

                if (CheckBox1.Checked == true)
                {
                    //if (byEndDate.Checked == true)
                    //{
                    //    cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status from followups where form='4' and status='3'  and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE()  and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%' order by study_id, followup_id ", con);
                    //    MySqlDataAdapter sda = new MySqlDataAdapter();
                    //    {
                    //        cmd.Connection = con;
                    //        sda.SelectCommand = cmd;
                    //        DataTable dt = new DataTable();
                    //        {
                    //            sda.Fill(dt);
                    //            GridView1.DataSource = dt;
                    //            GridView1.DataBind();
                    //            con.Close();
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status,Percentage                                            from followups 	LEFT JOIN 	(SELECT TableA.study_code, Consumed_LNS,(DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 AS Need_to_be_used,  CONCAT(ROUND((Consumed_LNS/ ( (DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 )*100),1),'%') AS Percentage FROM  (SELECT z.`study_code`,SUM(z.pw_crf4_28) AS Consumed_LNS FROM form_crf_4 AS z WHERE z.pw_crf4_22b!=1 GROUP BY z.study_code ) AS TableA  LEFT JOIN  (SELECT study_code,DATE_FORMAT(STR_TO_DATE(pw_crf_3a_2,'%d-%m-%Y'),'%d-%m-%Y')  AS date_of_registration FROM form_crf_3a) AS TableB ON TableA.study_code=TableB.study_code LEFT JOIN  (SELECT study_code, DATE_FORMAT(MAX(STR_TO_DATE(pw_crf4_2,'%d-%m-%Y')),'%d-%m-%Y') AS last_DOV FROM form_crf_4 WHERE pw_crf4_22b!=1   GROUP BY study_code)AS TableC ON TableA.study_code=TableC.study_code ) AS TableD 	ON TableD.study_code=followups.study_id					where form='4' and status='3'  and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE()  and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%' order by study_id, followup_id ", con);
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
                    //}
                }
                else
                {
                    if (byEndDate.Checked == true)
                    {
                        cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status,Percentage                                                   from followups	LEFT JOIN 	(SELECT TableA.study_code, Consumed_LNS,(DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 AS Need_to_be_used,  CONCAT(ROUND((Consumed_LNS/ ( (DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 )*100),1),'%') AS Percentage FROM  (SELECT z.`study_code`,SUM(z.pw_crf4_28) AS Consumed_LNS FROM form_crf_4 AS z WHERE z.pw_crf4_22b!=1 GROUP BY z.study_code ) AS TableA  LEFT JOIN  (SELECT study_code,DATE_FORMAT(STR_TO_DATE(pw_crf_3a_2,'%d-%m-%Y'),'%d-%m-%Y')  AS date_of_registration FROM form_crf_3a) AS TableB ON TableA.study_code=TableB.study_code LEFT JOIN  (SELECT study_code, DATE_FORMAT(MAX(STR_TO_DATE(pw_crf4_2,'%d-%m-%Y')),'%d-%m-%Y') AS last_DOV FROM form_crf_4 WHERE pw_crf4_22b!=1   GROUP BY study_code)AS TableC ON TableA.study_code=TableC.study_code ) AS TableD 	ON TableD.study_code=followups.study_id					 where form='4' and status='3' and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE()  and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%'  and (str_to_date(DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y'), '%d-%m-%Y')  between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by study_id, followup_id ", con);
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
                    else
                    {
                        cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status , Percentage                                                   from followups 	LEFT JOIN 	(SELECT TableA.study_code, Consumed_LNS,(DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 AS Need_to_be_used,  CONCAT(ROUND((Consumed_LNS/ ( (DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 )*100),1),'%') AS Percentage FROM  (SELECT z.`study_code`,SUM(z.pw_crf4_28) AS Consumed_LNS FROM form_crf_4 AS z WHERE z.pw_crf4_22b!=1 GROUP BY z.study_code ) AS TableA  LEFT JOIN  (SELECT study_code,DATE_FORMAT(STR_TO_DATE(pw_crf_3a_2,'%d-%m-%Y'),'%d-%m-%Y')  AS date_of_registration FROM form_crf_3a) AS TableB ON TableA.study_code=TableB.study_code LEFT JOIN  (SELECT study_code, DATE_FORMAT(MAX(STR_TO_DATE(pw_crf4_2,'%d-%m-%Y')),'%d-%m-%Y') AS last_DOV FROM form_crf_4 WHERE pw_crf4_22b!=1   GROUP BY study_code)AS TableC ON TableA.study_code=TableC.study_code ) AS TableD 	ON TableD.study_code=followups.study_id					 where form='4' and status='3'   and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE()  and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%'  and (str_to_date(start_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by study_id, followup_id ", con);
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
            txtdssid.Focus();
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

                if (CheckBox1.Checked == true)
                {
                    //if (byEndDate.Checked == true)
                    //{
                    //    cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D' END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status from followups where form='4' and status='3'  and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%' order by study_id, followup_id ", con);
                    //    MySqlDataAdapter sda = new MySqlDataAdapter();
                    //    {
                    //        cmd.Connection = con;
                    //        sda.SelectCommand = cmd;
                    //        DataTable dt = new DataTable();
                    //        {
                    //            sda.Fill(dt);
                    //            GridView2.DataSource = dt;
                    //            GridView2.DataBind();
                    //            con.Close();
                    //        }							
                    //    }
                    //}
                    //else
                    //{
                    cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status, Percentage                                                                               from followups 	LEFT JOIN 	(SELECT TableA.study_code, Consumed_LNS,(DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 AS Need_to_be_used,  CONCAT(ROUND((Consumed_LNS/ ( (DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 )*100),1),'%') AS Percentage FROM  (SELECT z.`study_code`,SUM(z.pw_crf4_28) AS Consumed_LNS FROM form_crf_4 AS z WHERE z.pw_crf4_22b!=1 GROUP BY z.study_code ) AS TableA  LEFT JOIN  (SELECT study_code,DATE_FORMAT(STR_TO_DATE(pw_crf_3a_2,'%d-%m-%Y'),'%d-%m-%Y')  AS date_of_registration FROM form_crf_3a) AS TableB ON TableA.study_code=TableB.study_code LEFT JOIN  (SELECT study_code, DATE_FORMAT(MAX(STR_TO_DATE(pw_crf4_2,'%d-%m-%Y')),'%d-%m-%Y') AS last_DOV FROM form_crf_4 WHERE pw_crf4_22b!=1   GROUP BY study_code)AS TableC ON TableA.study_code=TableC.study_code ) AS TableD 	ON TableD.study_code=followups.study_id					 where form='4' and status='3'  and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE()   and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%' order by study_id, followup_id ", con);
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
                    // }
                }
                else
                {
                    if (byEndDate.Checked == true)
                    {
                        cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status , Percentage                                                                   from followups 	LEFT JOIN 	(SELECT TableA.study_code, Consumed_LNS,(DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 AS Need_to_be_used,  CONCAT(ROUND((Consumed_LNS/ ( (DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 )*100),1),'%') AS Percentage FROM  (SELECT z.`study_code`,SUM(z.pw_crf4_28) AS Consumed_LNS FROM form_crf_4 AS z WHERE z.pw_crf4_22b!=1 GROUP BY z.study_code ) AS TableA  LEFT JOIN  (SELECT study_code,DATE_FORMAT(STR_TO_DATE(pw_crf_3a_2,'%d-%m-%Y'),'%d-%m-%Y')  AS date_of_registration FROM form_crf_3a) AS TableB ON TableA.study_code=TableB.study_code LEFT JOIN  (SELECT study_code, DATE_FORMAT(MAX(STR_TO_DATE(pw_crf4_2,'%d-%m-%Y')),'%d-%m-%Y') AS last_DOV FROM form_crf_4 WHERE pw_crf4_22b!=1   GROUP BY study_code)AS TableC ON TableA.study_code=TableC.study_code ) AS TableD 	ON TableD.study_code=followups.study_id					 where form='4' and status='3'   and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE() and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%'  and (str_to_date(DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y'), '%d-%m-%Y')  between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by study_id, followup_id ", con);
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
                    else
                    {
                        cmd = new MySqlCommand("select followup_id, site, followup_no, pw_assid, study_id, concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) as dssid,  pw_name,husband_name, (CASE WHEN arm= '1' THEN 'A' WHEN arm = '2' THEN 'B' WHEN arm = '3' THEN 'C' WHEN arm = '4' THEN 'D'  END) as ARM,start_date, DAYNAME(str_to_date(start_date, '%d-%m-%Y')) as Day, DATE_FORMAT(DATE_SUB(str_to_date(end_date, '%d-%m-%Y'), interval 1 day), '%d-%m-%Y') as end_date, status  , Percentage                                                                      from followups 	LEFT JOIN 	(SELECT TableA.study_code, Consumed_LNS,(DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 AS Need_to_be_used,  CONCAT(ROUND((Consumed_LNS/ ( (DATEDIFF(	STR_TO_DATE(TableC.last_DOV,'%d-%m-%Y'),		STR_TO_DATE(TableB.date_of_registration,'%d-%m-%Y')))*2 )*100),1),'%') AS Percentage FROM  (SELECT z.`study_code`,SUM(z.pw_crf4_28) AS Consumed_LNS FROM form_crf_4 AS z WHERE z.pw_crf4_22b!=1 GROUP BY z.study_code ) AS TableA  LEFT JOIN  (SELECT study_code,DATE_FORMAT(STR_TO_DATE(pw_crf_3a_2,'%d-%m-%Y'),'%d-%m-%Y')  AS date_of_registration FROM form_crf_3a) AS TableB ON TableA.study_code=TableB.study_code LEFT JOIN  (SELECT study_code, DATE_FORMAT(MAX(STR_TO_DATE(pw_crf4_2,'%d-%m-%Y')),'%d-%m-%Y') AS last_DOV FROM form_crf_4 WHERE pw_crf4_22b!=1   GROUP BY study_code)AS TableC ON TableA.study_code=TableC.study_code ) AS TableD 	ON TableD.study_code=followups.study_id					 where form='4' and status='3'  and  str_to_date(start_date, '%d-%m-%Y') <= CURDATE()   and concat(SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 1), ':', -1), SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 2), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 3), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 4), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 5), ':', -1) , SUBSTRING_INDEX(SUBSTRING_INDEX(dss_id, ':', 6), ':', -1) ) like '%" + txtdssid.Text + "%'  and (str_to_date(start_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by study_id, followup_id ", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=PW_Followup-4 (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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