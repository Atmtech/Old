<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Ranking.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.Ranking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="lblRanking" Text="Classements"></asp:Label>
    </div>
    <atmtech:GrilleAvance ID="grdLureList" GridLines="None" runat="server" Visible="true"
        TypeName="ATMTECH.FishingAtWork.Views.RankingPresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
        EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.DTO.PlayerDTO"
        EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
        AEnteteAffiche="True" SelectMethod="GetRanking" SelectCountMethod="GetPlayerCount"
        MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
        SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
        ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
        PagerSettings="TopAndBottom" PageSize="30">
        <columns>
           
                        <asp:TemplateField HeaderText="Rang">
                            <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblRank" Text='<%#Eval("Rank")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nom">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblFirstNameLastName" Text='<%#Eval("Player.User.FirstNameLastName")%>'></asp:Label>
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

                        
                        <asp:TemplateField HeaderText="Solde">
                             <ItemStyle Width="55px" HorizontalAlign="Center"></ItemStyle>
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblMoney" Text='<%#Eval("Player.Money","{0:c}")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
    </atmtech:GrilleAvance>
</asp:Content>
