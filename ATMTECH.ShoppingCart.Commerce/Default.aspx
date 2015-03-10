<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Default1" %>

<%@ Import Namespace="ATMTECH.Common.Constant" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <img src="Images/WebSite/slideTest1.jpg" width="1000px" />
    <div class="categorie">
        <img src="Images/WebSite/test1Promo.jpg" width="321px" />
        <img src="Images/WebSite/test1Promo.jpg" width="321px" style="padding-left: 15px; padding-right: 15px;" />
        <img src="Images/WebSite/test1Promo.jpg" width="320px" />
    </div>

    <div class="vente">
        <asp:Label runat="server" ID="lblItemEnVenteActuellement" Text="Items en vente actuellement"></asp:Label>
    </div>
    <div class="listeObjetEnPromo">
        <asp:DataList runat="server" ID="dataListListeProduitEnVente" RepeatDirection="Horizontal" RepeatColumns="4">
            <ItemTemplate>

                <div style="padding-left:15px;padding-bottom: 10px;">
                    <div class="wrapper">
                        <div class="ribbon-wrapper-green">
                            <div class="ribbon-green">
                                <asp:Label runat="server" ID="lblVentes" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? "VENTES" : "SALES"%>'></asp:Label>
                            </div>
                        </div>
                        <asp:HyperLink ID="imgProduct" runat="server" NavigateUrl='<%# "AddProductToBasket.aspx?ProductId=" + Eval("Id")%>'>
                            <asp:Image runat="server" ID="tes" ImageUrl='<%#Eval("PrincipalFileUrl")%>' CssClass="thumbnailImageListeProduitEnVente" />
                        </asp:HyperLink>

                        <br />
                        <asp:Label runat="server" ID="lblName" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? Eval("NameFrench") : Eval("NameEnglish")%>'></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblPrixAvant" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? "Était" : "Was"%>' />
                        <asp:Label runat="server" ID="lblUnitPrice" Text='<%#String.Format("{0:C}", Eval("UnitPrice") )%>' Style="text-decoration: line-through;"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblPrixMaintenant" Text='<%#Presenter.CurrentLanguage == LocalizationLanguage.FRENCH ? "Maintenant" : "Now"%>' />
                        <asp:Label runat="server" ID="lblSalePrice" Text='<%#String.Format("{0:C}",Eval("SalePrice"))%>'></asp:Label>
                    </div>
                </div>



                <%--                 <div class="wrapper">
        <div class="ribbon-wrapper-green">
                

                    
            
                <div style="text-align: center;height: 300px;">

                  
                </div>--%>
                       
        </div>
    </div>

            </ItemTemplate>
        </asp:DataList>
        <%-- <div style="text-align: center;">
        <asp:PlaceHolder runat="server" ID="placeHolderListeProduitEnVente"></asp:PlaceHolder>
             <div style="clear: both;">
        </div>--%>
    </div>


</asp:Content>
