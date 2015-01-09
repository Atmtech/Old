using System;
using System.Configuration;
using System.Web;
using ATMTECH.DAO.SessionManager;

namespace ATMTECH.Web
{
    public class HttpModuleSessionManager : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += ApplicationBeginRequest;
            context.EndRequest += ApplicationEndRequest;
            context.Error += ApplicationError;
        }

        public void Dispose()
        {
        }

        private void ApplicationBeginRequest(object sender, EventArgs e)
        {
            if (IsPageAspx(sender))
            {
                DatabaseSessionManager.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            }
        }

        private void ApplicationEndRequest(object sender, EventArgs e)
        {
            if (IsPageAspx(sender))
            {
                if (DatabaseSessionManager.Session != null)
                    DatabaseSessionManager.Session.Close();
            }
        }

        private void ApplicationError(object sender, EventArgs e)
        {
            if (IsPageAspx(sender))
            {

            }
        }

        private bool IsPageAspx(object sender)
        {
            return ((HttpApplication)sender).Request.Url.AbsolutePath.EndsWith(".aspx");
        }
    }
}
