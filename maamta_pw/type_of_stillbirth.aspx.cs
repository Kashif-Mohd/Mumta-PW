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
    public partial class type_of_stillbirth : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        static string StudyID;




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "type_of_stillbirth";
                ShowData();
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
            ShowData();
        }





        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT * FROM view_type_of_stillbirth WHERE dssid LIKE '%" + txtdssid.Text + "%'    or      study_code LIKE '%" + txtdssid.Text + "%'", con);
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
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT * FROM view_type_of_stillbirth WHERE dssid LIKE '%" + txtdssid.Text + "%'    or      study_code LIKE '%" + txtdssid.Text + "%'", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Type of StillBirth (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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























        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text == "Pending")
                {
                    TableCell cell = e.Row.Cells[8];
                    cell.ForeColor = System.Drawing.Color.FromName("#dfe6e9");
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                }
             
            }
        }




        protected void Link_EditForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["RolePW"]) == "web_sup_admin")
            {
                StudyID = null;
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                StudyID = commandArgs[0];
                panel_VIEW_type_of_stillbirth.Visible = false;
                panel_EDIT_type_of_stillbirth.Visible = true;
                FieldFill();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }



















        public bool InCompleteForm()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM view_type_of_stillbirth WHERE study_code='" + txt_StudyID.Text + "' and type_of_stillbirth!='Pending'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }








        protected void submit_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                if (InCompleteForm() == false)
                {

                    MySqlCommand cmd = new MySqlCommand("insert into form_crf_6a_stillbirth_type (study_id, type_of_stillbirth,description, entry_dt, entry_nm) values ('" + txt_StudyID.Text + "','" + DropDownList_TypeOfPregnancy.SelectedValue + "','" + txtremarks.InnerText + "','" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "','" + Convert.ToString(Session["MPusernamePW"]) + "')", cn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6a_stillbirth_type set type_of_stillbirth='" + DropDownList_TypeOfPregnancy.SelectedValue + "'	,description='" + txtremarks.InnerText + "', update_dt='" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "', update_nm='" + Convert.ToString(Session["MPusernamePW"]) + "'  where  study_id='" + txt_StudyID.Text + "'", cn);
                    cmd.ExecuteNonQuery();
                }
                cn.Close();
                Response.Redirect("type_of_stillbirth.aspx");
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }



        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM view_type_of_stillbirth WHERE study_code='" + StudyID + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txt_StudyID.Text = StudyID;
                    txt_dss.Text = dr["dssid"].ToString();
                    txt_woman_nm.Text = dr["woman_nm"].ToString();
                    txt_husband_nm.Text = dr["husband_nm"].ToString();
                    if (dr["type_of_stillbirth"].ToString() != "Pending")
                    {
                        DropDownList_TypeOfPregnancy.SelectedValue = dr["type_of_stillbirth"].ToString();
                    }
                    txtremarks.InnerText = dr["description"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }



    }
}