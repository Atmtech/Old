<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GererNourriture.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.GererNourriture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boutonAjout {
            background-color: rgb(54, 180, 54);
            color: white;
            font-size: 12px;
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
            background-color: rgb(255, 0, 0);
            color: white;
            font-size: 12px;
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

        .boutonModifier {
            background-color: rgb(0, 160, 196);
            color: white;
            font-size: 12px;
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
            <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>


                    <h2>
                        <asp:Label ID="lblEtape4CreationNouvelleEtape" runat="server" Text="Création du menu"></asp:Label>
                        ::
                <asp:Label ID="lblNomExpedition" runat="server" Text=""></asp:Label>
                    </h2>

                    <table>
                        <tr>
                            <td>
                                <div>
                                    <asp:TextBox runat="server" ID="txtNomMenu" placeholder="Nom" CssClass="TextBox"></asp:TextBox>

                                    <asp:TextBox runat="server" ID="txtDateMenu" placeholder="Date"></asp:TextBox>
                                    <div style="border-bottom: solid 1px gray">
                                        <asp:Label ID="lblMenuDetaille" runat="server" Text="Menu"></asp:Label></div>
                                    <atmtech:Editor runat="server" ID="txtMenu" Toolbar="Basic" />
                                    <div style="border-bottom: solid 1px gray">
                                        <asp:Label ID="lblCuisinier" runat="server" Text="Cuisinier"></asp:Label></div>
                                    <asp:DropDownList runat="server" ID="ddlParticipant"></asp:DropDownList>

                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton runat="server" ID="lnkAjouterMenu" Text="Enregistrer ce menu" CssClass="button icon fa-plus" OnClick="lnkAjouterMenuClick"></asp:LinkButton>
                    <br />
                    <hr />
                    <h2>
                        <asp:Label ID="lblListeMenu" runat="server" Text="Liste des menus"></asp:Label>
                    </h2>


                    <asp:DataList ID="listeNourriture" runat="server" OnItemCommand="listeNourritureItemCommand" OnItemDataBound="listeNourritureItemDataBound" RepeatDirection="Horizontal" RepeatColumns="3">
                        <ItemTemplate>

                            <div style="float: Left;">
                                <img src="Images/profile_placeholder.gif" alt="" style="border-radius: 50%;" />
                            </div>
                            <div style="padding-left: 10px; float: Left; padding-right: 15px; margin-bottom: 10px;">

                                <b>
                                    <asp:Label runat="server" ID="lblNomMenu" Text='<%# Eval("Nom") + " (" + Eval("Cuisinier.Utilisateur.FirstNameLastName") + ")"  %>'></asp:Label></b>
                                <div style="font-size: 15px;">
                                    <asp:Label runat="server" ID="lblDateNourriture" Text='<%# Eval("Date","{0:yyyy-MM-dd}")  %>'></asp:Label><br />
                                </div>
                                <asp:LinkButton runat="server" ID="lnkRetirerMenu" Text="Retirer" CssClass="boutonEnlever" CommandArgument='<%# Eval("Id")  %>' CommandName="retirer"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkModifierMenu" Text="Modifier" CssClass="boutonModifier" CommandArgument='<%# Eval("Id")  %>' CommandName="modifier"></asp:LinkButton>
                            </div>

                            <div style="clear: left;">
                                <b>
                                    <asp:Label runat="server" ID="lblListeParticipant" Text="Liste participant au repas"></asp:Label></b>
                                <br />

                                <div style="font-size: 13px;">
                                    <table>
                                        <asp:Repeater ID="listeParticipant" runat="server" OnItemCommand="listeParticipantItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 25px;">

                                                        <asp:Label runat="server" ID="lblIdParticipant" Text='<%# Eval("IdParticipant")  %>' Visible="False"></asp:Label>
                                                        <asp:Label runat="server" ID="lblIdNourriture" Text='<%# Eval("Nourriture.Id")  %>' Visible="False"></asp:Label>
                                                        <asp:Label runat="server" ID="lblIdNourritureParticipant" Text='<%# Eval("IdNourritureParticipant")  %>' Visible="False"></asp:Label>
                                                        <asp:LinkButton runat="server" ID="lnkRetirerParticipant" Text="Retirer" CssClass="boutonEnlever" Visible='<%# Convert.ToBoolean(Eval("EstParticipantNourriture"))  %>' CommandName="retirer"></asp:LinkButton>
                                                        <asp:LinkButton runat="server" ID="lnkAjouterParticipant" Text="Ajouter" CssClass="boutonAjout" Visible='<%# !Convert.ToBoolean(Eval("EstParticipantNourriture"))  %>' CommandName="ajouter"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblParticipant" Text='<%# Eval("Utilisateur.FirstNameLastName")  %>'></asp:Label>
                                                        (<asp:Label runat="server" ID="lblMail" Text='<%# Eval("Utilisateur.Email")  %>'></asp:Label>)
                                                <br />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
