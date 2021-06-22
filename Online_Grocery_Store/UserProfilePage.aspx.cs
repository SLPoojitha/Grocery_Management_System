using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Grocery_Store
{
    public partial class UserProfilePage : System.Web.UI.Page
    {
        string useremail = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }


        }

        private void BindGrid()
        {
            useremail = Request.QueryString["sessionid"].ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select User_ID,First_name,Last_name,Email,Password,Address,State,Country from user where Email ='" + useremail + "'", con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            Grdprofile.DataSource = sdr;
            Grdprofile.DataBind();
            con.Close();
        }



        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            Grdprofile.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }


        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            Grdprofile.EditIndex = -1;
            this.BindGrid();
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != Grdprofile.EditIndex)
            {
                e.Row.Cells[0].Controls[2].Visible=false ;
           }
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = Grdprofile.Rows[e.RowIndex];
            int userid = Convert.ToInt32(Grdprofile.DataKeys[e.RowIndex].Values[0]);
            string firstname = (row.Cells[2].Controls[0] as TextBox).Text;
            string lastname = (row.Cells[3].Controls[0] as TextBox).Text;
            string email = (row.Cells[4].Controls[0] as TextBox).Text;
            string password = (row.Cells[5].Controls[0] as TextBox).Text;
            string address = (row.Cells[6].Controls[0] as TextBox).Text;
            string state = (row.Cells[7].Controls[0] as TextBox).Text;
            string country = (row.Cells[8].Controls[0] as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE user SET First_name = @firstname, Last_name = @lastname,Email=@email,Password=@password,Address=@address,State=@state,Country=@country WHERE User_ID = @userid"))
                {
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Grdprofile.EditIndex = -1;
            this.BindGrid();
        }

        protected void btnuserorder_Click(object sender, EventArgs e)
        {
            useremail = Request.QueryString["sessionid"].ToString();
            //Response.Redirect("UserOrderPage.aspx");
            Response.Redirect("UserOrderPage.aspx?sessionid=" + useremail);
        }

        protected void imgbtnlogout5_Click(object sender, ImageClickEventArgs e)
        {
            useremail = Request.QueryString["sessionid"].ToString();
            Response.Redirect("Home.aspx");
        }

        protected void imgbtncart5_Click(object sender, ImageClickEventArgs e)
        {
            useremail = Request.QueryString["sessionid"].ToString();
            Response.Redirect("UserCartView.aspx?sessionid=" + useremail);
        }

        protected void imgbtnprofile5_Click(object sender, ImageClickEventArgs e)
        {
            useremail = Request.QueryString["sessionid"].ToString();
            Response.Redirect("UserProfilePage.aspx?sessionid=" + useremail);
        }

        protected void lblstorename4_Click(object sender, EventArgs e)
        {
            Response.Redirect("afterLogin.aspx");
        }
    }
}