<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Photos.aspx.cs" Inherits="ATMTECH.BillardLoretteville.Website.Photos" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <atmtech:Content ID="ContentDefault" runat="server" />
    <center>
        <atmtech:MediaGallery runat="server" ID="MediaGallery" />
    </center>
</asp:Content>
