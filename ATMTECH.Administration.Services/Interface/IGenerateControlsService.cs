using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Administration.Services.Interface
{
    public interface IGenerateControlsService
    {
        IList<PropertyWithLabel> ListeProprieteSansCelleSysteme(string nameSpace, string entity);

        IList<ControlWithLabel> CreateControls(string nameSpace, string entity, bool isInserting, int id,
                                               int idEnterprise);
    }
}
