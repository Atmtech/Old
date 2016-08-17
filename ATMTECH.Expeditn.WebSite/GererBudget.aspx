<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererBudget.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererBudget" %>

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
                        <asp:Label ID="lblGererBudgetTitre" runat="server" Text="Le budget"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>

                    <h3 class="header3">Dépenses par personnes
                    </h3>
                    <table>
                        <tr class="ligneTableau">
                            <td class="celluleTableau"><b>Participant</b></td>
                            <td class="celluleTableau"><b>Activité avec automobile ($)</b></td>
                            <td class="celluleTableau"><b>Activité avec bateau ($)</b></td>
                            <td class="celluleTableau"><b>Nourritures ($)</b></td>
                            <td class="celluleTableau"><b>Autres dépenses ($)</b></td>
                            <td class="celluleTableau"><b>Total ($)</b></td>
                        </tr>
                        <asp:Repeater ID="listeDepenseParPersonne" runat="server">
                            <ItemTemplate>
                                <tr class="ligneTableau">
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="lblUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("MontantEtapeAutomobile","{0:c}")  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("MontantEtapeBateau","{0:c}")  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label4" Text='<%# Eval("MontantNourriture","{0:c}")  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label5" Text='<%# Eval("MontantAutre","{0:c}")  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau" style="background-color: rgb(213, 226, 228);text-align: right">
                                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("MontantTotal","{0:c}")  %>' Visible="True"></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr class="ligneTableau">
                            <td class="celluleTableau"><b>
                                <asp:Label runat="server" ID="lblGrandTotalAffichage" Text="Grand total:"></asp:Label></b></td>
                            <td class="celluleTableau"><b>
                                <asp:Label runat="server" ID="lblTotalAutomobile"></asp:Label></b></td>
                            <td class="celluleTableau"><b>
                                <asp:Label runat="server" ID="lblTotalBateau"></asp:Label></b></td>
                            <td class="celluleTableau"><b>
                                <asp:Label runat="server" ID="lblTotalNourriture"></asp:Label></b></td>
                            <td class="celluleTableau"><b>
                                <asp:Label runat="server" ID="lblTotalAutres"></asp:Label></b></td>
                            <td class="celluleTableau" style="background-color: rgb(213, 226, 228);text-align: right"><b>
                                <asp:Label runat="server" ID="lblGrandTotal"></asp:Label></b></td>
                        </tr>
                    </table>
                    <h3 class="header3">
                        <asp:Label ID="lblRepartitionDesDepenses" runat="server" Text="Répartition des montants"></asp:Label>
                    </h3>

                    <table>
                       <tr class="ligneTableau">
                            <td  class="celluleTableau"><b><asp:label runat="server" id="lblLibelleParticipant" Text="Participant"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibellePourcentageAutomobile" Text="% Automobile"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibellePourcentageBateau" Text="% Bateau"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibellePourcentageNourriture" Text="% Nourriture"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibelleAutomobile" Text="Automobile"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibelleBateau" Text="Bateau"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibelleNourriture" Text="Nourriture"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibelleAutre" Text="Autres"></asp:label></b></td>
                            <td class="celluleTableau"><b><asp:label runat="server" id="lblLibelleTotal" Text="Total"></asp:label></b></td>
                        </tr>
                        <asp:Repeater ID="listeRepartitionMontant" runat="server">
                            <ItemTemplate>
                               <tr class="ligneTableau">
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="lblUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("NombrePresenceEtapeAutomobile") + "/" + Eval("NombreTotalEtapeAutomobile") + " = " +   (Convert.ToDecimal( Eval("PourcentagePresenceEtapeAutomobile")) * 100) + "%"  %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label11" Text='<%# Eval("NombrePresenceEtapeBateau") + "/" + Eval("NombreTotalEtapeBateau") + " = " +   (Convert.ToDecimal( Eval("PourcentagePresenceEtapeBateau")) * 100) + "%" %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label6" Text='<%# Eval("NombreRepas") + "/" + Eval("NombreTotalRepas") + " = " +   (Convert.ToDecimal( Eval("PourcentageRepas")) * 100) + "%" %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label7" Text='<%# Eval("MontantAvecPourcentageDuTotalAutomobile","{0:c}") %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label8" Text='<%# Eval("MontantAvecPourcentageDuTotalBateau","{0:c}") %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label9" Text='<%# Eval("MontantAvecPourcentageDesRepas","{0:c}") %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label12" Text='<%# Eval("MontantAvecPourcentageAutres","{0:c}") %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau" style="background-color: rgb(213, 226, 228);text-align: right">
                                        <asp:Label runat="server" ID="Label10" Text='<%# Eval("MontantTotal","{0:c}") %>' Visible="True"></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>

                    <h3 class="header3">
                        <asp:Label ID="lblMontantDu" runat="server" Text="Montant dû entre les participants"></asp:Label>
                    </h3>
                    <table>

                        <asp:Repeater ID="listeMontantDu" runat="server">
                            <ItemTemplate>
                               <tr class="ligneTableau">
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label8" Text='<%# Eval("Payeur.FirstNameLastName") %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">Doit</td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label13" Text='<%# Eval("Montant","{0:c}") %>' Visible="True"></asp:Label></td>
                                    <td class="celluleTableau">
                                        <asp:Label runat="server" ID="Label14" Text='<%# Eval("Paye.FirstNameLastName") %>' Visible="True"></asp:Label></td>


                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                    <h3 class="header3">
                        <asp:Label ID="lblRepartitionDepenseParParticipant" runat="server" Text="Répartir les dépenses par participant"></asp:Label>
                    </h3>

                    <div style="float: left; width: 50%">

                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblSelectionnerParticipantRepartirDepense" runat="server" Text="Sélectionner un participant ayant une facture pour la répartition"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlParticipant" class="controlEditable" />
                    </div>
                    <div style="float: left; padding-left: 10px;">

                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblMontantRepartition" runat="server" Text="Montant"></asp:Label>
                            $
                        </div>
                        <atmtech:Numeric runat="server" ID="txtMontant" CssClass="controlEditable" />
                    </div>

                    <div style="clear: both"></div>
                    <br />
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseNourriture" Text="Répartir dépenses de nourritures" class="mbr-buttons__btn btn btn-standard" OnClick="lnkRepartitionDepenseNourritureClick"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseAutomobile" Text="Répartir dépenses automobile" class="mbr-buttons__btn btn btn-standard" OnClick="lnkRepartitionDepenseAutomobileClick"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseBateau" Text="Répartir dépenses bateau" class="mbr-buttons__btn btn btn-standard" OnClick="lnkRepartitionDepenseBateauClick"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseAutre" Text="Répartir dépenses autres" class="mbr-buttons__btn btn btn-standard" OnClick="lnkRepartitionDepenseAutreClick"></asp:LinkButton>
                    <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
