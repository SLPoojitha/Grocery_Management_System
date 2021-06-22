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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlcategoryname.Items.Add(new ListItem("--Select Category Name--", ""));
                ddlcategoryname.AppendDataBoundItems = true;
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select Cat_id, Cate_name from category", con);
                try
                {

                    ddlcategoryname.DataSource = cmd.ExecuteReader();
                    ddlcategoryname.DataTextField = "Cate_name";
                    ddlcategoryname.DataValueField = "Cate_name";
                    ddlcategoryname.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnaddprodsubmit_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            string filename;
            string Image = null;
            string str = "INSERT INTO products (Prod_cat_id,Prod_name,Prod_price,Prod_picture,Prod_desc,Prod_units) VALUES (@prodcatid,@prodname,@prodprice, @prodpicture,@proddesc,@produnits)";
            MySqlCommand cmd = new MySqlCommand(str, con);
            cmd.Parameters.AddWithValue("@prodcatid", txtaddprodcatid.Text);
            cmd.Parameters.AddWithValue("@prodname", txtaddprodname.Text);
            cmd.Parameters.AddWithValue("@prodprice", Convert.ToDouble(txtaddprodprice.Text));
            if (FileUpload1.HasFile)
            {
                filename = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + filename));
                Image = "~/Upload/" + filename.ToString();

            }
            cmd.Parameters.AddWithValue("@prodpicture", Image);
            cmd.Parameters.AddWithValue("@proddesc", txtaddproddesc.Text);
            cmd.Parameters.AddWithValue("@produnits", Convert.ToInt32(txtaddprodunits.Text));
            cmd.ExecuteNonQuery();
            Response.Redirect("AdminPage.aspx");

        }

        protected void ddlcategoryname_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select Cat_id from category where Cate_name=@cateroryname ", con);
            cmd.Parameters.AddWithValue("@cateroryname", ddlcategoryname.SelectedItem.Value);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
                
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txtaddprodcatid.Text = sdr[0].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}