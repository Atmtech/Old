using System;
using System.Web.UI.WebControls;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Achievement.WebSite.Base
{
    public class PageBaseAchievement<TPresenter, TView> : PageBase
        where TView : class, IViewBase
        where TPresenter : BaseAccomplissementPresenter<TView>
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
            //FenetreDialogue window = (FenetreDialogue)Master.FindControl("windowMessage");
            //TitreLabelAvance titreLabelAvance = (Label)window.FindControl("lblError");

            //window.Titre = message.Title;
            //titreLabelAvance.Text = message.Description;
            //window.OuvrirFenetre();

            Label lblError = (Label)Master.FindControl("lblError");
            lblError.Text = message.Description;
        }

    }


}