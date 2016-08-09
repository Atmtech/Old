<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button runat="server" ID="btnGenererSql" OnClick="btnGenererSqlClick" Text="Generer modele" class="mbr-buttons__btn btn btn-lg btn-danger" />
                                            <asp:TextBox ID="txtSql" runat="server" Height="282px" Width="937px" TextMode="MultiLine" class="form-control"></asp:TextBox>
        <asp:Button runat="server" id="btnRecalculerChamps" OnClick="btnRecalculerChampsClick"/>
    </div>
    </form>
</body>
</html>
