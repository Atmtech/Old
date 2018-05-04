<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.GestionMultimedia.Twiggy.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        @import url(http://fonts.googleapis.com/css?family=Pacifico);
        @import url(http://fonts.googleapis.com/css?family=Montserrat);

        body {
            margin: 0 0 0 0;
            font-family: Montserrat;
        }

        html {
            background: url(images/photomain.jpg) no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .textBox {
            background-color: gray;
            color: white;
            padding: 4px 4px 4px 4px;
            border: solid 1px rgb(53, 53, 53);
            width: 100%;
        }

        textarea {
            background-color: gray;
            color: white;
            padding: 4px 4px 4px 4px;
            border: solid 1px rgb(53, 53, 53);
            width: 100%;
        }

        .centerPanel {
            margin-top: 100px;
            width: 500px;
            margin: 0 auto;
            -webkit-border-radius: 15;
            -moz-border-radius: 15;
            border-radius: 15px;
            border: solid #426d87 4px;
            background-color: rgb(43, 43, 43);
            color: white;
            padding: 5px 25px 15px 15px;
        }

        .bouton {
            background: #3498db;
            background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
            background-image: -moz-linear-gradient(top, #3498db, #2980b9);
            background-image: -ms-linear-gradient(top, #3498db, #2980b9);
            background-image: -o-linear-gradient(top, #3498db, #2980b9);
            background-image: linear-gradient(to bottom, #3498db, #2980b9);
            -webkit-border-radius: 15;
            -moz-border-radius: 15;
            border-radius: 15px;
            font-family: Arial;
            color: #ffffff;
            font-size: 14px;
            padding: 5px 20px 5px 20px;
            border: solid #426d87 4px;
            text-decoration: none;
            cursor: pointer;
        }

            .bouton:hover {
                background: #3cb0fd;
                background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
                background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
                background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
                background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
                background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
                text-decoration: none;
            }

        .header {
            font-family: Montserrat;
            font-size: 30px;
            background-color: black;
            width: 97%;
            height: 100px;
            color: white;
            padding-top: 15px;
            padding-left: 40px;
            text-align: center;
        }

        .label {
            padding-top: 10px;
            padding-bottom: 10px;
            color: aliceblue;
            font-size: 15px;
        }

        ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
            color: lightblue;
            opacity: 1; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: lightblue;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: lightblue;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <h2 class="header">ENGLISH CLASS</h2>
        
        <asp:Panel runat="server" ID="pnlPasOk" Visible="True" class="centerPanel">
            <h2 class="mbr-header__text">Authentication</h2>
            <asp:TextBox runat="server" ID="txtPassword" placeholder="Password" class="textBox" ></asp:TextBox><br/><br/>
            <asp:Button runat="server" ID="btnValiderPassword" Class="bouton" OnClick="btnValiderPasswordClick" Text="SIGN IN" />
        </asp:Panel>
        

        <asp:Panel runat="server" ID="pnlOk" class="centerPanel" style="width: 90%;">
            <h2>ALL VIDEO RECEIVED</h2>
            <asp:GridView ID="GridViewMovie" runat="server" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Bold="True"  OnRowCommand="GridViewMovieOnRowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Group">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGroupe" Text='<%# Eval("NoGroupe")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date received">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDateModified" Text='<%# Eval("DateCreation")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Students">
                        <ItemTemplate>

                            <asp:Label runat="server" ID="lblEtudiant1" Text='<%# Eval("Etudiants")  %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Movie style">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblStyle" Text='<%# Eval("Style")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="URL">
                        <ItemTemplate>
                            <a href='<%# Eval("UrlMedia")  %>' target="_blank">
                                <asp:Label runat="server" ID="lblVisionnee" Text='<%# Eval("UrlMedia")  %>'></asp:Label></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Class="bouton" CommandName="Supprimer" CommandArgument='<%#Eval("Id")%>' Text="Delete"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                    <%--  <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnVisionnee" Class="mbr-buttons__btn btn btn-lg btn-danger" CommandName="Visionnee" CommandArgument='<%#Eval("Id")%>' Text="I have seen this movie"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

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
