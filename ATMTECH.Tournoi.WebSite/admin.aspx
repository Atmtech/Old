<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="ATMTECH.Tournoi.WebSite.admin" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .button1 {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 5px 5px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin-top: 5px;
        }

        .textBox {
            font-size: 30px;
            Margin-top: 0;
            font-weight: bold;
            width: 40px;
            text-align: center;
        }

        .textBoxInvisible {
            font-size: 1px;
            Margin-top: 0;
            border: none;
            width: 1px;
            text-align: center;
        }
        .dropdown {
            font-size: 15px;
            Margin-top: 0;
            font-weight: bold;
            width: 100px;
            text-align: center;
        }
    </style>
    <h1>Administration - Tournoi</h1>
    <asp:Button runat="server" ID="btnAccueil" Text="Accueil" CssClass="button1" OnClick="btnAccueilClick" />
    <br />



    Nombre partie par jour:<br />
    <asp:TextBox runat="server" ID="txtIdNombrePartieParJour" Text="4"></asp:TextBox><br />
    Date départ:<br />
    <asp:TextBox runat="server" ID="txtDateDepart" Text="2017-10-11"></asp:TextBox><br />
    Nombre match avec chacun:<br />
    <asp:TextBox runat="server" ID="txtNombreMatchAvecChacun" Text="2"></asp:TextBox><br />
    <asp:Button runat="server" ID="btnFaireCalendrier" Text="Construire calendrier" OnClick="btnFaireCalendrierClick" CssClass="button1" />

    <h2>Liste des matchs</h2>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button runat="server" ID="btnSaveMatch" Text="Enregistrer les matchs" OnClick="btnSaveMatchClick" CssClass="button1" />
            <asp:Button runat="server" ID="btnRafraichir" Text="Rafraichir" OnClick="btnRafraichirClick" CssClass="button1" />
            <br />
            <br />


            <div style="background-color: rgb(194, 225, 164); width: 170px; margin-bottom: 10px; padding: 10px 10px 10px 10px;">
                <asp:Label runat="server" ID="lblPartieTotalAJouer"></asp:Label>
            </div>
            <asp:GridView ID="GridViewHoraire" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="1000px" AllowSorting="True" OnSorting="TrierGrilleHoraire">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            
                            <asp:TextBox runat="server" ID="txtId" Text='<%#Eval("Id")%>' CssClass="textBoxInvisible"  />
                            <asp:TextBox runat="server" ID="txtIdLocal" Text='<%#Eval("Local.Id")%>'  CssClass="textBoxInvisible"/>
                            <asp:TextBox runat="server" ID="txtIdVisiteur" Text='<%#Eval("Visiteur.Id")%>'  CssClass="textBoxInvisible" />
                            
                            <div style="float: left; width: 50px;">
                                <asp:Image runat="server" ID="imgLocal" ImageUrl='<%#"logo/" + Eval("Local.Id") + ".png"%>' Width="35px" Height="30px" />
                            </div>
                            <div style="float: left; width: 400px;">
                                <asp:Label runat="server" ID="lblLocal" Text='<%#Eval("Local.Nom")%>'></asp:Label>
                            </div>
                            <div style="float: left; font-weight: bold; font-size: 30px;">
                                <asp:TextBox runat="server" ID="txtScoreLocal" Text='<%#Eval("NombreButLocal")%>' CssClass="textBox" />
                            </div>
                            <div style="clear: both;"></div>
                            <div style="float: left; width: 50px;">
                                <asp:Image runat="server" ID="Image1" ImageUrl='<%#"logo/" + Eval("Visiteur.Id") + ".png"%>' Width="35px" Height="30px" />
                            </div>
                            <div style="float: left; width: 400px;">
                                <asp:Label runat="server" ID="Label2" Text='<%#Eval("Visiteur.Nom")%>'></asp:Label>
                            </div>
                            <div style="float: left; font-weight: bold; font-size: 30px;">
                                <asp:TextBox runat="server" ID="txtScoreVisiteur" Text='<%#Eval("NombreButVisiteur")%>' CssClass="textBox" />
                            </div>
                            <div style="float: left; font-size: 16px; font-weight: bold; margin-top: -45px; padding-left: 100px;">
                                
                                <asp:Button runat="server" ID="btnSaveMatch" Text="Enregistrer" OnClick="btnSaveMatchClick" CssClass="button1" />
                                Match #<asp:Label runat="server" ID="Label5" Text='<%# Eval("Id")%>'></asp:Label>
                                <table>
                                  
                                    <tr>
                                        <td>En prolongation</td>
                                        <td><asp:DropDownList runat="server" ID="ddlProlongation" SelectedValue='<%#Eval("PerteEnSurtemps").ToString()%>' CssClass="dropdown">
                                            <asp:ListItem Text="Oui" Value="1" />
                                            <asp:ListItem Text="Non" Value="0" />
                                        </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>Message</td>
                                        <td><asp:TextBox runat="server" ID="txtMessage" Text='<%#Eval("Message")%>' Width="100px" /></td>
                                    </tr>
                                </table>
                              
                            </div>
                            
                            <div style="clear: both;"></div>
                            
                            <hr />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
