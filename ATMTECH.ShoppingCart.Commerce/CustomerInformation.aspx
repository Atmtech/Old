<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CustomerInformation.aspx.cs" Inherits="ATMTECH.ShoppingCart.Commerce.CustomerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="InformationClient">
        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblInformationSurLeCompte" Text="Information sur le compte"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="lblPrenom" Text="Prénom" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtPrenom" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblNom" Text="Nom" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtNom" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblCourrielCreer" Text="Courriel" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCourrielCreer" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>

        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasseCreer" Text="Mot de passe" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasseCreer" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
        </div>
        <div style="padding-top: 20px;">
            <asp:Label runat="server" ID="lblMotDePasseCreerConfirmation" Text="Confirmation" CssClass="labelLogin"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtMotDePasseCreerConfirmation" runat="server" CssClass="textBox" Width="400px" TextMode="Password"></asp:TextBox>
        </div>


        <div class="adresseLivraisonClient">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblAdresseLivraisonClient" Text="Adresse de livraison"></asp:Label>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblNoCiviqueLivraisonInformationClient" Text="Numéro civique" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtNoCiviqueClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblRueLivraisonInformationClient" Text="Rue" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtRueClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblCodePostalLivraisonInformationClient" Text="Code postal" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtCodePostalLivraisonInformationClient" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblPaysLivraisonInformationClient" Text="Pays" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="ddlPaysClient" runat="server" CssClass="dropDownList" Width="400px"></asp:DropDownList>
            </div>
        </div>
        <div class="adresseFacturationClient">
            <div class="titreDansPage">
                <asp:Label runat="server" ID="lblAdresseFacturationClient" Text="Adresse de facturation"></asp:Label>
                
            </div>
            <div>
                <asp:CheckBox runat="server" ID="chkUtiliserMemeAdresseQueLivraison"/>
                <asp:Label runat="server" ID="UtiliserMemeAdresseQueLivraison" Text="Utiliser la même adresse que celle de livraison" CssClass="labelLogin"></asp:Label>
            </div>
            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblNoCiviqueFacturationInformationClient" Text="Numéro civique" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblRueFacturationInformationClient" Text="Rue" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblCodePostalFacturationInformationClient" Text="Code postal" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            </div>

            <div style="padding-top: 20px;">
                <asp:Label runat="server" ID="lblPaysFacturationInformationClient" Text="Pays" CssClass="labelLogin"></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="ddlPaysInformationClient" runat="server" CssClass="dropDownList" Width="400px"></asp:DropDownList>
            </div>
        </div>

        <div style="padding-top: 20px;">
            <asp:Button runat="server" ID="btnEnregistrerInformationClient" Text="Enregistrer" CssClass="boutonActionRond" Width="400px"></asp:Button>
        </div>
    </div>
    <div class="HistoriqueCommandeClient">

        <div class="titreDansPage">
            <asp:Label runat="server" ID="lblHistoriqueDeVosCommandesInformationClient" Text="Historique de vos commandes"></asp:Label>
        </div>

        <div class="Table">
            <div class="Heading">
                <div class="Cell">
                    <asp:Label runat="server" ID="lblNoCommandeInformationClient" Text="No."></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblDateCommandeInformationClient" Text="Commandé le"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblEnvoyeLeInformationClient" Text="Envoyé le"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblGrandTotalInformationClient" Text="Grand total"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblNumeroExpeditionInformationClient" Text="Numéro d'expédition"></asp:Label>
                </div>
                <div class="Cell">
                    <asp:Label runat="server" ID="lblVisualiserInformationClient" Text="Visualiser"></asp:Label>
                </div>
            </div>
            <div class="Row">
                <div class="Cell">
                    <p>1</p>
                </div>
                <div class="Cell">
                    <p>2015-01-01</p>
                </div>
                <div class="Cell">
                    <p>2015-02-01</p>
                </div>
                <div class="Cell">
                    <p>$ 100.19</p>
                </div>
                <div class="Cell">
                    <p># 3462525522</p>
                </div>
                <div class="Cell">
                    <img src="Images/WebSite/Rechercher.png" />
                </div>
            </div>
             <div class="Row">
                <div class="Cell">
                    <p>1</p>
                </div>
                <div class="Cell">
                    <p>2015-01-01</p>
                </div>
                <div class="Cell">
                    <p>2015-02-01</p>
                </div>
                <div class="Cell">
                    <p>$ 100.19</p>
                </div>
                <div class="Cell">
                    <p># 3462525522</p>
                </div>
                <div class="Cell">
                    <img src="Images/WebSite/Rechercher.png" />
                </div>
            </div>
             <div class="Row">
                <div class="Cell">
                    <p>1</p>
                </div>
                <div class="Cell">
                    <p>2015-01-01</p>
                </div>
                <div class="Cell">
                    <p>2015-02-01</p>
                </div>
                <div class="Cell">
                    <p>$ 100.19</p>
                </div>
                <div class="Cell">
                    <p># 3462525522</p>
                </div>
                <div class="Cell">
                    <img src="Images/WebSite/Rechercher.png" />
                </div>
            </div>
             <div class="Row">
                <div class="Cell">
                    <p>1</p>
                </div>
                <div class="Cell">
                    <p>2015-01-01</p>
                </div>
                <div class="Cell">
                    <p>2015-02-01</p>
                </div>
                <div class="Cell">
                    <p>$ 100.19</p>
                </div>
                <div class="Cell">
                    <p># 3462525522</p>
                </div>
                <div class="Cell">
                    <img src="Images/WebSite/Rechercher.png" />
                </div>
            </div>
             <div class="Row">
                <div class="Cell">
                    <p>1</p>
                </div>
                <div class="Cell">
                    <p>2015-01-01</p>
                </div>
                <div class="Cell">
                    <p>2015-02-01</p>
                </div>
                <div class="Cell">
                    <p>$ 100.19</p>
                </div>
                <div class="Cell">
                    <p># 3462525522</p>
                </div>
                <div class="Cell">
                    <img src="Images/WebSite/Rechercher.png" />
                </div>
            </div>


        </div>

    </div>
    <div style="clear: both;"></div>
</asp:Content>
