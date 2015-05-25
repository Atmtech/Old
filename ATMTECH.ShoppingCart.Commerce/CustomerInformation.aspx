<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CustomerInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.CustomerInformation" %>

<%@ Register TagPrefix="adresse" TagName="selectionneradresse" Src="~/UserControls/SelectionnerAdresse.ascx" %>

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

        <br/>
        <asp:Panel ID="pnlChangerMotDePasse" runat="server" Visible="False">
            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblMotDePasseCreer" Text="Mot de passe" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtMotDePasse" runat="server" CssClass="textBox" Width="400px" TextMode="Password"></asp:TextBox>
            </div>
            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblMotDePasseCreerConfirmation" Text="Confirmation" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtMotDePasseConfirmation" runat="server" CssClass="textBox" Width="400px" TextMode="Password"></asp:TextBox>
            </div><br/>
            <asp:Button runat="server" ID="btnChangerMotDePasse" Text="Changer mon mot de passe" OnClick="btnChangerMotDePasseClick"  CssClass="boutonActionRond" />
        </asp:Panel>
        <asp:Button runat="server" ID="btnJeVeuxChangerMonMotDePasse" Text="Je veux changer mon mot de passe" OnClick="btnJeVeuxChangerMonMotDePasseClick"  CssClass="boutonActionRond" />
        <br/>

        <div class="adresseLivraisonClient">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblAdresseLivraisonClient" Text="Adresse de livraison"></asp:Label>
            </div>
            <adresse:selectionneradresse ID="adresseLivraison" runat="server" EstAfficherCodePostal="True" />
        </div>
        <div class="adresseFacturationClient">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblAdresseFacturationClient" Text="Adresse de facturation"></asp:Label>
            </div>
            <div style="margin-bottom: 10px;">
                <asp:Button runat="server" ID="btnUtiliserMemeAdresseQueLivraison" OnClick="btnUtiliserMemeAdresseQueLivraisonClick" Text="Utiliser la même adresse que celle de livraison" CssClass="boutonActionRond" />
            </div>
            <adresse:selectionneradresse ID="adresseFacturation" runat="server" EstAfficherCodePostal="False" />
        </div>

        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnEnregistrerInformationClient" Text="Enregistrer" CssClass="boutonActionRondFinaliser" Width="400px" OnClick="btnEnregistrerInformationClientClick"></asp:Button>
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
        </div>
        <asp:Label runat="server" ID="lblAucuneCommandePasseACeJour" Text="Aucune commande passé à ce jour"></asp:Label>

    </div>
    <div style="clear: both;"></div>
</asp:Content>
