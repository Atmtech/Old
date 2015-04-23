using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Commerce
{
    public class PageMaitreBase<TPresenter, TView> : MasterPage
        where TView : class, IViewBase
        where TPresenter : BaseAdministrationPresenter<TView>
    {
        public TPresenter Presenter { get; set; }

        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {

                Panel panel = (Panel)FindControl("pnlSuccess");
                Label literal = (Label)FindControl("lblSuccess");
                literal.Text = message.Description;
                panel.Visible = true;

            }
            else
            {

                Panel panel = (Panel)FindControl("pnlError");
                Label literal = (Label)FindControl("lblError");
                literal.Text = message.Description;
                panel.Visible = true;

            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
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



            return false;
        }

    }
}