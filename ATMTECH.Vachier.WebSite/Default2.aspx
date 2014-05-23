<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href='http://fonts.googleapis.com/css?family=Indie+Flower' rel='stylesheet' type='text/css'>
</head>
<style>
    body
    {
        margin: 0 0 0 0;
        background-color: rgb(203, 192, 175);
        font-family: Segoe UI;
    }

    .titre
    {
        width: 100%;
        background-color: rgb(105, 92, 71);
        height: 80px;
        font-size: 45px;
        color: white;
        text-align: center;
        font-family: 'Indie Flower', cursive;
    }


    .menu
    {
        width: 100%;
        background-color: rgb(169, 152, 125);
        height: 55px;
        text-align: center;
    }

    h1
    {
        text-transform: uppercase;
        font-size: 12px;
        margin-bottom: 3px;
        letter-spacing: 2px;
        color: white;
    }

    .liste
    {
        float: left;
        background-color: rgb(141, 126, 102);
        width: 25%;
    }

    .vachier
    {
        float: left;
        background-color: rgb(130, 118, 98);
        width: 75%;
    }

    .button
    {
        border-radius: 39px;
        -moz-border-radius: 39px;
        -webkit-border-radius: 39px;
        border: 2px solid #494432;
        font-size: 15px;
        padding-left: 10px;
        padding-right: 10px;
        padding-top: 3px;
        padding-bottom: 3px;
        font-weight: bold;
        background-color: rgb(203, 192, 175);
        font-family: Segoe UI;
    }

        .button:hover
        {
            background: #7b7765;
            color: white;
        }
</style>
<body style="">
    <form id="form1" runat="server">
        <div class="titre">
            <div style="padding: 10px 10px 10px 10px;">À tout ceux qui le mérite... Allez donc chier</div>
        </div>
        <div class="menu">
            <div style="padding: 10px 10px 10px 10px; font-weight: bold; color: white; font-size: 12px; text-transform: uppercase;">
                <asp:Button runat="server" ID="btnAjouter" Text="Ajouter votre merde" CssClass="button" />
                <asp:Button runat="server" ID="btnCherche" Text="Cherche dans la merde" CssClass="button" />
                <asp:Button runat="server" ID="btnAjouterCelebre" Text="Ajoute ta merde célèbre" CssClass="button" />
            </div>
        </div>
        <div>
            <div class="liste">
                <div style="padding: 10px 10px 10px 10px;">
                    <h1>Le top 20 des merdes</h1>
                    <h1>Liste des pays qui chient le plus</h1>
                </div>
            </div>
            <div class="vachier" style="">
                <div style="padding: 10px 10px 10px 10px;">
                    <div style="float: left; width: 90%;">
                        <h1>Les grosses merdes</h1>
                    </div>
                    <div style="float: left; width: 10%; text-align: right;">
                        <h1>(1283)</h1>
                    </div>
                    <div style="clear: both;"></div>

                    <div style="font-weight: bold; font-size: 12px; color: rgb(49, 46, 43)">
                        <div>
                            <div style="float: left; width: 80%;">
                                Gros criss de mongole va donc chier. 
                            <div style="font-size: 10px; color: rgb(194, 189, 177)">Posté le 2000-11-11</div>
                            </div>
                            <div style="float: left; width: 20%; text-align: right;">

                                <img src="Images/like.png" style="width: 20px; height: 20px;" />
                                2 emmerdeurs
                            </div>
                        </div>
                        <br/><br/>
                         <div>
                            <div style="float: left; width: 80%;">
                                j'encule ta femme et tes enfants va donc chier. 
                            <div style="font-size: 10px;">Posté le 2000-11-11</div>
                            </div>
                            <div style="float: left; width: 20%; text-align: right;">

                                <img src="Images/like.png" style="width: 20px; height: 20px;" />
                                23 emmerdeurs
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>

        </div>
    </form>
</body>
</html>
