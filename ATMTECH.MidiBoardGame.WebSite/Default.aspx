<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.MidiBoardGame.WebSite.Default1" %>


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
        <asp:Label runat="server" ID="Label5" CssClass="form-control-label" Text="Surnom sur BoardGameGeek"></asp:Label>
        <asp:TextBox runat="server" ID="txtNickNameBoardGameGeek" CssClass="form-control" />

        <asp:Label runat="server" ID="Label2" CssClass="form-control-label" Text="Courriel"></asp:Label>
        <asp:TextBox runat="server" ID="txtCourrielCreer" CssClass="form-control" TextMode="Email" />
        <asp:Label runat="server" ID="Label3" CssClass="form-control-label" Text="Mot de passe"></asp:Label>
        <asp:TextBox runat="server" ID="txtMotDePasseCreer" CssClass="form-control" />
        <br />
        <asp:Button runat="server" ID="btnCreer" Text="Créer profile" CssClass="btn btn-info " OnClick="btnCreerClick" />


    </asp:Panel>
    <asp:Panel runat="server" ID="pnlConnecte" Visible="False">
        <b>Bonjour,
            <asp:Label runat="server" ID="lblNomUtilisateur"></asp:Label></b>
        <asp:Button runat="server" ID="btnDeconnecter" Text="Déconnecter" CssClass="btn btn-black" OnClick="btnDeconnecterClick" />
        <asp:Button runat="server" ID="btnImporterMaListeJeu" Text="Importer ma liste de jeu" CssClass="btn btn-black" OnClick="btnImporterMaListeJeuClick" />

        <asp:Panel runat="server" ID="pnlImporterListeJeu" Visible="False" Style="background-color: white; padding: 10px 10px 10px 10px;">
            <h2>Ma liste de jeux</h2>
            <asp:DataList runat="server" ID="datalistListeJeuBoardGameGeek" RepeatLayout="Table" RepeatColumns="2" OnItemCommand="datalistListeJeuBoardGameGeekItemCommand">
                <ItemTemplate>
                    <asp:Button runat="server" Visible='<%# Eval("Utilisateur") == null   %>' ID="btnAjouter" Text="Ajouter" CommandName="Ajouter" CommandArgument='<%# Eval("Nom")  %>' Style="font-size: 12px; font-weight: bold; background-color: rgb(54, 180, 54); color: white; border: none; border-radius: 20px; padding-top: 2px; padding-bottom: 2px; padding-left: 10px; padding-right: 10px; text-decoration: none; display: inline-block; white-space: nowrap; cursor: Pointer; font-family: Raleway;" />
                    <asp:Button runat="server" Visible='<%# Eval("Utilisateur") != null   %>' ID="Button1" Text="Retirer" CommandName="Retirer" CommandArgument='<%# Eval("Nom")  %>' Style="font-size: 12px; font-weight: bold; background-color: red; color: white; border: none; border-radius: 20px; padding-top: 2px; padding-bottom: 2px; padding-left: 10px; padding-right: 10px; text-decoration: none; display: inline-block; white-space: nowrap; cursor: Pointer; font-family: Raleway;" />
                    <asp:Label runat="server" ID="lblNomJeu" Text='<%# Eval("Nom")  %>'></asp:Label>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <br />
        <hr />
        <h3><strong>Présence ce midi</strong></h3>

        <asp:DataList runat="server" ID="datalistePresence">
            <ItemTemplate>
                <asp:Label runat="server" ID="label1" Text='<%# Eval("Utilisateur.Nom")  %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:Button runat="server" ID="btnPresence" Text="Je suis présent ce midi" CssClass="btn btn-black" OnClick="btnPresenceClick" />

        <h3><strong>Proposition pour ce midi</strong></h3>
            <asp:Label runat="server" ID="lblJeu" CssClass="form-control-label" Text="Liste de jeu"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlJeu" CssClass="form-control" />
         <asp:Button runat="server" ID="btnAjouterJeuMidi" Text="Ajouter un jeu pour ce Proposition" CssClass="btn btn-info " OnClick="btnAjouterJeuMidiClick" />
        <asp:DataList runat="server" ID="datalisteVote" OnItemCommand="datalisteVoteItemCommand" OnItemDataBound="datalisteVoteItemDataBound">
            <ItemTemplate>

                <asp:Button runat="server" ID="btnVoter" Text="Voter" CommandName="Vote" CssClass="btn btn-black" />
                <asp:Button runat="server" ID="btnRetirerVote" Text="Retirer mon vote" CommandName="Retirer" CssClass="btn btn-black" />
                <b>
                    <asp:HyperLink runat="server" ID="lnkBoardgameGeek" NavigateUrl='<%# Eval("Jeu.UrlBoardGameGeek")  %>' Text='<%# Eval("Jeu.Nom")  %>' Target="_blank" Font-Bold="True" ForeColor="black" Font-Names="Arial" Font-Italic="False"></asp:HyperLink>
                    <asp:Label runat="server" ID="lblIdMidi" Text='<%# Eval("Id")  %>' Visible="False"></asp:Label>
                    |
                    <asp:Label runat="server" ID="lblNombreVote" Visible="True"></asp:Label>
                    vote(s)
                    <img src="Images/thumb.png" style="width: 25px; height: 25px;" />
                </b>
            </ItemTemplate>
        </asp:DataList>
        



    </asp:Panel>

</asp:Content>
