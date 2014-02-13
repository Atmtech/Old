<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="PlayerInformation.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.PlayerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <atmtech:FenetreDialogue runat="server" ID="windowUpload">
        <atmtech:TitreLabelAvance runat="server" Text="Fichier: "></atmtech:TitreLabelAvance>
        <asp:FileUpload runat="server" ID="fileUpload" />
        <div class="toolbar">
            <atmtech:Bouton runat="server" ID="btnUpdateAvatar" OnClick="UpdateAvatarClick" Text="Modifier mon avatar" />
        </div>
    </atmtech:FenetreDialogue>
    <div class="headerWizard">
        <asp:Label runat="server" ID="titleCustomerInformation" Text="Information du pêcheur"></asp:Label>
    </div>
    <table>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Nom complet: " Enabled="False"
                StyleTextBox="width:400px"></atmtech:TextBoxAvance>
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtLogin" Libelle="Nom d'utilisateur: "
                StyleTextBox="width:400px;font-weight:bold;" Enabled="false"></atmtech:TextBoxAvance>
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtFirstName" Libelle="Prénom: " StyleTextBox="width:400px">
            </atmtech:TextBoxAvance>
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtLastName" Libelle="Nom: " StyleTextBox="width:400px">
            </atmtech:TextBoxAvance>
        </tr>
        <tr>
            <atmtech:TextBoxAvance runat="server" ID="txtEmail" Libelle="Courriel: " StyleTextBox="width:400px">
            </atmtech:TextBoxAvance>
        </tr>
        <tr>
            <td>
                <atmtech:TitreLabelAvance runat="server" ID="lblAvatar" Text="Avatar:"></atmtech:TitreLabelAvance>
            </td>
            <td>
                <asp:Image runat="server" ImageUrl="" ID="imgAvatar" />
                <%--<asp:FileUpload runat="server" ID="fileUpload" />--%>
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlChangePassword" Visible="False">
        <table>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtPassword" Libelle="Mot de passe: " StyleTextBox="width:400px"
                    TextMode="Password"></atmtech:TextBoxAvance>
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtConfirmPassword" Libelle="Confirmation: "
                    StyleTextBox="width:400px" TextMode="Password"></atmtech:TextBoxAvance>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label runat="server" ID="lblCustomerInformationSaved" Text="Enregistrement confirmé"
        Visible="False"></asp:Label>
    <div class="toolbar">
        <asp:Button runat="server" ID="btnSave" OnClick="SavePlayerClick" Text="Enregistrer" CssClass="button" />
        <asp:Button runat="server" ID="btnChangePassword" OnClick="ChangePassword_click" CssClass="button"
            Text="Changer mon mot de passe" />
        <asp:Button runat="server" ID="btnChangeAvatar" OnClick="ChangeAvatarClick" Text="Modifier avatar" CssClass="button"/>
        <asp:Button runat="server" ID="btnStatistic" OnClick="StatisticClick" Text="Statistique" CssClass="button"/>
        <asp:Button runat="server" ID="btnAchievement" OnClick="AchievementClick" Text="Réalisation" CssClass="button"/>
        <asp:Button runat="server" ID="btnSkills" OnClick="SkillsClick" Text="Compétences" CssClass="button"/>
    </div>
</asp:Content>
