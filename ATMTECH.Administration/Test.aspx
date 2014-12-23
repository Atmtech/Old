<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="ATMTECH.Administration.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button runat="server" Text="test" OnClick="testClick"/>
        <asp:Button ID="btntest2" runat="server" Text="test2" OnClick="test2Click"/>
    </div>
    </form>
</body>
</html>
