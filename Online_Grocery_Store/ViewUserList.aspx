<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUserList.aspx.cs" Inherits="Online_Grocery_Store.ViewUserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="viewuserlist.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="first">
            <br />
        <h1 class="h1"><asp:LinkButton ID="lblstorename3" runat="server" OnClick="lblstorename3_Click" >Groceteria</asp:LinkButton></h1>
      <asp:ImageButton ID="btnadminlogout1" runat="server" class="b1"  Height="28px" Width="28px" padding-top="1px" ImageUrl="~/logout.png" OnClick="btnadminlogout1_Click" /> 

        </div>
         <br />
        <br />
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"
                CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" 
                RowStyle-CssClass="rows" />
    </form>
</body>
</html>
