<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Online_Grocery_Store.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="login.css" rel="stylesheet" type ="text/css"/>
</head>
<body>
    <div class="first">
      <h1 class="h1">Groceteria</h1>
    </div>
    <form id="form1" runat="server">
        <div class="box">
            <img src="profile icon.jpg" width="100" height="100" />
            <br />
            <br />
            <asp:TextBox ID="txtusername" runat="server" placeholder="Email" class="Email" required="true" CausesValidation="True"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="txtpass" runat="server" placeholder="Password" class="Password" required="true" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnloginsubmit" runat="server" Text="Submit" type="submit" value="Login" class="button" OnClick="btnloginsubmit_Click" />
            <br />
            <br />
            <asp:Label ID="lblinvalidusernameandpass" runat="server" ForeColor="Red" Text="Invalid Username or Password"></asp:Label>
        </div>
    </form>
</body>
</html>
