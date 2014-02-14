<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="NewTrip.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.NewTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlStep1">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblTitleNewTrip" Text="Étape 1 - Saisir les informations générales"></asp:Label>
        </div>
        <table>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlSite" Libelle="Sélectionner un site"
                    AutoPostBack="True" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Titre de la journée"
                    Width="200px" EstObligatoire="True" />
            </tr>
            <tr>
                <atmtech:DateTextBoxAvance runat="server" ID="txtDateStart" Libelle="Date début" />
            </tr>
        </table>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnAddWayPoint" Text="Étape 2 - Ajouter une position de pêche"
                OnClick="WaypointClick" CssClass="button" />
            <asp:Button runat="server" ID="btnCancel" Text="Annuler" OnClick="CancelClick" CssClass="button" CausesValidation="False" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlStep2" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblTitleSelect" Text="Étape 2 - Sélectionner une position de pêche en double cliquant sur la carte"></asp:Label>
        </div>
        <atmtech:GoogleMap ID="googleMap" runat="server" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlStep3" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="Label1" Text="Étape 3 - Pour la position sélectionné"></asp:Label>
            <asp:Label Text="text" runat="server" ID="lblCurrentWayPoint" />
            /
            <asp:Label Text="text" runat="server" ID="lblMaximumWayPoint" />
        </div>
        <table>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlLure" Libelle="Leurre utilisé" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlTechnique" Libelle="Technique utilisé" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlDeep" Libelle="Profondeur" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlTimeStart" Libelle="Heure de début" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlTimeEnd" Libelle="Heure de fin" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="Latitude"
                    ID="txtLatitude" />
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="X" ID="txtPixelX"
                    Visible="False" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance ID="txtLongitude" runat="server" ModeAffichage="Consultation"
                    Libelle="Longitude" />
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="Y" ID="txtPixelY"
                    Visible="False" />
            </tr>
        </table>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnAddWayPoint2" Text="Étape 2 - Ajouter une position de pêche"
                CssClass="button" OnClick="WaypointClick" />
            <asp:Button runat="server" ID="btnFinish" Text="Terminé" OnClick="ResumeClick" CssClass="button" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlStep4" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblResume" Text="Résumé"></asp:Label>
        </div>
        <atmtech:GoogleMap ID="googleMapResume" runat="server" />
        <div class="toolbar">
            <asp:Button runat="server" ID="btnFinish2" Text="Terminé" OnClick="FinishClick" CssClass="button" />
        </div>
    </asp:Panel>
</asp:Content>
