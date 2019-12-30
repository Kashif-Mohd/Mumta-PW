using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WebForms;


namespace maamta_pw
{
    public partial class ultraReport : System.Web.UI.Page
    {
        static string Assess_ID;

        static string formCRF1id;
        static int total;
        static int examination_id;

        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ultraReport";
                DateFormatPageLoad();
                ShowData();
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


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
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
            }
            txtdssid.Focus();
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
                    cmd = new MySqlCommand("select b.form_crf_1_id,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.assis_id,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm,b.pw_crf1_02 as date_ultra, b.pw_crf1_03 as time_ultra from pregnant_woman as a left join form_crf_1 as b on a.assis_id=b.pw_assist_code WHERE concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%' and (str_to_date(pw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by (str_to_date(pw_crf1_02, '%d-%m-%Y'))", con);
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
                    cmd = new MySqlCommand("select b.form_crf_1_id,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.assis_id,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm,b.pw_crf1_02 as date_ultra, b.pw_crf1_03 as time_ultra from pregnant_woman as a left join form_crf_1 as b on a.assis_id=b.pw_assist_code where  concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) like '%" + txtdssid.Text + "%'  order by (str_to_date(pw_crf1_02, '%d-%m-%Y'))", con);
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














        private void GetInfo()
        {
            ReportViewer1.Reset();

            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select b.form_crf_1_id,a.pw_age,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,b.pw_crf1_19 as no_of_fetuses,a.assis_id,b.pw_crf1_02,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm,b.pw_crf1_18_a,b.pw_crf1_18_b,b.pw_crf1_18_c,b.pw_crf1_18_d,b.pw_crf1_18_e,b.pw_crf1_18_f,b.pw_crf1_18_g,b.pw_crf1_18_h,b.pw_crf1_18_i,b.pw_crf1_18_j,b.pw_crf1_19 from pregnant_woman as a left join form_crf_1 as b on a.assis_id=b.pw_assist_code where a.assis_id='" + Assess_ID + "' and b.form_crf_1_id='" + formCRF1id + "'", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    string WomanNm = dr["woman_nm"].ToString();
                    string HusbandNm = dr["husband_nm"].ToString();
                    string DSSID = dr["dssid"].ToString();
                    string AssessID = dr["assis_id"].ToString();
                    string Date = dr["pw_crf1_02"].ToString();
                    string Q19 = dr["pw_crf1_19"].ToString();
                    string Q18a = dr["pw_crf1_18_a"].ToString();
                    string Q18b = dr["pw_crf1_18_b"].ToString();
                    string Q18c = dr["pw_crf1_18_c"].ToString();
                    string Q18d = dr["pw_crf1_18_d"].ToString();
                    string Q18e = dr["pw_crf1_18_e"].ToString();
                    string Q18f = dr["pw_crf1_18_f"].ToString();
                    string Q18g = dr["pw_crf1_18_g"].ToString();
                    string Q18h = dr["pw_crf1_18_h"].ToString();
                    string Q18i = dr["pw_crf1_18_i"].ToString();
                    string Q18j = dr["pw_crf1_18_j"].ToString();

                    if (Q18a == "1") Q18a = "Gestational age, ";
                    if (Q18b == "2") Q18b = "Multiple pregnancy, ";
                    if (Q18c == "3") Q18c = "Thr./missed abortion, ";
                    if (Q18d == "4") Q18d = "Fetal death, ";
                    if (Q18e == "5") Q18e = "Presentation, ";
                    if (Q18f == "6") Q18f = "Placental localization, ";
                    if (Q18g == "7") Q18g = "Hydatidiform mole, ";
                    if (Q18h == "8") Q18h = "Fetal growth retardation, ";
                    if (Q18i == "9") Q18i = "Fetal abnormality, ";

                    string Q18 = Q18a + Q18b + Q18c + Q18d + Q18e + Q18f + Q18g + Q18h + Q18i + Q18j;



                    if (Q19 == "1") Q19 = "Single";
                    else if (Q19 == "2") Q19 = "Twin";
                    else if (Q19 == "3") Q19 = "Triplet";
                    else if (Q19 == "4") Q19 = "Quadruplet";


                    ReportParameterCollection ReportParameters = new ReportParameterCollection();
                    ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                    ReportViewer1.LocalReport.DataSources.Clear();


                    ReportParameters.Add(new ReportParameter("ReportParaWomanNm", WomanNm));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaHusbandNm", HusbandNm));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaDSSID", DSSID));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaAssessID", AssessID));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaDate", Date));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q19", Q19));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q18", Q18));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    con.Close();

                    GetCount();
                    GetDetails();
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








        private void GetCount()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select count(*) as total, min(examination_id) as examination_id from ultrasound_examination where form_crf1_id='" + formCRF1id + "'", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    total = Convert.ToInt32(dr["total"].ToString());
                    examination_id = Convert.ToInt32(dr["examination_id"].ToString());
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




        private void GetDetails()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                for (int i = 1; i <= total; i++)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from ultrasound_examination where examination_id='" + examination_id + "' and form_crf1_id='" + formCRF1id + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        string Q20 = dr["pw_crf_1_20"].ToString();
                        string Q21 = dr["pw_crf_1_21"].ToString();
                        string Q22 = dr["pw_crf_1_22"].ToString();
                        string Q23 = dr["pw_crf_1_23"].ToString();
                        string Q33 = dr["pw_crf_1_33"].ToString();
                        string Q34 = dr["pw_crf_1_34"].ToString();
                        string Q35a = dr["pw_crf_1_35_a"].ToString();
                        string Q35b = dr["pw_crf_1_35_b"].ToString();
                        string Q35c = dr["pw_crf_1_35_c"].ToString();
                        string Q35d = dr["pw_crf_1_35_d"].ToString();
                        string Q35e = dr["pw_crf_1_35_e"].ToString();
                        string Q35f = dr["pw_crf_1_35_f"].ToString();
                        string Q35g = dr["pw_crf_1_35_g"].ToString();
                        string Q35h = dr["pw_crf_1_35_h"].ToString();
                        string Q35i = dr["pw_crf_1_35_i"].ToString();
                        string Q35j = dr["pw_crf_1_35_j"].ToString();
                        string Q35k = dr["pw_crf_1_35_k"].ToString();
                        string Q35l = dr["pw_crf_1_35_l"].ToString();
                        string Q36 = dr["pw_crf_1_36"].ToString();
                        string Q37 = dr["pw_crf_1_37"].ToString();

                        if (Q20 == "1") Q20 = "Longitudinal";
                        else if (Q20 == "2") Q20 = "Transverse";
                        else if (Q20 == "3") Q20 = "Oblique";
                        else if (Q20 == "4") Q20 = "Not determined yet";
                        else if (Q20 == "5") Q20 = "Not recorded";


                        if (Q21 == "1") Q21 = "Cephalic";
                        else if (Q21 == "2") Q21 = "Breech";
                        else if (Q21 == "3") Q21 = "Shoulder";
                        else if (Q21 == "4") Q21 = "Not determined yet";
                        else if (Q21 == "5") Q21 = "Not recorded";


                        if (Q22 == "1") Q22 = "Present";
                        else if (Q22 == "2") Q22 = "Absent";
                        else if (Q22 == "3") Q22 = "Not recorded";


                        if (Q23 == "1") Q23 = "Present";
                        else if (Q23 == "2") Q23 = "Absent";
                        else if (Q23 == "3") Q23 = "Not recorded";


                        if (Q33 == "1") Q33 = "Adequate";
                        else if (Q33 == "2") Q33 = "Scanty";
                        else if (Q33 == "3") Q33 = "Excess";
                        else if (Q33 == "4") Q33 = "Not recorded";


                        if (Q34 == "1") Q34 = "Normal";
                        else if (Q34 == "2") Q34 = "Abnormal";
                        else if (Q34 == "3") Q34 = "Not recorded";

                        if (Q35a == "1") Q35a = "Fundus, ";
                        if (Q35b == "2") Q35b = "Anterior wall, ";
                        if (Q35c == "3") Q35c = "Posterior wall, ";
                        if (Q35d == "4") Q35d = "Right wall, ";
                        if (Q35e == "5") Q35e = "Left wall, ";
                        if (Q35f == "6") Q35f = "On lower segment, ";
                        if (Q35g == "7") Q35g = "Uterine wall not encroaching, ";
                        if (Q35h == "8") Q35h = "Placenta low lying, covering int. Os, ";
                        if (Q35i == "9") Q35i = "Placenta low lying, not covering int. Os, ";
                        if (Q35j == "10") Q35j = "Not low lying, ";
                        if (Q35k == "11") Q35k = "Placenta previa, ";
                        if (Q35l == "12") Q35l = "Placenta all around seen, ";

                        string Q35 = Q35a + Q35b + Q35c + Q35d + Q35e + Q35f + Q35g + Q35h + Q35i + Q35j + Q35k + Q35l;


                        ReportParameterCollection ReportParameters = new ReportParameterCollection();
                        ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";

                        ReportParameters.Add(new ReportParameter("Q20_" + i + "", Q20));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q21_" + i + "", Q21));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q22_" + i + "", Q22));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q23_" + i + "", Q23));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q33_" + i + "", Q33));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q34_" + i + "", Q34));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q35_" + i + "", Q35));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q36_" + i + "", Q36));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q37_" + i + "", Q37));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);



                        // MEASUREMENT 



                        string Q24 = dr["pw_crf_1_24"].ToString();
                        string Q25 = dr["pw_crf_1_25"].ToString();
                        string Q26 = dr["pw_crf_1_26"].ToString();
                        string Q27 = dr["pw_crf_1_27"].ToString();
                        string Q28 = dr["pw_crf_1_28"].ToString();
                        string Q29 = dr["pw_crf_1_29"].ToString();
                        string Q31 = dr["pw_crf_1_31"].ToString();
                        string Q32 = dr["pw_crf_1_32"].ToString();
                        string Q30a = dr["pw_crf_1_30_week"].ToString();
                        string Q30b = dr["pw_crf_1_30_days"].ToString();

                        string Q30 = Q30a + " Weeks ± " + Q30b + " Days.";



                        ReportParameters.Add(new ReportParameter("Q24_" + i + "", Q24 + " cm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q25_" + i + "", Q25 + " cm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q26_" + i + "", Q26 + " cm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q27_" + i + "", Q27 + " cm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q28_" + i + "", Q28 + " cm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q29_" + i + "", Q29 + " cm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q31_" + i + "", Q31 + " gm"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q32_" + i + "", Q32 + " ml"));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                        ReportParameters.Add(new ReportParameter("Q30_" + i + "", Q30));
                        this.ReportViewer1.LocalReport.SetParameters(ReportParameters);


                        con.Close();
                        examination_id = examination_id + 1;
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



        protected void btnBack_Click(object sender, EventArgs e)
        {
            total = 0;
            examination_id = 0;
            formCRF1id = null;
            Assess_ID = null;
            Response.Redirect("ultraReport.aspx");
        }




        protected void Link_Assis(object sender, EventArgs e)
        {
            formCRF1id = "";
            total = 0;
            examination_id = 0;

            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Assess_ID = commandArgs[0];
            formCRF1id = commandArgs[1];

            DivShow.Visible = false;
            DivReport.Visible = true;
            GetInfo();
        }



    }
}