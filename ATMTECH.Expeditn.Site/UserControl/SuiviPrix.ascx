<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SuiviPrix.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.SuiviPrix" %>
<style>
    .progress {
        height: 30px;
        font-size: 15px;
        font-weight: bold;
    }

    .styleToolTipCustom {
        width: 105px;
        border: solid 2px green;
        background-color: lightsteelblue;
        border-radius: 70%;
        text-align: center;
        font-family: verdana;
        font-weight: bold
    }
</style>


<div class="card">
    <div class="card-header text-uppercase font-weight-bold">
        <asp:Label runat="server" ID="lblTitrePanneau" class="font-weight-bold" Text="Informations générales" />
    </div>
    <div class="card-body">
        <div class="form-group row">
            <div class="col">
                <label class="font-weight-bold">Nom</label>
                <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtNom" PlaceHolder="Nom" required="true" />
            </div>
            <div class="col">
                <label class="font-weight-bold">Date début</label>
                <asp:TextBox runat="server" class="form-control bg-dark text-white form_datetime" ID="txtDebut" PlaceHolder="Date début" required="true"  AutoCompleteType="none"/>
            </div>
            <div class="col">
                <label class="font-weight-bold">Type d'application pour le suivi</label>
                <asp:DropDownList runat="server" class="form-control bg-dark text-white" ID="ddlTypeSuiviPrix" PlaceHolder="Type" required="true">
                    <asp:ListItem>Expedia</asp:ListItem>

                </asp:DropDownList>
            </div>

        </div>

        <div class="form-group row">
            <div class="col">
                <label class="font-weight-bold">Url pour le suivi du prix</label>
                <asp:TextBox runat="server" class="form-control bg-dark text-white" ID="txtUrlSuiviPrix" PlaceHolder="url" required="true" />
            </div>
        </div>

        <div class="form-group row">
            <div class="col">
                <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnEnregistrer" Text="ENREGISTRER" OnClick="btnEnregistrer_OnClick"></asp:Button>
                <asp:Button runat="server" class="btn btn-danger font-weight-bold" ID="btnSupprimer" Text="SUPPRIMER" OnClick="btnSupprimer_OnClick"></asp:Button>
            </div>
        </div>
    </div>
</div>
<br />
<div class="card">
    <div class="card-header text-uppercase font-weight-bold">
        <asp:Label runat="server" ID="Label1" class="font-weight-bold" Text="Suivi des prix dans le temps" />
    </div>
    <div class="card-body">
        <div class="form-group row">
            <div class="col">
                <asp:PlaceHolder runat="server" ID="placeholderHistorique"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</div>


<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>
