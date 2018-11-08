using System.Web;

namespace ATMTECH.StockGame.Services
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
