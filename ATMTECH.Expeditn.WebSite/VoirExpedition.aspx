<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="VoirExpedition.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.VoirExpedition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="text-align: center; padding-top: 10px;">
        <div style="font-weight: bold; font-size: 22px;">
            <asp:Label runat="server" ID="lblNom"></asp:Label>
        </div>


        <div style="font-size: 15px;">
            <asp:Label runat="server" ID="lblDateDebutListe"></asp:Label>
            <i class="fa fa-hand-o-right"></i>
            <asp:Label runat="server" ID="lblDateFinListe"></asp:Label>
            <i class="fa fa-user"></i>
            <asp:Label runat="server" ID="lblChefListe"></asp:Label>
        </div>

    </div>

    <section id="main" class="wrapper">
    </section>
</asp:Content>
