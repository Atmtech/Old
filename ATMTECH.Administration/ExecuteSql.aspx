<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ExecuteSql.aspx.cs" Inherits="ATMTECH.Administration.ExecuteSql" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Exécuter sur SQL
    </div>
    <asp:TextBox runat="server" ID="txtSql" TextMode="MultiLine" Width="100%"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="btnExecuteSql" OnClick="btnExecuteSqlClick" Text="Executer" CssClass="button" />
    <div style="overflow:scroll;">
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    </div>
</asp:Content>
