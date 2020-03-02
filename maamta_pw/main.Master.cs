using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta_pw
{
    public partial class main : System.Web.UI.MasterPage
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbeUserName.Text = "(Logged in: " + Convert.ToString(Session["MPusernamePW"]) + ")";
            lbeUserNav.Text = Convert.ToString(Session["MPusernamePW"]);
            //  Start Navigation:




            if (Convert.ToString(Session["RolePW"]) != "web_admin" && Convert.ToString(Session["RolePW"]) != "web_sup_admin")
            {
                navdash.Visible = false;
                navTabUsr.Visible = false;
                followups4.Visible = false;
                followups5a.Visible = false;
                followups5b.Visible = false;
                followups5c.Visible = false;
                navScrRandForms.Visible = false;
                //navDuplicate.Visible = false;
            }
            if (Convert.ToString(Session["RolePW"]) != "web_sup_admin")
            {
                 navWebEntry.Visible = false;
            }





            // End Navigation:

            if (Session["MPusernamePW"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

                // Dashboard
                if (Convert.ToString(Session["WebForm"]) == "dashUltra")
                {
                    dashboard.Attributes.Add("class", "active");
                    dashUltra.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "dashANC")
                {
                    dashboard.Attributes.Add("class", "active");
                    dashANC.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "DashboardRandom")
                {
                    dashboard.Attributes.Add("class", "active");
                    random.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                // Report Print
                else if (Convert.ToString(Session["WebForm"]) == "ultraReport")
                {
                    ReportUltra.Attributes.Add("class", "active");
                    ultraReport.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "ancReport")
                {
                    ReportUltra.Attributes.Add("class", "active");
                    ancReport.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }



                // Task-List
                else if (Convert.ToString(Session["WebForm"]) == "LABinvestigation")
                {
                    TaskList.Attributes.Add("class", "active");
                    labinvestigation.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "AzithromycinTask")
                {
                    TaskList.Attributes.Add("class", "active");
                    azithromycin.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "expectedOutcome")
                {                    
                    TaskList.Attributes.Add("class", "active");
                    expectedOutcome.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "expectedOutcomeEnrolled")
                {
                    TaskList.Attributes.Add("class", "active");
                    expectedOutcomeEnrolled.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "ancPending")
                {
                    TaskList.Attributes.Add("class", "active");
                    ancPending.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

                else if (Convert.ToString(Session["WebForm"]) == "ancVisits")
                {
                    TaskList.Attributes.Add("class", "active");
                    ancVisits.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

                else if (Convert.ToString(Session["WebForm"]) == "enrollmentPending")
                {
                    TaskList.Attributes.Add("class", "active");
                    enrollmentPending.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups4")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups4.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups5a")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups5a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups5b")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups5b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups5c")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups5c.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups6")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups6.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }



                // Show Forms:
                else if (Convert.ToString(Session["WebForm"]) == "randomSequence")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    randomSequence.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf1")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf1.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showanc")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showanc.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showFirstUltrasound")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showFirstUltrasound.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showanc_enrolled")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showanc_enrolled.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                else if (Convert.ToString(Session["WebForm"]) == "showcrf2")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf2.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf3a")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf3a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf3b")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf3b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf3c")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf3c.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf4")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf4.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf4b")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf4b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf5a")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf5a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf5b")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf5b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf5c")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf5c.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf6a")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf6a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf6b")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf6b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }



                //Compliance Forms:

                else if (Convert.ToString(Session["WebForm"]) == "showcrf4Compliance")
                {
                    WebEntry.Attributes.Add("class", "active");
                    showcrf4Compliance.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "entrycompliance")
                {
                    WebEntry.Attributes.Add("class", "active");
                    entrycompliance.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "checkcompliance")
                {
                    WebEntry.Attributes.Add("class", "active");
                    checkcompliance.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }






                // ERROR Forms:
                else if (Convert.ToString(Session["WebForm"]) == "duplicateCRF1")
                {
                    Error.Attributes.Add("class", "active");
                    duplicateCRF1.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "duplicateANC")
                {
                    Error.Attributes.Add("class", "active");
                    duplicateANC.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "ancSerialNo")
                {
                    Error.Attributes.Add("class", "active");
                    ancSerialMissed.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "errorCompliance")
                {
                    Error.Attributes.Add("class", "active");
                    errorCompliance.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "ErrorMissingFollowup")
                {
                    Error.Attributes.Add("class", "active");
                    ErrorMissingFollowup.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }








                 // Monitoring:
                else if (Convert.ToString(Session["WebForm"]) == "compPrtage")
                {
                    monitoring.Attributes.Add("class", "active");
                    compPrtage.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "CholinePrtage")
                {
                    monitoring.Attributes.Add("class", "active");
                    CholinePrtage.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "NicotinamidePrtage")
                {
                    monitoring.Attributes.Add("class", "active");
                    NicotinamidePrtage.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                    
                    
                //TAB user Account:
                else if (Convert.ToString(Session["WebForm"]) == "ListOfUsers")
                {
                    TabUsr.Attributes.Add("class", "active");
                    listUsr.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

               


            }
        }



    }
}