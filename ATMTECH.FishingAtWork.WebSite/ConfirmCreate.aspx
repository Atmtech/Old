<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ConfirmCreate.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.ConfirmCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="titleConfirmPassword" Text="Confirmation de la création de votre utilisateur"></asp:Label>
    </div>
    <asp:Panel runat="server" ID="pnlNotConfirmed">
        <div class="toolbar">
            <asp:Button runat="server" ID="btnConfirmCreate" OnClick="ConfirmCreate_click" CssClass="button"
                Text="Je confirme la création de mon compte utilisateur" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlConfirmed" Visible="False">
        <asp:Label runat="server" ID="lblCreateConfirmed" Text="Merci d'avoir confirmé votre création."></asp:Label>
    </asp:Panel>
</asp:Content>
