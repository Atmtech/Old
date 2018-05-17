<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.AirTerreMer.WebSite.Default" %>

<!DOCTYPE html>
<html>
<head>
    <!-- Site made with Mobirise Website Builder v4.7.2, https://mobirise.com -->
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="generator" content="Mobirise v4.7.2, mobirise.com">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1">
    <link rel="shortcut icon" href="assets/images/logo-simple-162x157.png" type="image/x-icon">
    <meta name="description" content="">
    <title>AIR-TERRE-MER</title>
    <link rel="stylesheet" href="assets/web/assets/mobirise-icons-bold/mobirise-icons-bold.css">
    <link rel="stylesheet" href="assets/web/assets/mobirise-icons/mobirise-icons.css">
    <link rel="stylesheet" href="assets/tether/tether.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-reboot.min.css">
    <link rel="stylesheet" href="assets/dropdown/css/style.css">
    <link rel="stylesheet" href="assets/theme/css/style.css">
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">

    <style>
        .modal-header {
            background-color: rgb(60, 60, 60);
            color: white !important;
            text-align: center;
            font-size: 30px;
        }

        .modal-body {
            background-color: gray;
            color: white !important;
        }

        .modal-footer {
            background-color: #f9f9f9;
        }

        .sousTitreFormulaire {
            color: rgb(230, 244, 255);
            font-weight: bold;
            text-transform: uppercase;
            font-size: 25px;
            padding-bottom: 5px;
        }

        .formulaire {
            display: block;
            width: 100%;
            padding: 3px 3px 3px 3px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            font-size: 15px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="reservation" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">RÉSERVATION</h4>
                    </div>
                    <div class="modal-body">

                        <div class="sousTitreFormulaire">Vos renseignements personnels</div>

                        <div class="row">
                            <div class="col-md-6 mb-2">
                                <label>Prénom (Obligatoire)</label>
                                <asp:TextBox runat="server" ID="txtPrenom" class="formulaire" required="true"></asp:TextBox>

                            </div>
                            <div class="col-md-6 mb-2">
                                <label>Nom (Obligatoire)</label>
                                <asp:TextBox runat="server" ID="txtNom" class="formulaire" required="true"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-2">
                                <label>Adresse courriel pour vous rejoindre (Obligatoire)</label>
                                <asp:TextBox runat="server" ID="txtCourriel" TextMode="Email" class="formulaire" required="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-2">
                                <label>Téléphone pour vous rejoindre (Obligatoire)</label>
                                <asp:TextBox runat="server" ID="txtTelephone" TextMode="Phone" class="formulaire" required="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label>Allergie</label>
                                <asp:TextBox runat="server" ID="txtAllergie" TextMode="MultiLine" Rows="2" class="formulaire"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-3">

                                <label>Autres informations pertinentes</label>
                                <asp:TextBox runat="server" ID="txtAutreInformation" TextMode="MultiLine" Rows="2" class="formulaire"></asp:TextBox>
                            </div>
                        </div>


                        <br />
                        <h4 class="mb-3">
                            <div class="sousTitreFormulaire">Informations sur votre réception</div>
                        </h4>
                        <div class="row">
                            <div class="col-md-4 mb-2">
                                <label>Budget maximal en épicerie (Obligatoire)</label>
                                <asp:DropDownList runat="server" ID="ddlBudget" class="formulaire custom-select d-block w-100" required="true" />

                            </div>
                            <div class="col-md-4 mb-2">
                                <label>Nombre de convives (Obligatoire)</label>
                                <asp:DropDownList runat="server" ID="ddlNombreConvive" class="formulaire custom-select d-block w-100" required="true" />

                            </div>

                            <div class="col-md-4 mb-2">
                                <label>Votre date de réception (Obligatoire)</label>
                                <asp:DropDownList runat="server" ID="ddlDate" class="formulaire custom-select d-block w-100" required="true" />
                            </div>


                            <div class="col-md-12 mb-2">
                                <label>N.B.: Seulement les dates disponibles sont inscrites dans la liste. </label>
                            </div>
                        </div>

                        <br />
                        <h4 class="mb-3">
                            <div class="sousTitreFormulaire">Vos préférences culinaires par ordre de priorité</div>
                        </h4>

                        <div class="row">
                            <div class="col-md-4 mb-3">
                                <label>Préférence culinaire #1</label>
                                <asp:DropDownList runat="server" ID="ddlPreferenceCulinaire1" class="formulaire custom-select d-block w-100" />
                            </div>
                            <div class="col-md-4 mb-3">
                                <label>Préférence culinaire #2</label>
                                <asp:DropDownList runat="server" ID="ddlPreferenceCulinaire2" class="formulaire custom-select d-block w-100" />
                            </div>
                            <div class="col-md-4 mb-3">
                                <label>Préférence culinaire #3</label>
                                <asp:DropDownList runat="server" ID="ddlPreferenceCulinaire3" class="formulaire custom-select d-block w-100" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 mb-3">
                                <label>Préférence culinaire #4</label>
                                <asp:DropDownList runat="server" ID="ddlPreferenceCulinaire4" class="formulaire custom-select d-block w-100" />
                            </div>
                            <div class="col-md-4 mb-3">
                                <label>Préférence culinaire #5</label>
                                <asp:DropDownList runat="server" ID="ddlPreferenceCulinaire5" class="formulaire custom-select d-block w-100" />
                            </div>
                            <div class="col-md-4 mb-3">
                                <label>Préférence culinaire #6</label>
                                <asp:DropDownList runat="server" ID="ddlPreferenceCulinaire6" class="formulaire custom-select d-block w-100" />
                            </div>
                        </div>
                        <div class="row">
                            <asp:Button runat="server" ID="btnReserver" Text="RÉSERVER" OnClick="btnReserverOnClick" class="btn btn-default btn-group" Style="background-color: rgb(83, 127, 74); color: white; font-weight: bold;" ValidationGroup="Reserver" />
                            <button type="button" class="btn btn-default btn-dark btn-group" data-dismiss="modal">FERMER</button>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <section class="menu cid-qREjAW5DCo" once="menu" id="menu1-3">
            <nav class="navbar navbar-expand beta-menu navbar-dropdown align-items-center navbar-fixed-top navbar-toggleable-sm">
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <div class="hamburger">
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                    </div>
                </button>
                <div class="menu-logo">
                    <div class="navbar-brand">
                        <span class="navbar-logo">
                            <a href="https://air-terre-mer.com">
                                <img src="assets/images/logo-simple-162x157.png" alt="air-terre-mer" title="" style="height: 8rem;">
                            </a>
                        </span>

                    </div>
                </div>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <div class="navbar-buttons mbr-section-btn">
                        <a class="btn btn-lg btn-info display-4" href="https://www.facebook.com/airterremertraiteur/" target="_blank"><span class="btn-facebook"></span>
                            CONTACT</a>
                    </div>

                    <div class="navbar-buttons mbr-section-btn">
                        <a class="btn btn-sm btn-primary display-4" data-toggle="modal" data-target="#reservation"><span class="mbrib-calendar mbr-iconfont mbr-iconfont-btn"></span>
                            POUR RÉSERVER</a>
                    </div>
                </div>
            </nav>
        </section>


        <section class="header10 cid-qRF1rAsVJB mbr-fullscreen mbr-parallax-background" id="header10-4">
            <div class="mbr-overlay" style="opacity: 0.8; background-color: rgb(0, 0, 0);">
            </div>
            <div class="container">
                <div class="media-container-column mbr-white col-lg-8 col-md-10 ml-auto">

                    <asp:Panel runat="server" ID="pnlMerci" Visible="False">
                        <div class="alert alert-success">
                            <div style="font-size: 20px;"><strong>Merci!</strong> de votre confiance, nous allons vous régalez.</div>
                        </div>
                    </asp:Panel>
                    <h1 class="mbr-section-title align-right mbr-bold pb-3 mbr-fonts-style display-1">CHEF À DOMICILE</h1>
                    
                    <p class="mbr-text align-right pb-3 mbr-fonts-style display-5">
                        Comment la magie s'opère ?
                    </p>
                    <div style="text-align: right; font-weight: bold; font-size: 20px;">
                        <table style="width: 100%">
                            <tr>
                                <td>Étape 1</td>
                                <td>Vous choississez le montant maximal pour la facture d'épicerie.</td>
                            </tr>
                            <tr>
                                <td>Étape 2</td>
                                <td>Vous indiquez le nombre de convives.</td>
                            </tr>
                            <tr>
                                <td>Étape 3</td>
                                <td>Vous sélectionnez vos préférences culinaires.</td>
                            </tr>
                            <tr>
                                <td>Étape 4</td>
                                <td>Vous payez la facture d'épicerie et les honoraires du chef.</td>
                            </tr>
                        </table>
                    </div>
                    <br/>
                    <p class="mbr-text align-right pb-3 mbr-fonts-style display-5">
                        C'est si simple.
                    </p>
                    <div class="mbr-section-btn align-right">

                        <a class="btn btn-sm btn-primary display-4" data-toggle="modal" data-target="#reservation"><span class="mbrib-calendar mbr-iconfont mbr-iconfont-btn"></span>

                            POUR RÉSERVER</a>
                    </div>
                </div>
            </div>

            <div class="mbr-arrow hidden-sm-down" aria-hidden="true">
                <a href="#next">
                    <i class="mbri-down mbr-iconfont"></i>
                </a>
            </div>
        </section>

        <section class="testimonials1 cid-qRF3CUuTRD" id="testimonials1-9">



            <div class="mbr-overlay" style="opacity: 0.8; background-color: rgb(0, 0, 0);">
            </div>
            <div class="container">
                <div class="media-container-row">
                    <div class="title col-12 align-center">
                        <h2 class="pb-3 mbr-fonts-style display-2">CE QUE PENSENT LES CONVIVES</h2>

                    </div>
                </div>
            </div>

            <div class="container pt-3 mt-2">
                <div class="media-container-row">
                    <div class="mbr-testimonial p-3 align-center col-12 col-md-6 col-lg-4">
                        <div class="panel-item p-3">
                            <div class="card-block">

                                <p class="mbr-text mbr-fonts-style display-7">"Les seules sushis que je mange. Jamais entendu un reproche sur sa cuisine. Il aime la bonne bouffe et fais à manger pour les autres comme il aime manger."</p>
                            </div>
                            <div class="card-footer">
                                <div class="mbr-author-name mbr-bold mbr-fonts-style display-7">
                                    Éric R.
                                </div>
                                <small class="mbr-author-desc mbr-italic mbr-light mbr-fonts-style display-7">Client repus</small>
                            </div>
                        </div>
                    </div>

                    <div class="mbr-testimonial p-3 align-center col-12 col-md-6 col-lg-4">
                        <div class="panel-item p-3">
                            <div class="card-block">

                                <p class="mbr-text mbr-fonts-style display-7">"Meilleurs Sushi à vie! Ma fête surprise de mes 40 ans fût un succès, les invités nous ont parlé longtemps du superbe menu qui avait été concocté 😊"</p>
                            </div>
                            <div class="card-footer">
                                <div class="mbr-author-name mbr-bold mbr-fonts-style display-7">
                                    Diane P.
                                </div>
                                <small class="mbr-author-desc mbr-italic mbr-light mbr-fonts-style display-7">Cliente repus</small>
                            </div>
                        </div>
                    </div>

                    <div class="mbr-testimonial p-3 align-center col-12 col-md-6 col-lg-4">
                        <div class="panel-item p-3">
                            <div class="card-block">

                                <p class="mbr-text mbr-fonts-style display-7">
                                    "Très conviviale et surprenant. J'ai adoré du point a au point B"
                                </p>
                            </div>
                            <div class="card-footer">
                                <div class="mbr-author-name mbr-bold mbr-fonts-style display-7">Anonyme</div>
                                <small class="mbr-author-desc mbr-italic mbr-light mbr-fonts-style display-7">Client repus</small>
                            </div>
                        </div>
                    </div>






                </div>
            </div>
        </section>

        <section class="countdown1 cid-qRF4g2McYq" id="countdown1-b">
            <div class="container ">
                <h2 class="mbr-section-title pb-3 align-center mbr-fonts-style display-2">LE PROCHAIN RENDEZ-VOUS DANS ...</h2>
            </div>
            <div class="container countdown-cont align-center">
                <div class="daysCountdown" title="Jours"></div>
                <div class="hoursCountdown" title="Heures"></div>
                <div class="minutesCountdown" title="Minutes"></div>
                <div class="secondsCountdown" title="Secondes"></div>
                <asp:PlaceHolder runat="server" ID="placeholderCompteRebour"></asp:PlaceHolder>
            </div>
        </section>

        <section class="" id="testimonials1-9" style="padding-top: 100px; display: block; color: white; background-color: rgb(50, 50, 50);">
            <div class="container">
                <h2 class="mbr-section-title pb-3 align-center mbr-fonts-style display-2">LES DERNIERS MENUS</h2>
            </div>

            <div class="container">
                <asp:Repeater ID="rptMenu" runat="server">
                    <ItemTemplate>
                        <%# Container.ItemIndex == 0 ? "<div class=\"media-container-row\">" : "" %>
                        <%# Container.ItemIndex % 6 == 0 && Container.ItemIndex !=0 ? "</div><br><div class=\"media-container-row\">" : "" %>


                        <div class="card p-3 col-12 col-md-6 col-lg-2" style="margin-right: 5px; padding: 10px 10px 10px 10px">
                            <div class="card-wrapper">
                                <div class="card-box" style="text-align: center;">
                                    <a href='menu/<%#Eval("NomMenu") %>' style="color: white" target="_blank"><%#Eval("DateReservation", "{0:d}") %>
                                        <img src="menu.png" style="padding-top: 5px;" /></a>
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <br />
        </section>

        <section once="" class="cid-qRF2WqSaeT" id="footer6-5">
            <div class="container">
                <div class="media-container-row align-center mbr-white">
                    <div class="col-12">
                        <p class="mbr-text mb-0 mbr-fonts-style display-7">
                            © Copyright 2018 AIR-TERRE-MER&nbsp;
                        </p>
                    </div>
                </div>
            </div>
        </section>


        <script src="assets/web/assets/jquery/jquery.min.js"></script>
        <script src="assets/tether/tether.min.js"></script>
        <script src="assets/popper/popper.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/smoothscroll/smooth-scroll.js"></script>
        <script src="assets/dropdown/js/script.min.js"></script>
        <script src="assets/touchswipe/jquery.touch-swipe.min.js"></script>
        <script src="assets/countdown/jquery.countdown.min.js"></script>
        <script src="assets/parallax/jarallax.min.js"></script>
        <script src="assets/theme/js/script.js"></script>


    </form>
</body>
</html>
