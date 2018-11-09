<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Pass.Website.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Passthrought</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous" />

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="site.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="form-group row">
            <div class="col">
                <div class="text-white pt-3 pl-5 font-weight-bold text-uppercase fa-text-height " style="font-size: 20px;">
                    <table>
                        <tr>
                            <td>
                                <asp:HyperLink runat="server" ID="hyperLinkHome" NavigateUrl="Default.aspx" Text="PASSWORD" class="text-white display-4" Style="text-decoration: none;"></asp:HyperLink></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="col">
                <div class="pt-3 pl-5 align-right" style="text-align: right">
                    <asp:Button runat="server" class="btn btn-dark font-weight-bold" Text="FERMER SESSION" ID="btnFermerSession" formnovalidate Visible="False" OnClick="btnFermerSessionOnclick"></asp:Button>

                </div>
            </div>
        </div>

        <div class="ml-4 mr-4" style="">
            <asp:Panel runat="server" class="alert alert-danger" role="alert" Visible="False" ID="pnlMessageErreur">
                <asp:Label runat="server" ID="lblMessageErreur"></asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" class="alert alert-danger" role="alert" Visible="False" ID="pnlMessageSucces">
                <asp:Label runat="server" ID="lblMessageSucces"></asp:Label>
            </asp:Panel>
            <asp:ScriptManager runat="server" ID="script"></asp:ScriptManager>

            <div class="text-black bg-white py-3 text-left px-3">
                <asp:Panel runat="server" ID="pnlIdentification">
                    <h2>Identification</h2>
                    <hr class="my-4">
                    <div class="form-group row">
                        <label class="col-sm-1 col-form-label">Courriel</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtCourriel" placeholder="email@example.com" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-1 col-form-label">Mot de passe</label>
                        <div class="col-sm-10">
                            <asp:TextBox class="form-control  bg-dark text-white" ID="txtMotPasse" TextMode="Password" runat="server" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-10">
                            <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnConnecter" Text="SE CONNECTER" OnClick="btnConnecterOnClick"></asp:Button>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlIdentifie" Visible="False">
                    <h2>Liste mot de passe enregistré</h2>
                    <table class="table table-dark table-hover table-striped table-condensed">
                        <thead>
                            <tr>
                                <th>Emplacement</th>
                                <th>Courriel</th>
                                <th>Mot de passe</th>
                            </tr>
                        </thead>
                        <asp:Repeater runat="server" ID="repeaterPassword">
                            <ItemTemplate>
                                <tr>
                                    <td> <asp:Label runat="server" ID="Label8" Text='<%# Eval("Emplacement").ToString() %>'></asp:Label></td>
                                    <td> <asp:Label runat="server" ID="Label1" Text='<%# Eval("Courriel").ToString() %>'></asp:Label></td>
                                    <td> <asp:Label runat="server" ID="Label2" Text='<%# Eval("MotDePasse").ToString() %>'></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>

                    <h2>Ajouter mot de de passe</h2>
                    <div class="form-group row">

                        <div class="col">
                            <label class="col-form-label">Courriel</label>
                            <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtCourrielAjouter" placeholder="email@example.com" />
                        </div>
                        <div class="col">
                            <label class="col-form-label">Mot de passe</label>

                            <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtMotPasseAjouter" placeholder="" />
                        </div>
                        <div class="col">
                            <label class="col-form-label">Emplacement</label>

                            <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtEmplacementAjouter" placeholder="" />
                        </div>


                    </div>
                    <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterMotPasse" Text="AJOUTER" OnClick="btnAjouterMotPasse_OnClick" ></asp:Button>
                </asp:Panel>
            </div>



            <div class="text-center py-3 text-white" style="background-color: black;">
                © 2018 Copyright etouelle.com 
            </div>
        </div>
    </form>
</body>
</html>
