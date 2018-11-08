<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compte.aspx.cs" Inherits="ATMTECH.StockGame.Site.Compte" %>

<%@ Register Src="UserControl/UtilisateurSaisie.ascx" TagName="UtilisateurSaisie" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-black bg-white py-3 text-left px-3">
        <ol class="breadcrumb  text-uppercase">
            <li class="breadcrumb-item "><a href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="breadcrumb-item active">Mon compte</li>
        </ol>

        <uc1:UtilisateurSaisie ID="UtilisateurSaisie1" runat="server" />
    </div>
</asp:Content>
