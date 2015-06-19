<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckoutPaypal.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ExpressCheckoutPaypal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="confirmationPaypal">


        <asp:Panel runat="server" ID="pnlAcceptPaypalPayment">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblVotreCommande" Text="Votre commande"></asp:Label>
            </div>

            <div class="Table" style="width: 100%">
                <div class="Heading">
                    <div class="Cell">
                        &nbsp;
                    </div>
                    <div class="Cell">
                        <asp:Label runat="server" ID="lblQuantiteAddProduct" Text="Quantité"></asp:Label>
                    </div>
                </div>
                <asp:PlaceHolder runat="server" ID="placeHolderListeCommandePasse"></asp:PlaceHolder>
            </div>
            <br />

            <table style="font-size: 15px; width: 400px;">
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
                        <asp:Label runat="server" ID="lblGrandTotal"></asp:Label>
                    </td>
                </tr>
            </table>

            <br />
            <br />
            <asp:Button runat="server" ID="btnAccepterPaiementPaypal" Text="Accepter la commande" CssClass="boutonActionRondAccepterPaypal" OnClick="btnAccepterPaiementPaypalClick" />

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
