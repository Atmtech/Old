<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Banner -->
    <section id="banner">

        <h2>
            <asp:Label runat="server" ID="lblMessageBienvenueEntete" Text="Bonjour. Voici expedit'n."></asp:Label></h2>
        <p>
            <asp:Label runat="server" ID="lblMessageBienvenueSousEntete" Text="La planification d'expédition simple, efficace et connecté sur votre monde."></asp:Label>
        </p>
        <ul class="actions">
            <li>
                <asp:HyperLink runat="server" ID="lnkPlanifierExpedition" Text="Planifier une expédition"
                    NavigateUrl="Default.aspx" CssClass="button big"></asp:HyperLink>
            </li>
        </ul>
    </section>

    <!-- One -->
    <section id="one" class="wrapper style1 special">
        <div class="container">
            <header class="major">
                <h2>
                    <asp:Label ID="lblCeQueExpeditnPeutFaire" runat="server" Text="Ce que Expedit'n peut faire pour vous"></asp:Label>
                </h2>
                <p>
                    <asp:Label ID="lblUneBoiteAoutilBienGarnie" runat="server" Text="Une boite à outil bien garnie, planifier n'aura jamais été aussi amusant"></asp:Label>
                </p>
            </header>
            <div class="row 150%">
                <div class="4u 12u$(medium)">
                    <section class="box">
                        <i class="icon big rounded color1 fa-cloud"></i>
                        <h3>
                            <asp:Label ID="lblAccessiblePartoutEnToutTemps" runat="server" Text="Accèssible en tout temps*"></asp:Label></h3>
                        <p>
                            <asp:Label ID="lblBranchezVousModifierVotreItineraire" runat="server" Text="Branchez vous, modifier votre itinéraire, suivez votre progression et profitez !"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblAvecUnAccesAinternet" runat="server" Text="*.: Avec un accès à internet"></asp:Label>
                        </p>
                    </section>
                </div>
                <div class="4u 12u$(medium)">
                    <section class="box">
                        <i class="icon big rounded color9 fa-microphone"></i>
                        <h3>
                            <asp:Label ID="lblInformerEnTempsReelVosProches" runat="server" Text="Informer en temps réel vos proches"></asp:Label></h3>
                        <p>
                            <asp:Label ID="lblModuleDeGeoLocalisationIntegre" runat="server" Text="Le module de géolocalisation intégré permet a vos proches de vous suivre"></asp:Label>
                        </p>
                    </section>
                </div>
                <div class="4u$ 12u$(medium)">
                    <section class="box">
                        <i class="icon big rounded color6 fa-rocket"></i>
                        <h3>
                            <asp:Label ID="lblLesOutilsNecessairePourPlanifier" runat="server" Text="Les outils nécessaires pour planifier"></asp:Label></h3>
                        <p>
                            <asp:Label ID="lblCalculDistanceListeChoseAFaire" runat="server" Text="Calcul de distance, Liste des choses à ne pas oublier, Calcul de votre budget, Liste des réservations etc."></asp:Label>
                        </p>
                    </section>
                </div>
            </div>
        </div>
    </section>

    <!-- Two -->
    <section id="two" class="wrapper style2 special">
        <div class="container">
            <header class="major">
                <h2>
                    <asp:Label ID="lblListeDesDerniereExpedition" runat="server" Text="Liste des dernières expéditions"></asp:Label></h2>
                <p>
                    <asp:Label ID="lblUnApercuDesDerniereExpeditionCree" runat="server" Text="Un aperçu des dernières expéditions créées"></asp:Label>
                </p>
            </header>
            <section class="profiles">
                <div class="row">
                    <asp:Repeater ID="listeExpedition" runat="server">
                        <ItemTemplate>
                            <section class="4u 6u(medium) 12u$(xsmall) profile">
                                <img src="http://fabricetremblay.ca/perso/TCAT/04.jpg" alt="" />
                                <h4>
                                    <asp:Label runat="server" ID="lblNomExpedition" Text='<%# Eval("Nom").ToString().Length > 25 ? Eval("Nom").ToString().Substring(0,25) + "[...]" : Eval("Nom").ToString()  %>'></asp:Label>
                                </h4>
                                <div style="font-size: 13px;">
                                    <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("DateDebut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                    <i class="fa fa-hand-o-right"></i>
                                    <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("DateFin","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                </div>
                                <p>
                                    <i class="fa fa-user"></i>
                                    <asp:Label runat="server" ID="lblChefListe" Text='<%# Eval("Chef.Utilisateur.FirstNameLastName","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                </p>
                            </section>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </section>
            <footer>
                <p></p>
                <ul class="actions">
                    <li>
                        <asp:HyperLink runat="server" ID="lnkRechercherPlusDexpedition" Text="Rechercher plus d'expedition" NavigateUrl="Rechercher.aspx" CssClass="button big"></asp:HyperLink></li>
                    </li>
                </ul>
            </footer>
        </div>
    </section>

    <!-- Three -->
    <section id="three" class="wrapper style3 special">
        <div class="container">
            <header class="major">
                <h2>
                    <asp:Label ID="lblContacterNous" runat="server" Text="Contacter nous"></asp:Label></h2>
                <p>
                    <asp:Label ID="lblSimplementPourNousDireCoucou" runat="server" Text="Simplement pour nous dire coucou, ou pour vos états d'âmes !"></asp:Label>
                </p>
            </header>
        </div>
        <div class="container 50%">
            <div class="row uniform">
                <div class="6u 12u$(small)">
                    <asp:TextBox runat="server" ID="txtNom" placeholder="Nom"></asp:TextBox>
                </div>
                <div class="6u$ 12u$(small)">
                    <asp:TextBox runat="server" ID="txtCourriel" placeholder="Courriel" TextMode="Email"></asp:TextBox>
                </div>
                <div class="12u$">
                    <asp:TextBox runat="server" ID="txtMessage" placeholder="Message" TextMode="MultiLine" Rows="6"></asp:TextBox>
                </div>
                <div class="12u$">
                    <ul class="actions">
                        <li>
                            <asp:Button runat="server" ID="lnkEnvoyerMessage" Text="Envoyer" CssClass="special big"></asp:Button>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
