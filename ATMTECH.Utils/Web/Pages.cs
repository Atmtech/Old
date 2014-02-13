using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ATMTECH.Common.Context;
using System.Web;

namespace ATMTECH.Utils.Web
{
    public class Pages
    {
        public static string HtmlDecode(string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        public static string GetCurrentHttpServer()
        {
            string port = ContextSessionManager.Context.Request.ServerVariables["SERVER_PORT"];
            string protocol = ContextSessionManager.Context.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (!String.IsNullOrEmpty(port))
            {
                port = ":" + port;
            }

            if (protocol == "" || protocol == "0")
            {
                protocol = "http://";
            }
            else
            {
                protocol = "https://";
            }

            return protocol + ContextSessionManager.Context.Request.ServerVariables["SERVER_NAME"] + port;
        }
        public static string GetCurrentUrl()
        {
            string port = ContextSessionManager.Context.Request.ServerVariables["SERVER_PORT"];
            string protocol = ContextSessionManager.Context.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (!String.IsNullOrEmpty(port))
            {
                port = ":" + port;
            }

            if (protocol == "" || protocol == "0")
            {
                protocol = "http://";
            }
            else
            {
                protocol = "https://";
            }

            return protocol + ContextSessionManager.Context.Request.ServerVariables["SERVER_NAME"] + port +
                   ContextSessionManager.Context.Request.ApplicationPath;
        }
        public static string GetCurrentPage()
        {
            string temp = ContextSessionManager.Context.Request.ServerVariables["URL"];
            int tempLength = temp.Length;
            return temp.Substring(1, tempLength - 1);
        }

        public static IEnumerable<T> GetControlsOfType<T>(Control root) where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as Control;
            if (container != null)
                foreach (var i in from Control c in container.Controls from i in GetControlsOfType<T>(c) select i)
                    yield return i;
        }


        public static Control FindControlRecursive(Control container, string name)
        {
            if ((container.ID != null) && (container.ID.Equals(name)))
                return container;

            return (from Control ctrl in container.Controls select FindControlRecursive(ctrl, name)).FirstOrDefault(foundCtrl => foundCtrl != null);
        }
      
        public static string RemoveHtmlTag(string html)
        {
            char[] array = new char[html.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < html.Length; i++)
            {
                char let = html[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
