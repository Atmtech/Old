<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.Default1" %>

<%@ Register Src="UserControls/GoogleMap.ascx" TagName="GoogleMap" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlHomeUnlogged" Visible="False">
        <div style="position: relative; left: -20px; top: -22px; width: 100%;">
            <img src="Images/Home/HomeImage2.jpg" width="102%" height="200px" /></div>
        <b>Bienvenue sur Fishing@work</b>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 50%" valign="top">
                    <br />
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                    Ipsum has been the industry's standard dummy text ever since the 1500s, when an
                    unknown printer took a galley of type and scrambled it to make a type specimen book.
                    It has survived not only five centuries, but also the leap into electronic typesetting,
                    remaining essentially unchanged. It was popularised in the 1960s with the release
                    of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop
                    publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                </td>
                <td style="width: 50%" valign="top">
                    <img src="Images/Main/bulletFish.png" align="absmiddle" />
                    <a href="CreatePlayer.aspx">Inscrivez vous !!!</a>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlCurrentTrip" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblTitleHomeInformation" Text="La journée de pêche d'aujourd'hui"></asp:Label>
        </div>
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Nom" ModeAffichage="Consultation">
                </atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtSite" Libelle="Site" ModeAffichage="Consultation">
                </atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtTotalPlayer" Libelle="Total de pêcheur sur le site actuellement"
                    ModeAffichage="Consultation"></atmtech:TextBoxAvance>
            </tr>
        </table>
        <uc1:GoogleMap ID="googleMap" runat="server" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNoTrip" Visible="False">
        <asp:Label runat="server" ID="lblNoTripAvailable" Text="Aucune journée de pêche planifiée pour aujourd'hui. Vous pouvez en planifier une en créant une journée de pêche dans le menu ou sur le lien suivant."></asp:Label>
        <br /><br />
        <asp:Button runat="server" OnClick="CreateTripClick" Text="Créer une journée de pêche" CssClass="button"></asp:Button>
    </asp:Panel>
</asp:Content>
