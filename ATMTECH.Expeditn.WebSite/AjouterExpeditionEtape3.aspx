<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AjouterExpeditionEtape3.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.AjouterExpeditionEtape3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main" class="wrapper">
        <div class="container">

            <h2>
                <asp:Label ID="lblEtape3CreationNouvelleEtape" runat="server" Text="Ajouter des activités"></asp:Label>
            </h2>

            <table>
                <tr>
                    <td>
                        <div class="container 50%">
                            <asp:TextBox runat="server" ID="txtNomEtape" placeholder="Nom de l'étape" CssClass="TextBox"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtDebutEtape" placeholder="Date de début"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtFinEtape" placeholder="Date de fin"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddlVehicule" placeholder="Vehicule"></asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="container 50%">
                            <asp:TextBox runat="server" ID="txtDistance" placeholder="Distance KM / MILES"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:LinkButton runat="server" ID="lnkAjouterActiviteExpedition" Text="Ajouter cette activité" CssClass="button icon fa-plus" OnClick="lnkAjouterActiviteExpeditionClick"></asp:LinkButton>

            <h2>
                <asp:Label ID="lblListeActivite" runat="server" Text="Liste des activités"></asp:Label>
            </h2>

            <br />
            <asp:LinkButton runat="server" ID="lnkPasserEtape4CreationEtape" Text="Ajouter des repas" CssClass="button icon fa-save" OnClick="lnkPasserEtape4CreationExpeditionClick"></asp:LinkButton>
        </div>
    </section>
</asp:Content>
