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
    public partial class dashboardRandom : System.Web.UI.Page
    {


        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "DashboardRandom";



                txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");

                txtCalndrDate.Attributes.Add("readonly", "readonly");
                txtCalndrDate1.Attributes.Add("readonly", "readonly");

                TotalEnrollment();
                ShowData();
                LoadChartAllSite();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }









        private void LoadChartAllSite()
        {
            try
            {
                string query = string.Format("select concat(Date_Format(str_to_date(pw_crf_3a_2, '%d-%m-%Y'),'%b'),'-',Date_Format(str_to_date(pw_crf_3a_2, '%d-%m-%Y'),'%y')) as Year, count(*) as enrollment	   from form_crf_3a group by Year(str_to_date(pw_crf_3a_2, '%d-%m-%Y')),Month(str_to_date(pw_crf_3a_2, '%d-%m-%Y'))");
                DataTable dt = GetData(query);
                Chart2.DataSource = dt;
                Chart2.Series[0].XValueMember = "Year";
                Chart2.Series[0].YValueMembers = "enrollment";
                Chart2.Series[0].Label = "#VALY";
                Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
                Chart2.DataBind();


                //Target Line:
                StripLine targetLine = new StripLine();
                targetLine.StripWidth = 0;
                targetLine.BorderColor = ColorTranslator.FromHtml("#55efc4");
                targetLine.BorderWidth = 3;
                targetLine.BorderDashStyle = ChartDashStyle.Dash;
                targetLine.IntervalOffset = 50; // In my case I am plotting percentages.
                targetLine.Text = "Target";
                targetLine.TextOrientation = TextOrientation.Horizontal;
                targetLine.ForeColor = targetLine.BorderColor;
                Chart2.ChartAreas[0].AxisY.StripLines.Add(targetLine);
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }

        }




        //For Cumulative:
        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

            MySqlConnection con = new MySqlConnection(constr);
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
        }








        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadChartAllSite();

            if (DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
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
                MySqlCommand cmd = new MySqlCommand("select  (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	)   as 'Total Approached',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17!='1' )  as 'Incomplete',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='1' )  as 'Complete',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='1'  and a.pw_crf2_19!='' )  as 'PW died',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_25<30.5 )  as 'MUAC less than 30.5 cm',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_25>=30.5 )  as 'MUAC equal or greater than 30.5 cm',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  (a.pw_crf2_25>=30.5 or  a.pw_crf2_33='2' or  a.pw_crf2_34='2' or a.pw_crf2_35='1' or a.pw_crf2_36='1' or a.pw_crf2_37='1' or a.pw_crf2_38='1')  )  as 'Any exclusion criteria',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  (a.pw_crf2_25<30.5 and a.pw_crf2_33='1' and a.pw_crf2_34='1' and a.pw_crf2_35='2' and a.pw_crf2_36='2' and a.pw_crf2_37='2' and a.pw_crf2_38='2')  )  as 'No exclusion criteria',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_42!='1' )  as 'No exclusion criteria, but consent refused',(select  count(*) from form_crf_3a as a where STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  )  as 'Enrolled'", con);

                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 0;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            //  GridView1.Rows[GridView1.Rows.Count - 1].BackColor = System.Drawing.Color.FromName("#b2bec3");
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





        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExportReport();
            }

        }






        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }








        public void ExcelExportMessage_Report()
        {
            GridView5.Caption = "<h2/> MAAMTA PW trial <br/>   <h4> Pregnant Women (PW) screened for eligibility between 8 to 19 weeks - CRF2<br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
            GridView6.Caption = "<br/><br/>    <h4>Pregnant Women (PW) screened for eligibility between 8 to 19 weeks  - CRF2 <br/>CUMULATIVE REPORT";
            GridView8.Caption = "<br/><br/><br/><br/>    <h4>Current Randomization and Enrollments<br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
            GridView9.Caption = "<br/><br/>    <h4>Cumulative Randomization and Enrollments<br/>CUMULATIVE REPORT";
        }

        //CRF-2 Report:
        private void ExportReportdata()
        {
            //Date Wise
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select  (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	)   as 'Total Pregnant Women Approached', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='1'  and a.pw_crf2_19!='' )  as 'PW died before screening', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='6' )  as 'PW was not screened as outcome was Miscarriage/Abortion', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='4' )  as 'PW was not screened as Shifted out of DSS', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='3' )  as 'PW was not screened as Refused', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='2' )  as 'PW was not screened as not at home', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='5' )  as 'PW was died during pregnancy and baby also died inside', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='1' )  as 'PW was screened eligibility', ('') as 'Break Line', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_25<30.5 )  as 'Eligible pregnant women as MUAC less than 30.5 cm', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_25>=30.5 )  as 'Not eligible pregnant women as MUAC equal or greater than 30.5 cm', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_33='2' )  as 'PW was not permanent resident of DSS', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_34='2' )  as 'PW was not continues to stay within DSS until birth outcome', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_35='1' )  as 'PW was working outside the home due to which she is unable to attend ANC visits', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_36='1' )  as 'PW was enrolled in Maamta PW trial in the past',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_37='1' )  as 'PW was enrolled in Maamta LW trial in the past',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_38='1' )  as 'PW has any known allergy to food items like peanut, milk, lentils', ('') as 'Break Line', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  (a.pw_crf2_25>=30.5 or  a.pw_crf2_33='2' or  a.pw_crf2_34='2' or a.pw_crf2_35='1' or a.pw_crf2_36='1' or a.pw_crf2_37='1' or a.pw_crf2_38='1')  )  as 'PW was screened and has any exclusion criteria', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  (a.pw_crf2_25<30.5 and a.pw_crf2_33='1' and a.pw_crf2_34='1' and a.pw_crf2_35='2' and a.pw_crf2_36='2' and a.pw_crf2_37='2' and a.pw_crf2_38='2')  )  as 'PW was screened with no exclusion criteria', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_42!='1' )  as 'PW was screened with no exclusion criteria, but consent refused', (select  count(*) from form_crf_3a as a where STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  )  as 'PW was screened with no exclusion criteria, and Enrolled'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView5.DataSource = dt;
                        GridView5.DataBind();
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

        private void ExportReportdata_WithOutDate()
        {
            //Cumulative
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select  (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	)   as 'Total Pregnant Women Approached', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='1'  and a.pw_crf2_19!='' )  as 'PW died before screening', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='6' )  as 'PW was not screened as outcome was Miscarriage/Abortion', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='4' )  as 'PW was not screened as Shifted out of DSS', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='3' )  as 'PW was not screened as Refused', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='2' )  as 'PW was not screened as not at home', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='5' )  as 'PW was died during pregnancy and baby also died inside', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_17='1' )  as 'PW was screened eligibility', ('') as 'Break Line', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_25<30.5 )  as 'Eligible pregnant women as MUAC less than 30.5 cm', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_25>=30.5 )  as 'Not eligible pregnant women as MUAC equal or greater than 30.5 cm', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_33='2' )  as 'PW was not permanent resident of DSS', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_34='2' )  as 'PW was not continues to stay within DSS until birth outcome', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_35='1' )  as 'PW was working outside the home due to which she is unable to attend ANC visits', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_36='1' )  as 'PW was enrolled in Maamta PW trial in the past',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_37='1' )  as 'PW was enrolled in Maamta LW trial in the past',(select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_38='1' )  as 'PW has any known allergy to food items like peanut, milk, lentils', ('') as 'Break Line', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  (a.pw_crf2_25>=30.5 or  a.pw_crf2_33='2' or  a.pw_crf2_34='2' or a.pw_crf2_35='1' or a.pw_crf2_36='1' or a.pw_crf2_37='1' or a.pw_crf2_38='1')  )  as 'PW was screened and has any exclusion criteria', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  (a.pw_crf2_25<30.5 and a.pw_crf2_33='1' and a.pw_crf2_34='1' and a.pw_crf2_35='2' and a.pw_crf2_36='2' and a.pw_crf2_37='2' and a.pw_crf2_38='2')  )  as 'PW was screened with no exclusion criteria', (select  count(*) from form_crf_2 as a where STR_TO_DATE(a.pw_crf2_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	 and  a.pw_crf2_42!='1' )  as 'PW was screened with no exclusion criteria, but consent refused', (select  count(*) from form_crf_3a as a where STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  )  as 'PW was screened with no exclusion criteria, and Enrolled'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView6.DataSource = dt;
                        GridView6.DataBind();
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



        private void ExportArmReportDateWise()
        {
            //In CRF-2 Report, Add ARM with Date
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select 'ARM-A' as ARM, (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='1' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'ARM-B', (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='2' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'ARM-C', (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='3' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'ARM-D', (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='4' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'Cumulative', (select count(*) from form_crf_3a as a where STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	between		STR_TO_DATE('" + txtCalndrDate.Text + "' ,'%d-%m-%Y')	 and	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView8.DataSource = dt;
                        GridView8.DataBind();
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




        private void ExportArmReportWithoutDate()
        {
            //In CRF-2 Report, Add Cumulative ARM
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select 'ARM-A' as ARM, (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='1' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'ARM-B', (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='2' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'ARM-C', (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='3' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'ARM-D', (select count(*) from form_crf_3a as a where a.pw_crf_3a_19='4' and  STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total	union all	select 'Cumulative', (select count(*) from form_crf_3a as a where STR_TO_DATE(a.pw_crf_3a_2,'%d-%m-%Y') 	<=	 STR_TO_DATE('" + txtCalndrDate1.Text + "' ,'%d-%m-%Y')	  ) as Total", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView9.DataSource = dt;
                        GridView9.DataBind();
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




        //CRF-2  Report:
        public void ExcelExportReport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=CRF-2 Report (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView5.AllowPaging = false;
                GridView6.AllowPaging = false;
                GridView8.AllowPaging = false;
                GridView9.AllowPaging = false;
                ExcelExportMessage_Report();
                GridView5.CaptionAlign = TableCaptionAlign.Top;
                GridView6.CaptionAlign = TableCaptionAlign.Top;
                GridView8.CaptionAlign = TableCaptionAlign.Top;
                GridView9.CaptionAlign = TableCaptionAlign.Top;

                ExportReportdata();
                ExportReportdata_WithOutDate();
                ExportArmReportDateWise();
                ExportArmReportWithoutDate();

                for (int i = 0; i < GridView5.HeaderRow.Cells.Count; i++)
                {
                    GridView5.HeaderRow.Cells[i].Style.Add("font-size", "15px");
                    GridView5.HeaderRow.Cells[i].Style.Add("height", "90px");
                    GridView5.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView5.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView5.Rows[GridView5.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView5.Rows[GridView5.Rows.Count - 1].Font.Bold = true;

                for (int i = 0; i < GridView6.HeaderRow.Cells.Count; i++)
                {
                    GridView6.HeaderRow.Cells[i].Style.Add("font-size", "15px");
                    GridView6.HeaderRow.Cells[i].Style.Add("height", "90px");
                    GridView6.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView6.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView6.Rows[GridView6.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView6.Rows[GridView6.Rows.Count - 1].Font.Bold = true;


                //ARM Report: 
                for (int i = 0; i < GridView8.HeaderRow.Cells.Count; i++)
                {
                    GridView8.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView8.HeaderRow.Cells[i].Style.Add("height", "50px");
                    GridView8.HeaderRow.Cells[i].Style.Add("background-color", "#e17055");
                    GridView8.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView8.Rows[GridView8.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView8.Rows[GridView8.Rows.Count - 1].Font.Bold = true;

                for (int i = 0; i < GridView9.HeaderRow.Cells.Count; i++)
                {
                    GridView9.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView9.HeaderRow.Cells[i].Style.Add("height", "50px");
                    GridView9.HeaderRow.Cells[i].Style.Add("background-color", "#e17055");
                    GridView9.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView9.Rows[GridView9.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView9.Rows[GridView9.Rows.Count - 1].Font.Bold = true;


                GridView5.RenderControl(htmlWrite);
                GridView6.RenderControl(htmlWrite);
                GridView8.RenderControl(htmlWrite);
                GridView9.RenderControl(htmlWrite);

                Response.Write(stringWrite.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");
            }
        }










        public void TotalEnrollment()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select count(*) as total from form_crf_3a ", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    lbeTotalEnrollment.Text = "Total: " + dr["total"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }








    }
}