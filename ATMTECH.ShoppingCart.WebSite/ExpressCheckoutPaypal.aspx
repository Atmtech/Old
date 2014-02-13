<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckoutPaypal.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.ExpressCheckoutPaypal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="titleExpressCheckoutPaypal" Text="Vous devez approuver la commande par paypal"
        CssClass="title"></asp:Label>
        <asp:Panel runat="server" ID="pnlAcceptPaypalPayment">
    <atmtech:Bouton runat="server" ID="btnAcceptPaypalPayment" OnClick="AcceptPaypalPayment"
        Text="Accepter la commande" /></asp:Panel>
    <asp:Panel runat="server" ID="pnlOrderFinalized" Visible="False">
        <asp:Label runat="server" ID="lblOrderIsFinalized" Text="Merci de votre commande"></asp:Label>
        <atmtech:Bouton runat="server" ID="btnPrintOrder" Text="Imprimer le détail de votre commande"
            OnClick="PrintOrderClick" />
    </asp:Panel>
</asp:Content>
