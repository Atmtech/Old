<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Default1" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="engine"><a rel="external" href="https://mobirise.com">mobile website software</a></section>
    <section class="mbr-box mbr-section mbr-section--relative mbr-section--fixed-size mbr-section--full-height mbr-section--bg-adapted mbr-parallax-background" id="header1-4" style="background-image: url(assets/images/trip1-4032x3024-40.jpg);">
        <div class="mbr-box__magnet mbr-box__magnet--sm-padding mbr-box__magnet--center-center mbr-after-navbar">
            <div class="mbr-overlay" style="opacity: 0.8; background-color: rgb(34, 34, 34);"></div>
            
          
            <div class="mbr-box__container mbr-section__container container">
                <div class="mbr-box mbr-box--stretched">
                    <div class="mbr-box__magnet mbr-box__magnet--center-center">
                        <div class="row">
                            <div class=" col-sm-8 col-sm-offset-2">
                                <div class="mbr-hero animated fadeInUp">
                                    <h1 class="mbr-hero__text" style="">Bonjour. Voici Expedit'n</h1>
                                    <p class="mbr-hero__subtext">
                                        La planification d'expédition simple, efficace et connecté sur votre monde.<br>
                                    </p>
                                </div>
                                <div class="mbr-buttons btn-inverse mbr-buttons--center"><a class="mbr-buttons__btn btn btn-lg animated fadeInUp delay btn-success" href="Inscription.aspx">M'inscrire pour planifier une expédition</a> </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="mbr-arrow mbr-arrow--floating text-center">
                <div class="mbr-section__container container">
                    <a class="mbr-arrow__link" href="#features1-5"><i class="glyphicon glyphicon-menu-down"></i></a>
                </div>
            </div>
        </div>
    </section>
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="features1-5" style="background-color: rgb(255, 255, 255);">
        <div class="mbr-section__container container mbr-section__container--std-top-padding" style="padding-top: 93px;">
            <div class="mbr-section__row row">
                <div class="mbr-section__col col-xs-12 col-sm-4">
                    <div class="mbr-section__container mbr-section__container--center mbr-section__container--middle">
                        <figure class="mbr-figure">
                            <div style="background-color: #3cadd4; border-radius: 50%; height: 100px; width: 100px;"><i class="fa fa-cloud" style="color: white; font-size: 50px; padding-top: 25px;"></i></div>
                        </figure>
                    </div>
                    <div class="mbr-section__container mbr-section__container--middle">
                        <div class="mbr-header mbr-header--reduce mbr-header--center mbr-header--wysiwyg">
                            <h3 class="mbr-header__text">Accessible en tout temps*</h3>
                        </div>
                    </div>
                    <div class="mbr-section__container mbr-section__container--last" style="padding-bottom: 93px;">
                        <div class="mbr-article mbr-article--wysiwyg">
                            <p>
                                Branchez vous, modifier votre itinéraire, suivez votre progression et profitez !
                                *.: Avec un accès à internet
                            </p>
                        </div>
                    </div>
                </div>
                <div class="mbr-section__col col-xs-12 col-sm-4">
                    <div class="mbr-section__container mbr-section__container--center mbr-section__container--middle">
                        <figure class="mbr-figure">
                            <div style="background-color: #add43c; border-radius: 50%; height: 100px; width: 100px;"><i class="fa fa-microphone" style="color: white; font-size: 50px; padding-top: 25px;"></i></div>
                        </figure>
                    </div>
                    <div class="mbr-section__container mbr-section__container--middle">
                        <div class="mbr-header mbr-header--reduce mbr-header--center mbr-header--wysiwyg">
                            <h3 class="mbr-header__text">Informer en temps réel vos proches</h3>
                        </div>
                    </div>
                    <div class="mbr-section__container mbr-section__container--last" style="padding-bottom: 93px;">
                        <div class="mbr-article mbr-article--wysiwyg">
                            <p>Le module de géolocalisation intégré permet a vos proches de vous suivre</p>
                        </div>
                    </div>
                </div>
                <div class="mbr-section__col col-xs-12 col-sm-4">
                    <div class="mbr-section__container mbr-section__container--center mbr-section__container--middle">
                        <figure class="mbr-figure">
                            <div style="background-color: #d43c61; border-radius: 50%; height: 100px; width: 100px;"><i class="fa fa-rocket" style="color: white; font-size: 50px; padding-top: 25px;"></i></div>
                        </figure>
                    </div>
                    <div class="mbr-section__container mbr-section__container--middle">
                        <div class="mbr-header mbr-header--reduce mbr-header--center mbr-header--wysiwyg">
                            <h3 class="mbr-header__text">Les outils nécessaires pour planifier</h3>
                        </div>
                    </div>
                    <div class="mbr-section__container mbr-section__container--last" style="padding-bottom: 93px;">
                        <div class="mbr-article mbr-article--wysiwyg">
                            <p>Calcul de distance, Liste des choses à ne pas oublier, Calcul de votre budget, Liste des réservations etc.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <asp:Repeater ID="listeExpedition" runat="server" Visible="False">
        <ItemTemplate>
            <section class="4u 6u(medium) 12u$(xsmall) profile">
                <asp:Image runat="server" ID="imgExpedition" ImageUrl='<%# Eval("FichierImage") %>' Style="border-radius: 50%; width: 100px; height: 100px;" />
                <h4>
                    <asp:HyperLink runat="server" ID="lblNomExpedition" Text='<%# Eval("Nom").ToString().Length > 25 ? Eval("Nom").ToString().Substring(0,25) + "[...]" : Eval("Nom").ToString()  %>' NavigateUrl='<%# "VoirExpedition.aspx?Id=" + Eval("Id") %>'></asp:HyperLink>
                </h4>
                <div style="font-size: 13px;">
                    <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                    <i class="fa fa-hand-o-right"></i>
                    <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label>
                </div>
                <p>
                    <i class="fa fa-user"></i>
                    <asp:Label runat="server" ID="lblChefListe" Text='<%# Eval("Administrateur.Utilisateur.FirstNameLastName","{0:yyyy-MM-dd}")  %>'></asp:Label>
                </p>
            </section>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
