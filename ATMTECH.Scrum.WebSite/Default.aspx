<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Scrum.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <atmtech:FenetreDialogue runat="server" ID="windowEditStory" Titre="Édition de la story"
        Largeur="600">
        <atmtech:Story runat="server" ID="storyEdit" OnSave="CloseWindow"></atmtech:Story>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowAddStory" Titre="Ajouter une story"
        Largeur="600" OnSave="CloseWindow">
        <atmtech:Story runat="server" ID="storyAdd"></atmtech:Story>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowEditSprint" Titre="Édition de l'itération"
        Largeur="600">
        <atmtech:Sprint runat="server" ID="sprintEdit" OnSave="CloseWindow"></atmtech:Sprint>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowAddSprint" Titre="Ajouter une itération"
        Largeur="600" OnSave="CloseWindow">
        <atmtech:Sprint runat="server" ID="sprintAdd" OnSave="CloseWindow"></atmtech:Sprint>
    </atmtech:FenetreDialogue>
    <asp:UpdatePanel runat="server" ID="updpanel">
        <ContentTemplate>
            <table cellspacing="5" style="width: 100%;">
                <tr>
                    <td valign="top">
                        <div class="title">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        Les produits
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="Images/Add.png" CssClass="imageThumbnail"
                                            ImageAlign="Middle" OnClick="AddProduct" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="innerBox">
                            <asp:Repeater runat="server" ID="repeaterProduct" OnItemDataBound="repeaterProduct_ItemDataBound">
                                <ItemTemplate>
                                    <div class="items">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 20px;">
                                                    <asp:Image runat="server" ID="imgProduct" ImageUrl="Images/product.png" CssClass="imageThumbnail"
                                                        ImageAlign="Middle" />
                                                </td>
                                                <td>
                                                    <asp:HyperLink runat="server" ID="lnkProduct"></asp:HyperLink>
                                                </td>
                                                <td style="text-align: right;">
                                                    |
                                                    <asp:Label runat="server" ID="lblTotalPoint"></asp:Label>
                                                    Pts restant |
                                                    <asp:Label runat="server" ID="lblHeureRestante"></asp:Label>
                                                    Heures restantes | Créé le:
                                                    <asp:Label runat="server" ID="lblDateCreated"></asp:Label>
                                                    | Propriétaire:
                                                    <asp:Label runat="server" ID="lblProductOwner"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
