﻿using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface.Francais
{
    public interface IPageMaitrePresenter : IViewBase
    {
        bool EstConnecte { set; }
        string NomUtilisateur { get; set; }
        string MotDePasse { get; set; }
    }
}