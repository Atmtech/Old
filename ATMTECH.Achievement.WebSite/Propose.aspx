<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true" CodeBehind="Propose.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.Propose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 10px; margin-right: 10px; text-align: left; background-color: white; border-radius: 10px;">
        <div style="padding: 10px 10px 10px 10px;">

            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Titre obligatoire" ControlToValidate="txtTitre" ValidationGroup="proposer" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description obligatoire" ControlToValidate="txtDescription" ValidationGroup="proposer" Display="None"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Catégorie obligatoire" ControlToValidate="ddlCategorie" ValidationGroup="proposer" Display="None"></asp:RequiredFieldValidator>--%>

            <h1>Proposer un accomplissement</h1>

            <asp:Panel runat="server" ID="pnlEtape1" Visible="True">
                <h2>Étape 1 - Information générale (1 de 4)</h2>

                <table style="text-align: left; width: 100%;">
                    <tr>
                        <td>Saisir un titre
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtTitre" runat="server" Style="width: 100%;" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Saisir une description</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Style="width: 100%;"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Saisir la catégorie</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlCategorie" runat="server" /></td>
                    </tr>
                </table>
                <asp:Button runat="server" ID="btnEtape2" Text="Étape 2 - Sélectionner la couleur de fond" CssClass="bouton" OnClick="btnEtape2Click" />
                <asp:Button runat="server" ID="btnAnnuler2" Text="Annuler" CssClass="bouton" OnClick="btnAnnulerClick" />
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlEtape2" Visible="False">
                <h2>Étape 2 - Sélectionner la couleur de fond (2 de 4)</h2>
                <asp:DropDownList ID="ddlCouleur" runat="server" Style="width: 100%;" />
                <asp:Button runat="server" ID="btnEtape3" Text="Étape 3 - Sélectionner l'image de fond" CssClass="bouton" OnClick="btnEtape3Click" />
                <asp:Button runat="server" ID="btnAnnuler3" Text="Annuler" CssClass="bouton" OnClick="btnAnnulerClick" />
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlEtape3" Visible="False">
                <h2>Étape 3 - Sélectionner l'image de fond (3 de 4)</h2>
                <table>
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="pnlImage" ScrollBars="Vertical" Height="200px">
                                <asp:DataList runat="server" ID="datalistImage" OnItemCommand="OnItemCommandClick" RepeatColumns="20" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"images/badge/" +  Eval("Filename")  %>' CssClass="listeImageProposerAccomplissement" CommandArgument='<%# Eval("Id") + "#" + Eval("Filename")  %>' CommandName="selectionnerImage" />
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                        <td style="padding-left: 100px;">Image sélectionné:
                            <br />
                            <asp:Image runat="server" ID="imgSelectionne" />
                        </td>
                    </tr>
                </table>

                <br />
                <asp:Button runat="server" ID="btnEtape4" Text="Étape 4 - Sélectionner les traits (Qualités / défauts) associé à l'accomplissement" CssClass="bouton" OnClick="btnEtape4Click" />
                <asp:Button runat="server" ID="btnAnnuler4" Text="Annuler" CssClass="bouton" OnClick="btnAnnulerClick" />
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlEtape4" Visible="False">
                <h2>Étape 4 - Sélectionner les traits (Qualités / défauts) associé à l'accomplissement (4 de4)</h2>
                <atmtech:VaseCommuniquantAvance runat="server" ID="listeTraits" CssClassFlecheDroite="vaseCommuniquantFleche" CssClassFlecheGauche="vaseCommuniquantFleche" />
                <asp:Button runat="server" ID="btnSommaire" Text="Sommaire" CssClass="bouton" OnClick="btnSommaireClick" />
                <asp:Button runat="server" ID="btnAnnuler5" Text="Annuler" CssClass="bouton" OnClick="btnAnnulerClick" />
            </asp:Panel>
           
            <asp:Panel runat="server" ID="pnlSommaire" Visible="False">
                <h2>Sommaire</h2>
                <asp:PlaceHolder runat="server" ID="placeHolderSommaire"></asp:PlaceHolder>
                <asp:Button runat="server" ID="btnAjouterAccomplissement" Text="Proposer cet accomplissement" CssClass="bouton" OnClick="btnAjouterAccomplissementClick" />
                <asp:Button runat="server" ID="btnAnnuler7" Text="Annuler" CssClass="bouton" OnClick="btnAnnulerClick" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
