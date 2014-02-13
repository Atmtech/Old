using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Achievement.Views.Interface
{
    public interface IAccomplissementPresenter : IViewBase
    {
        IList<Categorie> Categorie { set; }
        IList<Accomplissement> Accomplissement { set; }
        string idCategorieCourante { get; set; }
        IList<Accomplissement> AccomplissementAccompli { set; }
    }
}
