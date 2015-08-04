﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Identification.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Identification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="one" class="wrapper style1 special">
        <div class="container">
            <header class="major">
                <h2>
                    <asp:Label ID="lblIdentifiezVous" runat="server" Text="Vous n'êtes plus bien loin ..."></asp:Label>
                </h2>
                <p>
                    <asp:Label ID="lblIdentifiezVousAvecVotreCompte" runat="server" Text="Identifiez vous avec votre compte Expedit'n"></asp:Label>
                </p>
            </header>

            <div class="container 50%">

              

                    <asp:TextBox runat="server" ID="txtNomUtilisateur" placeholder="Courriel" TextMode="Email"></asp:TextBox>
                <br/>
                    <asp:TextBox runat="server" ID="txtMotPasse" placeholder="Mot de passe" TextMode="Password"></asp:TextBox>
                <br/>
                    <div class="12u$">
                        <asp:Button runat="server" ID="lnkIdentifiezVous" Text="Se connecter" CssClass="special big" OnClick="lnkIdentifiezVousClick"></asp:Button><br />
                        <br />
                        <asp:Button runat="server" ID="lnkJAiOublieMonMotDePasse" Text="J'ai oublié mon mot de passe" CssClass="special big" OnClick="lnkIdentifiezVousClick"></asp:Button>

                    </div>
              
            </div>
    </section>

</asp:Content>
