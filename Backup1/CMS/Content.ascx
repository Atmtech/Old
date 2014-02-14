<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content.ascx.cs" Inherits="ATMTECH.BillardLoretteville.Website.CMS.Content" %>
<%@ Register Src="FileUpload.ascx" TagName="FileUpload" TagPrefix="uc1" %>
<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.2.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<asp:Label runat="server" ID="lblValue"></asp:Label>
<asp:Panel runat="server" ID="pnlCommand">
    <div class="menuCms">
        [
        <asp:ImageButton runat="server" ID="lnkEdit" ImageUrl="~/Images/edition.png" AlternateText="Édition"
            OnClick="OnOpenEdit" ValidationGroup="OpenWindow"></asp:ImageButton>
        <asp:ImageButton runat="server" ID="lnkAddfile" ImageUrl="~/Images/ajouterFichier.png"
            AlternateText="Ajouter fichier" OnClick="OnOpenAddFile" ValidationGroup="OpenWindow">
        </asp:ImageButton>
        ]
    </div>
    <atmtech:FenetreDialogue runat="server" ID="FileUploadWindow" Titre="Téléverser du contenu"
        Largeur="800" Hauteur="700">
        <div style="font-size: 1.5em;">
            <uc1:FileUpload ID="FileUpload1" runat="server" />
        </div>
    </atmtech:FenetreDialogue>
    <atmtech:FenetreDialogue runat="server" ID="ContentWindow" Titre="Édition du contenu"
        Largeur="800" Hauteur="500" OnFermer="OnClose">
        <atmtech:ValidationSummaryAvance runat="server" ID="validation" ValidationGroup="save" />
        <table width="100%">
            <tr>
                <td valign="top" width="25%">
                    <atmtech:TitreLabelAvance runat="server" ID="lblPageList" Text="Liste des pages"></atmtech:TitreLabelAvance>
                    <hr />
                    <asp:DataList runat="server" ID="pageList">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lblPage" Text='<%# Bind("Description") %>' OnClick="OpenPage"
                                CommandArgument='<%# Bind("Id") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td width="75%" style="border-left-style: solid 1px black;">
                    <table>
                        <tr>
                            <atmtech:TextBoxAvance runat="server" ID="txtPageName" EstObligatoire="true" Libelle="Identifiant:"
                                ValidationGroup="save" />
                            <atmtech:TextBoxAvance runat="server" ID="txtDescription" EstObligatoire="true" Libelle="Description:"
                                ValidationGroup="save" />
                        </tr>
                        <tr>
                            <atmtech:ComboBoxAvance runat="server" ID="cboLanguage" Libelle="Langue:" EstObligatoire="true"
                                ValidationGroup="save" />
                        </tr>
                    </table>
                    <CKEditor:CKEditorControl ID="CKEditorEditorContent" runat="server" Height="435"
                        EnterMode="BR" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent|Table
/
Styles|Format|Font|FontSize|TextColor|BGColor|-|About">
                    </CKEditor:CKEditorControl>
                 
                    <div class="menuCms">
                        <asp:Button runat="server" ID="btnSaveContent" Text="Enregistrer" OnClick="OnSaveContent"
                            ValidationGroup="save" />
                        <asp:Button runat="server" ID="btnAddContent" Text="Ajouter une page" OnClick="OnAddContent"
                            ValidationGroup="save" />
                        <asp:Button runat="server" ID="btnCancelContent" Text="Annuler" OnClick="OnClose"
                            ValidationGroup="cancel" />
                    </div>
                </td>
            </tr>
        </table>
    </atmtech:FenetreDialogue>
</asp:Panel>
