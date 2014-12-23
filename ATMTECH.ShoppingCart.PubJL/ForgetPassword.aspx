<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ForgetPassword.aspx.cs" Inherits="ATMTECH.ShoppingCart.PubJL.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
        <div class="title">
            <asp:Label runat="server" ID="lblTitleForgetPassword" Text="J'ai oublié mon mot de passe" />
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblEmail" Text="Courriel:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" Width="400px"></asp:TextBox>
                </td>

            </tr>
        </table>
        <asp:Button runat="server" ID="btnSendMailForget" OnClick="SendMail_click" Text="Envoyez moi mon mot de passe" />
        <br />
        <asp:Label runat="server" ID="lblConfirmSendEmail" Text="Nous vous avons envoyé votre mot de passe par courriel."
            Visible="False"></asp:Label>
    </div>
</asp:Content>
