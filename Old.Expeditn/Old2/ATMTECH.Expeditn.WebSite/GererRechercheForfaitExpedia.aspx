<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererRechercheForfaitExpedia.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.GererRechercheForfaitExpedi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: white;">
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
                            <asp:Label ID="lblDateForfait" runat="server" Text="Date"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtDate" placeholder="Date" class="controlEditable"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="padding-right: 10px;">
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblUrl" runat="server" Text="URL de recherche sur Expedia"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtUrl" placeholder="URL de recherche sur Expedia" class="controlEditable"></asp:TextBox>
                    </td>
                </tr>


            </table>
            <br />
            <div style="padding: 10px 10px 10px 10px; background-color: rgb(231, 231, 231); border: 1px solid gray; color:rgb(15, 57, 180)">
                <asp:Label runat="server" ID="lblExempleLienExpedia" Text="N.B. Le url doit être valide sur expedia, vous devez d'abord l'essayer sur le site avant. <br>Pour ce faire faite une recherche sur expedia avec vos critères une fois le résultat sortie vous pouvez copier et coller le URL."></asp:Label>
            </div>
            <br />
            <br />

            <asp:LinkButton runat="server" ID="lnkEnregistrerRechercheForfaitExpedia" class="mbr-buttons__btn btn btn-standard" Text="Enregistrer" OnClick="lnkEnregistrerRechercheForfaitExpediaClick"></asp:LinkButton>


        </div>
    </section>
</asp:Content>
