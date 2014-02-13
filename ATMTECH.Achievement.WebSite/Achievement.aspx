<%@ Page Title="" Language="C#" MasterPageFile="~/Achievement.Master" AutoEventWireup="true" CodeBehind="Achievement.aspx.cs" Inherits="ATMTECH.Achievement.WebSite.Achievement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlListeAccomplissement">
        <div style="margin-left: 10px; margin-right: 10px; text-align: left; background-color: white; border-radius: 10px;">
            <div style="padding: 10px 10px 10px 10px;">
                <h1>Les accomplissements</h1>
                <table>
                    <tr>
                        <td>
                           
                               <div class="listeCategorie">
                               <asp:DropDownList runat="server">
                                             
                                    <asp:ListItem Value="x" Text="Tous"></asp:ListItem>
                                    <asp:ListItem Value="z" Text="Non approuvé"></asp:ListItem>
                                </asp:DropDownList> </div>
                           
                            <div>
                                <asp:DataList runat="server" ID="datalistCategorie">
                                    <ItemTemplate>
                                        <div class="listeCategorie">
                                            <asp:LinkButton runat="server" ID="btnOuvrirCategorie" Text='<%# Eval("Description") + " (" + Eval("NombreAccomplissement") + ")" %>' CommandArgument='<%# Eval("Id") %>' OnClick="btnOuvrirCategorie" />
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </td>
                        <td style="vertical-align: top; padding-left: 20px;">
                            <asp:PlaceHolder runat="server" ID="placeHolderAccomplissement"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
