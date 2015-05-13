using System;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ContenuPresenter : BaseShoppingCartPresenter<IContenuPresenter>
    {
        public IEntrepriseService EntrepriseService { get; set; }
        public ContenuPresenter(IContenuPresenter view)
            : base(view)
        {
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherContenu();
        }
        public void AfficherContenu()
        {
            if (!string.IsNullOrEmpty(View.IdContenu))
            {
                int idEnterprise = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED));
                Enterprise enterprise = EntrepriseService.ObtenirEntreprise(idEnterprise);

                if (View.IdContenu == ((int)TypeContenu.Retour).ToString())
                {
                    View.Contenu = LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH ? enterprise.FrenchStep : enterprise.EnglishStep;
                    
                }
                if (View.IdContenu == ((int)TypeContenu.Livraison).ToString())
                {
                    View.Contenu = LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH ? enterprise.FrenchWelcome : enterprise.EnglishWelcome;
                    
                }
                if (View.IdContenu == ((int)TypeContenu.Condition).ToString())
                {
                    View.Contenu = LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH ? enterprise.FrenchInformation : enterprise.EnglishInformation;
                    
                }
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

    }

    public enum TypeContenu
    {
        Condition,
        Retour,
        Livraison
    }
}