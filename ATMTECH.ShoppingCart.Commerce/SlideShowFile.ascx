<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlideShowFile.ascx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.SlideShowFile" %>

<style>
    .imageAjouterPanier
    {
        width: 55px;
        height: 65px;
    }

    .imagePrincipaleMaximale
    {
        width: 420px;
        height: 650px;
    }

    .imagePrincipaleAvecPadding
    {
        padding-top: 50px;
    }
</style>

<div style="background-color: white; width: 420px; height: 650px; text-align: center;">
    <asp:Image runat="server" ID="imgPrincipale" />
</div>


<div style="text-align: center; background-color: white; padding: 5px 5px 5px 5px; margin-top: 5px;">
    <asp:DataList runat="server" ID="dataListeFichier" RepeatColumns="7" RepeatDirection="Horizontal" OnItemCommand="dataListeFichierItemCommand">
        <ItemTemplate>
            <asp:ImageButton runat="server" ImageUrl='<%# "Images/Product/" + Eval("File.FileName")%>' CssClass="imageAjouterPanier" CommandName="AfficherImage" CommandArgument='<%# "Images/Product/" + Eval("File.FileName")%>' />
        </ItemTemplate>
    </asp:DataList>
</div>
