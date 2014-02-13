<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true" CodeBehind="Wall.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.Wall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="barreMenuDiscussion" style="text-align: right; padding-right: 15px;">
        <asp:Button runat="server" CssClass="boutonDiscussion" Text="Publier commentaire" />
    </div>

    <asp:PlaceHolder runat="server" ID="placeHolderDiscussion"></asp:PlaceHolder>


</asp:Content>
