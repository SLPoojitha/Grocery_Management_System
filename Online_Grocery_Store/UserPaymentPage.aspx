<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPaymentPage.aspx.cs" Inherits="Online_Grocery_Store.UserPaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="payment.css" rel="stylesheet" />
    <script type="text/javascript" src="payment.js"></script>
</head>
<body>
    <form id="formnew" runat="server">

      <div class="first">
            <h1 class="name"><asp:LinkButton ID="lblstorename5" runat="server" OnClick="lblstorename5_Click" >Groceteria</asp:LinkButton></h1>
      <asp:ImageButton ID="imgbtnprofile3" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/profile.png" OnClick="imgbtnprofile3_Click" />
      <asp:ImageButton ID="imgbtncart3" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/cart.png" OnClick="imgbtncart3_Click"  />
      <asp:ImageButton ID="imgbtnlogout3" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/logout.png" OnClick="imgbtnlogout3_Click"  />
    </div>
        <br />
        <br />
        <br />
        <div class="second">
            <h3 id="pay"><asp:Label ID="lbpayusing" runat="server" Text="Pay using : "></asp:Label></h3>
            <div class="card">
                <button type="button" class="b1" onclick="card()">Card</button>
             </div>
            <div class="cod">
                <button type="button" class="b2" onclick="cod()">COD</button>
            </div>
        </div>
        <div id="box1">
            <p class="fp11">
              Card Number:
              </p>
        <asp:TextBox ID="txtcardnumber" runat="server" type="text" class="fi11"></asp:TextBox>
            
            <p class="fp12">
              Name on Card:
              </p>
            <asp:TextBox ID="txtnameoncard" runat="server" type="text"  class="fi12"></asp:TextBox>
            <p class="fp13">
              CVV/CCV:
              </p>
            <asp:TextBox ID="txtcvv" runat="server" type="text"  class="fi13"></asp:TextBox>
            <p class="fp15">
              Expiry Date:
            </p>
            <asp:TextBox ID="txtexpirydate" runat="server" type="text"  placeholder="mm-yyyy" class="fi15"></asp:TextBox>
            <%--<p class="fp14">
              Amount:
              </p>
          <input type="text" class="fi14" >--%>
            <br />
            <p class="fp16">
              Address:
              </p>
            <asp:TextBox ID="txtdeliveryaddress" runat="server" type="text" Width="200px" height="27px" class="fi16" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="btncard" runat="server" Text="Place Order" class="ph1" OnClick="btncard_Click" />
        </div>
          <div id="box2">
          <p class="fp21">
            First Name:
            </p>
          <asp:TextBox ID="txtnamefordelivery" runat="server" type="text" class="fi21"></asp:TextBox>
          <p class="fp22">
            Address:
            </p>
            <asp:TextBox ID="textdeliveryaddress2" runat="server" type="text" Width="200px" height="27px" class="fi16" TextMode="MultiLine"></asp:TextBox>
          <br />
          <asp:Button ID="btnCOD" runat="server" Text="Place Order" class="ph1" OnClick="btnCOD_Click" />
          </div>
        <img src="pay.jpg" id="img" />
            
    </form>
</body>
</html>
