<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" Inherits="ATMTECH.StockGame.Site.TableauBord" MaintainScrollPositionOnPostback="true" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
    $(function () {
        $("[id$=txtRecherche]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/TableauBord.aspx/ObtenirSymbole") %>',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    error: function (response) {
                       // alert(response.responseText);
                    },
                    failure: function (response) {
                        //alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("[id$=txtSymbole]").val(i.item.val);
            },
            minLength: 1
        });
    });
</script>


    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>



    <div class=" bg-white text-dark py-3 text-left px-3">
        <ol class="breadcrumb text-uppercase">
            <li class="breadcrumb-item active">Tableau de bord</li>
        </ol>

        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label1" class="font-weight-bold" Text="Information générales" />
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="table table-dark table-hover table-striped">
                                    <tr>
                                        <td>Solde</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblSolde"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Nombre total de titre en possession</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblNombreTotalTitrePossession"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Rang parmis les autres investisseurs</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblRang"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Commission du courtier sur achat et vente</td>
                                        <td>
                                            <asp:Label runat="server" ID="lblCommission"></asp:Label></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <a href="Classement.aspx" class="btn btn-success font-weight-bold">Accéder au classement</a>



                    </div>
                </div>
            </div>

            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="lblTitreAchete" class="font-weight-bold" Text="Acheter un titre" />
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col">
                                <label class="col-form-label">Rechercher un symbole</label>
                                
                                <asp:TextBox ID="txtRecherche" runat="server" Class="form-control  bg-dark text-white" placeholder="Rechercher un symbole" />
                                <label class="col-form-label">Symbole associé à l'entreprise</label>
                                <asp:TextBox ID="txtSymbole" runat="server"  Class="form-control  bg-dark text-white" ReadOnly="True"/>
                                <br />
                                <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnRechercherTitre" Text="Rechercher" OnClick="btnRechercherTitre_OnClick" UseSubmitBehavior="False" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col">
                                <asp:Panel runat="server" Visible="False" ID="pnlResultatRecheche">
                                    <table class="table table-dark table-hover table-striped">
                                        <tr>
                                            <td>Logo</td>
                                            <td>
                                                <asp:Image runat="server" ID="imgLogo"></asp:Image></td>
                                        </tr>

                                        <tr>
                                            <td>Valeur actuelle</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblValeurActuelleRecherche"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Symbole</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSymboleRecherche"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Nom</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblNomRecherche"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Derniere date transaction</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDateDerniereTransactionRecherche"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Pourcentage de variation par rapport à l'ouverture</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPourcentageVariationOuvertureRecherche"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Valeur à l'ouverture</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblValeurOuvertureRecherche"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Bourse</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblNomBourseRecherche"></asp:Label>$</td>
                                        </tr>

                                    </table>
                                    <label class="col-form-label">Nombre</label>

                                    <asp:TextBox runat="server" class="form-control  bg-dark text-white" ID="txtNombre" placeholder="Nombre" required="true" />
                                    <br/>
                                    <asp:Button runat="server" class="btn btn-success font-weight-bold" ID="btnAcheterTitre" Text="Passer cet ordre" OnClick="btnAcheterTitre_OnClick" />
                                </asp:Panel>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label2" class="font-weight-bold" Text="Mes titres en possessions" />
                    </div>
                    <div class="card-body">

                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="table table-dark table-hover table-striped table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Nom</th>
                                            <th>Code</th>
                                            <th>Bourse</th>
                                            <th>Date achat</th>
                                            <th>Date dernière transaction</th>
                                            <th>Valeur à l'ouverture</th>
                                            <th>Valeur à l'achat</th>
                                            <th>Valeur actuelle</th>
                                            <th>Variation (%)</th>
                                            <th>Nombre acheté</th>
                                            <th>Valeur achat totale</th>
                                            <th>Valeur actuelle totale</th>
                                            <th>Commission achat</th>
                                            <th>Profit</th>
                                            <th></th>
                                        </tr>
                                    </thead>

                                    <asp:Repeater runat="server" ID="repeaterMesTitres" OnItemCommand="repeaterMesTitres_OnItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="">
                                                    <asp:Label runat="server" ID="Label8" Text='<%# Eval("Nom").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label4" Text='<%# Eval("Code").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label22" Text='<%# Eval("Bourse").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label5" Text='<%# Eval("DateAchat").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label28" Text='<%# Eval("DateDerniereTransaction").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label25" Text='<%# Eval("ValeurOuverture", "{0:c}").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label6" Text='<%# Eval("ValeurAchat", "{0:c}").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label7" Text='<%# Eval("ValeurActuelle", "{0:c}").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label9" Text='<%# Convert.ToDecimal( Eval("PourcentageVariationEntreFermetureEtActuel")).ToString("P")  %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label10" Text='<%# Eval("Nombre").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label16" Text='<%# Eval("ValeurAchatTotale", "{0:c}") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label11" Text='<%# Eval("ValeurActuelleTotale", "{0:c}") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label21" Text='<%# Eval("CommissionAchat", "{0:c}") %>'></asp:Label></td>
                                                <td style="width: 100px;">
                                                    <asp:Label runat="server" ID="Label20" Text='<%# Eval("Profit", "{0:c}") %>' ForeColor='<%# Convert.ToDecimal( Eval("Profit")) > 0 ? System.Drawing.Color.GreenYellow : System.Drawing.Color.Red %>'></asp:Label></td>
                                                <td>
                                                    <asp:Button runat="server" ID="btnEnlever" Text="Vendre" class="btn btn-success btn-sm" CommandName="vendre" CommandArgument='<%# Eval("Id")  %>' UseSubmitBehavior="False" />
                                                </td>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>

            </div>
        </div>

        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label23" class="font-weight-bold" Text="Mes ordres en cours" />
                    </div>
                    <div class="card-body">
                        <table class="table table-dark table-hover table-striped table-condensed">
                            <thead>
                                <tr>
                                    <th>Nom</th>
                                    <th>Code</th>
                                    <th>Valeur achat</th>
                                    <th>Valeur actuelle</th>
                                    <th>Profit</th>
                                    <th>Valeur minimal pour vendre ($)</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <asp:Repeater runat="server" ID="repeaterOrdre" OnItemCommand="repeaterOrdre_OnItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("Nom").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label24" Text='<%# Eval("Code").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label26" Text='<%# Eval("ValeurAchat", "{0:c}").ToString() %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="Label20" Text='<%# Eval("ValeurActuelle", "{0:c}") %>'></asp:Label></td>
                                        <td style="width: 100px;">
                                            <asp:Label runat="server" ID="Label27" Text='<%# Eval("Profit", "{0:c}") %>' ForeColor='<%# Convert.ToDecimal( Eval("Profit")) > 0 ? System.Drawing.Color.GreenYellow : System.Drawing.Color.Red %>'></asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtValeurOrdre" Text='<%# Eval("ValeurOrdrePourVendre") %>' Class="form-control  bg-dark text-white" Style="width: 150px;"></asp:TextBox></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnEnregistrer" Text="Enregistrer ordre" class="btn btn-success btn-sm" CommandName="Ordre" CommandArgument='<%# Eval("Id")  %>' UseSubmitBehavior="False" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </table>
                    </div>
                </div>

            </div>
        </div>

        <div class="form-group row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-uppercase font-weight-bold">
                        <asp:Label runat="server" ID="Label3" class="font-weight-bold" Text="Mes titres vendus" />
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table class="table table-dark table-hover table-striped table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Nom</th>
                                            <th>Code</th>
                                            <th>Date achat</th>
                                            <th>Valeur à l'achat</th>
                                            <th>Valeur vendu</th>
                                            <th>Nombre</th>
                                            <th>Commission </th>
                                            <th>Profit </th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater runat="server" ID="repeaterTitreVendu">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="Label8" Text='<%# Eval("Nom").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label12" Text='<%# Eval("Code").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label13" Text='<%# Eval("DateAchat").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label14" Text='<%# Eval("ValeurAchat", "{0:c}") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label15" Text='<%# Eval("ValeurVendu", "{0:c}") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label17" Text='<%# Eval("Nombre").ToString() %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label18" Text='<%# Eval("CommissionVendu", "{0:c}") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label runat="server" ID="Label19" Text='<%# ((Convert.ToDecimal(Eval("ValeurVendu")) * Convert.ToInt32(Eval("Nombre"))) - (Convert.ToDecimal(Eval("ValeurAchat"))  * Convert.ToInt32(Eval("Nombre"))) - Convert.ToDecimal(Eval("CommissionVendu").ToString())).ToString("C") %>'></asp:Label></td>
                                            </tr>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
