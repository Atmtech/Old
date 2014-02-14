<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Site.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.Site" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Lat:<asp:TextBox runat="server" ID="latitude"></asp:TextBox>
    Long:
    <asp:TextBox runat="server" ID="longitude"></asp:TextBox>
    <asp:Button runat="server" ID="btnSet" Text="Set" OnClick="btnSetClick" CssClass="button" />
    <atmtech:GoogleMap ID="googleMapResume" runat="server" Zoom="12" />
</asp:Content>
