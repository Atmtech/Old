<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="btnTest" Text="Test" OnClick="btnTestClick"/>
            <asp:Button runat="server" ID="btnTest2" Text="Test2" OnClick="btnTest2Click"/>
            <asp:Label runat="server" id="lblHttp"></asp:Label>
        </div>
    </form>
</body>
</html>
