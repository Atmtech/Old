<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Identification.aspx.cs" Inherits="ATMTECH.Pass.WebSite.Identification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panneau">
        <h1>Identification</h1>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblCourriel" CssClass="form-control-label" Text="Courriel"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtCourriel" CssClass="form-control" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblMotDePasse" CssClass="form-control-label" Text="Mot de passe"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="txtMotPasse" CssClass="form-control" TextMode="Password" /></td>
            </tr>

        </table>




        <br />
        <asp:Button runat="server" ID="btnConnecte" Text="Identifiez-vous" CssClass="boutonAction" OnClick="btnConnecteClick" />
    </div>
  

</asp:Content>
