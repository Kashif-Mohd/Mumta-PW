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
    public partial class updatecrf8b : System.Web.UI.Page
    {
        static string AD_Start_Date;
        static string AD_Stop_Date;

        //MySQL 
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf8";
                FieldFill();
                txtq27.Focus();
            }
        }






        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }







        protected void next_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                //q30a1
                if (txtq37a1dt.Text != "" && txtq37a1dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a1dt.Focus();
                }
                else if (txtq37a1dt.Text != "" && txtq37a1dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a1dt.Focus();
                }

                //q30a2
                else if (txtq37a2dt.Text != "" && txtq37a2dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a2dt.Focus();
                }
                else if (txtq37a2dt.Text != "" && txtq37a2dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a2dt.Focus();
                }

                //q30a3
                else if (txtq37a3dt.Text != "" && txtq37a3dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a3dt.Focus();
                }
                else if (txtq37a3dt.Text != "" && txtq37a3dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a3dt.Focus();
                }

                //q30a4
                else if (txtq37a4dt.Text != "" && txtq37a4dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a4dt.Focus();
                }
                else if (txtq37a4dt.Text != "" && txtq37a4dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a4dt.Focus();
                }

                //q30a5
                else if (txtq37a5dt.Text != "" && txtq37a5dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a5dt.Focus();
                }
                else if (txtq37a5dt.Text != "" && txtq37a5dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a5dt.Focus();
                }

                //q30a6
                else if (txtq37a6dt.Text != "" && txtq37a6dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a6dt.Focus();
                }
                else if (txtq37a6dt.Text != "" && txtq37a6dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a6dt.Focus();
                }

                //q30a7
                else if (txtq37a7dt.Text != "" && txtq37a7dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a7dt.Focus();
                }
                else if (txtq37a7dt.Text != "" && txtq37a7dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a7dt.Focus();
                }

                //q30a8
                else if (txtq37a8dt.Text != "" && txtq37a8dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a8dt.Focus();
                }
                else if (txtq37a8dt.Text != "" && txtq37a8dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a8dt.Focus();
                }

                //q30a9
                else if (txtq37a9dt.Text != "" && txtq37a9dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a9dt.Focus();
                }
                else if (txtq37a9dt.Text != "" && txtq37a9dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a9dt.Focus();
                }

                //q30a10
                else if (txtq37a10dt.Text != "" && txtq37a10dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a10dt.Focus();
                }
                else if (txtq37a10dt.Text != "" && txtq37a10dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a10dt.Focus();
                }
                //q30a11
                else if (txtq37a11dt.Text != "" && txtq37a11dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a11dt.Focus();
                }
                else if (txtq37a11dt.Text != "" && txtq37a11dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a11dt.Focus();
                }
                //q30a12
                else if (txtq37a12dt.Text != "" && txtq37a12dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a12dt.Focus();
                }
                else if (txtq37a12dt.Text != "" && txtq37a12dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a12dt.Focus();
                }
                //q30a13
                else if (txtq37a13dt.Text != "" && txtq37a13dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a13dt.Focus();
                }
                else if (txtq37a13dt.Text != "" && txtq37a13dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a13dt.Focus();
                }
                //q30a14
                else if (txtq37a14dt.Text != "" && txtq37a14dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a14dt.Focus();
                }
                else if (txtq37a14dt.Text != "" && txtq37a14dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a14dt.Focus();
                }
                //q30a15
                else if (txtq37a15dt.Text != "" && txtq37a15dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37a15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37a15dt.Focus();
                }
                else if (txtq37a15dt.Text != "" && txtq37a15dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37a15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37a15dt.Focus();
                }







                //q30b1
                else if (txtq37b1dt.Text != "" && txtq37b1dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b1dt.Focus();
                }
                else if (txtq37b1dt.Text != "" && txtq37b1dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b1dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b1dt.Focus();
                }

                //q30b2
                else if (txtq37b2dt.Text != "" && txtq37b2dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b2dt.Focus();
                }
                else if (txtq37b2dt.Text != "" && txtq37b2dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b2dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b2dt.Focus();
                }

                //q30b3
                else if (txtq37b3dt.Text != "" && txtq37b3dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b3dt.Focus();
                }
                else if (txtq37b3dt.Text != "" && txtq37b3dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b3dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b3dt.Focus();
                }

                //q30b4
                else if (txtq37b4dt.Text != "" && txtq37b4dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b4dt.Focus();
                }
                else if (txtq37b4dt.Text != "" && txtq37b4dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b4dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b4dt.Focus();
                }

                //q30b5
                else if (txtq37b5dt.Text != "" && txtq37b5dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b5dt.Focus();
                }
                else if (txtq37b5dt.Text != "" && txtq37b5dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b5dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b5dt.Focus();
                }

                //q30b6
                else if (txtq37b6dt.Text != "" && txtq37b6dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b6dt.Focus();
                }
                else if (txtq37b6dt.Text != "" && txtq37b6dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b6dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b6dt.Focus();
                }

                //q30b7
                else if (txtq37b7dt.Text != "" && txtq37b7dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b7dt.Focus();
                }
                else if (txtq37b7dt.Text != "" && txtq37b7dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b7dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b7dt.Focus();
                }

                //q30b8
                else if (txtq37b8dt.Text != "" && txtq37b8dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b8dt.Focus();
                }
                else if (txtq37b8dt.Text != "" && txtq37b8dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b8dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b8dt.Focus();
                }

                //q30b9
                else if (txtq37b9dt.Text != "" && txtq37b9dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b9dt.Focus();
                }
                else if (txtq37b9dt.Text != "" && txtq37b9dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b9dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b9dt.Focus();
                }

                //q30b10
                else if (txtq37b10dt.Text != "" && txtq37b10dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b10dt.Focus();
                }
                else if (txtq37b10dt.Text != "" && txtq37b10dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b10dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b10dt.Focus();
                }
                //q30b11
                else if (txtq37b11dt.Text != "" && txtq37b11dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b11dt.Focus();
                }
                else if (txtq37b11dt.Text != "" && txtq37b11dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b11dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b11dt.Focus();
                }
                //q30b12
                else if (txtq37b12dt.Text != "" && txtq37b12dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b12dt.Focus();
                }
                else if (txtq37b12dt.Text != "" && txtq37b12dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b12dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b12dt.Focus();
                }
                //q30b13
                else if (txtq37b13dt.Text != "" && txtq37b13dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b13dt.Focus();
                }
                else if (txtq37b13dt.Text != "" && txtq37b13dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b13dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b13dt.Focus();
                }
                //q30b14
                else if (txtq37b14dt.Text != "" && txtq37b14dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b14dt.Focus();
                }
                else if (txtq37b14dt.Text != "" && txtq37b14dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b14dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b14dt.Focus();
                }
                //q30b15
                else if (txtq37b15dt.Text != "" && txtq37b15dt.Text != "__-__-____" && (DateTime.ParseExact(txtq37b15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(AD_Start_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Greater than Adverse Event Start Date (" + AD_Start_Date + ")");
                    txtq37b15dt.Focus();
                }
                else if (txtq37b15dt.Text != "" && txtq37b15dt.Text != "__-__-____" && AD_Stop_Date != "88-88-8888" && (DateTime.ParseExact(txtq37b15dt.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(AD_Stop_Date, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Adverse Event Stopped Date (" + AD_Stop_Date + ")");
                    txtq37b15dt.Focus();
                }


                else if (check_CRF3a_ARM_BCD_Q30() == false && txtq30.SelectedValue == "1")
                {
                    showalert("Irrelevant option selected (Q30)");
                    txtq30.Focus();
                }
                else if (check_CRF3a_ARM_C_Q30() == false && txtq30.SelectedValue == "2")
                {
                    showalert("Irrelevant option selected (Q30)");
                    txtq30.Focus();
                }
                else if (check_CRF3a_ARM_D_Q30() == false && (txtq30.SelectedValue == "3" || txtq30.SelectedValue == "4"))
                {
                    showalert("Irrelevant option selected (Q30)");
                    txtq30.Focus();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update crf8 set q27='" + txtq27.SelectedValue + "',q28='" + txtq28.SelectedValue + "',q28_other='" + txtq28_other.Text + "',q29='" + txtq29.Text + "',q30='" + txtq30.SelectedValue + "'	,q31_minutes='" + txtq31_min.Text + "'	,q31_hours='" + txtq31_hr.Text + "', q31_days='" + txtq31_day.Text + "',q32='" + txtq32.SelectedValue + "',q32_other='" + txtq32_other.Text + "',   q33='" + txtq33.SelectedValue + "',       q34_01='" + (chkQ34_01.Checked == true ? "1" : "") + "',q34_02='" + (chkQ34_02.Checked == true ? "2" : "") + "',q34_03='" + (chkQ34_03.Checked == true ? "3" : "") + "',q34_04='" + (chkQ34_04.Checked == true ? "4" : "") + "',q34_05='" + (chkQ34_05.Checked == true ? "5" : "") + "',q34_06='" + (chkQ34_06.Checked == true ? "6" : "") + "',q34_07='" + (chkQ34_07.Checked == true ? "7" : "") + "',q34_08='" + (chkQ34_08.Checked == true ? "8" : "") + "',q34_09='" + (chkQ34_09.Checked == true ? "9" : "") + "',q34_10='" + (chkQ34_10.Checked == true ? "10" : "") + "',q34_11='" + (chkQ34_11.Checked == true ? "11" : "") + "',q34_12='" + (chkQ34_12.Checked == true ? "12" : "") + "',q34_13='" + (chkQ34_13.Checked == true ? "13" : "") + "', q34_13_other='" + txtq34.Text + "',q35='" + txtq35.Text + "',q36_01='" + (chkQ36_01.Checked == true ? "1" : "") + "',q36_02='" + (chkQ36_02.Checked == true ? "2" : "") + "',q36_03='" + (chkQ36_03.Checked == true ? "3" : "") + "',q36_04='" + (chkQ36_04.Checked == true ? "4" : "") + "',q36_05='" + (chkQ36_05.Checked == true ? "5" : "") + "',q36_06='" + (chkQ36_06.Checked == true ? "6" : "") + "',q36_07='" + (chkQ36_07.Checked == true ? "7" : "") + "',q36_08='" + (chkQ36_08.Checked == true ? "8" : "") + "',q36_09='" + (chkQ36_09.Checked == true ? "9" : "") + "', q36_09_other='" + txtq36.Text + "',                                                   q37a_1='" + txtq37a1.InnerText + "', q37a_2='" + txtq37a2.InnerText + "', q37a_3='" + txtq37a3.InnerText + "', q37a_4='" + txtq37a4.InnerText + "', q37a_5='" + txtq37a5.InnerText + "', q37a_6='" + txtq37a6.InnerText + "', q37a_7='" + txtq37a7.InnerText + "', q37a_8='" + txtq37a8.InnerText + "', q37a_9='" + txtq37a9.InnerText + "', q37a_10='" + txtq37a10.InnerText + "',q37a_11='" + txtq37a11.InnerText + "',q37a_12='" + txtq37a12.InnerText + "',q37a_13='" + txtq37a13.InnerText + "',q37a_14='" + txtq37a14.InnerText + "',q37a_15='" + txtq37a15.InnerText + "',      q37b_1='" + txtq37b1.InnerText + "', q37b_2='" + txtq37b2.InnerText + "', q37b_3='" + txtq37b3.InnerText + "', q37b_4='" + txtq37b4.InnerText + "', q37b_5='" + txtq37b5.InnerText + "', q37b_6='" + txtq37b6.InnerText + "', q37b_7='" + txtq37b7.InnerText + "', q37b_8='" + txtq37b8.InnerText + "', q37b_9='" + txtq37b9.InnerText + "', q37b_10='" + txtq37b10.InnerText + "',q37b_11='" + txtq37b11.InnerText + "',q37b_12='" + txtq37b12.InnerText + "',q37b_13='" + txtq37b13.InnerText + "',q37b_14='" + txtq37b14.InnerText + "',q37b_15='" + txtq37b15.InnerText + "',                       q37a_1dt='" + txtq37a1dt.Text + "', q37a_2dt='" + txtq37a2dt.Text + "', q37a_3dt='" + txtq37a3dt.Text + "', q37a_4dt='" + txtq37a4dt.Text + "', q37a_5dt='" + txtq37a5dt.Text + "', q37a_6dt='" + txtq37a6dt.Text + "', q37a_7dt='" + txtq37a7dt.Text + "', q37a_8dt='" + txtq37a8dt.Text + "', q37a_9dt='" + txtq37a9dt.Text + "', q37a_10dt='" + txtq37a10dt.Text + "',q37a_11dt='" + txtq37a11dt.Text + "',q37a_12dt='" + txtq37a12dt.Text + "',q37a_13dt='" + txtq37a13dt.Text + "',q37a_14dt='" + txtq37a14dt.Text + "',q37a_15dt='" + txtq37a15dt.Text + "',                           q37b_1dt='" + txtq37b1dt.Text + "', q37b_2dt='" + txtq37b2dt.Text + "', q37b_3dt='" + txtq37b3dt.Text + "', q37b_4dt='" + txtq37b4dt.Text + "', q37b_5dt='" + txtq37b5dt.Text + "', q37b_6dt='" + txtq37b6dt.Text + "', q37b_7dt='" + txtq37b7dt.Text + "', q37b_8dt='" + txtq37b8dt.Text + "', q37b_9dt='" + txtq37b9dt.Text + "', q37b_10dt='" + txtq37b10dt.Text + "', q37b_11dt='" + txtq37b11dt.Text + "', q37b_12dt='" + txtq37b12dt.Text + "', q37b_13dt='" + txtq37b13dt.Text + "', q37b_14dt='" + txtq37b14dt.Text + "', q37b_15dt='" + txtq37b15dt.Text + "'          where  id='" + Request.QueryString["FormID"] + "' and status=1", cn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("updatecrf8c.aspx?&FormID=" + Request.QueryString["FormID"]);
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









        public bool check_CRF3a_ARM_BCD_Q30()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_3a WHERE study_code='" + Request.QueryString["Study_ID"] + "' AND pw_crf_3a_19!='1' ", con);
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





        public bool check_CRF3a_ARM_C_Q30()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_3a WHERE study_code='" + Request.QueryString["Study_ID"] + "' AND pw_crf_3a_19='3'", con);
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








        public bool check_CRF3a_ARM_D_Q30()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM form_crf_3a WHERE study_code='" + Request.QueryString["Study_ID"] + "' AND pw_crf_3a_19='4'", con);
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




        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where  id='" + Request.QueryString["FormID"] + "' and status=1", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    AD_Start_Date = dr["q17"].ToString();
                    AD_Stop_Date = dr["q19"].ToString();

                    txtq27.SelectedValue = dr["q27"].ToString();
                    txtq28.SelectedValue = dr["q28"].ToString();
                    txtq28_other.Text = dr["q28_other"].ToString();
                    txtq29.SelectedValue = dr["q29"].ToString();
                    txtq30.SelectedValue = dr["q30"].ToString();

                    txtq31_min.Text = dr["q31_minutes"].ToString();
                    txtq31_hr.Text = dr["q31_hours"].ToString();
                    txtq31_day.Text = dr["q31_days"].ToString();

                    txtq32.SelectedValue = dr["q32"].ToString();
                    txtq32_other.Text = dr["q32_other"].ToString();
                    txtq33.SelectedValue = dr["q33"].ToString();


                    chkQ34_01.Checked = (dr["q34_01"].Equals("1"));
                    chkQ34_02.Checked = (dr["q34_02"].Equals("2"));
                    chkQ34_03.Checked = (dr["q34_03"].Equals("3"));
                    chkQ34_04.Checked = (dr["q34_04"].Equals("4"));
                    chkQ34_05.Checked = (dr["q34_05"].Equals("5"));
                    chkQ34_06.Checked = (dr["q34_06"].Equals("6"));
                    chkQ34_07.Checked = (dr["q34_07"].Equals("7"));
                    chkQ34_08.Checked = (dr["q34_08"].Equals("8"));
                    chkQ34_09.Checked = (dr["q34_09"].Equals("9"));
                    chkQ34_10.Checked = (dr["q34_10"].Equals("10"));
                    chkQ34_11.Checked = (dr["q34_11"].Equals("11"));
                    chkQ34_12.Checked = (dr["q34_12"].Equals("12"));
                    chkQ34_13.Checked = (dr["q34_13"].Equals("13"));
                    txtq34.Text = dr["q34_13_other"].ToString();
                    txtq35.Text = dr["q35"].ToString();

                    chkQ36_01.Checked = (dr["q36_01"].Equals("1"));
                    chkQ36_02.Checked = (dr["q36_02"].Equals("2"));
                    chkQ36_03.Checked = (dr["q36_03"].Equals("3"));
                    chkQ36_04.Checked = (dr["q36_04"].Equals("4"));
                    chkQ36_05.Checked = (dr["q36_05"].Equals("5"));
                    chkQ36_06.Checked = (dr["q36_06"].Equals("6"));
                    chkQ36_07.Checked = (dr["q36_07"].Equals("7"));
                    chkQ36_08.Checked = (dr["q36_08"].Equals("8"));
                    chkQ36_09.Checked = (dr["q36_09"].Equals("9"));
                    txtq36.Text = dr["q36_09_other"].ToString();

                    txtq37a1.InnerText = dr["q37a_1"].ToString();
                    txtq37a2.InnerText = dr["q37a_2"].ToString();
                    txtq37a3.InnerText = dr["q37a_3"].ToString();
                    txtq37a4.InnerText = dr["q37a_4"].ToString();
                    txtq37a5.InnerText = dr["q37a_5"].ToString();
                    txtq37a6.InnerText = dr["q37a_6"].ToString();
                    txtq37a7.InnerText = dr["q37a_7"].ToString();
                    txtq37a8.InnerText = dr["q37a_8"].ToString();
                    txtq37a9.InnerText = dr["q37a_9"].ToString();
                    txtq37a10.InnerText = dr["q37a_10"].ToString();
                    txtq37a11.InnerText = dr["q37a_11"].ToString();
                    txtq37a12.InnerText = dr["q37a_12"].ToString();
                    txtq37a13.InnerText = dr["q37a_13"].ToString();
                    txtq37a14.InnerText = dr["q37a_14"].ToString();
                    txtq37a15.InnerText = dr["q37a_15"].ToString();

                    txtq37b1.InnerText = dr["q37b_1"].ToString();
                    txtq37b2.InnerText = dr["q37b_2"].ToString();
                    txtq37b3.InnerText = dr["q37b_3"].ToString();
                    txtq37b4.InnerText = dr["q37b_4"].ToString();
                    txtq37b5.InnerText = dr["q37b_5"].ToString();
                    txtq37b6.InnerText = dr["q37b_6"].ToString();
                    txtq37b7.InnerText = dr["q37b_7"].ToString();
                    txtq37b8.InnerText = dr["q37b_8"].ToString();
                    txtq37b9.InnerText = dr["q37b_9"].ToString();
                    txtq37b10.InnerText = dr["q37b_10"].ToString();
                    txtq37b11.InnerText = dr["q37b_11"].ToString();
                    txtq37b12.InnerText = dr["q37b_12"].ToString();
                    txtq37b13.InnerText = dr["q37b_13"].ToString();
                    txtq37b14.InnerText = dr["q37b_14"].ToString();
                    txtq37b15.InnerText = dr["q37b_15"].ToString();



                    txtq37a1dt.Text = dr["q37a_1dt"].ToString();
                    txtq37a2dt.Text = dr["q37a_2dt"].ToString();
                    txtq37a3dt.Text = dr["q37a_3dt"].ToString();
                    txtq37a4dt.Text = dr["q37a_4dt"].ToString();
                    txtq37a5dt.Text = dr["q37a_5dt"].ToString();
                    txtq37a6dt.Text = dr["q37a_6dt"].ToString();
                    txtq37a7dt.Text = dr["q37a_7dt"].ToString();
                    txtq37a8dt.Text = dr["q37a_8dt"].ToString();
                    txtq37a9dt.Text = dr["q37a_9dt"].ToString();
                    txtq37a10dt.Text = dr["q37a_10dt"].ToString();
                    txtq37a11dt.Text = dr["q37a_11dt"].ToString();
                    txtq37a12dt.Text = dr["q37a_12dt"].ToString();
                    txtq37a13dt.Text = dr["q37a_13dt"].ToString();
                    txtq37a14dt.Text = dr["q37a_14dt"].ToString();
                    txtq37a15dt.Text = dr["q37a_15dt"].ToString();

                    txtq37b1dt.Text = dr["q37b_1dt"].ToString();
                    txtq37b2dt.Text = dr["q37b_2dt"].ToString();
                    txtq37b3dt.Text = dr["q37b_3dt"].ToString();
                    txtq37b4dt.Text = dr["q37b_4dt"].ToString();
                    txtq37b5dt.Text = dr["q37b_5dt"].ToString();
                    txtq37b6dt.Text = dr["q37b_6dt"].ToString();
                    txtq37b7dt.Text = dr["q37b_7dt"].ToString();
                    txtq37b8dt.Text = dr["q37b_8dt"].ToString();
                    txtq37b9dt.Text = dr["q37b_9dt"].ToString();
                    txtq37b10dt.Text = dr["q37b_10dt"].ToString();
                    txtq37b11dt.Text = dr["q37b_11dt"].ToString();
                    txtq37b12dt.Text = dr["q37b_12dt"].ToString();
                    txtq37b13dt.Text = dr["q37b_13dt"].ToString();
                    txtq37b14dt.Text = dr["q37b_14dt"].ToString();
                    txtq37b15dt.Text = dr["q37b_15dt"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }



    }
}