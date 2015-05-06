<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Expedition.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.ExpeditionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 20px;">
        <asp:Button runat="server" ID="btnAfficherListeMaterielExpedition" Text="Imprimer la liste du matériel pour cette expédition" CssClass="bouton" />
        <asp:Button runat="server" ID="btnImprimerExpedition" Text="Imprimer l'expedition" CssClass="bouton" />
    </div>
    <div class="expedition">
        <div class="titre">
            <asp:Label runat="server" ID="lblIdentificationExpedition" Text="Identification"></asp:Label>
        </div>

        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblTitreExpedition" Text="Nom"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtTitreExpedition" CssClass="textBox" Width="300px"></asp:TextBox>
                </td>

                <td>
                    <asp:Label runat="server" ID="lblDateDebutExpedition" Text="Date début"></asp:Label><br />
                    <atmtech:DatePicker runat="server" ID="txtDateDebut" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblDateFinExpedition" Text="Date fin"></asp:Label><br />
                    <atmtech:DatePicker runat="server" ID="txtDateFin" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblPays" Text="Pays"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtPays" CssClass="textBox"></asp:TextBox>
                </td>

                <td>
                    <asp:Label runat="server" ID="lblRegion" Text="Region"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtRegion" CssClass="textBox"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="margin-top: 10px;">
            <asp:Label runat="server" ID="lblDescriptionExpedition" Text="Description"></asp:Label><br />
            <atmtech:Editor runat="server" ID="txtdescriptionExpedition" Toolbar="Source|Bold|Italic|Underline|Strike|-|Subscript|Superscript|NumberedList|BulletedList|-|Outdent|Indent|Table/Styles|Format|Font|FontSize|TextColor|BGColor|"></atmtech:Editor>
        </div>

        <div class="affichageBudget">
            <asp:Label runat="server" ID="lblAffichageBudget" Text="Budget prévu (Comptabilisé avec les étapes)"></asp:Label><br />
            <asp:Label runat="server" ID="lblBudget"></asp:Label><br />
        </div>
    </div>
    <div class="etape">
        <div class="titre">

            <asp:Label runat="server" ID="lblLesEtapesExpedition" Text="Les étapes"></asp:Label>
        </div>
        <asp:DataList runat="server" ID="dataListEtape" RepeatDirection="Horizontal" RepeatColumns="4">
            <ItemTemplate>
                <div style="border: solid 1px gray; border-radius: 5px; padding: 5px 5px 5px 5px;">
                    <asp:ImageButton runat="server" ID="btnImageEtape" ImageUrl='<%#"~/Images/Media/" +Eval("FichierPrincipal")%>' class="imageListeEtape" CommandName="Voir" CommandArgument='<%#Eval("Id")%>' />

                    <div style="font-size: 11px; font-weight: bold;">
                        <asp:Label runat="server" ID="lblEtape" Text='<%#Eval("Nom")%>'></asp:Label>
                    </div>
                    <div style="font-size: 11px; font-weight: bold;">
                        <asp:Label runat="server" ID="lblNombreKilometre" Text='<%#Eval("Distance")%>'></asp:Label>
                        KM
                    </div>
                </div>

            </ItemTemplate>
            <FooterTemplate>
                <asp:Label Visible='<%#bool.Parse((dataListEtape.Items.Count==0).ToString())%>' runat="server" ID="lblNoRecord" Text="No Record Found!"></asp:Label>
            </FooterTemplate>
        </asp:DataList>
    </div>
    <div class="participant">
        <div class="titre">
            <asp:Label runat="server" ID="lblListeParticipant" Text="Liste des participants"></asp:Label><br />
        </div>

        <atmtech:ComboBox runat="server" ID="ddlUtilisateur" />

        <div style="margin-top: 10px;">
            <asp:Button runat="server" ID="btnAjouterUtilisateurAExpedition" Text="Ajouter cet utilisateur à cette expédition" CssClass="bouton" />
        </div>
        <div class="listeParticipant">
            <asp:DataList runat="server" ID="dataListeParticipant" RepeatDirection="Vertical">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblParticipant" Text='<%#Eval("Utilisateur.FirstNameLastName")%>'></asp:Label>
                    <asp:Label runat="server" ID="lblEstAdministrateur" Text='<%# Convert.ToBoolean(Eval("EstAdministrateurExpedition")) ? " | Admin" :""%>'></asp:Label><br />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label Visible='<%#bool.Parse((dataListeParticipant.Items.Count==0).ToString())%>' runat="server" ID="lblNoRecord" Text="No Record Found!"></asp:Label>
                </FooterTemplate>
            </asp:DataList>
        </div>
    </div>




</asp:Content>
