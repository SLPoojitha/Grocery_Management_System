<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Online_Grocery_Store.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
     <link href="home.css" rel="stylesheet" type ="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
     <div class="first">
      <br />
      <h1 class="name">Groceteria</h1>
      <asp:Button ID="btnlogin" runat="server" Text="Login" type="button" value="Login" class="login" OnClick="btnlogin_Click" />
      <asp:Button ID="btnreg" runat="server" Text="Sign up" type="button" value="Signup" class="signup" OnClick="btnreg_Click" />
    </div>
    <br />
<%--    <div class="second">
      <h3 class="h3">Search for Products</h3>
      <input type="text" class="text" />
      <button type="button" class="button">Search</button>
      </div>--%>
    <br />
    <div class="third">
      <h2 class="h31">Categories</h2>
      <button type="button" class="fruits">Fruits</button><br /><br />
      <button type="button" class="vegetables">Vegetables</button><br /><br />
      <button type="button" class="beverages">Beverages</button><br /><br />
      <button type="button" class="dairy">Diary</button><br /><br />
      <button type="button" class="clean">Cleaning Supplies</button><br /><br />
      <button type="button" class="care">Personal Care</button><br /><br />
      <button type="button" class="others">Paper Goods</button><br /><br />
        <button type="button" class="others">Dry goods</button><br /><br />
        <button type="button" class="others">Stationary</button><br /><br />
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
