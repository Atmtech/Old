<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererEtape.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererEtape" %>

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
                        <asp:Label ID="lblEtape3CreationNouvelleEtape" runat="server" Text="Ajouter des activités"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>

                    <table style="width: 100%">
                        <tr>
                            <td>

                                <div class="libelleChampsEditable">
                                    <asp:Label ID="lblNomEtape" runat="server" Text="Nom de l'étape"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="txtNomEtape" placeholder="Nom de l'étape"  CssClass="controlEditable"></asp:TextBox>
                                <div class="libelleChampsEditable">
                                    <asp:Label ID="lblDateDebutEtape" runat="server" Text="Date de début"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="txtDebutEtape" placeholder="Date de début" CssClass="controlEditable"></asp:TextBox>
                                <div class="libelleChampsEditable">
                                    <asp:Label ID="lblDateFin" runat="server" Text="Date de fin"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="txtFinEtape" placeholder="Date de fin" CssClass="controlEditable"></asp:TextBox>
                                <div style="border-bottom: solid 1px gray">
                                    <asp:Label ID="lblMoyenTransport" runat="server" Text="Moyen de transport"></asp:Label>
                                </div>
                                <asp:DropDownList runat="server" ID="ddlVehicule" placeholder="Vehicule" CssClass="controlEditable"></asp:DropDownList>

                            </td>
                            <td style="vertical-align: top;">
                                <div class="libelleChampsEditable">
                                    <asp:Label ID="lblDistance" runat="server" Text="Distance"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="txtDistance" placeholder="Distance" CssClass="controlEditable"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:LinkButton runat="server" ID="lnkAjouterActiviteExpedition" Text="Enregistrer cette activité" class="mbr-buttons__btn btn btn-standard" OnClick="lnkAjouterActiviteExpeditionClick"></asp:LinkButton>
                    <br />
                    <hr />
                    <h2 class="header3">
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
                                <div class="affichageListe" style="padding-bottom: 10px;">
                                    <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                    <i class="fa fa-hand-o-right"></i>
                                    <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label><br />
                                    <asp:Label runat="server" ID="lblVehicule" Text='<%# Eval("Vehicule.Annee") + " " + Eval("Vehicule.Nom") + " (" + Eval("Vehicule.Fabriquant") + ")"  %>'></asp:Label><br />
                                </div>
                                <asp:LinkButton runat="server" ID="lnkRetirerActivite" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Id")  %>' CommandName="retirer"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierActivite" Text="Modifier" CssClass="boutonModifier" CommandArgument='<%# Eval("Id")  %>' CommandName="modifier"></asp:LinkButton>
                            </div>

                            <div style="clear: left;padding-bottom: 20px;">
                                <b>
                                    <asp:Label runat="server" ID="lblListeParticipant" Text="Liste des participants"></asp:Label></b>
                                <br />
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
                                                <td class="affichageSousListe" style="padding-left: 10px; padding-bottom: 10px;">
                                                    <asp:Label runat="server" ID="lblParticipant" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>'></asp:Label>

                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <br />
                    <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
