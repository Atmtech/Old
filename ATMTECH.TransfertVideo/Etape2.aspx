<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etape2.aspx.cs" Inherits="ATMTECH.TransfertVideo.Etape2" %>

<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader, Version=4.0.0.0, Culture=neutral, PublicKeyToken=bc00d4b0e43ec38d" %>

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

    <link href="CSS/ThemeBlue.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">


        <section class="mbr-navbar mbr-navbar--freeze mbr-navbar--absolute mbr-navbar--sticky mbr-navbar--auto-collapse" id="ext_menu-4">
            <div class="mbr-navbar__section mbr-section">
                <div class="mbr-section__container container">
                    <div class="mbr-navbar__container">

                        <div class="mbr-navbar__hamburger mbr-hamburger"><span class="mbr-hamburger__line"></span></div>
                        <div class="mbr-navbar__column mbr-navbar__menu">
                            <nav class="mbr-navbar__menu-box mbr-navbar__menu-box--inline-right">
                                <div class="mbr-navbar__column">
                                    <ul class="mbr-navbar__items mbr-navbar__items--right mbr-buttons mbr-buttons--freeze mbr-buttons--right btn-inverse mbr-buttons--active">
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
                                    <h2 class="mbr-header__text">PLEASE CHOOSE YOUR MOVIE FILE</h2>
                                </div>


                                <div class="contentFileUpload">
                                      <h4>The maximum file size for a file is 300 mo</h4>
                                    <h4>Only file with these format: mp4,wmv,mpg</h4>
                                    <CuteWebUI:Uploader runat="server" ID="Uploader1" InsertText="UPLOAD YOUR MOVIE FILE" OnFileUploaded="Uploader_FileUploaded">
                                        <ValidateOption AllowedFileExtensions="mp4,wmv,mpg" MaxSizeKB="300000" />
                                    </CuteWebUI:Uploader>
                                </div>
                                <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                    <h2>OR WRITE YOUR <img src="Images/Youtube.png" width="160px" height="80px"/> URL</h2>
                                </div>
                                
                                <div class="contentFileUpload">
                                    <b>ENTER YOUR YOUTUBE URL:</b><asp:TextBox runat="server" Width="100%" id="txtYoutube"></asp:TextBox>
                                    <br/><br/>
                                   <asp:Button runat="server" id="btnSaveYoutube" OnClick="btnSaveYoutubeClick" Text="SAVE URL" Class="mbr-buttons__btn btn btn-lg btn-danger"/>
                                </div>
                                <%-- <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="mp4,wmv,mpg"  OnUploadComplete="AjaxFileUpload1_OnUploadComplete" MaximumNumberOfFiles="1"/>
                                <b>Only these files format are supported : mp4,wmv,mpg</b>
                                --%>
                                <div class="mbr-buttons mbr-buttons--right">
                                    <asp:Button runat="server" ID="btnRevenir" Text="PREVIOUS STEP" Class="mbr-buttons__btn btn btn-lg btn-danger" OnClick="btnRevenirClick" />
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
