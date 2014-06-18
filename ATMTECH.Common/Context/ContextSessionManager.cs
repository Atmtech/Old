using System.Web;
using System.Web.SessionState;

namespace ATMTECH.Common.Context
{
    public static class ContextSessionManager
    {
        public static HttpSessionState Session
        {
            get
            {
                bool isHttpContext = HttpContext.Current != null;
                return isHttpContext ? HttpContext.Current.Session : null;
            }
        }


        public static HttpContext Context
        {
            get
            {
                bool isHttpContext = HttpContext.Current != null;
                return isHttpContext ? HttpContext.Current : null;
            }
        }




    }
}
