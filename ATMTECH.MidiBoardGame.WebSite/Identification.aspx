<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Identification.aspx.cs" Inherits="ATMTECH.MidiBoardGame.WebSite.Identification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h3><strong>Identifiez-vous</strong></h3>

        <asp:Label runat="server" ID="lblCourriel" CssClass="form-control-label" Text="Courriel"></asp:Label>
        <asp:TextBox runat="server" ID="txtCourriel" CssClass="form-control" />
        <asp:Label runat="server" ID="lblMotDePasse" CssClass="form-control-label" Text="Mot de passe"></asp:Label>
        <asp:TextBox runat="server" ID="txtMotPasse" CssClass="form-control" TextMode="Password" />
        <br />
        <asp:Button runat="server" ID="btnConnecte" Text="Identifiez-vous" CssClass="boutonAction" OnClick="btnConnecteClick" />

        <br />
        <br />
        <h3><strong>Creer un compte</strong></h3>
        <asp:Label runat="server" ID="Label1" CssClass="form-control-label" Text="Nom"></asp:Label>
        <asp:TextBox runat="server" ID="txtNomCreer" CssClass="form-control" />
        <asp:Label runat="server" ID="Label5" CssClass="form-control-label" Text="Surnom sur BoardGameGeek"></asp:Label>
        <asp:TextBox runat="server" ID="txtNickNameBoardGameGeek" CssClass="form-control" />

        <asp:Label runat="server" ID="Label2" CssClass="form-control-label" Text="Courriel"></asp:Label>
        <asp:TextBox runat="server" ID="txtCourrielCreer" CssClass="form-control" TextMode="Email" />
        <asp:Label runat="server" ID="Label3" CssClass="form-control-label" Text="Mot de passe"></asp:Label>
        <asp:TextBox runat="server" ID="txtMotDePasseCreer" CssClass="form-control" />
        <br />
        <asp:Button runat="server" ID="btnCreer" Text="Créer profile" CssClass="boutonAction" OnClick="btnCreerClick" />
</asp:Content>
