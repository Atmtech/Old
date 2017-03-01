<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="ATMTECH.TransfertVideo.Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="centerPanelAdmin">

        <h2>TEACHER</h2>

        <asp:Panel runat="server" ID="pnlPasOk" Visible="True">
            <h3>Authentication</h3>
            <div class="label">Enter your password</div>
            <asp:TextBox runat="server" ID="txtPassword" placeholder="Password" class="textBox" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="btnValiderPassword" Class="bouton" OnClick="btnValiderPasswordClick" Text="SIGN IN" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlOk" Visible="False">
            Total movies received: <b>
                <asp:Label Text="text" runat="server" ID="lblTotal" /></b>
            <br />
            <br />

            <asp:GridView ID="GridViewMovie" runat="server" AutoGenerateColumns="False" GridLines="None" Width="100%"
                OnRowCommand="GridViewMovieRowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Group">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGroupe" Text='<%# Eval("Groupe")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date received">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDateModified" Text='<%# Eval("DateModified")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Students">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEtudiant1" Text='<%# Eval("Etudiant1") + ","  %>'></asp:Label>
                            <asp:Label runat="server" ID="lblEtudiant2" Text='<%# Eval("Etudiant2") + ","  %>'></asp:Label>
                            <asp:Label runat="server" ID="lblEtudiant3" Text='<%# Eval("Etudiant3") + ","  %>'></asp:Label>
                            <asp:Label runat="server" ID="lblEtudiant4" Text='<%# Eval("Etudiant4")  + "," %>'></asp:Label>
                            <asp:Label runat="server" ID="lblEtudiant5" Text='<%# Eval("Etudiant5")  + "," %>'></asp:Label>
                            <asp:Label runat="server" ID="lblEtudiant6" Text='<%# Eval("Etudiant6")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Movie style">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblStyle" Text='<%# Eval("Style")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Seen">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblVisionnee" Text='<%# Eval("Visionnee")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="File Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFileType" Text='<%# Eval("FileType")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnPlayer" Class="bouton" Text='View' CommandName="Player" CommandArgument='<%#Eval("Guid")%>' Visible='<%#Eval("EstVisionnable") %>'></asp:Button>
                            <asp:Button runat="server" ID="btnDownload" Class="bouton" CommandName="Download" CommandArgument='<%#Eval("Guid")%>' Text="Download"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="GridViewRow" VerticalAlign="Middle" />
                <HeaderStyle CssClass="GridViewHeader" ForeColor="#ffffff" VerticalAlign="Bottom" />
            </asp:GridView>
            

        </asp:Panel>
    </div>
</asp:Content>
