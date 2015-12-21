<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckoutPaypal.aspx.cs" Inherits="ATMTECH.Administration.Commerce.ExpressCheckoutPaypal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="titrePage">
        Retour de paypal
    </div>

    <asp:Panel runat="server" ID="pnlAcceptPaypalPayment">

        <table>
            <tr>
                <td>Numéro de commande:</td>
                <td style="font-weight: bold;">
                    <asp:Label runat="server" ID="lblNoCommande"></asp:Label></td>
            </tr>
            <tr>
                <td>De:</td>
                <td style="font-weight: bold;">
                    <asp:Label runat="server" ID="lblPayeur"></asp:Label></td>
            </tr>
            <tr>
                <td>Description:</td>
                <td style="font-weight: bold;">
                    <asp:Label runat="server" ID="lblDescriptionCommande"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Prix:</td>
                <td style="font-weight: bold;">
                    <asp:Label runat="server" ID="lblPrix"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Résultat transaction:</td>
                <td style="font-weight: bold;">
                    <asp:Label runat="server" ID="lblResultat"></asp:Label>
                </td>
            </tr>
        </table>

    </asp:Panel>
</asp:Content>
