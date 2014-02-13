<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminSpecies.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.AdminSpecies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        Liste des espèces
    </div>
    <atmtech:GrilleAvance ID="grdSpeciesList" GridLines="None" runat="server" Visible="true"
        TypeName="ATMTECH.FishingAtWork.Views.AdminSpeciesPresenter" DataKeyNames="Id"
        EstAfficheColonneEdition="False" EstAfficheColonneSuppression="false" ActiverBoutonAjout="false"
        DataObjectTypeName="ATMTECH.FishingAtWork.Entities.Species" EstPermiPagination="true"
        EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun." AEnteteAffiche="True"
        SelectMethod="GetSpecies" SelectCountMethod="GetSpeciesCount" MaximumRowsParameterName="nbEnreg"
        StartRowIndexParameterName="indexDebutRangee" SortParameterName="parametreTrie"
        EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter" ToolTipBoutonConsulter="Consulter"
        ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true" PagerSettings="TopAndBottom"
        PageSize="30" OnRowCommand="RowCommandClick">
        <columns>
           
                        <asp:TemplateField HeaderText="Espèces">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblSpeciesName" Text='<%#Eval("Name")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Poids max">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblMaximumWeight" Text='<%#Eval("MaximumWeight")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Poids min">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblMinimumWeight" Text='<%#Eval("MinimumWeight")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Leurre possible">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblLureCount" Text='<%#Eval("LureCount")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                             <div style="text-align: center;">  <asp:ImageButton runat="server" CommandName="OpenSpecies" ID="btnOpenSpecies" AlternateText="Ouvrir le Species" ImageUrl="Images/edition.png" CommandArgument='<%#Eval("Id")%>'></asp:ImageButton></div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
    </atmtech:GrilleAvance>
</asp:Content>
