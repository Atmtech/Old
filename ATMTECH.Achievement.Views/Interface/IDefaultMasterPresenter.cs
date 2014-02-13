using System.Collections.Generic;
using ATMTECH.Achievement.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Achievement.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        bool IsAuthenticated { set; }
        string NomUtilisateur { set; }
        string ImageUtilisateur { set; }
        IList<AccomplissementUtilisateur> AccomplissementUtilisateur { set; }
    }
}
