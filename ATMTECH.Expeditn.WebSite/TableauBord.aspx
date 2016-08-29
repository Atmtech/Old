<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.TableauBord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
     
    </style>

    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">

        <div class="mbr-section__container mbr-section__container--std-padding container" style="padding-top: 93px; padding-bottom: 93px;">
            <div class="row">
                <br />
                <h2 class="header2">
                    <asp:Label runat="server" ID="lblMesExpedition" Text="Mes expéditions"></asp:Label></h2>
                <asp:LinkButton runat="server" ID="lnkAjouterUneExpedition" Text="Ajouter une expédition" class="mbr-buttons__btn btn btn-standard" OnClick="lnkAjouterUneExpeditionClick"></asp:LinkButton>

                <br />
                <br />

                <asp:DataList ID="listeMesExpeditions" runat="server" RepeatDirection="Vertical" OnItemCommand="listeMesExpeditionsItemCommand">
                    <ItemTemplate>
                        <div style="float: Left;">
                            <asp:Image runat="server" ID="imgExpedition" ImageUrl='<%# Eval("FichierImage") %>' Style="border-radius: 50%; width: 100px; height: 100px;" />
                        </div>
                        <div style="padding-left: 10px; float: Left;">
                            <b>
                                <asp:Label runat="server" ID="lblNomExpedition" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                            </b>
                            <div style="font-size: 13px;">
                                <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                <i class="fa fa-hand-o-right"></i>
                                <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="lblIdExpedition" Text='<%# Eval("Id")  %>' Visible="False"></asp:Label>
                                <asp:LinkButton runat="server" ID="lnkModifierExpedition" Text="&nbsp;Expédition" Class="boutonModifier" CommandName="modifierExpedition"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierParticipant" Text="&nbsp;Participants" CssClass="boutonModifier" CommandName="modifierParticipant"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierEtape" Text="&nbsp;Activités " CssClass="boutonModifier" CommandName="modifierEtape"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierMenu" Text="&nbsp;Nourriture " CssClass="boutonModifier" CommandName="modifierMenu"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierRepartitionPaieme" Text="&nbsp;Répartition du budget" CssClass="boutonModifier" CommandName="modifierRepartitionBudget"></asp:LinkButton>
                            </div>
                        </div>
                        <div style="padding-top: 125px;"></div>
                    </ItemTemplate>
                </asp:DataList>

                <h2 class="header2">
                    <asp:Label runat="server" ID="lblSuiviForfaitExpedia" Text="Suivi des prix par"></asp:Label> <img src="Images/LogoExpediaFull.png"/></h2>
                <asp:Button runat="server" ID="btnAjouterUnSuiviDePrix" Text="Ajouter un suivi de prix" class="mbr-buttons__btn btn btn-standard" OnClick="btnAjouterUnSuiviDePrixClick"></asp:Button>

                <br />
                <br />


                <asp:DataList ID="listeMesSuiviPrix" runat="server" RepeatDirection="Vertical" OnItemCommand="listeMesSuiviPrixItemCommand">
                    <ItemTemplate>
                        <div style="float: Left;">
                            <asp:Image runat="server" ID="imgExpedia" ImageUrl="Images/LogoExpedia.png" Style="border-radius: 50%; width: 100px; height: 100px;" />
                        </div>
                        <div style="padding-left: 10px; float: Left;">
                            <b>
                                <asp:Label runat="server" ID="lblNomSuivi" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                            </b>
                            <div style="font-size: 13px;">
                                <asp:Label runat="server" ID="lblDateDepart" Text='<%# Eval("DateDepart","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                <i class="fa fa-hand-o-right"></i>
                                <asp:Label runat="server" ID="lblNombreJour" Text='<%# Eval("NombreJour")  %>'></asp:Label>
                                <asp:Label runat="server" ID="lblJour" Text="jours"></asp:Label>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="lblIdRechercheForfaitExpedia" Text='<%# Eval("Id")  %>' Visible="False"></asp:Label>
                                 <asp:LinkButton runat="server" ID="lnkVoirListePrix" Text="Voir liste prix" Class="boutonModifier" CommandName="voirListePrix"></asp:LinkButton>
                                 <asp:LinkButton runat="server" ID="lnkSupprimerRecherchePrix" Text="Supprimer ce suivi" Class="boutonEnlever" CommandName="supprimerSuiviPrix"></asp:LinkButton>
                            </div>
                        </div>
                        <div style="padding-top: 125px;"></div>
                    </ItemTemplate>
                </asp:DataList>


            </div>
        </div>
    </section>
</asp:Content>
