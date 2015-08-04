<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
           
            <asp:PlaceHolder runat="server" ID="placeHolderErreur"></asp:PlaceHolder>
            <div class="container 50%">
                 
                <div class="row uniform">
                 <asp:Label runat="server" ID="lblEstObligatoire" Text="* Les champs encadrés en vert sont obligatoires."></asp:Label>   
                    <div class="6u 12u$(small)">
                        <asp:TextBox runat="server" ID="txtPrenom" placeholder="Prénom" style="border: solid 2px green;"></asp:TextBox>
                    </div>
                    <div class="6u$ 12u$(small)">
                        <asp:TextBox runat="server" ID="txtNom" placeholder="Nom" style="border: solid 2px green;"></asp:TextBox>
                    </div>
                    <div class="12u$ 12u(small)">
                        <asp:TextBox runat="server" ID="txtCourriel" placeholder="Courriel" TextMode="Email" style="border: solid 2px green;"></asp:TextBox>
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
