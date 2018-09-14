<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container" style="padding-top: 93px; padding-bottom: 93px;">

            <h2 class="header2">
                <asp:Label ID="lblInscrivezVous" runat="server" Text="Inscrivez-vous "></asp:Label>
            </h2>
            <h3 class="header3">
                <asp:Label ID="lblEntrerVosInformation" runat="server" Text="Entrez vos informations et démarrer votre première planification"></asp:Label>
            </h3>
            <br />
            <asp:PlaceHolder runat="server" ID="placeHolderErreur"></asp:PlaceHolder>

            <asp:Label runat="server" ID="lblEstObligatoire" Text="* Les champs encadrés en vert sont obligatoires." Style="color: #009933"></asp:Label>
            <br />
            <br />
            <div class="libelleChampsEditable">
                <asp:Label ID="lblLibellePrenom" runat="server" Text="Prénom"></asp:Label>
            </div>

            <asp:TextBox runat="server" ID="txtPrenom" placeholder="Prénom" CssClass="controlEditable" BorderStyle="Solid" BorderColor="#009933"></asp:TextBox>

            <div class="libelleChampsEditable">
                <asp:Label ID="lblLibelleNom" runat="server" Text="Nom"></asp:Label>
            </div>
            <asp:TextBox runat="server" ID="txtNom" placeholder="Nom" CssClass="controlEditable" BorderStyle="Solid" BorderColor="#009933"></asp:TextBox>
            <div class="libelleChampsEditable">
                <asp:Label ID="lblLibelleCourriel" runat="server" Text="Courriel"></asp:Label>
            </div>
            <asp:TextBox runat="server" ID="txtCourriel" placeholder="Courriel" TextMode="Email" CssClass="controlEditable" BorderStyle="Solid" BorderColor="#009933"></asp:TextBox>
            <div class="libelleChampsEditable">
                <asp:Label ID="lblMotDePasse" runat="server" Text="Mot de passe"></asp:Label>
            </div>
            <asp:TextBox runat="server" ID="txtMotDePasse" placeholder="Mot de passe" TextMode="Password" CssClass="controlEditable" BorderStyle="Solid" BorderColor="#009933"></asp:TextBox>
            <div class="libelleChampsEditable">
                <asp:Label ID="lblConfirmationMotDePasse" runat="server" Text="Confirmation du mot de passe"></asp:Label>
            </div>
            <asp:TextBox runat="server" ID="txtConfirmationMotDePasse" placeholder="Confirmation" TextMode="Password" CssClass="controlEditable" BorderStyle="Solid" BorderColor="#009933"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="lnkCreerMonCompte" Text="Créer mon compte" class="mbr-buttons__btn btn btn-standard" OnClick="lnkCreerMonCompteClick"></asp:Button>
            <br />
            <asp:Label runat="server" ID="lblNousVousEnverronsUnCourriel" Text="N.B.: Nous vous enverrons un Courriel pour confirmer votre inscription."></asp:Label>
        </div>
    </section>
</asp:Content>
