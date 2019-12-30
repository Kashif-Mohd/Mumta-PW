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
    public partial class listusers : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "ListOfUsers";
            if (!IsPostBack)
            {
                ShowData();
                txtname.Focus();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtname.Focus();
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                if (DropDownList1.SelectedValue == "0")
                {
                    MySqlCommand cmd = new MySqlCommand("select a.sra_name,b.title,a.user_name,a.password,a.status from team as a left join group_title as b on a.team_title_id=b.team_title_id where a.status is not null and a.sra_name like '%" + txtname.Text + "%'  and a.status='1'  order by a.team_title_id,a.sra_name", con);
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
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select a.sra_name,b.title,a.user_name,a.password,a.status from team as a left join group_title as b on a.team_title_id=b.team_title_id where a.status is not null and a.sra_name like '%" + txtname.Text + "%'  and a.status='1'  and a.team_title_id='" + DropDownList1.SelectedValue + "' order by a.team_title_id,a.sra_name", con);
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

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[5].Text == "1")
            //    {
            //        e.Row.Cells[5].Text = "Active";
            //    }
            //    else if (e.Row.Cells[5].Text == "2")
            //    {
            //        e.Row.Cells[5].Text = "Deactive";
            //    }
            //}
        }



    }
}