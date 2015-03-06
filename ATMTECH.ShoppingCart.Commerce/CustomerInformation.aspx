<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CustomerInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.CustomerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="InformationClient">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblInformationSurLeCompte" Text="Information sur le compte"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="lblPrenom" Text="Prénom" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtPrenom" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblNom" Text="Nom" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtNom" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblCourrielCreer" Text="Courriel" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCourriel" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasseCreer" Text="Mot de passe" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasseCreerConfirmation" Text="Confirmation" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasseConfirmation" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>


        <div class="adresseLivraisonClient">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblAdresseLivraisonClient" Text="Adresse de livraison"></asp:Label>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblNoCiviqueLivraisonInformationClient" Text="Numéro civique" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtNoCiviqueLivraisonClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblRueLivraisonInformationClient" Text="Rue" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtRueLivraisonClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblCodePostalLivraisonInformationClient" Text="Code postal" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtCodePostalLivraisonInformationClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblVilleLivraisonClient" Text="Ville" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtVilleLivraisonClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>


            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblPaysLivraisonInformationClient" Text="Pays" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <atmtech:ComboBox ID="ddlPaysLivraisonClient" runat="server" Width="400px" AutoPostBack="True"></atmtech:ComboBox>
            </div>
        </div>
        <div class="adresseFacturationClient">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblAdresseFacturationClient" Text="Adresse de facturation"></asp:Label>

            </div>
            <div>
                <asp:Button runat="server" ID="btnUtiliserMemeAdresseQueLivraison" OnClick="btnUtiliserMemeAdresseQueLivraisonClick" Text="Utiliser la même adresse que celle de livraison" CssClass="boutonLien" />
            </div>
            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblNoCiviqueFacturationInformationClient" Text="Numéro civique" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtNoCiviqueFacturationClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblRueFacturationInformationClient" Text="Rue" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtRueFacturationClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblCodePostalFacturationInformationClient" Text="Code postal" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtCodePostalFacturationClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblVilleFacturationInformationClient" Text="Ville" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtVilleFacturationClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>


            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblPaysFacturationInformationClient" Text="Pays" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <atmtech:ComboBox ID="ddlPaysFacturationClient" runat="server" Width="400px" AutoPostBack="True"></atmtech:ComboBox>
            </div>
        </div>

        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnEnregistrerInformationClient" Text="Enregistrer" CssClass="boutonActionRond" Width="400px" OnClick="btnEnregistrerInformationClientClick"></asp:Button>
        </div>
    </div>
    <div class="HistoriqueCommandeClient">

        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblHistoriqueDeVosCommandesInformationClient" Text="Historique de vos commandes"></asp:Label>
        </div>

        <div class="Table">
            <div class="Heading">
                <div class="Cell">
                    <asp:Label runat="server" ID="lblNoCommandeInformationClient" Text="No."></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblDateCommandeInformationClient" Text="Commandé le"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblEnvoyeLeInformationClient" Text="Envoyé le"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblGrandTotalInformationClient" Text="Grand total"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblNumeroExpeditionInformationClient" Text="Numéro d'expédition"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblVisualiserInformationClient" Text="Visualiser"></asp:Label>
                </div>
            </div>
            <asp:PlaceHolder runat="server" ID="placeHolderListeCommandePasse"></asp:PlaceHolder>
            <asp:Label runat="server" ID="lblAucuneCommandePasseACeJour" Text="Aucune commande passé à ce jour"></asp:Label>

        </div>

    </div>
    <div style="clear: both;"></div>
</asp:Content>
