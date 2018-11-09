<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATMTECH.Pass.WebSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        (function () {

            'use strict';

            // click events
            document.body.addEventListener('click', copy, true);

            // event handler
            function copy(e) {

                // find target element
                var
                  t = e.target,
                  c = t.dataset.copytarget,
                  inp = (c ? document.querySelector(c) : null);

                // is element selectable?
                if (inp && inp.select) {

                    // select text
                    inp.select();

                    try {
                        // copy text
                        document.execCommand('copy');
                        inp.blur();
                    }
                    catch (err) {
                        alert('please press Ctrl/Cmd+C to copy');
                    }

                }

            }

        })();
    </script>





    <div class="panneau">
        <h2>Bienvenue,
            <asp:Label runat="server" ID="lblNomUtilisateur"></asp:Label>&nbsp;<asp:Button runat="server" ID="btnDeconnecte" OnClick="btnDeconnecteClick" Text="Déconnecter" CssClass="boutonAction" /></h2>

        <table>
            <asp:Repeater runat="server" ID="datalistePass">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="label1" Text='<%# Eval("Emplacement")  %>'></asp:Label></td>
                        <td>

                            <input type="text" id='<%# Eval("Emplacement")  %>' value='<%# Eval("MotDePasse")  %>' style="border: none; background-color: transparent; color: transparent" />
                            <button data-copytarget='#<%# Eval("Emplacement")  %>' class="boutonAction">Copier</button>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>
