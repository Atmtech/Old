using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public class PageMaitreBase<TPresenter, TView> : MasterPage
        where TView : class, IViewBase
        where TPresenter : BaseExpeditnPresenter<TView>
    {
        public TPresenter Presenter { get; set; }
        public void ShowMessage(Message message)
        {
            Session["MessageEnvoye"] = message;
            Response.Redirect("Error.aspx");
        }
        public void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection) where T : Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);

                if (control.HasControls())
                    GetControlList(control.Controls, resultCollection);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                Localiser();
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        private bool EstExclus(string id)
        {
            if (id == "lblPrixAvant") return true;
            if (id == "lblPrixActuel") return true;
            if (id == "lblPrixMaintenant") return true;
            if (id == "lblPrixVente") return true;
            if (id == "lblNomProduit") return true;
            if (id == "lblVentes") return true;
            if (id == "lblDescription") return true;
            if (id == "lblIdentProduit") return true;
            if (id == "lblPrixUnitaire") return true;
            if (id == "lblSousTotal") return true;
            if (id == "lblTaxeProvinciale") return true;
            if (id == "lblTaxeFederale") return true;
            if (id == "lblCoutLivraison") return true;
            if (id == "lblGrandTotal") return true;
            if (id == "lblAdresseLivraison") return true;
            if (id == "lblAdresseFacturation") return true;
            if (id == "lblPrixUnitairePaye") return true;
            if (id == "lblIdent") return true;
            if (id == "btnNomClient") return true;
            if (id == "btnPanier") return true;
            if (id == "lblError") return true;
            if (id == "lblSuccess") return true;
            if (id == "lblCaracteristique") return true;
            if (id == "lblPrixAjuste") return true;
            if (id == "lblPrixEpargner") return true;
            if (id == "lblNumeroCommande") return true;
            if (id == "lblContenu") return true;
            if (id == "lblGrandTotalApresCoupon") return true;
            if (id == "lblCouponValeur") return true;
            if (id == "lblAffichageCommande") return true;
            if (id == "lblMarque") return true;
            if (id == "lblNombreElement") return true;
            if (id == "lblMarque") return true;
            if (id == "lblPrixOriginal") return true;
            if (id == "lblVersion") return true;

            return false;
        }
        private void Localiser()
        {
            string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
            if (absoluteUri.IndexOf("localhost") > 0)
            {
                IList<Localization> localizations = new List<Localization>();
                List<Control> allControls = new List<Control>();
                GetControlList(Page.Controls, allControls);
                foreach (Control control in allControls)
                {
                    Localization localization = new Localization();

                    if (EstExclus(control.ID)) continue;
                    if (control is GridView)
                    {
                        for (int i = 0; i < (control as GridView).Columns.Count - 1; i++)
                        {
                            localization.ObjectId = (control as GridView).ID + "[" + i + "]";
                            localization.French = (control as GridView).ID + "[" + i + "]";
                            localization.English = (control as GridView).ID + "[" + i + "]";
                            localizations.Add(localization);
                        }
                    }
                    else
                    {
                        if (control is Label)
                        {
                            localization.ObjectId = control.ID;
                            localization.French = (control as Label).Text.Replace(" (*Loc)", "");
                            localization.English = (control as Label).Text.Replace(" (*Loc)", "(en)");
                            localizations.Add(localization);
                        }
                        if (control is Button)
                        {
                            localization.ObjectId = control.ID;
                            localization.French = (control as Button).Text.Replace(" (*Loc)", "");
                            localization.English = (control as Button).Text.Replace(" (*Loc)", "(en)");
                            localizations.Add(localization);
                        }

                        if (control is TextBox)
                        {
                            if (!string.IsNullOrEmpty((control as TextBox).Attributes["placeholder"]))
                            {
                                localization.ObjectId = control.ID;
                                localization.French = (control as TextBox).Attributes["placeholder"];
                                localization.English = (control as TextBox).Attributes["placeholder"] + "(en)";
                                localizations.Add(localization);
                            }

                            if (!string.IsNullOrEmpty((control as TextBox).ToolTip))
                            {
                                localization.ObjectId = control.ID;
                                localization.French = (control as TextBox).ToolTip;
                                localization.English = (control as TextBox).ToolTip;
                                localizations.Add(localization);
                            }
                        }
                    }
                }



                Presenter.SaveLocalization(localizations);
            }
        }
    }
}