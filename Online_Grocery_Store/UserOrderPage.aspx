<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderPage.aspx.cs" Inherits="Online_Grocery_Store.UserOrderPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="cart.css" rel="stylesheet" type ="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="first">
     
            <h1 class="name"><asp:LinkButton ID="lblstorename6" runat="server" OnClick="lblstorename6_Click" >Groceteria</asp:LinkButton></h1>
      <%--<asp:Label ID="lblsessionname" runat="server"></asp:Label>  --%>  
         <asp:ImageButton ID="imgbtncart4" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/cart.png" OnClick="imgbtncart4_Click" />
<%--      <asp:Button ID="btncart" runat="server" Text="Cart" type="button" value="cart" class="cart" OnClick="btncart_Click"  />--%>
         <asp:ImageButton ID="imgbtnprofile4" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/profile.png" OnClick="imgbtnprofile4_Click"  />
          <asp:ImageButton ID="imgbtnlogout4" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/logout.png" OnClick="imgbtnlogout4_Click"  />


<%--      <asp:Button ID="btneditprofile" runat="server" Text="Edit Profile" type="button" value="editprofile" class="editprofile" OnClick="btneditprofile_Click"  />--%>
    </div>
        <br />
        <div>
        </div>
        <asp:GridView ID="Grdorder" runat="server" HorizontalAlign="Center"
                CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" EmptyDataText="No order History" />
    </form>
</body>
</html>
