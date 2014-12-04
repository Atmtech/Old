<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Etouelle.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        @import url(http://fonts.googleapis.com/css?family=Pacifico);
        @import url(http://fonts.googleapis.com/css?family=Montserrat);

        html
        {
            background: url(photoMain.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .circle
        {
            width: 150px;
            height: 150px;
            border-radius: 250px;
            font-size: 20px;
            color: #fff;
            line-height: 150px;
            text-align: center;
            background: #000;
            border: solid 5px bisque;
        }

        A
        {
            text-decoration: none;
            color: bisque;
        }
    </style>

</head>
<body style="margin: 0 0 0 0;">
    <form id="form1" runat="server">
        <div>
            <div style="font-family: Pacifico, sans-serif; padding-left: 200px; padding-top: 150px; color: white; font-size: 80px;">
                Etouelle
            </div>
            <div style="font-family: Montserrat; padding-left: 205px; color: whitesmoke; font-size: 15px;">
                "La rivière prend forme à la tête des sommets<br />
                Rage pour l’amertume qui écume de si près<br />
                Remous convulsifs qui ne nuisent pas aux élans<br />
                Naissant d’un étang, elle y meurt après un temps."<br />
                <br />

            </div>
            <div style="font-family: Montserrat; padding-left: 205px; color: #a6c8c8; font-size: 16px;">
                <table>
                    <tr>
                        <td>
                            <div class="circle"><a href="CV.pdf" target="_new">Curriculum</a></div>
                        </td>
                        <td>
                            <div class="circle"><a href="recueil.pdf" >Écriture</a></div>
                        </td>
                        <td>
                            <div class="circle"><a href="mailto:sagaan@hotmail.com" target="_new">Contact</a></div>
                        </td>
                    </tr>
                </table>


            </div>
        </div>
    </form>
</body>
</html>
