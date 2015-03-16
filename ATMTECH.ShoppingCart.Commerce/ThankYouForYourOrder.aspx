<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThankYouForYourOrder.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ThankYouForYourOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="merciPourLaCommande">
        <asp:Label runat="server" ID="lblMerciDeVotreCommande" Text="Merci pour votre commande."></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="lblPourLeSuiviDeCommande" Text="Vous pouvez vérifier le suivi de votre commande via vos information de compte."></asp:Label>
    </div>
    <div style="padding-top: 20px;">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblVotreCommande" Text="La commande"></asp:Label>
            (<asp:Label runat="server" ID="lblNumeroCommande" Text="No"></asp:Label>)<br />
        </div>

        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblSousTotalAffichage" Text="Sous-total: "></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="lblSousTotal"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" ID="lblTaxeProvincialeAffichage" Text="TVQ: "></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="lblTaxeProvinciale"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" ID="lblTaxeFederaleAffichage" Text="TPS: "></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="lblTaxeFederale"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" ID="lblCoutLivraisonAffichage" Text="Livraison: "></asp:Label></td>
                <td>
                    <asp:Label runat="server" ID="lblCoutLivraison"></asp:Label></td>
            </tr>

            <tr>
                <td class="totalCommandePanier">
                    <asp:Label runat="server" ID="lblGrandTotalAffichage" Text="Total: "></asp:Label></td>
                <td class="totalCommandePanier">
                    <asp:Label runat="server" ID="lblGrandTotal"></asp:Label></td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" ID="btnImprimerCommande" Text="Imprimer la commande" OnClick="btnImprimerCommandeClick" CssClass="boutonActionRond" />

    </div>

</asp:Content>
