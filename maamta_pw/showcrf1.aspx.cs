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
    public partial class showcrf1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["duplicateCRF1DSSID"] != null)
                {
                    Session["WebForm"] = "duplicateCRF1";
                    txtdssid.Text = Convert.ToString(Session["duplicateCRF1DSSID"]);

                    //Disable Calendar:
                    txtCalndrDate.Enabled = false;
                    txtCalndrDate1.Enabled = false;
                    CheckBox1.Checked = true;
                    divSearch.Visible = false;
                    date.Visible = false;
                    ShowData();

                    txtdssid.Focus();
                }
                else
                {
                    divBackButton.Visible = false;
                    DateFormatPageLoad();
                    Session["WebForm"] = "showcrf1";
                    ShowData();
                    txtdssid.Focus();
                }
            }
        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["duplicateCRF1DSSID"] = null;
            Response.Redirect("duplicateCRF1.aspx");
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
                    cmd = new MySqlCommand("select * from view_crf1 WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);
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
                    cmd = new MySqlCommand("select * from view_crf1 WHERE DSSID LIKE '%" + txtdssid.Text + "%' ", con);
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




        //protected void Link_Assis(object sender, EventArgs e)
        //{
        //    string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
        //    string form_crf_2 = commandArgs[0];
        //    string AssismentId = commandArgs[1];

        //    Session["form_crf_2"] = form_crf_2;
        //    Session["AssismentIdCRF2"] = AssismentId;
        //    Response.Redirect("showcrf1byid.aspx");
        //}




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }



        protected void btnExport_Click(object sender, EventArgs e)
        {
            //ShowData();
            //if (GridView1.Rows.Count != 0)
            //{
            //    ExcelExport();
            //}
            //txtdssid.Focus();
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
            //MySqlConnection con = new MySqlConnection(constr);
            //try
            //{
            //    if (CheckBox1.Checked == false)
            //    {
            //        con.Open();
            //        MySqlCommand cmd;
            //        cmd = new MySqlCommand("select * from view_crf2 WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by form_crf_2", con);
            //        MySqlDataAdapter sda = new MySqlDataAdapter();
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            DataTable dt = new DataTable();
            //            {
            //                sda.Fill(dt);
            //                GridView2.DataSource = dt;
            //                GridView2.DataBind();
            //                con.Close();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        con.Open();
            //        MySqlCommand cmd;
            //        cmd = new MySqlCommand("select * from view_crf2 WHERE DSSID LIKE '%" + txtdssid.Text + "%' order by form_crf_2", con);
            //        MySqlDataAdapter sda = new MySqlDataAdapter();
            //        {
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            DataTable dt = new DataTable();
            //            {
            //                sda.Fill(dt);
            //                GridView2.DataSource = dt;
            //                GridView2.DataBind();
            //                con.Close();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            //}
            //finally
            //{
            //    con.Close();
            //}
        }




        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=CRF1 (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[14].Text == "1")
            //    {
            //        e.Row.Cells[14].Text = "Complete";
            //    }
            //    else if (e.Row.Cells[14].Text == "2")
            //    {
            //        e.Row.Cells[14].Text = "Not at home";
            //    }
            //    else if (e.Row.Cells[14].Text == "3")
            //    {
            //        e.Row.Cells[14].Text = "Refused";
            //    }
            //    else if (e.Row.Cells[14].Text == "4")
            //    {
            //        e.Row.Cells[14].Text = "False Pregnancy";
            //    }
            //    else if (e.Row.Cells[14].Text == "5")
            //    {
            //        e.Row.Cells[14].Text = "Shifted out of DSS";
            //    }
            //    else if (e.Row.Cells[14].Text == "6")
            //    {
            //        e.Row.Cells[14].Text = "Adopted Child from outside DSS";
            //    }
            //    else if (e.Row.Cells[14].Text == "7")
            //    {
            //        e.Row.Cells[14].Text = "PW died before visit";
            //    }
            //}
        }



        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[14].Text == "1")
            //    {
            //        e.Row.Cells[14].Text = "Complete";
            //    }
            //    else if (e.Row.Cells[14].Text == "2")
            //    {
            //        e.Row.Cells[14].Text = "Not at home";
            //    }
            //    else if (e.Row.Cells[14].Text == "3")
            //    {
            //        e.Row.Cells[14].Text = "Refused";
            //    }
            //    else if (e.Row.Cells[14].Text == "4")
            //    {
            //        e.Row.Cells[14].Text = "False Pregnancy";
            //    }
            //    else if (e.Row.Cells[14].Text == "5")
            //    {
            //        e.Row.Cells[14].Text = "Shifted out of DSS";
            //    }
            //    else if (e.Row.Cells[14].Text == "6")
            //    {
            //        e.Row.Cells[14].Text = "Adopted Child from outside DSS";
            //    }
            //    else if (e.Row.Cells[14].Text == "7")
            //    {
            //        e.Row.Cells[14].Text = "PW died before visit";
            //    }
            //}

        }
    }
}