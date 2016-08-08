<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AjouterExpeditionEtape1.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.AjouterExpeditionEtape1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main" class="wrapper">
        <div class="container">
            <h2>
                <asp:Label ID="lblEtape1CreationNouvelleExpedition" runat="server" Text="Définir la nouvelle expédition"></asp:Label>
            </h2>
            <table>
                <tr>
                    <td>
                        <div class="container 50%">
                            <asp:TextBox runat="server" ID="txtNomExpedition" placeholder="Nom de l'expédition" CssClass="TextBox"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtDebutExpedition" placeholder="Date de début"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtFinExpedition" placeholder="Date de fin"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtBudgetEstimeExpedition" placeholder="Budget estimé"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddlEstPrive">
                                <asp:ListItem Value="0">Expédition public</asp:ListItem>
                                <asp:ListItem Value="1">Expédition privée</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="container 50%">
                            <asp:TextBox runat="server" ID="txtLatitude" placeholder="Latitude"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtLongitude" placeholder="Longitude"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtRegionExpedition" placeholder="Region"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddlPays" placeholder="Pays"></asp:DropDownList>
                            <asp:TextBox runat="server" ID="txtVilleExpedition" placeholder="Ville"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:LinkButton runat="server" ID="lnkPasserEtape2CreationExpedition" Text="Ajouter des participants" CssClass="button icon fa-save" OnClick="lnkPasserEtape2CreationExpeditionClick"></asp:LinkButton>
        </div>
    </section>
</asp:Content>
