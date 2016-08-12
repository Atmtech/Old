<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererBudget.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererBudget" %>

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
                        <asp:Label ID="lblGererBudgetTitre" runat="server" Text="Le budget"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>

                    <h3>Dépenses par personnes
                    </h3>
                    <table>
                        <tr>
                            <td><b>Participant</b></td>
                            <td><b>Activité avec automobile ($)</b></td>
                            <td><b>Activité avec bateau ($)</b></td>
                            <td><b>Nourritures ($)</b></td>
                            <td><b>Autres dépenses ($)</b></td>
                            <td><b>Total ($)</b></td>
                        </tr>
                        <asp:Repeater ID="listeDepenseParPersonne" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("MontantEtapeAutomobile")  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label2" Text='<%# Eval("MontantEtapeBateau")  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label4" Text='<%# Eval("MontantNourriture")  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label5" Text='<%# Eval("MontantAutre")  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("MontantTotal")  %>' Visible="True"></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td><b>
                                <asp:Label runat="server" ID="lblGrandTotalAffichage" Text="Grand total:"></asp:Label></b></td>
                            <td><b>
                                <asp:Label runat="server" ID="lblTotalAutomobile"></asp:Label></b></td>
                            <td><b>
                                <asp:Label runat="server" ID="lblTotalBateau"></asp:Label></b></td>
                            <td><b>
                                <asp:Label runat="server" ID="lblTotalNourriture"></asp:Label></b></td>
                            <td><b>
                                <asp:Label runat="server" ID="lblTotalAutres"></asp:Label></b></td>
                            <td><b>
                                <asp:Label runat="server" ID="lblGrandTotal"></asp:Label></b></td>
                        </tr>
                    </table>
                    <h3>
                        <asp:Label ID="lblRepartitionDesDepenses" runat="server" Text="Répartition des montants"></asp:Label>
                    </h3>

                    <table>
                        <tr>
                            <td><b>Participant</b></td>
                            <td><b>% Activité Automobile</b></td>
                            <td><b>% Activité Bateau</b></td>
                            <td><b>% Nourriture</b></td>
                            <td><b>$ Activité Automobile</b></td>
                            <td><b>$ Activité Bateau</b></td>
                            <td><b>$ Nourriture</b></td>
                            <td><b>$ Autre</b></td>
                            <td><b>$ Total</b></td>
                        </tr>
                        <asp:Repeater ID="listeRepartitionMontant" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblUtilisateur" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("NombrePresenceEtapeAutomobile") + "/" + Eval("NombreTotalEtapeAutomobile") + " = " +   (Convert.ToDecimal( Eval("PourcentagePresenceEtapeAutomobile")) * 100) + "%"  %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label11" Text='<%# Eval("NombrePresenceEtapeBateau") + "/" + Eval("NombreTotalEtapeBateau") + " = " +   (Convert.ToDecimal( Eval("PourcentagePresenceEtapeBateau")) * 100) + "%" %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label6" Text='<%# Eval("NombreRepas") + "/" + Eval("NombreTotalRepas") + " = " +   (Convert.ToDecimal( Eval("PourcentageRepas")) * 100) + "%" %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label7" Text='<%# Eval("MontantAvecPourcentageDuTotalAutomobile") %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label8" Text='<%# Eval("MontantAvecPourcentageDuTotalBateau") %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label9" Text='<%# Eval("MontantAvecPourcentageDesRepas") %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label12" Text='<%# Eval("MontantAvecPourcentageAutres") %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label10" Text='<%# Eval("MontantTotal") %>' Visible="True"></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>

                    <h3>
                        <asp:Label ID="lblMontantDu" runat="server" Text="Montant dû entre les participants"></asp:Label>
                    </h3>
                    <table>

                        <asp:Repeater ID="listeMontantDu" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="Label8" Text='<%# Eval("Payeur.FirstNameLastName") %>' Visible="True"></asp:Label></td>
                                    <td>Doit</td>
                                    <td>
                                        <asp:Label runat="server" ID="Label13" Text='<%# Eval("Montant") %>' Visible="True"></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label14" Text='<%# Eval("Paye.FirstNameLastName") %>' Visible="True"></asp:Label></td>


                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                    <h3>
                        <asp:Label ID="lblRepartitionDepenseParParticipant" runat="server" Text="Répartir les dépenses par participant"></asp:Label>
                    </h3>

                    <div style="float: left; width: 50%">
                        <div style="border-bottom: solid 1px gray">
                            <asp:Label ID="lblPourCeParticipant" runat="server" Text="Pour ce participant"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlParticipant" />
                    </div>
                    <div style="float: left; padding-left: 10px;">
                        <div style="border-bottom: solid 1px gray">
                            <asp:Label ID="lblMontantRepartition" runat="server" Text="Montant"></asp:Label>
                            $
                        </div>
                        <atmtech:Numeric runat="server" ID="txtMontant" />
                    </div>

                    <div style="clear: both"></div>
                    <br />
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseNourriture" Text="Répartir dépenses de nourritures" CssClass="button icon fa-money" OnClick="lnkRepartitionDepenseNourritureClick"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseAutomobile" Text="Répartir dépenses automobile" CssClass="button icon fa-money" OnClick="lnkRepartitionDepenseAutomobileClick"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseBateau" Text="Répartir dépenses bateau" CssClass="button icon fa-money" OnClick="lnkRepartitionDepenseBateauClick"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkRepartitionDepenseAutre" Text="Répartir dépenses autres" CssClass="button icon fa-money" OnClick="lnkRepartitionDepenseAutreClick"></asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
