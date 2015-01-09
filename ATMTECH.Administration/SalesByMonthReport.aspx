<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SalesByMonthReport.aspx.cs" Inherits="ATMTECH.Administration.SalesByMonth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Rapport des commandes par mois
    </div>
    <table>
        <tr>
            <td>Enterprise:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="cboEnterprise" />
            </td>
        </tr>
        <tr>
            <td>Date début:</td>
            <td>
                <atmtech:DatePicker runat="server" ID="txtDateStart" />
            </td>
        </tr>
        <tr>
            <td>Date fin: </td>
            <td>
                <atmtech:DatePicker runat="server" ID="txtDateEnd" />
            </td>
        </tr>
    </table>
    <div style="background-color: lightgray; border: solid 1px gray; padding: 5px 5px 5px 5px;">
        <asp:Button runat="server" ID="btnGenerate" OnClick="GenerateClick" Text="Générer le rapport"
            CausesValidation="True" CssClass="button" />
    </div>
</asp:Content>
