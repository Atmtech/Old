<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectionnerAdresse.ascx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.UserControls.SelectionnerAdresse" %>

<asp:TextBox ID="txtAdresse" runat="server" AutoPostBack="true" CssClass="textBox" Width="300px"></asp:TextBox>
<asp:Button runat="server" ID="btnRechercher" Text="Rechercher" OnClick="btnRechercherClick" CssClass="boutonAction" />
<asp:GridView runat="server" ID="grdAdresse" ShowHeader="False" AutoGenerateColumns="False" ForeColor="White" OnRowCommand="grdAdresseRowCommand" Width="400px">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkSelectionnerAdresse" Text='<%# Eval("AdresseLongue") %>' CommandName="SelectionnerAdresse" CommandArgument='<%# Eval("AdresseLongue") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="padding-top: 20px;">
    <asp:Label runat="server" ID="lblCodePostal" Text="Code postal" CssClass="labelLogin"></asp:Label>
    <asp:TextBox ID="txtCodePostal" runat="server" AutoPostBack="true" CssClass="textBox" ValidationGroup="validation"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
        ControlToValidate="txtCodePostal"
        ValidationGroup="validation"
        ErrorMessage="*"
        runat="Server">
    </asp:RequiredFieldValidator>
    <asp:Label runat="server" ID="lblObligatoire" Text="* Obligatoire" ForeColor="red"></asp:Label>
</div>
<div>

    
</div>

