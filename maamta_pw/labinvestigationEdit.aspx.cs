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
    public partial class labinvestigationEdit : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        static string DOR;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "LABinvestigation";
                txtRandomid.Text = Request.QueryString["RandID"];
                DOR = null;
                FieldFill();
            }
        }



        //  Enrollment
        protected void enrollment_urine_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_enrollment_urine.Checked == true)
            {
                txtenrollment_urine.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtenrollment_urine.Attributes.Add("readonly", "readonly");
                txtenrollment_urine.Enabled = true;
            }
            else
            {
                txtenrollment_urine.Text = "";
                txtenrollment_urine.Enabled = false;
            }
        }

        protected void enrollment_hb_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_enrollment_hb.Checked == true)
            {
                txtenrollment_hb.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtenrollment_hb.Attributes.Add("readonly", "readonly");
                txtenrollment_hb.Enabled = true;
            }
            else
            {
                txtenrollment_hb.Text = "";
                txtenrollment_hb.Enabled = false;
            }
        }

        protected void enrollment_serum_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_enrollment_serum.Checked == true)
            {
                txtenrollment_serum.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtenrollment_serum.Attributes.Add("readonly", "readonly");
                txtenrollment_serum.Enabled = true;
            }
            else
            {
                txtenrollment_serum.Text = "";
                txtenrollment_serum.Enabled = false;
            }
        }

        protected void enrollment_plasma_niacin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_enrollment_plasma_niacin.Checked == true)
            {
                txtenrollment_plasma_niacin.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtenrollment_plasma_niacin.Attributes.Add("readonly", "readonly");
                txtenrollment_plasma_niacin.Enabled = true;
            }
            else
            {
                txtenrollment_plasma_niacin.Text = "";
                txtenrollment_plasma_niacin.Enabled = false;
            }
        }


        //  19 Weeks

        protected void chk19_wks_plasma_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_19_wks_plasma.Checked == true)
            {
                txt19_wks_plasma.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt19_wks_plasma.Attributes.Add("readonly", "readonly");
                txt19_wks_plasma.Enabled = true;
            }
            else
            {
                txt19_wks_plasma.Text = "";
                txt19_wks_plasma.Enabled = false;
            }
        }



        //  32 Weeks
        protected void chk32_wks_urine_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_32_wks_urine.Checked == true)
            {
                txt32_wks_urine.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt32_wks_urine.Attributes.Add("readonly", "readonly");
                txt32_wks_urine.Enabled = true;
            }
            else
            {
                txt32_wks_urine.Text = "";
                txt32_wks_urine.Enabled = false;
            }
        }

        protected void chk32_wks_hb_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_32_wks_hb.Checked == true)
            {
                txt32_wks_hb.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt32_wks_hb.Attributes.Add("readonly", "readonly");
                txt32_wks_hb.Enabled = true;
            }
            else
            {
                txt32_wks_hb.Text = "";
                txt32_wks_hb.Enabled = false;
            }
        }

        protected void chk32_wks_serum_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_32_wks_serum.Checked == true)
            {
                txt32_wks_serum.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt32_wks_serum.Attributes.Add("readonly", "readonly");
                txt32_wks_serum.Enabled = true;
            }
            else
            {
                txt32_wks_serum.Text = "";
                txt32_wks_serum.Enabled = false;
            }
        }

        protected void chk32_wks_plasma_proteomic_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_32_wks_plasma_proteomic.Checked == true)
            {
                txt32_wks_plasma_proteomic.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt32_wks_plasma_proteomic.Attributes.Add("readonly", "readonly");
                txt32_wks_plasma_proteomic.Enabled = true;
            }
            else
            {
                txt32_wks_plasma_proteomic.Text = "";
                txt32_wks_plasma_proteomic.Enabled = false;
            }
        }

        protected void chk32_wks_plasma_niacin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_32_wks_plasma_niacin.Checked == true)
            {
                txt32_wks_plasma_niacin.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt32_wks_plasma_niacin.Attributes.Add("readonly", "readonly");
                txt32_wks_plasma_niacin.Enabled = true;
            }
            else
            {
                txt32_wks_plasma_niacin.Text = "";
                txt32_wks_plasma_niacin.Enabled = false;
            }
        }










        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("labinvestigation.aspx");
        }








        protected void submit_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                string currentdate = DateTime.Now.ToString("dd-MM-yyyy");

                //enrollment_urine:
                if (chk_enrollment_urine.Checked == true && (DateTime.ParseExact(txtenrollment_urine.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_urine Date should be Less than Current Date!");
                    txtenrollment_urine.Focus();
                }
                else if (chk_enrollment_urine.Checked == true && DOR != null && (DateTime.ParseExact(txtenrollment_urine.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_urine Date should be greater than DOR: " + DOR + "");
                    txtenrollment_urine.Focus();
                }
                // enrollment_hb
                if (chk_enrollment_hb.Checked == true && (DateTime.ParseExact(txtenrollment_hb.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_hb Date should be Less than Current Date!");
                    txtenrollment_hb.Focus();
                }
                else if (chk_enrollment_hb.Checked == true && DOR != null && (DateTime.ParseExact(txtenrollment_hb.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_hb Date should be greater than DOR: " + DOR + "");
                    txtenrollment_hb.Focus();
                }
                // enrollment_serum
                if (chk_enrollment_serum.Checked == true && (DateTime.ParseExact(txtenrollment_serum.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_serum Date should be Less than Current Date!");
                    txtenrollment_serum.Focus();
                }
                else if (chk_enrollment_serum.Checked == true && DOR != null && (DateTime.ParseExact(txtenrollment_serum.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_serum Date should be greater than DOR: " + DOR + "");
                    txtenrollment_serum.Focus();
                }
                // enrollment_plasma_niacin
                if (chk_enrollment_plasma_niacin.Checked == true && (DateTime.ParseExact(txtenrollment_plasma_niacin.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_plasma_niacin Date should be Less than Current Date!");
                    txtenrollment_plasma_niacin.Focus();
                }
                else if (chk_enrollment_plasma_niacin.Checked == true && DOR != null && (DateTime.ParseExact(txtenrollment_plasma_niacin.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, enrollment_plasma_niacin Date should be greater than DOR: " + DOR + "");
                    txtenrollment_plasma_niacin.Focus();
                }



                // 19_wks_plasma
                if (chk_19_wks_plasma.Checked == true && (DateTime.ParseExact(txt19_wks_plasma.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 19_wks_plasma Date should be Less than Current Date!");
                    txt19_wks_plasma.Focus();
                }
                else if (chk_19_wks_plasma.Checked == true && DOR != null && (DateTime.ParseExact(txt19_wks_plasma.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 19_wks_plasma Date should be greater than DOR: " + DOR + "");
                    txt19_wks_plasma.Focus();
                }





                // 32_wks_urine
                if (chk_32_wks_urine.Checked == true && (DateTime.ParseExact(txt32_wks_urine.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_urine Date should be Less than Current Date!");
                    txt32_wks_urine.Focus();
                }
                else if (chk_32_wks_urine.Checked == true && DOR != null && (DateTime.ParseExact(txt32_wks_urine.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_urine Date should be greater than DOR: " + DOR + "");
                    txt32_wks_urine.Focus();
                }
                // 32_wks_hb
                if (chk_32_wks_hb.Checked == true && (DateTime.ParseExact(txt32_wks_hb.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_hb Date should be Less than Current Date!");
                    txt32_wks_hb.Focus();
                }
                else if (chk_32_wks_hb.Checked == true && DOR != null && (DateTime.ParseExact(txt32_wks_hb.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_hb Date should be greater than DOR: " + DOR + "");
                    txt32_wks_hb.Focus();
                }
                // 32_wks_serum
                if (chk_32_wks_serum.Checked == true && (DateTime.ParseExact(txt32_wks_serum.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_serum Date should be Less than Current Date!");
                    txt32_wks_serum.Focus();
                }
                else if (chk_32_wks_serum.Checked == true && DOR != null && (DateTime.ParseExact(txt32_wks_serum.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_serum Date should be greater than DOR: " + DOR + "");
                    txt32_wks_serum.Focus();
                }
                // 32_wks_plasma_proteomic
                if (chk_32_wks_plasma_proteomic.Checked == true && (DateTime.ParseExact(txt32_wks_plasma_proteomic.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_plasma_proteomic Date should be Less than Current Date!");
                    txt32_wks_plasma_proteomic.Focus();
                }
                else if (chk_32_wks_plasma_proteomic.Checked == true && DOR != null && (DateTime.ParseExact(txt32_wks_plasma_proteomic.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_plasma_proteomic Date should be greater than DOR: " + DOR + "");
                    txt32_wks_plasma_proteomic.Focus();
                }
                // 32_wks_plasma_niacin
                if (chk_32_wks_plasma_niacin.Checked == true && (DateTime.ParseExact(txt32_wks_plasma_niacin.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_plasma_niacin Date should be Less than Current Date!");
                    txt32_wks_plasma_niacin.Focus();
                }
                else if (chk_32_wks_plasma_niacin.Checked == true && DOR != null && (DateTime.ParseExact(txt32_wks_plasma_niacin.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < (DateTime.ParseExact(DOR, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 32_wks_plasma_niacin Date should be greater than DOR: " + DOR + "");
                    txt32_wks_plasma_niacin.Focus();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update lab_investigation set  enrollment_urine='" + txtenrollment_urine.Text + "', enrollment_hb='" + txtenrollment_hb.Text + "', enrollment_serum='" + txtenrollment_serum.Text + "', enrollment_plasma_niacin='" + txtenrollment_plasma_niacin.Text + "', 19_wks_plasma='" + txt19_wks_plasma.Text + "', 32_wks_urine='" + txt32_wks_urine.Text + "', 32_wks_hb='" + txt32_wks_hb.Text + "', 32_wks_serum='" + txt32_wks_serum.Text + "', 32_wks_plasma_proteomic='" + txt32_wks_plasma_proteomic.Text + "', 32_wks_plasma_niacin='" + txt32_wks_plasma_niacin.Text + "', entry_date='" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") + "', enter_by='" + Convert.ToString(Session["MPusernamePW"]) + "'  where  Randomization_ID='" + Request.QueryString["RandID"] + "'", cn);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record Updated Successfully!');window.location.href='labinvestigation.aspx';", true);
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
            MySqlCommand cmd = new MySqlCommand("select * from (SELECT b.lab_invest_id,a.study_code,b.Randomization_ID,a.dssid,a.Block,a.woman_nm,a.husband_nm,	a.pw_crf_3a_2 AS Enrollment,	CASE    WHEN b.Treatment =1 THEN 'A'    WHEN b.Treatment =2 THEN 'B'    WHEN b.Treatment =3 THEN 'C'    WHEN b.Treatment =4 THEN 'D' END AS ARM,	IF (b.Description!='',		DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (133-((xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days)) DAY),'%d-%m-%Y') 	,'') AS  19_weeks,	DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (224-((xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days)) DAY),'%d-%m-%Y') AS  32_weeks,			b.HB_FR_Vit_D_at_enrollment_and_week_32, b.Description,			 b.enrollment_urine, ROUND((((TO_DAYS(STR_TO_DATE(b.enrollment_urine,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS enrollment_urine_Weeks,	 b.enrollment_hb, ROUND((((TO_DAYS(STR_TO_DATE(b.enrollment_hb,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS enrollment_hb_Weeks,	 b.enrollment_serum, ROUND((((TO_DAYS(STR_TO_DATE(b.enrollment_serum,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS enrollment_serum_Weeks,	 b.enrollment_plasma_niacin, ROUND((((TO_DAYS(STR_TO_DATE(b.enrollment_plasma_niacin,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS enrollment_plasma_niacin_Weeks,	 b.19_wks_plasma, ROUND((((TO_DAYS(STR_TO_DATE(b.19_wks_plasma,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS 19_wks_plasma_Weeks,	 b.32_wks_urine, ROUND((((TO_DAYS(STR_TO_DATE(b.32_wks_urine,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS 32_wks_urine_Weeks,	 b.32_wks_hb, ROUND((((TO_DAYS(STR_TO_DATE(b.32_wks_hb,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS 32_wks_hb_Weeks, b.32_wks_serum, ROUND((((TO_DAYS(STR_TO_DATE(b.32_wks_serum,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS 32_wks_serum_Weeks, b.32_wks_plasma_proteomic, ROUND((((TO_DAYS(STR_TO_DATE(b.32_wks_plasma_proteomic,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS 32_wks_plasma_proteomic_Weeks, b.32_wks_plasma_niacin, ROUND((((TO_DAYS(STR_TO_DATE(b.32_wks_plasma_niacin,'%d-%m-%Y')) - TO_DAYS(STR_TO_DATE(DATE_FORMAT(ADDDATE((STR_TO_DATE(xx.pw_crf1_02, '%d-%m-%Y')), INTERVAL (	-	(xx.pw_crf_1_30_week * 7) + xx.pw_crf_1_30_days) DAY),'%d-%m-%Y'),'%d-%m-%Y')))/7)),0) AS 32_wks_plasma_niacin_Weeks FROM view_crf3a AS a LEFT JOIN lab_investigation AS b ON a.pw_crf_3a_18=b.Randomization_ID LEFT JOIN form_crf_3a AS yy ON yy.form_crf_3a_id=a.form_crf_3a_id LEFT JOIN (SELECT * FROM view_crf1 AS a WHERE a.form_crf_1_id IN (SELECT MIN(z.form_crf_1_id) FROM view_crf1 AS z GROUP BY z.assis_id)) AS xx ON SUBSTRING_INDEX(xx.assis_id,':',-1)=yy.pw_id 	ORDER BY b.Randomization_ID) as TableA                  where Randomization_ID='" + Request.QueryString["RandID"] + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {

                    DOR = dr["Enrollment"].ToString();

                    string[] EnrollmentDate = DOR.Split(new char[] { '-' });
                    string Day = EnrollmentDate[0];
                    string Month = EnrollmentDate[1];
                    string Year = EnrollmentDate[2];

                    if (Day.Length == 1) Day = "0" + Day;
                    if (Month.Length == 1) Month = "0" + Month;
                    DOR = Day + "-" + Month + "-" + Year;



                    txtDescription.Text = dr["description"].ToString();
                    txtwomannm.Text = dr["woman_nm"].ToString();
                    txthusbandnm.Text = dr["husband_nm"].ToString();

                    //  Enrollement
                    txtenrollment_urine.Text = dr["enrollment_urine"].ToString();
                    txtenrollment_hb.Text = dr["enrollment_hb"].ToString();
                    txtenrollment_serum.Text = dr["enrollment_serum"].ToString();
                    txtenrollment_plasma_niacin.Text = dr["enrollment_plasma_niacin"].ToString();


                    //  19 Weeks
                    txt19_wks_plasma.Text = dr["19_wks_plasma"].ToString();


                    //  32 Weeks
                    txt32_wks_urine.Text = dr["32_wks_urine"].ToString();
                    txt32_wks_hb.Text = dr["32_wks_hb"].ToString();
                    txt32_wks_serum.Text = dr["32_wks_serum"].ToString();
                    txt32_wks_plasma_proteomic.Text = dr["32_wks_plasma_proteomic"].ToString();
                    txt32_wks_plasma_niacin.Text = dr["32_wks_plasma_niacin"].ToString();





                    //  Enrollement
                    if (txtenrollment_urine.Text != "")
                    {
                        chk_enrollment_urine.Checked = true;
                        txtenrollment_urine.Attributes.Add("readonly", "readonly");
                        txtenrollment_urine.Enabled = true;
                    }
                    if (txtenrollment_hb.Text != "")
                    {
                        chk_enrollment_hb.Checked = true;
                        txtenrollment_hb.Attributes.Add("readonly", "readonly");
                        txtenrollment_hb.Enabled = true;
                    }
                    if (txtenrollment_serum.Text != "")
                    {
                        chk_enrollment_serum.Checked = true;
                        txtenrollment_serum.Attributes.Add("readonly", "readonly");
                        txtenrollment_serum.Enabled = true;
                    }
                    if (txtenrollment_plasma_niacin.Text != "")
                    {
                        chk_enrollment_plasma_niacin.Checked = true;
                        txtenrollment_plasma_niacin.Attributes.Add("readonly", "readonly");
                        txtenrollment_plasma_niacin.Enabled = true;
                    }



                    //  19 Weeks
                    if (txt19_wks_plasma.Text != "")
                    {
                        chk_19_wks_plasma.Checked = true;
                        txt19_wks_plasma.Attributes.Add("readonly", "readonly");
                        txt19_wks_plasma.Enabled = true;
                    }



                    //  32 Weeks
                    if (txt32_wks_urine.Text != "")
                    {
                        chk_32_wks_urine.Checked = true;
                        txt32_wks_urine.Attributes.Add("readonly", "readonly");
                        txt32_wks_urine.Enabled = true;
                    }
                    if (txt32_wks_hb.Text != "")
                    {
                        chk_32_wks_hb.Checked = true;
                        txt32_wks_hb.Attributes.Add("readonly", "readonly");
                        txt32_wks_hb.Enabled = true;
                    }
                    if (txt32_wks_serum.Text != "")
                    {
                        chk_32_wks_serum.Checked = true;
                        txt32_wks_serum.Attributes.Add("readonly", "readonly");
                        txt32_wks_serum.Enabled = true;
                    }
                    if (txt32_wks_plasma_proteomic.Text != "")
                    {
                        chk_32_wks_plasma_proteomic.Checked = true;
                        txt32_wks_plasma_proteomic.Attributes.Add("readonly", "readonly");
                        txt32_wks_plasma_proteomic.Enabled = true;
                    }
                    if (txt32_wks_plasma_niacin.Text != "")
                    {
                        chk_32_wks_plasma_niacin.Checked = true;
                        txt32_wks_plasma_niacin.Attributes.Add("readonly", "readonly");
                        txt32_wks_plasma_niacin.Enabled = true;
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }



    }
}