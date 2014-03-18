<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CsharpEditor.aspx.cs" Inherits="ATMTECH.Administration.CsharpEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="HighlightCode.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" style="height: 98%">
                <tr>
                    <td style="width: 50%; font-size: 12px">
                        <strong>Please paste the code in textbox control and choose the language before clicking
                    the HighLight button </strong>
                    </td>
                    <td style="width: 50%; font-size: 12px">
                        <strong>Result: </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:UpdatePanel runat="server" ID="test">
                            <ContentTemplate>
                                Please choose the language:<asp:DropDownList ID="ddlLanguage" runat="server">
                                    <asp:ListItem Value="-1">-Please select-</asp:ListItem>
                                    <asp:ListItem Value="cs">C#</asp:ListItem>
                                    <asp:ListItem Value="vb">VB.NET</asp:ListItem>
                                    <asp:ListItem Value="js">JavaScript</asp:ListItem>
                                    <asp:ListItem Value="vbs">VBScript</asp:ListItem>
                                    <asp:ListItem Value="sql">Sql</asp:ListItem>
                                    <asp:ListItem Value="css">CSS</asp:ListItem>
                                    <asp:ListItem Value="html">HTML/XML</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                please paste your code here:<asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <br />
                                <asp:TextBox ID="tbCode" runat="server" TextMode="MultiLine" Height="528px" Width="710px" OnTextChanged="textChangedClick" AutoPostBack="True"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnHighLight" runat="server" Text="HighLight" OnClick="btnHighLight_Click" /><asp:Label
                                    ID="lbError" runat="server" Text="Label" ForeColor="Red"></asp:Label>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <div id="DivCode">
                            <asp:Label ID="lbResult" runat="server" Text=""></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
