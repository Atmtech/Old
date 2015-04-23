<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ATMTECH.Administration.Commerce.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Site.css" rel="stylesheet" type="text/css" />
    <link href="JQuery/jquery-ui-1.11.2/jquery-ui.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/ComboBox.css" rel="stylesheet" />
    <script src="JQuery/jquery-ui-1.11.2/external/jquery/jquery.js"></script>
    <script src="JQuery/jquery-ui-1.11.2/jquery-ui.js"></script>
    <script src="JQuery/jquery-ui-1.11.2/ComboBox.js"></script>
    <script src="JQuery/jquery-ui-1.11.2/PriceFormat.js"></script>
    <script src="JQuery/jquery-ui-1.11.2/autoNumeric.js"></script>
</head>
<body>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/Utilitaires.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery.MultiFile.js") %>"></script>

    <%-- Envoyer true à la fonction GererExpiration pour l'affichage du temps restant en bas de page. --%>
    <script type="text/javascript">
        $(function () {
            InitialiserExpiration(20, '<%=ResolveUrl("~/Errors/SessionTimeout.htm")%>', false);
            $("#lnkImprimer").click(function () {
                $('#impression').jqprint();
                return false;
            });
        });
    </script>

    <form id="form1" runat="server">
        <div>
            <atmtech:DatePicker  runat="server" ID="txtTest" Text="2015-04-13 00:00:00" />
            <asp:Button runat="server" ID="btnSkin" OnClick="btnSkinOnclick"/>
        </div>
    </form>
</body>
</html>
