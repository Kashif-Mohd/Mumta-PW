using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta_pw
{
    public partial class showcrf5cbyid : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showcrf5c";
                if (Session["StudyIdCRF5c"] == null)
                {
                    Response.Redirect("showcrf5c.aspx");
                }
                lbeAssid.Text = Convert.ToString(Session["StudyIdCRF5c"]);
                ShowData();
                ShowMUAC();
                ShowWeight();
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["StudyId_CRF5c"] = null;
            Session["form_crf5c_id"] = null;
            Response.Redirect("showcrf5c.aspx");
        }



        public static DataTable FlipDataTable(DataTable dt)
        {
            DataTable table = new DataTable();
            //Get all the rows and change into columns
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow dr;
            //get all the columns and make it as rows
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr = table.NewRow();
                dr[0] = dt.Columns[j].ToString();
                for (int k = 1; k <= dt.Rows.Count; k++)
                    dr[k] = dt.Rows[k - 1][j];
                table.Rows.Add(dr);
            }

            return table;
        }



        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select * from view_crf5c where form_crf_5c_id='" + Convert.ToString(Session["form_crf_5c_id"]) + "'", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataSource = FlipDataTable(dt);
                            GridView1.DataBind();
                            GridView1.HeaderRow.Visible = false;
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




        private void ShowWeight()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from pw_weight_crf_5c where form_crf_5c_id='" + Convert.ToString(Session["form_crf_5c_id"]) + "' ", con);
                {
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



        private void ShowMUAC()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from muac_crf_5c where form_crf_5c_id='" + Convert.ToString(Session["form_crf_5c_id"]) + "' ", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView3.DataSource = dt;
                            GridView3.DataBind();
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

        


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[0].Width = 230;

                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[1].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[0].BorderColor = System.Drawing.Color.FromName("#126652");
            }
        }

    
    }
}