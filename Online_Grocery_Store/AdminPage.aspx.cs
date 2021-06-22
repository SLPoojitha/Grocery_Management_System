using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Grocery_Store
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnviewuserlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUserList.aspx");
        }

        protected void btnaddproduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void btnviewproductlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductList.aspx");
        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnaddcategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }
    }
}