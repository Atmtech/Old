<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container">
            <h2 class="header2">
                <asp:Label runat="server" ID="lblMesInformations" Text="Mes informations"></asp:Label></h2>

            <div style="float: left; width: 50%">

                <div class="libelleChampsEditable">
                    <asp:Label ID="lblPrenom" runat="server" Text="Prénom"></asp:Label>
                </div>
                <asp:TextBox runat="server" ID="txtFirstName" placeholder="Prénom" CssClass="controlEditable"></asp:TextBox>
                <div class="libelleChampsEditable">
                    <asp:Label ID="lblLibelleNom" runat="server" Text="Nom"></asp:Label>
                </div>
                <asp:TextBox runat="server" ID="txtLastName" placeholder="Nom" CssClass="controlEditable"></asp:TextBox>
                <div class="libelleChampsEditable">
                    <asp:Label ID="lblMotPasse" runat="server" Text="Mot de passe"></asp:Label>
                </div>
                <asp:TextBox runat="server" ID="txtPassword" placeholder="Mot de passe" CssClass="controlEditable"></asp:TextBox>
                <div class="libelleChampsEditable">
                    <asp:Label ID="lblCourriel" runat="server" Text="Courriel"></asp:Label>
                </div>
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Courriel" CssClass="controlEditable"></asp:TextBox>
            </div>
            <div style="float: left; width: 50%; padding-left: 25px;">
                <asp:Image runat="server" ID="imgUtilisateur" Style="border-radius: 50%; width: 150px; height: 150px;" /><br />

                <%--    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
                                    <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="mp4,avi,wmv,mpg" OnClientUploadComplete="ClientUploadComplete" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" />--%>


                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server" class="multi"  CssClass="controlEditable"/>
                <br/>
                <asp:LinkButton runat="server" ID="lnkChangerImageProfile" Text="Changer l'image de mon profile" class="mbr-buttons__btn btn btn-standard" OnClick="lnkChangerImageClick"></asp:LinkButton>
            </div>
            <br />
            <asp:LinkButton runat="server" ID="lnkEnregistrerUtilisateur" Text="Enregistrer" class="mbr-buttons__btn btn btn-standard" OnClick="lnkEnregistrerUtilisateurClick"></asp:LinkButton>
        </div>
    </section>
</asp:Content>
