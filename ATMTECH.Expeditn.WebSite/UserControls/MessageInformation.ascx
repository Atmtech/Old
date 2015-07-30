<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageInformation.ascx.cs" Inherits="ATMTECH.Expeditn.WebSite.UserControls.MessageInformation" %>
<asp:Panel ID="pnlMessageInformation" runat="server" Visible="False">
    <div style="border: solid 1px rgb(234, 144, 144); border-radius: 5px; background-color: white;">
        <p>
            <div style="font-size: 2em;"><i class="color6 fa fa-exclamation-triangle "></i>&nbsp;<strong>Ooops une erreur ...</strong></div>
            <div style="padding-top: 10px; font-size: 1.5em;">
                <asp:Label runat="server" ID="lblMessageInformation"></asp:Label>
            </div>
        </p>
    </div>
</asp:Panel>
