<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="WallPost.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.WallPost" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.2.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headerWizard">
        <asp:Label runat="server" ID="lblWallPost" Text="Forum"></asp:Label>
    </div>
    <asp:Panel runat="server" ID="pnlPostList" Visible="True">
        <atmtech:GrilleAvance ID="grdLureList" GridLines="None" runat="server" Visible="true"
            TypeName="ATMTECH.FishingAtWork.Views.WallPostPresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
            EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.DTO.WallPostDTO"
            EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
            AEnteteAffiche="False" SelectMethod="GetWallPost" SelectCountMethod="GetWallPostCount"
            MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
            SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
            ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
            PagerSettings="TopAndBottom" PageSize="30">
            <columns>
                <asp:TemplateField>
                   <ItemTemplate>
                        <div style="width:100px;float:left;">
                            <asp:Image runat="server" ID="imgPlayer" ImageUrl='<%#Eval("Player.Image")%>' Width="100" height="100"/>
                            <asp:Label runat="server" ID="lblFirstNameLastName" Text='<%#Eval("Player.User.FirstNameLastName")%>'></asp:Label>
                        </div>
                        <div style="float:left;padding-left:10px;padding-bottom: 5px;padding-top: 5px;padding-right: 15px;">
                            <asp:Label runat="server" ID="lblName" Text='<%#Eval("WallPost.Post")%>'></asp:Label>    
                            <asp:Label runat="server" ID="lblPostedDate" Text="Posté le : "></asp:Label><asp:Label runat="server" ID="lblDateCreated" Text='<%#Eval("WallPost.DateCreated")%>'></asp:Label>    
                        </div>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                </columns>
        </atmtech:GrilleAvance>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnWritePost" OnClick="WritePostClick" Text="Ajouter un message"
                CssClass="button" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlWritePost" Visible="False">
        <asp:Label runat="server" ID="lblWritePost" Text="Écrire un commentaire sur le forum"></asp:Label>
        <CKEditor:CKEditorControl ID="CKEditorEditorPost" runat="server" Height="235" EnterMode="BR"
            Toolbar="Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent|Table
/
Styles|Format|Font|FontSize|TextColor|BGColor|">
        </CKEditor:CKEditorControl>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnSavePost" OnClick="SavePostClick" Text="Enregistrer"
                CssClass="button" />
            <asp:Button runat="server" ID="btnCancelPost" OnClick="CancelPostClick" Text="Annuler"
                CssClass="button" />
        </div>
    </asp:Panel>
</asp:Content>
