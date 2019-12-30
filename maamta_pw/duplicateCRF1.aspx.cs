using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta_pw
{
    public partial class duplicateCRF1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "duplicateCRF1";
            Session["duplicateCRF1DSSID"] = null;
            if (Convert.ToString(Session["dropdownID"]) == "2")
            {
                DropDownList1.SelectedValue = "2";
                Session["dropdownID"] = null;
            }


            if (!IsPostBack)
            {                
                ShowData();
            }
        }







        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                //Duplicate DSSID (Date are Same): 
                if (DropDownList1.SelectedValue == "1")
                {
                    MySqlCommand cmd = new MySqlCommand("select dssid,count(dssid) as Duplicate, pw_crf1_02 as DOV ,pw_crf_1_09 as woman_nm,pw_crf_1_10 as husband_nm   from view_crf1 where no_of_fetus='1'  group by dssid,pw_crf1_02 having (count(dssid)>1) and (count(pw_crf1_02)>1) order by dssid", con);
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
                //Duplicate DSSID (ALL): 
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select dssid,count(dssid) as Duplicate,pw_crf1_02 as DOV, pw_crf_1_09 as woman_nm,pw_crf_1_10 as husband_nm  from (select * from view_crf1 group by assis_id) as view_crf1 where no_of_fetus='1' and (pw_status is null or pw_status ='') group by dssid having (count(dssid)>1) order by dssid", con);
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




        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }





        protected void btnExport_Click(object sender, EventArgs e)
        {
            //if (GridView1.Rows.Count != 0)
            //{
            //    ExcelExport();
            //}
        }


        //private void Exportdata()
        //{
        //    MySqlConnection con = new MySqlConnection(constr);
        //    con.Open();
        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand("SELECT  a.*, b.totalCount AS Duplicate FROM  (SELECT z.* FROM view_crf1 as z INNER JOIN (SELECT MAX(form_crf_1_id) as form_crf_1_id,assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate  FROM view_crf1   GROUP BY assis_id) AS b  ON   b.form_crf_1_id=z.form_crf_1_id  GROUP BY  b.assis_id ) a INNER JOIN (SELECT  r.dssid, COUNT(*) totalCount FROM (SELECT z.* FROM view_crf1 as z INNER JOIN (SELECT MAX(form_crf_1_id) as form_crf_1_id,assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate  FROM view_crf1   GROUP BY assis_id) AS b  ON   b.form_crf_1_id=z.form_crf_1_id  GROUP BY  b.assis_id ) as r GROUP BY r.dssid HAVING COUNT(*) >= 2) b ON a.dssid = b.dssid");
        //        {
        //            MySqlDataAdapter sda = new MySqlDataAdapter();
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandTimeout = 999999;
        //                cmd.CommandType = CommandType.Text;
        //                sda.SelectCommand = cmd;
        //                DataTable dt = new DataTable();
        //                {
        //                    sda.Fill(dt);
        //                    GridView2.DataSource = dt;
        //                    GridView2.DataBind();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}




        //public void ExcelExport()
        //{
        //    try
        //    {
        //        Response.Clear();
        //        Response.AddHeader("content-disposition", "attachment;filename=Duplicate Screening(" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
        //        Response.Charset = "";

        //        Response.ContentType = "application/vnd.xls";
        //        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter htmlWrite =
        //        new HtmlTextWriter(stringWrite);
        //        GridView2.AllowPaging = false;
        //        GridView2.CaptionAlign = TableCaptionAlign.Top;

        //        Exportdata();
        //        for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
        //        {
        //            GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
        //            GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
        //        }
        //        GridView2.RenderControl(htmlWrite);
        //        Response.Write(stringWrite.ToString());
        //        Response.End();

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

        //    }
        //}





        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (DropDownList1.SelectedValue == "2")
            {
                e.Row.Cells[3].Visible = false;
            }
        }





        protected void Link_DSSID(object sender, EventArgs e)
        {
            string dssid = ((LinkButton)sender).Text;
            Session["duplicateCRF1DSSID"] = dssid;
            Session["dropdownID"] = DropDownList1.SelectedValue;
            Response.Redirect("showcrf1.aspx");
        }


    }
}