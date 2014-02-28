<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductSearch.aspx.cs" Inherits="ATMTECH.ShoppingCart.Glv.ProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <strong><asp:Label runat="server" id="lblSearchTitle"></asp:Label></strong>
    </div>
    <table style="display:none;">
        <tr>
            <atmtech:TextBoxAvance runat="server" Libelle="Rechercher:" ID="txtSearch" />
            <td>
                <atmtech:Bouton runat="server" ID="btnSearch" OnClick="SearchClick" Text="Rechercher" />
            </td>
        </tr>
    </table>
    <asp:PlaceHolder runat="server" ID="placeHolderProduct"></asp:PlaceHolder>
    <div class="clearfix">
    </div>
</asp:Content>
