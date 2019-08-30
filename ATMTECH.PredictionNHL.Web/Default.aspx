<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.PredictionNHL.Web.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   


    <style>
        html,
        body,
        header,
        .view {
            height: 100%;
        }

        @media (max-width: 740px) {
            html,
            body,
            header,
            .view {
                height: 1000px;
            }
        }

        @media (min-width: 800px) and (max-width: 850px) {
            html,
            body,
            header,
            .view {
                height: 600px;
            }
        }

        .btn .fa {
            margin-left: 3px;
        }

        .top-nav-collapse {
            background-color: #424f95 !important;
        }

        .navbar:not(.top-nav-collapse) {
            background: transparent !important;
        }

        @media (max-width: 991px) {
            .navbar:not(.top-nav-collapse) {
                background: #424f95 !important;
            }
        }

        .btn-white {
            color: black !important;
        }

        h6 {
            line-height: 1.7;
        }

        .rgba-gradient {
            background: -moz-linear-gradient(45deg, rgba(0, 0, 0, 0.7), rgba(126, 126, 126, 0.7) 100%);
            background: -webkit-linear-gradient(45deg,rgba(0, 0, 0, 0.7), rgba(126, 126, 126, 0.7) 100%);
            background: -webkit-gradient(linear, 45deg, from(rgba(0, 0, 0, 0.7)), to(rgba(126, 126, 126, 0.7)));
            background: -o-linear-gradient(45deg,rgba(0, 0, 0, 0.7), rgba(126, 126, 126, 0.7) 100%);
            background: linear-gradient(to 45deg, rgba(0, 0, 0, 0.7), rgba(126, 126, 126, 0.7) 100%);
        }
    </style>


     <div class="view" style=" background-repeat: no-repeat; background-size: cover; background-position: center center;">
        <div class="mask rgba-gradient d-flex justify-content-center align-items-center">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 white-text text-center text-md-left mt-xl-5 mb-5 wow fadeInLeft" data-wow-delay="0.3s">
                        <h1 class="h1-responsive font-weight-bold mt-sm-5 text-white">Prediction NHL</h1>
                        <hr class="hr-light">
                        <h6 class="mb-4 text-white"> </h6>
                        <a class="btn btn-success font-weight-bold" href="Identification.aspx" role="button">OUVRIR UNE SESSION</a>
                        <a class="btn btn-dark font-weight-bold" href="Identification.aspx?Creer=1" role="button">CRÉER UN COMPTE</a>
                        
                          <asp:button class="btn btn-dark font-weight-bold" runat="server" ID="btnGet" Text="tamere" OnClick="btnGet_Click" />


                        <%--<input size="16" type="text" value="2012-06-15" readonly class="form_datetime form-control  bg-dark text-white">--%>
      
                    </div>
                    <div class="col-md-6 col-xl-5 mt-xl-5 wow fadeInRight" data-wow-delay="0.3s">
                        <img src="Images/compass-icon.png" alt="" class="img-fluid w-50">
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
