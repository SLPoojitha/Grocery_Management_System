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
    public partial class ViewProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select Prod_id,Prod_name,Prod_price,Prod_desc,Prod_units from products", con);
            MySqlDataReader sdr = cmd.ExecuteReader();
            grdviewproductlist.DataSource = sdr;
            grdviewproductlist.DataBind();
            con.Close();
        }
            protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grdviewproductlist.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdviewproductlist.Rows[e.RowIndex];
            int productid = Convert.ToInt32(grdviewproductlist.DataKeys[e.RowIndex].Values[0]);
            string productname = (row.Cells[2].Controls[0] as TextBox).Text;
            string productprice = (row.Cells[3].Controls[0] as TextBox).Text;
            double prdprice = Convert.ToDouble(productprice);
            string productdesc = (row.Cells[4].Controls[0] as TextBox).Text;
            string productunits = (row.Cells[5].Controls[0] as TextBox).Text;
            int prdunits = Convert.ToInt32(productunits);
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE products SET Prod_name = @productname, Prod_price = @productprice,Prod_desc=@productdesc,Prod_units=@productunits WHERE Prod_id = @productid"))
                {
                    cmd.Parameters.AddWithValue("@productid", productid);
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@productprice", prdprice);
                    cmd.Parameters.AddWithValue("@productdesc", productdesc);
                    cmd.Parameters.AddWithValue("@productunits", prdunits);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            grdviewproductlist.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            grdviewproductlist.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int prodid = Convert.ToInt32(grdviewproductlist.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM products WHERE Prod_id = @prodid"))
                {
                    cmd.Parameters.AddWithValue("@prodid", prodid);
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
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdviewproductlist.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void btnadminlgout2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lblstorename2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}