using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Administration.Services.Interface
{
    public interface IGenerateControlsService
    {
        IList<PropertyWithLabel> ListeProprieteSansCelleSysteme(string nameSpace, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties);

        IList<ControlWithLabel> CreateControls(string nameSpace, string entity, bool isInserting, int id,
                                               int idEnterprise, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties  );
    }
}
