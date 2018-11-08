<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InformationGeneralesExpedition.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.InformationGeneralesExpedition" %>
<style>
   
</style>
<div class="card">
    <div class="card-header text-uppercase font-weight-bold bg-color">
        <asp:Label runat="server" ID="lblTitrePanneauExpedition" class="font-weight-bold" Text="Informations générales" />
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
                <asp:TextBox runat="server" class="form-control bg-dark text-white form_datetime" ID="txtDebut" PlaceHolder="Date début" required="true" autocomplete="off"/>
            </div>
            <div class="col">
                <label class="font-weight-bold">Date fin</label>
                <asp:TextBox runat="server" class="form-control bg-dark text-white form_datetime" ID="txtFin" PlaceHolder="Date fin" required="true" autocomplete="off" />
            </div>
        </div>

        <asp:Panel runat="server" ID="pnlAjouterImageExpedition" Visible="True">
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
        </asp:Panel>

        <div class="form-group row">
            <div class="col">
                <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnEnregistrer" Text="ENREGISTRER" OnClick="btnEnregistrer_OnClick"></asp:Button>
                <asp:Button runat="server" class="btn btn-danger font-weight-bold" ID="btnSupprimer" Text="SUPPRIMER" OnClick="btnSupprimer_OnClick"></asp:Button>
            </div>
        </div>
    </div>
</div>
