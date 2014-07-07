<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Tools.aspx.cs" Inherits="ATMTECH.Administration.Tools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding-left: 10px;">
        <div style="text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
            Confirmation d'une commande à un client (Envoi d'un courriel et changement du status de la commande)
        </div>
        Numéro de commande: 
        <asp:TextBox runat="server" ID="txtOrder1"></asp:TextBox>
        <asp:Button runat="server" ID="btnConfirm" OnClick="ConfirmOrderClick" Text="Confirmer"
            CausesValidation="False" CssClass="button" Visible="True" />

        <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
            Afficher une facture en format PDF
        </div>
        Numéro de commande: 
        <asp:TextBox runat="server" ID="txtOrder2"></asp:TextBox>
        <asp:Button runat="server" ID="btnDisplayOrder" OnClick="DisplayOrderClick" Text="Afficher" CausesValidation="False" CssClass="button" />


        <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
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

        <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
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

        <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
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


        <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
            Rebalancer les inventaires avec les commandes
        </div>
        <asp:Button runat="server" ID="btnBalanceStock" OnClick="btnBalanceStockClick" CausesValidation="False" CssClass="button" Text="Balancer" />
        <asp:Label runat="server" ID="lblResultBalance"></asp:Label>


        <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
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

        </asp:DropDownList>
        <asp:Button runat="server" ID="btnBalanceSearchColumn" OnClick="btnBalanceSearchColumnClick" CausesValidation="False" CssClass="button" Text="Balancer" />
        <asp:Label runat="server" ID="lblResultatBalanceSearch"></asp:Label>
        
        
          <div style="margin-top: 20px; text-transform: uppercase; padding: 10px 10px 10px 10px; font-weight: bold; background-color: rgb(175, 181, 183); border: solid 1px gray; box-shadow: 1px 1px 5px 2px #b2b0b0; margin-bottom: 10px;">
            Créer une copie de sauvegarde de la Base de données
        </div>
                <asp:Button runat="server" ID="btnCreateBackup" OnClick="btnCreateBackupClick" CausesValidation="False" CssClass="button" Text="Copie de sauvegarde" />
        <br/>
          <asp:Label runat="server" ID="lblResultBackup"></asp:Label>
    </div>
</asp:Content>
