using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta_pw
{
    public partial class azithromycin : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GraphColor();
               // ShowGraph();
                pendingColor();
                ShowDataPending();

                Session["WebForm"] = "AzithromycinTask";
            }
        }




        //protected void btnGraph_Click(object sender, EventArgs e)
        //{
        //    GraphColor();
        //    //ShowGraph();
        //}




        protected void btnPending_Click(object sender, EventArgs e)
        {
            pendingColor();
            ShowDataPending();
            txtdssidPending.Focus();
        }

        protected void btnDose_Click(object sender, EventArgs e)
        {
            doseColor();
            ShowDataDose();
            txtdssidDose.Focus();
        }




        //private void GraphColor()
        //{
        //    btnGraph.Style.Add("color", "white");
        //    btnGraph.Style.Add("background-color", "#55efc4");

        //    btnPending.Style.Add("color", "#adadad");
        //    btnPending.Style.Add("background-color", "#e0e0e0");
        //    btnDose.Style.Add("color", "#adadad");
        //    btnDose.Style.Add("background-color", "#e0e0e0");

        //    divGraph.Visible = true;
        //    divDose.Visible = false;
        //    divPending.Visible = false;
        //}

        private void pendingColor()
        {
            btnPending.Style.Add("color", "white");
            btnPending.Style.Add("background-color", "#55efc4");

            btnDose.Style.Add("color", "#adadad");
            btnDose.Style.Add("background-color", "#e0e0e0");
            //btnGraph.Style.Add("color", "#adadad");
            //btnGraph.Style.Add("background-color", "#e0e0e0");

            divPending.Visible = true;
            divDose.Visible = false;
            divGraph.Visible = false;
        }

        private void doseColor()
        {
            btnDose.Style.Add("color", "white");
            btnDose.Style.Add("background-color", "#55efc4");

            btnPending.Style.Add("color", "#adadad");
            btnPending.Style.Add("background-color", "#e0e0e0");
            //btnGraph.Style.Add("color", "#adadad");
            //btnGraph.Style.Add("background-color", "#e0e0e0");

            divDose.Visible = true;
            divPending.Visible = false;
            divGraph.Visible = false;
        }









    

     


    





     





    


    





















        protected void btnSearchPending_Click(object sender, EventArgs e)
        {
            ShowDataPending();
            txtdssidPending.Focus();
        }


        private void ShowDataPending()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select assis_id as Assisment_ID,a.study_code  as Study_ID,	b.dssid as DSSID,	b.pw_crf_1_09 as Woman_Name,	b.pw_crf_1_10 as Husband_Name,			   DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (140-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y') as  20_weeks, (select z.pw_crf_6a_2 from form_crf_6a as z where z.study_id=a.study_id) as CRF6a_Filled,	(select case when z.pw_crf_6a_21='1' then 'Alive'   when z.pw_crf_6a_21='2' then 'Stillbirth'   when z.pw_crf_6a_21='3' then 'Miscarriage' End	 from form_crf_6a as z where z.study_id=a.study_id) as OutcomeStatus	         from form_crf_3a as a left join (select * from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id)) as b on SUBSTRING_INDEX(b.assis_id,':',-1)=a.pw_id where a.pw_crf_3a_19='3'	and	a.study_code not in (select z.study_code from form_crf_5a as z where z.followup_num between '1' and '6' and z.pw_crf5a_36='1') and b.dssid  like '%" + txtdssidPending.Text + "%'           		and DATEDIFF(str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (140-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),CURDATE())<8	        	order by str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (140-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),a.study_code", con);
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
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select assis_id as Assisment_ID,a.study_code  as Study_ID,	b.dssid as DSSID,	b.pw_crf_1_09 as Woman_Name,	b.pw_crf_1_10 as Husband_Name,	(select z.pw_crf5a_02 from form_crf_5a as z where z.followup_num between '1' and '6' and z.pw_crf5a_36='1' and z.study_id=a.study_id ) as 20_weeks_Done,	   DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (196-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y') as  28_weeks, (select z.pw_crf_6a_2 from form_crf_6a as z where z.study_id=a.study_id) as CRF6a_Filled,	(select case when z.pw_crf_6a_21='1' then 'Alive'   when z.pw_crf_6a_21='2' then 'Stillbirth'   when z.pw_crf_6a_21='3' then 'Miscarriage' End	 from form_crf_6a as z where z.study_id=a.study_id) as OutcomeStatus            	 from form_crf_3a as a left join (select * from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id)) as b on SUBSTRING_INDEX(b.assis_id,':',-1)=a.pw_id where a.pw_crf_3a_19='3'	and a.study_code not in (select z.study_code from form_crf_5a as z where z.followup_num between '7' and '14' and z.pw_crf5a_36='1') and b.dssid  like '%" + txtdssidPending.Text + "%'           		and DATEDIFF(str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (196-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),CURDATE())<8	            order by str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (196-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),a.study_code", con);
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




        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }




        protected void btnExportPending_Click(object sender, EventArgs e)
        {
            ShowDataPending();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExportPending();
            }
            txtdssidPending.Focus();
        }





        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void ExcelExportP()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select assis_id as Assisment_ID,a.study_code  as Study_ID,	b.dssid as DSSID,	b.pw_crf_1_09 as Woman_Name,	b.pw_crf_1_10 as Husband_Name,			   DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (140-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y') as  20_weeks, (select z.pw_crf_6a_2 from form_crf_6a as z where z.study_id=a.study_id) as CRF6a_Filled,	(select case when z.pw_crf_6a_21='1' then 'Alive'   when z.pw_crf_6a_21='2' then 'Stillbirth'   when z.pw_crf_6a_21='3' then 'Miscarriage' End	 from form_crf_6a as z where z.study_id=a.study_id) as OutcomeStatus            	 from form_crf_3a as a left join (select * from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id)) as b on SUBSTRING_INDEX(b.assis_id,':',-1)=a.pw_id where a.pw_crf_3a_19='3'	and	a.study_code not in (select z.study_code from form_crf_5a as z where z.followup_num between '1' and '6' and z.pw_crf5a_36='1') and b.dssid  like '%" + txtdssidPending.Text + "%'           		and DATEDIFF(str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (140-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),CURDATE())<8	        	order by str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (140-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),a.study_code", con);

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
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select assis_id as Assisment_ID,a.study_code  as Study_ID,	b.dssid as DSSID,	b.pw_crf_1_09 as Woman_Name,	b.pw_crf_1_10 as Husband_Name,	(select z.pw_crf5a_02 from form_crf_5a as z where z.followup_num between '1' and '6' and z.pw_crf5a_36='1' and z.study_id=a.study_id ) as 20_weeks_Done,	   DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (196-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y') as  28_weeks, (select z.pw_crf_6a_2 from form_crf_6a as z where z.study_id=a.study_id) as CRF6a_Filled,	(select case when z.pw_crf_6a_21='1' then 'Alive'   when z.pw_crf_6a_21='2' then 'Stillbirth'   when z.pw_crf_6a_21='3' then 'Miscarriage' End	 from form_crf_6a as z where z.study_id=a.study_id) as OutcomeStatus        	 from form_crf_3a as a left join (select * from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id)) as b on SUBSTRING_INDEX(b.assis_id,':',-1)=a.pw_id where a.pw_crf_3a_19='3'	and a.study_code not in (select z.study_code from form_crf_5a as z where z.followup_num between '7' and '14' and z.pw_crf5a_36='1') and b.dssid  like '%" + txtdssidPending.Text + "%'           		and DATEDIFF(str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (196-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),CURDATE())<8	            order by str_to_date(DATE_FORMAT(AddDate((str_to_date(b.pw_crf1_02, '%d-%m-%Y')), interval (196-((b.pw_crf_1_30_week * 7) + b.pw_crf_1_30_days)) DAY),'%d-%m-%Y'), '%d-%m-%Y'),a.study_code", con);
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
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }




        public void ExcelExportPending()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Azithromycin Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;

                GridView2.CaptionAlign = TableCaptionAlign.Top;

                ExcelExportP();
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
























        protected void btnSearchDose_Click(object sender, EventArgs e)
        {
            ShowDataDose();
            txtdssidDose.Focus();
        }





        private void ShowDataDose()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList2.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select z.* from view_crf5a as z where z.followup_num between '1' and '6' and z.pw_crf5a_36='1' and z.dssid like '%" + txtdssidDose.Text + "%' group by z.study_code order by z.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView3.DataSource = dt;
                            GridView3.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select z.* from view_crf5a as z where z.followup_num between '7' and '14' and z.pw_crf5a_36='1'  and z.dssid like '%" + txtdssidDose.Text + "%'  group by z.study_code  order by z.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView3.DataSource = dt;
                            GridView3.DataBind();
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







        protected void btnExportDose_Click(object sender, EventArgs e)
        {
            ShowDataDose();
            if (GridView3.Rows.Count != 0)
            {
                ExcelExportDose();
            }
            txtdssidDose.Focus();
        }




        private void ExcelExportD()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList2.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select z.* from view_crf5a as z where z.followup_num between '1' and '6' and z.pw_crf5a_36='1' and z.dssid like '%" + txtdssidDose.Text + "%' group by z.study_code order by z.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView4.DataSource = dt;
                            GridView4.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select z.* from view_crf5a as z where z.followup_num between '7' and '14' and z.pw_crf5a_36='1'  and z.dssid like '%" + txtdssidDose.Text + "%'  group by z.study_code  order by z.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView4.DataSource = dt;
                            GridView4.DataBind();
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







        public void ExcelExportDose()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Azithromycin Dose (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView4.AllowPaging = false;

                GridView4.CaptionAlign = TableCaptionAlign.Top;

                ExcelExportD();
                for (int i = 0; i < GridView4.HeaderRow.Cells.Count; i++)
                {
                    GridView4.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView4.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView4.RenderControl(htmlWrite);
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