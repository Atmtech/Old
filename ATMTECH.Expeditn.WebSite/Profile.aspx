<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main" class="wrapper">

        <div class="container">
            <h2>
                <asp:Label runat="server" ID="lblMesInformations" Text="Mes informations"></asp:Label></h2>

            <div style="float: left; width: 50%">
                <asp:TextBox runat="server" ID="txtFirstName" placeholder="Prénom"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtLastName" placeholder="Nom"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtPassword" placeholder="Mot de passe"></asp:TextBox>
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Courriel"></asp:TextBox>
            </div>
            <div style="float: left; width: 50%; padding-left: 25px;">
                <asp:Image runat="server" ID="imgUtilisateur" Style="border-radius: 50%; width: 150px; height: 150px;" /><br />
                
                     <%--    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
                                    <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="mp4,avi,wmv,mpg" OnClientUploadComplete="ClientUploadComplete" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" />--%>

                

                <asp:FileUpload ID="FileUpload1" runat="server" class="multi" />
                <asp:LinkButton runat="server" ID="lnkChangerImage" Text="Changer l'image" CssClass="button icon fa-save" OnClick="lnkChangerImageClick"></asp:LinkButton>
            </div>
            <br />
            <asp:LinkButton runat="server" ID="lnkEnregistrerUtilisateur" Text="Enregistrer" CssClass="button icon fa-save" OnClick="lnkEnregistrerUtilisateurClick"></asp:LinkButton>
        </div>
    </section>
</asp:Content>
