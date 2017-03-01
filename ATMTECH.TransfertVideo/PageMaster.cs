using System.Web.UI;

namespace ATMTECH.TransfertVideo
{
    public class PageMaster : Page
    {
        public string IdentifiantUnique
        {
            get
            {
                if (Session["IdentifiantUnique"] == null)
                {
                    Session["IdentifiantUnique"] = string.Empty;
                }
                return Session["IdentifiantUnique"].ToString();
            }
            set { Session["IdentifiantUnique"] = value; }
        }
    }
}