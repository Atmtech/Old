<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.MidiBoardGame.WebSite.Default1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <b>Bonjour,&nbsp;<asp:Label runat="server" ID="lblNomUtilisateur"></asp:Label></b>
    <asp:Button runat="server" ID="btnDeconnecter" Text="Déconnecter" CssClass="boutonAction" OnClick="btnDeconnecterClick" />
    <asp:Button runat="server" ID="btnMonProfile" Text="Mon profile" CssClass="boutonAction" OnClick="btnMonProfileClick" />

    <br />
    <br />
    <table style="width: 100%;">
        <tr>
            <td style="vertical-align: top; padding: 10px 10px 10px 10px;">
                <div style="background-color: white; padding: 10px 10px 10px 10px; height: auto;">
                    <h5 style="text-transform: uppercase"><strong>Présences ce midi</strong></h5>
                    <table style="width: 100%;">
                        <asp:Repeater runat="server" ID="datalistePresence" OnItemCommand="datalistePresenceItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="label1" Text='<%# Eval("Utilisateur.Nom")  %>'></asp:Label></td>
                                    <td>
                                        <asp:Button runat="server" ID="Button1" Text="Retirer" CommandName="Retirer" CommandArgument='<%# Eval("Utilisateur.Id")  %>' CssClass="boutonRouge" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <br />
                    <asp:Button runat="server" ID="btnPresence" Text="Je suis présent ce midi" CssClass="boutonAction" OnClick="btnPresenceClick" />
                </div>
            </td>

            <td style="vertical-align: top; padding: 10px 10px 10px 10px; border-left: solid 1px gray;">

                <div style="background-color: white; padding: 10px 10px 10px 10px; height: 160px;">
                    <h5 style="text-transform: uppercase"><strong>Propositions pour ce midi</strong></h5>
                    <asp:DropDownList runat="server" ID="ddlJeu" CssClass="form-control" />
                    <br />
                    <asp:Button runat="server" ID="btnAjouterJeuMidi" Text="Je veux jouer à ce jeu ce midi" CssClass="boutonAction" OnClick="btnAjouterJeuMidiClick" />
                </div>
            </td>
        </tr>

        <tr>
            <td colspan="2" style="vertical-align: top; padding: 10px 10px 10px 10px;">
                <div style="background-color: white; padding: 10px 10px 10px 10px;">
                    <h5 style="text-transform: uppercase"><strong>Votes en cours pour ce midi</strong></h5>
                    <table style="width: 100%;">
                        <asp:Repeater runat="server" ID="datalisteVote" OnItemCommand="datalisteVoteItemCommand" OnItemDataBound="datalisteVoteItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td style="padding-right: 5px;">
                                        <asp:Button runat="server" ID="btnVoter" Text="Voter" CommandName="Vote" CssClass="boutonAction" />
                                    </td>
                                    <td style="padding-right: 15px;">
                                        <asp:Button runat="server" ID="btnRetirerVote" Text="Retirer mon vote" CommandName="Retirer" CssClass="boutonAction" />
                                    </td>
                                      <td style="padding-right: 15px;">
                                        <asp:Button runat="server" ID="btnEnlever" Text="Supprimer" CommandName="Supprimer" CssClass="boutonAction" />
                                    </td>
                                    <td style="padding-right: 15px; text-align: left;">
                                        <asp:HyperLink runat="server" ID="lnkBoardgameGeek" NavigateUrl='<%# Eval("Jeu.UrlBoardGameGeek")  %>' Text='<%# Eval("Jeu.Nom")  %>' Target="_blank" Font-Bold="True" ForeColor="black" Font-Names="Arial" Font-Italic="False"></asp:HyperLink></td>
                                    <td style="padding-right: 15px; text-align: right;">
                                        <asp:Label runat="server" ID="lblNombreVote" Visible="True"></asp:Label>&nbsp;vote(s)<img src="Images/thumb.png" style="width: 25px; height: 25px;" />

                                        <asp:Label runat="server" ID="lblId" Text='<%# Eval("Id")  %>' Visible="False"></asp:Label>

                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>
