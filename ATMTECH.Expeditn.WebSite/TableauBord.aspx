<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ATMTECH.Expeditn.WebSite.TableauBord" %>

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
            <h2>
                <asp:Label runat="server" ID="lblMesExpedition" Text="Mes expéditions"></asp:Label></h2>
            <asp:LinkButton runat="server" ID="lnkAjouterUneExpedition" Text="Ajouter une expédition" CssClass="special button icon fa-map-marker" OnClick="lnkAjouterUneExpeditionClick"></asp:LinkButton>
            <asp:LinkButton runat="server" ID="lnkModifierMesInformations" Text="Modifier mes informations" CssClass="special button icon fa-map-marker" OnClick="lnkModifierMesInformationsClick"></asp:LinkButton>
            <br />
            <br />

            <asp:DataList ID="listeMesExpeditions" runat="server" RepeatDirection="Vertical" OnItemCommand="listeMesExpeditionsItemCommand">
                <ItemTemplate>
                    <div style="float: Left;">
                         <asp:Image runat="server" ID="imgExpedition" ImageUrl='<%# Eval("FichierImage") %>' style="border-radius: 50%; width: 100px; height: 100px;"/>

                        
                    </div>
                    <div style="padding-left: 10px; float: Left;">
                        <b>
                            <asp:Label runat="server" ID="lblNomExpedition" Text='<%# Eval("Nom").ToString() %>'></asp:Label>
                        </b>
                        <div style="font-size: 13px;">
                            <asp:Label runat="server" ID="lblDateDebutListe" Text='<%# Eval("Debut","{0:yyyy-MM-dd}")  %>'></asp:Label>
                            <i class="fa fa-hand-o-right"></i>
                            <asp:Label runat="server" ID="lblDateFinListe" Text='<%# Eval("Fin","{0:yyyy-MM-dd}")  %>'></asp:Label>


                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblIdExpedition" Text='<%# Eval("Id")  %>' Visible="False"></asp:Label>
                            
                            <asp:LinkButton runat="server" ID="lnkModifierExpedition" Text="&nbsp;Modifier expédition" CssClass="icon fa-map-marker boutonModifier" CommandName="modifierExpedition"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkModifierParticipant" Text="&nbsp;Modifier participant " CssClass="icon fa-user boutonModifier" CommandName="modifierParticipant"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkModifierEtape" Text="&nbsp;Modifier activités " CssClass="icon fa-automobile boutonModifier" CommandName="modifierEtape"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkModifierMenu" Text="&nbsp;Modifier menu " CssClass="icon fa-delicious boutonModifier" CommandName="modifierMenu"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkModifierRepartitionPaieme" Text="&nbsp;Modifier répartition budget" CssClass="icon fa-calculator boutonModifier" CommandName="modifierRepartitionBudget"></asp:LinkButton>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </section>
</asp:Content>
