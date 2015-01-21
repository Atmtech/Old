<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="StockTransaction.aspx.cs" Inherits="ATMTECH.Administration.StockTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="title">
        Consulter l'inventaire d'un produit avec les transactions associées
    </div>
    <table style="width: 750px;">
        <tr>
            <td>Choisir un inventaire:            
            </td>
            <td>
                <atmtech:ComboBox runat="server" ID="ddlStock" AutoPostBack="True" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnGenerate" Text="Générer" OnClick="btnGenerateClick" CssClass="button"  />
            </td>
        </tr>
    </table>




    <asp:PlaceHolder runat="server" ID="placeHtml"></asp:PlaceHolder>
</asp:Content>
