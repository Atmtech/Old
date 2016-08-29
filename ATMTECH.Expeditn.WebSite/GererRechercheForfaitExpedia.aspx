<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererRechercheForfaitExpedia.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.GererRechercheForfaitExpedi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">
        <div class="mbr-section__container mbr-section__container--std-padding container">

            <h2 class="header2">
                <asp:Label runat="server" ID="lblAjouterUneRecherche" Text="Ajouter une recherche de forfait"></asp:Label>
            </h2>

            <table style="width: 100%">
                <tr>
                    <td style="padding-right: 10px;">
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblDescriptifDestination" runat="server" Text="Descriptif de la destination"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtDescriptifDestination" placeholder="Descriptif de la destination" class="controlEditable"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="padding-right: 10px;">
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblUrl" runat="server" Text="Liens à utiliser pour expedia"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtUrl" placeholder="Liens à utiliser pour expedia" class="controlEditable"></asp:TextBox>
                    </td>
                </tr>


            </table>
            
                 <asp:LinkButton runat="server" ID="lnkEnregistrerRechercheForfaitExpedia" class="mbr-buttons__btn btn btn-standard" Text="Enregistrer" OnClick="lnkEnregistrerRechercheForfaitExpediaClick"></asp:LinkButton>
      

        </div>
    </section>
</asp:Content>
