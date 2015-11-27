<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Morpheus.contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <!-- Site made with Mobirise Website Builder v2.5.1, http://mobirise.com -->
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="assets/images/logo.png" type="image/x-icon">
    <meta name="description" content="Entrepreneur général, Construction, Rénovation, Style, Qualité.">
    <title>CONTACTEZ-NOUS</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:700,400&amp;subset=cyrillic,latin,greek,vietnamese">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/mobirise/css/style.css">
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="mbr-navbar mbr-navbar--freeze mbr-navbar--absolute mbr-navbar--sticky mbr-navbar--auto-collapse" id="ext_menu-20">
                <div class="mbr-navbar__section mbr-section">
                    <div class="mbr-section__container container">
                        <div class="mbr-navbar__container">
                            <div class="mbr-navbar__column mbr-navbar__column--s mbr-navbar__brand">
                                <span class="mbr-navbar__brand-link mbr-brand mbr-brand--inline">
                                    <img class="mbr-navbar__brand-img mbr-brand__img" alt="" src="assets/images/logo.png" style="width: 200px; height: 100px;">

                                    <div style="font-size: 15px; color: white; padding-left: 8px; text-decoration: none; width: 300px;">
                                        <b>ENTREPRENEUR GÉNÉRAL</b><br />
                                        RBQ: 5607-0386-01
                                    </div>
                                </span>
                            </div>
                            <div class="mbr-navbar__hamburger mbr-hamburger text-white"><span class="mbr-hamburger__line"></span></div>
                            <div class="mbr-navbar__column mbr-navbar__menu">
                                <nav class="mbr-navbar__menu-box mbr-navbar__menu-box--inline-right">
                                    <div class="mbr-navbar__column">
                                        <ul class="mbr-navbar__items mbr-navbar__items--right mbr-buttons mbr-buttons--freeze mbr-buttons--right btn-decorator mbr-buttons--active mbr-buttons--only-links">
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="index.html">ACCUEIL</a></li>
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="histoire.html">NOTRE HISTOIRE</a></li>
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="apropos.html">À PROPOS</a></li>
                                            <li class="mbr-navbar__item"><a class="mbr-buttons__link btn text-white" href="contact.aspx">CONTACTEZ-NOUS</a></li>
                                        </ul>
                                    </div>

                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-17" style="background-color: rgb(204, 204, 204);">

                <div class="mbr-section__container mbr-section__container--std-padding container">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-8 col-sm-offset-2">
                                    <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                        <h2 class="mbr-header__text">
                                            <br>
                                            CONTACTEZ-NOUS</h2>
                                    </div>

                                    <asp:panel runat="server" ID="pnlMerci" Visible="false" style="background-color: rgb(125, 214, 134); padding: 10px 10px 10px 10px; border: 1px solid green; margin-bottom: 10px;" >
                                        Merci de votre intérêt, nous vous réponderons dans les plus bref délais.
                                    </asp:panel>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="Nom" required="" placeholder="Nom*" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="Courriel" required="" placeholder="Courriel*"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" TextMode="Phone" class="form-control" ID="Telephone" placeholder="Téléphone"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" class="form-control" ID="Message" TextMode="MultiLine" placeholder="Message" Rows="7"></asp:TextBox>
                                    </div>
                                    <div class="mbr-buttons mbr-buttons--right">
                                        <asp:Button runat="server" ID="btnContact" class="mbr-buttons__btn btn btn-lg btn-primary" OnClick="btnContactClick" Text="CONTACTEZ-NOUS"></asp:Button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="contacts1-21" style="background-color: rgb(40, 50, 78);">

                <div class="mbr-section__container container">
                    <div class="mbr-contacts mbr-contacts--wysiwyg row">
                        <div class="col-sm-4">
                            <img class="mbr-contacts__img mbr-contacts__img--left" alt="" src="assets/images/logo.png">
                            <div style="font-size: 15px; color: white; padding-left: 8px; text-decoration: none; width: 300px;">
                                <b>ENTREPRENEUR GÉNÉRAL</b><br />
                                RBQ: 5607-0386-01
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="row">
                                <div class="col-sm-4">
                                    <p class="mbr-contacts__text"></p>
                                    <p>
                                        <strong>ADRESSE</strong>&nbsp;&nbsp;&nbsp;&nbsp;<br>
                                        1056, Étienne-Dumetz<br>
                                        Cap-Rouge, QC, G1Y 1C2<br>
                                        <br>
                                    </p>
                                    <p></p>
                                </div>
                                <div class="col-sm-4">
                                    <p class="mbr-contacts__text">
                                        <strong>CONTACT</strong><br>
                                        Matthieu Germain<br>
                                        info@morpheusrenovation.com<br>
                                        Téléphone : 418.264-7032<br>
                                    </p>
                                </div>
                                <div class="col-sm-4">
                                    <p class="mbr-contacts__text"></p>
                                    <ul class="mbr-contacts__list"></ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>


            <script src="assets/jquery/jquery.min.js"></script>
            <script src="assets/bootstrap/js/bootstrap.min.js"></script>
            <script src="assets/smooth-scroll/SmoothScroll.js"></script>
            <script src="assets/mobirise/js/script.js"></script>


        </div>
    </form>
</body>
</html>
