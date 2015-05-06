<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="erreur">
        <asp:Panel runat="server" ID="pnlError" CssClass="errorMessage" Visible="False">
            <table>
                <tr>
                    <td style="vertical-align: top;">
                        <img src="Images/WebSite/error-icon.png" style="width: 40px; height: 40px; vertical-align: middle;" alt="Erreur" /></td>
                    <td style="font-weight: bold;">
                        <div style="font-size: 25px; padding-bottom: 10px;">
                            <asp:Label runat="server" ID="lblOupsUneErreurEstSurvenue" Text="Oups ... Une erreur est survenue !"></asp:Label><br />
                        </div>
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlSuccess" CssClass="successMessage" BorderStyle="Solid" Visible="False">
            <table>
                <tr>
                    <td style="vertical-align: top;">
                        <img src="Images/WebSite/success-icon.png" style="width: 40px; height: 40px; vertical-align: middle;" alt="Succès" /></td>
                    <td style="font-weight: bold;">
                        <div style="font-size: 25px; padding-bottom: 10px;">
                            <asp:Label runat="server" ID="lblCestUnSucces" Text="C'est un succès ..."></asp:Label><br />
                        </div>
                        <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

    <asp:Button runat="server" ID="btnRetourAccueil" Text="Retourner à l'accueil" OnClick="btnRetourAccueilClick" CssClass="bouton" />

</asp:Content>
