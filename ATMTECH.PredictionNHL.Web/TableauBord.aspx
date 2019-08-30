<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" Inherits="ATMTECH.PredictionNHL.Web.TableauBordPage" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb text-uppercase">
            <li class="breadcrumb-item active">Tableau de bord</li>
        </ol>

        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="lblPrediction" class="font-weight-bold" Text="Vos prédictions" />
                    </div>
                    <div class="card-body">
                        <label class="font-weight-bold">Date de la prédiction (les dates avec des * ont déja des prédictions)</label>
                        <asp:DropDownList runat="server" class="form-control bg-dark text-white" ID="ddlDatePrediction" PlaceHolder="Date" required="true" OnSelectedIndexChanged="ddlDatePrediction_SelectedIndexChanged" AutoPostBack="true" />

                        <asp:Panel runat="server" ID="pnlPrediction">
                            <table class="table table-dark table-hover table-striped">
                                <thead>
                                    <tr>
                                        <th>Réel</th>
                                        <th>Prédiction</th>
                                        <th>Visiteur</th>
                                        <th>@</th>
                                        <th>Réel</th>
                                        <th>Prédiction</th>
                                        <th>Local</th>
                                        <th></th>


                                    </tr>
                                </thead>
                                <asp:Repeater runat="server" ID="repeaterPrediction" OnItemCommand="repeaterPrediction_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 25px;">
                                                <h1>
                                                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("PointageVisiteur").ToString() %>'></asp:Label></h1>
                                            </td>
                                            <td style="width: 25px;">
                                                <asp:TextBox runat="server" ID="txtPredictionPointageVisiteur" ReadOnly='<%# Convert.ToBoolean(Eval("EstDejaPredit")) ? true : false  %>' class="form-control  bg-dark text-white" Text='<%# Eval("PredictionPointageVisiteur").ToString() %>' onkeypress="return isNumberKey(event)"></asp:TextBox></td>
                                            <td>
                                                <asp:Label runat="server" ID="lblNomEquipeVisiteur" Text='<%# Eval("NomEquipeVisiteur").ToString() %>'></asp:Label></td>
                                            <td>
                                                <h1>@</h1>
                                            </td>
                                            <td style="width: 25px;">
                                                <h1>
                                                    <asp:Label runat="server" ID="Label4" Text='<%# Eval("PointageLocal").ToString() %>'></asp:Label></h1>
                                            </td>
                                            <td style="width: 25px;">
                                                <asp:TextBox runat="server" ID="txtPredictionPointageLocal" ReadOnly='<%# Convert.ToBoolean(Eval("EstDejaPredit")) ? true : false  %>' class="form-control  bg-dark text-white" Text='<%# Eval("PredictionPointageLocal").ToString() %>' onkeypress="return isNumberKey(event)"></asp:TextBox></td>
                                            <td>
                                                <asp:Label runat="server" ID="lblNomEquipe" Text='<%# Eval("NomEquipeLocal").ToString() %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblGamePrimaryKey" Text='<%# Eval("GamePrimaryKey").ToString() %>' Visible="false "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer ma prédiction" class="btn btn-success btn-sm" CommandName="enregistrer" Visible='<%# Convert.ToBoolean(Eval("EstDejaPredit")) ? false : true  %>' />

                                            </td>
                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label1" class="font-weight-bold" Text="Classements" />
                    </div>
                    <div class="card-body">
                        <table class="table table-dark table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Position</th>
                                    <th>Nom</th>
                                    <th>Nombre de prédictions</th>
                                    <th>Nombre de victoires</th>
                                    <th>Nombre d'échec</th>
                                    <th>Pourcentage réussite</th>
                                    <th>Nombre de points</th>
                                </tr>
                            </thead>

                            <asp:Repeater runat="server" ID="repeaterClassement">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1 %>.</td>
                                        <td><asp:Label runat="server" ID="Label4" Text='<%# Eval("Utilisateur.Affichage").ToString() %>'></asp:Label></td>
                                        <td><asp:Label runat="server" ID="Label3" Text='<%# Eval("NombreTotalPrediction").ToString() %>'></asp:Label></td>
                                        <td><asp:Label runat="server" ID="Label5" Text='<%# Eval("NombreVictoire").ToString() %>'></asp:Label></td>
                                        <td><asp:Label runat="server" ID="Label6" Text='<%# Eval("NombreEchec").ToString() %>'></asp:Label></td>
                                        <td><asp:Label runat="server" ID="Label8" Text='<%# string.Format("{0:0.### %}",Eval("Pourcentage")) %>'></asp:Label></td>
                                        <td><asp:Label runat="server" ID="Label7" Text='<%# Eval("Pointage").ToString() %>'></asp:Label></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
