<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="VoirHistoriqueForfaitExpedia.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.VoirHistoriqueForfaitExpedia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container">

            <h2 class="header2">
                <asp:Label runat="server" ID="lblNom"></asp:Label>
            </h2>

            <asp:Label runat="server" ID="lblFiltrerPageAvecUnHotel" Text="Filtrer la page pour un seul hotel en particulier"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlListeHotel" OnSelectedIndexChanged="ddlListeHotelChanged" class="controlEditable" AutoPostBack="True"/>
            
            <asp:button runat="server" ID="btnVoirTous" Text="Voir tous" CssClass="boutonAjout" OnClick="btnVoirTousClick"></asp:button>
            <br />
            <br />


            <asp:HyperLink runat="server" ID="btnVoirRechercheSurExpedia" Text="Voir cette recherche sur expedia" NavigateUrl="http://www.test.com" Target="_blank" class="mbr-buttons__btn btn btn-standard"></asp:HyperLink>


            <br />


            <h3 class="header3">
                <asp:Label runat="server" ID="lblStatistiqueHistoriquePrix" Text="Statistiques"></asp:Label>
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
            
              <br/>
            <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>
      

        </div>
    </section>
</asp:Content>
