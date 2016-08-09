<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AjouterExpeditionEtape3.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.AjouterExpeditionEtape3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boutonAjout {
            background-color: rgb(54, 180, 54);
            color: white;
            font-size: 14px;
            border-radius: 20px;
            padding-top: 2px;
            padding-bottom: 2px;
            padding-left: 10px;
            padding-right: 10px;
            text-decoration: none;
            display: inline-block;
            white-space: nowrap;
            cursor: Pointer;
        }

        .boutonEnlever {
            background-color: rgb(180, 99, 99);
            color: white;
            font-size: 14px;
            border-radius: 20px;
            padding-top: 2px;
            padding-bottom: 2px;
            padding-left: 10px;
            padding-right: 10px;
            text-decoration: none;
            display: inline-block;
            white-space: nowrap;
            cursor: Pointer;
        }
    </style>
    <section id="main" class="wrapper">
        <div class="container">

            <h2>
                <asp:Label ID="lblEtape3CreationNouvelleEtape" runat="server" Text="Ajouter des activités"></asp:Label>
            </h2>

            <table>
                <tr>
                    <td>
                        <div class="container 50%">
                            <asp:TextBox runat="server" ID="txtNomEtape" placeholder="Nom de l'étape" CssClass="TextBox"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtDebutEtape" placeholder="Date de début"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtFinEtape" placeholder="Date de fin"></asp:TextBox>
                            <asp:DropDownList runat="server" ID="ddlVehicule" placeholder="Vehicule"></asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <div class="container 50%">
                            <asp:TextBox runat="server" ID="txtDistance" placeholder="Distance"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:LinkButton runat="server" ID="lnkAjouterActiviteExpedition" Text="Ajouter cette activité" CssClass="button icon fa-plus" OnClick="lnkAjouterActiviteExpeditionClick"></asp:LinkButton>
            <br />
            <hr/>
            <h2>
                <asp:Label ID="lblListeActivite" runat="server" Text="Liste des activités"></asp:Label>
            </h2>


            <asp:DataList ID="listeActivite" runat="server" OnItemCommand="listeActiviteItemCommand" OnItemDataBound="listeActiviteItemDataBound" RepeatDirection="Horizontal" RepeatColumns="3">
                <ItemTemplate>

                    <div style="float: Left;">
                        <img src="Images/profile_placeholder.gif" alt="" style="border-radius: 50%;" />
                    </div>
                    <div style="padding-left: 10px; float: Left; padding-right: 15px;">

                        <b>
                            <asp:Label runat="server" ID="lblNomActivite" Text='<%# Eval("Nom") + " (" + Eval("Distance") + " KM)"  %>'></asp:Label></b>
                        <div style="font-size: 15px;">
                            <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                            <i class="fa fa-hand-o-right"></i>
                            <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label><br />
                            <asp:Label runat="server" ID="lblVehicule" Text='<%# Eval("Vehicule.Nom") + " (" + Eval("Vehicule.Fabriquant") + ")"  %>'></asp:Label><br />
                        </div>
                        <asp:LinkButton runat="server" ID="lnkRetirerActivite" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Id")  %>' CommandName="retirer"></asp:LinkButton>
                    </div>
                    <div style="padding-left: 10px; float: Left; border-left: solid 1px gray; padding-left: 15px;">

                        <b>
                            <asp:Label runat="server" ID="lblListeParticipant" Text="Liste participant"></asp:Label></b>
                        <br />

                        <div style="font-size: 13px;">
                            <table>
                                <asp:Repeater ID="listeParticipant" runat="server" OnItemCommand="listeParticipantItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkRetirerParticipant" Text="Retirer" CssClass="boutonEnlever" Visible='<%# Convert.ToBoolean(Eval("EstParticipantEtape"))  %>' CommandArgument='<%# Eval("IdEtapeParticipant")  %>' CommandName="retirer"></asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lnkAjouterParticipant" Text="Ajouter" CssClass="boutonAjout" Visible='<%# !Convert.ToBoolean(Eval("EstParticipantEtape"))  %>' CommandArgument='<%# Eval("IdParticipant")  %>' CommandName="ajouter"></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblParticipant" Text='<%# Eval("Nom")  %>'></asp:Label><br />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtMontant" PlaceHolder="Montant investi" AutoPostBack="True" OnTextChanged="txtMontantChanged" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <asp:LinkButton runat="server" ID="lnkPasserEtape4CreationEtape" Text="Ajouter des repas" CssClass="button icon fa-save" OnClick="lnkPasserEtape4CreationExpeditionClick"></asp:LinkButton>
        </div>
    </section>
</asp:Content>
