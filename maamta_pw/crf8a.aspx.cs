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
    public partial class crf8a : System.Web.UI.Page
    {
        string currentdate;
        static string PW_TRIAL_FormID;

        //MySQL 
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "entrycrf8";
                txtdssid.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        // Check Button:

        protected void checkButton_Click(object sender, EventArgs e)
        {
            // Q16:
            try
            {
                currentdate = DateTime.Now.ToString("dd-MM-yyyy");
                if (txtQ17DateStart.Text == "" || txtQ17DateStart.Text == "__-__-____")
                {
                    showalert("Enter Start Date Q17!");
                    txtQ17DateStart.Focus();
                }
                else if (DateTime.ParseExact(txtQ17DateStart.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtQ17DateStart.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtQ17DateStart.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtQ17DateStart.Focus();
                }
                else
                {
                    if (CompleteForm() == false)
                    {
                        Panel1.Visible = true;
                        txtStudyID.ReadOnly = true;
                        txtQ17DateStart.ReadOnly = true;
                        txtq17.Text = txtQ17DateStart.Text;
                        btnchk.Visible = false;
                        FieldFill();
                        txtq4.Focus();
                    }
                    else
                    {
                        txtQ17DateStart.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtQ17DateStart.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }
        }




        public bool CompleteForm()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where study_id='" + txtStudyID.Text + "' and q17='" + txtQ17DateStart.Text + "' and status='1'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Already Exist!')", true);
                    exist = true;
                    txtQ17DateStart.Focus();
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where study_id='" + txtStudyID.Text + "' and q17='" + txtQ17DateStart.Text + "' and status='0'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtq4.Text = dr["q4"].ToString();
                    txtq5.Text = dr["q5"].ToString();

                    txtq14.SelectedValue= dr["q14"].ToString();
                    txtq15.Text  = dr["q15"].ToString();
                    txtq17.Text = dr["q17"].ToString();
                    txtq18.Text = dr["q18"].ToString();
                    txtq19.Text = dr["q19"].ToString();
                    txtq20.Text = dr["q20"].ToString();
                    txtq21.Text = dr["q21"].ToString();
                    txtq22.Text = dr["q22"].ToString();
                    txtq23.Text = dr["q23"].ToString();
                    txtq24.Text = dr["q24"].ToString();
                    txtq25.Text = dr["q25"].ToString();
                    txtq26.Text = dr["q26"].ToString();
                }
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtdssid.Text == "" || txtdssid.Text.Length < 4)
            {
                showalert("Enter DSSID or Study ID, minimun length should be 4");
                txtdssid.Focus();
            }
            else
            {
                ShowData();
                FieldFill();
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
                cmd = new MySqlCommand("select * from view_crf3a as a  where a.dssid like '%" + txtdssid.Text + "%' or a.study_code like '%" + txtdssid.Text + "%'", con);
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


        protected void next_Click(object sender, EventArgs e)
        {
            PW_TRIAL_FormID = null;
            currentdate = DateTime.Now.ToString("dd-MM-yyyy");

            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                //// Q2:
                //if (DateTime.ParseExact(txtq2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                //{
                //    showalert("Incorrect Date, Should be Less than Current Date!");
                //    txtq2.Focus();
                //}
                //else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                //{
                //    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                //    txtq2.Focus();
                //}

                // Q17:
                
                if (DateTime.ParseExact(txtq17.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq17.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq17.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq17.Focus();
                }

                // Q19:
                else if (txtq19.Text != "88-88-8888" && (DateTime.ParseExact(txtq19.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq19.Focus();
                }
                else if (txtq19.Text != "88-88-8888" && (DateTime.ParseExact(txtq17.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq19.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Should be Greater than Q16 Date (" + txtq17.Text + ")");
                    txtq19.Focus();
                }

                // Q21:
                else if (DateTime.ParseExact(txtq21.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq21.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq21.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq21.Focus();
                }

                // Q23:
                else if (DateTime.ParseExact(txtq23.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq23.Focus();
                }
                else if (DateTime.ParseExact(txtq15.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq23.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq23.Focus();
                }
                // Q25:
                else if (DateTime.ParseExact(txtq25.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq25.Focus();
                }
                else if (DateTime.ParseExact(txtq25.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq23.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq15.Text + ")");
                    txtq25.Focus();
                }

                else if (check_CRF6a_ForQ14() == false && txtq14.SelectedValue == "2")
                {
                    showalert("CRF6a is not, First fill CRF6a and CRF6b then enter SAEs form");
                    txtq14.Focus();
                }
                else
                {
                    //FindFormID();

                    //string TimeQ26 = Convert.ToString(Convert.ToDateTime(txtq24.Text).AddMinutes(10).TimeOfDay);
                    //TimeQ26 = TimeQ26.Substring(0, 5);

                    int Age = Convert.ToInt32((Convert.ToDateTime(txtq17.Text) - Convert.ToDateTime(txtq15.Text)).TotalDays);


                    if (InCompleteForm() == false)
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into crf8(study_id,    q2,   q3,    q4,	q5,	q6,	q7,	dssid,	q14,	q15,	q16,	q17,	q18,	q19,	q20,	q21,	q22,	q23,	q24     ,q25    ,q26, status, entry_dt, entry_nm) values ('" + txtStudyID.Text + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + DateTime.Now.ToString("HH:mm") + "','" + txtq4.Text.ToUpper() + "','" + txtq5.Text.ToUpper() + "','" + txtq6WomanNm.Text.ToUpper() + "','" + txtq7HusbandNm.Text.ToUpper() + "','" + txtdssidQ8toQ13.Text.ToUpper() + "','" + txtq14.SelectedValue + "','" + txtq15.Text + "','" + Age + "','" + txtq17.Text + "','" + txtq18.Text + "' ,'" + txtq19.Text + "','" + txtq20.Text + "','" + txtq21.Text + "' ,'" + txtq22.Text + "','" + txtq23.Text + "','" + txtq24.Text + "','" + txtq25.Text + "' ,'" + txtq26.Text + "','" + "0" + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Convert.ToString(Session["MPusernamePW"]) + "')", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("update crf8 set q4='" + txtq4.Text + "'	,q5='" + txtq5.Text + "'	,q6='" + txtq6WomanNm.Text + "'	,q7='" + txtq7HusbandNm.Text + "'	,dssid='" + txtdssidQ8toQ13.Text + "'	,q14='" + txtq14.SelectedValue + "'	,q15='" + txtq15.Text + "'	,q16='" + Age + "'	,q17='" + txtq17.Text + "'	,q18='" + txtq18.Text + "'	,q19='" + txtq19.Text + "'	,q20='" + txtq20.Text + "', q21='" + txtq21.Text + "'	,q22='" + txtq22.Text + "'	,q23='" + txtq23.Text + "'	,q24='" + txtq22.Text + "',q25='" + txtq25.Text + "'	,q26='" + txtq26.Text + "', entry_dt='" + DateTime.Now.ToString("dd-MM-yyyy") + "', entry_nm='" + Convert.ToString(Session["MPusernamePW"]) + "'  where  study_id='" + txtStudyID.Text + "' and q17='" + txtq17.Text + "'  and status=0", cn);
                        cmd.ExecuteNonQuery();
                    }
                    InCompleteForm();
                    cn.Close();
                    Response.Redirect("crf8b.aspx?&FormID=" + PW_TRIAL_FormID + "&Study_ID=" + txtStudyID.Text.ToUpper());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtq17.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }
            finally
            {
                cn.Close();
            }
        }



        public bool check_CRF6a_ForQ14()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_6a WHERE study_code='" + txtStudyID.Text + "'", con);
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








        public bool InCompleteForm()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where study_id='" + txtStudyID.Text + "' and q17='" + txtQ17DateStart.Text + "' and status='0'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    PW_TRIAL_FormID = dr["id"].ToString();
                    exist = true;
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        protected void Link_OpenForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["RolePW"]) == "web_sup_admin" || Convert.ToString(Session["RolePW"]) == "web_admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                txtStudyID.Text = commandArgs[0];
                txtdssidQ8toQ13.Text = commandArgs[1];
                txtq6WomanNm.Text = commandArgs[2];
                txtq7HusbandNm.Text = commandArgs[3];
                txtq15.Text = commandArgs[4];

                forSearch.Visible = false;
                forEntry.Visible = true;

                txtQ17DateStart.Focus();
            }
            else
            {
                showalert("Only Admin has right to update details");
            }
        }



    }
}