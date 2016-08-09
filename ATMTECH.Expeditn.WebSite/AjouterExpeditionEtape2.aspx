<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AjouterExpeditionEtape2.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.AjouterExpeditionEtape2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boutonAjout {
            background-color: rgb(54, 180, 54);
            color: white;
            font-size: 14px;
            border-radius: 20px;
            padding-top: 2px;
            padding-bottom: 2px;
            padding-left: 10px;
            padding-right: 10px;
            text-decoration: none;
            display: inline-block;
            white-space: nowrap;
            cursor: Pointer;
        }

        .boutonEnlever {
            background-color: rgb(180, 99, 99);
            color: white;
            font-size: 14px;
            border-radius: 20px;
            padding-top: 2px;
            padding-bottom: 2px;
            padding-left: 10px;
            padding-right: 10px;
            text-decoration: none;
            display: inline-block;
            white-space: nowrap;
            cursor: Pointer;
        }
    </style>
    <section id="main" class="wrapper">
        <div class="container">

            <h2>
                <asp:Label ID="lblEtape2CreationNouvelleExpedition" runat="server" Text="Ajouter des participants sur la nouvelle expédition"></asp:Label>
            </h2>
            <table>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtRechercheUtilisateur" placeholder="Rechercher des utilisateurs" CssClass="TextBox"></asp:TextBox>

                    </td>
                    <td>
                        <asp:LinkButton runat="server" ID="lnkRechercherUtilisateur" Text="Rechercher utilisateur" CssClass="button icon fa-search" OnClick="lnkRechercherUtilisateurClick"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">


                        <asp:DataList ID="listeUtilisateur" runat="server" OnItemCommand="listeUtilisateurItemCommand" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <div style="float: Left;">
                                    <img src="Images/profile_placeholder.gif" alt="" style="border-radius: 50%;" />
                                </div>
                                <div style="padding-left: 10px; float: Left;">
                                    <b>
                                        <asp:Label runat="server" ID="lblNomUtilisateur" Text='<%# Eval("FirstNameLastName")  %>'></asp:Label></b>
                                    <div style="font-size: 13px;">
                                        <asp:Label runat="server" ID="lblInscriptDepuis" Text="Inscrit depuis: "></asp:Label>
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("DateCreated")  %>'></asp:Label>
                                    </div>
                                    <asp:LinkButton runat="server" ID="lnkAjouterUtilisateur" Text="Ajouter" CssClass="boutonAjout" CommandArgument='<%# Eval("Id")  %>' CommandName="ajouter"></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>

                        <asp:Label runat="server" ID="lblAucuneRechercheUtilisateurEffectue" Text="Aucun utilisateur retrouvé ..."></asp:Label>
                    </td>
                </tr>
            </table>


            <h2>
                <asp:Label runat="server" ID="lblListeDesParticipant" Text="Liste des participants"></asp:Label></h2>

            <asp:DataList ID="listeParticipant" runat="server" OnItemCommand="listeUtilisateurItemCommand" RepeatDirection="Horizontal">
                <ItemTemplate>

                    <div style="float: Left;">
                        <img src="Images/profile_placeholder.gif" alt="" style="border-radius: 50%;" />
                    </div>
                    <div style="padding-left: 10px; float: Left;">

                        <b>
                            <asp:Label runat="server" ID="lblNomUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>'></asp:Label></b>
                        <div>
                            <asp:Label runat="server" ID="lblEstChefDeGroupe" Text="Administrateur: "></asp:Label>
                            <asp:Label runat="server" ID="lblEstAdministrateur" Font-Bold="True" Text='<%# Eval("EstAdministrateur").ToString() == "False" ? "Non" : "Oui" %>'></asp:Label>
                        </div>
                        <asp:LinkButton runat="server" ID="lnkRetirerUtilisateur" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Utilisateur.Id")  %>' CommandName="retirer"></asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:DataList>

            <asp:LinkButton runat="server" ID="lnkPasserEtape3CreationExpedition" Text="Ajouter des activités à votre expédition" CssClass="button icon fa-save" OnClick="lnkPasserEtape3CreationExpeditionClick"></asp:LinkButton>
        </div>
    </section>
</asp:Content>
