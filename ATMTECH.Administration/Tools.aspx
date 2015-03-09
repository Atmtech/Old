<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Tools.aspx.cs" Inherits="ATMTECH.Administration.Tools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        

        <div class="EnteteOutils" style="margin-top: 0px;">
            Confirmation d'une commande à un client (Envoi d'un courriel et changement du status de la commande)
        </div>
        Numéro de commande: 
        <asp:TextBox runat="server" ID="txtOrder1"></asp:TextBox>
        <asp:Button runat="server" ID="btnConfirm" OnClick="ConfirmOrderClick" Text="Confirmer"
            CausesValidation="False" CssClass="button" Visible="True" />

        <div class="EnteteOutils">
            Afficher une facture en format PDF
        </div>
        Numéro de commande: 
        <asp:TextBox runat="server" ID="txtOrder2"></asp:TextBox>
        <asp:Button runat="server" ID="btnDisplayOrder" OnClick="DisplayOrderClick" Text="Afficher" CausesValidation="False" CssClass="button" />
        
       
        <div class="EnteteOutils">
            Associer un utilisateur qui n'est pas un client à une entreprise
        </div>
        <table>
            <tr>

                <td>Utilisateur</td>
                <td>
                    <asp:DropDownList runat="server" ID="cboUser" AutoPostBack="True" />
                </td>
                <td>Enterprise:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="cboEnterprise1" AutoPostBack="True" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnAssociateWithCustomer" OnClick="AssociateUserOpenWindowClick"
                        Text="Associer" CausesValidation="False" CssClass="button" />
                </td>
            </tr>
        </table>

        <div class="EnteteOutils">
            Créer une entreprise à partir d'une autre
        </div>
        <table>
            <tr>
                <td>Enterprise:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="cboEnterprise2" />
                </td>
                <td>Nouveau nom:<asp:TextBox runat="server" ID="txtNewName"></asp:TextBox></td>
                <td>
                    <asp:Button runat="server" ID="btnCreateEnterpriseFrom" OnClick="btnCreateEnterpriseFromClick"
                        Text="Créer" CausesValidation="False" CssClass="button" />
                </td>
            </tr>
        </table>

        <div class="EnteteOutils">
            Appliquer un modèle d'inventaire à un produit
        </div>

        <table>
            <tr>
                <td>Entreprise:</td>
                <td>
                    <asp:DropDownList runat="server" ID="cboEnterprise3" AutoPostBack="True" />
                </td>
            </tr>
            <tr>
                <td>Modèle:</td>
                <td>
                    <asp:DropDownList runat="server" ID="cboStockTemplate" />
                </td>
            </tr>
            <tr>
                <td>Produits sans Inventaire:</td>
                <td>
                    <asp:DropDownList runat="server" ID="cboProductWithoutStock" />
                </td>
            </tr>
            <tr>
                <td>Ne possède pas d'inventaire:
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="chkIsWithoutStock" />
                </td>
            </tr>
            <tr>
                <td>Quantité en inventaire</td>
                <td>
                    <asp:TextBox runat="server" ID="txtQuantityStockTemplate" Text="0" Visible="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnApplyStockTemplate" OnClick="ApplyStockTemplateClick" CausesValidation="False" CssClass="button" Text="Appliquer" />
                </td>
            </tr>


        </table>


        <div class="EnteteOutils">
            Réajuster une ligne de commande
        </div>
        Id ligne commande à modifié:<asp:TextBox runat="server" ID="txtAdjustOrderlineId"></asp:TextBox>
        N.B.: Voir dans "Ligne de commande"<br />
        Quantité finale pour l'item:<asp:TextBox ID="txtAdjustOrderlineQuantite" runat="server"></asp:TextBox>
        N.B.: Si quantité est 0 alors l'item sera enlevé de la commande<br />
        <asp:Button runat="server" ID="btnAdjustOrderline" OnClick="btnAdjustOrderlineClick" CausesValidation="False" CssClass="button" Text="Réajuster" />
        <asp:Label runat="server" ID="lblAdjustOrderline"></asp:Label>



        <div class="EnteteOutils">
            Rebalancer les inventaires avec les commandes
        </div>
        <asp:Button runat="server" ID="btnBalanceStock" OnClick="btnBalanceStockClick" CausesValidation="False" CssClass="button" Text="Balancer" />
        <asp:Label runat="server" ID="lblResultBalance"></asp:Label>

        <div class="EnteteOutils">
            Rebalancer les totaux des commandes
        </div>
        <asp:Button runat="server" ID="btnBalanceOrder" OnClick="btnBalanceOrderClick" CausesValidation="False" CssClass="button" Text="Balancer" />
        <asp:Label runat="server" ID="lblResultBalanceOrder"></asp:Label>


        <div class="EnteteOutils">
            Synchroniser les fichiers images avec la base de données.
        </div>
        <asp:DropDownList runat="server" ID="ddlSiteList" AutoPostBack="True">
            <asp:ListItem Value="C:\WebSite\cima-directeur.boutiquecorpo.com\Images">cima-directeur.boutiquecorpo.com</asp:ListItem>
            <asp:ListItem Value="C:\WebSite\cima-employe.boutiquecorpo.com\Images">cima-employe.boutiquecorpo.com</asp:ListItem>
            <asp:ListItem Value="C:\WebSite\ursulines.boutiquecorpo.com\Images">ursuline.boutiquecorpo.com</asp:ListItem>
            <asp:ListItem Value="C:\WebSite\glv.boutiquecorpo.com\Images">glv.boutiquecorpo.com</asp:ListItem>
            <asp:ListItem Value="C:\WebSite\glv-an.boutiquecorpo.com\Images">glv-an.boutiquecorpo.com</asp:ListItem>
            <asp:ListItem Value="C:\WebSite\lauzon.boutiquecorpo.com\Images">lauzon.boutiquecorpo.com</asp:ListItem>
            <asp:ListItem Value="C:\WebSite\dev.boutiquecorpo.com\Images">dev.boutiquecorpo.com</asp:ListItem>

            <%--<asp:ListItem Value="C:\Domains\cima-directeur.boutiquecorpo.com\www\Images">cima-directeur.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\cima-employe.boutiquecorpo.com\www\Images">cima-employe.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\ursulines.boutiquecorpo.com\www\Images">ursuline.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\glv.boutiquecorpo.com\www\Images">glv.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\glv-an.boutiquecorpo.com\www\Images">glv-an.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\lauzon.boutiquecorpo.com\www\Images">lauzon.boutiquecorpo.com</asp:ListItem>--%>
            <asp:ListItem Value="C:\dev\Atmtech\ATMTECH.ShoppingCart.PubJL\Images">Développement</asp:ListItem>
        </asp:DropDownList>

        <asp:Button runat="server" ID="btnSynchroniserFichierImage" OnClick="btnSynchroniserFichierImageClick" CausesValidation="False" CssClass="button" Text="Synchroniser" />
        <asp:Label runat="server" ID="Label1"></asp:Label>

        <div class="EnteteOutils">
            Rebalancer les colonnes de recherches
        </div>
        Objet à balancer: 
        <asp:DropDownList runat="server" ID="ddlBalanceSearch" AutoPostBack="True">
            <asp:ListItem Text="Address" Value="Address"></asp:ListItem>
            <asp:ListItem Text="Country" Value="Country"></asp:ListItem>
            <asp:ListItem Text="City" Value="City"></asp:ListItem>
            <asp:ListItem Text="User" Value="User"></asp:ListItem>
            <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
            <asp:ListItem Text="CustomerType" Value="CustomerType"></asp:ListItem>
            <asp:ListItem Text="Enterprise" Value="Enterprise"></asp:ListItem>
            <asp:ListItem Text="EnterpriseAddress" Value="EnterpriseAddress"></asp:ListItem>
            <asp:ListItem Text="EnterpriseEmail" Value="EnterpriseEmail"></asp:ListItem>
            <asp:ListItem Text="EnumOrderInformation" Value="EnumOrderInformation"></asp:ListItem>
            <asp:ListItem Text="GroupProduct" Value="GroupProduct"></asp:ListItem>
            <asp:ListItem Text="Order" Value="Order"></asp:ListItem>
            <asp:ListItem Text="OrderLine" Value="OrderLine"></asp:ListItem>
            <asp:ListItem Text="Product" Value="Product"></asp:ListItem>
            <asp:ListItem Text="ProductCategory" Value="ProductCategory"></asp:ListItem>
            <asp:ListItem Text="ProductFile" Value="ProductFile"></asp:ListItem>
            <asp:ListItem Text="File" Value="File"></asp:ListItem>
            <asp:ListItem Text="ProductPriceHistory" Value="ProductPriceHistory"></asp:ListItem>
            <asp:ListItem Text="Stock" Value="Stock"></asp:ListItem>
            <asp:ListItem Text="StockLink" Value="StockLink"></asp:ListItem>
            <asp:ListItem Text="StockTemplate" Value="StockTemplate"></asp:ListItem>
            <asp:ListItem Text="Supplier" Value="Supplier"></asp:ListItem>
            <asp:ListItem Text="Taxes" Value="Taxes"></asp:ListItem>
            <asp:ListItem Text="StockTransaction" Value="StockTransaction"></asp:ListItem>
            <asp:ListItem Text="Localization" Value="Localization"></asp:ListItem>

        </asp:DropDownList>
        <asp:Button runat="server" ID="btnBalanceSearchColumn" OnClick="btnBalanceSearchColumnClick" CausesValidation="False" CssClass="button" Text="Balancer" />
        <asp:Label runat="server" ID="lblResultatBalanceSearch"></asp:Label>


        <div class="EnteteOutils">
            Créer une copie de sauvegarde de la Base de données
        </div>
        <asp:Button runat="server" ID="btnCreateBackup" OnClick="btnCreateBackupClick" CausesValidation="False" CssClass="button" Text="Copie de sauvegarde" />
        <br />
        <asp:Label runat="server" ID="lblResultBackup"></asp:Label>


        <div class="EnteteOutils">
            Restaurer fichier base données
        </div>
        <asp:Button runat="server" ID="btnRestore" OnClick="btnRestoreClick" CausesValidation="False" CssClass="button" Text="Restaurer" />
        <br />
        <asp:Label runat="server" ID="lblResultRestore"></asp:Label>


        <div class="EnteteOutils">
            Ouvrir ou fermer le système
        </div>
        <asp:Button runat="server" ID="btnOpenApplication" OnClick="btnOpenApplicationClick" CausesValidation="False" CssClass="button" Text="Ouvrir l'application" />
        <asp:Button runat="server" ID="btnCloseApplication" OnClick="btnCloseApplicationClick" CausesValidation="False" CssClass="button" Text="Fermer l'application" />

         <div class="EnteteOutils">
            Chargement massif (Ne pas utiliser si vous ne savez pas ce que vous faites)
        </div>
        <asp:Button runat="server" ID="btnChargerXmlProduit" Text="Charger les produits d'un fichier XML" OnClick="btnChargerXmlProduitClick" CssClass="button" />


    </div>
</asp:Content>
