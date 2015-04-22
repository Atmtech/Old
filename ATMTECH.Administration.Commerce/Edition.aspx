<%@ Page Title="" Language="C#" MasterPageFile="Default.Master" AutoEventWireup="true"
    CodeBehind="Edition.aspx.cs" Inherits="ATMTECH.Administration.Commerce.DataEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlSaveDone" Visible="False">
        <div style="border: solid 1px black; color: green; padding: 10px 10px 10px 10px; background-color: white; margin-bottom: 5px;">
            <asp:Label runat="server" ID="lblMessage" Text="Enregistrement effectué avec succès"></asp:Label>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlEdit" Visible="False" Style="margin-bottom: 10px; margin-left: 10px; border: Gray solid 2px; background-color: bisque; padding: 10px 10px 10px 10px; border-radius: 25px;">


        <div style="font-size: 11px; margin-bottom: 10px;">
            <asp:PlaceHolder runat="server" ID="pnlControl"></asp:PlaceHolder>
        </div>
        <div style="background-color: lightgray; border: solid 1px gray; padding: 5px 5px 5px 15px; border-radius: 25px;">
            <asp:Button runat="server" ID="btnSave" Text="Enregistrer" OnClick="SaveClick" CausesValidation="False"
                CssClass="bouton" />
            <asp:Button runat="server" ID="btnAnnuler" Text="Annuler" OnClick="CancelClick" CausesValidation="False"
                CssClass="bouton" />
        </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="pnlPilotage">
        <div class="titrePage">
            Pilotage des données ::
        <asp:Label runat="server" ID="lblTitle"></asp:Label>
        </div>
        <div>
            <asp:Panel runat="server" ID="pnlheader">
                <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                    <legend><b>Critère du filtre</b></legend>
                    <asp:Panel runat="server" ID="pnlEnterprise" Visible="False">
                        <asp:DropDownList runat="server" ID="cboSelectionEntreprise" Width="400px" />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSearch" Visible="True">
                        <table cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtSearch" placeholder="Entrer votre filtre (Vide pour tout)" Width="400px" /></td>
                                <td style="padding-left: 10px;">
                                    <asp:Button runat="server" ID="btnSearch" OnClick="SearchClick" Text="Filtrer"
                                        CssClass="bouton" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                        Nombre d'éléments trouvés: <b><asp:Label runat="server" ID="lblNombreElementTrouve" Text=""></asp:Label></b>
                    </asp:Panel>
                </fieldset>
            </asp:Panel>
            <br />
            <fieldset style="padding: 7px; border-radius: 5px; -moz-border-radius: 5px;">
                <legend><b>Liste des données obtenues par le filtre</b></legend>
                <div style="overflow: scroll;">
                    <div style="margin-bottom: 10px;">
                        <asp:Button runat="server" ID="btnAdd" OnClick="AddClick" Text="Ajouter une nouvelle donnée" CausesValidation="False"
                            CssClass="bouton" />
                    </div>
                    <asp:GridView ID="grdData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        AllowPaging="True" AutoGenerateColumns="False" PageSize="10" OnRowCommand="RowCommandClick"
                        OnPageIndexChanging="PageIndexChanging" Font-Size="12px" EmptyDataText="Aucune données ..." OnRowDataBound="RowDataBound">
                        <Columns>
                            <asp:ButtonField CommandName="Inactive" ImageUrl="Images/supprimer.gif" Text="Supprimer"
                                CausesValidation="False" ButtonType="Image" />
                            <asp:ButtonField ImageUrl="Images/edition.png" CommandName="Edition" Text="Edition"
                                CausesValidation="False" ButtonType="Image" />
                            <asp:ButtonField ImageUrl="Images/Copy.png" CommandName="Copie" Text="Copie" CausesValidation="False"
                                ButtonType="Image" />
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        </Columns>
                        <FooterStyle BackColor="GoldenRod" Font-Bold="True" ForeColor="White"/>
                        <HeaderStyle BackColor="GoldenRod" Font-Bold="True" ForeColor="White" Font-Size="15px" />
                        <PagerSettings Position="TopAndBottom" />
                        <PagerStyle BackColor="GoldenRod" ForeColor="White" Font-Bold="True" Font-Size="15px" HorizontalAlign="Left" />

                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        <AlternatingRowStyle BackColor="#FFE1E1E1" ForeColor="#284775" />
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
