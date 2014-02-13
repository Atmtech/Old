<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaypalTestPage.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.PaypalTestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ImageButton runat="server" ID="btnPaypal" AlternateText="checkout with paypal" ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" OnClick="TestPaypal" /><br><br>This will show the checkout with Paypal button on the page. Below is the onClick event handler code:<br><br>
    <asp:button runat="server" ID="btnUps" OnClick="TestUps" Text="test ups" />
    </div>
    </form>
</body>
</html>
