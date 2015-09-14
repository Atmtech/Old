using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class CustomerInformation : PageBase<InformationClientPresenter, IInformationClientPresenter>,
                                               IInformationClientPresenter
    {
        public string Nom { get { return txtNom.Text; } set { txtNom.Text = value; } }
        public string Prenom { get { return txtPrenom.Text; } set { txtPrenom.Text = value; } }
        public string Courriel { get { return txtCourriel.Text; } set { txtCourriel.Text = value; } }
        public string MotPasse { get { return txtMotDePasse.Text; } set { txtMotDePasse.Text = value; } }
        public string MotPasseConfirmation { get { return txtMotDePasseConfirmation.Text; } set { txtMotDePasseConfirmation.Text = value; } }
        public string AdresseLongueLivraison
        {
            get { return adresseLivraison.AdresseLongue; }
            set { adresseLivraison.AdresseLongue = value; }
        }
        public string AdresseLongueFacturation
        {
            get { return adresseFacturation.AdresseLongue; }
            set { adresseFacturation.AdresseLongue = value; }
        }
        public string CodePostalLivraison
        {
            get { return adresseLivraison.CodePostal; }
            set { adresseLivraison.CodePostal = value; }
        }
        public bool EstAucuneAdresseLivraison { get; set; }
        public bool EstAucuneAdresseFacturation { get; set; }
        public IList<Order> ListeCommandePasse
        {
            set
            {
                lblAucuneCommandePasseACeJour.Visible = value.Count == 0;
                foreach (Order order in value)
                {
                    string html = "<div class='Row'><div class='Cell'><p>{0}</p></div><div class='Cell'><p>{1}</p></div><div class='Cell'><p>{2}</p></div><div class='Cell'><p>{3}</p></div><div class='Cell'><p>{4}</p></div><div class='Cell'><a href='" + Pages.THANK_YOU_ORDER + "?" + PagesId.ORDER_ID + "={5}'><img src='Images/WebSite/Rechercher.png' width='16px' height='16px' /></a></div></div>";
                    if (order.FinalizedDate != null)
                    {
                        DateTime dateFinalise = (DateTime)order.FinalizedDate;
                        html = string.Format(html, order.Id, dateFinalise.ToString("yyyy-MM-dd HH:mm tt"), order.ShippingDate == null ? "N/A" : order.ShippingDate.ToString(), order.GrandTotal.ToString("c"),
                            order.TrackingNumber ?? "N/A", order.Id);
                        Literal literal = new Literal { Text = html };
                        placeHolderListeCommandePasse.Controls.Add(literal);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtMotDePasse.Attributes["value"] = txtMotDePasse.Text;
            txtMotDePasseConfirmation.Attributes["value"] = txtMotDePasseConfirmation.Text;
        }

        protected void btnEnregistrerInformationClientClick(object sender, EventArgs e)
        {
            Presenter.Enregistrer();
        }
        protected void btnUtiliserMemeAdresseQueLivraisonClick(object sender, EventArgs e)
        {
            AdresseLongueFacturation = AdresseLongueLivraison;
            Presenter.Enregistrer();
        }
        protected void btnChangerMotDePasseClick(object sender, EventArgs e)
        {
            Presenter.EnregistrerMotPasse();
        }
        protected void btnJeVeuxChangerMonMotDePasseClick(object sender, EventArgs e)
        {
            pnlChangerMotDePasse.Visible = true;
            btnJeVeuxChangerMonMotDePasse.Visible = false;
        }
    }
}