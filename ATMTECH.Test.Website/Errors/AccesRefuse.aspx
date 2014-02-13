<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/DefaultMaster.master" AutoEventWireup="true" CodeBehind="AccesRefuse.aspx.cs" Inherits="ATMTECH.Errors.AccesRefuse" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ModuleScripts" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DefaultContent" runat="server">

<center>
    
    <div style="padding:10px 10px 20px 10px; width:95%; background-color:#E5E5E5;border:solid 1px gray;">
    <h2><div style="color:Red;">Vous n'avez pas accès à la page désirée.</div></h2>
    
    <asp:Label runat="server" ID="lblRaisonAccesRefuse">
    </asp:Label>
    
    <br /><br />
    
    <a href="javascript:RedirigerVersAccueil();">Revenir à la page d'accueil</a>
    
    </div>
    
    </center>
    
    
</asp:Content>
