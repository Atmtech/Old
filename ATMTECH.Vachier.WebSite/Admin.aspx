<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ATMTECH.Vachier.WebSite.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAjouterInsulte" runat="server" Text="Ajouter une insulte" OnClick="btnAjouterInsulteOnClick" />
            <asp:Button ID="btnAfficherInsulte" runat="server" Text="Afficher les insultes" OnClick="btnAfficherInsulteOnClick" />
            

            <asp:Button ID="btnConvertir" runat="server" Text="Convertir les insultes" OnClick="btnConvertirOnClick" />
           <br/> <asp:TextBox runat="server" id="txtConnectionString" Text="server=ATMTECH\SQLEXPRESS2012;Initial Catalog=Vachier;Integrated security=SSPI;Trusted_Connection=True;MultipleActiveResultSets=True;Pooling=false;" style="width: 100%;"></asp:TextBox>
            
            <br/>
            <asp:Button ID="btnDrop" runat="server" Text="Effacer collection insultes" OnClick="btnDropOnClick" />
            <asp:Button ID="btnDropLocalisation" runat="server" Text="Effacer collection Localisation" OnClick="btnDropLocalisationOnClick" />

            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            
            <asp:Button ID="btnAfficherProchain" runat="server" Text="Afficher prochaine" OnClick="btnAfficherProchainOnClick" />
        </div>
    </form>
</body>
</html>
