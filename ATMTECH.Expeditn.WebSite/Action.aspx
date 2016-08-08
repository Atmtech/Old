<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Main -->
    <section id="main" class="wrapper">
        <div class="container">

            <div style="position: relative; top: -50px;">
                <asp:LinkButton runat="server" ID="lnkAjouterUneExpedition" Text="Ajouter une expédition" CssClass="special button icon fa-map-marker" OnClick="lnkAjouterUneExpeditionClick"></asp:LinkButton>
                <%--<asp:LinkButton runat="server" ID="lnkModifierUneExpedition" Text="Modifier une expédition" CssClass="special button icon fa-map-marker" OnClick="lnkModifierUneExpeditionClick" Visible="false"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkModifierMesInformations" Text="Modifier mes informations" CssClass="button icon fa-info"  Visible="false"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkMesAmis" Text="Mes amis" CssClass="button icon fa-info"  Visible="false"></asp:LinkButton>--%>
            </div>

        </div>
    </section>
</asp:Content>
