<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SalesByOrderInformation.aspx.cs" Inherits="ATMTECH.Administration.SalesByOrderInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Rapports des ventes par imputation
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
            <td>Date début:<atmtech:DatePicker runat="server" ID="txtDateStart" />
            </td>
        </tr>
        <tr>
            <td>Date fin: 
                <atmtech:DatePicker runat="server" ID="txtDateEnd" />
            </td>
            
        </tr>
    </table>
    <div style="background-color: lightgray; border: solid 1px gray; padding: 5px 5px 5px 5px;">
        <asp:Button runat="server" ID="btnGenerate" OnClick="GenerateClick" Text="Générer le rapport"
            CausesValidation="True" CssClass="button" />
    </div>
</asp:Content>
