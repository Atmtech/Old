<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="motPasseOublie">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblJaiOublieMonMotDePasse" Text="J'ai oublié mon mot de passe"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="lblCourrielMotPasseOublie" Text="Entrer le courriel utilisé lors de l'inscription" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCourriel" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnEnvoyerCourriel" Text="Envoyez moi mon mot de passe" CssClass="boutonActionRond"  OnClick="btnEnvoyerCourrielClick"/>
        </div>
    </div>
    <div style="clear: both;"></div>
</asp:Content>
