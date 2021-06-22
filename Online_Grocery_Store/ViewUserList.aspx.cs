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
    public partial class ViewUserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select User_ID,First_name,Last_name,Email,Address,State,Country from user",con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            GridView1.DataSource = sdr;
            GridView1.DataBind();
            con.Close();
        }

        protected void btnadminlogout1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lblstorename3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}