<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Default1" %>

<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="System.Security.Policy" %>

<%@ Register Src="UserControls/ListeExpedition.ascx" TagName="ListeExpedition" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%">
        <tr>
            <td>Catégorie<br />
                <asp:DropDownList runat="server" ID="ddlCategorie" Width="300" CssClass="dropDownList" />
            </td>
            <td style="text-align: right">Page<br />
                <asp:DropDownList runat="server" ID="DropDownList1" placeholder="Watermark" Width="50" CssClass="dropDownList">
                    <asp:ListItem Text="1"></asp:ListItem>
                    <asp:ListItem Text="2"></asp:ListItem>
                    <asp:ListItem Text="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>

    <uc1:ListeExpedition ID="ListeExpedition" runat="server" />

</asp:Content>
