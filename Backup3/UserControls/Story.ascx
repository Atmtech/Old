<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Story.ascx.cs" Inherits="ATMTECH.Scrum.WebSite.UserControls.StoryPage" %>
<table>
    <tr>
        <atmtech:TextBoxMultiligneAvance runat="server" ID="txtDescription" Rows="4" Libelle="Description"
            StyleTextBox="width:400px;" />
    </tr>
    <tr>
        <atmtech:TextBoxMultiligneAvance runat="server" ID="txtBatch" Libelle="Insérer une story par ligne" />
    </tr>
    <tr>
        <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtPriority" EstNumeriqueSeul="True"
            Libelle="Priorité" />
    </tr>
    <tr>
        <atmtech:ComboBoxAvance runat="server" ID="cboPoint" Libelle="Points" AutoPostBack="True" />
    </tr>
    <tr>
        <atmtech:ComboBoxAvance runat="server" ID="cboSprint" Libelle="Itération" AutoPostBack="True" />
    </tr>
    <tr>
        <atmtech:ComboBoxAvance runat="server" ID="cboProduct" Libelle="Produit" AutoPostBack="True" />
    </tr>
    <tr>
        <atmtech:ComboBoxAvance runat="server" ID="cboStatus" Libelle="Statut" AutoPostBack="True" />
    </tr>
</table>
<hr />
<asp:Button runat="server" ID="btnSave" Text="Enregistrer" OnClick="SaveStory" />
