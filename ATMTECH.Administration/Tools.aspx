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

    </div>
</asp:Content>
