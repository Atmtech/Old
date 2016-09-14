<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="VoirHistoriqueForfaitExpedia.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.VoirHistoriqueForfaitExpedia" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: white;">
        <div class="mbr-section__container mbr-section__container--std-padding container">

            <asp:ScriptManager runat="server" ID="test"></asp:ScriptManager>


            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <h2 class="header2">
                        <asp:Label runat="server" ID="lblHistoriqueForfaitExpedia" Text="Historique des forfaits "></asp:Label>
                        <img src="Images/LogoExpediaFull.png" />
                    </h2>



                    <table style="width: 50%;">
                        <tr class="ligneTableau">
                            <td>Nom de l'historique:</td>
                            <td>
                                <asp:Label runat="server" ID="lblNom"></asp:Label></td>
                        </tr>
                        <tr class="ligneTableau">
                            <td>
                                <asp:Label runat="server" ID="lblDateDepartLe" Text="Départ prévu le"></asp:Label></td>
                            <td>
                                <asp:Label runat="server" ID="lblDateDepart"></asp:Label></td>
                        </tr>

                        <tr class="ligneTableau">
                            <td>
                                <asp:Label runat="server" ID="lblPourunedureeDe" Text="Pour une durée de "></asp:Label></td>
                            <td>
                                <asp:Label runat="server" ID="lblNombreJour"></asp:Label><asp:Label runat="server" ID="lblNombreJourVacance" Text=" Jours"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                    <asp:HyperLink runat="server" ID="btnVoirRechercheSurExpedia" Text="Voir cette recherche sur expedia" NavigateUrl="http://www.test.com" Target="_blank" class="mbr-buttons__btn btn btn-standard"></asp:HyperLink>

                    <br />
                    <br />
                    <div class="libelleChampsEditable">
                        <asp:Label runat="server" ID="lblFiltrerPageAvecUnHotel" Text="Filtrer la page pour un seul hotel en particulier"></asp:Label>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlListeHotel" OnSelectedIndexChanged="ddlListeHotelChanged" class="controlEditable" AutoPostBack="True" /></td>
                            <td style="padding-top: 5px; padding-left: 10px;">
                                <asp:Button runat="server" ID="btnVoirTous" Visible="True" Text="Voir tous l'historique" class="mbr-buttons__btn btn btn-standard" OnClick="btnVoirTousClick"></asp:Button></td>
                        </tr>
                    </table>

                    <h3 class="header3">
                        <asp:Label runat="server" ID="lblStatistiqueHistoriquePrix" Text="Faits marquants"></asp:Label>
                    </h3>

                    <table>
                        <tr class="ligneTableau">
                            <td class="celluleTableau">Le moins cher</td>
                            <td class="celluleTableau">
                                <b>
                                    <asp:Label runat="server" ID="lblForfaitMoinsCher"></asp:Label></b> </td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="lblForfaitMoinsCherNomHotel"></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="lblForfaitMoinsCherCompagnie"></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="lblForfaitMoinsCherDate"></asp:Label></td>
                        </tr>
                        <tr class="ligneTableau">
                            <td class="celluleTableau">Le plus cher</td>
                            <td class="celluleTableau">
                                <b>
                                    <asp:Label runat="server" ID="lblForfaitPlusCher"></asp:Label></b> </td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="lblForfaitPlusCherNomHotel"></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="lblForfaitPlusCherCompagnie"></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="lblForfaitPlusCherDate"></asp:Label></td>

                        </tr>
                    </table>


                   <%-- <h3 class="header3">
                        <asp:Label runat="server" ID="lblListePrix" Text="Historique des prix"></asp:Label>
                    </h3>--%>
                    <asp:PlaceHolder runat="server" ID="placeHolderGraphique"></asp:PlaceHolder>
                    <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </section>
</asp:Content>
