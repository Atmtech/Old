using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using ATMTECH.Common.Context;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.DTO;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class NavigationService : BaseService, INavigationService
    {


        public void Redirect(string page)
        {
            ContextSessionManager.Context.Response.Redirect(page);
        }

        public void Redirect(string page, IList<QueryString> queryString)
        {
            string queryStringTemp = string.Empty;

            foreach (QueryString s in queryString)
            {
                queryStringTemp += s.Name + "=" + s.Value + "&";
            }
            ContextSessionManager.Context.Response.Redirect(page + "?" + queryStringTemp);
        }



        private string CapitalizeFirst(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
        public CountryIp GetInformationIpInfoDb()
        {
            try
            {
                string ip = ContextSessionManager.Context.Request.UserHostName;
                if (ip != "127.0.0.1" && ip != "::1")
                {
                    
                    string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key=784b00c1233a988d47b6bfbfbd2fa55dc41279ec9781162bbe9d7ce36d001b0f&ip={0}", ip);
                    using (WebClient client = new WebClient())
                    {
                        string s = client.DownloadString(url);
                        string[] response = s.Split(';');
                        CountryIp countryIp = new CountryIp
                            {
                                Ip = ip,
                                CountryName = CapitalizeFirst(response[4]),
                                Region = CapitalizeFirst(response[5]),
                                City = CapitalizeFirst(response[6]),
                                PostalCode = response[7]
                            };
                        return countryIp;
                    }

                   
                }
            }
            catch (System.Exception)
            {


            }


            return null;

        }

        public void Refresh()
        {
            ContextSessionManager.Context.Response.Redirect(ContextSessionManager.Context.Request.RawUrl);
        }
        public void Refresh(IList<QueryString> queryStrings)
        {
            string queryStringTemp = queryStrings.Aggregate(string.Empty, (current, s) => current + (s.Name + "=" + s.Value + "&"));

            if (ContextSessionManager.Context.Request.RawUrl.IndexOf("?") == -1)
            {
                ContextSessionManager.Context.Response.Redirect(ContextSessionManager.Context.Request.RawUrl + "?" + queryStringTemp);
            }
            else
            {
                ContextSessionManager.Context.Response.Redirect(ContextSessionManager.Context.Request.RawUrl + queryStringTemp);
            }

        }
        public IList<QueryString> GetQueryString()
        {
            return QueryString.GetQueryString();
        }

        public string GetQueryStringValue(string key)
        {
            return QueryString.GetQueryStringValue(key);
        }
    }
}
