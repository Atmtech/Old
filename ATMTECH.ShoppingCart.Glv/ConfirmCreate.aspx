<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ConfirmCreate.aspx.cs" Inherits="ATMTECH.ShoppingCart.Glv.ConfirmCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
        <div class="title">
            <strong>
                <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirmation de la création de votre utilisateur"></asp:Label>
            </strong>
        </div>
        <asp:Panel runat="server" ID="pnlNotConfirmed">
            <atmtech:Bouton runat="server" ID="btnConfirmCreate" OnClick="ConfirmCreate_click"
                Text="Je confirme la création de mon compte utilisateur" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlConfirmed" Visible="False">
            <asp:Label runat="server" ID="lblCreateConfirmed" Text="Merci d'avoir confirmé votre création."></asp:Label>
        </asp:Panel>
    </div>

</asp:Content>

