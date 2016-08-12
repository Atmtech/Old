<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererEtape.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererEtape" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boutonAjout {
            background-color: rgb(54, 180, 54);
            color: white;
            font-size: 12px;
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
            background-color: rgb(255, 0, 0);
            color: white;
            font-size: 12px;
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

        .boutonModifier {
            background-color: rgb(0, 160, 196);
            color: white;
            font-size: 12px;
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
            <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <h2>
                        <asp:Label ID="lblEtape3CreationNouvelleEtape" runat="server" Text="Ajouter des activités"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>

                    <table>
                        <tr>
                            <td>
                                <div class="container 50%">
                                    <asp:TextBox runat="server" ID="txtNomEtape" placeholder="Nom de l'étape" CssClass="TextBox"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtDebutEtape" placeholder="Date de début"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtFinEtape" placeholder="Date de fin"></asp:TextBox>
                                    <div style="border-bottom: solid 1px gray">
                                        <asp:Label ID="lblMoyenTransport" runat="server" Text="Moyen de transport"></asp:Label></div>
                                    <asp:DropDownList runat="server" ID="ddlVehicule" placeholder="Vehicule"></asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <div class="container 50%">
                                    <asp:TextBox runat="server" ID="txtDistance" placeholder="Distance"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton runat="server" ID="lnkAjouterActiviteExpedition" Text="Enregistrer cette activité" CssClass="button icon fa-plus" OnClick="lnkAjouterActiviteExpeditionClick"></asp:LinkButton>
                    <br />
                    <hr />
                    <h2>
                        <asp:Label ID="lblListeActivite" runat="server" Text="Liste des activités"></asp:Label>
                    </h2>


                    <asp:DataList ID="listeActivite" runat="server" OnItemCommand="listeActiviteItemCommand" OnItemDataBound="listeActiviteItemDataBound" RepeatDirection="Horizontal" RepeatColumns="3">
                        <ItemTemplate>

                            <div style="float: Left;">
                                <img src="Images/Medias/AucuneImage.gif" alt="" style="border-radius: 50%;" />
                            </div>
                            <div style="padding-left: 10px; float: Left; padding-right: 15px; margin-bottom: 10px;">

                                <b>
                                    <asp:Label runat="server" ID="lblNomActivite" Text='<%# Eval("Nom") + " (" + Eval("Distance") + " KM)"  %>'></asp:Label></b>
                                <div style="font-size: 15px;">
                                    <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                    <i class="fa fa-hand-o-right"></i>
                                    <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label><br />
                                    <asp:Label runat="server" ID="lblVehicule" Text='<%# Eval("Vehicule.Annee") + " " + Eval("Vehicule.Nom") + " (" + Eval("Vehicule.Fabriquant") + ")"  %>'></asp:Label><br />
                                </div>
                                <asp:LinkButton runat="server" ID="lnkRetirerActivite" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Id")  %>' CommandName="retirer"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierActivite" Text="Modifier" CssClass="boutonModifier" CommandArgument='<%# Eval("Id")  %>' CommandName="modifier"></asp:LinkButton>
                            </div>

                            <div style="clear: left;">
                                <b>
                                    <asp:Label runat="server" ID="lblListeParticipant" Text="Liste participant"></asp:Label></b>
                                <br />

                                <div style="font-size: 13px;">
                                    <table>
                                        <asp:Repeater ID="listeParticipant" runat="server" OnItemCommand="listeParticipantItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 25px;">
                                                        <asp:Label runat="server" ID="lblIdEtapeParticipant" Text='<%# Eval("IdEtapeParticipant")  %>' Visible="False"></asp:Label>
                                                        <asp:Label runat="server" ID="lblIdParticipant" Text='<%# Eval("IdParticipant")  %>' Visible="False"></asp:Label>
                                                        <asp:Label runat="server" ID="lblIdEtape" Text='<%# Eval("Etape.Id")  %>' Visible="False"></asp:Label>
                                                        <asp:LinkButton runat="server" ID="lnkRetirerParticipant" Text="Retirer" CssClass="boutonEnlever" Visible='<%# Convert.ToBoolean(Eval("EstParticipantEtape"))  %>' CommandName="retirer"></asp:LinkButton>
                                                        <asp:LinkButton runat="server" ID="lnkAjouterParticipant" Text="Ajouter" CssClass="boutonAjout" Visible='<%# !Convert.ToBoolean(Eval("EstParticipantEtape"))  %>' CommandName="ajouter"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblParticipant" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>'></asp:Label>
                                                        (<asp:Label runat="server" ID="lblMail" Text='<%# Eval("Utilisateur.Email")  %>'></asp:Label>)
                                                <br />
                                                    </td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
                    <asp:LinkButton runat="server" ID="lnkPasserEtape4CreationEtape" Text="Création des menus" CssClass="button icon fa-save" OnClick="lnkPasserEtape4CreationExpeditionClick"></asp:LinkButton>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </section>
</asp:Content>
