<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.CalculPeche.WebSite.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" href="assets/images/fishing-2000x1000-66.jpg" type="image/x-icon">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:700,400&amp;subset=cyrillic,latin,greek,vietnamese">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/animate.css/animate.min.css">
    <link rel="stylesheet" href="assets/mobirise/css/style.css">
    <link rel="stylesheet" href="assets/dropdown-menu-plugin/style.css">
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">


    <style>
        TABLE {
            WIDTH: 100%;
        }

        H1 {
            text-transform: uppercase;
            font-size: 18px;
            color: rgb(137, 199, 218);
            font-weight: bold;
            border-bottom: 2px solid rgb(137, 199, 218);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <section class="mbr-navbar mbr-navbar--freeze mbr-navbar--absolute mbr-navbar--sticky mbr-navbar--auto-collapse" id="ext_menu-0">
                <div class="mbr-navbar__section mbr-section">
                    <div class="mbr-section__container container">
                        <div class="mbr-navbar__container">
                            <div class="mbr-navbar__column mbr-navbar__column--s mbr-navbar__brand">
                                <span class="mbr-navbar__brand-link mbr-brand mbr-brand--inline">

                                    <span class="mbr-brand__name"><a class="mbr-brand__name text-white" href="https://expeditn.etouelle.com">EXPEDIT'N</a></span>
                                </span>
                            </div>
                            <div class="mbr-navbar__hamburger mbr-hamburger"><span class="mbr-hamburger__line"></span></div>
                            <div class="mbr-navbar__column mbr-navbar__menu">
                                <nav class="mbr-navbar__menu-box mbr-navbar__menu-box--inline-right">
                                    <div class="mbr-navbar__column">
                                        <ul class="mbr-navbar__items mbr-navbar__items--right float-left mbr-buttons mbr-buttons--freeze mbr-buttons--right btn-decorator mbr-buttons--active mbr-buttons--only-links">
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="http://expeditn.etouelle.com">ACCUEIL</a></li>
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="Admin.aspx">ADMINISTRATION</a></li>
                                        </ul>

                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="engine"><a rel="external" href="https://mobirise.com">best free website builder</a></section>


            <section class="mbr-section mbr-section--relative mbr-section--short-paddings mbr-parallax-background" id="msg-box1-6" style="background-image: url(assets/images/fishing-2000x1000-74.jpg);">

                <div class="mbr-overlay" style="opacity: 0.7; background-color: rgb(34, 34, 34);"></div>

                <div class="mbr-section__container mbr-section__container--isolated container" style="padding-top: 60px; padding-bottom: 60px;">
                    <div class="row">
                        <div class="mbr-box mbr-box--fixed mbr-box--adapted">
                            <div class="mbr-box__magnet mbr-box__magnet--top-left mbr-section__left col-sm-8">
                                <div class="mbr-section__container mbr-section__container--middle">
                                    <div class="mbr-header mbr-header--auto-align mbr-header--wysiwyg">
                                        <h3 class="mbr-header__text">PRE MADE BLOCKS</h3>
                                    </div>
                                </div>
                                <div class="mbr-section__container">
                                    <div class="mbr-article mbr-article--auto-align ">
                                        <div style="color: white; text-align: left;">

                                            <h1>CRÉER EXPÉDITION</h1>
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtNom" class="form-control" placeholder="Nom"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtDateDebut" class="form-control" placeholder="Date début"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="txtDateFin" class="form-control" placeholder="Date fin"></asp:TextBox>
                                            </div>
                                            <asp:Button runat="server" ID="btnCreerExpedition" OnClick="btnCreerUneExpedition" Text="Créer" class="mbr-buttons__btn btn btn-lg btn-danger" />


                                            <asp:GridView runat="server" ID="grvTEst" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Nom"  />
                                                </Columns>
                                            </asp:GridView>

                                            <h1>ÉDITER ENTITÉS</h1>
                                            <div class="form-group">
                                                <asp:HyperLink runat="server" ID="lnkExpedition" NavigateUrl="Edition.aspx?NomEntite=Expedition" Text="Expedition" class="mbr-buttons__btn btn btn-lg btn-danger"></asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="lnkParticipantAutomobile" NavigateUrl="Edition.aspx?NomEntite=ParticipantAutomobileExpedition" Text="Automobile expedition" class="mbr-buttons__btn btn btn-lg btn-danger"></asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="Edition.aspx?NomEntite=ParticipantBateauExpedition" Text="Bateau expedition" class="mbr-buttons__btn btn btn-lg btn-danger"></asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="HyperLink2" NavigateUrl="Edition.aspx?NomEntite=ParticipantExpedition" Text="Participant expedition" class="mbr-buttons__btn btn btn-lg btn-danger"></asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="HyperLink3" NavigateUrl="Edition.aspx?NomEntite=ParticipantPresenceExpedition" Text="Presence expedition" class="mbr-buttons__btn btn btn-lg btn-danger"></asp:HyperLink>
                                                <asp:HyperLink runat="server" ID="HyperLink4" NavigateUrl="Edition.aspx?NomEntite=ParticipantRepasExpedition" Text="Repas expedition" class="mbr-buttons__btn btn btn-lg btn-danger"></asp:HyperLink>
                                            </div>

                                            <h1>GÉNÉRER MODÈLE DE DONNÉE</h1>
                                            <asp:Button runat="server" ID="btnGenererSql" OnClick="btnGenererSqlClick" Text="Generer modele" class="mbr-buttons__btn btn btn-lg btn-danger" />
                                            <asp:TextBox ID="txtSql" runat="server" Height="282px" Width="937px" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>




            <footer class="mbr-section mbr-section--relative mbr-section--fixed-size" id="footer1-4" style="background-color: rgb(68, 68, 68);">

                <div class="mbr-section__container container">
                    <div class="mbr-footer mbr-footer--wysiwyg row" style="padding-top: 36.900000000000006px; padding-bottom: 36.900000000000006px;">
                        <div class="col-sm-12">
                            <p class="mbr-footer__copyright">EXPEDIT'N - Copyright (c) 2016 Atmosphere Technologies</p>
                        </div>
                    </div>
                </div>
            </footer>

            <script src="assets/web/assets/jquery/jquery.min.js"></script>
            <script src="assets/bootstrap/js/bootstrap.min.js"></script>
            <script src="assets/smooth-scroll/SmoothScroll.js"></script>
            <script src="assets/jarallax/jarallax.js"></script>
            <script src="assets/mobirise/js/script.js"></script>
            <script src="assets/dropdown-menu-plugin/script.js"></script>



        </div>
    </form>
</body>
</html>
