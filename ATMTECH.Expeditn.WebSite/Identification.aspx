<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Identification.aspx.cs" Inherits="ATMTECH.Expeditn.WebSite.Identification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />


    <section class="mbr-section mbr-section--relative mbr-section--fixed-size" id="form1-11" style="background-color: rgb(239, 239, 239);">

        <div class="mbr-section__container mbr-section__container--std-padding container" style="padding-top: 93px; padding-bottom: 93px;">
            <div class="row">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2" data-form-type="formoid">
                            <div class="mbr-header mbr-header--center mbr-header--std-padding">
                                <h1 class="mbr-header__text">
                                    <asp:Label ID="lblIdentifiezVous" runat="server" Text="Vous n'êtes plus bien loin ..."></asp:Label></h1>
                                <p class="mbr-header__subtext">
                                    <asp:Label ID="lblIdentifiezVousAvecVotreCompte" runat="server" Text="Identifiez vous avec votre compte Expedit'n"></asp:Label><br>
                                </p>
                            </div>

                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtNomUtilisateur" placeholder="Courriel" TextMode="Email" CssClass="controlEditable"></asp:TextBox>
                            </div>
                            
                              <asp:TextBox runat="server" ID="txtMotPasse" placeholder="Mot de passe" class="controlEditable"></asp:TextBox>
                            <br />
                            <div class="mbr-buttons mbr-buttons--center btn-inverse">
                                <asp:Button runat="server" ID="lnkIdentifiezVous" Text="Se connecter" class="mbr-buttons__btn btn btn-standard" OnClick="lnkIdentifiezVousClick"></asp:Button><br />
                            </div>
                            <br />
                            <div class="mbr-buttons mbr-buttons--center btn-inverse">
                                <asp:Button runat="server" ID="lnkJAiOublieMonMotDePasse" Text="J'ai oublié mon mot de passe" class="mbr-buttons__btn btn btn-standard" OnClick="lnkIdentifiezVousClick"></asp:Button>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
