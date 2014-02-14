<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sprint.ascx.cs" Inherits="ATMTECH.Scrum.WebSite.UserControls.SprintPage" %>
<table>
    <tr>
        <atmtech:TextBoxMultiligneAvance runat="server" ID="txtDescription" Rows="4" Libelle="Description"
            StyleTextBox="width:400px;" />
    </tr>
    <tr>
         <atmtech:ComboBoxAvance runat="server" ID="cboProduct" Libelle="Produit" />
    </tr>
    <tr>
        <atmtech:DateTextBoxAvance runat="server" ID="txtDateStart" Libelle="Départ"/>
    </tr>
    <tr>
        <atmtech:DateTextBoxAvance runat="server" ID="txtDateEnd" Libelle="Fin"/>
    </tr>
</table>
<hr />
<asp:Button runat="server" ID="btnSave" Text="Enregistrer" OnClick="SaveSprint" />
