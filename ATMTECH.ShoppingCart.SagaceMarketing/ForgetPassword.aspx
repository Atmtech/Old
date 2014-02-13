<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="titleForgetPassword" Text="J'ai oublié mon mot de passe"
        CssClass="title"></asp:Label>
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " StyleTextBox="width:400px;"></atmtech:TextBoxAvance>
        </tr>
    </table>
    <atmtech:Bouton runat="server" ID="btnSendMailForget" OnClick="SendMail_click" Text="Envoyez moi mon mot de passe" />
    <br/>
    <asp:Label runat="server" ID="lblConfirmSendEmail" Text="Nous vous avons envoyé votre mot de passe par courriel." Visible="False"></asp:Label>
</asp:Content>
