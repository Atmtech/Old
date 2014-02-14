<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.Contact" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.2.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="titleSendMail" Text="Envoyez nous vos commentaires"></asp:Label>
    </div>
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Nom: " ValidationGroup="SendMail"
                StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " ValidationGroup="SendMail"
                StyleTextBox="width:400px" EstObligatoire="True"></atmtech:TextBoxAvance>
        </tr>
    </table>
    <CKEditor:CKEditorControl ID="CKEditorMail" runat="server" Height="235" EnterMode="BR"
        Toolbar="">
    </CKEditor:CKEditorControl>
    <div class="toolbar">
        <asp:Button runat="server" ID="btnCreate" OnClick="SendMailClick" Text="Envoyer"
            ValidationGroup="SendMail" CssClass="button" />
        <asp:Button runat="server" ID="btnCancel" OnClick="CancelSendMailClick" Text="Annuler"
            CssClass="button" />
    </div>
</asp:Content>
