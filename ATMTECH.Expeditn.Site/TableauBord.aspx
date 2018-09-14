<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" Inherits="ATMTECH.Expeditn.Site.TableauBordPage" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="UserControl/SelectionnerUtilisateur.ascx" TagName="SelectionnerUtilisateur" TagPrefix="SelectionnerUtilisateur" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" ID="updatePanelmodalAjouterRepartitionDepense" UpdateMode="Conditional" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div id="modalAjouterRepartitionDepense" class="modal fade" role="dialog">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Ajouter des dépenses par type d'activités</h4>
                        </div>
                        <div class="modal-body">

                            <label class="font-weight-bold">Participant</label><br />
                            <asp:DropDownList runat="server" class="form-control bg-dark text-white" ID="ddlParticipantDepense" PlaceHolder="Participant"></asp:DropDownList>
                            <label class="font-weight-bold">Type activité</label><br />
                            <asp:DropDownList runat="server" class="form-control bg-dark text-white" ID="ddlTypeActivite" PlaceHolder="Type activite"></asp:DropDownList>

                            <label class="font-weight-bold">Montant</label><br />
                            <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtMontant" PlaceHolder="Montant" TextMode="Number"></asp:TextBox>


                            <div class="modal-footer">
                                <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterDepense" Text="Ajouter dépense" OnClick="btnAjouterDepense_OnClick"></asp:Button>
                                <asp:Button runat="server" ID="Button1" class="btn btn-default btn-dark btn-group" OnClick="btnFermerModalClick" Text="Fermer" formnovalidate></asp:Button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


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
                                    <SelectionnerUtilisateur:SelectionnerUtilisateur runat="server" ID="selectionnerUtilisateurParticipant" OnPreRecherche="selectionnerUtilisateurParticipant_OnPreRecherche" OnAjouter="selectionnerUtilisateurParticipant_OnAjouter" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnFermerAjouterParticipant" class="btn btn-default btn-dark btn-group" OnClick="btnFermerModalClick" Text="Fermer" formnovalidate></asp:Button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

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
                                <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterActivite" Text="Ajouter activité" OnClick="btnAjouterActiviteClick"></asp:Button>
                                <asp:Button runat="server" ID="btnFermerActivite" class="btn btn-default btn-dark btn-group" OnClick="btnFermerModalClick" Text="Fermer" formnovalidate></asp:Button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <div class=" bg-white text-dark py-3 text-left px-3">

        <h2>Mes expéditions   
            <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterExpedition" Text="AJOUTER UNE EXPÉDITION" OnClick="btnAjouterExpeditionOnclick"></asp:Button>
        </h2>
        <hr class="my-4">

        <asp:Panel runat="server" ID="pnlExpedition" Visible="false">
            <div class="form-group row">
                <div class="col">
                    <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="Button2" Text="ENREGISTRER" OnClick="btnEnregistrerOnclick"></asp:Button>
                    <asp:Button runat="server" class="btn btn-dark font-weight-bold" Text="ANNULER" OnClick="btnToutMasquerClick" formnovalidate></asp:Button>
                </div>
            </div>
            <div class="card">
                <div class="card-header text-uppercase font-weight-bold">
                    <asp:Label runat="server" ID="lblTitrePanneauExpedition" class="font-weight-bold" Text="Ajouter expédition" />
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <div class="col">
                            <label class="font-weight-bold">Titre</label>
                            <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtTitre" PlaceHolder="Titre" required="true" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col">
                            <label class="font-weight-bold">Description</label>
                            <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtDescription" PlaceHolder="Description" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col">
                            <label class="font-weight-bold">Date début</label>
                            <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtDebut" PlaceHolder="Date début" TextMode="Date" required="true" />
                        </div>
                        <div class="col">
                            <label class="font-weight-bold">Date fin</label>
                            <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtFin" PlaceHolder="Date fin" TextMode="Date" required="true" />
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col">
                            <label class="font-weight-bold">Image principale de votre expédition</label>
                            <div class="custom-file">

                                <asp:FileUpload type="file" ID="fichierImage" class="bg-dark text-white" runat="server"></asp:FileUpload>

                            </div>
                        </div>
                        <div class="col">
                            <label class="font-weight-bold">Aperçu</label><br />
                            <asp:Image Style="text-align: left; width: 250px; height: 175px;" alt="Card image cap" ID="imagePrincipale" runat="server" />
                        </div>
                    </div>


                    <div class="form-group row">
                        <div class="col">
                            <a class="btn btn-success font-weight-bold text-white" data-toggle="modal" data-target="#modalAjouterParticipant" formnovalidate>AJOUTER PARTICIPANT</a>

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
                    <div class="form-group row">
                        <div class="col">
                            <a class="btn btn-success font-weight-bold text-white" data-toggle="modal" data-target="#modalAjouterActivite" formnovalidate>AJOUTER ACTIVITÉ</a>
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
                                    <asp:UpdatePanel runat="server" ID="updatePanel1" UpdateMode="Conditional">
                                        <ContentTemplate>
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

                                                            <asp:TextBox runat="server" ID="txtDate" Text='<%# Eval("Date","{0:d}") %>' Visible="False" TextMode="Date" class="form-control bg-dark text-white"></asp:TextBox>
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
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("Prenom").ToString() %>'></asp:Label>
                                                                            <asp:Label runat="server" ID="Label5" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                                                                            ______________________________
                                                                        </div>
                                                                        <div class="col">
                                                                            <asp:Button runat="server" ID="btnPresent" Text="Présent" class="btn btn-success btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="Present" Visible="True" />
                                                                        </div>
                                                                        <div class="col">
                                                                            <asp:Button runat="server" ID="btnAbsent" Text="Absent" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("Id")  %>' CommandName="Absent" Visible="True" />
                                                                        </div>


                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </td>


                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </tbody>
                            </table>
                        </div>
                    </div>


                    <div class="form-group row">
                        <div class="col">
                            <a class="btn btn-success font-weight-bold text-white" data-toggle="modal" data-target="#modalAjouterRepartitionDepense" formnovalidate>AJOUTER LES COÛTS POUR UN TYPE D'ACTIVITÉ</a>
                        </div>
                        <div class="col">
                            <asp:DropDownList runat="server" class="form-control bg-dark text-white " ID="ddlParticipantReset" PlaceHolder="Participant"></asp:DropDownList>
                        </div>

                        <div class="col">
                            <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnInitialiserRepartition" Text="Remettre les dépenses à zéro pour ce participant" OnClick="btnInitialiserRepartition_OnClick"></asp:Button>
                        </div>

                    </div>
                    <div class="form-group row">
                        <div class="col">
                            <asp:PlaceHolder runat="server" ID="placeHolderDepense"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>

                <hr class="my-4">
                <div class="form-group row">
                    <div class="col">
                        <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnEnregistrer" Text="ENREGISTRER" OnClick="btnEnregistrerOnclick"></asp:Button>
                        <asp:Button runat="server" class="btn btn-dark font-weight-bold" Text="ANNULER" OnClick="btnToutMasquerClick" formnovalidate></asp:Button>
                    </div>
                </div>
            </div>

            <asp:Label runat="server" ID="lblId"></asp:Label>
        </asp:Panel>


        <asp:Panel runat="server" ID="pnlListeExpedition">
            <asp:DataList runat="server" ID="listeExpedition" RepeatDirection="Horizontal" RepeatColumns="4" OnItemCommand="listeExpeditionOnItemCommand">
                <ItemTemplate>

                    <div class="card" style="text-align: center;">

                        <div class="card-body">
                            <asp:Image class="card-img-top" src='<%# "images/Expedition/" + Eval("Image") %>' alt="Card image cap" runat="server" Style="text-align: center; width: 200px; height: 200px; border-radius: 50%" />
                            <hr />
                            <h5 class="card-title">
                                <asp:Label runat="server" ID="Label1" Text='<%# Eval("Titre").ToString() %>'></asp:Label></h5>
                            <b>
                                <asp:Label runat="server" ID="lblDebut" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                                au
                            <asp:Label runat="server" ID="lblFin" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label></b>
                            <p class="card-text">

                                <asp:Label runat="server" ID="Label2" Text='<%# Eval("Description").ToString() %>'></asp:Label>
                            </p>
                            <asp:Button runat="server" class="btn btn-success font-weight-bold" Text="MODIFIER" CommandArgument='<%# Eval("Id")  %>' CommandName="Modifier" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:Panel class="alert alert-secondary glyphicon glyphicon-exclamation-sign" role="alert" runat="server" Visible="False" ID="pnlAucuneExpedition">
                Aucune expéditions d'ajouter pour l'instant
            </asp:Panel>
        </asp:Panel>

        <br />
        <h2>Mes recherches de prix de forfaits   
        
        </h2>
        <hr class="my-4">
        <asp:Panel runat="server" ID="pnlScan">
            <div class="form-group row">

                <div class="col">
                    <label class="font-weight-bold">Nom de la recherche</label>
                    <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtNomRecherche" PlaceHolder="Nom de la recherche" required="true" />
                </div>
                <div class="col">
                    <label class="font-weight-bold">Url de la recherche</label>
                    <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtUrl" PlaceHolder="Url" required="true" />
                </div>
            </div>

            <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterRecherchePrix" Text="AJOUTER UNE RECHERCHE" OnClick="btnAjouterRecherchePrix_OnClick"></asp:Button>

            <table class="table table-dark table-hover table-striped">
                <thead>
                    <tr>
                        <th>Nom
                        </th>
                        <th>Type
                        </th>
                        <th>Url
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="repeaterRecherchePrix">
                        <ItemTemplate>
                            <tr>
                                
                                <td><a href="HistoriquePrix.aspx"> <asp:Label runat="server" ID="Label1" Text='<%# Eval("Nom").ToString() %>'></asp:Label></a></td>
                                <td><asp:Label runat="server" ID="Label6" Text='<%# Eval("TypeScan").ToString() %>'></asp:Label></td>
                                <td><asp:Label runat="server" ID="Label7" Text='<%# Eval("UrlScan").ToString() %>'></asp:Label></td>

                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>


    </div>


</asp:Content>
