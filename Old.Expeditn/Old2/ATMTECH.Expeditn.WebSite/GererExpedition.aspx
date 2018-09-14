<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererExpedition.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.GererExpedition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />


    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">

        <div class="mbr-section__container mbr-section__container--std-padding container">

            <h2 class="header2">
                <asp:Label ID="lblEtape1CreationNouvelleExpedition" runat="server" Text="Information sur l'expédition"></asp:Label>
            </h2>
            <table style="width: 100%">
                <tr>
                    <td style="padding-right: 10px;">

                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblTitreNomExpedition" runat="server" Text="Nom de l'expédition"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtNomExpedition" placeholder="Nom de l'expédition" class="controlEditable"></asp:TextBox>

                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblDebutExpedition" runat="server" Text="Date de début"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtDebutExpedition" placeholder="Date de début" class="controlEditable"></asp:TextBox>


                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblFinExpedition" runat="server" Text="Date de fin"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtFinExpedition" placeholder="Date de fin" class="controlEditable"></asp:TextBox>

                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblBudgetEstimeExpedition" runat="server" Text="Budget estimé"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtBudgetEstimeExpedition" placeholder="Budget estimé" class="controlEditable"></asp:TextBox>

                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblEstPrive" runat="server" Text="Accessibilité"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlEstPrive" class="controlEditable">
                            <asp:ListItem Value="0">Expédition public</asp:ListItem>
                            <asp:ListItem Value="1">Expédition privée</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblLatitude" runat="server" Text="Latitude"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtLatitude" placeholder="Latitude" class="controlEditable"></asp:TextBox>
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblLongitude" runat="server" Text="Longitude"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtLongitude" placeholder="Longitude" class="controlEditable"></asp:TextBox>
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblRegionExpedition" runat="server" Text="Région"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtRegionExpedition" placeholder="Region" class="controlEditable"></asp:TextBox>
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblPays" runat="server" Text="Pays"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlPays" placeholder="Pays" class="controlEditable"></asp:DropDownList>
                        <div class="libelleChampsEditable">
                            <asp:Label ID="lblVilleExpedition" runat="server" Text="Ville"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtVilleExpedition" placeholder="Ville" class="controlEditable"></asp:TextBox>

                    </td>

                    <td>
                        <div style="text-align: center; padding-left: 15px;">
                            <asp:Image runat="server" ID="imgExpedition" Style="border-radius: 50%; width: 150px; height: 150px;" /><br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                            <asp:LinkButton runat="server" ID="lnkChangerImage" Text="Changer l'image de l'expedition" class="mbr-buttons__btn btn btn-standard" OnClick="lnkChangerImageClick"></asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
            <br/>
            <asp:LinkButton runat="server" ID="lnkEnregistrerExpedition" class="mbr-buttons__btn btn btn-standard" Text="Enregistrer" OnClick="lnkEnregistrerExpeditionClick"></asp:LinkButton>
            
            <br/>
            <asp:HyperLink runat="server" ID="lnkRevenirTableauBord" class="mbr-buttons__btn btn btn-standard" Text="Revenir au tableau de bord" NavigateUrl="TableauBord.aspx"></asp:HyperLink>
        </div>

    </section>
</asp:Content>
