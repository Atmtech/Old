<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.TransfertVideo.Admin" %>

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
            <asp:Panel runat="server" ID="pnlPasOk" Visible="True">
                <div class="mbr-section__container mbr-section__container--std-padding container" style="padding-top: 93px; padding-bottom: 93px;">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-8 col-sm-offset-2" data-form-type="formoid">
                                    <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                        <h2 class="mbr-header__text">Authentication</h2>
                                    </div>

                                    <div class="form-group" style="border: solid 1px lightgray;">
                                        <asp:TextBox runat="server" ID="txtPassword" placeholder="Password"  class="form-control" ></asp:TextBox>
                                    </div>

                                    <div class="mbr-buttons mbr-buttons--right">
                                        <asp:Button runat="server" ID="btnValiderPassword" Class="mbr-buttons__btn btn btn-lg btn-danger" OnClick="btnValiderPasswordClick" Text="SIGN IN" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlOk" Visible="False">
                <div class="mbr-section__container mbr-section__container--std-padding container" style="padding-top: 93px; padding-bottom: 93px;">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-8 col-sm-offset-2" data-form-type="formoid">


                                    <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                        <h2 class="mbr-header__text">MOVIE LISTING</h2>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                Filter by group: 
                                 <asp:DropDownList runat="server" ID="ddlGroupe" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupeChanged" >
                                     <asp:ListItem>all</asp:ListItem>   
                                     <asp:ListItem>100</asp:ListItem>
                                     <asp:ListItem>101</asp:ListItem>
                                 </asp:DropDownList>

                                <br />
                                Total movie received: <b>
                                    <asp:Label Text="text" runat="server" ID="lblTotal" /></b>
                                <br />
                                <br />
                                <asp:GridView ID="GridViewMovie" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewMovie_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Group">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblGroupe" Text='<%# Eval("Groupe")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date received">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDateModified" Text='<%# Eval("DateModified")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Students">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblEtudiant1" Text='<%# Eval("Etudiant1")  %>'></asp:Label><br />
                                                <asp:Label runat="server" ID="lblEtudiant2" Text='<%# Eval("Etudiant2")  %>'></asp:Label><br />
                                                <asp:Label runat="server" ID="lblEtudiant3" Text='<%# Eval("Etudiant3")  %>'></asp:Label><br />
                                                <asp:Label runat="server" ID="lblEtudiant4" Text='<%# Eval("Etudiant4")  %>'></asp:Label><br />
                                                <asp:Label runat="server" ID="lblEtudiant5" Text='<%# Eval("Etudiant5")  %>'></asp:Label><br />
                                                <asp:Label runat="server" ID="lblEtudiant6" Text='<%# Eval("Etudiant6")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Movie style">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblStyle" Text='<%# Eval("Style")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Seen">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblVisionnee" Text='<%# Eval("Visionnee")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnVoir" Class="mbr-buttons__btn btn btn-lg btn-danger" Text='View' CommandName="Voir" CommandArgument='<%#Eval("Guid")%>'></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnVisionnee" Class="mbr-buttons__btn btn btn-lg btn-danger" CommandName="Visionnee" CommandArgument='<%#Eval("Guid")%>' Text="I have seen this movie"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="btnDownload" Class="mbr-buttons__btn btn btn-lg btn-danger" NavigateUrl='<%# "download.aspx?file=" + Eval("FichierMp4")%>' Text="Download"></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
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
