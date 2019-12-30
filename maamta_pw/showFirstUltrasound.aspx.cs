using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta_pw
{
    public partial class showFirstUltrasound : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showFirstUltrasound";
                ShowData();
                txtdssid.Focus();
            }
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


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.no_of_fetus,	a.assis_id,	a.pw_crf1_02 as date_of_visit,	a.pw_crf1_03 as start_time,	a.pw_crf_1_09 as woman_nm,	a.pw_crf_1_10  as husband_nm,	a.dssid, a.pw_crf_1_30_week,	a.pw_crf_1_30_days,		a.pw_crf_1_37,	a.pw_crf1_38 as end_time,	a.sra_name from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id) and a.dssid like  '%" + txtdssid.Text + "%'   and  (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  group by a.assis_id order by str_to_date(a.pw_crf1_02, '%d-%m-%Y'), STR_TO_DATE(a.pw_crf1_03,  '%H:%i')", con);
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
                    cmd = new MySqlCommand("select a.no_of_fetus,	a.assis_id,	a.pw_crf1_02 as date_of_visit,	a.pw_crf1_03 as start_time,	a.pw_crf_1_09 as woman_nm,	a.pw_crf_1_10  as husband_nm,	a.dssid, a.pw_crf_1_30_week,	a.pw_crf_1_30_days,		a.pw_crf_1_37,	a.pw_crf1_38 as end_time,	a.sra_name from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id) and a.dssid like  '%" + txtdssid.Text + "%'    group by a.assis_id order by str_to_date(a.pw_crf1_02, '%d-%m-%Y'), STR_TO_DATE(a.pw_crf1_03,  '%H:%i')", con);
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



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.no_of_fetus,	a.assis_id,	a.pw_crf1_02 as date_of_visit,	a.pw_crf1_03 as start_time,	a.pw_crf_1_09 as woman_nm,	a.pw_crf_1_10  as husband_nm,	a.dssid, a.pw_crf_1_30_week,	a.pw_crf_1_30_days,		a.pw_crf_1_37,	a.pw_crf1_38 as end_time,	a.sra_name from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id) and a.dssid like  '%" + txtdssid.Text + "%'   and  (str_to_date(a.pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  group by a.assis_id order by str_to_date(a.pw_crf1_02, '%d-%m-%Y'), STR_TO_DATE(a.pw_crf1_03,  '%H:%i')", con);
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
                    cmd = new MySqlCommand("select a.no_of_fetus,	a.assis_id,	a.pw_crf1_02 as date_of_visit,	a.pw_crf1_03 as start_time,	a.pw_crf_1_09 as woman_nm,	a.pw_crf_1_10  as husband_nm,	a.dssid, a.pw_crf_1_30_week,	a.pw_crf_1_30_days,		a.pw_crf_1_37,	a.pw_crf1_38 as end_time,	a.sra_name from view_crf1 as a where a.form_crf_1_id in (select min(z.form_crf_1_id) from view_crf1 as z group by z.assis_id) and a.dssid like  '%" + txtdssid.Text + "%'    group by a.assis_id order by str_to_date(a.pw_crf1_02, '%d-%m-%Y'), STR_TO_DATE(a.pw_crf1_03,  '%H:%i')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=1st Ultrasound (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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