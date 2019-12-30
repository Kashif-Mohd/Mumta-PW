using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta_pw
{
    public partial class compPrtage : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["WebForm"] = "compPrtage";
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,			(select count(z.study_id) from followups as z where z.form='4' and z.study_id=c.study_code and str_to_date(z.start_date, '%d-%m-%Y') <= CURDATE()) as total_Followups, 	(select count(z.study_id) from form_crf_4 as z where z.study_id=c.study_id) as CRF4_Attempt,		(select count(z.study_id) from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as CRF4_Complete, 			(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as Cumulative			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text.ToUpper() + "%' order by c.study_code;", con);
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
            string query = string.Format("select 'Greater than 75.0%' as Field, count(c.study_code) as 'total'		from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1')>=75.0  union all select 'Between 70.0% to 74.9%' as Field, count(c.study_code) as 'total'		from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1')  between 70.0 and 74.9  union all select 'Between 60.0% to 69.9%' as Field, count(c.study_code) as 'total'		from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') between 60.0 and 69.9  union all select 'Between 50.1% to 59.9%' as Field, count(c.study_code) as 'total'		from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') between 50.1 and 59.9  union all select 'Less and equal than 50.0%' as Field, count(c.study_code) as 'total'		from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1')<=50.0");
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




        ////Site Wise Compliance:
        //private void LoadChartSiteWise()
        //{
        //    Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
        //    Chart2.DataBindCrossTable(GetDataItem().DefaultView, "site", "Greater than 75.0%", "total", "Label=total");
        //    Chart2.DataBind();
        //}



        //private DataTable GetDataItem()
        //{
        //    MySqlConnection con = new MySqlConnection(constr);
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand("select b.lw_crf_1_11 as site,'Greater than 75.0%', count(c.study_code) as 'total'	from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and d.lw_crf_3a_19!='a'  		and (select ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)))*100),1)  from form_crf_5a as z where z.study_id=c.study_id) >=75.0 group by b.lw_crf_1_11 union all select b.lw_crf_1_11 as site,'Between 70.0% to 74.9%',count(c.study_code) as 'total'  from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and d.lw_crf_3a_19!='a'  		and (select ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)))*100),1)  from form_crf_5a as z where z.study_id=c.study_id) between 70.0 and 74.9 group by b.lw_crf_1_11 union all select b.lw_crf_1_11 as site,'Between 60.0% to 69.9%',count(c.study_code) as 'total'	 from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and d.lw_crf_3a_19!='a'  		and (select ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)))*100),1)  from form_crf_5a as z where z.study_id=c.study_id) between 60.0 and 69.9 group by b.lw_crf_1_11  union all select b.lw_crf_1_11 as site,'Between 50.1% to 59.9%',count(c.study_code) as 'total'  from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and d.lw_crf_3a_19!='a'  		and (select ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)))*100),1)  from form_crf_5a as z where z.study_id=c.study_id) between 50.1 and 59.9 group by b.lw_crf_1_11  union all select b.lw_crf_1_11 as site,'Less and equal than 50.0%',count(c.study_code) as 'total'   from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and d.lw_crf_3a_19!='a'  		and (select ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)))*100),1)  from form_crf_5a as z where z.study_id=c.study_id) <=50.0 group by b.lw_crf_1_11", con);
        //    {
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        DataTable dtData = new DataTable();
        //        dtData.Load(reader);
        //        return dtData;
        //        con.Close();
        //    }
        //    con.Close();
        //}








        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Compliance Cumulative (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,			(select count(z.study_id) from followups as z where z.form='4' and z.study_id=c.study_code and str_to_date(z.start_date, '%d-%m-%Y') <= CURDATE()) as total_Followups, 	(select count(z.study_id) from form_crf_4 as z where z.study_id=c.study_id) as CRF4_Attempt,		(select count(z.study_id) from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as CRF4_Complete, 			(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as Cumulative			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text.ToUpper() + "%' order by c.study_code;", con);
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,					(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as percentage			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and 		 (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1')>=75.0  		order by c.study_code;", con);
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,					(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as percentage			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and 		 (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1')  between 70.0 and 74.9  		order by c.study_code;  ", con);
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,					(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as percentage			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and 		 (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1')  between 60.0 and 69.9  		order by c.study_code;", con);
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,					(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as percentage			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and 		 (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') between 50.1 and 59.9    		order by c.study_code;", con);
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
                cmd = new MySqlCommand("select c.study_code,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm, d.pw_crf_3a_19 as ARM,					(select 	concat(ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1),'%')  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') as percentage			from 		pregnant_woman as a left join  studies as c on c.pw_id=a.pw_id left join form_crf_3a as d on d.pw_id=a.pw_id	  where c.study_code is not null and d.pw_crf_3a_19!='1' and 		 (select 	ROUND(((sum(z.pw_crf4_28)/sum(		if((z.pw_crf4_24 is NULL || z.pw_crf4_24 =''), (SELECT (DATEDIFF(str_to_date(z.pw_crf4_2, '%d-%m-%Y'), str_to_date(y.pw_crf_3a_2, '%d-%m-%Y')  ))*2    from     form_crf_3a as y    where y.study_id=z.study_id), z.pw_crf4_26)				))*100),1)  from form_crf_4 as z where z.study_id=c.study_id and z.pw_crf4_18='1') <=50.0   		order by c.study_code;", con);
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    TableCell cell8 = e.Row.Cells[8];
            //    TableCell cell10 = e.Row.Cells[10];
            //    TableCell cell20 = e.Row.Cells[20];
            //    TableCell cell28 = e.Row.Cells[28];

            //    cell8.BackColor = System.Drawing.Color.FromName("#ffeaa7");
            //    cell10.BackColor = System.Drawing.Color.FromName("#ffeaa7");
            //    cell20.BackColor = System.Drawing.Color.FromName("#ffeaa7");
            //    cell28.BackColor = System.Drawing.Color.FromName("#bdc3c7");

            //    // LW MUAC

            //    if (e.Row.Cells[12].Text != "&nbsp;" && e.Row.Cells[11].Text != "&nbsp;" && (float.Parse(e.Row.Cells[12].Text) < float.Parse(e.Row.Cells[11].Text)))
            //    {
            //        TableCell cell = e.Row.Cells[12];
            //        cell.BackColor = System.Drawing.Color.FromName("#ff7675");
            //    }               
            //}
        }
    }
}