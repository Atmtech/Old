<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoviePlayer.aspx.cs" Inherits="ATMTECH.TransfertVideo.MoviePlayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centerPanelAdmin">
        <div style="text-align: center">
            <h2>MOVIE PLAYER</h2>

            <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
            <br /><br />
            <asp:Button runat="server" ID="btnReturn" Text="RETURN TO ADMIN" CssClass="bouton" OnClick="btnReturnClick" />
        </div>

    </div>
</asp:Content>
