using System;
using System.Diagnostics;
using ATMTECH.Web;

namespace ATMTECH.Administration
{
    public class Global : BaseHttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Trace.Write("Avant Configure");
            Configure();
            Trace.Write("Apres Configure");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}