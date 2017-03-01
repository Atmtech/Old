<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformationGenerale.aspx.cs" Inherits="ATMTECH.TransfertVideo.InformationGenerale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="centerPanel">
        <h2>WRITE THE REQUIRED INFORMATIONS</h2>

        <table style="width: 400px;">
            <tr>
                <td>
                    <div class="label">Choose your Group</div>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlGroupe" AutoPostBack="True" CssClass="textBox">
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>74</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div class="label">Movie style</div>
                    <div>
                        <asp:DropDownList runat="server" ID="ddlStyle" AutoPostBack="True" CssClass="textBox">
                            <asp:ListItem>Comedy - Drama</asp:ListItem>
                            <asp:ListItem>Detective Story</asp:ListItem>
                            <asp:ListItem>Horror</asp:ListItem>
                            <asp:ListItem>Thriller</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>

        <br />

        <asp:Label runat="server" Text="The first student name is required !" ID="lblRequired" Visible="False" ForeColor="red"></asp:Label>
        <div class="label">
            Student name 1 (required)
        </div>
        <asp:TextBox runat="server" placeholder="Student name 1" class="textBox" ID="txtEtudiant1"></asp:TextBox><asp:Image runat="server" ImageUrl="~/Images/Message_Error.png" Visible="False" ID="imgError" />
        <br />
        <br />
        <div class="label">Student name 2</div>
        <asp:TextBox runat="server" placeholder="Student name 2" class="textBox" ID="txtEtudiant2"></asp:TextBox>
        <br />
        <br />
        <div class="label">Student name 3</div>
        <asp:TextBox runat="server" placeholder="Student name 3" class="textBox" ID="txtEtudiant3" ></asp:TextBox>
        <br />
        <br />
        <div class="label">Student name 4</div>
        <asp:TextBox runat="server" placeholder="Student name 4" class="textBox" ID="txtEtudiant4"></asp:TextBox>
        <br />
        <br />
        <div class="label">Student name 5</div>
        <asp:TextBox runat="server" placeholder="Student name 5" class="textBox" ID="txtEtudiant5" ></asp:TextBox>
        <br />
        <br />
        <div class="label">Student name 6</div>
        <asp:TextBox runat="server" placeholder="Student name 6" class="textBox" ID="txtEtudiant6"></asp:TextBox>

        <br />
        <br />
        <asp:Button runat="server" ID="btnSave" Text="UPLOAD YOUR MOVIE" CssClass="bouton" OnClick="btnSaveClick" />

    </div>
</asp:Content>
