<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifierExpedition.aspx.cs" Inherits="ATMTECH.Expeditn.Site.ModifierExpedition" %>

<%@ Register Src="UserControl/InformationGeneralesExpedition.ascx" TagName="InformationGeneralesExpedition" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Participant.ascx" TagName="Participant" TagPrefix="uc2" %>
<%@ Register Src="UserControl/Activites.ascx" TagName="Activites" TagPrefix="uc3" %>
<%@ Register Src="UserControl/CoutActivites.ascx" TagName="CoutActivites" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb text-uppercase">
            <li class="breadcrumb-item "><a href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="breadcrumb-item active">Modifier l'expédition</li>
        </ol>

        <div class="form-group row">
            <div class="col">
                <uc1:InformationGeneralesExpedition ID="InformationGeneralesExpedition1" runat="server" EstEnAjout="False" />
                
            </div>
            <div class="col">
                <uc2:Participant ID="Participant" runat="server" />
            </div>
        </div>

        <div class="form-group row">
            <div class="col">
                <uc3:Activites ID="activites" runat="server" OnSurAction="activites_OnSurAction" />
            </div>
        </div>
        
        <div class="form-group row">
            <div class="col">
                <uc4:CoutActivites ID="coutActivite" runat="server" />
            </div>
        </div>
        <asp:Label runat="server" ID="lblTest"></asp:Label>
    </div>
</asp:Content>
