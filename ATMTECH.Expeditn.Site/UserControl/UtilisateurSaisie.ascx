<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UtilisateurSaisie.ascx.cs" Inherits="ATMTECH.Expeditn.Site.UserControl.UtilisateurSaisie" %>
<div class="form-group row">
    <label class="col-sm-1 col-form-label">Prénom</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtPrenom" placeholder="Prénom"  required="true" />
    </div>
               

</div>
<div class="form-group row">
    <label class="col-sm-1 col-form-label">Nom</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtNom" placeholder="Nom"  required="true" />
    </div>
</div>
<div class="form-group row">
    <label class="col-sm-1 col-form-label">Courriel</label>
    <div class="col-sm-10">
        <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtCourriel" placeholder="email@example.com"  required="true" />
    </div>
</div>
<div class="form-group row">
    <label class="col-sm-1 col-form-label">Mot de passe</label>
    <div class="col-sm-10">
        <asp:TextBox class="form-control  bg-dark text-white" ID="txtPassword" runat="server"  required="true" />
    </div>
</div>
<div class="form-group row">
    <div class="col-sm-10">
        <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnEnregistrer" Text="enregistrer" OnClick="btnEnregistrer_OnClick"></asp:Button>
    </div>
</div>