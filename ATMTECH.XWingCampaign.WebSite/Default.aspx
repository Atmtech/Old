<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.XWingCampaign.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: table; color: wheat; font-weight: bold; padding: 10px 10px 10px 10px;">XWing Campaign aide</div>

    <div style="padding: 10px 10px 10px 10px;">

        <div class="titreVaisseau">
            <asp:Button ID="btnTieFighter" runat="server" Text="Tie Fighter" CssClass="myButton" CommandArgument="1" OnClick="SelectionnerVaisseau" />
            <asp:Button ID="btnTieInterceptor" runat="server" Text="Tie Interceptor" CssClass="myButton" CommandArgument="2" OnClick="SelectionnerVaisseau" />
        </div>

        <div class="statistiqueVaisseau">
            <asp:Label runat="server" ID="lblNomVaisseau"></asp:Label>
            (
            <asp:Label runat="server" ID="lblAttaque" ForeColor="red" Font-Bold="True"></asp:Label><img src="Images/Website/Attaque.png" />
            <asp:Label runat="server" ID="lblDefense" ForeColor="#33CC33" Font-Bold="True"></asp:Label><img src="Images/Website/Defense.png" />
            <asp:Label runat="server" ID="lblCoque" ForeColor="yellow" Font-Bold="True"></asp:Label><img src="Images/Website/Coque.png" />
            <asp:Label runat="server" ID="lblBouclier" ForeColor="Cyan" Font-Bold="True"></asp:Label><img src="Images/Website/bouclier.png" />
            )
        </div>

        <table class="quadrant">
            <tr>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantNW"></asp:PlaceHolder>
                </td>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantN"></asp:PlaceHolder>
                </td>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantNE"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantW"></asp:PlaceHolder>
                </td>
                <td class="celluleQuadrant"></td>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantE"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantSW"></asp:PlaceHolder>
                </td>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantS"></asp:PlaceHolder>
                </td>
                <td class="celluleQuadrant">
                    <asp:PlaceHolder runat="server" ID="quadrantSE"></asp:PlaceHolder>
                </td>
            </tr>
        </table>

        <asp:Panel ID="pnlResultat" runat="server" CssClass="panelResultat" Visible="False">
            <asp:Label runat="server" ID="lblRetour"></asp:Label><br />
            <asp:Button runat="server" ID="btnFermer" CssClass="myButton" Text="Fermer" OnClick="btnFermerClick" />
        </asp:Panel>



    </div>









</asp:Content>

