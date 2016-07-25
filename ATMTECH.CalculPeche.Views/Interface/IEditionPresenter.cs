using System;
using ATMTECH.Views.Interface;

namespace ATMTECH.CalculPeche.Views.Interface
{
    public interface IEditionPresenter : IViewBase
    {
        string NomEntite { get; }
        string CritereRecherche { get; set; }
        Object ValeurRetrouve { set; }
        int NombreValeurRetrouve { set; }
        int ValeurId { get; set; }
      //  Enterprise Entreprise { get;  }
        //string Entity { get; }
        //string NameSpace { get; }
        //object EnterpriseList { set; }
        //string Enterprise { get; }
        //string InnerTitle { set; }
        //string IsEnterpriseRuled { get; }

        //bool IsInserting { get; set; }
        //int? IdCopy { set; }

        

        //IList<EntityInformation> EntityInformations { get; set; }
        //IList<EntityProperty> EntityProperties { get; set; }


    }
}
