<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RapportCimaAncien.aspx.cs" Inherits="ATMTECH.Administration.RapportCimaAncien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Date depart:<atmtech:DatePicker runat="server" ID="txtDepart"></atmtech:DatePicker> (ex: 20100101)<br/>
        Date fin: <atmtech:DatePicker runat="server" ID="txtFin"></atmtech:DatePicker> (ex: 20100101)

        <asp:Button runat="server" ID="btnRapport" OnClick="btnRapportClick" Text="Generer le rapport"/>
        <asp:GridView runat="server" ID="grdTest"></asp:GridView>
    </div>
    </form>
</body>
</html>
