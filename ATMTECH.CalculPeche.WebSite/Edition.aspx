<%@ Page Title="" Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Edition.aspx.cs" Inherits="ATMTECH.CalculPeche.WebSite.Edition" %>





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

     <link href="JQuery/jquery-ui-1.11.2/css/lightbox.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/jquery-ui.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/jquery-ui.custom.css" rel="stylesheet" />
    <link href="JQuery/jquery-ui-1.11.2/ComboBox.css" rel="stylesheet" />
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/external/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/ComboBox.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/autoNumeric.min.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/js/lightbox.min.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/js/jssor.js"></script>
    <script type="text/javascript" src="JQuery/jquery-ui-1.11.2/js/jssor.slider.js"></script>

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
            <section class="mbr-box mbr-section mbr-section--relative mbr-section--fixed-size mbr-section--full-height mbr-section--bg-adapted mbr-parallax-background" id="header4-5" style="background-image: url(assets/images/fishing-2000x1000-74.jpg);">
                <div class="mbr-box__magnet  mbr-box__magnet--top">
                    <div class="mbr-overlay" style="opacity: 0.9; background-color: rgb(34, 34, 34);">
                    </div>

                    <div class="mbr-box__container mbr-section__container container">
                        <div style="color: white; text-align: left;">

                            <div style="padding: 10px 10px 10px 10px; background-color: white;">

                                <div style="margin-bottom: 10px; color: black;">
                                    <asp:Panel runat="server" ID="pnlError" CssClass="errorMessage" BorderStyle="Solid" Visible="False">
                                        <img src="Images/error-icon.png" style="width: 40px; height: 40px; vertical-align: middle;" />
                                        <strong>
                                            <asp:Label runat="server" ID="lblError"></asp:Label></strong>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlSuccess" CssClass="successMessage" BorderStyle="Solid" Visible="False">
                                        <img src="Images/success-icon.png" style="width: 40px; height: 40px; vertical-align: middle;" />
                                        <strong>
                                            <asp:Label runat="server" ID="lblSuccess"></asp:Label></strong>
                                    </asp:Panel>
                                </div>


                                <asp:Panel runat="server" ID="pnlEdition" Visible="False" CssClass="panneauEdition">
                                    <div style="margin-bottom: 10px;">
                                        <asp:PlaceHolder runat="server" ID="pnlControl"></asp:PlaceHolder>
                                    </div>
                                    <div class="panneauEditionBouton">
                                        <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" OnClick="btnEnregistrerClick" CausesValidation="False"
                                            class="mbr-buttons__btn btn btn-lg btn-danger" />
                                        <asp:Button runat="server" ID="btnAnnuler" Text="Annuler" OnClick="btnAnnulerClick" CausesValidation="False"
                                            class="mbr-buttons__btn btn btn-lg btn-danger" />
                                    </div>
                                </asp:Panel>
                            </div>
                            <div style="background-color: white; color: black;">

                                <asp:Panel runat="server" ID="pnlPilotage">
                                    <div>
                                        Pilotage des données ::<asp:Label runat="server" ID="lblTitre"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Panel runat="server" ID="pnlheader">
                                            <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                                                <legend><b>Critère de recherche</b></legend>
                                                <asp:Panel runat="server" ID="pnlRecherche" Visible="True">
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtCritereRecherche" placeholder="Entrer votre critère de recherche (Vide pour tout)" Width="400px" /></td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:Button runat="server" ID="btnRecherche" OnClick="btnRechercheClick" Text="Filtrer"
                                                                    class="mbr-buttons__btn btn btn-lg btn-danger" CausesValidation="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    Nombre d'éléments trouvés: <b>
                                                        <asp:Label runat="server" ID="lblNombreElementTrouve" Text=""></asp:Label></b>
                                                </asp:Panel>
                                            </fieldset>
                                        </asp:Panel>
                                        <br />
                                        <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                                            <legend><b>Liste des données obtenues par le filtre</b></legend>
                                            <div style="overflow: scroll;">
                                                <div style="margin-bottom: 10px;">
                                                    <asp:Button runat="server" ID="btnAjouter" OnClick="btnAjouterClick" Text="Ajouter une nouvelle donnée" CausesValidation="False"
                                                        class="mbr-buttons__btn btn btn-lg btn-danger" />
                                                </div>
                                                <asp:GridView ID="grdData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                                    AllowPaging="True" AutoGenerateColumns="False" PageSize="10" OnRowCommand="grdDataRowCommandClick"
                                                    OnPageIndexChanging="grdDataPageIndexChanging" Font-Size="12px" EmptyDataText="Aucune données ...">
                                                    <Columns>
                                                        <asp:ButtonField CommandName="Inactive" ImageUrl="Images/supprimer.gif" Text="Supprimer"
                                                            CausesValidation="False" ButtonType="Image" />
                                                        <asp:ButtonField ImageUrl="Images/edition.png" CommandName="Edition" Text="Edition"
                                                            CausesValidation="False" ButtonType="Image" />
                                                        <asp:ButtonField ImageUrl="Images/Copy.png" CommandName="Copie" Text="Copie" CausesValidation="False"
                                                            ButtonType="Image" />
                                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                                    </Columns>
                                                    <FooterStyle BackColor="darkslategray" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="darkslategray" Font-Bold="True" ForeColor="White" Font-Size="15px" />
                                                    <PagerSettings Position="TopAndBottom" />
                                                    <PagerStyle BackColor="darkslategray" ForeColor="White" Font-Bold="True" Font-Size="15px" HorizontalAlign="Left" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <AlternatingRowStyle BackColor="#FFE1E1E1" ForeColor="#284775" />
                                                </asp:GridView>
                                            </div>
                                        </fieldset>
                                    </div>
                                </asp:Panel>
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

