using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Grocery_Store
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblinvalidusernameandpass.Visible = false;
        }

        protected void btnloginsubmit_Click(object sender, EventArgs e)
        {
            if(txtusername.Text=="Admin"&& txtpass.Text=="admin@123")
            {
                Response.Redirect("AdminPage.aspx");
            }

            else
            {
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select * from user where Email =@username and password=@password", con);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpass.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["id"] = txtusername.Text;
                    Response.Redirect("afterLogin.aspx");
                }

                else
                {
                    lblinvalidusernameandpass.Visible = true;
                }
            }
           
        }
    }
}