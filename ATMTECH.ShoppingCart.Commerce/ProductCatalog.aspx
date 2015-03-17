<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductCatalog.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ProductCatalog" %>

<%@ Register Src="ListeProduit.ascx" TagName="ListeProduit" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ListeProduit ID="ListeProduit1" runat="server" Langue='<%#Presenter.CurrentLanguage%>' />
</asp:Content>
