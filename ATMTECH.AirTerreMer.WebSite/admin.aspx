<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ATMTECH.AirTerreMer.WebSite.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="generator" content="Mobirise v4.7.2, mobirise.com">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1">
    <link rel="shortcut icon" href="assets/images/logo-simple-162x157.png" type="image/x-icon">
    <meta name="description" content="">
    <title>Admin</title>
    <link rel="stylesheet" href="assets/web/assets/mobirise-icons-bold/mobirise-icons-bold.css">
    <link rel="stylesheet" href="assets/web/assets/mobirise-icons/mobirise-icons.css">
    <link rel="stylesheet" href="assets/tether/tether.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-grid.min.css">
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap-reboot.min.css">
    <link rel="stylesheet" href="assets/dropdown/css/style.css">
    <link rel="stylesheet" href="assets/theme/css/style.css">
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css">
    <style>
        BODY {
            background-color: black;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 10px 10px 10px 10px">

            <asp:Panel runat="server" ID="pnlConnecte">

                <div class="row">
                    <div class="col-md-1 mb-2">
                        <label>Utilisateur</label>
                        <asp:TextBox runat="server" ID="txtUtilisateur" class="formulaire"></asp:TextBox>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1 mb-2">
                        <label>Mot de passe</label>
                        <asp:TextBox runat="server" ID="txtMotPasse" class="formulaire" TextMode="Password"></asp:TextBox>

                    </div>
                </div>
                <div class="row">
                    <asp:Button runat="server" ID="btnReserver" Text="Ok" OnClick="btnOkClick" class="btn btn-default btn-group" Style="background-color: rgb(83, 127, 74); color: white; font-weight: bold;" ValidationGroup="Reserver" />

                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlAuthentifie" Visible="false">
                <h2>Ajouter une réservation</h2>
                <table>
                    <tr>
                        <td>Date reservation:</td>
                        <td><asp:TextBox runat="server" ID="txtDateReservation"></asp:TextBox></td>
                    </tr>
                    <tr><td>Prénom:</td>
                        <td><asp:TextBox runat="server" ID="txtPrenom"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Nom:</td>
                        <td><asp:TextBox runat="server" ID="txtNom"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Nom menu</td>
                        <td><asp:TextBox runat="server" ID="txtNomMenu"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><br /><asp:Button runat="server" ID="btnAjouterMenu" Text="Ajouter une réservation" Style="background-color: rgb(83, 127, 74); color: white; font-weight: bold;" OnClick="btnAjouterMenuClick" /></td>
                    </tr>

                </table>
                

                <asp:DataList ID="rptReserve" runat="server" OnItemCommand="rptReserveCommand" RepeatColumns="3">
                    <ItemTemplate>
                        <div style="margin-top: 10px; background-color: rgb(86, 86, 86); margin-left: 10px; padding: 10px 10px 10px 10px">
                            <table>
                                <tr>
                                    <td><b>Date réservation: </b></td>
                                    <td><%#  Eval("DateReservation") %></td>
                                    <td><b>Nombre de personnes</b></td>
                                    <td><%#  Eval("NombreConvive") %></td>
                                </tr>
                                <tr>
                                    <td><b>Au nom de:</b></td>
                                    <td><%#  Eval("Prenom") + " " +  Eval("Nom") %></td>
                                </tr>
                                <tr>
                                    <td><b>Courriel:</b></td>
                                    <td><%#  Eval("Courriel")  %></td>
                                    <td><b>Telephone:</b></td>
                                    <td><%#  Eval("Telephone")  %></td>
                                </tr>
                                <tr>
                                    <td><b>Préférence culinaire:</b></td>
                                    <td><%#  string.IsNullOrEmpty( Eval("PreferenceCulinaire1").ToString()) ? "" : Eval("PreferenceCulinaire1") + "<br>"  %>
                                        <%#  string.IsNullOrEmpty( Eval("PreferenceCulinaire2").ToString()) ? "" : Eval("PreferenceCulinaire2") + "<br>"  %>
                                        <%#  string.IsNullOrEmpty( Eval("PreferenceCulinaire3").ToString()) ? "" : Eval("PreferenceCulinaire3") + "<br>"  %>
                                        <%#  string.IsNullOrEmpty( Eval("PreferenceCulinaire4").ToString()) ? "" : Eval("PreferenceCulinaire4") + "<br>"  %>
                                        <%#  string.IsNullOrEmpty( Eval("PreferenceCulinaire5").ToString()) ? "" : Eval("PreferenceCulinaire5") + "<br>"  %>
                                        <%#  string.IsNullOrEmpty( Eval("PreferenceCulinaire6").ToString()) ? "" : Eval("PreferenceCulinaire6") + "<br>"  %>
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Allergie:</b></td>
                                    <td><%#  Eval("AllergieIntolerance") %>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Informations:</b></td>
                                    <td><%#  Eval("InformationSupplementaire") %>
                                        
                                    </td>
                                </tr>

                                <tr>
                                    <td><b>Nom menu:</b></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNomMenu" Text='<%#  Eval("NomMenu") %>'></asp:TextBox>
                                        <asp:Button runat="server" ID="btnReserver" Text="Sauvegarder" Style="background-color: rgb(83, 127, 74); color: white; font-weight: bold;" CommandArgument='<%#Eval("Id") %>' CommandName="Menu" />
                                    </td>
                                </tr>

                            </table>



                        </div>


                    </ItemTemplate>
                </asp:DataList>

               

            </asp:Panel>
        </div>

        <script src="assets/web/assets/jquery/jquery.min.js"></script>
        <script src="assets/tether/tether.min.js"></script>
        <script src="assets/popper/popper.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/smoothscroll/smooth-scroll.js"></script>
        <script src="assets/dropdown/js/script.min.js"></script>
        <script src="assets/touchswipe/jquery.touch-swipe.min.js"></script>
        <script src="assets/countdown/jquery.countdown.min.js"></script>
        <script src="assets/parallax/jarallax.min.js"></script>
        <script src="assets/theme/js/script.js"></script>

    </form>
</body>
</html>

