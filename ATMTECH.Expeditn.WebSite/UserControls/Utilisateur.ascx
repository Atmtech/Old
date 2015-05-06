<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Utilisateur.ascx.cs" Inherits="ATMTECH.Expeditn.WebSite.UserControls.UtilisateurControl" %>
<div class="panneauUtilisateur">
    <table>
        <tr>
            <td>
                <asp:Image runat="server" ImageUrl="/Images/Utilisateur/AucuneImage.png" Style="width: 50px; height: 45px;" />
            </td>
            <td style="vertical-align: top; color: black; font-size: 10px; padding-left: 10px;"><b>
                <asp:Label runat="server" ID="lblNomPrenomUtilisateur"></asp:Label><br/>
                <asp:Label runat="server" ID="lblCourrielUtilisateur"></asp:Label>
            </b>
                <br /><br />
                <asp:Label runat="server" ID="lblIdUtilisateur" Visible="False"></asp:Label>
                <asp:Button runat="server" ID="btnAfficherMesExpeditions" Text="Afficher mes expeditions" CssClass="boutonSimple" Visible="False" OnClick="btnAfficherMesExpeditionsClick" />
            </td>
        </tr>
    </table>
</div>
