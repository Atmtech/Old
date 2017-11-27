<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Tournoi.WebSite.Default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .button2 {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 4px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            margin-top: 2px;
        }
    </style>


    <div style="width: 100%; text-align: center; text-transform: uppercase; background-color: gray;color:white;">
        <h1>
           SQI:  <asp:Label runat="server" ID="lblNomSaison"></asp:Label></h1>
    </div>
    <div style="width: 48%; padding: 10px 10px 10px 10px; float: left; border-right: solid 1px gray;">
        <h2>Saison régulière - <asp:Label runat="server" ID="lblPartieTotalAJouer"></asp:Label></h2>
        <asp:GridView ID="GridViewPosition" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" AllowSorting="True" OnSorting="TrierGrillePosition" OnRowCommand="GridViewPositionOnRowCommand">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="imgLocal" ImageUrl='<%#"logo/" + Eval("Equipe.Id") + ".png"%>' Width="35px" Height="30px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Equipe.Nom" HeaderText="Équipe" SortExpression="Equipe.Nom" />
                <asp:BoundField DataField="NombrePartieJoue" HeaderText="MJ" SortExpression="NombrePartieJoue" />

                <asp:BoundField DataField="NombreVictoire" HeaderText="V" SortExpression="NombreVictoire" />
                <asp:BoundField DataField="NombreDefaite" HeaderText="D" SortExpression="NombreDefaite" />
                <asp:BoundField DataField="NombreDefaiteEnSurTemps" HeaderText="DP" SortExpression="NombreDefaiteEnSurTemps" />
                <asp:BoundField DataField="NombrePoint" HeaderText="PTS" SortExpression="NombrePoint" />
                <asp:BoundField DataField="NombreButPour" HeaderText="BP" SortExpression="NombreButPour" />
                <asp:BoundField DataField="NombreButContre" HeaderText="BC" SortExpression="NombreButContre" />
                <asp:BoundField DataField="PourcentageVictoire" HeaderText="%PG" SortExpression="PourcentageVictoire" />
                <asp:TemplateField HeaderText="Présence aujourd'hui" Visible="False">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblLocal" Text='<%# (bool)Eval("EstPresentAujourdhui") ? "Présent" : "Absent"%>'></asp:Label></td>
                                <td>
                                    <asp:Button runat="server" ID="btnPresent" Text="Présent" CommandName="Present" CssClass="button2" CommandArgument='<%#Eval("Equipe.Id")%>' /></td>
                                <td>
                                    <asp:Button runat="server" ID="btnAbsent" Text="Absent" CommandName="Absent" CssClass="button2" CommandArgument='<%#Eval("Equipe.Id")%>' /></td>

                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="left" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <hr  />
       
        <div>
            Filtrer:
            <asp:DropDownList runat="server" ID="ddlEquipe" />
            <asp:Button runat="server" ID="btnFiltrer" OnClick="btnFiltrerClick" CssClass="button2" Text="Filtre" />
            <asp:Button runat="server" ID="btnResetFiltre" OnClick="btnResetFiltreClick" CssClass="button2" Text="Annuler filtre" /><br />
            <br />
        </div>
        <asp:GridView ID="GridViewHoraire" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AllowSorting="True" OnSorting="TrierGrilleHoraire">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>

                        <table>

                            <tr>
                                <td style="padding-right: 15px;">
                                    <asp:Image runat="server" ID="imgLocal" ImageUrl='<%#"logo/" + Eval("Local.Id") + ".png"%>' Width="35px" Height="30px" /></td>
                                <td style="width: 400px;">
                                    <asp:Label runat="server" ID="lblLocal" Text='<%#Eval("Local.Nom")%>'></asp:Label></td>
                                <td style="font-size: 25px; font-weight: bold; padding-left: 15px; padding-right: 15px;">
                                    <asp:Label runat="server" ID="Label1" Text='<%# Eval("NombreButLocal")%>'></asp:Label></td>
                                <th rowspan="2" style="text-align: left;">
                                    <asp:Label runat="server" Text='<%# (Eval("Gagnant.Id").ToString() != "0") ? (Eval("PerteEnSurtemps").ToString() == "1" ? "FINAL / PROLONGATION" : "FINAL") : "<div style=color:gray;font-size:12px;>Entre 12:00 et 13:00 RC.05</div>" %>'></asp:Label>
                                    <asp:Label runat="server" ID="Label4" Text='<%# Eval("Message")%>'></asp:Label>
                                    
                                    <div style="font-size: 10px; font-weight: bold;">
                                        Match #<asp:Label runat="server" ID="Label5" Text='<%# Eval("Id")%>'></asp:Label>
                                        <asp:Label runat="server" ID="Label6" Text='<%# Eval("Date","{0:dddd dd MMMM , yyyy}")%>'></asp:Label>
                                    </div>

                                </th>
                            </tr>
                            <tr>
                                <td style="padding-right: 15px;">
                                    <asp:Image runat="server" ID="Image1" ImageUrl='<%#"logo/" + Eval("Visiteur.Id") + ".png"%>' Width="35px" Height="30px" /></td>
                                <td style="width: 400px;">
                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("Visiteur.Nom")%>'></asp:Label></td>
                                <td style="font-size: 25px; font-weight: bold; padding-left: 15px; padding-right: 15px;">
                                    <asp:Label runat="server" ID="Label3" Text='<%# Eval("NombreButVisiteur")%>'></asp:Label></td>

                            </tr>

                        </table>


                      
                        <div style="font-size: 12px; font-weight: bold;">
                        </div>



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

    </div>
    <div style="width: 48%; padding: 10px 10px 10px 10px; float: left;">
        <h2>Série éliminatoire</h2>
     
    </div>
    <div style="clear: left;"></div>
</asp:Content>

