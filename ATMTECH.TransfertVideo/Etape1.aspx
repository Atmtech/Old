<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etape1.aspx.cs" Inherits="ATMTECH.TransfertVideo.Etape1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="generator" content="Mobirise v2.11, mobirise.com" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:700,400&amp;subset=cyrillic,latin,greek,vietnamese" />
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/animate.css/animate.min.css" />
    <link rel="stylesheet" href="assets/mobirise/css/style.css" />
    <link rel="stylesheet" href="assets/dropdown-menu-plugin/style.css" />
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css" />


</head>
<body>
    <form id="form1" runat="server">

        <style>
            .ajax__fileupload_dropzone {
                border: dotted 1px #B2D1E0 !important;
                color: #B2D1E0 !important;
            }

            .ajax__fileupload_uploadbutton {
                font-family: "Roboto", Helvetica, Arial, sans-serif;
                margin: 0 10px 13px 0;
                text-transform: uppercase;
                background-color: #f97352;
                width: 200px;
                margin-right: 0px;
                padding: 10px 10px 10px 10px;
                letter-spacing: 2px;
            }

            .ajax__fileupload {
                height: 175px;
            }
        </style>

        <section class="mbr-navbar mbr-navbar--freeze mbr-navbar--absolute mbr-navbar--sticky mbr-navbar--auto-collapse" id="ext_menu-4">
            <div class="mbr-navbar__section mbr-section">
                <div class="mbr-section__container container">
                    <div class="mbr-navbar__container">

                        <div class="mbr-navbar__hamburger mbr-hamburger"><span class="mbr-hamburger__line"></span></div>
                        <div class="mbr-navbar__column mbr-navbar__menu">
                            <nav class="mbr-navbar__menu-box mbr-navbar__menu-box--inline-right">
                                <div class="mbr-navbar__column">
                                    <ul class="mbr-navbar__items mbr-navbar__items--right mbr-buttons mbr-buttons--freeze mbr-buttons--right btn-inverse mbr-buttons--active">
                                        <li class="mbr-navbar__item"><a class="mbr-buttons__btn btn btn-danger" href="Transfert.aspx">UPLOAD MY MOVIE</a></li>
                                    </ul>
                                </div>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="engine"><a rel="external" href="https://mobirise.com">mobile website creator</a></section>
        <section class="mbr-section mbr-section--relative mbr-section--fixed-size mbr-after-navbar" id="form1-7" style="background-color: rgb(239, 239, 239);">

            <div class="mbr-section__container mbr-section__container--std-padding container" style="padding-top: 93px; padding-bottom: 93px;">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-8 col-sm-offset-2" data-form-type="formoid">
                                <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                    <h2 class="mbr-header__text">WRITE THE REQUIRED INFORMATION</h2>
                                </div>

                                <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                    <h3>Please write clearly your information !</h3>
                                </div>
                                <asp:Panel runat="server" ID="pnlErreurNull" ForeColor="red" Visible="False">
                                    Your group number and all your teammate names is required !!!
                                </asp:Panel>
                                
                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" placeholder="Group number *" class="form-control" ID="txtGroupe"></asp:TextBox>
                                    </div>

                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" placeholder="Student name 1 *" class="form-control" ID="txtEtudiant1"></asp:TextBox>
                                    </div>

                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" placeholder="Student name 2" class="form-control" ID="txtEtudiant2"></asp:TextBox>
                                    </div>

                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" placeholder="Student name 3" class="form-control" ID="txtEtudiant3"></asp:TextBox>
                                    </div>

                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" placeholder="Student name 4" class="form-control" ID="txtEtudiant4"></asp:TextBox>
                                    </div>

                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" placeholder="Student name 5" class="form-control" ID="txtEtudiant5"></asp:TextBox>
                                    </div>

                                    <div class="mbr-buttons mbr-buttons--right">
                                        <asp:Button runat="server" ID="btnSuivant" Text="NEXT STEP" Class="mbr-buttons__btn btn btn-lg btn-danger" OnClick="btnSuivantClick" />
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <footer class="mbr-section mbr-section--relative mbr-section--fixed-size" id="footer1-6" style="background-color: rgb(68, 68, 68);">

            <div class="mbr-section__container container">
                <div class="mbr-footer mbr-footer--wysiwyg row" style="padding-top: 36.900000000000006px; padding-bottom: 36.900000000000006px;">
                    <div class="col-sm-12">
                        <p class="mbr-footer__copyright">Copyright (c) 2016 Twiggy.</p>
                    </div>
                </div>
            </div>
        </footer>


        <script src="assets/web/assets/jquery/jquery.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/smooth-scroll/SmoothScroll.js"></script>
        <!--[if lte IE 9]>
    <script src="assets/jquery-placeholder/jquery.placeholder.min.js"></script>
  <![endif]-->
        <script src="assets/mobirise/js/script.js"></script>
        <script src="assets/dropdown-menu-plugin/script.js"></script>
        <script src="assets/formoid/formoid.min.js"></script>

    </form>
</body>
</html>
