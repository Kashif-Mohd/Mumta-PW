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
    public partial class ancReport : System.Web.UI.Page
    {
        static string Assess_ID;

        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ancReport";

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
                    MySqlCommand cmd; cmd = new MySqlCommand("select anc_form_id,date_of_attempt as date_of_anc, q50_next_visit_dt as next_visit,dssid,assis_id,woman_nm,husband_nm from view_anc where anc_visit_id in (select max(anc_visit_id) from anc_visit_details group by pw_assist_id) and dssid like '%" + txtdssid.Text + "%' and str_to_date(date_of_attempt, '%d-%m-%Y')  between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')", con);

                    //cmd = new MySqlCommand("select b.anc_form_id,(select max(str_to_date(z.date_of_attempt, '%d-%m-%Y'))  from anc_visit_details as z where z.pw_assist_id=a.assis_id) as date_of_anc, (select max(str_to_date(z.q50_next_visit_dt, '%d-%m-%Y'))  from anc_visit_details as z where z.pw_assist_id=a.assis_id) as next_visit, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.assis_id,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm from pregnant_woman as a inner join anc_form as b on a.assis_id=b.pw_assist_code where concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%' and (select max(str_to_date(z.date_of_attempt, '%d-%m-%Y'))  from anc_visit_details as z where z.pw_assist_id=a.assis_id) between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y') order by b.anc_form_id", con);
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
                    cmd = new MySqlCommand("select anc_form_id,date_of_attempt as date_of_anc, q50_next_visit_dt as next_visit,dssid,assis_id,woman_nm,husband_nm from view_anc where anc_visit_id in (select max(anc_visit_id) from anc_visit_details group by pw_assist_id) and dssid like '%" + txtdssid.Text + "%'", con);

                    //cmd = new MySqlCommand("select b.anc_form_id,(select max(str_to_date(z.date_of_attempt, '%d-%m-%Y'))  from anc_visit_details as z where z.pw_assist_id=a.assis_id) as date_of_anc, (select max(str_to_date(z.q50_next_visit_dt, '%d-%m-%Y'))  from anc_visit_details as z where z.pw_assist_id=a.assis_id) as next_visit, concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.assis_id,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm from pregnant_woman as a inner join anc_form as b on a.assis_id=b.pw_assist_code where concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) LIKE '%" + txtdssid.Text + "%'  order by b.anc_form_id", con);
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
                cmd = new MySqlCommand("select b.anc_form_id,(select max(str_to_date(z.date_of_attempt, '%d-%m-%Y')) from anc_visit_details as z where z.pw_assist_id=a.assis_id) as date_of_attempt,a.pw_age,a.pw_hb_occp,a.pw_marriage_year,a.pw_marriage_months,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.assis_id,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm,b.anc_form_8,b.anc_form_9,b.anc_form_10,b.anc_form_11,b.anc_form_12,b.anc_form_14,b.anc_form_15,b.anc_form_16,b.anc_form_17,b.anc_form_18,b.anc_form_19,b.anc_form_20,b.anc_form_21,b.anc_form_22,b.anc_form_23,b.anc_form_24,b.anc_form_25,b.anc_form_26,b.anc_form_27,b.anc_form_28,b.anc_form_29,b.anc_form_30,b.anc_form_31,b.anc_form_32,b.anc_form_33,b.anc_form_34,b.anc_form_35,b.anc_form_36,b.anc_form_37,b.anc_form_38,b.anc_form_39,b.anc_form_40,b.anc_form_41,b.anc_form_42,b.anc_form_43,b.anc_form_44,b.anc_form_45,    b.anc_form_46_a,b.anc_form_46_b,b.anc_form_46_c,b.anc_form_46_d,    b.anc_form_46b_a,b.anc_form_46b_b,b.anc_form_46b_c,b.anc_form_46b_d, b.tt_1_date, b.tt_2_date       from pregnant_woman as a inner join anc_form as b on a.assis_id=b.pw_assist_code where a.assis_id='" + Assess_ID + "'", con);

                //cmd = new MySqlCommand("select b.anc_form_id,a.pw_age,a.pw_hb_occp,a.pw_marriage_year,a.pw_marriage_months,concat(a.pw_crf_1_11,a.pw_crf_1_12,a.pw_crf_1_13,a.pw_crf_1_14,a.pw_crf_1_15,a.pw_crf_1_16) as dssid,a.assis_id,a.pw_crf_1_09 as woman_nm,a.pw_crf_1_10 as husband_nm,b.anc_form_8,b.anc_form_9,b.anc_form_10,b.anc_form_11,b.anc_form_12,b.anc_form_14,b.anc_form_15,b.anc_form_16,b.anc_form_17,b.anc_form_18,b.anc_form_19,b.anc_form_20,b.anc_form_21,b.anc_form_22,b.anc_form_23,b.anc_form_24,b.anc_form_25,b.anc_form_26,b.anc_form_27,b.anc_form_28_a,b.anc_form_28_b,b.anc_form_28_c,b.anc_form_28_d from pregnant_woman as a inner join anc_form as b on a.assis_id=b.pw_assist_code where a.assis_id='EMP1:RG:5'", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    //Info
                    string WomanNm = dr["woman_nm"].ToString();
                    string HusbandNm = dr["husband_nm"].ToString();
                    string DSSID = dr["dssid"].ToString();
                    string AssessID = dr["assis_id"].ToString();
                    string Age = dr["pw_age"].ToString();
                    string marriage_year = dr["pw_marriage_year"].ToString();
                    string marriage_months = dr["pw_marriage_months"].ToString();
                    string hb_occp = dr["pw_hb_occp"].ToString();
                    string date_of_attempt = dr["date_of_attempt"].ToString();

                    // Convert Date of Visit  Format
                    string[] commandArgs = date_of_attempt.ToString().Split(new char[] { '-' });
                    string a = commandArgs[0];
                    string b = commandArgs[1];
                    string c = commandArgs[2];
                    date_of_attempt = c + "-" + b + "-" + a;



                    //First Info
                    string Q8 = dr["anc_form_8"].ToString();
                    string Q9 = dr["anc_form_9"].ToString();
                    string Q10 = dr["anc_form_10"].ToString();
                    string Q11 = dr["anc_form_11"].ToString();
                    string Q12 = dr["anc_form_12"].ToString();
                    string Q14 = dr["anc_form_14"].ToString();
                    string Q15 = dr["anc_form_15"].ToString();
                    string Q16 = dr["anc_form_16"].ToString();
                    string Q17 = dr["anc_form_17"].ToString();
                    string Q18 = dr["anc_form_18"].ToString();
                    string Q19 = dr["anc_form_19"].ToString();
                    string Q20 = dr["anc_form_20"].ToString();
                    string Q21 = dr["anc_form_21"].ToString();
                    string Q22 = dr["anc_form_22"].ToString();
                    string Q23 = dr["anc_form_23"].ToString();
                    string Q24 = dr["anc_form_24"].ToString();
                    string Q25 = dr["anc_form_25"].ToString();
                    string Q26 = dr["anc_form_26"].ToString();
                    string Q27 = dr["anc_form_27"].ToString();
                    string Q28 = dr["anc_form_28"].ToString();
                    string Q29 = dr["anc_form_29"].ToString();
                    string Q30 = dr["anc_form_30"].ToString();
                    string Q31 = dr["anc_form_31"].ToString();
                    string Q32 = dr["anc_form_32"].ToString();
                    string Q33 = dr["anc_form_33"].ToString();
                    string Q34 = dr["anc_form_34"].ToString();
                    string Q35 = dr["anc_form_35"].ToString();
                    string Q36 = dr["anc_form_36"].ToString();

                    string Q37 = dr["anc_form_37"].ToString();
                    string Q38 = dr["anc_form_38"].ToString();
                    string Q39 = dr["anc_form_39"].ToString();
                    string Q40 = dr["anc_form_40"].ToString();
                    string Q41 = dr["anc_form_41"].ToString();

                    string Q42 = dr["anc_form_42"].ToString();
                    string Q43 = dr["anc_form_43"].ToString();

                    string QTT1 = dr["tt_1_date"].ToString();
                    string QTT2 = dr["tt_2_date"].ToString();

                    string Q44 = dr["anc_form_44"].ToString();
                    string Q45 = dr["anc_form_45"].ToString();

                    string Q46b_a = dr["anc_form_46_a"].ToString();
                    string Q46b_b = dr["anc_form_46_b"].ToString();
                    string Q46b_c = dr["anc_form_46_c"].ToString();
                    string Q46b_d = dr["anc_form_46_d"].ToString();

                    string Q46a_a = dr["anc_form_46b_a"].ToString();
                    string Q46a_b = dr["anc_form_46b_b"].ToString();
                    string Q46a_c = dr["anc_form_46b_c"].ToString();
                    string Q46a_d = dr["anc_form_46b_d"].ToString();


                   


                    if (Q8 == "1") Q8 = "Yes";
                    else if (Q8 == "2") Q8 = "No";




                    if (Q14 == "1") Q14 = "Yes";
                    else if (Q14 == "2") Q14 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q14.ToString().Split(new char[] { ':' });
                        Q14 = "Yes, " + Args[1];
                    }
                    if (Q15 == "1") Q15 = "Yes";
                    else if (Q15 == "2") Q15 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q15.ToString().Split(new char[] { ':' });
                        Q15 = "Yes, " + Args[1];
                    }
                    if (Q16 == "1") Q16 = "Yes";
                    else if (Q16 == "2") Q16 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q16.ToString().Split(new char[] { ':' });
                        Q16 = "Yes, " + Args[1];
                    }
                    if (Q17 == "1") Q17 = "Yes";
                    else if (Q17 == "2") Q17 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q17.ToString().Split(new char[] { ':' });
                        Q17 = "Yes, " + Args[1];
                    }
                    if (Q18 == "1") Q18 = "Yes";
                    else if (Q18 == "2") Q18 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q18.ToString().Split(new char[] { ':' });
                        Q18 = "Yes, " + Args[1];
                    }
                    if (Q19 == "1") Q19 = "Yes";
                    else if (Q19 == "2") Q19 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q19.ToString().Split(new char[] { ':' });
                        Q19 = "Yes, " + Args[1];
                    }
                    if (Q20 == "1") Q20 = "Yes";
                    else if (Q20 == "2") Q20 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q20.ToString().Split(new char[] { ':' });
                        Q20 = "Yes, " + Args[1];
                    }
                    if (Q21 == "1") Q21 = "Yes";
                    else if (Q21 == "2") Q21 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q21.ToString().Split(new char[] { ':' });
                        Q21 = "Yes, " + Args[1];
                    }
                    if (Q22 == "1") Q22 = "Yes";
                    else if (Q22 == "2") Q22 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q22.ToString().Split(new char[] { ':' });
                        Q22 = "Yes, " + Args[1];
                    }
                    if (Q23 == "1") Q23 = "Yes";
                    else if (Q23 == "2") Q23 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q23.ToString().Split(new char[] { ':' });
                        Q23 = "Yes, " + Args[1];
                    }
                    if (Q24 == "1") Q24 = "Yes";
                    else if (Q24 == "2") Q24 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q24.ToString().Split(new char[] { ':' });
                        Q24 = "Yes, " + Args[1];
                    }
                    if (Q25 == "1") Q25 = "Yes";
                    else if (Q25 == "2") Q25 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q25.ToString().Split(new char[] { ':' });
                        Q25 = "Yes, " + Args[1];
                    }
                    if (Q26 == "1") Q26 = "Yes";
                    else if (Q26 == "2") Q26 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q26.ToString().Split(new char[] { ':' });
                        Q26 = "Yes, " + Args[1];
                    }
                    if (Q27 == "1") Q27 = "Yes";
                    else if (Q27 == "2") Q27 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q27.ToString().Split(new char[] { ':' });
                        Q27 = "Yes, " + Args[1];
                    }
                    if (Q28 == "1") Q28 = "Yes";
                    else if (Q28 == "2") Q28 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q28.ToString().Split(new char[] { ':' });
                        Q28 = "Yes, " + Args[1];
                    }




                    if (Q29 == "1") Q29 = "Yes";
                    else if (Q29 == "2") Q29 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q29.ToString().Split(new char[] { ':' });
                        Q29 = "Yes, " + Args[1];
                    }

                    if (Q30 == "1") Q30 = "Yes";
                    else if (Q30 == "2") Q30 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q30.ToString().Split(new char[] { ':' });
                        Q30 = "Yes, " + Args[1];
                    }

                    if (Q31 == "1") Q31 = "Yes";
                    else if (Q31 == "2") Q31 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q31.ToString().Split(new char[] { ':' });
                        Q31 = "Yes, " + Args[1];
                    }

                    if (Q32 == "1") Q32 = "Yes";
                    else if (Q32 == "2") Q32 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q32.ToString().Split(new char[] { ':' });
                        Q32 = "Yes, " + Args[1];
                    }

                    if (Q33 == "1") Q33 = "Yes";
                    else if (Q33 == "2") Q33 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q33.ToString().Split(new char[] { ':' });
                        Q33 = "Yes, " + Args[1];
                    }

                    if (Q34 == "1") Q34 = "Yes";
                    else if (Q34 == "2") Q34 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q34.ToString().Split(new char[] { ':' });
                        Q34 = "Yes, " + Args[1];
                    }

                    if (Q35 == "1") Q35 = "Yes";
                    else if (Q35 == "2") Q35 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q35.ToString().Split(new char[] { ':' });
                        Q35 = "Yes, " + Args[1];
                    }

                    if (Q36 == "1") Q36 = "Yes";
                    else if (Q36 == "2") Q36 = "No"; //Specify 
                    else
                    {
                        string[] Args = Q36.ToString().Split(new char[] { ':' });
                        Q36 = "Yes, " + Args[1];
                    }






                    if (Q37 == "1") Q37 = "Yes"; //Specify 
                    else if (Q37 == "2") Q37 = "No";
                    else
                    {
                        string[] Args = Q37.ToString().Split(new char[] { ':' });
                        Q37 = "No, " + Args[1];
                    }

                    if (Q38 == "1") Q38 = "Yes"; //Specify 
                    else if (Q38 == "2") Q38 = "No";
                    else
                    {
                        string[] Args = Q38.ToString().Split(new char[] { ':' });
                        Q38 = "No, " + Args[1];
                    }

                    if (Q39 == "1") Q39 = "Yes"; //Specify 
                    else if (Q39 == "2") Q39 = "No";
                    else
                    {
                        string[] Args = Q39.ToString().Split(new char[] { ':' });
                        Q39 = "No, " + Args[1];
                    }

                    if (Q40 == "1") Q40 = "Yes"; //Specify 
                    else if (Q40 == "2") Q40 = "No";
                    else
                    {
                        string[] Args = Q40.ToString().Split(new char[] { ':' });
                        Q40 = "No, " + Args[1];
                    }
                    if (Q41 == "1") Q41 = "Yes, have cardiac issue";
                    else if (Q41 == "2") Q41 = "No active disease"; //Specify 
                    else
                    {
                        string[] Args = Q41.ToString().Split(new char[] { ':' });
                        Q41 = "Yes have cardiac issue, " + Args[1];
                    }

                    if (Q44 == "1") Q44 = "Yes";
                    else if (Q44 == "2") Q44 = "No";




                    if (Q46a_a != "") Q46a_a = Q46a_a + ", ";
                    if (Q46a_b != "") Q46a_b = Q46a_b + ", ";
                    if (Q46a_c != "") Q46a_c = Q46a_c + ", ";
                    string Q46a = Q46a_a + Q46a_b + Q46a_c + Q46a_d;



                    if (Q46b_a != "") Q46b_a = Q46b_a + ", ";
                    if (Q46b_b != "") Q46b_b = Q46b_b + ", ";
                    if (Q46b_c != "") Q46b_c = Q46b_c + ", ";
                    string Q46b = Q46b_a + Q46b_b + Q46b_c + Q46b_d;




                    ReportParameterCollection ReportParameters = new ReportParameterCollection();
                    ReportViewer1.LocalReport.ReportPath = "ancReport.rdlc";
                    ReportViewer1.LocalReport.DataSources.Clear();


                    ReportParameters.Add(new ReportParameter("ReportParaWomanNm", WomanNm));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaHusbandNm", HusbandNm));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaDSSID", DSSID));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaAssessID", AssessID));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaAge", Age));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("marriage_year", marriage_year));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("marriage_months", marriage_months));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("ReportParaDate", date_of_attempt));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("hb_occp", hb_occp));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q8", Q8));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q9", Q9));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q10", Q10));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q11", Q11));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q12", Q12));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q14", Q14));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q15", Q15));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q16", Q16));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q17", Q17));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q18", Q18));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q19", Q19));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q20", Q20));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q21", Q21));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q22", Q22));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q23", Q23));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q24", Q24));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q25", Q25));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q26", Q26));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q27", Q27));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q28", Q28));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q29", Q29));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q30", Q30));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q31", Q31));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q32", Q32));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q33", Q33));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q34", Q34));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q35", Q35));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q36", Q36));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);



                    ReportParameters.Add(new ReportParameter("Q37", Q37));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q38", Q38));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q39", Q39));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q40", Q40));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q41", Q41));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q42", Q42));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q43", Q43));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("TT1", QTT1));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("TT2", QTT2));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q44", Q44));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q45", Q45 + " cm"));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q46a", Q46a));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q46b", Q46b));
                    this.ReportViewer1.LocalReport.SetParameters(ReportParameters);


                    //Table of ANC Appoint Date
                    //  ReportViewer1.Height = Microsoft.Reporting.WebForms.ZoomMode.FullPage;
                    ReportDataSource dsANCvisitAppointment = new ReportDataSource("anc_visit_app", ANCvisitAppointment());
                    this.ReportViewer1.LocalReport.DataSources.Add(dsANCvisitAppointment);

                    //Table of ANC Visit Details
                    ReportDataSource dsANCvisitDetails = new ReportDataSource("anc_visit_details", ANCvisitDetails());
                    this.ReportViewer1.LocalReport.DataSources.Add(dsANCvisitDetails);

                    //Table of Past History
                    ReportDataSource dsPastHistory = new ReportDataSource("past_history", PastHistory());
                    this.ReportViewer1.LocalReport.DataSources.Add(dsPastHistory);
                }
                con.Close();
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






        private DataTable ANCvisitAppointment()
        {
            DataTable dt = new DataTable();

            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.date_of_attempt,a.anc_visit_48,a.anc_visit_49,a.q50_next_visit_dt,concat(if(a.anc_visit_51_a=1,'Venofer dose, ',''), if(a.anc_visit_51_b=2,'Augmentin, ',''), if(a.anc_visit_51_c=3,'Flagyl, ',''), if(a.anc_visit_51_d=4,'Diclofenac tab, ',''), if(a.anc_visit_51_e=5,'Diclofenac inj, ',''), if(a.anc_visit_51_f=6,'Nospa, ',''), if(a.anc_visit_51_g=7,'Citrosoda, ',''), if(a.anc_visit_51_h=8,'Douphaston, ',''), if(a.anc_visit_51_i=9,'Lialac syrup, ',''), if(a.anc_visit_51_j=10,'Adicos syrup, ',''), if(a.anc_visit_51_k=11,'Canestin vaginal cream, ',''), if(a.anc_visit_51_l=12,'Methyldopa, ',''), if(a.anc_visit_51_m=13,'Captorpil, ',''), if(a.anc_visit_51_n=14,'Ascard,',''), if(a.anc_visit_51_o=15,'Vermox, ',''), if(a.anc_visit_51_p=16,'Ferrous suplphate, ',''), if(a.anc_visit_51_q=17,'Folic acid, ',''), if(a.anc_visit_51_r=18,'Paracetamol, ',''), if(a.anc_visit_51_s=19,'Ponstan, ',''), if(a.anc_visit_51_t=20,'Softin, ',''), if(a.anc_visit_51_u=21,'Tricel, ',''), if(a.anc_visit_51_w!='','Buscopan, ','')  , if(a.anc_visit_51_x!='','Canestin topical cream, ','') , if(a.anc_visit_51_y!='','Hydrozol cream, ','') , if(a.anc_visit_51_z!='','Synto injection, ','') , if(a.anc_visit_51_aa!='','S T mom tablet, ','') , if(a.anc_visit_51_ab!='','ORS, ','') , if(a.anc_visit_51_ac!='','NS 1000 ml, ','') , if(a.anc_visit_51_ad!='','LR 1000 ml, ',''), 		if(a.anc_visit_51_v !='',concat(a.anc_visit_51_v,', '),''), 		if(a.anc_visit_51_v1 !='',concat(a.anc_visit_51_v1,', '),''),		if(a.anc_visit_51_v2 !='',concat(a.anc_visit_51_v2,', '),''),		if(a.anc_visit_51_v3 !='',concat(a.anc_visit_51_v3,', '),''),		if(a.anc_visit_51_v4 !='',concat(a.anc_visit_51_v4,', '),'')		) as Q51 from anc_visit_details as a 		 where a.pw_assist_id='" + Assess_ID + "' order by str_to_date(a.date_of_attempt, '%d-%m-%Y')", con);

                //cmd = new MySqlCommand("select a.date_of_attempt,a.anc_visit_48,a.anc_visit_49,a.q50_next_visit_dt,concat(if(a.anc_visit_51_a=1,'Venofer dose, ',''), if(a.anc_visit_51_b=2,'Augmentin, ',''), if(a.anc_visit_51_c=3,'Flagyl, ',''), if(a.anc_visit_51_d=4,'Diclofenac tab, ',''), if(a.anc_visit_51_e=5,'Diclofenac inj, ',''), if(a.anc_visit_51_f=6,'Nospa, ',''), if(a.anc_visit_51_g=7,'Citrosoda, ',''), if(a.anc_visit_51_h=8,'Douphaston, ',''), if(a.anc_visit_51_i=9,'Lialac syrup, ',''), if(a.anc_visit_51_j=10,'Adicos syrup, ',''), if(a.anc_visit_51_k=11,'Canestin vaginal cream, ',''), if(a.anc_visit_51_l=12,'Methyldopa, ',''), if(a.anc_visit_51_m=13,'Captorpil, ',''), if(a.anc_visit_51_n=14,'Ascard,',''), if(a.anc_visit_51_o=15,'Vermox, ',''), if(a.anc_visit_51_p=16,'Ferrous suplphate, ',''), if(a.anc_visit_51_q=17,'Folic acid, ',''), if(a.anc_visit_51_r=18,'Paracetamol, ',''), if(a.anc_visit_51_s=19,'Ponstan, ',''), if(a.anc_visit_51_t=20,'Softin, ',''), if(a.anc_visit_51_u=21,'Tricel, ',''), if(a.anc_visit_51_v !='',a.anc_visit_51_v,'')) as Q51 from anc_visit_details as a where a.pw_assist_id='" + Assess_ID + "' order by str_to_date(a.date_of_attempt, '%d-%m-%Y')", con);

                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
            return dt;
        }





        private DataTable ANCvisitDetails()
        {
            DataTable dt = new DataTable();

            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.date_of_attempt,a.q50_sbp,a.q50_dbp,a.q50_wt,a.q50_wop,a.q50_uts,	(CASE WHEN a.q50_pres= '1' THEN 'Cephalic' WHEN a.q50_pres = '2' THEN 'Breech' WHEN a.q50_pres = '3' THEN 'Shoulder' WHEN a.q50_pres = '4' THEN 'Not determined yet' WHEN a.q50_pres = '5' THEN 'Not recorded'  ELSE a.q50_pres END) as q50_pres,		(CASE WHEN a.q50_fhs= '1' THEN 'Yes' WHEN a.q50_fhs = '2' THEN 'No' END) as q50_fhs,	(CASE WHEN a.q50_odm= '1' THEN 'Yes' WHEN a.q50_odm = '2' THEN 'No' END) as q50_odm,	(CASE WHEN a.q50_anm= '1' THEN 'Yes' WHEN a.q50_anm= '2' THEN 'No' END) as q50_anm,			(CASE WHEN a.q50_rcomp= '1' THEN 'JPMC' WHEN a.q50_rcomp= '2' THEN 'CIVIL' WHEN a.q50_rcomp= '3' THEN 'AKU KHARADAR' WHEN a.q50_rcomp= '4' THEN 'AKU' WHEN a.q50_rcomp= '5' THEN 'ATTIYA' WHEN a.q50_rcomp= '9' THEN 'not required' ELSE a.q50_rcomp END) as q50_rcomp,	a.q50_rks from anc_visit_details as a where a.pw_assist_id='" + Assess_ID + "' order by str_to_date(a.date_of_attempt, '%d-%m-%Y')", con);

                //cmd = new MySqlCommand("select date_of_attempt,	q50_sbp,	q50_dbp,	q50_wt,	q50_wop,	q50_uts,	(CASE WHEN q50_pres= '1' THEN 'Cephalic' WHEN q50_pres = '2' THEN 'Breech' WHEN q50_pres = '3' THEN 'Shoulder' WHEN q50_pres = '4' THEN 'Not determined yet' WHEN q50_pres = '5' THEN 'Not recorded'  ELSE q50_pres END) as q50_pres,		(CASE WHEN q50_fhs= '1' THEN 'Yes' WHEN q50_fhs = '2' THEN 'No' END) as q50_fhs,	(CASE WHEN q50_odm= '1' THEN 'Yes' WHEN q50_odm = '2' THEN 'No' END) as q50_odm,	(CASE WHEN q50_anm= '1' THEN 'Yes' WHEN q50_anm= '2' THEN 'No' END) as q50_anm,			(CASE WHEN q50_rcomp= '1' THEN 'JPMC' WHEN q50_rcomp= '2' THEN 'CIVIL' WHEN q50_rcomp= '3' THEN 'AKU KHARADAR' WHEN q50_rcomp= '4' THEN 'AKU' WHEN q50_rcomp= '5' THEN 'ATTIYA' WHEN q50_rcomp= '9' THEN 'not required' ELSE q50_rcomp END) as q50_rcomp,	q50_rks from anc_visit_details as a where a.pw_assist_id='" + Assess_ID + "' order by str_to_date(a.date_of_attempt, '%d-%m-%Y')", con);

                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
            return dt;
        }






        private DataTable PastHistory()
        {
            DataTable dt = new DataTable();

            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;

                cmd = new MySqlCommand("select a.anc_q13_dob, (CASE WHEN a.anc_q13_dop = '1' THEN 'before 22 weeks' WHEN a.anc_q13_dop = '2' THEN 'before 22-28 weeks' WHEN a.anc_q13_dop = '3' THEN 'before 29-32 weeks' WHEN a.anc_q13_dop = '4' THEN 'before 33-37 weeks' WHEN a.anc_q13_dop = '5' THEN 'before 38-40 weeks' WHEN a.anc_q13_dop = '6' THEN 'before 41-42 weeks' WHEN a.anc_q13_dop = '9' THEN 'Do not know' WHEN a.anc_q13_dop = '99' THEN 'Do not know' ELSE a.anc_q13_dop END)  anc_q13_dop,		(CASE WHEN a.anc_q13_ofp = '1' THEN 'Born alive' WHEN a.anc_q13_ofp = '2' THEN 'Stillbirth' WHEN a.anc_q13_ofp = '3' THEN 'Miscarriage'  ELSE a.anc_q13_ofp END) as anc_q13_ofp,	(CASE WHEN a.anc_q13_pob = '1' THEN 'Home' WHEN a.anc_q13_pob = '2' THEN 'KGH' WHEN a.anc_q13_pob = '3' THEN 'Jinnah / Civil' WHEN a.anc_q13_pob = '4' THEN 'Other government hospital' WHEN a.anc_q13_pob = '5' THEN 'Private hospital' WHEN a.anc_q13_pob = '6' THEN 'Maternity center / clinic' WHEN a.anc_q13_pob = '7' THEN 'On the way' WHEN a.anc_q13_pob = '8' THEN 'Do not know' WHEN a.anc_q13_pob = '9' THEN 'Kharadar AKU'  ELSE a.anc_q13_pob END) as anc_q13_pob,		(CASE WHEN a.anc_q13_mod = '1' THEN 'Normal' WHEN a.anc_q13_mod = '2' THEN 'Elective C-section' WHEN a.anc_q13_mod = '3' THEN 'Emergency operation' WHEN a.anc_q13_mod = '4' THEN 'Forcep delivery'  ELSE a.anc_q13_mod END) as	anc_q13_mod,		(CASE WHEN a.anc_q13_gender= '1' THEN 'Male' WHEN a.anc_q13_gender= '2' THEN 'Female' WHEN a.anc_q13_gender= '9' THEN 'Do not know' ELSE a.anc_q13_gender END) as anc_q13_gender,	(CASE WHEN a.anc_q13_vital_status= '1' THEN 'Alive' WHEN a.anc_q13_vital_status= '2' THEN 'Died on day 0' WHEN a.anc_q13_vital_status= '3' THEN 'Died between 1-6 days' WHEN a.anc_q13_vital_status= '4' THEN 'Died between 7-28 days' WHEN a.anc_q13_vital_status= '5' THEN 'Died between 29-59 days' WHEN a.anc_q13_vital_status= '6' THEN 'Died between 3-5 months' WHEN a.anc_q13_vital_status= '7' THEN 'Died between 6-11 months' WHEN a.anc_q13_vital_status= '8' THEN 'Died between 12-59 months' WHEN a.anc_q13_vital_status= '88' THEN 'Miscarriage or stillbirth' ELSE a.anc_q13_vital_status END) as anc_q13_vital_status,		(CASE WHEN a.anc_q13_cn = '1' THEN 'Cardiac anomaly' WHEN a.anc_q13_cn = '2' THEN 'Cleft lip / palate' WHEN a.anc_q13_cn = '3' THEN 'Spina bifida' WHEN a.anc_q13_cn = '4' THEN 'Blood disease' WHEN a.anc_q13_cn = '5' THEN 'Limb deformity' WHEN a.anc_q13_cn = '6' THEN 'Scrotal hernia' WHEN a.anc_q13_cn = '7' THEN 'Hep B/C' WHEN a.anc_q13_cn = '8' THEN 'Umbilical hernia' WHEN a.anc_q13_cn = '9' THEN 'Hydrocephalus' WHEN a.anc_q13_cn = '10' THEN 'Microcephalus' WHEN a.anc_q13_cn = '11' THEN 'Eye defect' WHEN a.anc_q13_cn = '12' THEN 'Skin defect' WHEN a.anc_q13_cn = '13' THEN 'Intestinal obstruction' WHEN a.anc_q13_cn = '88' THEN 'No Anomaly'	WHEN a.anc_q13_cn = '99' THEN 'Do not know'  ELSE a.anc_q13_cn END) as anc_q13_cn,a.anc_q13_complication  	from anc_past_ob_history as a where      a.pw_assist_code='" + Assess_ID + "'", con);
                //cmd = new MySqlCommand("select a.anc_q13_dob,a.anc_q13_dop,a.anc_q13_ofp,a.anc_q13_pob,a.anc_q13_mod,a.anc_q13_gender,a.anc_q13_vital_status,a.anc_q13_cn from anc_past_ob_history as a where a.pw_assist_code='EMP1:RG:5'", con);

                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Assess_ID = null;
            Response.Redirect("ancReport.aspx");
        }


        protected void Link_Assis(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Assess_ID = commandArgs[0];
            DivShow.Visible = false;
            DivReport.Visible = true;
            GetInfo();
        }


    }
}