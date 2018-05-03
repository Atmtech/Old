using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ATMTECH.Vachier.WebSite
{
    public class PageBase : Page
    {
        public DAOLogger DAOLogger { get { return new DAOLogger(); } }
    }
}