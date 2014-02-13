<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Record.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.Record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="lblRecord" Text="Records"></asp:Label>
    </div>
      <atmtech:GrilleAvance ID="grdLureList" GridLines="None" runat="server" Visible="true"
        TypeName="ATMTECH.FishingAtWork.Views.RecordPresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
        EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.Record"
        EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
        AEnteteAffiche="True" SelectMethod="GetRecord" SelectCountMethod="GetRecordCount"
        MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
        SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
        ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
        PagerSettings="TopAndBottom" PageSize="30">
        <columns>
           
            <asp:TemplateField HeaderText="Espèce">
                <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblSpecies" Text='<%#Eval("Species.Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Site">
                <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblSite" Text='<%#Eval("Site.Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Poids">
                <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblWeight" Text='<%#Eval("Weight")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
              <asp:TemplateField HeaderText="Pêcheur">
                <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
            <ItemTemplate>
                    <asp:Label runat="server" ID="lblPlayer" Text='<%#Eval("Player.User.FirstNameLastName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                    </columns>
    </atmtech:GrilleAvance>
</asp:Content>
