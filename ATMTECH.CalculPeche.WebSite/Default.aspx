<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.CalculPeche.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList runat="server" ID="ddlExpedition" AutoPostBack="True" OnSelectedIndexChanged="ddlExpeditionChanged" />
            <h1>Présence</h1>
            <asp:GridView runat="server" ID="grvPresence" AutoGenerateColumns="True"></asp:GridView>
            <h1>Bateau</h1>
            <asp:GridView runat="server" ID="grvBateau" AutoGenerateColumns="True"></asp:GridView>
            <h1>Repas</h1>
            <asp:GridView runat="server" ID="grvRepas" AutoGenerateColumns="True"></asp:GridView>


        </div>
    </form>
</body>
</html>
