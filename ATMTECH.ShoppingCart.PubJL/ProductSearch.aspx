<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductSearch.aspx.cs" Inherits="ATMTECH.ShoppingCart.PubJL.ProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <asp:Label runat="server" ID="lblSearchTitle"></asp:Label>
    </div>
    <table style="display: none;">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblSearch" Text="Rechercher:"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtSearch" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnSearch" OnClick="SearchClick" Text="Rechercher" />
            </td>
        </tr>
    </table>
    <asp:PlaceHolder runat="server" ID="placeHolderProduct"></asp:PlaceHolder>
    <div class="clearfix">
    </div>
</asp:Content>
