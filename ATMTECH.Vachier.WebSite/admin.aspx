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
            <asp:Button runat="server" ID="btnTest" Text="Générer exclusion" OnClick="btnTestClick"/><br/>
            <asp:Button runat="server" ID="btnTest2" Text="Supprimer post exclusion" OnClick="btnTest2Click"/><br/>
            
            <asp:TextBox runat="server" id="txtExclus" text="Ta mère est une http://uvan.us/41075/jeep-names.html" Style="width:800px;"></asp:TextBox><br/>
            <asp:Button runat="server" ID="btnTest3" Text="Verifier si exclus" OnClick="btnTest3Click"/><br/>
            <asp:Label runat="server" id="lblHttp" ForeColor="green"></asp:Label><br/>
            <asp:Label runat="server" id="lblCompte"></asp:Label><br/>
        </div>
    </form>
</body>
</html>
