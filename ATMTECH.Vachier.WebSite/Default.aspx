<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1">
    <meta name="description" content="">
    <title>VA-CHIER.COM</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://www.google.com/recaptcha/api.js"></script>
    <link href="site.css" rel="stylesheet" />

</head>
<body style="background-color: #CEBFAF">
    <form id="form1" runat="server">
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="ajouterMerde" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Ajoute ta merde</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label for="usrname" ID="lblTitre" runat="server">Titre</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="txtTitre" MaxLength="20" placeholder="Titre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="psw">Ton petit mot de marde</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtDescription" placeholder="Ton petit mot de marde" MaxLength="280"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="psw">Ton insulte</label>
                            <asp:DropDownList runat="server" class="form-control" ID="ddlInsulte" placeholder="Ton insulte">
                            </asp:DropDownList>
                        </div>

                        <div class="g-recaptcha" data-sitekey="6LcmV6UUAAAAAN1Jizik_mZxykqNyVxD61l3c58m"></div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fermer</button>
                        <asp:Button runat="server" ID="btnAjouterMerde" Text="Ajouter cette belle merde" OnClick="btnAjouterMerdeOnClick" class="btn btn-default btn-group" Style="background-color: rgb(132,82,31); color: white; font-weight: bold;" />
                    </div>
                </div>
            </div>
        </div>

        <div class="navbar navbar-dark bg-dark shadow-sm" style="background-color: #4F4943">
            <div class="container d-flex justify-content-between">
                <a href="Default.aspx" class="navbar-brand d-flex align-items-center">
                    <img src="Images/logo.png" width="70" height="60" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" aria-hidden="true" class="mr-2" viewbox="0 0 24 24" focusable="false"></img>
                    <h1>VA-CHIER.COM | </h1>
                    <div style="text-transform: uppercase">
                        &nbsp;&nbsp;&nbsp;À tous ceux qui le mérite
                        <br />
                        &nbsp;&nbsp;&nbsp;Allez donc chier !!!
                    </div>
                </a>
                <button type="button" class="btn" data-toggle="modal" data-target="#exampleModal" style="background-color: rgb(132,82,31); color: white;">
                    AJOUTE TA MERDE
                </button>
            </div>
        </div>
        <br />

        <asp:ScriptManager runat="server" ID="ScriptManager" />
        <asp:UpdatePanel runat="server" ID="updatePanel">
            <ContentTemplate>
                <div class="container" style="padding-bottom: 25px;">
                    <div class="row">
                        <div class="col-sm">
                            <asp:Button runat="server" ID="btnPrecedent" class="btn" Style="background-color: rgb(132,82,31); color: white;" Text="Page précédente" OnClick="btnPrecedentOnclick" />
                            <asp:Button runat="server" ID="btnSuivant" class="btn" Style="background-color: rgb(132,82,31); color: white;" Text="Page suivante" OnClick="btnSuivantOnclick" />
                        </div>
                        <div class="col-sm">
                            <asp:TextBox runat="server" class="form-control" ID="txtRecherche" MaxLength="20" placeholder="Rechercher"></asp:TextBox>
                        </div>
                        <div class="col-sm">
                            <asp:Button runat="server" ID="btnRechercherMerde" class="btn" Style="background-color: rgb(132,82,31); color: white;" Text="Rechercher" OnClick="btnRechercherMerde_OnClick" />
                            <asp:Label runat="server" id="lblNombreMerdeTrouve" Visible="False"></asp:Label>
                            <%--<asp:Button runat="server" ID="btnRechercherMerde" class="btn" Style="background-color: rgb(132,82,31); color: white;" Text="Rechercher" OnClick="btnRechercherMerde" />--%>
                        </div>
                        
                    </div>

                </div>

                <div class="container">
                    <div class="row">
                        <asp:Repeater ID="rptVachier" runat="server" OnItemCommand="rptVachierCommand">
                            <ItemTemplate>
                                <div class="col-sm">
                                    <div class="card" style="width: 12rem; margin-bottom: 5px;">
                                        <div class="card-body">
                                            <h6><%#  Eval("Titre").ToString().Length > 0 ? Eval("Titre") : "" %></h6>

                                            <div style="font-size: 0.8em;">
                                                <asp:ImageButton runat="server" ImageUrl="Images/likebrun.png" CommandArgument='<%#Eval("Id") %>' CommandName="Jaime" />
                                                <%#Eval("NombreJaime") %> votes
                                                    
                                            </div>
                                            <hr />

                                            <p class="card-text" style="font-size: 0.8em;"><%# FormatterDescription(Eval("Description").ToString())%></p>
                                            <div style="color: rgb(159, 108, 35); font-size: 11px; font-weight: bold;">
                                                Posté le <%# Eval("DateCreation")%><br />
                                                <a href="https://www.google.ca/maps/search/<%# Eval("PourGoogle") %>" target="_blank" data-toggle="tooltip" title="Une belle merde régionale!"><%# Eval("AffichagePaysRegionVille") %></a>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <br />
        <div class="container-fluid" style="background-color: white; padding-top: 50px; padding-bottom: 50px;">
            <div class="container text-center">
                <h5 class=" display-4">NOS TOPS MERDEUX</h5>
                <br />
                <div class="row">
                    <div class="col-sm text-left">
                        <h4>Top 10 des commentaires merdeux</h4>

                        <asp:Repeater runat="server" ID="rptTopMerdeux">
                            <ItemTemplate>
                                <p>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 80%"><%# Container.ItemIndex + 1 %>. <%#  FormatterDescription(Eval("Description").ToString()) %> </td>
                                            <td style="width: 20%; font-size: 0.8em;" class="text-right"><%# Eval("NombreJaime") %> votes</td>
                                        </tr>
                                    </table>
                                </p>

                                <div class="progress">
                                    <div class="progress-bar" role="progressbar" style="width: <%#  Math.Truncate((Convert.ToDouble( Eval("NombreJaime")) / Convert.ToDouble(ObtenirNombreTotalVote())) * 100) %>%">
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-sm  text-left">
                        <h4>Top 10 des régions de marde !</h4>

                        <asp:Repeater runat="server" ID="rptTopVille">
                            <ItemTemplate>
                                <p>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 80%"><%# Container.ItemIndex + 1 %>. <%#  FormatterDescription(Eval("Localisation").ToString()) %> </td>
                                            <td style="width: 20%; font-size: 0.8em;" class="text-right"><%# Eval("Compte") %></td>
                                        </tr>
                                    </table>
                                </p>
                                <div class="progress">
                                    <div class="progress-bar" role="progressbar" style="width: <%#  Math.Truncate((Convert.ToDouble( Eval("Compte")) / Convert.ToDouble( ObtenirNombreTotalVille())) * 100) %>%">
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

        </div>

        <div class="container-fluid" style="background-color: #CEBFAF; padding-top: 50px; padding-bottom: 50px;">
            <div class="container text-center">

                <div id="fb-root"></div>
                <script async defer crossorigin="anonymous" src="https://connect.facebook.net/fr_FR/sdk.js#xfbml=1&version=v3.3&appId=286270354802156&autoLogAppEvents=1"></script>



                <h5 class=" display-4">PARTAGE TA MARDE</h5>

                <a href="http://reddit.com/submit?url=https://va-chier.com&amp;title=Ajouter de la merde" target="_blank">
                    <img src="https://simplesharebuttons.com/images/somacro/reddit.png" alt="Reddit" />
                </a>

                <a href="http://www.facebook.com/sharer.php?u=http://va-chier.com" target="_blank">
                    <img src="https://simplesharebuttons.com/images/somacro/facebook.png" alt="Facebook" />
                </a>

                <a href="http://www.linkedin.com/shareArticle?mini=true&amp;url=http://va-chier.com" target="_blank">
                    <img src="https://simplesharebuttons.com/images/somacro/linkedin.png" alt="LinkedIn" />
                </a>

                <a href="javascript:void((function()%7Bvar%20e=document.createElement('script');e.setAttribute('type','text/javascript');e.setAttribute('charset','UTF-8');e.setAttribute('src','http://assets.pinterest.com/js/pinmarklet.js?r='+Math.random()*99999999);document.body.appendChild(e)%7D)());" target="_blank">
                    <img src="https://simplesharebuttons.com/images/somacro/pinterest.png" alt="Pinterest" />
                </a>

                <a href="https://twitter.com/share?url=http://va-chier.com&amp;text=De la belle merde&amp;hashtags=va-chier.com" target="_blank">
                    <img src="https://simplesharebuttons.com/images/somacro/twitter.png" alt="Twitter" />
                </a>

                <a href="http://www.digg.com/submit?url=http://va-chier.com" target="_blank">
                    <img src="https://simplesharebuttons.com/images/somacro/diggit.png" alt="Digg" />
                </a>




            </div>
        </div>

        <div class="container-fluid" style="background-color: #4F4943; padding-top: 25px; padding-bottom: 25px;">
            <div class="container text-center">
                <h6 class="text-white">© Copyright 2018 VA-CHIER.COM - Toutes mardes réservés</h6>
            </div>
        </div>
    </form>
</body>
</html>
