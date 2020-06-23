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
    public partial class showanc_enrolled_labeled : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showanc_enrolled_labeled";
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
                    cmd = new MySqlCommand("SELECT a.anc_form_id AS 'anc_form_id',    a.anc_visit_id AS 'anc_visit_id',   a.assis_id AS 'assis_id',b.study_code,   a.date_of_attempt AS 'Date of Visit',    time_of_attempt AS 'Time of Visit',   woman_nm AS 'Woman Name',   husband_nm AS 'Husband Name',    dssid AS 'dssid',    pw_age AS 'Age of woman',    q50_next_visit_dt AS 'Next Appointment',    pw_hb_occp AS 'Husband occupation',    pw_marriage_year AS 'Year of marriage (Years)',    pw_marriage_months AS 'Year of marriage (Months)',    (CASE WHEN anc_form_8='1' THEN 'Yes'	WHEN anc_form_8='2' THEN 'No' END) AS 'Is this first pregnancy',    anc_form_9 AS 'Gravida',    anc_form_10 AS 'Alive births in the past',    anc_form_11 AS 'Stillbirths in the past',    anc_form_12 AS 'Miscarriage/Abortions in the past',    total_past_rec AS 'Past obstetric history (Alive birth + Stillbirth + Miscarriage/Abortions)', '-' AS 'Past Medical History',    (CASE WHEN anc_form_14 LIKE '1%' THEN 'Yes' WHEN anc_form_14='2' THEN 'No' END) AS 'PW has/had TB',    (CASE WHEN anc_form_15 LIKE '1%' THEN 'Yes' WHEN anc_form_15='2' THEN 'No' END) AS 'PW has/had Rheumatic fever',    (CASE WHEN anc_form_16 LIKE '1%' THEN 'Yes' WHEN anc_form_16='2' THEN 'No' END) AS 'PW has/had Kidney disease',    (CASE WHEN anc_form_17 LIKE '1%' THEN 'Yes' WHEN anc_form_17='2' THEN 'No' END) AS 'PW has/had Epilepsy',    (CASE WHEN anc_form_18 LIKE '1%' THEN 'Yes' WHEN anc_form_18='2' THEN 'No' END) AS 'PW has/had Diabetes Mellitus',    (CASE WHEN anc_form_19 LIKE '1%' THEN 'Yes' WHEN anc_form_19='2' THEN 'No' END) AS 'PW has/had Thalassemia',    (CASE WHEN anc_form_20 LIKE '1%' THEN 'Yes' WHEN anc_form_20='2' THEN 'No' END) AS 'PW has/had Mental illness',    (CASE WHEN anc_form_21 LIKE '1%' THEN 'Yes' WHEN anc_form_21='2' THEN 'No' END) AS 'PW has/had Respiratory disease',    (CASE WHEN anc_form_22 LIKE '1%' THEN 'Yes' WHEN anc_form_22='2' THEN 'No' END) AS 'PW has/had Rubella/Torch',    (CASE WHEN anc_form_23 LIKE '1%' THEN 'Yes' WHEN anc_form_23='2' THEN 'No' END) AS 'PW has/had Congenital abnormalities',    (CASE WHEN anc_form_24 LIKE '1%' THEN 'Yes' WHEN anc_form_24='2' THEN 'No' END) AS 'PW has/had a blood transfusion',    (CASE WHEN anc_form_25 LIKE '1%' THEN 'Yes' WHEN anc_form_25='2' THEN 'No' END) AS 'PW has/had subfertility',    (CASE WHEN anc_form_26 LIKE '1%' THEN 'Yes' WHEN anc_form_26='2' THEN 'No' END) AS 'PW has/had Hepatitis',    (CASE WHEN anc_form_27 LIKE '1%' THEN 'Yes' WHEN anc_form_27='2' THEN 'No' END) AS 'PW has/had hypertension',    (CASE WHEN anc_form_28 LIKE '1%' THEN 'Yes' WHEN anc_form_28='2' THEN 'No' END) AS 'PW has/had road traffic accident',    (CASE WHEN anc_form_29 LIKE '1%' THEN 'Yes' WHEN anc_form_29='2' THEN 'No' END) AS 'PW has/had operation/s',    (CASE WHEN anc_form_30 LIKE '1%' THEN 'Yes' WHEN anc_form_30='2' THEN 'No' END) AS 'PW has/had allergies or drug sensitivity',    (CASE WHEN anc_form_31 LIKE '1%' THEN 'Yes' WHEN anc_form_31='2' THEN 'No' END) AS 'Family history of TB ',    (CASE WHEN anc_form_32 LIKE '1%' THEN 'Yes' WHEN anc_form_32='2' THEN 'No' END) AS 'Family history of diabetes mellitus',    (CASE WHEN anc_form_33 LIKE '1%' THEN 'Yes' WHEN anc_form_33='2' THEN 'No' END) AS 'Family history of hypertension ',    (CASE WHEN anc_form_34 LIKE '1%' THEN 'Yes' WHEN anc_form_34='2' THEN 'No' END) AS 'Family history of twins',    (CASE WHEN anc_form_35 LIKE '1%' THEN 'Yes' WHEN anc_form_35='2' THEN 'No' END) AS 'Family history of congenital abnormalities',    (CASE WHEN anc_form_36 LIKE '1%' THEN 'Yes' WHEN anc_form_36='2' THEN 'No' END) AS 'Family history of thalassemia',    '-' AS 'Current Condition', (CASE WHEN anc_form_37 LIKE '1%' THEN 'Yes' WHEN anc_form_37 LIKE '2%' THEN 'No' END) AS 'General condition stable',    (CASE WHEN anc_form_38 LIKE '1%' THEN 'Yes' WHEN anc_form_38 LIKE '2%' THEN 'No' END) AS 'Chest clear',    (CASE WHEN anc_form_39 LIKE '1%' THEN 'Yes' WHEN anc_form_39 LIKE '2%' THEN 'No' END) AS 'Abdomen soft',    (CASE WHEN anc_form_40 LIKE '1%' THEN 'Yes' WHEN anc_form_40 LIKE '2%' THEN 'No' END) AS 'Breast examination normal',    (CASE WHEN anc_form_41 LIKE '1%' THEN 'Yes, have cardiac issue' WHEN anc_form_41 LIKE '2%' THEN 'No active disease' END) AS 'Heart disease',    anc_form_42 AS 'LMP',    anc_form_43 AS 'EDD',    (CASE WHEN anc_form_44='1' THEN 'Yes' WHEN anc_form_44='2' THEN 'No' END) AS 'Menstrual cycle regular?',    anc_form_45 AS 'Maternal height',    CONCAT(  (IF(a.anc_form_46a_1 !='',CONCAT(a.anc_form_46a_1,', '),'')), (IF(a.anc_form_46a_2 !='',CONCAT(a.anc_form_46a_2,', '),'')), (IF(a.anc_form_46a_3 !='',CONCAT(a.anc_form_46a_3,', '),'')), (IF(a.anc_form_46a_4 !='',CONCAT(a.anc_form_46a_4,', '),''))) AS 'High risk factor related to past pregnancy', (CASE WHEN anc_visit_47='1' THEN 'Yes' WHEN anc_visit_47='2' THEN 'No' END) AS 'Do you want to add lab report?',    anc_visit_48 AS 'Please write laboratory report serial number',    anc_visit_49 AS 'Write key lab report findings here',    q50_sbp AS 'Systolic BP',    q50_dbp AS 'Diastolic BP',    q50_wt AS 'Weight of PW',    q50_wop AS 'Weeks of pregnancy',    q50_uts AS 'Uterine size',    (CASE WHEN q50_pres='1' THEN 'Cephalic' WHEN q50_pres='2' THEN 'Breech'	WHEN q50_pres='3' THEN 'Shoulder'	WHEN q50_pres='4' THEN 'Not determined yet'	WHEN q50_pres='5' THEN 'Not recorded' END) AS 'Presentation',    (CASE WHEN q50_fhs='1' THEN 'Yes' WHEN q50_fhs='2' THEN 'No' END)  AS 'FHS',    (CASE WHEN q50_odm='1' THEN 'Yes' WHEN q50_odm='2' THEN 'No' END)  AS 'Oedema',    (CASE WHEN q50_anm='1' THEN 'Yes' WHEN q50_anm='2' THEN 'No' END)  AS 'Anemia',    (CASE WHEN q50_rcomp='1' THEN 'JPMC' WHEN q50_rcomp='2' THEN 'Civil' WHEN q50_rcomp='3' THEN 'AKU Kharadar' WHEN q50_rcomp='4' THEN 'AKU' WHEN q50_rcomp='5' THEN 'Attiya' WHEN q50_rcomp='9' THEN 'Not Required' END)   AS 'Is PW also registered at any of these facilities for pregnancy related complication',    q50_rks AS 'Remarks',    CONCAT(IF(a.anc_visit_51_a=1,'Venofer dose, ',''), IF(a.anc_visit_51_b=2,'Augmentin, ',''), IF(a.anc_visit_51_c=3,'Flagyl, ',''), IF(a.anc_visit_51_d=4,'Diclofenac tab, ',''), IF(a.anc_visit_51_e=5,'Diclofenac inj, ',''), IF(a.anc_visit_51_f=6,'Nospa, ',''), IF(a.anc_visit_51_g=7,'Citrosoda, ',''), IF(a.anc_visit_51_h=8,'Douphaston, ',''), IF(a.anc_visit_51_i=9,'Lialac syrup, ',''), IF(a.anc_visit_51_j=10,'Adicos syrup, ',''), IF(a.anc_visit_51_k=11,'Canestin vaginal cream, ',''), IF(a.anc_visit_51_l=12,'Methyldopa, ',''), IF(a.anc_visit_51_m=13,'Captorpil, ',''), IF(a.anc_visit_51_n=14,'Ascard,',''), IF(a.anc_visit_51_o=15,'Vermox, ',''), IF(a.anc_visit_51_p=16,'Ferrous suplphate, ',''), IF(a.anc_visit_51_q=17,'Folic acid, ',''), IF(a.anc_visit_51_r=18,'Paracetamol, ',''), IF(a.anc_visit_51_s=19,'Ponstan, ',''), IF(a.anc_visit_51_t=20,'Softin, ',''), IF(a.anc_visit_51_u=21,'Tricel, ',''), IF(a.anc_visit_51_w!='','Buscopan, ','')  , IF(a.anc_visit_51_x!='','Canestin topical cream, ','') , IF(a.anc_visit_51_y!='','Hydrozol cream, ','') , IF(a.anc_visit_51_z!='','Synto injection, ','') , IF(a.anc_visit_51_aa!='','S T mom tablet, ','') , IF(a.anc_visit_51_ab!='','ORS, ','') , IF(a.anc_visit_51_ac!='','NS 1000 ml, ','') , IF(a.anc_visit_51_ad!='','LR 1000 ml, ',''), 		IF(a.anc_visit_51_v !='',CONCAT(a.anc_visit_51_v,', '),''), 		IF(a.anc_visit_51_v1 !='',CONCAT(a.anc_visit_51_v1,', '),''),		IF(a.anc_visit_51_v2 !='',CONCAT(a.anc_visit_51_v2,', '),''),		IF(a.anc_visit_51_v3 !='',CONCAT(a.anc_visit_51_v3,', '),''),		IF(a.anc_visit_51_v4 !='',CONCAT(a.anc_visit_51_v4,', '),'')		) AS 'Medications which were prescribed during a visit',                 CONCAT(  (IF(a.52a !='',CONCAT(a.52a,', '),'')), (IF(a.52b !='',CONCAT(a.52b,', '),'')), (IF(a.52c !='',CONCAT(a.52c,', '),'')), (IF(a.52d !='',CONCAT(a.52d,', '),''))) AS 'High risk factor related to current pregnancy', (CASE WHEN tt_1='1' THEN 'Yes' WHEN tt_1='2' THEN 'No' END)   AS 'Tetenus Toxin 1',    tt_1_date AS 'Date of Tetenus Toxin 1',    (CASE WHEN tt_2='1' THEN 'Yes' WHEN tt_2='2' THEN 'No' END) AS 'Tetenus Toxin 2',    tt_2_date AS 'Date of Tetenus Toxin 2',    end_time AS 'End Time',    sra_name AS 'SRA Name' FROM view_anc as a            left join studies as b on b.pw_id=SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) where SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) in (select pw_id from form_crf_3a) and a.DSSID LIKE '%" + txtdssid.Text + "%'  and (str_to_date(a.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))     order by b.study_code,STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y')", con);
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
                    cmd = new MySqlCommand("SELECT a.anc_form_id AS 'anc_form_id',    a.anc_visit_id AS 'anc_visit_id',   a.assis_id AS 'assis_id',b.study_code,   a.date_of_attempt AS 'Date of Visit',    time_of_attempt AS 'Time of Visit',   woman_nm AS 'Woman Name',   husband_nm AS 'Husband Name',    dssid AS 'dssid',    pw_age AS 'Age of woman',    q50_next_visit_dt AS 'Next Appointment',    pw_hb_occp AS 'Husband occupation',    pw_marriage_year AS 'Year of marriage (Years)',    pw_marriage_months AS 'Year of marriage (Months)',    (CASE WHEN anc_form_8='1' THEN 'Yes'	WHEN anc_form_8='2' THEN 'No' END) AS 'Is this first pregnancy',    anc_form_9 AS 'Gravida',    anc_form_10 AS 'Alive births in the past',    anc_form_11 AS 'Stillbirths in the past',    anc_form_12 AS 'Miscarriage/Abortions in the past',    total_past_rec AS 'Past obstetric history (Alive birth + Stillbirth + Miscarriage/Abortions)', '-' AS 'Past Medical History',    (CASE WHEN anc_form_14 LIKE '1%' THEN 'Yes' WHEN anc_form_14='2' THEN 'No' END) AS 'PW has/had TB',    (CASE WHEN anc_form_15 LIKE '1%' THEN 'Yes' WHEN anc_form_15='2' THEN 'No' END) AS 'PW has/had Rheumatic fever',    (CASE WHEN anc_form_16 LIKE '1%' THEN 'Yes' WHEN anc_form_16='2' THEN 'No' END) AS 'PW has/had Kidney disease',    (CASE WHEN anc_form_17 LIKE '1%' THEN 'Yes' WHEN anc_form_17='2' THEN 'No' END) AS 'PW has/had Epilepsy',    (CASE WHEN anc_form_18 LIKE '1%' THEN 'Yes' WHEN anc_form_18='2' THEN 'No' END) AS 'PW has/had Diabetes Mellitus',    (CASE WHEN anc_form_19 LIKE '1%' THEN 'Yes' WHEN anc_form_19='2' THEN 'No' END) AS 'PW has/had Thalassemia',    (CASE WHEN anc_form_20 LIKE '1%' THEN 'Yes' WHEN anc_form_20='2' THEN 'No' END) AS 'PW has/had Mental illness',    (CASE WHEN anc_form_21 LIKE '1%' THEN 'Yes' WHEN anc_form_21='2' THEN 'No' END) AS 'PW has/had Respiratory disease',    (CASE WHEN anc_form_22 LIKE '1%' THEN 'Yes' WHEN anc_form_22='2' THEN 'No' END) AS 'PW has/had Rubella/Torch',    (CASE WHEN anc_form_23 LIKE '1%' THEN 'Yes' WHEN anc_form_23='2' THEN 'No' END) AS 'PW has/had Congenital abnormalities',    (CASE WHEN anc_form_24 LIKE '1%' THEN 'Yes' WHEN anc_form_24='2' THEN 'No' END) AS 'PW has/had a blood transfusion',    (CASE WHEN anc_form_25 LIKE '1%' THEN 'Yes' WHEN anc_form_25='2' THEN 'No' END) AS 'PW has/had subfertility',    (CASE WHEN anc_form_26 LIKE '1%' THEN 'Yes' WHEN anc_form_26='2' THEN 'No' END) AS 'PW has/had Hepatitis',    (CASE WHEN anc_form_27 LIKE '1%' THEN 'Yes' WHEN anc_form_27='2' THEN 'No' END) AS 'PW has/had hypertension',    (CASE WHEN anc_form_28 LIKE '1%' THEN 'Yes' WHEN anc_form_28='2' THEN 'No' END) AS 'PW has/had road traffic accident',    (CASE WHEN anc_form_29 LIKE '1%' THEN 'Yes' WHEN anc_form_29='2' THEN 'No' END) AS 'PW has/had operation/s',    (CASE WHEN anc_form_30 LIKE '1%' THEN 'Yes' WHEN anc_form_30='2' THEN 'No' END) AS 'PW has/had allergies or drug sensitivity',    (CASE WHEN anc_form_31 LIKE '1%' THEN 'Yes' WHEN anc_form_31='2' THEN 'No' END) AS 'Family history of TB ',    (CASE WHEN anc_form_32 LIKE '1%' THEN 'Yes' WHEN anc_form_32='2' THEN 'No' END) AS 'Family history of diabetes mellitus',    (CASE WHEN anc_form_33 LIKE '1%' THEN 'Yes' WHEN anc_form_33='2' THEN 'No' END) AS 'Family history of hypertension ',    (CASE WHEN anc_form_34 LIKE '1%' THEN 'Yes' WHEN anc_form_34='2' THEN 'No' END) AS 'Family history of twins',    (CASE WHEN anc_form_35 LIKE '1%' THEN 'Yes' WHEN anc_form_35='2' THEN 'No' END) AS 'Family history of congenital abnormalities',    (CASE WHEN anc_form_36 LIKE '1%' THEN 'Yes' WHEN anc_form_36='2' THEN 'No' END) AS 'Family history of thalassemia',    '-' AS 'Current Condition', (CASE WHEN anc_form_37 LIKE '1%' THEN 'Yes' WHEN anc_form_37 LIKE '2%' THEN 'No' END) AS 'General condition stable',    (CASE WHEN anc_form_38 LIKE '1%' THEN 'Yes' WHEN anc_form_38 LIKE '2%' THEN 'No' END) AS 'Chest clear',    (CASE WHEN anc_form_39 LIKE '1%' THEN 'Yes' WHEN anc_form_39 LIKE '2%' THEN 'No' END) AS 'Abdomen soft',    (CASE WHEN anc_form_40 LIKE '1%' THEN 'Yes' WHEN anc_form_40 LIKE '2%' THEN 'No' END) AS 'Breast examination normal',    (CASE WHEN anc_form_41 LIKE '1%' THEN 'Yes, have cardiac issue' WHEN anc_form_41 LIKE '2%' THEN 'No active disease' END) AS 'Heart disease',    anc_form_42 AS 'LMP',    anc_form_43 AS 'EDD',    (CASE WHEN anc_form_44='1' THEN 'Yes' WHEN anc_form_44='2' THEN 'No' END) AS 'Menstrual cycle regular?',    anc_form_45 AS 'Maternal height',    CONCAT(  (IF(a.anc_form_46a_1 !='',CONCAT(a.anc_form_46a_1,', '),'')), (IF(a.anc_form_46a_2 !='',CONCAT(a.anc_form_46a_2,', '),'')), (IF(a.anc_form_46a_3 !='',CONCAT(a.anc_form_46a_3,', '),'')), (IF(a.anc_form_46a_4 !='',CONCAT(a.anc_form_46a_4,', '),''))) AS 'High risk factor related to past pregnancy', (CASE WHEN anc_visit_47='1' THEN 'Yes' WHEN anc_visit_47='2' THEN 'No' END) AS 'Do you want to add lab report?',    anc_visit_48 AS 'Please write laboratory report serial number',    anc_visit_49 AS 'Write key lab report findings here',    q50_sbp AS 'Systolic BP',    q50_dbp AS 'Diastolic BP',    q50_wt AS 'Weight of PW',    q50_wop AS 'Weeks of pregnancy',    q50_uts AS 'Uterine size',    (CASE WHEN q50_pres='1' THEN 'Cephalic' WHEN q50_pres='2' THEN 'Breech'	WHEN q50_pres='3' THEN 'Shoulder'	WHEN q50_pres='4' THEN 'Not determined yet'	WHEN q50_pres='5' THEN 'Not recorded' END) AS 'Presentation',    (CASE WHEN q50_fhs='1' THEN 'Yes' WHEN q50_fhs='2' THEN 'No' END)  AS 'FHS',    (CASE WHEN q50_odm='1' THEN 'Yes' WHEN q50_odm='2' THEN 'No' END)  AS 'Oedema',    (CASE WHEN q50_anm='1' THEN 'Yes' WHEN q50_anm='2' THEN 'No' END)  AS 'Anemia',    (CASE WHEN q50_rcomp='1' THEN 'JPMC' WHEN q50_rcomp='2' THEN 'Civil' WHEN q50_rcomp='3' THEN 'AKU Kharadar' WHEN q50_rcomp='4' THEN 'AKU' WHEN q50_rcomp='5' THEN 'Attiya' WHEN q50_rcomp='9' THEN 'Not Required' END)   AS 'Is PW also registered at any of these facilities for pregnancy related complication',    q50_rks AS 'Remarks',    CONCAT(IF(a.anc_visit_51_a=1,'Venofer dose, ',''), IF(a.anc_visit_51_b=2,'Augmentin, ',''), IF(a.anc_visit_51_c=3,'Flagyl, ',''), IF(a.anc_visit_51_d=4,'Diclofenac tab, ',''), IF(a.anc_visit_51_e=5,'Diclofenac inj, ',''), IF(a.anc_visit_51_f=6,'Nospa, ',''), IF(a.anc_visit_51_g=7,'Citrosoda, ',''), IF(a.anc_visit_51_h=8,'Douphaston, ',''), IF(a.anc_visit_51_i=9,'Lialac syrup, ',''), IF(a.anc_visit_51_j=10,'Adicos syrup, ',''), IF(a.anc_visit_51_k=11,'Canestin vaginal cream, ',''), IF(a.anc_visit_51_l=12,'Methyldopa, ',''), IF(a.anc_visit_51_m=13,'Captorpil, ',''), IF(a.anc_visit_51_n=14,'Ascard,',''), IF(a.anc_visit_51_o=15,'Vermox, ',''), IF(a.anc_visit_51_p=16,'Ferrous suplphate, ',''), IF(a.anc_visit_51_q=17,'Folic acid, ',''), IF(a.anc_visit_51_r=18,'Paracetamol, ',''), IF(a.anc_visit_51_s=19,'Ponstan, ',''), IF(a.anc_visit_51_t=20,'Softin, ',''), IF(a.anc_visit_51_u=21,'Tricel, ',''), IF(a.anc_visit_51_w!='','Buscopan, ','')  , IF(a.anc_visit_51_x!='','Canestin topical cream, ','') , IF(a.anc_visit_51_y!='','Hydrozol cream, ','') , IF(a.anc_visit_51_z!='','Synto injection, ','') , IF(a.anc_visit_51_aa!='','S T mom tablet, ','') , IF(a.anc_visit_51_ab!='','ORS, ','') , IF(a.anc_visit_51_ac!='','NS 1000 ml, ','') , IF(a.anc_visit_51_ad!='','LR 1000 ml, ',''), 		IF(a.anc_visit_51_v !='',CONCAT(a.anc_visit_51_v,', '),''), 		IF(a.anc_visit_51_v1 !='',CONCAT(a.anc_visit_51_v1,', '),''),		IF(a.anc_visit_51_v2 !='',CONCAT(a.anc_visit_51_v2,', '),''),		IF(a.anc_visit_51_v3 !='',CONCAT(a.anc_visit_51_v3,', '),''),		IF(a.anc_visit_51_v4 !='',CONCAT(a.anc_visit_51_v4,', '),'')		) AS 'Medications which were prescribed during a visit',                 CONCAT(  (IF(a.52a !='',CONCAT(a.52a,', '),'')), (IF(a.52b !='',CONCAT(a.52b,', '),'')), (IF(a.52c !='',CONCAT(a.52c,', '),'')), (IF(a.52d !='',CONCAT(a.52d,', '),''))) AS 'High risk factor related to current pregnancy', (CASE WHEN tt_1='1' THEN 'Yes' WHEN tt_1='2' THEN 'No' END)   AS 'Tetenus Toxin 1',    tt_1_date AS 'Date of Tetenus Toxin 1',    (CASE WHEN tt_2='1' THEN 'Yes' WHEN tt_2='2' THEN 'No' END) AS 'Tetenus Toxin 2',    tt_2_date AS 'Date of Tetenus Toxin 2',    end_time AS 'End Time',    sra_name AS 'SRA Name' FROM view_anc as a             left join studies as b on b.pw_id=SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) where SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) in (select pw_id from form_crf_3a) and a.DSSID LIKE '%" + txtdssid.Text + "%'     order by b.study_code,STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y')", con);
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
                    cmd = new MySqlCommand("SELECT a.anc_form_id AS 'anc_form_id',    a.anc_visit_id AS 'anc_visit_id',   a.assis_id AS 'assis_id',b.study_code,   a.date_of_attempt AS 'Date of Visit',    time_of_attempt AS 'Time of Visit',   woman_nm AS 'Woman Name',   husband_nm AS 'Husband Name',    dssid AS 'dssid',    pw_age AS 'Age of woman',    q50_next_visit_dt AS 'Next Appointment',    pw_hb_occp AS 'Husband occupation',    pw_marriage_year AS 'Year of marriage (Years)',    pw_marriage_months AS 'Year of marriage (Months)',    (CASE WHEN anc_form_8='1' THEN 'Yes'	WHEN anc_form_8='2' THEN 'No' END) AS 'Is this first pregnancy',    anc_form_9 AS 'Gravida',    anc_form_10 AS 'Alive births in the past',    anc_form_11 AS 'Stillbirths in the past',    anc_form_12 AS 'Miscarriage/Abortions in the past',    total_past_rec AS 'Past obstetric history (Alive birth + Stillbirth + Miscarriage/Abortions)', '-' AS 'Past Medical History',    (CASE WHEN anc_form_14 LIKE '1%' THEN 'Yes' WHEN anc_form_14='2' THEN 'No' END) AS 'PW has/had TB',    (CASE WHEN anc_form_15 LIKE '1%' THEN 'Yes' WHEN anc_form_15='2' THEN 'No' END) AS 'PW has/had Rheumatic fever',    (CASE WHEN anc_form_16 LIKE '1%' THEN 'Yes' WHEN anc_form_16='2' THEN 'No' END) AS 'PW has/had Kidney disease',    (CASE WHEN anc_form_17 LIKE '1%' THEN 'Yes' WHEN anc_form_17='2' THEN 'No' END) AS 'PW has/had Epilepsy',    (CASE WHEN anc_form_18 LIKE '1%' THEN 'Yes' WHEN anc_form_18='2' THEN 'No' END) AS 'PW has/had Diabetes Mellitus',    (CASE WHEN anc_form_19 LIKE '1%' THEN 'Yes' WHEN anc_form_19='2' THEN 'No' END) AS 'PW has/had Thalassemia',    (CASE WHEN anc_form_20 LIKE '1%' THEN 'Yes' WHEN anc_form_20='2' THEN 'No' END) AS 'PW has/had Mental illness',    (CASE WHEN anc_form_21 LIKE '1%' THEN 'Yes' WHEN anc_form_21='2' THEN 'No' END) AS 'PW has/had Respiratory disease',    (CASE WHEN anc_form_22 LIKE '1%' THEN 'Yes' WHEN anc_form_22='2' THEN 'No' END) AS 'PW has/had Rubella/Torch',    (CASE WHEN anc_form_23 LIKE '1%' THEN 'Yes' WHEN anc_form_23='2' THEN 'No' END) AS 'PW has/had Congenital abnormalities',    (CASE WHEN anc_form_24 LIKE '1%' THEN 'Yes' WHEN anc_form_24='2' THEN 'No' END) AS 'PW has/had a blood transfusion',    (CASE WHEN anc_form_25 LIKE '1%' THEN 'Yes' WHEN anc_form_25='2' THEN 'No' END) AS 'PW has/had subfertility',    (CASE WHEN anc_form_26 LIKE '1%' THEN 'Yes' WHEN anc_form_26='2' THEN 'No' END) AS 'PW has/had Hepatitis',    (CASE WHEN anc_form_27 LIKE '1%' THEN 'Yes' WHEN anc_form_27='2' THEN 'No' END) AS 'PW has/had hypertension',    (CASE WHEN anc_form_28 LIKE '1%' THEN 'Yes' WHEN anc_form_28='2' THEN 'No' END) AS 'PW has/had road traffic accident',    (CASE WHEN anc_form_29 LIKE '1%' THEN 'Yes' WHEN anc_form_29='2' THEN 'No' END) AS 'PW has/had operation/s',    (CASE WHEN anc_form_30 LIKE '1%' THEN 'Yes' WHEN anc_form_30='2' THEN 'No' END) AS 'PW has/had allergies or drug sensitivity',    (CASE WHEN anc_form_31 LIKE '1%' THEN 'Yes' WHEN anc_form_31='2' THEN 'No' END) AS 'Family history of TB ',    (CASE WHEN anc_form_32 LIKE '1%' THEN 'Yes' WHEN anc_form_32='2' THEN 'No' END) AS 'Family history of diabetes mellitus',    (CASE WHEN anc_form_33 LIKE '1%' THEN 'Yes' WHEN anc_form_33='2' THEN 'No' END) AS 'Family history of hypertension ',    (CASE WHEN anc_form_34 LIKE '1%' THEN 'Yes' WHEN anc_form_34='2' THEN 'No' END) AS 'Family history of twins',    (CASE WHEN anc_form_35 LIKE '1%' THEN 'Yes' WHEN anc_form_35='2' THEN 'No' END) AS 'Family history of congenital abnormalities',    (CASE WHEN anc_form_36 LIKE '1%' THEN 'Yes' WHEN anc_form_36='2' THEN 'No' END) AS 'Family history of thalassemia',    '-' AS 'Current Condition', (CASE WHEN anc_form_37 LIKE '1%' THEN 'Yes' WHEN anc_form_37 LIKE '2%' THEN 'No' END) AS 'General condition stable',    (CASE WHEN anc_form_38 LIKE '1%' THEN 'Yes' WHEN anc_form_38 LIKE '2%' THEN 'No' END) AS 'Chest clear',    (CASE WHEN anc_form_39 LIKE '1%' THEN 'Yes' WHEN anc_form_39 LIKE '2%' THEN 'No' END) AS 'Abdomen soft',    (CASE WHEN anc_form_40 LIKE '1%' THEN 'Yes' WHEN anc_form_40 LIKE '2%' THEN 'No' END) AS 'Breast examination normal',    (CASE WHEN anc_form_41 LIKE '1%' THEN 'Yes, have cardiac issue' WHEN anc_form_41 LIKE '2%' THEN 'No active disease' END) AS 'Heart disease',    anc_form_42 AS 'LMP',    anc_form_43 AS 'EDD',    (CASE WHEN anc_form_44='1' THEN 'Yes' WHEN anc_form_44='2' THEN 'No' END) AS 'Menstrual cycle regular?',    anc_form_45 AS 'Maternal height',    CONCAT(  (IF(a.anc_form_46a_1 !='',CONCAT(a.anc_form_46a_1,', '),'')), (IF(a.anc_form_46a_2 !='',CONCAT(a.anc_form_46a_2,', '),'')), (IF(a.anc_form_46a_3 !='',CONCAT(a.anc_form_46a_3,', '),'')), (IF(a.anc_form_46a_4 !='',CONCAT(a.anc_form_46a_4,', '),''))) AS 'High risk factor related to past pregnancy', (CASE WHEN anc_visit_47='1' THEN 'Yes' WHEN anc_visit_47='2' THEN 'No' END) AS 'Do you want to add lab report?',    anc_visit_48 AS 'Please write laboratory report serial number',    anc_visit_49 AS 'Write key lab report findings here',    q50_sbp AS 'Systolic BP',    q50_dbp AS 'Diastolic BP',    q50_wt AS 'Weight of PW',    q50_wop AS 'Weeks of pregnancy',    q50_uts AS 'Uterine size',    (CASE WHEN q50_pres='1' THEN 'Cephalic' WHEN q50_pres='2' THEN 'Breech'	WHEN q50_pres='3' THEN 'Shoulder'	WHEN q50_pres='4' THEN 'Not determined yet'	WHEN q50_pres='5' THEN 'Not recorded' END) AS 'Presentation',    (CASE WHEN q50_fhs='1' THEN 'Yes' WHEN q50_fhs='2' THEN 'No' END)  AS 'FHS',    (CASE WHEN q50_odm='1' THEN 'Yes' WHEN q50_odm='2' THEN 'No' END)  AS 'Oedema',    (CASE WHEN q50_anm='1' THEN 'Yes' WHEN q50_anm='2' THEN 'No' END)  AS 'Anemia',    (CASE WHEN q50_rcomp='1' THEN 'JPMC' WHEN q50_rcomp='2' THEN 'Civil' WHEN q50_rcomp='3' THEN 'AKU Kharadar' WHEN q50_rcomp='4' THEN 'AKU' WHEN q50_rcomp='5' THEN 'Attiya' WHEN q50_rcomp='9' THEN 'Not Required' END)   AS 'Is PW also registered at any of these facilities for pregnancy related complication',    q50_rks AS 'Remarks',    CONCAT(IF(a.anc_visit_51_a=1,'Venofer dose, ',''), IF(a.anc_visit_51_b=2,'Augmentin, ',''), IF(a.anc_visit_51_c=3,'Flagyl, ',''), IF(a.anc_visit_51_d=4,'Diclofenac tab, ',''), IF(a.anc_visit_51_e=5,'Diclofenac inj, ',''), IF(a.anc_visit_51_f=6,'Nospa, ',''), IF(a.anc_visit_51_g=7,'Citrosoda, ',''), IF(a.anc_visit_51_h=8,'Douphaston, ',''), IF(a.anc_visit_51_i=9,'Lialac syrup, ',''), IF(a.anc_visit_51_j=10,'Adicos syrup, ',''), IF(a.anc_visit_51_k=11,'Canestin vaginal cream, ',''), IF(a.anc_visit_51_l=12,'Methyldopa, ',''), IF(a.anc_visit_51_m=13,'Captorpil, ',''), IF(a.anc_visit_51_n=14,'Ascard,',''), IF(a.anc_visit_51_o=15,'Vermox, ',''), IF(a.anc_visit_51_p=16,'Ferrous suplphate, ',''), IF(a.anc_visit_51_q=17,'Folic acid, ',''), IF(a.anc_visit_51_r=18,'Paracetamol, ',''), IF(a.anc_visit_51_s=19,'Ponstan, ',''), IF(a.anc_visit_51_t=20,'Softin, ',''), IF(a.anc_visit_51_u=21,'Tricel, ',''), IF(a.anc_visit_51_w!='','Buscopan, ','')  , IF(a.anc_visit_51_x!='','Canestin topical cream, ','') , IF(a.anc_visit_51_y!='','Hydrozol cream, ','') , IF(a.anc_visit_51_z!='','Synto injection, ','') , IF(a.anc_visit_51_aa!='','S T mom tablet, ','') , IF(a.anc_visit_51_ab!='','ORS, ','') , IF(a.anc_visit_51_ac!='','NS 1000 ml, ','') , IF(a.anc_visit_51_ad!='','LR 1000 ml, ',''), 		IF(a.anc_visit_51_v !='',CONCAT(a.anc_visit_51_v,', '),''), 		IF(a.anc_visit_51_v1 !='',CONCAT(a.anc_visit_51_v1,', '),''),		IF(a.anc_visit_51_v2 !='',CONCAT(a.anc_visit_51_v2,', '),''),		IF(a.anc_visit_51_v3 !='',CONCAT(a.anc_visit_51_v3,', '),''),		IF(a.anc_visit_51_v4 !='',CONCAT(a.anc_visit_51_v4,', '),'')		) AS 'Medications which were prescribed during a visit',                 CONCAT(  (IF(a.52a !='',CONCAT(a.52a,', '),'')), (IF(a.52b !='',CONCAT(a.52b,', '),'')), (IF(a.52c !='',CONCAT(a.52c,', '),'')), (IF(a.52d !='',CONCAT(a.52d,', '),''))) AS 'High risk factor related to current pregnancy', (CASE WHEN tt_1='1' THEN 'Yes' WHEN tt_1='2' THEN 'No' END)   AS 'Tetenus Toxin 1',    tt_1_date AS 'Date of Tetenus Toxin 1',    (CASE WHEN tt_2='1' THEN 'Yes' WHEN tt_2='2' THEN 'No' END) AS 'Tetenus Toxin 2',    tt_2_date AS 'Date of Tetenus Toxin 2',    end_time AS 'End Time',    sra_name AS 'SRA Name' FROM view_anc as a            left join studies as b on b.pw_id=SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) where SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) in (select pw_id from form_crf_3a) and a.DSSID LIKE '%" + txtdssid.Text + "%'  and (str_to_date(a.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))     order by b.study_code,STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y')", con);
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
                    cmd = new MySqlCommand("SELECT a.anc_form_id AS 'anc_form_id',    a.anc_visit_id AS 'anc_visit_id',   a.assis_id AS 'assis_id',b.study_code,   a.date_of_attempt AS 'Date of Visit',    time_of_attempt AS 'Time of Visit',   woman_nm AS 'Woman Name',   husband_nm AS 'Husband Name',    dssid AS 'dssid',    pw_age AS 'Age of woman',    q50_next_visit_dt AS 'Next Appointment',    pw_hb_occp AS 'Husband occupation',    pw_marriage_year AS 'Year of marriage (Years)',    pw_marriage_months AS 'Year of marriage (Months)',    (CASE WHEN anc_form_8='1' THEN 'Yes'	WHEN anc_form_8='2' THEN 'No' END) AS 'Is this first pregnancy',    anc_form_9 AS 'Gravida',    anc_form_10 AS 'Alive births in the past',    anc_form_11 AS 'Stillbirths in the past',    anc_form_12 AS 'Miscarriage/Abortions in the past',    total_past_rec AS 'Past obstetric history (Alive birth + Stillbirth + Miscarriage/Abortions)', '-' AS 'Past Medical History',    (CASE WHEN anc_form_14 LIKE '1%' THEN 'Yes' WHEN anc_form_14='2' THEN 'No' END) AS 'PW has/had TB',    (CASE WHEN anc_form_15 LIKE '1%' THEN 'Yes' WHEN anc_form_15='2' THEN 'No' END) AS 'PW has/had Rheumatic fever',    (CASE WHEN anc_form_16 LIKE '1%' THEN 'Yes' WHEN anc_form_16='2' THEN 'No' END) AS 'PW has/had Kidney disease',    (CASE WHEN anc_form_17 LIKE '1%' THEN 'Yes' WHEN anc_form_17='2' THEN 'No' END) AS 'PW has/had Epilepsy',    (CASE WHEN anc_form_18 LIKE '1%' THEN 'Yes' WHEN anc_form_18='2' THEN 'No' END) AS 'PW has/had Diabetes Mellitus',    (CASE WHEN anc_form_19 LIKE '1%' THEN 'Yes' WHEN anc_form_19='2' THEN 'No' END) AS 'PW has/had Thalassemia',    (CASE WHEN anc_form_20 LIKE '1%' THEN 'Yes' WHEN anc_form_20='2' THEN 'No' END) AS 'PW has/had Mental illness',    (CASE WHEN anc_form_21 LIKE '1%' THEN 'Yes' WHEN anc_form_21='2' THEN 'No' END) AS 'PW has/had Respiratory disease',    (CASE WHEN anc_form_22 LIKE '1%' THEN 'Yes' WHEN anc_form_22='2' THEN 'No' END) AS 'PW has/had Rubella/Torch',    (CASE WHEN anc_form_23 LIKE '1%' THEN 'Yes' WHEN anc_form_23='2' THEN 'No' END) AS 'PW has/had Congenital abnormalities',    (CASE WHEN anc_form_24 LIKE '1%' THEN 'Yes' WHEN anc_form_24='2' THEN 'No' END) AS 'PW has/had a blood transfusion',    (CASE WHEN anc_form_25 LIKE '1%' THEN 'Yes' WHEN anc_form_25='2' THEN 'No' END) AS 'PW has/had subfertility',    (CASE WHEN anc_form_26 LIKE '1%' THEN 'Yes' WHEN anc_form_26='2' THEN 'No' END) AS 'PW has/had Hepatitis',    (CASE WHEN anc_form_27 LIKE '1%' THEN 'Yes' WHEN anc_form_27='2' THEN 'No' END) AS 'PW has/had hypertension',    (CASE WHEN anc_form_28 LIKE '1%' THEN 'Yes' WHEN anc_form_28='2' THEN 'No' END) AS 'PW has/had road traffic accident',    (CASE WHEN anc_form_29 LIKE '1%' THEN 'Yes' WHEN anc_form_29='2' THEN 'No' END) AS 'PW has/had operation/s',    (CASE WHEN anc_form_30 LIKE '1%' THEN 'Yes' WHEN anc_form_30='2' THEN 'No' END) AS 'PW has/had allergies or drug sensitivity',    (CASE WHEN anc_form_31 LIKE '1%' THEN 'Yes' WHEN anc_form_31='2' THEN 'No' END) AS 'Family history of TB ',    (CASE WHEN anc_form_32 LIKE '1%' THEN 'Yes' WHEN anc_form_32='2' THEN 'No' END) AS 'Family history of diabetes mellitus',    (CASE WHEN anc_form_33 LIKE '1%' THEN 'Yes' WHEN anc_form_33='2' THEN 'No' END) AS 'Family history of hypertension ',    (CASE WHEN anc_form_34 LIKE '1%' THEN 'Yes' WHEN anc_form_34='2' THEN 'No' END) AS 'Family history of twins',    (CASE WHEN anc_form_35 LIKE '1%' THEN 'Yes' WHEN anc_form_35='2' THEN 'No' END) AS 'Family history of congenital abnormalities',    (CASE WHEN anc_form_36 LIKE '1%' THEN 'Yes' WHEN anc_form_36='2' THEN 'No' END) AS 'Family history of thalassemia',    '-' AS 'Current Condition', (CASE WHEN anc_form_37 LIKE '1%' THEN 'Yes' WHEN anc_form_37 LIKE '2%' THEN 'No' END) AS 'General condition stable',    (CASE WHEN anc_form_38 LIKE '1%' THEN 'Yes' WHEN anc_form_38 LIKE '2%' THEN 'No' END) AS 'Chest clear',    (CASE WHEN anc_form_39 LIKE '1%' THEN 'Yes' WHEN anc_form_39 LIKE '2%' THEN 'No' END) AS 'Abdomen soft',    (CASE WHEN anc_form_40 LIKE '1%' THEN 'Yes' WHEN anc_form_40 LIKE '2%' THEN 'No' END) AS 'Breast examination normal',    (CASE WHEN anc_form_41 LIKE '1%' THEN 'Yes, have cardiac issue' WHEN anc_form_41 LIKE '2%' THEN 'No active disease' END) AS 'Heart disease',    anc_form_42 AS 'LMP',    anc_form_43 AS 'EDD',    (CASE WHEN anc_form_44='1' THEN 'Yes' WHEN anc_form_44='2' THEN 'No' END) AS 'Menstrual cycle regular?',    anc_form_45 AS 'Maternal height',    CONCAT(  (IF(a.anc_form_46a_1 !='',CONCAT(a.anc_form_46a_1,', '),'')), (IF(a.anc_form_46a_2 !='',CONCAT(a.anc_form_46a_2,', '),'')), (IF(a.anc_form_46a_3 !='',CONCAT(a.anc_form_46a_3,', '),'')), (IF(a.anc_form_46a_4 !='',CONCAT(a.anc_form_46a_4,', '),''))) AS 'High risk factor related to past pregnancy', (CASE WHEN anc_visit_47='1' THEN 'Yes' WHEN anc_visit_47='2' THEN 'No' END) AS 'Do you want to add lab report?',    anc_visit_48 AS 'Please write laboratory report serial number',    anc_visit_49 AS 'Write key lab report findings here',    q50_sbp AS 'Systolic BP',    q50_dbp AS 'Diastolic BP',    q50_wt AS 'Weight of PW',    q50_wop AS 'Weeks of pregnancy',    q50_uts AS 'Uterine size',    (CASE WHEN q50_pres='1' THEN 'Cephalic' WHEN q50_pres='2' THEN 'Breech'	WHEN q50_pres='3' THEN 'Shoulder'	WHEN q50_pres='4' THEN 'Not determined yet'	WHEN q50_pres='5' THEN 'Not recorded' END) AS 'Presentation',    (CASE WHEN q50_fhs='1' THEN 'Yes' WHEN q50_fhs='2' THEN 'No' END)  AS 'FHS',    (CASE WHEN q50_odm='1' THEN 'Yes' WHEN q50_odm='2' THEN 'No' END)  AS 'Oedema',    (CASE WHEN q50_anm='1' THEN 'Yes' WHEN q50_anm='2' THEN 'No' END)  AS 'Anemia',    (CASE WHEN q50_rcomp='1' THEN 'JPMC' WHEN q50_rcomp='2' THEN 'Civil' WHEN q50_rcomp='3' THEN 'AKU Kharadar' WHEN q50_rcomp='4' THEN 'AKU' WHEN q50_rcomp='5' THEN 'Attiya' WHEN q50_rcomp='9' THEN 'Not Required' END)   AS 'Is PW also registered at any of these facilities for pregnancy related complication',    q50_rks AS 'Remarks',    CONCAT(IF(a.anc_visit_51_a=1,'Venofer dose, ',''), IF(a.anc_visit_51_b=2,'Augmentin, ',''), IF(a.anc_visit_51_c=3,'Flagyl, ',''), IF(a.anc_visit_51_d=4,'Diclofenac tab, ',''), IF(a.anc_visit_51_e=5,'Diclofenac inj, ',''), IF(a.anc_visit_51_f=6,'Nospa, ',''), IF(a.anc_visit_51_g=7,'Citrosoda, ',''), IF(a.anc_visit_51_h=8,'Douphaston, ',''), IF(a.anc_visit_51_i=9,'Lialac syrup, ',''), IF(a.anc_visit_51_j=10,'Adicos syrup, ',''), IF(a.anc_visit_51_k=11,'Canestin vaginal cream, ',''), IF(a.anc_visit_51_l=12,'Methyldopa, ',''), IF(a.anc_visit_51_m=13,'Captorpil, ',''), IF(a.anc_visit_51_n=14,'Ascard,',''), IF(a.anc_visit_51_o=15,'Vermox, ',''), IF(a.anc_visit_51_p=16,'Ferrous suplphate, ',''), IF(a.anc_visit_51_q=17,'Folic acid, ',''), IF(a.anc_visit_51_r=18,'Paracetamol, ',''), IF(a.anc_visit_51_s=19,'Ponstan, ',''), IF(a.anc_visit_51_t=20,'Softin, ',''), IF(a.anc_visit_51_u=21,'Tricel, ',''), IF(a.anc_visit_51_w!='','Buscopan, ','')  , IF(a.anc_visit_51_x!='','Canestin topical cream, ','') , IF(a.anc_visit_51_y!='','Hydrozol cream, ','') , IF(a.anc_visit_51_z!='','Synto injection, ','') , IF(a.anc_visit_51_aa!='','S T mom tablet, ','') , IF(a.anc_visit_51_ab!='','ORS, ','') , IF(a.anc_visit_51_ac!='','NS 1000 ml, ','') , IF(a.anc_visit_51_ad!='','LR 1000 ml, ',''), 		IF(a.anc_visit_51_v !='',CONCAT(a.anc_visit_51_v,', '),''), 		IF(a.anc_visit_51_v1 !='',CONCAT(a.anc_visit_51_v1,', '),''),		IF(a.anc_visit_51_v2 !='',CONCAT(a.anc_visit_51_v2,', '),''),		IF(a.anc_visit_51_v3 !='',CONCAT(a.anc_visit_51_v3,', '),''),		IF(a.anc_visit_51_v4 !='',CONCAT(a.anc_visit_51_v4,', '),'')		) AS 'Medications which were prescribed during a visit',                 CONCAT(  (IF(a.52a !='',CONCAT(a.52a,', '),'')), (IF(a.52b !='',CONCAT(a.52b,', '),'')), (IF(a.52c !='',CONCAT(a.52c,', '),'')), (IF(a.52d !='',CONCAT(a.52d,', '),''))) AS 'High risk factor related to current pregnancy', (CASE WHEN tt_1='1' THEN 'Yes' WHEN tt_1='2' THEN 'No' END)   AS 'Tetenus Toxin 1',    tt_1_date AS 'Date of Tetenus Toxin 1',    (CASE WHEN tt_2='1' THEN 'Yes' WHEN tt_2='2' THEN 'No' END) AS 'Tetenus Toxin 2',    tt_2_date AS 'Date of Tetenus Toxin 2',    end_time AS 'End Time',    sra_name AS 'SRA Name' FROM view_anc as a             left join studies as b on b.pw_id=SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) where SUBSTRING_INDEX(SUBSTRING_INDEX(a.assis_id, ':', 3), ':', -1) in (select pw_id from form_crf_3a) and a.DSSID LIKE '%" + txtdssid.Text + "%'     order by b.study_code,STR_TO_DATE(a.date_of_attempt,'%d-%m-%Y')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=ANC Detail-Enrolled (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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