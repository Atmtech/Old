<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="PlayerList.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.PlayerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="lblRecord" Text="Liste des pêcheurs"></asp:Label>
    </div>
    <atmtech:GrilleAvance ID="grdLureList" GridLines="None" runat="server" Visible="true"
        TypeName="ATMTECH.FishingAtWork.Views.PlayerListPresenter" DataKeyNames="Id"
        EstAfficheColonneEdition="False" EstAfficheColonneSuppression="false" ActiverBoutonAjout="false"
        DataObjectTypeName="ATMTECH.FishingAtWork.Entities.PlayerListDTO" EstPermiPagination="true"
        EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun." AEnteteAffiche="True"
        SelectMethod="GetPlayerWithSite" SelectCountMethod="GetPlayerCount" MaximumRowsParameterName="nbEnreg"
        StartRowIndexParameterName="indexDebutRangee" SortParameterName="parametreTrie"
        EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter" ToolTipBoutonConsulter="Consulter"
        ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true" PagerSettings="TopAndBottom"
        PageSize="30">
        <columns>
           
            <asp:TemplateField HeaderText="Pêcheur">
                <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblPlayer" Text='<%#Eval("Player.User.FirstNameLastName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Site">
                <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblSite" Text='<%#Eval("Site.Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
              <asp:TemplateField HeaderText="Niveau">
                             <ItemStyle Width="55px" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblLevel" Text='<%#Eval("Player.Level")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="Experience">
                             <ItemStyle Width="55px" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblExperience" Text='<%#Eval("Player.Experience")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
          
                    </columns>
    </atmtech:GrilleAvance>
</asp:Content>
