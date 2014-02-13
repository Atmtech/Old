using System.Collections.Generic;
using System.Reflection;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface ILookupPresenter : IViewBase
    {
         string IdValeur { get; set; }
         object EnterpriseList { set; }
         string Enterprise { get; }
    }
}
