<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.Default" %>

<!DOCTYPE html>
<html>
<head>
    <!-- Site made with Mobirise Website Builder v4.7.2, https://mobirise.com -->
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="generator" content="Mobirise v4.7.2, mobirise.com">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1">
    <link rel="shortcut icon" href="assets/images/logo-122x99.png" type="image/x-icon">
    <meta name="description" content="">
    <title>VA-CHIER.COM</title>
    <link rel="stylesheet" href="assets/web/assets/mobirise-icons/mobirise-icons.css">
    <link rel="stylesheet" href="assets/tether/tether.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-reboot.min.css">
    <link rel="stylesheet" href="assets/dropdown/css/style.css">
    <link rel="stylesheet" href="assets/socicon/css/styles.css">
    <link rel="stylesheet" href="assets/theme/css/style.css">
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <style>
        .modal-header {
            background-color: rgb(132,82,31);
            color: white !important;
            text-align: center;
            font-size: 30px;
        }

        .modal-footer {
            background-color: #f9f9f9;
        }

        A {
            color: rgb(132,82,31);
        }


        .pagination input {
            margin-left: 10px;
            border-radius: 50%;
            height: 40px;
            width: 40px;
            color: black;
            float: left;
            text-decoration: none;
            transition: background-color .3s;
            border: 1px solid #ddd;
        }

            .pagination input.active {
                background-color: #4CAF50;
                color: white;
                border: 1px solid #4CAF50;
            }

            .pagination input:hover:not(.active) {
                background-color: #756565;
            }
    </style>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });


        $(document).ready(function () {
            $('[data-toggle="popover"]').popover();
        });

    </script>


