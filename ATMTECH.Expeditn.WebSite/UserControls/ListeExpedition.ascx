<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListeExpedition.ascx.cs" Inherits="ATMTECH.Expeditn.WebSite.UserControls.ListeExpedition" %>

  <asp:DataList runat="server" ID="dataListExpedition" RepeatDirection="Horizontal" RepeatColumns="3" OnItemCommand="dataListExpeditionItemCommand">
        <ItemTemplate>
            <div class="expeditionListe">
                <asp:ImageButton runat="server" ID="btnImageExpedition" ImageUrl='<%#"~/Images/Media/" +Eval("FichierPrincipal")%>' class="imageListeExpedition" CommandName="Voir" CommandArgument='<%#Eval("Id")%>' />
                <div class="expeditionListeTitre">
                    <asp:Label runat="server" ID="lblTitre" Text='<%#Eval("Nom")%>'></asp:Label>
                </div>
                <div class="expeditionListeDescription">
                    <asp:Label runat="server" ID="lblDescription" Text='<%#  Eval("Description").ToString().Length > 49 ? Eval("Description").ToString().Substring(0,50) + "...":Eval("Description") %>'></asp:Label>
                </div>

                <div class="expeditionListeChef">
                    <asp:Label runat="server" ID="lblChef" Text='<%#Eval("Chef.Utilisateur.FirstNameLastName")%>'></asp:Label>
                </div>

                <div class="expeditionListeParticipant">
                    <div style="float: left; width: 70%; font-size: 10px; padding-top: 5px;">
                        Date:
                        <asp:Label runat="server" ID="lblDateDebut" Text='<%#Eval("DateDebut", "{0:d}")%>'></asp:Label>
                        -
                                <asp:Label runat="server" ID="lblDateFin" Text='<%#Eval("DateFin", "{0:d}")%>'></asp:Label>
                    </div>
                    <div style="float: left; text-align: right; border-radius: 4px; width: 30%; background-color: rgb(212, 212, 212); vertical-align: middle; padding-top: 3px; padding-bottom: 3px;">
                        <asp:Label runat="server" ID="lblNombreParticipant" Text='<%#Eval("NombreParticipant")%>'></asp:Label>&nbsp;
                        <img src="Images/WebSite/Suiveux.png" style="width: 20px; height: 20px; vertical-align: middle;" />
                        <img src="Images/WebSite/Aimer.png" style="width: 20px; height: 20px; vertical-align: middle;" />&nbsp;<asp:Label runat="server" ID="lblNombreParticipantQuiSuive" Text='<%#Eval("NombreParticipantQuiSuive")%>'></asp:Label>&nbsp;
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
