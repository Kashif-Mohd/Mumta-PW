using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace maamta_pw
{
    public partial class dashboardCompANC : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashWorkerPerformance";

                txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");

                txtCalndrDate.Attributes.Add("readonly", "readonly");
                txtCalndrDate1.Attributes.Add("readonly", "readonly");

                LoadChartUserWise();
            }

        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadChartUserWise();
        
        }



        private void LoadChartUserWise()
        {
            // CRF4 and CRF5a 
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.DataBindCrossTable(GetDataItemCompANC().DefaultView, "sra_name", "CRFs", "total", "Label=total");
            Chart1.DataBind();


            // CRF5c and CRF6a,6b 
            Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
            Chart2.DataBindCrossTable(GetDataItemOutcomeAnthro().DefaultView, "sra_name", "CRFs", "total", "Label=total");
            Chart2.DataBind();

            
            // CRF4b
            Chart3.ChartAreas["ChartArea3"].AxisX.MajorGrid.Enabled = false;
            Chart3.DataBindCrossTable(GetDataItem_Choline_Nicotinamide().DefaultView, "sra_name", "CRFs", "total", "Label=total");
            Chart3.DataBind();
        }






        private DataTable GetDataItemCompANC()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT a.`sra_name`,'crf4_visits' AS CRFs, (SELECT COUNT(*) FROM form_crf_4 AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf4_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')		 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  a.`team_title_id`='4' AND a.`status`=1  UNION SELECT a.`sra_name`,'crf4_complete' AS CRFs, (SELECT COUNT(*) FROM form_crf_4 AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf4_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')	AND xx.`pw_crf4_18`='1'	 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  a.`team_title_id`='4' AND a.`status`=1  UNION SELECT a.`sra_name`,'crf5a_visits' AS CRFs, (SELECT COUNT(*) FROM form_crf_5a AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf5a_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')		 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  a.`team_title_id`='4' AND a.`status`=1 UNION SELECT a.`sra_name`,'crf5a_complete' AS CRFs, (SELECT COUNT(*) FROM form_crf_5a AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf5a_02, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')	AND xx.`pw_crf5a_18`='1'	 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  a.`team_title_id`='4' AND a.`status`=1", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }





        private DataTable GetDataItemOutcomeAnthro()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT a.`sra_name`,'crf5c_visits' AS CRFs, (SELECT COUNT(*) FROM form_crf_5c AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf5c_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')		 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  (a.`team_title_id`='5' OR a.`team_title_id`='7') AND a.`status`=1   UNION SELECT a.`sra_name`,'crf5c_complete' AS CRFs, (SELECT COUNT(*) FROM form_crf_5c AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf5c_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')	 AND xx.`pw_crf5c_19`='1'	 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  (a.`team_title_id`='5' OR a.`team_title_id`='7') AND a.`status`=1   UNION SELECT a.`sra_name`,'crf6a_visits' AS CRFs, (SELECT COUNT(*) FROM form_crf_6a AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf_6a_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')		 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  (a.`team_title_id`='5' OR a.`team_title_id`='7') AND a.`status`=1   UNION SELECT a.`sra_name`,'crf6a_complete' AS CRFs, (SELECT COUNT(*) FROM form_crf_6a AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf_6a_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')	 AND xx.`pw_crf_6a_18`='1'	 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  (a.`team_title_id`='5' OR a.`team_title_id`='7') AND a.`status`=1", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }





        private DataTable GetDataItem_Choline_Nicotinamide()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT a.`sra_name`,'crf4b_visits' AS CRFs, (SELECT COUNT(*) FROM form_crf_4b AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf4b_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')		 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  a.`team_title_id`='6' AND a.`status`=1   UNION SELECT a.`sra_name`,'crf4b_complete' AS CRFs, (SELECT COUNT(*) FROM form_crf_4b AS xx LEFT JOIN team AS xy ON xx.team_id=xy.team_id WHERE a.`sra_name`=xy.sra_name AND STR_TO_DATE(xx.pw_crf4b_2, '%d-%m-%Y') BETWEEN STR_TO_DATE('" + txtCalndrDate.Text + "', '%d-%m-%Y')  AND STR_TO_DATE('" + txtCalndrDate1.Text + "', '%d-%m-%Y')	 AND xx.`pw_crf4b_14`='1'	 GROUP BY xx.team_id) AS total FROM team AS a WHERE  a.sra_name NOT LIKE '%eidul%' AND  a.`team_title_id`='6' AND a.`status`=1", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }




    }
}