<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Test" %>

<%@ Register TagPrefix="adresse" TagName="selectionneradresse" Src="~/UserControls/SelectionnerAdresse.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/Site.css" rel="stylesheet" type="text/css" />
    <link href="JQuery/jquery-ui-1.11.2/css/lightbox.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/jquery-ui.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/jquery-ui.custom.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/ComboBox.css" rel="stylesheet" />
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/external/jquery/jquery.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/jquery-ui.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/ComboBox.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/autoNumeric.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/js/lightbox.min.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/js/jssor.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/js/jssor.slider.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <adresse:selectionneradresse ID="adresseLivraison" runat="server" />

        </div>
    </form>
</body>
</html>
