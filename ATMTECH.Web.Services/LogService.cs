using System;
using System.Xml.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;

using ATMTECH.Web.Services.Interface;
using System.Xml;

namespace ATMTECH.Web.Services
{
    public class LogService : BaseService, ILogService
    {
        public IDAOLogVisit DAOLogVisit { get; set; }
        public INavigationService NavigationService { get; set; }
        public IDAOLogException DAOLogException { get; set; }

        private User _authenticateUser;
        public User AuthenticateUser
        {
            get
            {
                if (ContextSessionManager.Session != null)
                {
                    if (ContextSessionManager.Session["Internal_LoggedUser"] != null)
                    {
                        return (User)ContextSessionManager.Session["Internal_LoggedUser"];
                    }
                    return null;
                }
                return _authenticateUser;
            }
            set
            {
                if (ContextSessionManager.Session != null)
                {
                    ContextSessionManager.Session["Internal_LoggedUser"] = value;
                }
                else
                {
                    _authenticateUser = value;
                }

            }
        }


        public LogVisit LogVisit()
        {
            try
            {
                LogVisit logVisit = new LogVisit();



                if (AuthenticateUser != null)
                {
                    logVisit.User = AuthenticateUser;
                }


                logVisit.Ip = ContextSessionManager.Context.Request.UserHostName;
                logVisit.Page = Utils.Web.Pages.GetCurrentPage();
                logVisit.DateCreated = DateTime.Now;

                if (logVisit.Ip != "127.0.0.1" && logVisit.Ip != "::1")
                {
                    String url = " http://freegeoip.net/xml/142.213.15.22";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(url);
                    logVisit.CountryName = doc.GetElementsByTagName("CountryName")[0].InnerText;
                    logVisit.CountryCode = doc.GetElementsByTagName("CountryCode")[0].InnerText;
                    logVisit.RegionName = doc.GetElementsByTagName("RegionName")[0].InnerText;
                    logVisit.RegionName = doc.GetElementsByTagName("CityName")[0].InnerText;
                }

                return logVisit;

            }
            catch
            {
            }
            return null;
        }

        public void LogException(Message message, System.Exception ex)
        {
            LogException logException = new LogException() { Description = message.Description + " " + ex.Message, InnerId = message.InnerId };
            if (AuthenticateUser != null)
            {
                logException.User = AuthenticateUser;
            }
            DAOLogException.CreateLog(logException);
        }

        public void LogException(Message message)
        {
            LogException logException = new LogException() { Description = message.Description, InnerId = message.InnerId };
            if (AuthenticateUser != null)
            {
                logException.User = AuthenticateUser;
            }
            DAOLogException.CreateLog(logException);
        }
    }
}
