<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ProductSearch.aspx.cs" Inherits="ATMTECH.ShoppingCart.WebSite.ProductSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" Libelle="Rechercher:" ID="txtSearch" />
            <td><atmtech:Bouton runat="server" ID="btnSearch" OnClick="SearchClick" Text="Rechercher" /></td>
        </tr>
        
    </table>
    
    <asp:DataList runat="server" ID="dataListProduct" OnItemDataBound="ProductDataBound"
        Width="100%" OnItemCommand="ProductCommand">
        <ItemTemplate>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Image runat="server" ID="imgProduct" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblIdent" runat="server"></asp:Label>
                            ::
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton runat="server" ID="lnkViewProduct" CssClass="linkButton" Text="[ Voir ce produit ]"
                                CommandName="ViewProduct"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </center>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
