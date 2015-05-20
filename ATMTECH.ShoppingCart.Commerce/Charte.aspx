<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charte.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Charte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            
            <a href="Default.aspx">

                <img src="Images/WebSite/logo.png" />
            </a>

            <br/>
            
            <asp:Button ID="btnRevenirProduit" runat="server" OnClick="btnRevenirAccueilClick" Text="Revenir au produit | Return to product" CssClass="boutonActionRond" /><br />
            <br/>
            <asp:Image runat="server" ID="imgCharte" />
        </div>
    </form>
</body>
</html>
