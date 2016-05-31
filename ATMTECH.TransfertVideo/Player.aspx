﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Player.aspx.cs" Inherits="ATMTECH.TransfertVideo.Player" %>

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
                                        <li class="mbr-navbar__item"><a class="mbr-buttons__btn btn btn-danger" href="Etape1.aspx">UPLOAD MY MOVIE</a></li>
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
                                    <h2 class="mbr-header__text">MOVIE LISTING</h2>
                                </div>
                            </div>

                            <%--<video width="400" controls>

                                <source src="Video/test.mpg" type="video/mpg">
                                Your browser does not support HTML5 video.
                            </video>--%>


                            <%--     <object classid="clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95" width="480" height="360" codebase="http://www.microsoft.com/Windows/MediaPlayer/">
                                <param name="Filename" value="Video/test.wmv">
                                <param name="AutoStart" value="true">
                                <param name="ShowControls" value="true">
                                <param name="BufferingTime" value="2">
                                <param name="ShowStatusBar" value="true">
                                <param name="AutoSize" value="true">
                                <param name="InvokeURLs" value="false">
                                <embed src="Video/test.wmv" type="application/x-mplayer2" autostart="1" enabled="1" showstatusbar="1" showdisplay="1" showcontrols="1" pluginspage="http://www.microsoft.com/Windows/MediaPlayer/" codebase="http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,0,0,0" width="480" height="360"></embed>
                            </object>--%>
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
