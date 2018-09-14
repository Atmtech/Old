<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoriquePrix.aspx.cs" Inherits="ATMTECH.Expeditn.Site.HistoriquePrix" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .progress {
            height: 30px;
            font-size: 15px;
            font-weight: bold;
        }
    </style>

    <div class=" bg-white text-dark py-3 text-left px-3">
        <asp:PlaceHolder runat="server" ID="placeholderHistorique"></asp:PlaceHolder>
    </div>


</asp:Content>

