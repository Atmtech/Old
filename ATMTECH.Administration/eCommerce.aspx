<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="eCommerce.aspx.cs" Inherits="ATMTECH.Administration.eCommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div style="border: solid 1px gray; padding: 10px 10px 10px 10px; margin-top: 10px;">
            <b>Outils de la version eCommerce<br />
            </b>
            <div class="EnteteOutils">
                Initialiser environnement
            </div>

            P.S. Fonctionne seulement en local (C:\dev\Atmtech\ATMTECH.ShoppingCart.Commerce)
            <ul style="list-style-type: lower-alpha;">
                <li>
                    <asp:Button runat="server" ID="btnChargerXmlProduit" Text="Charger les produits du fichier XML" OnClick="btnChargerXmlProduitClick" CssClass="button" /> (Products.xml)
                </li>
                <li>
                    <asp:Button runat="server" ID="btnCopierImageAvecMixedVersRepertoire" OnClick="btnCopierImageAvecMixedVersRepertoireClick" CausesValidation="False" CssClass="button" Text="Copier image de couleur dans répertoire product" /></li> (Les couleurs dans le fichier garments-2015-03-26.zip)
                <li>
                    <asp:Button runat="server" ID="btnSynchroniserFichierImage" OnClick="btnSynchroniserFichierImageClick" CausesValidation="False" CssClass="button" Text="Inscrire les fichiers du répertoire selectionne dans la BD" /></li> (Tout les fichiers n'existant pas dans la bd qui se retrouve dans le repertoire images)
                <li>
                    <asp:Button runat="server" ID="btnSynchroniserProduitFichier" OnClick="btnSynchroniserProduitFichierClick" CausesValidation="False" CssClass="button" Text="Associer les produits aux fichiers inscrit dans la BD" /></li> (Associe via le nom du fichier au bon produit)
            </ul>
            <div class="EnteteOutils">
                Afficher toutes les couleurs du XML
            </div>
            <asp:Button runat="server" ID="btnAfficherCouleurXml" Text="Afficher les couleurs du XML" OnClick="btnAfficherCouleurXmlClick" CssClass="button" />
            <asp:Label runat="server" ID="lblCouleur"></asp:Label>
        </div>
</asp:Content>
