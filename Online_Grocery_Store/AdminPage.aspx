<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Online_Grocery_Store.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="admin.css" rel="stylesheet" type ="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
     <div class="first">
         <br/>
      <h1 class="h1">Groceteria</h1>
      <asp:ImageButton ID="imgbtn" runat="server" class="b1"  Height="28px" Width="28px" padding-top="1px" ImageUrl="~/logout.png" OnClick="imgbtn_Click"  /> 

        </div>
         <br />
    <br />
    <img src="admin_image.jpg" class="image" />
        <br />
    <br />
    <br />
       <asp:Button ID="btnviewuserlist" runat="server" type="button" class="b2" Text="Customer List" OnClick="btnviewuserlist_Click" />
       <asp:Button ID="btnaddproduct" runat="server" type="button" class="b4" Text="Add Product" OnClick="btnaddproduct_Click" />
       <asp:Button ID="btnviewproductlist" runat="server" type="button" class="b3" Text="Product List" OnClick="btnviewproductlist_Click" />
    </form>
</body>
</html>

