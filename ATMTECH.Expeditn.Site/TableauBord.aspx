<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" Inherits="ATMTECH.Expeditn.Site.TableauBordPage" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb text-uppercase">
            <li class="breadcrumb-item active">Tableau de bord</li>
        </ol>
      
        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="lblTitreExpedition" class="font-weight-bold" Text="Les expéditions" />
                    </div>
                    <div class="card-body">

                        <table class="table table-dark table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Nom
                                    </th>
                                    <th>Date début
                                    </th>
                                    <th>Date fin
                                    </th>
                                    <th></th>
                                </tr>
                            </thead>

                            <asp:Repeater runat="server" ID="repeaterExpedition" OnItemCommand="repeaterExpedition_OnItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("Titre").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("Debut", "{0:d}").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label3" Text='<%# Eval("Fin", "{0:d}").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnEnlever" Text="Voir" class="btn btn-success btn-sm" CommandName="Modifier" CommandArgument='<%# Eval("Id")  %>' /></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterExpedition" Text="AJOUTER UNE EXPÉDITION" OnClick="btnAjouterExpedition_OnClick" />

                    </div>
                </div>
            </div>

            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label1" class="font-weight-bold" Text="Les suivis de prix" />
                    </div>
                    <div class="card-body">
                        <table class="table table-dark table-hover table-striped">
                            <thead>
                                <tr>
                                    <th>Nom</th>
                                    <th>Date début</th>
                                    <th>Type</th>
                                    <th></th>
                                </tr>
                            </thead>


                            <asp:Repeater runat="server" ID="repeaterSuiviPrix" OnItemCommand="repeaterSuiviPrix_OnItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("Nom").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label5" Text='<%# Eval("Debut", "{0:d}").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text='<%# Eval("TypeSuiviPrix").ToString() %>'></asp:Label></td>

                                        <td>
                                            <asp:Button runat="server" ID="Button1" Text="Voir" class="btn btn-success btn-sm"   CommandName="Modifier" CommandArgument='<%# Eval("Id")  %>'/></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>



                        </table>


                        <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterSuiviDePrix" Text="AJOUTER UN SUIVI DE PRIX" OnClick="btnAjouterSuiviDePrix_OnClick" />
                    </div>
                </div>
            </div>
        </div>

    </div>


</asp:Content>
