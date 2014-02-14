<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="titleForgetPassword" Text="J'ai oublié mon mot de passe"></asp:Label>
    </div>
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " StyleTextBox="width:400px;">
            </atmtech:TextBoxAvance>
        </tr>
    </table>
    <div class="toolbar">
        <asp:Button runat="server" ID="btnSendMailForget" OnClick="SendMail_click" Text="Envoyez moi mon mot de passe" CssClass="button" />
    </div>
    <br />
    <asp:Label runat="server" ID="lblConfirmSendEmail" Text="Nous vous avons envoyé votre mot de passe par courriel."
        Visible="False"></asp:Label>
</asp:Content>
