<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Atorp.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblCrevette" runat="server" Text="Crevette"></asp:Label>
        <asp:Button ID="btnTest" runat="server" Text="Test" OnClick="btnTestClick" />
    </div>
    </form>
</body>
</html>
