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
                if (isHttpContext)
                {
                    return HttpContext.Current.Session;
                }
                else
                {
                    return null;
                }
            }
        }
        public static HttpContext Context
        {
            get
            {
                bool isHttpContext = HttpContext.Current != null;
                if (isHttpContext)
                {
                    return HttpContext.Current;
                }
                else
                {
                    return null;
                }
            }
        }

        
    }
}
