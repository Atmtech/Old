<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreerSql.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.CreerSql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button runat="server" Text="Générer SQL" id="btnGenererSql" OnClick="btnGenererSqlClick"/><br/>
        <asp:TextBox ID="txtSql" runat="server" Height="282px" Width="937px" TextMode="MultiLine"></asp:TextBox>
        
        <br/>
        <asp:Button runat="server" Text="Test DAO" id="btnTestDao" OnClick="btnTestDaoClick"/>
    </form>
</body>
</html>
