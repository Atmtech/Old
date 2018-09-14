<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererNourriture.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererNourriture" %>

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
                        <asp:Label ID="lblEtape4CreationNouvelleEtape" runat="server" Text="Création du menu"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>

                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <div>
                                    <div class="libelleChampsEditable">
                                        <asp:Label ID="lblLibelleNomMenu" runat="server" Text="Nom du menu"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtNomMenu" placeholder="Nom"  CssClass="controlEditable"></asp:TextBox>

                                    <div class="libelleChampsEditable">
                                        <asp:Label ID="lblDateMenu" runat="server" Text="Date"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlDateMenu" placeholder="Date" CssClass="controlEditable"></asp:DropDownList>

                                    <div class="libelleChampsEditable">
                                        <asp:Label ID="lblMenuDetaille" runat="server" Text="Menu"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtMenu" TextMode="MultiLine" Rows="5" CssClass="controlEditableMultiligne" Width="100%"></asp:TextBox>
                                    <div class="libelleChampsEditable">
                                        <asp:Label ID="lblCuisinier" runat="server" Text="Cuisinier"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlParticipant" CssClass="controlEditable"></asp:DropDownList>

                                </div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:LinkButton runat="server" ID="lnkAjouterMenu" Text="Enregistrer ce menu" class="mbr-buttons__btn btn btn-standard" OnClick="lnkAjouterMenuClick"></asp:LinkButton>

                    <asp:LinkButton runat="server" ID="lnkImprimerMenu" Text="Imprimer le menu de l'expédition" class="mbr-buttons__btn btn btn-standard" OnClick="lnkImprimerMenuClick"></asp:LinkButton>
                    <br />
                    <h3 class="header3">
                        <asp:Label ID="lblListeMenu" runat="server" Text="Liste des menus"></asp:Label>
                    </h3>


                    <asp:DataList ID="listeNourriture" runat="server" OnItemCommand="listeNourritureItemCommand" OnItemDataBound="listeNourritureItemDataBound" RepeatDirection="Horizontal" RepeatColumns="3">
                        <ItemTemplate>

                            <div style="float: Left;">
                                <img src="Images/Medias/AucuneImage.gif" alt="" style="border-radius: 50%;" />
                            </div>
                            <div style="padding-left: 10px; float: Left; padding-right: 15px; margin-bottom: 10px;">

                                <b>
                                    <asp:Label runat="server" ID="lblNomMenu" Text='<%# Eval("Nom") + " (" + Eval("Cuisinier.Utilisateur.FirstNameLastName") + ")"  %>'></asp:Label></b>
                                <div class="affichageListe" style="padding-bottom: 10px;">
                                    <asp:Label runat="server" ID="lblDateNourriture" Text='<%# Eval("Date","{0:yyyy-MM-dd}")  %>'></asp:Label><br />
                                </div>
                                <asp:LinkButton runat="server" ID="lnkRetirerMenu" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Id")  %>' CommandName="retirer"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierMenu" Text="Modifier" CssClass="boutonModifier" CommandArgument='<%# Eval("Id")  %>' CommandName="modifier"></asp:LinkButton>
                            </div>

                            <div style="clear: left; padding-bottom: 20px;">
                                <b>
                                    <asp:Label runat="server" ID="lblListeParticipant" Text="Liste participant au repas"></asp:Label></b>
                                <br />


                                <table>
                                    <asp:Repeater ID="listeParticipant" runat="server" OnItemCommand="listeParticipantItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="width: 25px;">

                                                    <asp:Label runat="server" ID="lblIdParticipant" Text='<%# Eval("IdParticipant")  %>' Visible="False"></asp:Label>
                                                    <asp:Label runat="server" ID="lblIdNourriture" Text='<%# Eval("Nourriture.Id")  %>' Visible="False"></asp:Label>
                                                    <asp:Label runat="server" ID="lblIdNourritureParticipant" Text='<%# Eval("IdNourritureParticipant")  %>' Visible="False"></asp:Label>
                                                    <asp:LinkButton runat="server" ID="lnkRetirerParticipant" Text="Retirer" CssClass="boutonEnlever" Visible='<%# Convert.ToBoolean(Eval("EstParticipantNourriture"))  %>' CommandName="retirer"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="lnkAjouterParticipant" Text="Ajouter" CssClass="boutonAjout" Visible='<%# !Convert.ToBoolean(Eval("EstParticipantNourriture"))  %>' CommandName="ajouter"></asp:LinkButton>
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
                <Triggers>
                    <asp:PostBackTrigger ControlID="lnkImprimerMenu" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
