<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="OpenTrip.aspx.cs" Inherits="ATMTECH.FishingAtWork.WebSite.OpenTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlOpenTripGridView">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblTitleNewTrip" Text="Liste de vos journées de pêches"></asp:Label>
        </div>
        <atmtech:GrilleAvance ID="grdTripList" GridLines="None" runat="server" Visible="true"
            TypeName="ATMTECH.FishingAtWork.Views.OpenTripPresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
            EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.Trip"
            EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
            AEnteteAffiche="True" SelectMethod="GetTrip" SelectCountMethod="GetTripCount"
            MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
            SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
            ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
            PagerSettings="TopAndBottom" PageSize="30" OnRowCommand="RowCommandClick">
            <columns>
           
                        <asp:TemplateField HeaderText="Titre de la journée">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                         <asp:TemplateField HeaderText="Site">
                        <ItemTemplate>
                                <asp:Label runat="server" ID="lblSiteName" Text='<%#Eval("Site.Name")%>'></asp:Label>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Latitude">
                        <ItemTemplate>
                              <div style="text-align: center;">   <asp:Label runat="server" ID="lblLatitude" Text='<%#Eval("Site.Latitude")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                        <asp:TemplateField HeaderText="Longitude">
                        <ItemTemplate>
                                <div style="text-align: center;"> <asp:Label runat="server" ID="lblLongitude" Text='<%#Eval("Site.Longitude")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            

                           <asp:TemplateField HeaderText="Départ">
                        <ItemTemplate>
                               <div style="text-align: center;"> <asp:Label runat="server" ID="lblDateStart" Text='<%#Eval("DateStart","{0:yyyy-MM-dd}")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                           <asp:TemplateField HeaderText="Fin">
                        <ItemTemplate>
                              <div style="text-align: center;">  <asp:Label runat="server" ID="lblDateEnd" Text='<%#Eval("DateEnd","{0:yyyy-MM-dd}")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Waypoint(s)"  >
                            <ItemTemplate>
                                <div style="text-align: center;font-weight: bold;"> <asp:Label runat="server" ID="lblWaypoint" Text='<%#Eval("WaypointCount")%>'></asp:Label> / 
                                 <asp:Label runat="server" ID="lblMaximumWaypoint" Text='<%#Eval("Player.MaximumWaypoint")%>'></asp:Label>  
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Capture(s)"  >
                            <ItemTemplate>
                                <div style="text-align: center;font-weight: bold;"> 
                                0
                                </div>  
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                             <div style="text-align: center;">  <asp:ImageButton runat="server" CommandName="OpenTrip" ID="btnOpenTrip" AlternateText="Ouvrir une journée de pêche" ImageUrl="Images/loupe.png" CommandArgument='<%#Eval("Id")%>'></asp:ImageButton></div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
        </atmtech:GrilleAvance>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlTripDetail" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="Label1" Text="Le détail de la journée de pêche sélectionnée"></asp:Label>
        </div>
        <table>
            <tr>
                <td valign="top">
                    <table>
                        <tr>
                            <atmtech:ComboBoxAvance runat="server" ID="ddlSite" Libelle="Site sélectionné" AutoPostBack="True"
                                ModeAffichage="Consultation" />
                        </tr>
                        <tr>
                            <atmtech:TextBoxAvance runat="server" ID="txtName" Libelle="Description" Width="400px"
                                EstObligatoire="True" />
                        </tr>
                        <tr>
                            <atmtech:DateTextBoxAvance runat="server" ID="txtDateStart" Libelle="Date début" />
                        </tr>
                        <tr>
                            <atmtech:DateTextBoxAvance runat="server" ID="txtDateEnd" Libelle="Date fin" ModeAffichage="Consultation" />
                        </tr>
                        <tr>
                            <atmtech:TextBoxAvance runat="server" ID="txtWayPoint" Libelle="Points de navigation"
                                ModeAffichage="Consultation" />
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <div style="width: 200px; vertical-align: top; margin-bottom: 10px; margin-right: 10px;
                        border: solid 1px gray;">
                        <div style="background-color: gainsboro;">
                            <table>
                                <tr>
                                    <td>
                                        <img src="Images/Main/bulletFish.png" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblName" CssClass="siteName"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <atmtech:GoogleMap ID="googleMapThumbnailWindow" runat="server" IsThumbnail="True" />
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <atmtech:GrilleAvance ID="grdWaypointList" GridLines="None" runat="server" Visible="true"
            TypeName="ATMTECH.FishingAtWork.Views.OpenTripPresenter" DataKeyNames="Id" EstAfficheColonneEdition="False"
            EstAfficheColonneSuppression="false" ActiverBoutonAjout="false" DataObjectTypeName="ATMTECH.FishingAtWork.Entities.Waypoint"
            EstPermiPagination="true" EstPermiTri="true" APiedPageAffiche="False" MessageAucuneDonnee="Aucun."
            AEnteteAffiche="True" SelectMethod="GetWaypoint" SelectCountMethod="GetwaypointCount"
            MaximumRowsParameterName="nbEnreg" StartRowIndexParameterName="indexDebutRangee"
            SortParameterName="parametreTrie" EstBoutonConsulterAsynchrone="true" ToolTipBoutonAjout="Ajouter"
            ToolTipBoutonConsulter="Consulter" ToolTipBoutonSupprimer="Supprimer" ToujoursRafraichir="true"
            PagerSettings="TopAndBottom" PageSize="30" OnRowCommand="WaypointRowCommandClick">
            <columns>
           
                        <asp:TemplateField HeaderText="Leurre">
                        <ItemTemplate>
                                <center><asp:Label runat="server" ID="lblLure" Text='<%#Eval("Lure.Name")%>'></asp:Label></center>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Technique">
                        <ItemTemplate>
                               <center> <asp:Label runat="server" ID="lblTechnique" Text='<%#Eval("TechniqueName")%>'></asp:Label></center>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Profondeur">
                        <ItemTemplate>
                               <center> <asp:Label runat="server" ID="lblDeep" Text='<%#Eval("Deep")%>'></asp:Label></center>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Départ">
                        <ItemTemplate>
                               <center> <asp:Label runat="server" ID="lblHourStart" Text='<%#Eval("DateStart","{0:t}")%>'></asp:Label></center>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Fin">
                        <ItemTemplate>
                               <center> <asp:Label runat="server" ID="lblHourEnd" Text='<%#Eval("DateEnd","{0:t}")%>'></asp:Label></center>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Latitude">
                        <ItemTemplate>
                              <div style="text-align: center;">   <asp:Label runat="server" ID="Label2" Text='<%#Eval("Latitude")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                        <asp:TemplateField HeaderText="Longitude">
                        <ItemTemplate>
                                <div style="text-align: center;"> <asp:Label runat="server" ID="Label3" Text='<%#Eval("Longitude")%>'></asp:Label></div>
                         </ItemTemplate>
                        </asp:TemplateField>
            
                        <asp:TemplateField>
                            <ItemTemplate>
                             <div style="text-align: center;">  <asp:ImageButton runat="server" CommandName="OpenWaypoint" ID="ImageButton1" AlternateText="Ouvrir waypoint" ImageUrl="Images/loupe.png" CommandArgument='<%#Eval("Id")%>'></asp:ImageButton></div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </columns>
        </atmtech:GrilleAvance>
        <div class="toolbar">
            <asp:Button runat="server" ID="btnSave" Text="Enregistrer" OnClick="SaveClick" CausesValidation="True"
                CssClass="button" />
            <asp:Button runat="server" ID="btnAddWaypoint" Text="Ajouter un point de navigation"
                OnClick="AddWaypointClick" CausesValidation="False" CssClass="button" />
            <asp:Button runat="server" ID="btnCancel" Text="Annuler" OnClick="CancelClick" CausesValidation="False"
                CssClass="button" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlEditWayPoint" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="Label4" Text="Modifier les informations du waypoint"></asp:Label>
        </div>
        <table>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlLure" Libelle="Leurre utilisé" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlTechnique" Libelle="Technique utilisé" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlDeep" Libelle="Profondeur" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlTimeStart" Libelle="Heure de début" />
            </tr>
            <tr>
                <atmtech:ComboBoxAvance runat="server" ID="ddlTimeEnd" Libelle="Heure de fin" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="Latitude"
                    ID="txtLatitude" />
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="X" ID="txtPixelX"
                    Visible="False" />
            </tr>
            <tr>
                <atmtech:TextBoxAvance ID="txtLongitude" runat="server" ModeAffichage="Consultation"
                    Libelle="Longitude" />
                <atmtech:TextBoxAvance runat="server" ModeAffichage="Consultation" Libelle="Y" ID="txtPixelY"
                    Visible="False" />
            </tr>
        </table>
        <div class="toolbar">
            <asp:Button runat="server" ID="Bouton1" Text="Enregistrer" OnClick="SaveWaypointClick"
                CssClass="button" />
            <asp:Button runat="server" ID="Bouton3" Text="Modifier les coordonnées" OnClick="ChangeWayPointClick"
                CssClass="button" />
            <asp:Button runat="server" ID="Bouton2" Text="Annuler" OnClick="CancelToWayPointClick"
                CssClass="button" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlSelectWaypoint" Visible="False">
        <div class="headerWizard">
            <asp:Label runat="server" ID="lblTitleSelect" Text="Sélectionner une position de pêche en double cliquant sur la carte"></asp:Label>
        </div>
        <atmtech:GoogleMap ID="googleMap" runat="server" />
    </asp:Panel>
</asp:Content>
