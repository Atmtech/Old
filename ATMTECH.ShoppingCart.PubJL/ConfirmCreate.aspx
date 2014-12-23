<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ConfirmCreate.aspx.cs" Inherits="ATMTECH.ShoppingCart.PubJL.ConfirmCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
        <div class="title">
            <strong>
                <div style="font-size: 16px;">
                    <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirmation de la création de votre utilisateur"></asp:Label>
                </div>
            </strong>
        </div>
        <asp:Panel runat="server" ID="pnlNotConfirmed">
            <asp:Button runat="server" ID="btnConfirmCreate" OnClick="ConfirmCreate_click"
                Text="Je confirme la création de mon compte utilisateur" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlConfirmed" Visible="False">
            <asp:Label runat="server" ID="lblCreateConfirmed" Text="Merci d'avoir confirmé votre création."></asp:Label>
        </asp:Panel>
    </div>

</asp:Content>

