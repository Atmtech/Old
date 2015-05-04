<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 100%">
        <tr>
            <td>Catégorie<br />
                <asp:DropDownList runat="server" ID="ddlCategorie" placeholder="Watermark" Width="300" CssClass="dropDownList">
                    <asp:ListItem Text="Montagne"></asp:ListItem>
                    <asp:ListItem Text="Foret"></asp:ListItem>
                    <asp:ListItem Text="Peche"></asp:ListItem>
                </asp:DropDownList></td>
            <td style="text-align: right">Page<br/>
                  <asp:DropDownList runat="server" ID="DropDownList1" placeholder="Watermark" Width="50" CssClass="dropDownList">
                      <asp:ListItem Text="1"></asp:ListItem>
                      <asp:ListItem Text="2"></asp:ListItem>
                      <asp:ListItem Text="3"></asp:ListItem>
                  </asp:DropDownList>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <td style="padding-right: 50px;">
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px; margin-bottom: 10px;">
                    <img src="Images/Background/trip2.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br/>
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>
            <td style="padding-right: 50px;">
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;margin-bottom: 10px;">
                    <img src="Images/Background/trip1.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 11 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>
            <td>
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;margin-bottom: 10px;">
                    <img src="Images/Background/trip3.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 21 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>

        </tr>
        
          <tr>
            <td style="padding-right: 50px;">
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;margin-bottom: 10px;">
                    <img src="Images/Background/trip2.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>
            <td style="padding-right: 50px;">
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;margin-bottom: 10px;">
                    <img src="Images/Background/trip1.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>
            <td>
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;margin-bottom: 10px;">
                    <img src="Images/Background/trip3.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>

        </tr>
        
          <tr>
            <td style="padding-right: 50px;">
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;">
                    <img src="Images/Background/trip2.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>
            <td style="padding-right: 50px;">
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;">
                    <img src="Images/Background/trip1.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>
            <td>
                <div style="background-color: white; font-size: 10px; border-radius: 10px; padding: 10px 10px 10px 10px; width: 280px; height: 240px;">
                    <img src="Images/Background/trip3.jpg" class="imageListeExpedition" /><br />
                    <div style="font-weight: bold; font-size: 12px;">Hicking en Nouvelle-Zélande[...]</div>
                    4 participants | Suivi par: 199 personnes<br />
                    Le 25 aout 2010
                    <br />
                    Joé Luveau
                </div>
            </td>

        </tr>
    </table>
    <br/><br/>

</asp:Content>
