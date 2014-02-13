using System;
using ATMTECH.Web;

namespace ATMTECH.Template.WebSite
{
    public class Global : BaseHttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError().GetBaseException();
            DisplayFatalError(exception);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}