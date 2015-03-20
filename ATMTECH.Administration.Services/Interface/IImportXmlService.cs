using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.Administration.Services.Interface
{
    public interface IImportXmlService
    {
        void ImportProductAndStockXml(Enterprise enterprise, string fileXml);
        IList<string> DisplayColor(Enterprise enterprise, string fileXml);
    }
}
