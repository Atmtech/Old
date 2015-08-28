<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListeCouleur.ascx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.UserControls.ListeCouleur" %>

<%--<asp:PlaceHolder runat="server" ID="placeHolderCouleur"></asp:PlaceHolder>--%>

<asp:DataList runat="server" ID="dataListListeImagesCouleur" RepeatDirection="Horizontal" RepeatColumns="10">
    <ItemTemplate>
        <asp:Image runat="server" ID="imageCouleur" ImageUrl='<%# Eval("Images") %>' AlternateText='<%# Eval("Nom") %>' ToolTip='<%# Eval("Nom") %>' />
    </ItemTemplate>
</asp:DataList>