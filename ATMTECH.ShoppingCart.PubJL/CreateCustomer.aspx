<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CreateCustomer.aspx.cs" Inherits="ATMTECH.ShoppingCart.PubJL.CreateCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 950px; padding: 10px 10px 10px 10px; color: black; border: solid 1px gray; background-color: white; margin-bottom: 10px;">
        <div class="title">
            <strong>
                <asp:Label runat="server" ID="lblCreateCustomer" Text="Création d'un client"></asp:Label>
            </strong>
        </div>

        <asp:Panel runat="server" ID="pnlCreate">
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblFirstName" Text="Prénom"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFirstName" ValidationGroup="CreateCustomer"
                            Width="400px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblLastName" Text="Nom"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLastName" ValidationGroup="CreateCustomer"
                            Width="400px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblEmail" Text="Courriel:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" ValidationGroup="CreateCustomer"
                            Width="400px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblLogin" Text="Nom d'utilisateur:"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLogin"
                            Width="400px" ValidationGroup="CreateCustomer"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblPassword" Text="Mot de passe:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" ValidationGroup="CreateCustomer"
                            Width="400px" TextMode="Password"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirmation:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtConfirmPassword"
                            Width="400px" ValidationGroup="CreateCustomer" TextMode="Password"></asp:TextBox>
                    </td>

                </tr>
              
            </table>
            <asp:Button runat="server" ID="btnCreate" OnClick="CreateCustomer_click" Text="Créer"
                ValidationGroup="CreateCustomer" />
            <asp:Button runat="server" ID="btnCancel" OnClick="CancelCreateCustomer_click" Text="Annuler" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlCreated" Visible="False">
            <asp:Label runat="server" ID="lblCreateCustomerSuccess" Text="Veuillez suivre les informations contenu dans le courriel pour valider la création de votre utilisateur."></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
