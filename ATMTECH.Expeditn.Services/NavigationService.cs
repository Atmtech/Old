using System.Net;
using System.Web;

namespace ATMTECH.Expeditn.Services
{
   public class NavigationService : BaseService
    {
        public void RafraichirPage()
        {
            HttpRequest currentRequest = HttpContext.Current.Request;
            HttpContext.Current.Response.Redirect(currentRequest.Url.ToString());
        }
    }
}
