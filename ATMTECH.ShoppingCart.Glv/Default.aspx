<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ATMTECH.ShoppingCart.Glv.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="tile triple-vertical triple">
            <div class="tile-content" style="overflow: auto; overflow-x: hidden;">
                <asp:Label runat="server" ID="lblContent"></asp:Label>
            </div>
        </div>
        <asp:PlaceHolder runat="server" ID="placeHolderProductFavorite"></asp:PlaceHolder>
        <div class="clearfix">
        </div>
    </div>
    <div class="clearfix">
    </div>
</asp:Content>
