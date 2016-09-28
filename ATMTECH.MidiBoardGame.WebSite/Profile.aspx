<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ATMTECH.MidiBoardGame.WebSite.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3><strong>Information sur votre profil</strong></h3>
    <asp:Label runat="server" ID="Label1" CssClass="form-control-label" Text="Nom"></asp:Label>
    <asp:TextBox runat="server" ID="txtNom" CssClass="form-control" />
    <asp:Label runat="server" ID="Label5" CssClass="form-control-label" Text="Surnom sur BoardGameGeek"></asp:Label>
    <asp:TextBox runat="server" ID="txtNickNameBoardGameGeek" CssClass="form-control" />
    <asp:Label runat="server" ID="lblAffichageNickName"></asp:Label>
    

    <asp:Label runat="server" ID="Label2" CssClass="form-control-label" Text="Courriel"></asp:Label>
    <asp:TextBox runat="server" ID="txtCourriel" CssClass="form-control" TextMode="Email" Enabled="False"/>
    
    <asp:Label runat="server" ID="lblGravatar" CssClass="form-control-label" Text="Votre utilisateur Gravatar"></asp:Label>
    <asp:TextBox runat="server" ID="txtGravatar" CssClass="form-control" TextMode="Email" Enabled="True"/>
    

    
    <br />
    <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer" CssClass="boutonAction" OnClick="btnEnregistrerClick" />

    <h3>Ma liste de jeux</h3>
    <div style="background-color: white; font-size: 12px; font-weight: bold; letter-spacing: 2px; padding: 10px 10px 10px 10px;">
        <asp:DataList runat="server" ID="datalistListeJeuBoardGameGeek" RepeatLayout="Table" RepeatColumns="2" OnItemCommand="datalistListeJeuBoardGameGeekItemCommand">
            <ItemTemplate>
                <asp:Button runat="server" Visible='<%# Eval("Utilisateur") == null   %>' ID="btnAjouter" Text="Ajouter" CommandName="Ajouter" CommandArgument='<%# Eval("Nom")  %>' CssClass="boutonVert" />
                <asp:Button runat="server" Visible='<%# Eval("Utilisateur") != null   %>' ID="Button1" Text="Retirer" CommandName="Retirer" CommandArgument='<%# Eval("Nom")  %>' CssClass="boutonRouge" />
                <asp:Label runat="server" ID="lblNomJeu" Text='<%# Eval("Nom")  %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <br/>
    <asp:Button runat="server" ID="btnRevenirAccueil" Text="Revenir a l'accueil" CssClass="boutonAction" OnClick="btnRevenirAccueilClick" />
</asp:Content>
