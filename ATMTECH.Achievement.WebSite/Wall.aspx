<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true" CodeBehind="Wall.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.Wall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="barreMenuDiscussion" style="text-align: right; padding-right: 15px;">
        <asp:Button ID="btnEcrireMessageSurLeMur" runat="server" CssClass="boutonDiscussion" Text="Écrire un message" OnClick="btnEcrireMessageSurLeMurClick" />
    </div>

    <div style="padding: 10px 10px 10px 10px;">
        <asp:Panel ID="pnlCommentaire" runat="server" Style="background-color: white; border-radius: 10px; text-align: left; padding: 20px 20px 20px 20px;" Visible="False">
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtMessageMur" Width="100%" placeholder="Message" Rows="5"></asp:TextBox>
            <br />
            <asp:Button ID="btnPublierMessageSurLeMur" runat="server" CssClass="boutonDiscussion" Text="Publier le message" OnClick="btnPublierMessageSurLeMurClick" />
        </asp:Panel>
    </div>


    <asp:Panel runat="server" ID="pnlDiscussion" Style='padding: 10px 10px 10px 10px;'>

        <asp:DataList runat="server" ID="datalistDiscussion" OnItemDataBound="ItemDataBoundDataListDiscussion" OnItemCommand="ItemCommandDiscussionClick" Width="100%">
            <ItemTemplate>

                <table style='width: 100%'>
                    <tr>
                        <td style='vertical-align: top; padding-right: 15px; width: 45px;'>
                            <img src='../images/User/moose.jpg' class='imageDiscussionMur' /></td>
                        <td>
                            <div class='bubbleLeft'>
                                <div style='padding: 15px 15px 15px 15px; min-height: 40px; text-align: left;'>
                                    <div class='titreUtilisateurDiscussionMur'>
                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("Utilisateur.FirstNameLastName")%>'></asp:Label>
                                        a dit:
                                    </div>
                                    <div class='titreTempsPosteDiscussionMur'>
                                        Il y a
                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("DateCreated")%>'></asp:Label>
                                    </div>
                                    <div class='texteDiscussionMur'>
                                        <asp:Label runat="server" ID="lblIdent" Text='<%#Eval("Description")%>'></asp:Label>
                                    </div>

                                    <asp:Button ID="Button1" runat="server" CssClass="boutonDiscussion" Text="Commenter" CommandName="OuvrirPanneauCommentaire" />
                                    <asp:Button ID="Button2" runat="server" CssClass="boutonDiscussion" Text="J'aime" CommandName="JaimeMessage" CommandArgument='<%#Eval("Id")%>' />

                                    <asp:Panel ID="pnlCommenter" runat="server" Visible="False" Style="margin-top: 10px; margin-bottom: 10px; padding: 10px 10px 10px 10px; background-color: whitesmoke; border-radius: 10px; text-align: left;">
                                        <asp:TextBox runat="server" ID="txtCommentaire" PlaceHolder="Commentaire" TextMode="MultiLine" Width="100%" Rows="5"></asp:TextBox>
                                        <asp:Button ID="Button3" runat="server" CssClass="boutonDiscussion" Text="Publier commentaire" CommandName="PublierCommentaire" CommandArgument='<%#Eval("Id")%>' />
                                    </asp:Panel>

                                    <asp:DataList runat="server" ID="dataListDiscussionReponse" Width="100%" OnItemCommand="ItemCommandDiscussionReponseClick">
                                        <ItemTemplate>
                                            <table style='width: 100%'>
                                                <tr>
                                                    <td>
                                                        <div class='bubbleRight'>
                                                            <div style='padding: 15px 15px 15px 15px; min-height: 40px; text-align: left;'>
                                                                <div class='titreUtilisateurDiscussionMur'>
                                                                    <asp:Label runat="server" ID="Label4" Text='<%#Eval("Utilisateur.FirstNameLastName")%>'></asp:Label>
                                                                    a dit:
                                                                </div>
                                                                <div class='titreTempsPosteDiscussionMur'>
                                                                    Il y a
                                                                <asp:Label runat="server" ID="Label5" Text='<%#Eval("DateCreated")%>'></asp:Label>
                                                                </div>
                                                                <div class='texteDiscussionMur'>
                                                                    <asp:Label runat="server" ID="Label3" Text='<%#Eval("Description")%>'></asp:Label>
                                                                </div>
                                                                <asp:Button ID="Button2" runat="server" CssClass="boutonDiscussion" Text="J'aime" CommandName="JaimeCommentaire" CommandArgument='<%#Eval("Id")%>' />
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style='width: 45px;'>
                                                        <div style='vertical-align: top; margin-left: 15px;'>
                                                            <img src='../images/User/moose.jpg' class='imageDiscussionMur' />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>

            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
</asp:Content>
