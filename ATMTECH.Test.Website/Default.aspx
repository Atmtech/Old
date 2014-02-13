<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Test.Website._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery-ui.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery.jqprint.0.3.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/Utilitaires.js") %>"></script>
    <%-- Envoyer true à la fonction GererExpiration pour l'affichage du temps restant en bas de page. --%>
    <script type="text/javascript">
        $(function () {
            InitialiserExpiration(20, '<%=ResolveUrl("~/Errors/SessionTimeout.htm")%>', false);
            $("#lnkImprimer").click(function () {
                $('#impression').jqprint();
                return false;
            });
        });
    </script>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </asp:ScriptManager>
    <div style="padding: 10px 10px 10px 10px;">
        <atmtech:FenetreDialogue runat="server" ID="fenetreOuvrir" Titre="Test" />
        <h1>
            Page de test</h1>
        <atmtech:Bouton runat="server" ID="btnTest" OnClick="TestOpenWindow" Text="Test Open Window" />
        <br />
        <atmtech:Bouton runat="server" ID="btnTestPurolator" Text="Testing purolator" OnClick="TestPurolator" />
        <br />
        <atmtech:Bouton runat="server" ID="btnGenerateSqlFromClass" Text="Test Generate Create Table Sql From Class"
            OnClick="TestGenerateCreateTableSqlFromClass" />
        <br />
        <atmtech:Bouton runat="server" ID="btnTestGenerateAlterTableSqlFromClass" Text="Test Generate Alter Table Sql From Class"
            OnClick="TestGenerateAlterTableSqlFromClass" />
        <br />
         <atmtech:Bouton runat="server" ID="btnTestIpCountry" Text="Test IpCountry"
            OnClick="TestIpCountry" />
        <br />
        Resultat:<br />
        <asp:TextBox runat="server" ID="txtResultat" TextMode="MultiLine" Rows="25" Width="100%"></asp:TextBox>
    </div>
    <input type="hidden" id="EstFenetreModal" value="0" />
    <input type="hidden" id="StatutExpiration" value="1" />
    </form>
</body>
</html>
