<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Activites.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.Activites" %>
<asp:UpdatePanel runat="server" ID="updatePanelaJouterActivite" UpdateMode="Conditional" ChildrenAsTriggers="True">
    <ContentTemplate>
        <div id="modalAjouterActivite" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Ajouter des activités</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-group row">
                                    <div class="col">
                                        <label class="font-weight-bold">Nom</label><br />
                                        <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtNomActivite" PlaceHolder="Nom"></asp:TextBox>
                                        <label class="font-weight-bold">Description</label><br />
                                        <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtDescriptionActivite" PlaceHolder="Description" TextMode="MultiLine"></asp:TextBox>
                                        <label class="font-weight-bold">Type activité</label><br />
                                        <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtTypeActivite" PlaceHolder="Type activité"></asp:TextBox>
                                        <label class="font-weight-bold">Date</label><br />
                                        <asp:DropDownList runat="server" class="form-control bg-dark text-white" ID="ddlDateActivite" PlaceHolder="Date"></asp:DropDownList>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="modal-footer">
                            <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterActivite" Text="AJOUTER ACTIVITÉ" OnClick="btnAjouterActivite_OnClick"></asp:Button>
                            <asp:Button runat="server" ID="btnFermerActivite" class="btn btn-default btn-dark btn-group" OnClick="btnFermerActivite_OnClick" Text="FERMER" formnovalidate></asp:Button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>


<div class="card">
    <div class="card-header text-uppercase font-weight-bold">
        <asp:Label runat="server" ID="lblTitrePanneauExpedition" class="font-weight-bold" Text="Les activités" />
    </div>
    <div class="card-body">

        <div class="form-group row">
            <div class="col">
                <a class="btn btn-success font-weight-bold text-white" data-toggle="modal" data-target="#modalAjouterActivite" formnovalidate>AJOUTER ACTIVITÉ</a>
                <br />
                <br />
                <table class="table table-dark table-hover table-striped">
                    <thead>
                        <tr>
                            <th></th>
                            <th></th>
                            <th>Nom
                            </th>
                            <th>Description
                            </th>
                            <th>Date
                            </th>
                            <th>Type
                            </th>
                            <th></th>
                            <th>Participant
                            </th>

                        </tr>
                    </thead>
                    <tbody>

                        <asp:Repeater runat="server" ID="repeaterActivite" OnItemDataBound="repeaterActivite_OnItemDataBound" OnItemCommand="repeaterActivite_OnItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:ImageButton src="Images/edit-icon.png" Style="width: 16px; height: 16px;" runat="server" CommandName="edit" CommandArgument='<%# Eval("Id")  %>' /></td>
                                    <td>
                                        <asp:ImageButton src="Images/delete.png" Style="width: 16px; height: 16px;" runat="server" CommandName="delete" CommandArgument='<%# Eval("Id")  %>' /></td>
                                    <td>
                                        <asp:Label runat="server" ID="lblNom" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                                        <asp:TextBox runat="server" ID="txtNom" Text='<%# Eval("Nom").ToString() %>' Visible="False" class="form-control bg-dark text-white"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description").ToString() %>'></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDescription" Text='<%# Eval("Description").ToString() %>' Visible="False" class="form-control bg-dark text-white"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblDate" Text='<%# Eval("Date","{0:d}") %>'></asp:Label>

                                        <asp:TextBox runat="server" ID="txtDate" Text='<%# Eval("Date","{0:d}") %>' Visible="False" class="form-control bg-dark text-white"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblTypeActivite" Text='<%# Eval("TypeActivite").ToString() %>'></asp:Label>
                                        <asp:TextBox runat="server" ID="txtTypeActivite" Text='<%# Eval("TypeActivite").ToString() %>' Visible="False" class="form-control bg-dark text-white"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" class="btn btn-success btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="enregistrer" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblIdActivite" Text='<%# Eval("Id").ToString() %>' Visible="False"></asp:Label>
                                        <asp:Repeater runat="server" ID="repeaterListeParticipantActivite" OnItemCommand="repeaterListeParticipantActivite_OnItemCommand" OnItemDataBound="repeaterListeParticipantActivite_OnItemDataBound">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" ID="updatePanel1" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="row">

                                                            <div class="col" style="margin-bottom: 14px;">
                                                                <asp:Label runat="server" ID="Label1" Text='<%# Eval("Prenom").ToString() %>'></asp:Label>
                                                                <asp:Label runat="server" ID="Label5" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                                                            </div>

                                                            <div class="col">
                                                                <asp:Button runat="server" ID="btnPresent" Text="Présent" class="btn btn-success btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="Present" Visible="True" />
                                                                <asp:Button runat="server" ID="btnAbsent" Text="Absent" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="Absent" Visible="True" />
                                                            </div>

                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:Repeater>
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
