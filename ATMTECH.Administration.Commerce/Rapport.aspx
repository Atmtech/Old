<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Rapport.aspx.cs" Inherits="ATMTECH.Administration.Commerce.Rapport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titrePage">
        Rapport
    </div>
    <asp:Panel runat="server" ID="pnlRapportAvecDate" Visible="False">
        <table>
            <tr>
                <td>Date début:</td>
                <td>
                    <atmtech:DatePicker runat="server" ID="txtDateDepart" />
                </td>
            </tr>
            <tr>
                <td>Date fin: </td>
                <td>
                    <atmtech:DatePicker runat="server" ID="txtDateFin" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlRapportUneCommande" Visible="False">
        Numéro de commande:
        <asp:TextBox runat="server" ID="txtNoCommande"></asp:TextBox>
    </asp:Panel>
    <asp:Button runat="server" ID="btnGenerer" OnClick="btnGenererClick" Text="Générer" CssClass="bouton" />
</asp:Content>
