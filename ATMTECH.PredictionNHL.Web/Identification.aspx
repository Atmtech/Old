<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Identification.aspx.cs" Inherits="ATMTECH.PredictionNHL.Web.Identification" %>
<%@ Register src="UserControl/UtilisateurSaisie.ascx" tagname="UtilisateurSaisie" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-black bg-white py-3 text-left px-3">
        <asp:Panel runat="server" ID="pnlIdentification">
            <h2>Identification</h2>
            <hr class="my-4">
            <div class="form-group row">
                <label class="col-sm-1 col-form-label">Courriel</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtCourriel" placeholder="email@example.com" />
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-1 col-form-label">Mot de passe</label>
                <div class="col-sm-10">
                    <asp:TextBox class="form-control  bg-dark text-white" ID="txtMotPasse" TextMode="Password" runat="server" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnConnecter" Text="SE CONNECTER" OnClick="btnConnecterOnClick"></asp:Button>
                    <asp:Button runat="server" class="btn btn-dark font-weight-bold" ID="btnCreerCompte" Text="CRÉER UN COMPTE" OnClick="btnCreerCompte_OnClick"></asp:Button>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlCreerUtilisateur">
            <h2>Créer un compte</h2>
            <hr class="my-4">
            <uc1:UtilisateurSaisie ID="UtilisateurSaisie1" runat="server" />
        </asp:Panel>
    </div>
</asp:Content>
