<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Online_Grocery_Store.Register" %>

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
           <h1>Sign Up</h1>
         <p>
         Please fill the details to create an account!
        </p>
           
<%--            <asp:Label ID="lbcreatenew" runat="server" Text="Create New Account"></asp:Label>--%>
            
<%--            <asp:Label ID="lbcrname" runat="server" Text="Name"></asp:Label>--%>
            <asp:TextBox ID="txtcrfname" runat="server" type="text" placeholder="First Name" class="First" required="true"></asp:TextBox>
            <br />
           <br />
<%--            <asp:Label ID="lbcrusername" runat="server" Text="Username"></asp:Label>--%>
            <asp:TextBox ID="txtcrlname" runat="server" type="text" placeholder="Last Name" class="Last"></asp:TextBox>
            <br />
           <br />
<%--             <asp:Label ID="lbcrpass" runat="server" Text="Password"></asp:Label>--%>
            <asp:TextBox ID="txtcraddress" runat="server" type="address" placeholder="Address" class="Address" required="true" TextMode="MultiLine"></asp:TextBox>
            <br />
           <br />
           <%--            <asp:Label ID="lbcrstate" runat="server" Text="State"></asp:Label>--%>
            <asp:TextBox ID="txtcrstate" runat="server" type="text" placeholder="State" class="state" required="true"></asp:TextBox>

<%--            <asp:Label ID="lbcrcountry" runat="server" Text="Country"></asp:Label>--%>
            <asp:TextBox ID="txtcrcountry" runat="server" type="text" placeholder="Country" class="country" required="true"></asp:TextBox>
            <br />
           <br />
           <%--            <asp:Label ID="lbcremail" runat="server" Text="Email"></asp:Label>--%>
            <asp:TextBox ID="txtcremail" runat="server" type="email" placeholder="Email" class="Email" required="true"></asp:TextBox>
            <br />
           <br />
<%--            <asp:Label ID="lbcrpass" runat="server" Text="Password"></asp:Label>--%>
            <asp:TextBox ID="txtcrpass" runat="server" type="password" placeholder="Password" class="Password" required="true"></asp:TextBox>
            <br />
           <br />

<%--            <asp:Label ID="lbcrmobile" runat="server" Text="Mobile no."></asp:Label>--%>
            <asp:TextBox ID="txtcrcnfpass" runat="server" type="password" placeholder="Confirm Password" class="Confirm" required="true"></asp:TextBox>
            <br />
           <br />
          <%-- <asp:CheckBox ID="chkcrpolicy" runat="server" type="checkbox" class="check" required="true" />--%>
           <input type="checkbox" class="check" required="" />
           <p class="one">
        I accept the Terms of Use & Privacy Policy.
        </p>
           <br />
           <br />
            <asp:Button ID="btncrsubmit" runat="server" type="submit" class="button" Text="Submit" OnClick="btncrsubmit_Click" OnClientClick="validate()"  />
        </div>
    </form>
</body>
</html>
