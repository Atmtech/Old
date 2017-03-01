<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.TransfertVideo.Admin" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="generator" content="Mobirise v2.11, mobirise.com" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:700,400&amp;subset=cyrillic,latin,greek,vietnamese" />
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/animate.css/animate.min.css" />
    <link rel="stylesheet" href="assets/mobirise/css/style.css" />
    <link rel="stylesheet" href="assets/dropdown-menu-plugin/style.css" />
    <link rel="stylesheet" href="assets/mobirise/css/mbr-additional.css" type="text/css" />


</head>
<body>
    <form id="form1" runat="server">





        <asp:Panel runat="server" ID="pnlPasOk" Visible="True">
            <h2 class="mbr-header__text">Authentication</h2>
            <asp:TextBox runat="server" ID="txtPassword" placeholder="Password" class="form-control"></asp:TextBox>
            <asp:Button runat="server" ID="btnValiderPassword" Class="mbr-buttons__btn btn btn-lg btn-danger" OnClick="btnValiderPasswordClick" Text="SIGN IN" />
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlOk" Visible="False">
            <h2 class="mbr-header__text">MOVIE LISTING</h2>
            Filter by group: 
                                 <asp:DropDownList runat="server" ID="ddlGroupe" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupeChanged">
                                     <asp:ListItem>all</asp:ListItem>
                                     <asp:ListItem>100</asp:ListItem>
                                     <asp:ListItem>101</asp:ListItem>
                                 </asp:DropDownList>

            <br />
            Total movie received: <b>
                <asp:Label Text="text" runat="server" ID="lblTotal" /></b>
            <br />
            <br />
            <asp:GridView ID="GridViewMovie" runat="server" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridViewMovie_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Group">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGroupe" Text='<%# Eval("Groupe")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date received">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDateModified" Text='<%# Eval("DateModified")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Students">
                        <ItemTemplate>
                            <li>
                                <asp:Label runat="server" ID="lblEtudiant1" Text='<%# Eval("Etudiant1")  %>'></asp:Label></li>
                            <li>
                                <asp:Label runat="server" ID="lblEtudiant2" Text='<%# Eval("Etudiant2")  %>'></asp:Label></li>
                            <li>
                                <asp:Label runat="server" ID="lblEtudiant3" Text='<%# Eval("Etudiant3")  %>'></asp:Label></li>
                            <li>
                                <asp:Label runat="server" ID="lblEtudiant4" Text='<%# Eval("Etudiant4")  %>'></asp:Label></li>
                            <li>
                                <asp:Label runat="server" ID="lblEtudiant5" Text='<%# Eval("Etudiant5")  %>'></asp:Label></li>
                            <li>
                                <asp:Label runat="server" ID="lblEtudiant6" Text='<%# Eval("Etudiant6")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Movie style">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblStyle" Text='<%# Eval("Style")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Seen">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblVisionnee" Text='<%# Eval("Visionnee")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnVoir" Class="mbr-buttons__btn btn btn-lg btn-danger" Text='View' CommandName="Voir" CommandArgument='<%#Eval("Guid")%>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnVisionnee" Class="mbr-buttons__btn btn btn-lg btn-danger" CommandName="Visionnee" CommandArgument='<%#Eval("Guid")%>' Text="I have seen this movie"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnDownload" Class="mbr-buttons__btn btn btn-lg btn-danger" NavigateUrl='<%# "download.aspx?file=" + Eval("Fichier")%>' Text="Download"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </asp:Panel>


    </form>
</body>
</html>
