using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Achievement.Views.Interface
{
    public interface IProposerPresenter : IViewBase
    {
        string Titre { get; }
        string Description { get; }
        IList<string> ListeCodeTraits { get; }
        string Image { get; }
        string Couleur { get; }
        string Categorie { get; }

        IList<File> Fichier { set; }
        IList<Trait> Traits { set; }
        IList<string> Couleurs { set; }
        IList<Categorie> Categories { set; }
    }
}
