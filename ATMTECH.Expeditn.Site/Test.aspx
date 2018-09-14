<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ATMTECH.Expeditn.Site.Test" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title></title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous">
    <style>
        body {
            font-size: .875rem;
        }




        /*
 * Navbar
 */

        .navbar .form-control {
            padding: .75rem 1rem;
            border-width: 0;
            border-radius: 0;
        }

        .form-control-dark {
            color: #fff;
            background-color: rgba(255, 255, 255, .1);
            border-color: rgba(255, 255, 255, .1);
        }

            .form-control-dark:focus {
                border-color: transparent;
                box-shadow: 0 0 0 3px rgba(255, 255, 255, .25);
            }

        .jumbotron {
            margin-bottom: 0px;
        }

        .jumboTronPecheur .jumbotron {
            text-align: center;
            color: white;
            background: linear-gradient(rgba(0, 0, 0, 0.65), rgba(0, 0, 0, 0.65)), url("http://www.theleader.info/wp-content/uploads/2018/01/Freshwater-fishing.jpg")no-repeat no-repeat;
            background-size: 100%;
            height: 100vh;
        }

        .jumboTronPecheur2 .jumbotron {
            color: white;
            background: linear-gradient(rgba(0, 0, 0, 0.65), rgba(0, 0, 0, 0.65)), url("http://sbybiz.com/wp-content/uploads/2018/05/Castaways-Freshwater-fishing-1-7-22-16.jpg")no-repeat no-repeat;
            background-size: 100%;
            height: 600px;
        }
    </style>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">

        <nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 ">
            <a class="navbar-brand col-sm-3 col-md-2 mr-0 font-weight-bold text-uppercase" href="#">expedit'n</a>
            <input class="form-control form-control-dark w-100" type="text" placeholder="RECHERCHER UNE EXPÉDITION" aria-label="RECHERCHER UNE EXPÉDITION">

            <ul class="navbar-nav px-3 ">
                <li class="nav-item text-nowrap ">
                    <asp:Button runat="server" class="btn btn-primary font-weight-bold" href="#" Text="OUVRIR UNE SESSION"></asp:Button>
                </li>

            </ul>
            <ul class="navbar-nav px-2 ">
                <li class="nav-item text-nowrap ">
                    <a class="btn btn-success font-weight-bold" href="#">CREER UN COMPTE</a>
                </li>
            </ul>
        </nav>

        <div class="jumboTronPecheur">

            <div class="jumbotron">
               
                
                <p class="mx-auto bg-white text-dark py-3 text-left px-3" style="width: 75%">
                    test
                </p>

                <h1 class="display-4">Bonjour. Voici Expedit'n</h1>

                <br />
                <p>La planification d'expédition simple, efficace et connecté sur votre monde.</p>
                <hr class="my-4">
                <p class="lead">
                    <a class="btn btn-primary btn-lg font-weight-bold" href="#" role="button">OUVRIR UNE SESSION</a>
                </p>

            </div>
        </div>



    </form>


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>


    <script>
        var jumboHeight = $('.jumbotron').outerHeight();
        function parallax() {
            var scrolled = $(window).scrollTop();
            $('.bg').css('height', (jumboHeight - scrolled) + 'px');
        }

        $(window).scroll(function (e) {
            parallax();
        });
    </script>
</body>
</html>
