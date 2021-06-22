using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Grocery_Store
{
    public partial class afterLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblsessionname.Text = Session["id"].ToString();
           
        }

        protected void imgbtncart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserCartView.aspx?sessionid=" + Session["id"].ToString());
        }

        protected void imgbtnprofile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserProfilePage.aspx?sessionid=" + Session["id"].ToString());
        }

        protected void imgbtnlogout_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnfruits_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Fruits" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btnbeverages_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Beverages" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btndairy_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Diary" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btnvegetables_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Vegetables" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btncleaning_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Cleaning Supplies" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btnpersonalcare_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Personal Care" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btnpapergoods_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Paper Goods" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btndrygoods_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Dry Goods" + "&sessionid=" + Session["id"].ToString());
        }

        protected void btnstationary_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProductList.aspx?name=Stationary" + "&sessionid=" + Session["id"].ToString());
        }

    }
}