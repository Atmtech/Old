using System;
using ATMTECH.Entities;
using ATMTECH.Template.Views.Base;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Template.WebSite.Base
{
    public class PageBaseTemplate<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseTemplatePresenter<TView>
    {
        public TPresenter Presenter { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        }

        public void ShowMessage(Message message)
        {
            FenetreDialogue window = (FenetreDialogue)Master.FindControl("windowMessage");
            TitreLabelAvance titreLabelAvance = (TitreLabelAvance)window.FindControl("lblMessage");

            window.Titre = message.Title;
            titreLabelAvance.Text = message.Description;
            window.OuvrirFenetre();
        }

    }


}