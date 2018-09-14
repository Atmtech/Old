<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectionnerUtilisateur.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.SelectionnerUtilisateur" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="form-group row">
            <div class="col">
                <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtRechercherUtilisateur" PlaceHolder="Rechercher utilisateur" />
            </div>
            <div class="col">
                <asp:Button runat="server" ID="btnRechercher" Text="Rechercher" class="btn btn-default btn-group btn-success font-weight-bold" OnClick="btnRechercherClick" />
            </div>
        </div>
        <div class="form-group row">
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
                    <asp:Repeater runat="server" ID="repeaterListeUtilisateur" OnItemCommand="repeaterListeUtilisateurItemCommand" >
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
        </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
