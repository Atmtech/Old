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
            font-size: 17px;
            color: rgb(137, 199, 218);
            font-weight: bold;
            border-bottom: 2px solid rgb(137, 199, 218);
        }

        .encadre {
            color: white;
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
                                        <div style="color: white; text-align: left; font-size: 14px;">
                                            <div class="encadre">
                                                <h1>Selectionner l'expédition à consulter</h1>
                                                <asp:DropDownList runat="server" ID="ddlExpedition" AutoPostBack="True" OnSelectedIndexChanged="ddlExpeditionChanged" class="form-control" />
                                            </div>
                                            <table>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <div class="encadre">
                                                            <h1>Information</h1>
                                                            <asp:PlaceHolder runat="server" ID="placeholderGeneral"></asp:PlaceHolder>
                                                        </div>
                                                    </td>
                                                    <td style="vertical-align: top; width: 300px;">
                                                        <div class="encadre">
                                                            <h1>Montant dûs</h1>
                                                            <asp:PlaceHolder runat="server" ID="placeHolderMontantDu"></asp:PlaceHolder>
                                                        </div>
                                                    </td>
                                                    <td style="vertical-align: top">
                                                        <h1>Dépenses par personne</h1>
                                                        <asp:PlaceHolder runat="server" ID="placeholderArgent"></asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                            </table>

                                            <div class="encadre">
                                                <h1>Répartition des paiements</h1>
                                                <asp:PlaceHolder runat="server" ID="placeholderRepartition"></asp:PlaceHolder>
                                            </div>

                                            <div class="encadre">
                                                <h1>Détail des présences</h1>
                                                <asp:PlaceHolder runat="server" ID="placeholderPresence"></asp:PlaceHolder>
                                            </div>
                                            <div class="encadre">
                                                <h1>Détail des sorties en bateau</h1>
                                                <asp:PlaceHolder runat="server" ID="placeholderBateau"></asp:PlaceHolder>
                                            </div>
                                            <div class="encadre">
                                                <h1>Détail sur le nombre de repas par jour</h1>
                                                <asp:PlaceHolder runat="server" ID="placeholderRepas"></asp:PlaceHolder>
                                            </div>
                                             <div class="encadre">
                                                <h1>Détail sur le nombre d'automobile emprunté</h1>
                                                <asp:PlaceHolder runat="server" ID="placeHolderAutomobile"></asp:PlaceHolder>
                                            </div>

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
