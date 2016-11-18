<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ExecuteSql.aspx.cs" Inherits="ATMTECH.MidiBoardGame.WebSite.ExecuteSql" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Exécuter sur SQL
    </div>
    <asp:TextBox runat="server" ID="txtSql" TextMode="MultiLine" Width="100%" Rows="10"></asp:TextBox>
    <div style="margin-top: 10px;">
    <asp:Button runat="server" ID="btnExecuteSql" OnClick="btnExecuteSqlClick" Text="Executer" CssClass="bouton" />
        </div>
    <div style="overflow:scroll;">
        <asp:Label runat="server" ID="lblResult"></asp:Label>
    </div>
</asp:Content>
