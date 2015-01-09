using System.Collections.Generic;
using ATMTECH.Common.Context;

namespace ATMTECH.Web
{
    public class QueryString
    {
        public const string PAGENAME = "PageName";

        public string Name { get; set; }
        public string Value { get; set; }

        public QueryString()
        {
        }

        public QueryString(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public static IList<QueryString> GetQueryString()
        {
            IList<QueryString> list = new List<QueryString>();
            foreach (string key in ContextSessionManager.Context.Request.QueryString.Keys)
            {
                QueryString queryString = new QueryString();
                queryString.Name = key;
                queryString.Value = ContextSessionManager.Context.Request.QueryString[key];
                list.Add(queryString);
            }
            return list;
        }
        public static string GetQueryStringValue(string key)
        {
            return ContextSessionManager.Context.Request.QueryString[key];
        }


    }
}
