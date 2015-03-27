<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="FileUpload.aspx.cs" Inherits="ATMTECH.Administration.FileUpload" EnableEventValidation="false" %>

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
        Gestion des fichiers
    </div>

    Sélectionner un emplacement à visualiser: 
    
    <asp:DropDownList runat="server" ID="ddlSiteList" AutoPostBack="True">
        <asp:ListItem Value="C:\WebSite\cima-directeur.boutiquecorpo.com\Images">cima-directeur.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\cima-employe.boutiquecorpo.com\Images">cima-employe.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\ursulines.boutiquecorpo.com\Images">ursuline.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\glv.boutiquecorpo.com\Images">glv.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\glv-an.boutiquecorpo.com\Images">glv-an.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\lauzon.boutiquecorpo.com\Images">lauzon.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\inrs.boutiquecorpo.com\Images">inrs.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\WebSite\dev.boutiquecorpo.com\Images">dev.boutiquecorpo.com</asp:ListItem>

        <%--<asp:ListItem Value="C:\Domains\cima-directeur.boutiquecorpo.com\www\Images">cima-directeur.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\cima-employe.boutiquecorpo.com\www\Images">cima-employe.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\ursulines.boutiquecorpo.com\www\Images">ursuline.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\glv.boutiquecorpo.com\www\Images">glv.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\glv-an.boutiquecorpo.com\www\Images">glv-an.boutiquecorpo.com</asp:ListItem>
        <asp:ListItem Value="C:\Domains\lauzon.boutiquecorpo.com\www\Images">lauzon.boutiquecorpo.com</asp:ListItem>--%>
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



                    </div>
                    <br />
                    <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                        <legend><b>Liste des fichiers transférés</b></legend>
                        <asp:Label runat="server" ID="lblTransferedFile"></asp:Label>
                    </fieldset>

                    <div style="background-color: lightgray; border: solid 1px gray; padding: 5px 5px 5px 5px;margin-top: 10px;">
                        Saisir votre ratio:
                        <asp:TextBox runat="server" ID="txtRatio"></asp:TextBox>px <br />
                        <asp:Button runat="server" ID="btnResize" Text="Reformater tout les fichiers de produits" OnClick="btnResizeClick"
                            CausesValidation="False" CssClass="button" />
                    </div>
                </td>
                <td style="width: 70%;" valign="top">

                    <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                        <legend><b>Liste des fichiers sur le serveur pour les produits</b></legend>
                        <asp:TextBox runat="server" ID="txtFilter"></asp:TextBox>
                        <asp:Button runat="server" ID="btnFilter" Text="Filtrer" OnClick="btnFilterClick" />
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

                    <asp:Panel runat="server" ID="pnlEdit" Visible="False" BorderStyle="Solid">
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

</asp:Content>
