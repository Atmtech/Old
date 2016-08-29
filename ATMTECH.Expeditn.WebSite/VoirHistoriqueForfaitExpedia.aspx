<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="VoirHistoriqueForfaitExpedia.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.VoirHistoriqueForfaitExpedia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container">



            <h2 class="header2">
                <asp:Label runat="server" ID="lblHistoriqueForfaitExpedia" Text="Historique des forfaits "></asp:Label>
                <img src="Images/LogoExpediaFull.png" />
            </h2>
            
            <table style="width: 50%;">
                <tr  class="ligneTableau">
                    <td>Nom de l'historique:</td>
                    <td><asp:Label runat="server" ID="lblNom"></asp:Label></td>
                </tr>
                <tr class="ligneTableau">
                    <td><asp:Label runat="server" ID="lblDateDepartLe" Text="Départ prévu le"></asp:Label></td>
                    <td><asp:Label runat="server" ID="lblDateDepart"></asp:Label></td>
                </tr>
                
                <tr class="ligneTableau">
                    <td>  <asp:Label runat="server" ID="lblPourunedureeDe" Text="Pour une durée de "></asp:Label></td>
                    <td><asp:Label runat="server" ID="lblNombreJour"></asp:Label><asp:Label runat="server" ID="lblNombreJourVacance" Text=" Jours"></asp:Label></td>
                </tr>
            </table>
           <br/>
<asp:HyperLink runat="server" ID="btnVoirRechercheSurExpedia" Text="Voir cette recherche sur expedia" NavigateUrl="http://www.test.com" Target="_blank" class="mbr-buttons__btn btn btn-standard"></asp:HyperLink>
                    
            <br/>
            <br/>
            <div class="libelleChampsEditable">
                <asp:Label runat="server" ID="lblFiltrerPageAvecUnHotel" Text="Filtrer la page pour un seul hotel en particulier"></asp:Label>
            </div>
            <asp:DropDownList runat="server" ID="ddlListeHotel" OnSelectedIndexChanged="ddlListeHotelChanged" class="controlEditable" AutoPostBack="True" />
                 <br/>
            <asp:Button runat="server" ID="btnVoirTous" Text="Voir tous l'historique" class="mbr-buttons__btn btn btn-standard" OnClick="btnVoirTousClick"></asp:Button>
            


            <br />


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


            <h3 class="header3">
                <asp:Label runat="server" ID="lblListePrix" Text="Historique des prix"></asp:Label>
            </h3>


            <table>
                <tr class="ligneTableau">
                    <td class="celluleTableau"><b>Hotel</b></td>
                    <td class="celluleTableau"><b>Compagnie</b></td>
                    <td class="celluleTableau"><b>Prix ($)</b></td>
                    <td class="celluleTableau"><b>Étoile</b></td>
                    <td class="celluleTableau"><b>Date</b></td>
                </tr>
                <asp:Repeater ID="listeHistoriqueForfaitExpedia" runat="server">
                    <ItemTemplate>
                        <tr class="ligneTableau">

                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("NomHotel").ToString() %>'></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="Label1" Text='<%# Eval("CompagnieOrganisatrice").ToString() %>'></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="Label2" Text='<%# Eval("Prix").ToString() %>'></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="Label5" Text='<%# Eval("NombreEtoile").ToString() %>'></asp:Label></td>
                            <td class="celluleTableau">
                                <asp:Label runat="server" ID="Label4" Text='<%# Eval("DateCreated").ToString() %>'></asp:Label></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

            <br />
            <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>


        </div>
    </section>
</asp:Content>
