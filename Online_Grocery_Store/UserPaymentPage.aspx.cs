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
    public partial class UserPaymentPage : System.Web.UI.Page
    {
        double totalamount = 0;
        int userid = 0;
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            totalamount = Convert.ToDouble(Request.QueryString["totalamount"].ToString());
            userid= Convert.ToInt32(Request.QueryString["userid"].ToString());
            dt = (DataTable)Session["dtcartforuser"];
        }

        protected void btncard_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            
            string str = "INSERT INTO orders (Order_user_id,Order_date,Pay_amount,Pay_method) VALUES (@orderuserid,@orderdate,@payamount, @paymethod)";
            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.Parameters.AddWithValue("@orderuserid", Convert.ToInt32(userid));
            cmd.Parameters.AddWithValue("@orderdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@payamount", Convert.ToDouble(totalamount));
            cmd.Parameters.AddWithValue("@paymethod", "Card");
            cmd.ExecuteNonQuery();
            MySqlCommand cmd1 = new MySqlCommand("select max(Order_id) from orders where Order_user_id = " + userid, con);
            int OrderId = (int)cmd1.ExecuteScalar();

            foreach (DataRow dr in dt.Rows)
            {
                //user_id = Convert.ToInt32(dr["User_ID"].ToString());
                int productId = Convert.ToInt32(dr["prod_id"].ToString());
                int quantityinusercart = Convert.ToInt32(dr["Quan_in_cart"].ToString());
                int produnits = Convert.ToInt32(dr["Prod_units"].ToString());
                double totalamount= Convert.ToDouble(dr["Total_amount"].ToString());
                string str1 = "INSERT INTO order_item (Item_prod_id,Item_order_id,Item_quan,Item_price) VALUES (@prodid,@orderid,@quan, @payamount)";
                MySqlCommand cmd2 = new MySqlCommand(str1, con);
                cmd2.Parameters.AddWithValue("@prodid", Convert.ToInt32(productId));
                cmd2.Parameters.AddWithValue("@orderid", Convert.ToInt32(OrderId));
                cmd2.Parameters.AddWithValue("@quan", Convert.ToInt32(quantityinusercart));
                cmd2.Parameters.AddWithValue("@payamount", Convert.ToDouble(totalamount));
                cmd2.ExecuteNonQuery();

                int produnitsupdate = produnits - quantityinusercart;
                //quantity in product table - quantity in cart table 
                //update prod table

                string str3 = "Update products set Prod_units= @produnitupdates where Prod_id=@prodid";
                MySqlCommand cmd4 = new MySqlCommand(str3, con);
                cmd4.Parameters.AddWithValue("@prodid", Convert.ToInt32(productId));
                cmd4.Parameters.AddWithValue("@produnitupdates", Convert.ToInt32(produnitsupdate));
                cmd4.ExecuteNonQuery();

            }

            string str2 = "delete from cart where Cart_user_id =" + userid;
            MySqlCommand cmd3 = new MySqlCommand(str2, con);
            cmd3.ExecuteNonQuery();
            Response.Redirect("afterLogin.aspx");
        }

        protected void btnCOD_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();

            string str = "INSERT INTO orders (Order_user_id,Order_date,Pay_amount,Pay_method) VALUES (@orderuserid,@orderdate,@payamount, @paymethod)";
            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.Parameters.AddWithValue("@orderuserid", Convert.ToInt32(userid));
            cmd.Parameters.AddWithValue("@orderdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@payamount", Convert.ToDouble(totalamount));
            cmd.Parameters.AddWithValue("@paymethod", "COD");
            cmd.ExecuteNonQuery();

            MySqlCommand cmd1 = new MySqlCommand("select max(Order_id) from orders where Order_user_id = " + userid, con);
            int OrderId = (int)cmd1.ExecuteScalar();

            foreach (DataRow dr in dt.Rows)
            {
                //user_id = Convert.ToInt32(dr["User_ID"].ToString());
                int productId = Convert.ToInt32(dr["prod_id"].ToString());
                int produnits = Convert.ToInt32(dr["Prod_units"].ToString());
                int quantityinusercart = Convert.ToInt32(dr["Quan_in_cart"].ToString());
                double totalamount = Convert.ToDouble(dr["Total_amount"].ToString());
                string str1 = "INSERT INTO order_item (Item_prod_id,Item_order_id,Item_quan,Item_price) VALUES (@prodid,@orderid,@quan, @payamount)";
                MySqlCommand cmd2 = new MySqlCommand(str1, con);
                cmd2.Parameters.AddWithValue("@prodid", Convert.ToInt32(productId));
                cmd2.Parameters.AddWithValue("@orderid", Convert.ToInt32(OrderId));
                cmd2.Parameters.AddWithValue("@quan", Convert.ToInt32(quantityinusercart));
                cmd2.Parameters.AddWithValue("@payamount", Convert.ToDouble(totalamount));
                cmd2.ExecuteNonQuery();


                int produnitsupdate = produnits - quantityinusercart;
                string str3 = "Update products set Prod_units= @produnitupdates where Prod_id=@prodid";
                MySqlCommand cmd4 = new MySqlCommand(str3, con);
                cmd4.Parameters.AddWithValue("@prodid", Convert.ToInt32(productId));
                cmd4.Parameters.AddWithValue("@produnitupdates", Convert.ToInt32(produnitsupdate));
                cmd4.ExecuteNonQuery();

            }

            string str2 = "delete from cart where Cart_user_id =" + userid;
            MySqlCommand cmd3 = new MySqlCommand(str2, con);
            cmd3.ExecuteNonQuery();
            Response.Redirect("afterLogin.aspx");
        }

        protected void imgbtnlogout3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void imgbtncart3_Click(object sender, ImageClickEventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Email from user where user_id = '" + userid + "'", con);
            string userEmail = (string)cmd.ExecuteScalar();
            Response.Redirect("UserCartView.aspx?sessionid=" + userEmail);
        }

        protected void imgbtnprofile3_Click(object sender, ImageClickEventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Email from user where user_id = '" + userid + "'", con);
            string userEmail = (string)cmd.ExecuteScalar();
            Response.Redirect("UserProfilePage.aspx?sessionid=" + userEmail);
        }

        protected void lblstorename5_Click(object sender, EventArgs e)
        {
            Response.Redirect("afterLogin.aspx");
        }
    }
}