using System;
using System.Web.UI;

namespace ATMTECH.TransfertVideo
{
    public partial class Site : MasterPage
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUploadClick(object sender, EventArgs e)
        {
           Session["IdentifiantUnique"] = string.Empty;
          Response.Redirect("InformationGenerale.aspx");
        }

        protected void btnTeacherClick(object sender, EventArgs e)
        {
            Response.Redirect("Administration.aspx");
        }
    }
}