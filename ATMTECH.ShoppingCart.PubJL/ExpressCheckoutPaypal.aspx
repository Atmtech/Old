<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckoutPaypal.aspx.cs" Inherits="ATMTECH.ShoppingCart.PubJL.ExpressCheckoutPaypal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
        <div class="title">
            <strong>
                <asp:Label runat="server" ID="lblAcceptPaypalPayment" Text="Vous devez approuver la commande par paypal"></asp:Label></h2>
            </strong>
        </div>

        <asp:Panel runat="server" ID="pnlAcceptPaypalPayment">
            <b><asp:Label runat="server" ID="lblYourOrder"></asp:Label></b><br />
            <asp:Label runat="server" ID="lblDisplayOrder"></asp:Label><br />
            <asp:Button runat="server" ID="btnAcceptPaypalPayment" OnClick="AcceptPaypalPayment"
                Text="Accepter la commande" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlOrderFinalized" Visible="False">
            <asp:Label runat="server" ID="lblOrderIsFinalized" Text="Merci de votre commande"></asp:Label><br/>
            <asp:Button runat="server" ID="btnPrintOrder" Text="Imprimer le détail de votre commande"
                OnClick="PrintOrderClick" />
        </asp:Panel>
    </div>
</asp:Content>
