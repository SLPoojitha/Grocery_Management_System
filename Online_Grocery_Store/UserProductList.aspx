<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProductList.aspx.cs" Inherits="Online_Grocery_Store.UserProductList" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" href="UserProdList.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="first">
<%--            <h1 class="name"><asp:Label ID="lblstorename1" runat="server" Text="STORE NAME"></asp:Label></h1>--%>
<%--            <asp:HyperLink ID="HyperLink1" runat="server">STORE NAME</asp:HyperLink>--%>
            <h1 class="name"><asp:LinkButton ID="lblstorename1" runat="server" OnClick="lblstorename1_Click" >Groceteria</asp:LinkButton></h1>
<%--     <h1 class="name">Groceteria</h1>--%>
      <asp:ImageButton ID="imgbtnprofile2" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/profile.png" OnClick="imgbtnprofile2_Click" />
      <asp:ImageButton ID="imgbtncart2" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/cart.png" OnClick="imgbtncart2_Click"  />
      <asp:ImageButton ID="imgbtnlogout2" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/logout.png" OnClick="imgbtnlogout2_Click" />
    </div>
        <br />
        <br />
        <div>
            <asp:GridView runat="server" ID="gdImage" HeaderStyle-BackColor="Tomato" height="100px"  AutoGenerateColumns="false" HorizontalAlign="Center"
                CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows" >  
                <Columns>  
                    <asp:BoundField DataField="Prod_id" HeaderText="ProductID" />  
                    <asp:BoundField DataField="Prod_name" HeaderText="ProductName" />  
                    <asp:BoundField DataField="Prod_price" HeaderText="ProductPrice" />  
                    <asp:ImageField DataImageUrlField="Prod_picture" HeaderText="ProductPicture"></asp:ImageField> 
                    <asp:BoundField DataField="Prod_desc" HeaderText="ProductDescription" />  
                    <asp:BoundField DataField="Prod_units" HeaderText="ProductUnits" />
                  <asp:TemplateField HeaderText="Quantity">
                  <ItemTemplate>
                  <asp:TextBox ID="txtuserquantity" runat="server"></asp:TextBox>
                  </ItemTemplate>
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                  <ItemTemplate>
                  <asp:Button ID="btnaddusercart" runat="server" type="button"  Text="Add To Cart" CommandName="Add To Cart" CommandArgument="<%# Container.DataItemIndex %>" onclick="btnaddusercart_Click" />
                  </ItemTemplate>
                 </asp:TemplateField>
                </Columns>  
            </asp:GridView>  
        </div>
    </form>
</body>
</html>
