<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Shopping.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.Shopping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="lblShopping" Text="Équipements et leurres disponibles"></asp:Label>
    </div>
    <asp:Panel runat="server" ID="pnlLure" Visible="True">
        <asp:Label runat="server" ID="lblLureList" Text="Liste des leurres" CssClass="title"></asp:Label>
        <atmtech:GrilleAvance ID="grdLureList" GridLines="None" runat="server" Visible="true"
            TypeName="ATMTECH.FishingAtWork.Views.ShoppingPresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
            EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.DTO.LurePlayerLure"
            EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
            AEnteteAffiche="True" SelectMethod="GetLure" SelectCountMethod="GetLureCount"
            MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
            SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
            ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
            PagerSettings="TopAndBottom" PageSize="30" OnRowCommand="LureRowCommandClick">
            <columns>
           
                        <asp:TemplateField HeaderText="Nom">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("Lure.Name")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                         <asp:TemplateField HeaderText="Prix">
                             <ItemStyle Width="55px" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblSiteName" Text='<%#Eval("Lure.Price","{0:c}")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="En possession">
                             <ItemStyle Width="55px" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblOwned" Text='<%#Eval("PlayerLure.Quantity")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantité">
                            <ItemStyle Width="50px"></ItemStyle>
                        <ItemTemplate>
                            
                              <div style="text-align: center;">
                                  <atmtech:AlphaNumTextBoxAvance runat="server" ID="txtQuantity" EstNumeriqueSeul="True" Width="35px"/>   
                              </div>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="35px"></ItemStyle>
                            <ItemTemplate>
                             <div style="text-align: center;">  <asp:ImageButton runat="server" CommandName="AddToCart" ID="btnAddToCart" AlternateText="Ajouter au panier" ImageUrl="Images/ajouter.png" CommandArgument='<%#Eval("Id")%>'></asp:ImageButton></div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
        </atmtech:GrilleAvance>
    </asp:Panel>
</asp:Content>
