<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckoutPaypal.aspx.cs" Inherits="ATMTECH.ShoppingCart.SagaceMarketing.ExpressCheckoutPaypal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="https://www.paypalobjects.com/webstatic/mktg/logo/AM_mc_vs_dc_ae.jpg" border="0"
        alt="PayPal Acceptance Mark">
    <asp:Label runat="server" ID="lblAcceptPaypalPayment" Text="Vous devez approuver la commande par paypal"
        CssClass="title"></asp:Label>
    <asp:Panel runat="server" ID="pnlAcceptPaypalPayment">
        <asp:Button runat="server" ID="btnAcceptPaypalPayment" OnClick="AcceptPaypalPayment"
            Text="Accepter la commande" CssClass="button" /></asp:Panel>
    <asp:Panel runat="server" ID="pnlOrderFinalized" Visible="False">
        <asp:Label runat="server" ID="lblOrderIsFinalized" Text="Merci de votre commande"></asp:Label>
        <asp:Button runat="server" ID="btnPrintOrder" Text="Imprimer le détail de votre commande"
            OnClick="PrintOrderClick" CssClass="button" />
    </asp:Panel>
</asp:Content>
