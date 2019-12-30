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
    public partial class dashANC : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashANC";
                txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate.Attributes.Add("readonly", "readonly");
                txtCalndrDate1.Attributes.Add("readonly", "readonly");
                ShowData();
            }

        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
                ShowDuplicate();
            }
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select b.sra_name,count(*) as total from anc_visit_details as a left join team as b on a.team_id=b.team_id where (str_to_date(a.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) group by a.team_id", con);

                {
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


        private void ShowDuplicate()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT count(*) AS duplicate FROM (SELECT count(*) as total,concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16) as dssid from anc_visit_details as a left join pregnant_woman as b on a.pw_id=b.pw_id where (str_to_date(a.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) group by concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16),date_of_attempt having count(concat(b.pw_crf_1_11,b.pw_crf_1_12,b.pw_crf_1_13,b.pw_crf_1_14,b.pw_crf_1_15,b.pw_crf_1_16))>1 ) AS t", con);
                {
                    dreader = cmd.ExecuteReader();
                    if (dreader.Read())
                    {
                        linkDuplicate.Text = dreader["duplicate"].ToString();
                    }
                    con.Close();
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


        Int32 total = 0;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total = total + Convert.ToInt32(e.Row.Cells[2].Text);
                lbeTotal.Text = total.ToString();
            }
        }


        protected void Link_Duplicate(object sender, EventArgs e)
        {
            //if (((LinkButton)sender).Text != "0")
            //{
            //    Session["showcrf1Hide"] = "showcrf1Hide";
            //    Session["FirstEDate"] = txtCalndrDate.Text;
            //    Session["SecEDate"] = txtCalndrDate1.Text;
            //    Response.Redirect("showcrf1.aspx");
            //}
        }


    }
}