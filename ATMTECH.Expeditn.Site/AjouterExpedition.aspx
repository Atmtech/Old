<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjouterExpedition.aspx.cs" Inherits="ATMTECH.Expeditn.Site.AjouterExpedition" %>

<%@ Register TagPrefix="uc1" TagName="InformationGeneralesExpedition" Src="~/UserControl/InformationGeneralesExpedition.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb  text-uppercase">
            <li class="breadcrumb-item "><a href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="breadcrumb-item active">Ajouter une expédition</li>
        </ol>
      
        <div class="form-group row">
            <div class="col">
                <uc1:InformationGeneralesExpedition ID="InformationGeneralesExpedition1" runat="server" EstEnAjout="True"  />
            </div>
        </div>
    </div>
</asp:Content>
