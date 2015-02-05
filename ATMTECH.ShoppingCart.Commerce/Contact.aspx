<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="InformationClient">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblContacterNous" Text="Contacter-nous"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="lblVotreNom" Text="Votre nom:" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtVotreNom" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblCourrielContacterNous" Text="Courriel" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCourrielContacterNous" runat="server" CssClass="textBox" Width="400px"  TextMode="Email"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblNoTelephoneContacterNous" Text="Numéro de téléphone" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtNoTelephoneContacterNous" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMessageContacterNous" Text="Message" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMessageContacterNous" runat="server" CssClass="textBoxMultiligne" Width="400px" TextMode="MultiLine" Rows="15"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnEnvoyerCommentaire" Text="Envoyer" CssClass="boutonActionRond" Width="400px"></asp:Button>
        </div>
    </div>
     <div style="clear: both;"></div>
</asp:Content>
