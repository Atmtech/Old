<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MotPasseOublie.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.MotPasseOublie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="identification">
        <div class="titre">
            <asp:Label runat="server" ID="lblJaiOublieMonMotDePasse" Text="J'ai oublié mon mot de passe"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="lblCourrielMotPasseOublie" Text="Entrer le courriel utilisé lors de l'inscription"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCourriel" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnEnvoyerCourriel" Text="Envoyez moi mon mot de passe" CssClass="bouton" OnClick="btnEnvoyerCourrielClick" />
        </div>
    </div>
</asp:Content>
