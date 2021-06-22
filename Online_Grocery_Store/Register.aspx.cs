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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncrsubmit_Click(object sender, EventArgs e)
        {
            if(txtcrpass.Text==txtcrcnfpass.Text)
            {
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                string str = "INSERT INTO user (First_Name,Last_name,Password,Address,State,Country,Email) VALUES (@firstname,@lastname,@password,@address,@state,@country,@email)";
                MySqlCommand cmd = new MySqlCommand(str, con);
                cmd.Parameters.AddWithValue("@firstname", txtcrfname.Text);
                cmd.Parameters.AddWithValue("@lastname", txtcrlname.Text);
                cmd.Parameters.AddWithValue("@password", txtcrpass.Text);
                cmd.Parameters.AddWithValue("@address", txtcraddress.Text);
                cmd.Parameters.AddWithValue("@state", txtcrstate.Text);
                cmd.Parameters.AddWithValue("@country", txtcrcountry.Text);
                cmd.Parameters.AddWithValue("@email", txtcremail.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            }
        }
    }
}