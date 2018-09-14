<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Admin" %>

<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container">
            Admin
            
             <asp:Button runat="server" ID="btnGenererSql" OnClick="btnGenererSqlClick" Text="Generer modele" class="mbr-buttons__btn btn btn-lg btn-danger" />
            <asp:TextBox ID="txtSql" runat="server" Height="282px" Width="937px" TextMode="MultiLine" class="form-control"></asp:TextBox>
            <asp:Button runat="server" ID="btnRecalculerChamps" OnClick="btnRecalculerChampsClick" />

        </div>
    </section>

</asp:Content>
