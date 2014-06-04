<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href='http://fonts.googleapis.com/css?family=Indie+Flower' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'>
    <link href="SiteDenonceTonGros.css" rel="stylesheet" />
</head>

<body style="">
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery-ui.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery.jqprint.0.3.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/Utilitaires.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Javascript/jquery.print-preview.js") %>"></script>

    <%-- Envoyer true à la fonction GererExpiration pour l'affichage du temps restant en bas de page. --%>
    <script type="text/javascript">
        $(function () {
            InitialiserExpiration(20, '<%=ResolveUrl("~/Errors/SessionTimeout.htm")%>', false);
            $("#lnkImprimer").click(function () {
                $('#impression').jqprint();
                return false;
            });
        });
    </script>
    <form id="form1" runat="server">
        <div class="titre">


            <img src="Images/DEnonceTonGros.png" style="width: 500px; height: 90px;" />


        </div>

        <div class="menu">
            <div style="padding: 10px 10px 10px 10px; font-weight: bold; color: white; font-size: 12px; text-transform: uppercase;">
                <asp:Button runat="server" ID="btnAjouter" Text="Dénonce ton gros" CssClass="button" OnClick="btnAjouterClick" />
                <asp:Button runat="server" ID="btnCherche" Text="Cherche ton gros" CssClass="button" OnClick="btnChercheClick" />
                 <a href="http:\\www.va-chier.com"><img src="Images/bullet.png" /> </a>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlAjouter" CssClass="panneauMenu" Visible="False">
            Dénonce ton gros<br />
            <br />
            Ton gros:
            <asp:TextBox runat="server" ID="txtMerdeux"></asp:TextBox>
            Insulte:
            <asp:DropDownList runat="server" ID="ddlInsulte"></asp:DropDownList>
            <asp:Button runat="server" ID="btnEmmerder" Text="Ajouter" CssClass="button" OnClick="btnEmmerderClick" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlCherche" CssClass="panneauMenu" Visible="False">
            Fouille pour ton gros<br />
            <br />
            <asp:TextBox runat="server" ID="txtChercher"></asp:TextBox>
            <asp:Button runat="server" ID="btnChercher" Text="Chercher" CssClass="button" OnClick="btnChercherClick" />
        </asp:Panel>
        <%--  <asp:Panel runat="server" ID="pnlAjouterCelebre" CssClass="panneauMenu" Visible="False"></asp:Panel>--%>

        <div class="merdeDuMoment">
            <i>"<asp:Label runat="server" ID="lblMerdeDuMoment"></asp:Label>"</i> - <sup>un gros tas le
            <asp:Label runat="server" ID="lblMerdeDuMomentDate"></asp:Label></sup>
        </div>
        <div>
            <div class="liste">
                <div style="padding: 10px 10px 10px 10px;">
                    <h1>Le top 10 des gros tas</h1>
                    <asp:DataList runat="server" ID="datalistTop" OnItemCommand="datalistTopItemCommandClick">
                        <ItemTemplate>
                            <div class="top20">
                                <table>
                                    <tr>
                                        <td style="width: 10px;vertical-align: top;">
                                            <asp:Label runat="server" ID="lblNumber" Text='<%#Container.ItemIndex + 1  %>'></asp:Label>.
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblInsulte" Text='<%#Eval("Insulte.Description")%>'></asp:Label>
                                        </td>
                                        <td style="width: 30px;vertical-align: top;">
                                            <asp:Label runat="server" ID="lblJaime" Text='<%#"(" + Eval("JaimeTaMerde") + ")"%>' CssClass="compteEmmerdeur"></asp:Label>

                                        </td>

                                    </tr>
                                </table>


                            </div>
                        </ItemTemplate>
                        <%-- <AlternatingItemTemplate>
                            <div style="background-color: rgb(192, 192, 183);" class="top20">
                                <asp:Label runat="server" ID="lblNumber" Text='<%#Container.ItemIndex + 1  %>' ForeColor="Maroon"></asp:Label>.
                            <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description")%>'></asp:Label>
                                <asp:Label runat="server" ID="lblInsulte" Text='<%#Eval("Insulte.Description")%>'></asp:Label>
                                <asp:Label runat="server" ID="lblJaime" Text='<%#"(" + Eval("JaimeTaMerde") + ")"%>' CssClass="compteEmmerdeur"></asp:Label>
                            </div>
                        </AlternatingItemTemplate>--%>
                        <FooterTemplate>
                            <asp:Label ID="lblEmpty" Text="Aucune merde importante à affichier bande de merdeux" runat="server"
                                Visible='<%#bool.Parse((datalistTop.Items.Count==0).ToString())%>'>
                            </asp:Label>
                        </FooterTemplate>
                    </asp:DataList>
                    <h1>Liste des pays avec le plus de gros</h1>
                    <asp:DataList runat="server" ID="dataListPays">
                        <ItemTemplate>
                            <div style="font-size: 12px; font-weight: bold;">
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label runat="server" ID="lblNumber" Text='<%#Container.ItemIndex + 1  %>' ForeColor="Maroon"></asp:Label>.</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("CountryName")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <h1>Liste des villes pleine d'obèse</h1>
                    <asp:DataList runat="server" ID="dataListVille">
                        <ItemTemplate>
                            <div style="font-size: 12px; font-weight: bold;">
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label runat="server" ID="lblNumber" Text='<%#Container.ItemIndex + 1  %>' ForeColor="Maroon"></asp:Label>.</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("City")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div class="vachier" style="">
                <div style="padding: 10px 10px 10px 10px;">
                    <asp:DropDownList runat="server" ID="ddlListePage" AutoPostBack="True" OnSelectedIndexChanged="ddlListePageSelectedIndexChanged" Visible="False">
                        <asp:ListItem>0</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList runat="server" ID="ddlNombreParPage" AutoPostBack="True" Visible="False">
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>

                    <div style="float: left; width: 30%;">
                        <h1>Les dernières gros tas</h1>

                    </div>

                    <div style="float: left; width: 70%; text-align: right;">
                        <h1>(Total de gros:
                            <asp:Label runat="server" ID="lblTotalMarde"></asp:Label>)</h1>
                    </div>
                    <div style="clear: both; height: 10px;"></div>

                    <div class="listeMerdeux">

                        <asp:Panel runat="server" ID="pnlRecherche" Visible="False">
                            Vous avez recherché ce gros:
                            <asp:Label runat="server" ID="lblRecherche" CssClass="libelleRecherche"></asp:Label>
                            <asp:Button runat="server" ID="btnAnnulerRecherche" CssClass="button" Text="Annuler recherche de merde" OnClick="btnAnnulerRechercheClick" />
                        </asp:Panel>

                        <asp:Repeater runat="server" ID="datalistMerde" OnItemCommand="datalistMerdeItemCommandClick">
                            <HeaderTemplate>
                                <table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img src="Images/bulletDenonceTonGros.png" /></td>
                                    <td>
                                        <div style="margin-right: 10px;">
                                            <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description")%>'></asp:Label>
                                            <asp:Label runat="server" ID="lblInsulte" Text='<%#Eval("Insulte.Description")%>'></asp:Label>
                                            <div class="datePoste">
                                                Posté le
                                            <asp:Label runat="server" ID="lblDate" Text='<%#Eval("DateCreated")%>'></asp:Label>
                                                (<asp:Label runat="server" ID="lblCity" Text='<%#Eval("City")%>'></asp:Label>,
                                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("Region")%>'></asp:Label>
                                                <asp:Label runat="server" ID="Label1" Text='<%#Eval("CountryName")%>'></asp:Label>)
                                            </div>
                                        </div>
                                    </td>
                                    <td style="width: 120px; padding-bottom: 10px;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/likeDEnonceTonGros.png" Width="20px" Height="20px" CommandName="JaimeTaMerde" CommandArgument='<%#Eval("Id")%>' AlternateText="J'aime ta merde" />
                                        <asp:Label runat="server" ID="lblJaimeTaMerde" Text='<%#Eval("JaimeTaMerde")%>'></asp:Label>
                                        Dénoncé(s)
                                    </td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                    <br />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
