<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoutActivites.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.CoutActivites" %>

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
                            <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAjouterDepense" Text="AJOUTER DÉPENSE" OnClick="btnAjouterDepense_OnClick"></asp:Button>
                            <asp:Button runat="server" ID="btnFermerModal" class="btn btn-default btn-dark btn-group" OnClick="btnFermerModal_OnClick" Text="Fermer" formnovalidate></asp:Button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>


<div class="card">
    <div class="card-header text-uppercase font-weight-bold">
        <asp:Label runat="server" ID="lblTitrePanneauExpedition" class="font-weight-bold" Text="LES COÛTS POUR UN TYPE D'ACTIVITÉ" />
    </div>
    <div class="card-body">
        <div class="form-group row">
            <div class="col">
                <a class="btn btn-success font-weight-bold text-white" data-toggle="modal" data-target="#modalAjouterRepartitionDepense" formnovalidate>AJOUTER LES COÛTS POUR UN TYPE D'ACTIVITÉ</a>
            </div>
            <div class="col">
                <asp:DropDownList runat="server" class="form-control bg-dark text-white " ID="ddlParticipantReset" PlaceHolder="Participant"></asp:DropDownList>
            </div>

            <div class="col">
                <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnInitialiserRepartition" Text="REMETTRE DÉPENSES À ZÉRO POUR LE PARTICIPANT SELECTIONNÉ" OnClick="btnInitialiserRepartition_OnClick"></asp:Button>
            </div>

        </div>
        <div class="form-group row">
            <div class="col">
                <asp:PlaceHolder runat="server" ID="placeHolderDepense"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</div>