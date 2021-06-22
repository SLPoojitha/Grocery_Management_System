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
    public partial class UserCartView : System.Web.UI.Page
    {
        double TotalTobePaid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string useremailid = Request.QueryString["sessionid"].ToString();

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            string query = "select prod_id, prod_name, prod_price, Quan_in_cart, Total_amount from cart C, products P, user U where C.Cart_prod_id = P.Prod_id and C.Cart_user_id = U.User_ID and U.Email = '" + useremailid + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            grdusercartview.DataSource = sdr;
            grdusercartview.DataBind();
            double tempamount = 0;
            foreach (GridViewRow gridrow in grdusercartview.Rows)
            {
             
                double totalpayableamount = Convert.ToDouble(gridrow.Cells[5].Text);
              //  tempamount = totalpayableamount;
                TotalTobePaid = tempamount + totalpayableamount;
                tempamount = TotalTobePaid;

                payableamount.Text = TotalTobePaid.ToString();

            }
            con.Close();
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grdusercartview.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdusercartview.Rows[e.RowIndex];
            int prodid = Convert.ToInt32(grdusercartview.DataKeys[e.RowIndex].Values[0]);
           
            string productname = (row.Cells[2]).Text;
            string productprice = (row.Cells[3]).Text;
            double prdprice = Convert.ToDouble(productprice);
            string quantityincart = (row.Cells[4].Controls[0] as TextBox).Text;
            int quantincart = Convert.ToInt32(quantityincart);
            // string totalamount = (row.Cells[4].Controls[0] as TextBox).Text;
            double totalamt = prdprice * quantincart;
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE cart SET Quan_in_cart = @quantityincart, Total_amount = @totalamount WHERE Cart_prod_id = @prodid"))
                {
                    cmd.Parameters.AddWithValue("@quantityincart", quantincart);
                    cmd.Parameters.AddWithValue("@totalamount", totalamt);
                    cmd.Parameters.AddWithValue("@prodid", prodid);
                    
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            grdusercartview.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            grdusercartview.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int prodid = Convert.ToInt32(grdusercartview.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE Cart_prod_id = @Cartprodid"))
                {
                    cmd.Parameters.AddWithValue("@Cartprodid", prodid);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdusercartview.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void btnbuyproduct_Click(object sender, EventArgs e)
        {
            int user_id = 0;
            int quantityinusercart = 0;
            bool usercartquantityflag = true;
            string useremailid = Request.QueryString["sessionid"].ToString();
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            string query = "select prod_id, Quan_in_cart, Prod_units, Total_amount, User_ID  from cart C, products P, user U where C.Cart_prod_id = P.Prod_id and C.Cart_user_id = U.User_ID and U.Email = '" + useremailid + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                user_id = Convert.ToInt32(dr["User_ID"].ToString());
                int productId = Convert.ToInt32(dr["prod_id"].ToString());
                quantityinusercart= Convert.ToInt32(dr["Quan_in_cart"].ToString());
                string query1 = "select Prod_id, Prod_units  from products where Prod_id=" + productId;
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                foreach(DataRow dr1 in dt1.Rows)
                {
                    int Productunits= Convert.ToInt32(dr1["Prod_units"].ToString());
                    if(Productunits-quantityinusercart<=0)
                    {
                        usercartquantityflag = false;
                        break;
                       
                    }

                }

                if (usercartquantityflag == false)
                    break;
            }

            if (usercartquantityflag)
            //Response.Redirect("UserPaymentPage.aspx?");
            {
                Session["dtcartforuser"] = dt;
                if (quantityinusercart != 0)
                {
                    Response.Redirect("UserPaymentPage.aspx?totalamount=" + payableamount.Text + "&userid=" + user_id.ToString() + "&session=" + Session["dtcartforuser"].ToString());
                }
                // no records in cart table
                else 
                {
                    //btnbuyproduct.Enabled = false;
                }
            }
                
            
            else
                lblquantitylessorzero.Text = "Quantity added in cart is no longer available. Please check Product list";
           
            //  MySqlDataReader sdr = cmd.ExecuteReader();
        }

        protected void imgbtnlogout1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void imgbtnprofile1_Click(object sender, ImageClickEventArgs e)
        {
            string useremailid = Request.QueryString["sessionid"].ToString();
            Response.Redirect("UserProfilePage.aspx?sessionid=" + useremailid);
        }

        protected void lblstorename7_Click(object sender, EventArgs e)
        {
            Response.Redirect("afterLogin.aspx");
        }
    }
}