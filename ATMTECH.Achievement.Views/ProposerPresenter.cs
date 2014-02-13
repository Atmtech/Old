using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.DAO.Interface;
using ATMTECH.Web.Services.Interface;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Achievement.Views
{
    public class ProposerPresenter : BaseAccomplissementPresenter<IProposerPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IAccomplissementService AccomplissementService { get; set; }
        public IDAOFile DAOFile { get; set; }

        public ProposerPresenter(IProposerPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            RemplirListeImage();
            RemplirListeCategorie();
            RemplirListeCouleur();
        }

        private void RemplirListeCategorie()
        {
            View.Categories = AccomplissementService.ObtenirCategorieActive();
        }

        public void RemplirListeTrait()
        {
            View.Traits = AccomplissementService.ObtenirTrait();
        }
        public void RemplirListeImage()
        {
            View.Fichier = AccomplissementService.ObtenirListeFichierBadge();
        }

        public void RemplirListeCouleur()
        {

            string[] allColors = Enum.GetNames(typeof(KnownColor));
            string[] systemEnvironmentColors = new string[(typeof(SystemColors)).GetProperties().Length];
            int index = 0;
            foreach (PropertyInfo member in (typeof(SystemColors)).GetProperties())
            {
                systemEnvironmentColors[index++] = member.Name;
            }
            View.Couleurs = allColors.Where(color => Array.IndexOf(systemEnvironmentColors, color) < 0).ToList();
        }

        public void RetournerAccueil()
        {
            NavigationService.Redirect(Pages.Pages.DISCUSSION);
        }

        public Accomplissement GenererAccomplissementDuWizard()
        {
            Accomplissement accomplissement = new Accomplissement
                {
                    Titre = View.Titre,
                    Description = View.Description,
                    Categorie = AccomplissementService.ObtenirCategorieParCode(View.Categorie),
                    Couleur = View.Couleur,
                    ProposePar = AuthenticationService.AuthenticateUser
                };

            File file = DAOFile.GetFileByFileName(Path.GetFileName(View.Image));
            accomplissement.Image = file;
            accomplissement.AccomplissementTraits = new List<AccomplissementTrait>();

            foreach (string codeTrait in View.ListeCodeTraits)
            {
                Trait trait = AccomplissementService.ObtenirTraitParCode(codeTrait);
                AccomplissementTrait accomplissementTrait = new AccomplissementTrait
                    {
                        Trait = trait,
                        Accomplissement = accomplissement
                    };
                accomplissement.AccomplissementTraits.Add(accomplissementTrait);
            }

            return accomplissement;
        }
        public void CreerAccomplissement()
        {
            AccomplissementService.Creer(GenererAccomplissementDuWizard());
            NavigationService.Redirect(Pages.Pages.DISCUSSION);
        }
    }
}
