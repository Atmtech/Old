<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main -->
    <section id="main" class="wrapper">
        <div class="container">

            <div style="position: relative; top: -50px;">

                <asp:LinkButton runat="server" ID="lnkAjouterUneExpedition" Text="Ajouter une expédition" CssClass="special button icon fa-map-marker"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkModifierMesInformations" Text="Modifier mes informations" CssClass="button icon fa-info"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkMesAmis" Text="Mes amis" CssClass="button icon fa-info"></asp:LinkButton>
                <p>
                    <h3>
                        <asp:Label runat="server" ID="lblListeDeMesExpeditions" Text="Liste de mes expéditions"></asp:Label></h3>
                    Vide
                </p>
            </div>

        </div>
    </section>

</asp:Content>
