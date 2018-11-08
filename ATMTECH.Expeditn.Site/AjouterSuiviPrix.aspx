<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjouterSuiviPrix.aspx.cs" Inherits="ATMTECH.Expeditn.Site.AjouterSuiviPrix" %>

<%@ Register src="UserControl/SuiviPrix.ascx" tagname="SuiviPrix" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb  text-uppercase">
            <li class="breadcrumb-item "><a href="TableauBord.aspx">Tableau de bord</a></li>
            <li class="breadcrumb-item active">Ajouter un suivi de prix
            </li>
        </ol>
      
        <div class="form-group row">
            <div class="col">
                <uc1:SuiviPrix ID="SuiviPrix1" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
