<%@ Page Title="" Language="C#" MasterPageFile="~/Investisseurs.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Investisseurs.WebSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label runat="server" ID="lblPlayer"></asp:Label>
    <asp:TextBox runat="server" ID="txtStockQuote"></asp:TextBox>
    <asp:Button runat="server" ID="btnGetQuote" Text="Get" OnClick="GetQuoteClick" />
    

    <asp:Panel runat="server" ID="pnlBuyStock" Visible="False">
        Symbol: <asp:Label runat="server" ID="lblSymBol"></asp:Label>    
        Bid: <asp:Label runat="server" ID="lblBid"></asp:Label>    
        Ask: <asp:Label runat="server" ID="lblAsk"></asp:Label>    
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtQuantity" Libelle="Quantité"/>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnBuyQuote" Text="Buy" OnClick="BuyQuoteClick" />
    </asp:Panel>
</asp:Content>
