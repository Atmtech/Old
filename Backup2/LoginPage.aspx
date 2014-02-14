<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="LoginPage.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <atmtech:Login runat="server" ID="login" Visible="True" />
</asp:Content>
