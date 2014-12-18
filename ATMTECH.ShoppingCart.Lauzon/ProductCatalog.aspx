<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.Lauzon.ProductCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder runat="server" ID="placeHolderProduct"></asp:PlaceHolder>
    <asp:Panel runat="server" ID="pnlNoCategory" Visible="False">
        <asp:Label ID="lblNoCategory" runat="server" Text="Aucune catégorie"></asp:Label>
    </asp:Panel>
    <div class="clearfix" style="margin-bottom: 10px;">
    </div>

</asp:Content>
