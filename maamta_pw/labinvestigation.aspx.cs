using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta_pw
{
    public partial class labinvestigation : System.Web.UI.Page
    {


        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "LABinvestigation";
                DateFormatPageLoad();
                ShowData();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
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
            }
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownListWeeks.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest", con);
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
                else if (DropDownListWeeks.SelectedValue == "19")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where    19_weeks!=''    and     str_to_date(19_weeks, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by str_to_date(19_weeks, '%d-%m-%Y')", con);
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
                else if ( DropDownListWeeks.SelectedValue == "32")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where    32_weeks!=''    and     str_to_date(32_weeks, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by str_to_date(32_weeks, '%d-%m-%Y')", con);
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










        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownListWeeks.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest", con);
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
                else if (DropDownListWeeks.SelectedValue == "19")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where    19_weeks!=''    and     str_to_date(19_weeks, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by str_to_date(19_weeks, '%d-%m-%Y')", con);
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
                else if (DropDownListWeeks.SelectedValue == "32")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where    32_weeks!=''    and     str_to_date(32_weeks, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by str_to_date(32_weeks, '%d-%m-%Y')", con);
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






        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Lab Investigation (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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












        protected void btnReportPending_Click(object sender, EventArgs e)
        {
          ExcelExportSpecimenPending();
        }




        private void SpecimenPendingSample()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select a.dssid,a.study_code as study_id,a.Randomization_ID as Random_ID,a.woman_nm,a.husband_nm,a.Enrollment,a.19_weeks,a.32_weeks,a.ARM , (case when a.Description!='' Then '(HB, Serum, Urine & 1 Plasma for Niacin at enrollment) + (1 Plasma at week 19) + (HB, Serum, 2 plasma & Urine at week 32)' when (a.description='' or a.description is null) Then 'HB, Serum at Enrollment and week 32' END) as description,  (select  concat( IF(z.enrollment_urine!='','Urine, ','' ), IF(z.enrollment_hb!='','HB, ','' ), IF(z.enrollment_serum!='','Serum, ','' ),IF(z.enrollment_plasma_niacin!='','Plasma Niacin, ','' ) ) from view_lab_invest as z where a.study_code = z.study_code)  as Enrollment_SampleDone,  (select IF(  (z.description='(Urine & 1 Plasma for Niacin at enrollment) + (1 Plasma at week 19) + (2 plasma & Urine at week 32)'), 	concat( IF((z.enrollment_urine='' or z.enrollment_urine is null),'Urine, ','' ), IF((z.enrollment_hb='' or z.enrollment_hb is null),'HB, ','' ), IF((z.enrollment_serum='' or z.enrollment_serum is null),'Serum, ','' ),IF((z.enrollment_plasma_niacin=''  or  z.enrollment_plasma_niacin is null),'Plasma Niacin, ','' )),		concat(  IF((z.enrollment_hb='' or z.enrollment_hb is null),'HB, ','' ), IF((z.enrollment_serum='' or z.enrollment_serum is null),'Serum, ','' ))     )           from view_lab_invest as z where a.study_code = z.study_code)  as Enrollment_SamplePending,  (select  IF(z.19_wks_plasma!='','Plasma','') from view_lab_invest as z where a.study_code = z.study_code and z.19_weeks!='')  as 19_Weeks_SampleDone,  (select IF((z.19_wks_plasma='' or  z.19_wks_plasma is null),'Plasma','')     from view_lab_invest as z where a.study_code = z.study_code and z.19_weeks!=''	and	 str_to_date(a.19_weeks, '%d-%m-%Y')<=CURDATE() )  as 19_Weeks_SamplePending, (select  concat( IF(z.32_wks_urine!='','Urine, ','' ), IF(z.32_wks_hb!='','HB, ','' ), IF(z.32_wks_serum!='','Serum, ','' ),IF(z.32_wks_plasma_niacin!='','Plasma Niacin, ','' ) ,IF(z.32_wks_plasma_proteomic!='','Plasma Proteomic, ','' ) ) from view_lab_invest as z where a.study_code = z.study_code )  as 32_Weeks_SampleDone,  (select IF(  (z.description='(Urine & 1 Plasma for Niacin at enrollment) + (1 Plasma at week 19) + (2 plasma & Urine at week 32)'), 	concat( IF((z.32_wks_urine='' or z.32_wks_urine is null),'Urine, ','' ), IF((z.32_wks_hb='' or z.32_wks_hb is null),'HB, ','' ), IF((z.32_wks_serum='' or z.32_wks_serum is null),'Serum, ','' ), IF((z.32_wks_plasma_niacin=''  or  z.32_wks_plasma_niacin is null),'Plasma Niacin, ','' ), IF((z.32_wks_plasma_proteomic=''  or  z.32_wks_plasma_proteomic is null),'Plasma Proteomic, ','' )),		concat(  IF((z.32_wks_hb='' or z.32_wks_hb is null),'HB, ','' ), IF((z.32_wks_serum='' or z.32_wks_serum is null),'Serum, ','' ))     )           from view_lab_invest as z where a.study_code = z.study_code 	and	 str_to_date(a.32_weeks, '%d-%m-%Y')<=CURDATE() )  as 32_Weeks_SamplePending      from view_lab_invest as a", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView5.DataSource = dt;
                        GridView5.DataBind();
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




        public void ExcelExportSpecimenPending()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Specimen Pending Report (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView5.AllowPaging = false;
                GridView5.CaptionAlign = TableCaptionAlign.Top;
                SpecimenPendingSample();
                for (int i = 0; i < GridView5.HeaderRow.Cells.Count; i++)
                {
                    GridView5.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView5.HeaderRow.Cells[i].Style.Add("height", "80px");
                    GridView5.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView5.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                

                GridView5.RenderControl(htmlWrite);

                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }










        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell14 = e.Row.Cells[14];
                cell14.BackColor = System.Drawing.Color.FromName("#bdc3c7");
            }
        }




        protected void Link_EditForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["RolePW"]) == "web_sup_admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                string RandID = commandArgs[0];
                Response.Redirect("labinvestigationEdit.aspx?&RandID=" + RandID);
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }


    }
}