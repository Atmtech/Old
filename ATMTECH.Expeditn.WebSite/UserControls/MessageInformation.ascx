<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageInformation.ascx.cs" Inherits="ATMTECH.Expeditn.WebSite.UserControls.MessageInformation" %>
<asp:Panel ID="pnlMessageInformationErreur" runat="server" Visible="False">
    <div style="border: solid 2px rgb(234, 144, 144); border-radius: 5px; background-color: white; margin-bottom: 10px;">
        <p>
            <div style="font-size: 2em;"><i class="color6 fa fa-exclamation-triangle "></i>&nbsp;<strong>Ooops une erreur ...</strong></div>
            <div style="padding-top: 10px; font-size: 1.5em;">
                <asp:Label runat="server" ID="lblMessageInformationErreur"></asp:Label>
            </div>
        </p>
    </div>
</asp:Panel>


<asp:Panel ID="pnlMessageInformationSucces" runat="server" Visible="False">
    <div style="border: solid 2px rgb(10, 157, 52); border-radius: 5px; background-color: white; margin-bottom: 10px;">
        <p>
            <div style="font-size: 2em;"><i class="color6 fa fa-exclamation-triangle "></i>&nbsp;<strong>Succès ...</strong></div>
            <div style="padding-top: 10px; font-size: 1.5em;">
                <asp:Label runat="server" ID="lblMessageInformationSucces"></asp:Label>
            </div>
        </p>
    </div>
</asp:Panel>

