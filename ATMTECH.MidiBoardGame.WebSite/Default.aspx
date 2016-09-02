<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.MidiBoardGame.WebSite.Default1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlDeConnecte" Visible="True">
        <h3><strong>Identifiez-vous</strong></h3>

        <asp:Label runat="server" ID="lblCourriel" CssClass="form-control-label" Text="Courriel"></asp:Label>
        <asp:TextBox runat="server" ID="txtCourriel" CssClass="form-control" />
        <asp:Label runat="server" ID="lblMotDePasse" CssClass="form-control-label" Text="Mot de passe"></asp:Label>
        <asp:TextBox runat="server" ID="txtMotPasse" CssClass="form-control" TextMode="Password" />
        <br />
        <asp:Button runat="server" ID="btnConnecte" Text="Identifiez-vous" CssClass="btn btn-info " OnClick="btnConnecteClick" />

        <br />
        <br />
        <h3><strong>Creer un compte</strong></h3>
        <asp:Label runat="server" ID="Label1" CssClass="form-control-label" Text="Nom"></asp:Label>
        <asp:TextBox runat="server" ID="txtNomCreer" CssClass="form-control" />
        <asp:Label runat="server" ID="Label2" CssClass="form-control-label" Text="Courriel"></asp:Label>
        <asp:TextBox runat="server" ID="txtCourrielCreer" CssClass="form-control" TextMode="Email" />
        <asp:Label runat="server" ID="Label3" CssClass="form-control-label" Text="Mot de passe"></asp:Label>
        <asp:TextBox runat="server" ID="txtMotDePasseCreer" CssClass="form-control" />
        <br />
        <asp:Button runat="server" ID="btnCreer" Text="Créer profile" CssClass="btn btn-info " OnClick="btnCreerClick" />


    </asp:Panel>
    <asp:Panel runat="server" ID="pnlConnecte" Visible="False">
        <b>Bonjour,
            <asp:Label runat="server" ID="lblNomUtilisateur"></asp:Label></b> <asp:Button runat="server" ID="btnDeconnecter" Text="Déconnecter"  CssClass="btn btn-black" OnClick="btnDeconnecterClick" />
        <br />
        <hr />
        <h3><strong>Proposition pour ce midi</strong></h3>
        <hr />
        <p>
        </p>
        <p>
            <asp:DataList runat="server" ID="datalisteVote" OnItemCommand="datalisteVoteItemCommand" OnItemDataBound="datalisteVoteItemDataBound" >
                <ItemTemplate>
                    
                    <asp:Button runat="server" ID="btnVoter" Text="Voter" CommandName="Vote" CssClass="btn btn-black" />
                    <asp:Button runat="server" ID="btnRetirerVote" Text="Retirer mon vote" CommandName="Retirer" CssClass="btn btn-black" />
                    <%--<asp:Button runat="server" ID="btnSupprimer" Text="Supprimer" CommandName="Supprimer" CssClass="btn btn-danger" />--%>
                    <b>
                        <asp:HyperLink runat="server" id="lnkBoardgameGeek" NavigateUrl='<%# Eval("Jeu.UrlBoardGameGeek")  %>' Text='<%# Eval("Jeu.Nom")  %>' Target="_blank" Font-Bold="True"  ForeColor="black" Font-Names="Arial" Font-Italic="False"></asp:HyperLink>

                        
                    <asp:Label runat="server" ID="lblIdMidi" Text='<%# Eval("Id")  %>' Visible="False"></asp:Label> |
                    <asp:Label runat="server" ID="lblNombreVote" Visible="True"></asp:Label> vote(s) <img src="Images/thumb.png" style="width: 25px; height: 25px;" />
                    </b>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <br />

            <asp:Label runat="server" ID="lblJeu" CssClass="form-control-label" Text="Liste de jeu"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlJeu" CssClass="form-control" />
        </p>
        <br />
        <asp:Button runat="server" ID="btnAjouterJeuMidi" Text="Ajouter un jeu pour ce midi" CssClass="btn btn-info " OnClick="btnAjouterJeuMidiClick" />
        <br />
        <br />
        <hr />
        <h3><strong>Ajouter un jeu à la liste</strong></h3>
        <hr />
        <asp:Label runat="server" ID="lblNom" CssClass="form-control-label alert-form" Text="Nom du jeu"></asp:Label>
        <asp:TextBox runat="server" ID="txtNomJeu" CssClass="form-control"></asp:TextBox><br />
         <asp:Label runat="server" ID="Label4" CssClass="form-control-label" Text="Url boardgameGeek"></asp:Label>
         <asp:TextBox runat="server" ID="txtUrl" CssClass="form-control"></asp:TextBox><br />
        <asp:Button runat="server" ID="btnAjouterJeu" Text="Ajouter un jeu à la liste" CssClass="btn btn-info " OnClick="btnAjouterJeuClick" />
    </asp:Panel>

</asp:Content>
