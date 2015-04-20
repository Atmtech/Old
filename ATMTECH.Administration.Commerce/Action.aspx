<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="ATMTECH.Administration.Commerce.Action" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlConfirmerCommande" Visible="false">
        <div class="titrePage">
            Confirmer la commande
        </div>
        Numéro de commande
        <atmtech:Numeric runat="server" ID="txtNoCommandeConfirmer" NoDecimal="True"></atmtech:Numeric>
        <asp:Button ID="btnConfirmerCommande" runat="server" Text="Confirmer la commande" CssClass="bouton" OnClick="btnConfirmerCommandeClick" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlAjusterCommande" Visible="false">
        <div class="titrePage">
            Ajuster une commande
        </div>
        Numéro de commande
        <atmtech:Numeric runat="server" ID="txtNoCommandeAjustement" NoDecimal="true"></atmtech:Numeric>
        <asp:Button ID="btnAfficherCommandeAjustement" runat="server" Text="Afficher commande à ajuster" CssClass="bouton" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlRestaureCopie" Visible="false">
        <div class="titrePage">
            Restaurer une copie de sauvegarde
        </div>
        Copie:
        <asp:DropDownList runat="server" ID="ddlListeCopieSauvegarde" AutoPostBack="True" />
        <br />
        <asp:Button runat="server" ID="btnRestaurerCopieSauvegarde" Text="Restaurer la copie de sauvegarde" OnClick="btnRestaurerCopieSauvegardeClick" CssClass="bouton" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlEditionCourriel" Visible="False">
        <div class="titrePage">
            Éditer un courriel
        </div>
        Courriel:
        <atmtech:ComboBox runat="server" ID="ddlListeCourriel" />
        <br />
        <br />
        <asp:Button runat="server" ID="btnAfficherCourriel" Text="Afficher le courriel" OnClick="btnAfficherCourrielClick" CssClass="bouton" /><br />

        <table style="width: 100%">
            <tr>
                <td style="width: 50%">Code:
                    <br />
                    <asp:TextBox runat="server" ID="txtCode" Enabled="False" Width="100%"></asp:TextBox><br/>
                    Sujet:<br />

                    <asp:TextBox runat="server" ID="txtSujet" Width="100%"></asp:TextBox><br />
                    Corps:<br />
                    <asp:TextBox runat="server" ID="txtCorps" TextMode="MultiLine" Rows="30" Width="100%" />
                </td>
                <td style="vertical-align: top; width: 50%; padding-left: 10px;">
                    <div style="border: solid 1px gray; width: 100%">
                        <asp:Label runat="server" ID="lblApercu" Text=""></asp:Label>
                    </div>
                </td>
            </tr>

        </table>


        <asp:Button runat="server" ID="btnApercuCourriel" Text="Aperçu du courriel" OnClick="btnApercuCourrielClick" CssClass="bouton" />
        <asp:Button runat="server" ID="btnSauvegarderCourriel" Text="Enregistrer" OnClick="btnSauvegarderCourrielClick" CssClass="bouton" />
    </asp:Panel>
</asp:Content>
