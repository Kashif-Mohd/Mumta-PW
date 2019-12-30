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
    public partial class ancVisits : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "ancVisits";
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
                    cmd = new MySqlCommand("select a.assis_id, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid, a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm,b.q50_next_visit_dt as appointment_date  from anc_visit_details as b left join pregnant_woman as a on a.assis_id=b.pw_assist_id  where b.anc_visit_id in (select max(z.anc_visit_id) from anc_visit_details as z group by z.pw_assist_id)		  and (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y') != '')  and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%'    order by (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y'))", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
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
                else
                {

                    cmd = new MySqlCommand("select a.assis_id, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid, a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm,b.q50_next_visit_dt as appointment_date  from anc_visit_details as b left join pregnant_woman as a on a.assis_id=b.pw_assist_id  where b.anc_visit_id in (select max(z.anc_visit_id) from anc_visit_details as z group by z.pw_assist_id)		  and (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y') != '')  and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%'    and (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))		 order by (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y'))", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
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



        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }



        public void ExcelExportMessage()
        {
            GridView2.Caption = "<h3/>ANC Visit Schedule<br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
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
                    cmd = new MySqlCommand("select a.assis_id, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid, a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm,b.q50_next_visit_dt as appointment_date  from anc_visit_details as b left join pregnant_woman as a on a.assis_id=b.pw_assist_id  where b.anc_visit_id in (select max(z.anc_visit_id) from anc_visit_details as z group by z.pw_assist_id)		  and (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y') != '')  and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%'    order by (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y'))", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
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
                else
                {

                    cmd = new MySqlCommand("select a.assis_id, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid, a.pw_crf_1_09 as woman_nm, a.pw_crf_1_10 as husband_nm,b.q50_next_visit_dt as appointment_date  from anc_visit_details as b left join pregnant_woman as a on a.assis_id=b.pw_assist_id  where b.anc_visit_id in (select max(z.anc_visit_id) from anc_visit_details as z group by z.pw_assist_id)		  and (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y') != '')  and concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%'    and (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))		 order by (str_to_date(b.q50_next_visit_dt, '%d-%m-%Y'))", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
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
                Response.AddHeader("content-disposition", "attachment;filename=ANC-Visit Schedule (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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