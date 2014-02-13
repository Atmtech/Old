<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminSite.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.AdminSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        Liste des sites
    </div>
    <atmtech:GrilleAvance ID="grdSiteList" GridLines="None" runat="server" Visible="true"
        TypeName="ATMTECH.FishingAtWork.Views.AdminSitePresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
        EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.Site"
        EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
        AEnteteAffiche="True" SelectMethod="GetSite" SelectCountMethod="GetSiteCount"
        MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
        SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
        ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
        PagerSettings="TopAndBottom" PageSize="30" OnRowCommand="RowCommandClick">
        <columns>
           
                        <asp:TemplateField HeaderText="Site">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblSiteName" Text='<%#Eval("Name")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Latitude">
                        <ItemTemplate>
                              <div style="text-align: center;">   <asp:Label runat="server" ID="lblLatitude" Text='<%#Eval("Latitude")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                        <asp:TemplateField HeaderText="Longitude">
                        <ItemTemplate>
                                <div style="text-align: center;"> <asp:Label runat="server" ID="lblLongitude" Text='<%#Eval("Longitude")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            
            
                        <asp:TemplateField>
                            <ItemTemplate>
                             <div style="text-align: center;">  <asp:ImageButton runat="server" CommandName="OpenSite" ID="btnOpenSite" AlternateText="Ouvrir le site" ImageUrl="Images/loupe.png" CommandArgument='<%#Eval("Id")%>'></asp:ImageButton></div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
    </atmtech:GrilleAvance>
    <asp:Panel runat="server" ID="pnlSite" Visible="False">
        <atmtech:GoogleMap ID="googleMap" runat="server" />
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="Latitude"
                    ID="txtLatitude" />
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="X" ID="txtPixelX"
                    Visible="False" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance ID="txtLongitude" runat="server" ModeAffichage="Consultation"
                    Libelle="Longitude" />
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="Y" ID="txtPixelY"
                    Visible="False" />
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
