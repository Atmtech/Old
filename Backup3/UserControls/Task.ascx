<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Task.ascx.cs" Inherits="ATMTECH.Scrum.WebSite.UserControls.TaskPage" %>
<table>
    <tr>
        <td>
            Story ::
            <atmtech:TitreLabelAvance runat="server" ID="txtStory" />
        </td>
        <td>
            <atmtech:TitreLabelAvance runat="server" ID="txtStoryDescription" />
        </td>
    </tr>
    <tr>
        <atmtech:TextBoxMultiligneAvance runat="server" ID="txtDescription" Rows="4" Libelle="Description"
            StyleTextBox="width:400px;" />
    </tr>
    <tr>
        <atmtech:TextBoxAvance runat="server" ID="txtEstimatedPoint" Libelle="Temps estimé" />
    </tr>
</table>
<hr />
<asp:Button runat="server" ID="btnSave" Text="Enregistrer" OnClick="SaveTask" />
