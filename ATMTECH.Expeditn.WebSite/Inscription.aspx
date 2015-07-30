<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Inscription" %>
<%@ Register src="UserControls/MessageInformation.ascx" tagname="MessageInformation" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    
    

    <section id="one" class="wrapper style1 special">
        <div class="container">
            <header class="major">
                <h2>
                    <asp:Label ID="lblInscrivezVous" runat="server" Text="Inscrivez-vous "></asp:Label>
                </h2>
                <p>
                    <asp:Label ID="lblEntrerVosInformation" runat="server" Text="Entrez vos informations et démarrer votre première planification"></asp:Label>
                </p>
            </header>
            
            <uc1:MessageInformation ID="MessageInformation" runat="server" EstVisible="False" />

            <div class="container 50%">

                <div class="row uniform">
                    <div class="6u 12u$(small)">
                        <asp:TextBox runat="server" ID="txtPrenom" placeholder="Prénom"></asp:TextBox>
                    </div>
                    <div class="6u$ 12u$(small)">
                        <asp:TextBox runat="server" ID="txtNom" placeholder="Nom"></asp:TextBox>
                    </div>
                    <div class="12u$ 12u(small)">
                        <asp:TextBox runat="server" ID="txtCourriel" placeholder="Courriel" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="12u$ 12u$(small)">
                        <asp:TextBox runat="server" ID="txtMotDePasse" placeholder="Mot de passe" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="12u$ 12u$(small)">
                        <asp:TextBox runat="server" ID="txtConfirmationMotDePasse" placeholder="Confirmation" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="12u$">
                        <ul class="actions">
                            <li>
                                <asp:Button runat="server" ID="lnkCreerMonCompte" Text="Créer mon compte" CssClass="special big" OnClick="lnkCreerMonCompteClick"></asp:Button>
                            </li>
                        </ul>
                        <strong>
                            <asp:Label runat="server" ID="lblNousVousEnverronsUnCourriel" Text="N.B.: Nous vous enverrons un courriel pour confirmer votre inscription."></asp:Label>
                        </strong>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>
