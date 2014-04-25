<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.DenonceTonGros.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table>
        <tr>
            <td colspan="2">
                <div style="background-color: #629da5; padding-left: 20px; color: white;">
                    LA MERDE DU MOMENT
                </div>
                <div style="border: solid 1px #629da5; padding: 10px 10px 10px 10px; background-color: #e1d9d0">
                    ... <i>"<asp:Label runat="server" ID="lblMerdeDuJour"></asp:Label>"</i> -Emmerdeur inconnu  
                    
                    <asp:ImageButton ID="imgBtnLikeMerdeDujour" runat="server" ImageUrl="Images/like.png" Width="15px" Height="15px" OnClick="imgBtnLikeMerdeDujourClick" />
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <div style="background-color: #629da5; padding-left: 20px; color: white;">
                    <table style="width: 100%;">
                        <tr>
                            <td> LES GROSSES MERDES </td>
                            <td style="text-align: right;font-size: 12px;">( <asp:Label runat="server" ID="lblTotalMarde" Font-Bold="True"></asp:Label> grosses merdes )</td>
                        </tr>
                    </table>
                   
                </div>
                <div style="border: solid 1px #629da5; padding: 10px 10px 10px 10px; background-color: #e1d9d0">
                    Consulter la page:
                <asp:DropDownList runat="server" ID="ddlListePage" AutoPostBack="True" OnSelectedIndexChanged="selectedIndexChanged" />
                    <hr />
                    <asp:DataList runat="server" ID="datalist" OnItemCommand="ItemCommandClick">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img src="Images/DialogLeft.jpg" />

                                    </td>
                                    <td style="" valign="top">
                                        <div style="font-size: 10px; font-weight: bold; background-color: rgb(220, 220, 220); margin-bottom: 5px; border: 1px solid rgb(108, 101, 75); border-radius: 25px; padding: 10px 10px 10px 10px;">

                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description")%>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblInsulte" Text='<%#Eval("Insulte.Description")%>'></asp:Label>
                                                        (<asp:Label runat="server" ID="lblDate" Text='<%#Eval("DateCreated")%>'></asp:Label>)
                                                    </td>
                                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblJaimeTaMerde" Text='<%#Eval("Jaime")%>'></asp:Label></td>
                                                    <td>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Images/like.png" Width="17px" Height="17px" CommandName="JaimeTaMerde" CommandArgument='<%#Eval("Id")%>'  AlternateText="J'aime ta merde"/></td>
                                                </tr>
                                            </table>


                                        </div>

                                    </td>

                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </td>
            <td valign="top" style="width: 50%">

                <div style="background-color: #629da5; padding-left: 20px; color: white;">
                    LE TOP 20 DES GROS!!!
                </div>


                <div style="border: solid 1px #629da5; padding: 10px 10px 10px 10px; background-color: #e1d9d0">
                    <div style="font-size: 12px; font-weight: bold;">
                        <asp:DataList runat="server" ID="datalistTop" OnItemCommand="ItemCommandClick">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">

                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Image ID="ImageButton1" runat="server" ImageUrl="Images/like.png" Width="15px" Height="15px" /></td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>


                                <tr>
                                    <td valign="top">
                                        <asp:Label runat="server" ID="lblNumber" Text='<%#Container.ItemIndex + 1  %>' ForeColor="Maroon"></asp:Label>.</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description")%>'></asp:Label>
                                        <asp:Label runat="server" ID="lblInsulte" Text='<%#Eval("Insulte.Description")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblJaime" Text='<%#Eval("Jaime")%>'></asp:Label></td>
                                </tr>


                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr style="background-color: rgb(192, 192, 183);">
                                    <td valign="top">
                                        <asp:Label runat="server" ID="lblNumber" Text='<%#Container.ItemIndex + 1  %>' ForeColor="Maroon"></asp:Label>.</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblDescription" Text='<%#Eval("Description")%>'></asp:Label>
                                        <asp:Label runat="server" ID="lblInsulte" Text='<%#Eval("Insulte.Description")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblJaime" Text='<%#Eval("Jaime")%>'></asp:Label></td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                </tr>
                            </table>
                            <asp:Label ID="lblEmpty" Text="Aucune merde importante à affichier bande de merdeux" runat="server"
                                Visible='<%#bool.Parse((datalistTop.Items.Count==0).ToString())%>'>
                            </asp:Label>
                            </FooterTemplate>
                        </asp:DataList>
                    </div>
                </div>



            </td>
        </tr>
    </table>

</asp:Content>
