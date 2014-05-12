<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="FileUpload.aspx.cs" Inherits="ATMTECH.Administration.FileUpload" EnableEventValidation="false" %>

<%@ Register Assembly="obout_FileUpload" Namespace="OboutInc.FileUpload" TagPrefix="fup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input.textBoxAvance, textarea.textBoxAvance
        {
            border: 1px solid gray;
            padding: 0 1px;
            color: #333333;
        }

        input.textBoxAvance, textarea, .dxeListBox, input.dxeEditArea
        {
            font-size: 12px;
        }
    </style>
    <div class="title">
        Les images
    </div>

    Sélectionner un emplacement à visualiser: 
    
    <asp:DropDownList runat="server" ID="ddlSiteList" AutoPostBack="True">
        <asp:ListItem Value="E:\cima-directeur.boutiquecorpo.com\Images">cima-directeur.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="E:\cima-employe.boutiquecorpo.com\Images">cima-employe.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="E:\ursulines.boutiquecorpo.com\Images">ursuline.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="E:\glv.boutiquecorpo.com\Images">glv.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="E:\glv-an.boutiquecorpo.com\Images">glv-an.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\dev\Atmtech\ATMTECH.ShoppingCart.PubJL\Images">Développement</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <div>
        Emplacement des images:
        <asp:Label runat="server" ID="lblRootPathImage"></asp:Label>
        <table width="100%">
            <tr>
                <td style="width: 30%;" valign="top">
                    <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                        <legend><b>Sélectionner l'emplacement de transfert</b></legend>Pour:
                        <asp:DropDownList runat="server" ID="cboType">
                            <asp:ListItem Value="Product">Un produit</asp:ListItem>
                            <asp:ListItem Value="Enterprise">Une entreprise</asp:ListItem>
                        </asp:DropDownList>
                    </fieldset>
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" class="multi" />
                    <br />
                    <div style="background-color: lightgray; border: solid 1px gray; padding: 5px 5px 5px 5px;">
                        <asp:Button runat="server" ID="btnUpload" Text="Transférer tout les fichiers" OnClick="BtnUploadClick"
                            CausesValidation="False" CssClass="button" />
                        <asp:Button runat="server" ID="btnResize" Text="Reformater tout les fichiers de produits" OnClick="btnResizeClick"
                            CausesValidation="False" CssClass="button" />
                    </div>
                    <br />
                    <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                        <legend><b>Liste des fichiers transférés</b></legend>
                        <asp:Label runat="server" ID="lblTransferedFile"></asp:Label>
                    </fieldset>
                </td>
                <td style="width: 70%;" valign="top">

                    <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                        <legend><b>Liste des fichiers sur le serveur pour les produits</b></legend>
                        <asp:GridView runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ID="grdFile"
                            AllowPaging="True" AutoGenerateColumns="False" PageSize="10"
                            OnPageIndexChanging="PageIndexChanging" Font-Size="11px" EmptyDataText="Aucune données ..." OnRowCommand="RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="Id" SortExpression="Id"></asp:BoundField>
                                <asp:BoundField HeaderText="Fichier" DataField="FileName" SortExpression="FileName"></asp:BoundField>
                                <asp:BoundField HeaderText="Titre" DataField="Title" SortExpression="Title"></asp:BoundField>
                                <asp:BoundField HeaderText="Description" DataField="Description" SortExpression="Description"></asp:BoundField>
                                <asp:BoundField HeaderText="Taille" DataField="Size" SortExpression="Size"></asp:BoundField>
                                <asp:BoundField HeaderText="Catégorie" DataField="Category" SortExpression="Category"></asp:BoundField>
                                <asp:BoundField HeaderText="Modifié le" DataField="DateModified" SortExpression="DateModified"></asp:BoundField>
                                <asp:BoundField HeaderText="Crée le" DataField="DateCreated" SortExpression="DateCreated"></asp:BoundField>
                                <asp:ButtonField CommandName="Edition" ImageUrl="Images/edition.png" ButtonType="Image" />
                                <asp:ButtonField CommandName="Supprimer" ImageUrl="Images/supprimer.gif" ButtonType="Image" />
                            </Columns>
                        </asp:GridView>
                    </fieldset>

                    <asp:Panel runat="server" ID="pnlEdit" Visible="False">
                        <table>
                            <tr>
                                <td>Id:</td>
                                <td>
                                    <asp:Label runat="server" ID="lblId"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Fichier:</td>
                                <td>
                                    <asp:Label runat="server" ID="lblFile"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Titre:</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Description:</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDescription"></asp:TextBox></td>
                            </tr>
                        </table>
                        <asp:Button runat="server" CssClass="button" ID="btnSave" OnClick="SaveFile" Text="Enregistrer" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <div class="title">
        La base de données
    </div>
    <div>
        <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
            <legend><b>Télécharger la base de données</b></legend>
            <asp:Button runat="server" ID="btnTelecharger" OnClick="btnTelechargerClick" Text="Télécharger la base de données" CssClass="button" />
        </fieldset>
        <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
            <legend><b>Téléverser une nouvelle base de données</b></legend>
            <asp:FileUpload ID="FileUpload2" runat="server" class="multi" />
            <asp:Button runat="server" ID="btnTeleverser" OnClick="btnTeleverserClick" Text="Téléverser la base de données" CssClass="button" />
        </fieldset>
    </div>
</asp:Content>
