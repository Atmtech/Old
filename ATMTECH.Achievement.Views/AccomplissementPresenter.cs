using System;
using System.Linq;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class AccomplissementPresenter : BaseAccomplissementPresenter<IAccomplissementPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IAccomplissementService AccomplissementService { get; set; }

        public AccomplissementPresenter(IAccomplissementPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Categorie = AccomplissementService.ObtenirCategorieActive();
            View.AccomplissementAccompli = AccomplissementService.ObtenirListeAccomplissementAccompli();
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            if (!string.IsNullOrEmpty(View.idCategorieCourante))
            {
                ObtenirListeAccomplissementDeLaCategorie(Convert.ToInt32(View.idCategorieCourante));
            }
        }

        public void ObtenirListeAccomplissementDeLaCategorie(int idCategorie)
        {
            View.Accomplissement = AccomplissementService.ObtenirAccomplissementActifParCategorie(idCategorie);
        }

    }
}
