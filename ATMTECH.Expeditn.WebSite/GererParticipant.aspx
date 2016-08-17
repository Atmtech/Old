<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererParticipant.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererParticipant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container">
            <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <h2 class="header2">
                        <asp:Label ID="lblEtape2CreationNouvelleExpedition" runat="server" Text="Ajouter des participants"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>
                    <table style="width: 100%">
                        <tr>
                            <td style="padding-right: 15px;">
                                <asp:TextBox runat="server" ID="txtRechercheUtilisateur" placeholder="Rechercher des utilisateurs" class="controlEditable"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lnkRechercherUtilisateur" Text="Rechercher utilisateur" class="mbr-buttons__btn btn btn-standard" OnClick="lnkRechercherUtilisateurClick"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">


                                <asp:DataList ID="listeUtilisateur" runat="server" OnItemCommand="listeUtilisateurItemCommand" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <div style="float: Left;">
                                            <asp:Image runat="server" ID="imgParticipant" ImageUrl='<%#  Eval("Image") %>' Style="border-radius: 50%; width: 100px; height: 100px;" />
                                        </div>
                                        <div style="padding-left: 10px; float: Left;">
                                            <b>
                                                <asp:Label runat="server" ID="lblNomUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>'></asp:Label></b>
                                            <div style="font-size: 13px;">
                                                <asp:Label runat="server" ID="lblInscriptDepuis" Text="Inscrit depuis: "></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Text='<%# Eval("Utilisateur.DateCreated")  %>'></asp:Label>
                                            </div>
                                            <asp:LinkButton runat="server" ID="lnkAjouterUtilisateur" Text="Ajouter ce participant" CssClass="boutonAjout" CommandArgument='<%# Eval("Utilisateur.Id")  %>' CommandName="ajouter"></asp:LinkButton>
                                        </div>

                                        <div style="float: Left; width: 120px;"></div>
                                    </ItemTemplate>
                                </asp:DataList>

                                <asp:Label runat="server" ID="lblAucuneRechercheUtilisateurEffectue" Text="Aucun utilisateur retrouvé ..."></asp:Label>
                            </td>
                        </tr>
                    </table>


                    <h3 class="header3">
                        <asp:Label runat="server" ID="lblListeDesParticipant" Text="Liste des participants"></asp:Label></h3>

                    <asp:DataList ID="listeParticipant" runat="server" OnItemCommand="listeUtilisateurItemCommand" RepeatDirection="Horizontal">
                        <ItemTemplate>

                            <div style="float: Left;">
                                <asp:Image runat="server" ID="imgParticipant" ImageUrl='<%#  Eval("Image") %>' Style="border-radius: 50%; width: 100px; height: 100px;" />
                            </div>
                            <div style="padding-left: 10px; float: Left;">
                                <b>
                                    <asp:Label runat="server" ID="lblNomUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>'></asp:Label></b>
                                <div>
                                    <asp:Label runat="server" ID="lblEstChefDeGroupe" Text="Administrateur: "></asp:Label>
                                    <asp:Label runat="server" ID="lblEstAdministrateur" Font-Bold="True" Text='<%# Eval("EstAdministrateur").ToString() == "False" ? "Non" : "Oui" %>'></asp:Label>
                                </div>
                                <asp:LinkButton runat="server" ID="lnkRetirerUtilisateur" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Utilisateur.Id")  %>' CommandName="retirer"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierUtilisateur" Text="Modifier" CssClass="boutonModifier" CommandArgument='<%# Eval("Id")  %>' CommandName="modifier"></asp:LinkButton>
                            </div>
                            <div style="float: Left; width: 120px;"></div>
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
                   <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>

</asp:Content>
