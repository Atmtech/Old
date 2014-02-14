<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="SiteList.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.SiteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlSiteInformation" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lbl" Text="Information sur le site"></asp:Label>
        </div>
        <table>
            <tr>
                <td>
                    <div style="width: 200px; vertical-align: top; margin-bottom: 10px; margin-right: 10px;
                        border: solid 1px gray;">
                        <div style="background-color: gainsboro;">
                            <table>
                                <tr>
                                    <td>
                                        <img src="Images/Main/bulletFish.png" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblName" CssClass="siteName"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <atmtech:GoogleMap ID="googleMapThumbnailWindow" runat="server" IsThumbnail="True" />
                    </div>
                </td>
                <td valign="top">
                    <asp:Label runat="server" ID="lblTitleDescription" Text="Description" CssClass="title"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblInformation"></asp:Label>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblTitleSpecies" Text="Liste des espèces disponibles sur ce plan d'eau" CssClass="title"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lblSpecies"></asp:Label>
                </td>
            </tr>
        </table>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnShowSiteList" OnClick="ShowSiteListClick" Text="Afficher la liste"
                CssClass="button" CausesValidation="False" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlList" Visible="True">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblSiteList" Text="Liste des sites disponibles"></asp:Label>
        </div>
        <asp:DataList runat="server" ID="dataListSite" OnItemDataBound="SiteListDataBound"
            OnItemCommand="SiteListCommand" RepeatDirection="Horizontal" RepeatColumns="4">
            <ItemTemplate>
                <div style="width: 200px; vertical-align: top; margin-bottom: 10px; margin-right: 10px;
                    border: solid 1px gray;">
                    <div style="background-color: gainsboro;">
                        <table>
                            <tr>
                                <td>
                                    <img src="Images/Main/bulletFish.png" />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblSiteName" CssClass="siteName" />
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="imgInformation" ImageUrl="~/Images/Main/Help.png"
                                        CommandName="info" CommandArgument='<%#Eval("Id")%>' />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <atmtech:GoogleMap ID="googleMapThumbnail" runat="server" IsThumbnail="True" />
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
</asp:Content>
