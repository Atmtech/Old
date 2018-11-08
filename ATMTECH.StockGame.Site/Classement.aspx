<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Classement.aspx.cs" Inherits="ATMTECH.StockGame.Site.Classement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb text-uppercase">
            <li class="breadcrumb-item "><a href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="breadcrumb-item active">Classement</li>
        </ol>

        <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>

        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label1" class="font-weight-bold" Text="Listes des joueurs" />
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="table table-dark table-hover table-striped table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Rang</th>
                                            <th>Nom</th>
                                            <th>Solde en banque</th>
                                            <th>Solde avec tous les titres vendus</th>
                                        </tr>
                                    </thead>

                                    <asp:Repeater runat="server" ID="repeaterClassement">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="Label8" Text='<%# Eval("Rang").ToString() %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label2" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label3" Text='<%# Eval("Solde", "{0:c}").ToString() %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label4" Text='<%# Eval("SoldeAction", "{0:c}").ToString() %>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