</head>
<body>

    <form id="form1" runat="server">
        <div id="modalAjouterMerde" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Ajoute ta merde</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label for="usrname" ID="lblTitre" runat="server"><span class="glyphicon glyphicon-user"></span>Titre</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="txtTitre" MaxLength="20" placeholder="Titre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="psw"><span class="glyphicon glyphicon-eye-open"></span>Ton petit mot de marde</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtDescription" placeholder="Ton petit mot de marde" MaxLength="280"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="psw"><span class="glyphicon glyphicon-eye-open"></span>Ton insulte</label>
                            <asp:DropDownList runat="server" class="form-control" ID="ddlInsulte" placeholder="Ton insulte">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btnAjouterMerde" Text="Ajouter cette belle merde" OnClick="btnAjouterMerdeOnClick" class="btn btn-default btn-group" Style="background-color: rgb(132,82,31); color: white; font-weight: bold;" />
                        <button type="button" class="btn btn-default btn-dark btn-group" data-dismiss="modal">Fermer</button>
                    </div>
                </div>

            </div>
        </div>


        <div id="modalChercherMerde" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Fouiller dans la merde</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label for="usrname" ID="Label1" runat="server"><span class="glyphicon glyphicon-user"></span>Merde à rechercher</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="TextBox1" placeholder="Merde à rechercher"></asp:TextBox>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="Button1" Text="Chercher de la merde" OnClick="btnAjouterMerdeOnClick" class="btn btn-default btn-group" Style="background-color: rgb(132,82,31); color: white; font-weight: bold;" />
                        <button type="button" class="btn btn-default btn-dark btn-group" data-dismiss="modal">Fermer</button>
                    </div>
                </div>

            </div>
        </div>




        <section class="menu cid-qQmesCmsc9" once="menu" id="menu1-2">
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
                            <a>
                                <img src="assets/images/logo-122x99.png" alt="Mobirise" title="" style="height: 3.8rem;">
                            </a>
                        </span>
                        <span class="navbar-caption-wrap">
                            <a class="navbar-caption text-white display-2">VA-CHIER.COM   |</a>
                            <a class="navbar-caption text-white display-4">À TOUS CEUX QUI LE MÉRITE<br>
                                ALLEZ-DONC CHIER !!!</a>
                        </span>
                    </div>
                </div>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <%-- <ul class="navbar-nav nav-dropdown" data-app-modern-menu="true">
                        <li class="nav-item">
                            <a class="nav-link link text-white display-4" data-toggle="modal" data-target="#modalChercherMerde">
                                <span class="mbri-search mbr-iconfont mbr-iconfont-btn"></span>CHERCHER DANS LA MERDE</a>
                        </li>
                    </ul>--%>
                    <div class="navbar-buttons mbr-section-btn">

                        <a class="btn btn-sm btn-info display-4" data-toggle="modal" data-target="#modalAjouterMerde">
                            <span class="mbri-save mbr-iconfont mbr-iconfont-btn "></span>
                            AJOUTER TA MERDE</a>



                    </div>
                </div>
            </nav>
        </section>
        
        <section>
            test de merde
        </section>

        <section class="features17 cid-qQmfyhm9rf" id="features17-k">

            <div class="container-fluid">


                <div class="pagination">
                    <asp:Button runat="server" ID="btnPrecedent" Text="❮" OnClick="btnPrecedentOnclick"></asp:Button>
                    <%-- <asp:DropDownList runat="server" />--%>
                    <asp:Button runat="server" ID="btnSuivant" Text="❯" OnClick="btnSuivantOnclick"></asp:Button>
                </div>

                <asp:ScriptManager runat="server" id="ScriptManager"/>
                <asp:UpdatePanel runat="server" id="updatePanel">
                    <ContentTemplate>
                        <asp:Repeater ID="rptVachier" runat="server" OnItemCommand="rptVachierCommand">
                            <ItemTemplate>
                                <%# Container.ItemIndex == 0 ? "<div class=\"media-container-row\">" : "" %>
                                <%# Container.ItemIndex % 6 == 0 && Container.ItemIndex !=0 ? "</div><div class=\"media-container-row\">" : "" %>

                                <div class="card p-3 col-12 col-md-6 col-lg-2">
                                    <div class="card-wrapper">
                                        <div class="card-box">
                                            <h4 class="card-title pb-3 mbr-fonts-style display-7">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td><%#  Eval("Titre").ToString().Length > 0 ? Eval("Titre") : "" %></td>
                                                        <td style="text-align: right;">
                                                            <asp:ImageButton runat="server" ImageUrl="Images/likebrun.png" CommandArgument='<%#Eval("Id") %>' CommandName="Jaime" />
                                                            <%#Eval("NombreJaime") %>
                                                        </td>

                                                    </tr>
                                                </table>
                                            </h4>
                                            <p class="mbr-text mbr-fonts-style display-7">
                                                <%--  <%# FormatterDescription(Eval("Description").ToString()).Length > 140 ? FormatterDescription(Eval("Description").ToString()).Substring(0,140) +  "<div><a href=\"#\" data-toggle=\"tooltip\" title=\"" + Eval("Description") + "\"> [ plus de marde ] </a></div>" : FormatterDescription(Eval("Description").ToString()) %>
                                                --%>
                                                <%# FormatterDescription(Eval("Description").ToString())%>

                                                <%--<%#  Eval("Description").ToString().Length > 140 ? Eval("Description").ToString().Substring(0,140) +  "... <div><a href=\"#\" data-toggle=\"popover\" title=\"La merde totale\" data-content=\"" +  Eval("Description") + "\" data-trigger=\"focus\"> [ Plus de marde ]</a><br><br></div>" :  Eval("Description")%>--%>
                                                <div style="color: rgb(159, 108, 35); font-size: 11px; font-weight: bold;">
                                                    Posté le <%# Eval("DateCreation", "{0:d}")%><br />
                                                    <a href="#" data-toggle="tooltip" title="Une belle merde régionale!"><%# Eval("AffichagePaysRegionVille") %></a>
                                                </div>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </section>

        <section class="progress-bars2 cid-qQNE10ZQpz" id="progress-bars2-t">
            <div class="container">
                <h2 class="mbr-section-title pb-3 align-center mbr-fonts-style display-2">NOS TOPS MERDEUX</h2>

                <h3 class="mbr-section-subtitle mbr-fonts-style display-5">ON A DE BONNE PETITE MERDE LA DEDANS</h3>

                <div class="row pt-5 mt-5">
                    <div class="col-md-6 text-elements">
                        <h4 class="section-content-title pb-3 align-left mbr-fonts-style display-5">Top 10 des commentaires merdeux
                        </h4>

                        <asp:Repeater runat="server" ID="rptTopMerdeux">
                            <ItemTemplate>
                                <div class="progress1 pb-5">
                                    <div class="title-wrap">
                                        <div class="progressbar-title mbr-fonts-style display-7">
                                            <p>
                                                <%# Container.ItemIndex + 1 %>. <%#  FormatterDescription(Eval("Description").ToString()) %>
                                            </p>
                                        </div>
                                        <div class="progress_value mbr-fonts-style display-7">
                                            <div>
                                                <%# Eval("NombreJaime") %>
                                                <span>votes</span>
                                            </div>
                                        </div>
                                    </div>
                                    <progress class="progress progress-primary " max='<%#  ObtenirNombreTotalVote() %>' value='<%# Eval("NombreJaime") %>'></progress>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="progress_elements col-md-6">

                        <h4 class="section-content-title pb-3 align-left mbr-fonts-style display-5">Top 10 des régions de marde !
                        </h4>

                        <asp:Repeater runat="server" ID="rptTopVille">
                            <ItemTemplate>
                                <div class="progress1 pb-5">
                                    <div class="title-wrap">
                                        <div class="progressbar-title mbr-fonts-style display-7">
                                            <p>
                                                <%# Container.ItemIndex + 1 %>. <%#  FormatterDescription(Eval("Localisation").ToString()) %>
                                            </p>
                                        </div>
                                        <div class="progress_value mbr-fonts-style display-7">
                                            <div>
                                                <%# Eval("Compte") %>
                                                <span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <progress class="progress progress-primary " max='<%#  ObtenirNombreTotalVille() %>' value='<%# Eval("Compte") %>'></progress>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>


                </div>
            </div>
        </section>

        <section class="cid-qQJDbfQWRs" id="social-buttons3-m">





            <div class="container">
                <div class="media-container-row">
                    <div class="col-md-8 align-center">
                        <h2 class="pb-3 mbr-section-title mbr-fonts-style display-2">PARTAGE TA MARDE</h2>
                        <div>
                            <div class="mbr-social-likes">
                                <span class="btn btn-social socicon-bg-facebook facebook mx-2" title="Share link on Facebook">
                                    <i class="socicon socicon-facebook"></i>
                                </span>
                                <span class="btn btn-social twitter socicon-bg-twitter mx-2" title="Share link on Twitter">
                                    <i class="socicon socicon-twitter"></i>
                                </span>
                                <span class="btn btn-social plusone socicon-bg-googleplus mx-2" title="Share link on Google+">
                                    <i class="socicon socicon-googleplus"></i>
                                </span>


                                <span class="btn btn-social pinterest socicon-bg-pinterest mx-2" title="Share link on Pinterest">
                                    <i class="socicon socicon-pinterest"></i>
                                </span>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section once="" class="cid-qQJDgdJQ5i" id="footer6-n">





            <div class="container">
                <div class="media-container-row align-center mbr-white">
                    <div class="col-12">
                        <p class="mbr-text mb-0 mbr-fonts-style display-7">
                            © Copyright 2018 VA-CHIER.COM - Toutes mardes réservés
                        </p>
                    </div>
                </div>
            </div>
        </section>


        <script src="assets/web/assets/jquery/jquery.min.js"></script>
        <script src="assets/popper/popper.min.js"></script>
        <script src="assets/tether/tether.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/dropdown/js/script.min.js"></script>
        <script src="assets/touchswipe/jquery.touch-swipe.min.js"></script>
        <script src="assets/sociallikes/social-likes.js"></script>
        <script src="assets/smoothscroll/smooth-scroll.js"></script>
        <script src="assets/theme/js/script.js"></script>


        <%--    <script type="text/javascript">
        $(window).load(function () {
            $('#myModal').modal('show');
        });
    </script>--%>
    </form>
</body>
</html>
