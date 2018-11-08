<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Participant.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.Participant" %>
<%@ Register TagPrefix="SelectionnerUtilisateur" Namespace="ATMTECH.Expeditn.Site.UserControl" Assembly="ATMTECH.Expeditn.Site" %>

<asp:UpdatePanel runat="server" ID="updatePanelParticipant" UpdateMode="Conditional" ChildrenAsTriggers="True">
    <ContentTemplate>
        <div id="modalAjouterParticipant" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Ajouter des participants</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-group row">
                                    <div class="col">
                                        <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtRechercherUtilisateur" PlaceHolder="Rechercher utilisateur" />
                                    </div>
                                    <div class="col">
                                        <asp:Button runat="server" ID="btnRechercher" Text="RECHERCHER" class="btn btn-default btn-group btn-success font-weight-bold" OnClick="btnRechercher_OnClick" formnovalidate />
                                    </div>
                                </div>
                              
                                    <table class="table table-dark table-hover table-striped">
                                        <thead>
                                        <tr>
                                            <th>Prénom
                                            </th>
                                            <th>Nom
                                            </th>
                                            <th>Courriel
                                            </th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <asp:Repeater runat="server" ID="repeaterListeUtilisateur" OnItemCommand="repeaterListeUtilisateur_OnItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("Prenom").ToString() %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("Nom").ToString() %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label runat="server" ID="Label4" Text='<%# Eval("Courriel").ToString() %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnAjouter" Text="Ajouter" class="btn btn-success btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="Ajouter" /></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        </tbody>
                                    </table>
                              

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="modal-footer">
                            <asp:Button runat="server" ID="btnFermerAjouterParticipant" class="btn btn-default btn-dark btn-group" OnClick="btnFermerModalClick" Text="FERMER" formnovalidate></asp:Button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>


<div class="card">
    <div class="card-header text-uppercase font-weight-bold">
        <asp:Label runat="server" ID="lblTitrePanneauExpedition" class="font-weight-bold" Text="Les participants" />
    </div>
    <div class="card-body">
        <div class="form-group row">
            <div class="col">

                <a class="btn btn-success font-weight-bold text-white" data-toggle="modal" data-target="#modalAjouterParticipant" formnovalidate>AJOUTER PARTICIPANT</a>
                <br />
                <br />
                <table class="table table-dark table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Prénom
                            </th>
                            <th>Nom
                            </th>
                            <th>Courriel
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="repeaterParticipant" OnItemCommand="repeaterParticipantItemCommand" OnItemDataBound="repeaterParticipantItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("Prenom").ToString() %>'></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("Nom").ToString() %>'></asp:Label></td>
                                    <td>
                                        <asp:Label runat="server" ID="Label4" Text='<%# Eval("Courriel").ToString() %>'></asp:Label></td>
                                    <td>
                                        <asp:Button runat="server" ID="btnEnlever" Text="Enlever" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="Enlever" />
                                        <asp:Label runat="server" ID="lblEstAdministrateur" Text="Est administrateur" Visible="True"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

            </div>
        </div>
    </div>
</div>
