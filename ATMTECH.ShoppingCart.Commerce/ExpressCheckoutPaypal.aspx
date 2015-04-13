<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckoutPaypal.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ExpressCheckoutPaypal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="confirmationPaypal">

        <asp:Label runat="server" ID="lblAccepterPaiementPaypal" Text="Vous devez approuver la commande par paypal"></asp:Label>
        <asp:Panel runat="server" ID="pnlAcceptPaypalPayment">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblVotreCommande" Text="Votre commande"></asp:Label>
            </div>
            <asp:Label runat="server" ID="lblAffichageCommande"></asp:Label><br />
            <asp:Button runat="server" ID="btnAccepterPaiementPaypal" Text="Accepter la commande" CssClass="boutonActionRond" OnClick="btnAccepterPaiementPaypalClick"/>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlOrderFinalized" Visible="False">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblCommandeFinalisee" Text="Merci de votre commande"></asp:Label>
            </div>
            <asp:Button runat="server" ID="btnImprimerCommande" Text="Imprimer le détail de votre commande" OnClick="btnImprimerCommandeClick" CssClass="boutonActionRond" />
        </asp:Panel>
    </div>

    <div style="clear: both;"></div>
</asp:Content>
