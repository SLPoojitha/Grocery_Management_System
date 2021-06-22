<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="afterLogin.aspx.cs" Inherits="Online_Grocery_Store.afterLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> afterLogin page</title>
    <link href="home_new.css" rel="stylesheet" type ="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="first">
      <p class="p1">
          Welcome, 
         <asp:Label ID="lblsessionname" runat="server"></asp:Label>
      </p>
     
      <h1 class="name">Groceteria</h1>  
      <%--<asp:Label ID="lblsessionname" runat="server"></asp:Label>  --%>  
         <asp:ImageButton ID="imgbtncart" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/cart.png" OnClick="imgbtncart_Click" />
<%--      <asp:Button ID="btncart" runat="server" Text="Cart" type="button" value="cart" class="cart" OnClick="btncart_Click"  />--%>
         <asp:ImageButton ID="imgbtnprofile" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/profile.png" OnClick="imgbtnprofile_Click" />
          <asp:ImageButton ID="imgbtnlogout" runat="server" class="profile" Height="21px" Width="21px" padding-top="1px" ImageUrl="~/logout.png" OnClick="imgbtnlogout_Click" />


<%--      <asp:Button ID="btneditprofile" runat="server" Text="Edit Profile" type="button" value="editprofile" class="editprofile" OnClick="btneditprofile_Click"  />--%>
    </div>
    <br />
<%--    <div class="second">
      <h3 class="h3">Search for Products</h3>
      <%--<input type="text" class="text" />--%>
<%--        <asp:TextBox ID="txtsearchbox" runat="server" type="text" class="text" ></asp:TextBox>
      <asp:Button ID="btnsearch" runat="server" type="button" class="button" Text="Search" />--%>
<%--      </div>--%>
    <br />
    <div class="third">
      <h2 class="h31">Categories</h2>
      <asp:Button ID="btnfruits" runat="server" type="button" class="fruits" Text="Fruits" OnClick="btnfruits_Click" /><br /><br />
      <asp:Button ID="btnvegetables" runat="server" type="button" class="vegetables" Text="Vegetables" OnClick="btnvegetables_Click" /><br /><br />
      <asp:Button ID="btnbeverages" runat="server" type="button" class="beverages" Text="Beverages" OnClick="btnbeverages_Click" /><br /><br />
      <asp:Button ID="btndairy" runat="server" type="button" class="dairy" Text="Dairy" OnClick="btndairy_Click" /><br /><br />
      <asp:Button ID="btncleaning" runat="server" type="button" class="clean" Text="Cleaning Supplies" OnClick="btncleaning_Click" /><br /><br />
      <asp:Button ID="btnpersonalcare" runat="server" type="button" class="care" Text="Personal Care" OnClick="btnpersonalcare_Click" /><br /><br />
      <asp:Button ID="btnpapergoods" runat="server" type="button" class="others" Text="Paper goods" OnClick="btnpapergoods_Click" /><br /><br />
      <asp:Button ID="btndrygoods" runat="server" type="button" class="others" Text="Dry goods" OnClick="btndrygoods_Click" /><br /><br />
      <asp:Button ID="btnstationary" runat="server" type="button" class="others" Text="Stationary" OnClick="btnstationary_Click" /><br /><br />
      </div>
      <img src="slider1.png" class="mySlides" />
      <img src="slider2.png" class="mySlides" />
      <img src="slider3.png" class="mySlides" />
      <script>
        var slideIndex = 0;
        showSlides();
        function showSlides() {
          var i;
          var slides = document.getElementsByClassName("mySlides");
          for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
          }
          slideIndex++;
          if (slideIndex > slides.length) {slideIndex = 1}
          slides[slideIndex-1].style.display = "block";
          setTimeout(showSlides, 2000); // Change image every 2 seconds
        }
      </script>
      <br />
      <br />
    </form>
</body>
</html>
