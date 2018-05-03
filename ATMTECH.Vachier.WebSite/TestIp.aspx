<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestIp.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.TestIp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" id="txtIp"></asp:TextBox>
            <asp:Button runat="server" id="btnTest" OnClick="btnTestOnClick"/>
        </div>
    </form>
</body>
</html>
