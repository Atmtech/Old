<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Banner -->
    <section id="banner">
        <h2><asp:Label runat="server" ID="lblMessageBienvenueEntete" Text="Bonjour. Voici expedit'n."></asp:Label></h2>
        <p><asp:Label runat="server" ID="lblMessageBienvenueSousEntete" Text="La planification d'expédition simple, efficace et connecté sur votre monde."></asp:Label>
        </p>
        <ul class="actions">
            <li>
                <asp:HyperLink runat="server" ID="lnkPlanifierExpedition" Text="Planifier une expédition
                    dededede" NavigateUrl="Default.aspx" CssClass="button big"></asp:HyperLink>
            </li>
        </ul>
    </section>


</asp:Content>
