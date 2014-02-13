<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true"
    CodeBehind="AdminLure.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.AdminLure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        Liste des leurres
    </div>
    <asp:Button runat="server" ID="btnAdd" OnClick="AddClick" Text="Ajouter" CssClass="button" />
    <atmtech:GrilleAvance ID="grdLureList" GridLines="None" runat="server" Visible="true"
        TypeName="ATMTECH.FishingAtWork.Views.AdminLurePresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
        EstAfficheColonneSuppression="false" ActiverBoutonAjout="True" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.Lure"
        EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
        AEnteteAffiche="True" SelectMethod="GetLure" SelectCountMethod="GetLureCount"
        MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
        SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
        ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
        PagerSettings="TopAndBottom" PageSize="30" OnRowCommand="RowCommandClick">
        <columns>
           
                        <asp:TemplateField HeaderText="Leurre">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblLureName" Text='<%#Eval("Name")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Prix ($)">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblPrice" Text='<%#Eval("Price")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                             <div style="text-align: center;">  <asp:ImageButton runat="server" CommandName="OpenLure" ID="btnOpenLure" AlternateText="Ouvrir le leurre" ImageUrl="Images/edition.png" CommandArgument='<%#Eval("Id")%>'></asp:ImageButton></div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
    </atmtech:GrilleAvance>
    <asp:Panel runat="server" ID="pnlEdit" Visible="False">
        <div class="headerWizard">
            Édition
        </div>
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtId" Libelle="Id:" ModeAffichage="Consultation" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Nom:" />
            </tr>
            <tr>
                <atmtech:MonnaieTextBoxAvance runat="server" ID="txtPrice" Libelle="Prix:" NombreEntiers="6"
                    NombreDecimaux="2" />
            </tr>
        </table>
        <div style="background-color: lightgray; border: solid 1px gray; padding: 5px 5px 5px 5px;">
            <asp:Button runat="server" ID="btnSave" OnClick="SaveClick" Text="Enregistrer" CssClass="button" />
        </div>
    </asp:Panel>
</asp:Content>
