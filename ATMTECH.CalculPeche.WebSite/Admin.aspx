<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.CalculPeche.WebSite.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button runat="server" ID="btnGenererSql" OnClick="btnGenererSqlClick" Text="Generer modele" />
            <asp:TextBox ID="txtSql" runat="server" Height="282px" Width="937px" TextMode="MultiLine"></asp:TextBox>
    </div>
    </form>
</body>
</html>
