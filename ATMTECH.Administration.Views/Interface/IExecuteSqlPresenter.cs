using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IExecuteSqlPresenter : IViewBase
    {
        string ReturnExecuteSql { set; }
    }
}
