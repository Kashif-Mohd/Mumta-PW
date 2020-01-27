using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta_pw
{
    public partial class NicotinamidePrtage : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "NicotinamidePrtage";
                GraphColor();
                //  LoadChartSiteWise();
                LoadChartPercentages();
                txtdssid.Focus();

                GridViewGraphR1Color();
                ShowGraphGridViewR1();
            }

        }
        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }



        protected void GridViewGraphR1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGraphR1.PageIndex = e.NewPageIndex;
            ShowGraphGridViewR1();
        }
        protected void GridViewGraphR2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGraphR2.PageIndex = e.NewPageIndex;
            ShowGraphGridViewR2();
        }
        protected void GridViewGraphR3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGraphR3.PageIndex = e.NewPageIndex;
            ShowGraphGridViewR3();
        }
        protected void GridViewGraphR4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGraphR4.PageIndex = e.NewPageIndex;
            ShowGraphGridViewR4();
        }
        protected void GridViewGraphR5_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewGraphR5.PageIndex = e.NewPageIndex;
            ShowGraphGridViewR5();
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




        protected void btnGraph_Click(object sender, EventArgs e)
        {
            GraphColor();
            // LoadChartSiteWise();
            LoadChartPercentages();
            ShowGraphGridViewR1();
        }


        protected void btnForms_Click(object sender, EventArgs e)
        {
            FormsColor();
            txtdssid.Focus();
        }




        protected void btnGridViewGraphR1_Click(object sender, EventArgs e)
        {
            LoadChartPercentages();
            GridViewGraphR1Color();
            ShowGraphGridViewR1();
        }
        protected void btnGridViewGraphR2_Click(object sender, EventArgs e)
        {
            LoadChartPercentages();
            GridViewGraphR2Color();
            ShowGraphGridViewR2();
        }
        protected void btnGridViewGraphR3_Click(object sender, EventArgs e)
        {
            LoadChartPercentages();
            GridViewGraphR3Color();
            ShowGraphGridViewR3();
        }
        protected void btnGridViewGraphR4_Click(object sender, EventArgs e)
        {
            LoadChartPercentages();
            GridViewGraphR4Color();
            ShowGraphGridViewR4();
        }
        protected void btnGridViewGraphR5_Click(object sender, EventArgs e)
        {
            LoadChartPercentages();
            GridViewGraphR5Color();
            ShowGraphGridViewR5();
        }












        private void GraphColor()
        {
            btnForms.Style.Add("color", "#adadad");
            btnForms.Style.Add("background-color", "#e0e0e0");
            btnGraph.Style.Add("color", "white");
            btnGraph.Style.Add("background-color", "#55efc4");

            divGraph.Visible = true;
            divForms.Visible = false;
        }

        private void FormsColor()
        {
            btnForms.Style.Add("color", "white");
            btnForms.Style.Add("background-color", "#55efc4");
            btnGraph.Style.Add("color", "#adadad");
            btnGraph.Style.Add("background-color", "#e0e0e0");
            divForms.Visible = true;
            divGraph.Visible = false;
        }








        private void GridViewGraphR1Color()
        {
            btnGridViewGraphR1.Style.Add("color", "white");
            btnGridViewGraphR1.Style.Add("background-color", "#55efc4");

            btnGridViewGraphR2.Style.Add("color", "#adadad");
            btnGridViewGraphR2.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR3.Style.Add("color", "#adadad");
            btnGridViewGraphR3.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR4.Style.Add("color", "#adadad");
            btnGridViewGraphR4.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR5.Style.Add("color", "#adadad");
            btnGridViewGraphR5.Style.Add("background-color", "#e0e0e0");

            divGridViewGraphR1.Visible = true;
            divGridViewGraphR2.Visible = false;
            divGridViewGraphR3.Visible = false;
            divGridViewGraphR4.Visible = false;
            divGridViewGraphR5.Visible = false;
        }



        private void GridViewGraphR2Color()
        {
            btnGridViewGraphR2.Style.Add("color", "white");
            btnGridViewGraphR2.Style.Add("background-color", "#55efc4");

            btnGridViewGraphR1.Style.Add("color", "#adadad");
            btnGridViewGraphR1.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR3.Style.Add("color", "#adadad");
            btnGridViewGraphR3.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR4.Style.Add("color", "#adadad");
            btnGridViewGraphR4.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR5.Style.Add("color", "#adadad");
            btnGridViewGraphR5.Style.Add("background-color", "#e0e0e0");

            divGridViewGraphR2.Visible = true;
            divGridViewGraphR1.Visible = false;
            divGridViewGraphR3.Visible = false;
            divGridViewGraphR4.Visible = false;
            divGridViewGraphR5.Visible = false;
        }


        private void GridViewGraphR3Color()
        {
            btnGridViewGraphR3.Style.Add("color", "white");
            btnGridViewGraphR3.Style.Add("background-color", "#55efc4");

            btnGridViewGraphR2.Style.Add("color", "#adadad");
            btnGridViewGraphR2.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR1.Style.Add("color", "#adadad");
            btnGridViewGraphR1.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR4.Style.Add("color", "#adadad");
            btnGridViewGraphR4.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR5.Style.Add("color", "#adadad");
            btnGridViewGraphR5.Style.Add("background-color", "#e0e0e0");

            divGridViewGraphR3.Visible = true;
            divGridViewGraphR2.Visible = false;
            divGridViewGraphR1.Visible = false;
            divGridViewGraphR4.Visible = false;
            divGridViewGraphR5.Visible = false;
        }

        private void GridViewGraphR4Color()
        {
            btnGridViewGraphR4.Style.Add("color", "white");
            btnGridViewGraphR4.Style.Add("background-color", "#55efc4");

            btnGridViewGraphR2.Style.Add("color", "#adadad");
            btnGridViewGraphR2.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR3.Style.Add("color", "#adadad");
            btnGridViewGraphR3.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR1.Style.Add("color", "#adadad");
            btnGridViewGraphR1.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR5.Style.Add("color", "#adadad");
            btnGridViewGraphR5.Style.Add("background-color", "#e0e0e0");

            divGridViewGraphR4.Visible = true;
            divGridViewGraphR2.Visible = false;
            divGridViewGraphR3.Visible = false;
            divGridViewGraphR1.Visible = false;
            divGridViewGraphR5.Visible = false;
        }


        private void GridViewGraphR5Color()
        {
            btnGridViewGraphR5.Style.Add("color", "white");
            btnGridViewGraphR5.Style.Add("background-color", "#55efc4");

            btnGridViewGraphR2.Style.Add("color", "#adadad");
            btnGridViewGraphR2.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR3.Style.Add("color", "#adadad");
            btnGridViewGraphR3.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR4.Style.Add("color", "#adadad");
            btnGridViewGraphR4.Style.Add("background-color", "#e0e0e0");
            btnGridViewGraphR1.Style.Add("color", "#adadad");
            btnGridViewGraphR1.Style.Add("background-color", "#e0e0e0");

            divGridViewGraphR5.Visible = true;
            divGridViewGraphR2.Visible = false;
            divGridViewGraphR3.Visible = false;
            divGridViewGraphR4.Visible = false;
            divGridViewGraphR1.Visible = false;
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
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND d.pw_crf_3a_19='4' AND CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text.ToUpper() + "%' ORDER BY c.study_code;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
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



        private void LoadChartPercentages()
        {
            string query = string.Format("SELECT 'Greater than 75.0%' AS FIELD, COUNT(c.study_code) AS 'total'				FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE	c.study_code IS NOT NULL AND d.pw_crf_3a_19!='1' AND		  (SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  >=75.0  	UNION ALL SELECT 'Between 70.0% to 74.9%' AS FIELD, COUNT(c.study_code) AS 'total'		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND d.pw_crf_3a_19!='1' AND		  (SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  BETWEEN 70.0 AND 74.9  	UNION ALL SELECT 'Between 60.0% to 69.9%' AS FIELD, COUNT(c.study_code) AS 'total'		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND d.pw_crf_3a_19!='1' AND		  (SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  BETWEEN 60.0 AND 69.9  	UNION ALL SELECT 'Between 50.1% to 59.9%' AS FIELD, COUNT(c.study_code) AS 'total'		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND d.pw_crf_3a_19!='1' AND		  (SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  BETWEEN 50.1 AND 59.9		UNION ALL SELECT 'Less and equal than 50.0%' AS FIELD, COUNT(c.study_code) AS 'total'		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND d.pw_crf_3a_19!='1' AND		  (SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  <=50.0 ");
            DataTable dt = GetData(query);
            Chart1.DataSource = dt;
            Chart1.Series[0].XValueMember = "Field";
            Chart1.Series[0].YValueMembers = "total";
            Chart1.Series[0].Label = "#VALY";
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.DataBind();
        }



        //For Cumulative:
        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

            MySqlConnection con = new MySqlConnection(constr);
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
        }












        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Nicotinamide Cumulative (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND d.pw_crf_3a_19='4' AND CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text.ToUpper() + "%' ORDER BY c.study_code;", con);
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









        // For Detailed View Of Graph Value                 /*Greater than 75.0%*/
        private void ShowGraphGridViewR1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND  d.pw_crf_3a_19='4' AND 		(SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)>=75.0		ORDER BY c.study_code;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewGraphR1.DataSource = dt;
                        GridViewGraphR1.DataBind();
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

        // For Detailed View Of Graph Value                 /*Between 70.0% to 74.9%*/
        private void ShowGraphGridViewR2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND  d.pw_crf_3a_19='4' AND 		(SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)           between 70.0 and 74.9  		order by c.study_code;  ", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewGraphR2.DataSource = dt;
                        GridViewGraphR2.DataBind();
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

        // For Detailed View Of Graph Value              /*Between 60.0% to 69.9%*/
        private void ShowGraphGridViewR3()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND  d.pw_crf_3a_19='4' AND 		(SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)        between 60.0 and 69.9  		order by c.study_code;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewGraphR3.DataSource = dt;
                        GridViewGraphR3.DataBind();
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

        // For Detailed View Of Graph Value         /*Between 50.1% to 59.9%*/
        private void ShowGraphGridViewR4()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND  d.pw_crf_3a_19='4' AND 		(SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)              between 50.1 and 59.9    		order by c.study_code;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewGraphR4.DataSource = dt;
                        GridViewGraphR4.DataBind();
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

        // For Detailed View Of Graph Value         /* Less and equal than 50.0%*/


        private void ShowGraphGridViewR5()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.study_code,CONCAT(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) AS dssid,a.pw_crf_1_09 AS woman_nm,a.pw_crf_1_10 AS husband_nm, 				(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id) AS CRF4b_Attempt,		(SELECT COUNT(z.study_id) FROM form_crf_4b AS z WHERE z.study_id=c.study_id AND z.pw_crf4b_14='1') AS CRF4b_Complete		,(SELECT CONCAT(ROUND ( (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) ,1),'%')		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)  AS Cumulative_Nicotinamide 		FROM 		pregnant_woman AS a LEFT JOIN  studies AS c ON c.pw_id=a.pw_id LEFT JOIN form_crf_3a AS d ON d.pw_id=a.pw_id	  WHERE c.study_code IS NOT NULL AND  d.pw_crf_3a_19='4' AND 		(SELECT (((SELECT SUM(z.pw_crf4b_19c_qty) FROM form_crf_4b AS z WHERE z.study_code=ax.study_code)/(DATEDIFF(STR_TO_DATE(ax.pw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(ay.pw_crf_3a_2, '%d-%m-%Y'))  )	)*100) 		FROM 		(SELECT * FROM form_crf_4b AS xx WHERE xx.`form4b_id` IN (SELECT MAX(form4b_id) FROM form_crf_4b GROUP BY study_code)) AS ax LEFT JOIN  form_crf_3a AS ay ON ax.`study_code`=ay.`study_code` WHERE ax.study_id=c.study_id GROUP BY ax.study_id)       <=50.0   		order by c.study_code;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewGraphR5.DataSource = dt;
                        GridViewGraphR5.DataBind();
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




        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
 
        }



    }
}