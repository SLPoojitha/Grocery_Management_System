<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Online_Grocery_Store.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="signup.css" rel="stylesheet" type ="text/css"/>
    <script type="text/javascript" src="signup.js"></script>
</head>
<body>
    <div class="f1">
      <h1 class="h1">Groceteria</h1>
    </div>
    <form id="form1" runat="server">
       <div class="box">
           <h1>Add product</h1>
         <p>
         Please fill the details of new product!
        </p>
           <asp:DropDownList ID="ddlcategoryname" runat="server" placeholder="Category Name" class="CategoryName" required="true" AutoPostBack = "true"
          OnSelectedIndexChanged="ddlcategoryname_SelectedIndexChanged">
    </asp:DropDownList>
            <br />
           <br />
<%--            <asp:Label ID="lbcreatenew" runat="server" Text="Create New Account"></asp:Label>--%>
            
<%--            <asp:Label ID="lbcrname" runat="server" Text="Name"></asp:Label>--%>
            <asp:TextBox ID="txtaddprodcatid" runat="server" type="text" placeholder="Category id" class="First" required="true"></asp:TextBox>
            <br />
           <br />
<%--            <asp:Label ID="lbcrusername" runat="server" Text="Username"></asp:Label>--%>
            <asp:TextBox ID="txtaddprodname" runat="server" type="text" placeholder="Product name" class="Last"></asp:TextBox>
            <br />
           <br />
           <%--            <asp:Label ID="lbcrstate" runat="server" Text="State"></asp:Label>--%>
            <asp:TextBox ID="txtaddprodprice" runat="server" type="text" placeholder="Price" class="state" required="true"></asp:TextBox>

          
           <%--            <asp:Label ID="lbcrcountry" runat="server" Text="Country"></asp:Label>--%>
            <asp:TextBox ID="txtaddprodunits" runat="server" type="text" placeholder="Units" class="country" required="true"></asp:TextBox>
            <br />
           <br />
                       <asp:Label ID="lbluploadpic" runat="server" class="Last" Text="Upload Product Picture"></asp:Label>
           <br />
                   <asp:FileUpload ID="FileUpload1" runat="server" required="true" />           
           <br />
           <br />

           <%--            <asp:Label ID="lbcremail" runat="server" Text="Email"></asp:Label>--%>
            <asp:TextBox ID="txtaddproddesc" runat="server" type="address" placeholder="Description" class="Address" required="true" TextMode="MultiLine"></asp:TextBox>            <br />
           <br />
            <asp:Button ID="btnaddprodsubmit" runat="server" type="submit" class="button" Text="Add" OnClick="btnaddprodsubmit_Click"   />
           <br />
           <%--<asp:FileUpload ID="FileUpload1" runat="server" required="true" /> --%> 
        </div>
    </form>
</body></html>
