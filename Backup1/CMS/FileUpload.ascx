<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs"
    Inherits="ATMTECH.BillardLoretteville.Website.CMS.FileUpload" %>
<%@ Register Assembly="obout_FileUpload" Namespace="OboutInc.FileUpload" TagPrefix="fup" %>
<script type="text/JavaScript">
    function ClearedFiles(fileNames) {
        alert("Seulement les fichiers images sont permis le fichier suivant ne possède pas une extension valide\n\n" + fileNames);
    }

    function Rejected(fileName, size, maxSize) {
        alert("Fichier " + fileName + " a été rejeté \nLa taille (" + size + " bytes) excède le maximum de " + maxSize + " bytes");
    }
</script>
<atmtech:GrilleAvance ID="grdFile" runat="server" Visible="true" TypeName="ATMTECH.Views.FileUploadPresenter"
    DataKeyNames="Id" EstAfficheColonneEdition="true" EstAfficheColonneSuppression="true"
    AjouterMethode="test" ActiverBoutonAjout="False" DataObjectTypeName="ATMTECH.Entities.File"
    EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="True" MessageAucuneDonnee="Aucun."
    UpdateMethod="UpdateFile" DeleteMethod="DeleteFile" SelectMethod="GetFile" SelectCountMethod="GetFileCount"
    MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
    SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
    ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true">
    <columns>
    <asp:BoundField HeaderText="Fichier" DataField="FileName" SortExpression="FileName"></asp:BoundField>
<asp:BoundField HeaderText="Description" DataField="Description" SortExpression="Description"></asp:BoundField>
<asp:BoundField HeaderText="Taille" DataField="Size" SortExpression="Size"></asp:BoundField>
<asp:BoundField HeaderText="Titre" DataField="Title" SortExpression="Title"></asp:BoundField>
<asp:BoundField HeaderText="Modifié le" DataField="DateModified" SortExpression="DateModified"></asp:BoundField>
<asp:BoundField HeaderText="Crée le" DataField="DateCreated" SortExpression="DateCreated"></asp:BoundField>
</columns>
    <detail largeur="500" titreinsertion="Ajouter" titremodification="Modifier" titreconsultation="consulter">
<EditItemTemplate>
<table width="100%"><tr><atmtech:TextBoxAvance enabled="True" id="txtDescription" Libelle="Description" runat="server" Text='<%# Bind("Description")%>' width="100%"></atmtech:TextBoxAvance>
</tr><tr><atmtech:TextBoxAvance enabled="True" id="txtTitle" Libelle="Titre" runat="server" Text='<%# Bind("Title")%>' width="100%"></atmtech:TextBoxAvance>
</tr><tr><atmtech:TextBoxAvance enabled="False" id="txtSize" Libelle="Taille" runat="server" Text='<%# Bind("Size")%>' width="100%"></atmtech:TextBoxAvance>
</tr><tr><atmtech:TextBoxAvance enabled="False" id="txtServerPath" Libelle="Fichier" runat="server" Text='<%# Bind("FileName")%>' width="100%"></atmtech:TextBoxAvance>
</tr><tr><atmtech:TextBoxAvance enabled="False" id="txtEmplacement" Libelle="Emplacement" runat="server" Text='<%# Bind("ServerPath")%>' width="100%"></atmtech:TextBoxAvance>
</tr><tr><atmtech:TextBoxAvance enabled="False" id="txtDateModified" Libelle="Modifié le" runat="server" Text='<%# Bind("DateModified")%>' width="100%"></atmtech:TextBoxAvance>
</tr><tr><atmtech:TextBoxAvance enabled="False" id="txtDateCreated" Libelle="Crée le" runat="server" Text='<%# Bind("DateCreated")%>' width="100%"></atmtech:TextBoxAvance>
</tr>
<tr><atmtech:TextBoxAvance enabled="False" Visible="false" id="txtIsActive" Libelle="IsActive" runat="server" Text='<%# Bind("IsActive")%>' width="100%"></atmtech:TextBoxAvance>
</tr>
</table><hr/>
    <asp:button id="btnUpdateFile" runat="server" Text="Enregistrer" CommandName="Update" />
</EditItemTemplate>
</detail>
</atmtech:GrilleAvance>
<b>Sélectionner le fichier:</b><br />
<input name="myFile" size="20" type="file" />
<asp:LinkButton ID="transferFiles" runat="server">Transférer le fichier</asp:LinkButton>
<fup:FileUploadProgress ID="FileUploadProgress2" runat="server" OnClientFileCleared="ClearedFiles"
    OnClientFileRejected="Rejected">
    <AllowedFileFormats>
        <fup:Format Ext="xls" MaxByteSize="1024000" />
        <fup:Format Ext="doc" MaxByteSize="1024000" />
        <fup:Format Ext="html" MaxByteSize="1024000" />
        <fup:Format Ext="htm" MaxByteSize="1024000" />
        <fup:Format Ext="gif" MaxByteSize="1024000" />
        <fup:Format Ext="jpg" MaxByteSize="1024000" />
        <fup:Format Ext="jpeg" MaxByteSize="1024000" />
        <fup:Format Ext="flv" MaxByteSize="1024000" />
        <fup:Format Ext="png" MaxByteSize="1024000" />
        <fup:Format Ext="exe" MaxByteSize="1024000" />
        <fup:Format Ext="msi" MaxByteSize="1024000" />
        <fup:Format Ext="wmv" MaxByteSize="1024000" />
        <fup:Format Ext="mpg" MaxByteSize="1024000" />
        <fup:Format Ext="mp4" MaxByteSize="1024000" />
        <fup:Format Ext="mp3" MaxByteSize="1024000" />
        <fup:Format Ext="wav" MaxByteSize="1024000" />
    </AllowedFileFormats>
</fup:FileUploadProgress>
