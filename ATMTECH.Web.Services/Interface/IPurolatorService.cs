using System.Collections.Generic;

namespace ATMTECH.Web.Services.Interface
{
    public interface IPurolatorService
    {
        IList<PurolatorEstimateReturn> GetQuickEstimate(PurolatorPackage purolatorPackage, ConfigurationPurolatorWebService configuration);
    }
}
