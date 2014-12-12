using System;
using System.Net.Mail;
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
        public IDAOLogMail DAOLogMail { get; set; }

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


        public void LogVisit()
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
                logVisit.Url = ContextSessionManager.Context.Request.Url.AbsoluteUri;

                if (logVisit.Ip != "127.0.0.1" && logVisit.Ip != "::1")
                {
                    String url = "http://freegeoip.net/xml/" + logVisit.Ip;
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(url);
                        logVisit.CountryName = doc.GetElementsByTagName("CountryName")[0].InnerText;
                        logVisit.CountryCode = doc.GetElementsByTagName("CountryCode")[0].InnerText;
                        logVisit.RegionName = doc.GetElementsByTagName("RegionName")[0].InnerText;
                        logVisit.CityName = doc.GetElementsByTagName("City")[0].InnerText;
                        logVisit.Latitude = doc.GetElementsByTagName("Latitude")[0].InnerText;
                        logVisit.Longitude = doc.GetElementsByTagName("Longitude")[0].InnerText;
                    }
                    catch (System.Exception)
                    {

                        logVisit.Description = "Erreur log: " + url;
                    }


                    DAOLogVisit.UpdateLogVisit(logVisit);
                }
            }
            catch (System.Exception exception)
            {
                //LogException(new Message() { Description = "Erreur fatale dans LogVisit: ", InnerId = "ADM0001" }, exception);
            }
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

        public void LogMail(MailMessage mailMessage)
        {
            DAOLogMail.CreateLog(mailMessage);
        }
    }
}
