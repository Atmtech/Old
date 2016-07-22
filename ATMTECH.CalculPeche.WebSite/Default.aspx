<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.CalculPeche.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="assets/images/fishing-2000x1000-66.jpg" type="image/x-icon">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:700,400&amp;subset=cyrillic,latin,greek,vietnamese">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/animate.css/animate.min.css">
    <link rel="stylesheet" href="assets/mobirise/css/style.css">
    <link rel="stylesheet" href="assets/dropdown-menu-plugin/style.css">
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">

    <title></title>
    <style>
        TABLE {
            WIDTH: 100%;
        }
        H1 {
            text-transform: uppercase;
            font-size: 18px;
            color: rgb(137, 199, 218);
            font-weight: bold;  
            border-bottom:2px solid rgb(137, 199, 218);
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

                                    <span class="mbr-brand__name"><a class="mbr-brand__name text-white" href="http://expeditn.etouelle.com">EXPEDIT'N</a></span>
                                </span>
                            </div>
                            <div class="mbr-navbar__hamburger mbr-hamburger"><span class="mbr-hamburger__line"></span></div>
                            <div class="mbr-navbar__column mbr-navbar__menu">
                                <nav class="mbr-navbar__menu-box mbr-navbar__menu-box--inline-right">
                                    <div class="mbr-navbar__column">
                                        <ul class="mbr-navbar__items mbr-navbar__items--right float-left mbr-buttons mbr-buttons--freeze mbr-buttons--right btn-decorator mbr-buttons--active mbr-buttons--only-links">
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="http://expeditn.etouelle.com">ACCUEIL</a></li>
                                        </ul>

                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="engine"><a rel="external" href="https://mobirise.com">best free website builder</a></section>
            <section class="mbr-box mbr-section mbr-section--relative mbr-section--fixed-size mbr-section--full-height mbr-section--bg-adapted mbr-parallax-background" id="header4-5" style="background-image: url(assets/images/fishing-2000x1000-74.jpg);">
                <div class="mbr-box__magnet mbr-box__magnet--sm-padding mbr-box__magnet--center-center mbr-after-navbar">
                    <div class="mbr-overlay" style="opacity: 0.9; background-color: rgb(34, 34, 34);">
                    </div>

                    <div class="mbr-box__container mbr-section__container container">
                        <div style="color: white; text-align: left;">
                            <div class="encadre">
                               <H1> Selectionner l'expédition à consulter</H1>
            <asp:DropDownList runat="server" ID="ddlExpedition" AutoPostBack="True" OnSelectedIndexChanged="ddlExpeditionChanged" class="form-control"/>
                            </div>
                            <table>
                                <tr>
                                    <td style="vertical-align: top">
                                        <div class="encadre">
                                            <h1>Information générales</h1>
                                            <asp:PlaceHolder runat="server" ID="placeholderGeneral"></asp:PlaceHolder>
                                        </div>
                                    </td>
                                    <td style="vertical-align: top">
                                        <div class="encadre">
                                            <h1>Montant dûs</h1>
                                            <asp:PlaceHolder runat="server" ID="placeHolderMontantDu"></asp:PlaceHolder>
                                        </div>
                                    </td>
                                </tr>
                            </table>


                            <div class="encadre">
                                <h1>Argent depensé</h1>
                                <asp:PlaceHolder runat="server" ID="placeholderArgent"></asp:PlaceHolder>
                            </div>

                            <div class="encadre">
                                <h1>Présence</h1>
                                <asp:PlaceHolder runat="server" ID="placeholderPresence"></asp:PlaceHolder>
                            </div>
                            <div class="encadre">
                                <h1>Sortie en bateau</h1>
                                <asp:PlaceHolder runat="server" ID="placeholderBateau"></asp:PlaceHolder>
                            </div>
                            <div class="encadre">
                                <h1>Nombre de repas par jour</h1>
                                <asp:PlaceHolder runat="server" ID="placeholderRepas"></asp:PlaceHolder>
                            </div>

                            <div class="encadre">
                                <h1>Répartition des paiements</h1>
                                <asp:PlaceHolder runat="server" ID="placeholderRepartition"></asp:PlaceHolder>
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
