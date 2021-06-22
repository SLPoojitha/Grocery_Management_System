using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Grocery_Store
{
    public partial class UserProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Request.QueryString["name"].ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            string query = "select Prod_id, Prod_name, Prod_price, Prod_picture, Prod_desc, Prod_units from products, category where category.cate_name= " + "'" + str + "'"+ " and category.cat_id=products.prod_cat_id";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gdImage.DataSource = dt;
            gdImage.DataBind();
        }

        protected void btnaddusercart_Click(object sender, EventArgs e)
        {
            
            string useremailid = Request.QueryString["sessionid"].ToString();
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int rowindex = gvRow.RowIndex;
            GridViewRow row = gdImage.Rows[rowindex];
            int productid = Convert.ToInt32(row.Cells[0].Text);
            TextBox txtuserquantity = (TextBox)gvRow.FindControl("txtuserquantity");
            int productquantityincart = Convert.ToInt32(txtuserquantity.Text);
            int prodprice= Convert.ToInt32(row.Cells[2].Text);
            double totalamount = productquantityincart * Convert.ToDouble(prodprice);

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();


            MySqlCommand cmd = new MySqlCommand("select user_id from user where Email = '" + useremailid + "'", con);
            int userID = (int)cmd.ExecuteScalar();

            //MySqlCommand cmd1 = null;
            int cartprodid = 0;
            int quantityincart = 0;
            double total_amount = 0.00;
            DataTable dt = new DataTable();
            bool flag = false;
           
                string strcmd1 = "select Cart_prod_id,Quan_in_cart,Total_amount from CART where Cart_user_id = " + userID + "";
                MySqlCommand cmd1 = new MySqlCommand(strcmd1, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

                da.Fill(dt);
           
              if(dt.Rows.Count>0)
             {
                foreach (DataRow dtrow in dt.Rows)
                {
                    cartprodid = Convert.ToInt32(dtrow["Cart_prod_id"]);
                    quantityincart = Convert.ToInt32(dtrow["Quan_in_cart"]);
                    total_amount = Convert.ToDouble(dtrow["Total_amount"]);
                    if(productid == cartprodid)
                    {
                        flag = true;
                        break;

                    }

                }
                    if (productid == cartprodid && flag==true)
                    {

                        MySqlCommand cmd2 = new MySqlCommand("Update CART set Quan_in_cart=@quantityincart, Total_amount=@totalamount where Cart_prod_id=@productid and Cart_user_id= @userID ", con);
                        cmd2.Parameters.AddWithValue("@quantityincart", quantityincart + productquantityincart);
                        cmd2.Parameters.AddWithValue("@totalamount", totalamount + total_amount);
                        cmd2.Parameters.AddWithValue("@productid", productid);
                        cmd2.Parameters.AddWithValue("@userID", userID);
                        cmd2.Connection = con;
                        cmd2.ExecuteNonQuery();
                        con.Close();

                    }

                    else
                    {
                        string str = "INSERT INTO CART (Cart_user_id,Cart_prod_id,Quan_in_cart,Total_amount) VALUES (@cartuserid,@cartprodid,@quantityincart,@Totalamount)";
                        MySqlCommand cmd3 = new MySqlCommand(str, con);
                        cmd3.Parameters.AddWithValue("@cartuserid", userID);
                        cmd3.Parameters.AddWithValue("@cartprodid", productid);
                        cmd3.Parameters.AddWithValue("@quantityincart", productquantityincart);
                        cmd3.Parameters.AddWithValue("@Totalamount", totalamount);
                        cmd3.ExecuteNonQuery();
                    }
                
            }

            else
            {

                string str = "INSERT INTO CART (Cart_user_id,Cart_prod_id,Quan_in_cart,Total_amount) VALUES (@cartuserid,@cartprodid,@quantityincart,@Totalamount)";
                MySqlCommand cmd3 = new MySqlCommand(str, con);
                cmd3.Parameters.AddWithValue("@cartuserid", userID);
                cmd3.Parameters.AddWithValue("@cartprodid", productid);
                cmd3.Parameters.AddWithValue("@quantityincart", productquantityincart);
                cmd3.Parameters.AddWithValue("@Totalamount", totalamount);
                cmd3.ExecuteNonQuery();
            }
        }

        protected void gdImage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgbtnlogout2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void imgbtncart2_Click(object sender, ImageClickEventArgs e)
        {
            string useremailid = Request.QueryString["sessionid"].ToString();
            Response.Redirect("UserCartView.aspx?sessionid=" + useremailid);
        }

        protected void imgbtnprofile2_Click(object sender, ImageClickEventArgs e)
        {
            string useremailid = Request.QueryString["sessionid"].ToString();
            Response.Redirect("UserProfilePage.aspx?sessionid=" + useremailid);
        }

        protected void lblstorename1_Click(object sender, EventArgs e)
        {
            Response.Redirect("afterLogin.aspx");
        }
    }
}