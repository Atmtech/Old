<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="ATMTECH.Scrum.WebSite.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <atmtech:FenetreDialogue runat="server" ID="windowEditStory" Titre="Édition de la story"
        Largeur="600">
        <atmtech:Story runat="server" ID="storyEdit" OnSave="CloseWindow"></atmtech:Story>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowAddStory" Titre="Ajouter une story"
        Largeur="600" OnSave="CloseWindow">
        <atmtech:Story runat="server" ID="storyAdd" OnSave="CloseWindow"></atmtech:Story>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowEditSprint" Titre="Édition de l'itération"
        Largeur="600">
        <atmtech:Sprint runat="server" ID="sprintEdit" OnSave="CloseWindow"></atmtech:Sprint>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowAddSprint" Titre="Ajouter une itération"
        Largeur="600" OnSave="CloseWindow">
        <atmtech:Sprint runat="server" ID="sprintAdd" OnSave="CloseWindow"></atmtech:Sprint>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowAddTask" Titre="Ajouter une tâche"
        Largeur="600" OnSave="CloseWindow">
        <atmtech:Task runat="server" ID="taskAdd" OnSave="CloseWindow"></atmtech:Task>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="windowEditTask" Titre="Édition d'une tâche"
        Largeur="600" OnSave="CloseWindow">
        <atmtech:Task runat="server" ID="taskEdit" OnSave="CloseWindow"></atmtech:Task>
    </atmtech:FenetreDialogue>
    <div class="title">
        <a href="Default.aspx" style="color: white;"><< Accueil </a>
    </div>
    <p>
    </p>
    <table style="width: 100%;">
        <tr>
            <td>
                <div class="title">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Les itérations :
                                <asp:Label runat="server" ID="lblProduct2"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="Images/Add.png" CssClass="imageThumbnail"
                                    ImageAlign="Middle" OnClick="AddSprint" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="innerBox">
                    <asp:Repeater runat="server" ID="repeaterSprint" OnItemDataBound="repeaterSprint_ItemDataBound"
                        OnItemCommand="EditSprint">
                        <ItemTemplate>
                            <div class="items">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Image runat="server" ID="imgBullet" ImageUrl="Images/Bullet.png" CssClass="imageThumbnail"
                                                ImageAlign="Middle" />
                                            <asp:Label runat="server" ID="lblDescription"></asp:Label>
                                        </td>
                                        <td style="text-align: right; vertical-align: middle;">
                                            |
                                            <asp:Label runat="server" ID="lblTotalHour"></asp:Label>
                                            h. | Début:
                                            <asp:Label runat="server" ID="lblStart"></asp:Label>
                                            | Fin:
                                            <asp:Label runat="server" ID="lblEnd"></asp:Label>
                                            <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="Images/Edit.png" CommandName="Edit"
                                                CssClass="imageThumbnail" ImageAlign="Middle" />
                                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="Images/Delete.png" CommandName="Delete"
                                                CssClass="imageThumbnail" ImageAlign="Middle" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 5px;">
                <div class="title">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Les stories :
                                <asp:Label runat="server" ID="lblProduct"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                |
                                <asp:Label runat="server" ID="lblTotalPoint"></asp:Label>
                                pts |
                                <asp:Label runat="server" ID="lblTotalHour"></asp:Label>
                                Heures
                                <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="Images/Add.png" CssClass="imageThumbnail"
                                    ImageAlign="Middle" OnClick="AddStory" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="innerBox">
                    <asp:Repeater runat="server" ID="repeaterStory" OnItemDataBound="repeaterStory_ItemDataBound"
                        OnItemCommand="EditStory">
                        <ItemTemplate>
                            <div class="items">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Image runat="server" ID="imgBullet" ImageUrl="Images/Bullet.png" CssClass="imageThumbnail"
                                                ImageAlign="Middle" />
                                            <asp:Label runat="server" ID="lblDescription"></asp:Label>
                                        </td>
                                        <td style="text-align: right; vertical-align: middle;">
                                            |
                                            <asp:Label runat="server" ID="lblPoint"></asp:Label>
                                            Pts. | Itération:
                                            <asp:Label runat="server" ID="lblSprint"></asp:Label>
                                            | Statut:
                                            <asp:Label runat="server" ID="lblStatus"></asp:Label>
                                            <asp:ImageButton runat="server" ID="btnTask" ImageUrl="Images/Task.png" CommandName="Task"
                                                CssClass="imageThumbnail" ImageAlign="Middle" />
                                            <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="Images/Edit.png" CommandName="Edit"
                                                CssClass="imageThumbnail" ImageAlign="Middle" />
                                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="Images/Delete.png" CommandName="Delete"
                                                CssClass="imageThumbnail" ImageAlign="Middle" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel CssClass="itemsTask" runat="server" ID="pnlTask" Visible="False">
                                    <asp:Repeater runat="server" ID="repeaterTask" OnItemCommand="EditTask" OnItemDataBound="repeaterTask_ItemDataBound">
                                        <ItemTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Image runat="server" ID="imgBullet" ImageUrl="Images/Task.png" CssClass="imageThumbnail"
                                                            ImageAlign="Middle" />
                                                        <asp:Label runat="server" ID="lblTaskDescription"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right; vertical-align: middle;">
                                                        |
                                                        <asp:Label runat="server" ID="lblEstimateHour"></asp:Label>
                                                        heures estimées<asp:ImageButton runat="server" ID="btnEdit" ImageUrl="Images/Edit.png"
                                                            CommandName="Edit" CssClass="imageThumbnail" ImageAlign="Middle" />
                                                        |
                                                        <asp:Label runat="server" ID="lblTimeDoneHour"></asp:Label>
                                                        heures réelles
                                                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="Images/Delete.png" CommandName="Delete"
                                                            CssClass="imageThumbnail" ImageAlign="Middle" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </asp:Panel>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
