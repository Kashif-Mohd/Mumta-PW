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
    public partial class infantdeath : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        static string StudyID;
        static string currentdate;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "infantdeath";
                txtdssid.Focus();
                // ShowData();
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
            if (txtdssid.Text.Length < 5)
            {
                showalert("Minimum 5 digit and char required!");
                txtdssid.Focus();
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
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT b.`study_code` AS study_id,b.dssid,b.woman_nm,b.husband_nm,b.pw_crf_6a_2 AS DOV,b.pw_crf_6a_19 AS DOB,b.pw_crf_6a_20 AS TOB,   TIME_FORMAT(TIMEDIFF(CONCAT(STR_TO_DATE(a.date_of_death,'%d-%m-%Y'),' ',TIME_FORMAT(REPLACE(a.time_of_death,' ',''),'%H:%i:%s')),CONCAT(STR_TO_DATE(`b`.`pw_crf_6a_19`,'%d-%m-%Y'),' ',TIME_FORMAT(REPLACE(`b`.`pw_crf_6a_20`,' ',''),'%H:%i:%s'))),'%H:%i:%s') AS `death_duration`, a.`date_of_death`,a.`time_of_death`  FROM view_crf6a AS b LEFT JOIN    form_crf_6a_infant_death AS a ON a.`study_id`=b.study_code    WHERE b.pw_crf_6a_22='1'    and  b.`study_code`	LIKE '%" + txtdssid.Text + "%' 		OR 		b.dssid LIKE '%" + txtdssid.Text + "%' ", con);
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
                cmd = new MySqlCommand("SELECT b.`study_code` AS study_id,b.dssid,b.woman_nm,b.husband_nm,b.pw_crf_6a_2 AS DOV,b.pw_crf_6a_19 AS DOB,b.pw_crf_6a_20 AS TOB,  TIME_FORMAT(TIMEDIFF(CONCAT(STR_TO_DATE(a.date_of_death,'%d-%m-%Y'),' ',TIME_FORMAT(REPLACE(a.time_of_death,' ',''),'%H:%i:%s')),CONCAT(STR_TO_DATE(`b`.`pw_crf_6a_19`,'%d-%m-%Y'),' ',TIME_FORMAT(REPLACE(`b`.`pw_crf_6a_20`,' ',''),'%H:%i:%s'))),'%H:%i:%s') AS `death_duration`, a.`date_of_death`,a.`time_of_death`  FROM form_crf_6a_infant_death AS a LEFT JOIN view_crf6a AS b ON a.`study_id`=b.study_code   WHERE a.`study_id`	LIKE '%" + txtdssid.Text + "%' 		OR 		dssid LIKE '%" + txtdssid.Text + "%' ", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Infant Death (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[8].Text == "Pending")
            //    {
            //        TableCell cell = e.Row.Cells[8];
            //        cell.ForeColor = System.Drawing.Color.FromName("#dfe6e9");
            //        cell.BackColor = System.Drawing.Color.FromName("#ff7675");
            //    }
            //}
        }




        protected void Link_EditForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["RolePW"]) == "web_sup_admin" || Convert.ToString(Session["RolePW"]) == "web_admin")
            {
                StudyID = null;
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                StudyID = commandArgs[0];
                panel_VIEW_infant_death.Visible = false;
                panel_EDIT_infant_death.Visible = true;
                FieldFill();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }



















        public bool CheckInfantDeath()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_6a_infant_death      WHERE study_id='" + txt_StudyID.Text + "'", con);
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
                currentdate = DateTime.Now.ToString("dd-MM-yyyy");

                if (txtDOD.Text == "" || txtDOD.Text == "__-__-____")
                {
                    showalert("Enter Date of Death!");
                    txtDOD.Focus();
                }
                else if (DateTime.ParseExact(txtDOD.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtDOD.Focus();
                }
                else if (DateTime.ParseExact(txtDOD.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(txtDOB.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Birth (" + txtDOB.Text + ")");
                    txtDOD.Focus();
                }
                else if (txtTOD.Text == "" || txtTOD.Text == "__:__")
                {
                    showalert("Enter Time of Death!");
                    txtTOD.Focus();
                }
                else
                {
                    if (CheckInfantDeath() == false)
                    {

                        MySqlCommand cmd = new MySqlCommand("insert into form_crf_6a_infant_death (study_id, date_of_death,time_of_death, entry_dt, entry_nm) values ('" + txt_StudyID.Text + "','" + txtDOD.Text + "','" + txtTOD.Text + "','" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "','" + Convert.ToString(Session["MPusernamePW"]) + "')", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("update form_crf_6a_infant_death set date_of_death='" + txtDOD.Text + "'	,time_of_death='" + txtTOD.Text + "', update_dt='" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "', update_nm='" + Convert.ToString(Session["MPusernamePW"]) + "'  where  study_id='" + txt_StudyID.Text + "'", cn);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                    Response.Redirect("infantdeath.aspx");
                }                
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
                MySqlCommand cmd = new MySqlCommand("SELECT b.study_code AS study_id,b.dssid,b.woman_nm,b.husband_nm, 	 DATE_FORMAT(	STR_TO_DATE(b.pw_crf_6a_19,'%d-%m-%Y') ,'%d-%m-%Y')  AS DOB,    b.pw_crf_6a_20 AS TOB,          a.`date_of_death`,  a.`time_of_death` FROM       view_crf6a AS b     LEFT JOIN   form_crf_6a_infant_death AS a       ON a.`study_id`=b.study_code        WHERE b.`study_code`  ='" + StudyID + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txt_StudyID.Text = StudyID;
                    txt_dss.Text = dr["dssid"].ToString();
                    txt_woman_nm.Text = dr["woman_nm"].ToString();
                    txt_husband_nm.Text = dr["husband_nm"].ToString();
                    txtDOB.Text = dr["DOB"].ToString();
                    txtDOD.Text = dr["date_of_death"].ToString();
                    txtTOD.Text = dr["time_of_death"].ToString();
                    txtDOD.Focus();
                }
            }
            finally
            {
                con.Close();
            }
        }




    }
}