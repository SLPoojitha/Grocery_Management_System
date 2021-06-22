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
    public partial class UserOrderPage : System.Web.UI.Page
    {
        string useremailid = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            useremailid = Request.QueryString["sessionid"].ToString();

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            string query = "select user_id from user where Email = '" + useremailid + "'";
            MySqlCommand cmd1 = new MySqlCommand(query, con);
            int userID = (int)cmd1.ExecuteScalar();

            MySqlCommand cmd = new MySqlCommand("select Order_date, Order_id, pay_method, Prod_name, Item_Quan, Item_price, Pay_amount from products, orders, order_item where Item_prod_id = Prod_id and order_id = Item_order_id  and Order_user_id = " + userID, con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            Grdorder.DataSource = sdr;
            Grdorder.DataBind();
            con.Close();
        }

        protected void imgbtnlogout4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void imgbtnprofile4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserProfilePage.aspx?sessionid=" + useremailid);
        }

        protected void imgbtncart4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserCartView.aspx?sessionid=" + useremailid);
        }

        protected void lblstorename6_Click(object sender, EventArgs e)
        {
            Response.Redirect("afterLogin.aspx");
        }
    }
}