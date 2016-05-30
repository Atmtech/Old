using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ATMTECH.Web;

namespace ATMTECH.TransfertVideo
{
    public partial class Etape2 : System.Web.UI.Page
    {
        public string Guid { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid = QueryString.GetQueryStringValue("Guid");
        }

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            //string fichier = e.FileName;
            //string repertoire = Server.MapPath("/Video/");
            //AjaxFileUpload1.SaveAs(repertoire + fichier);
        }

        protected void btnRevenirClick(object sender, EventArgs e)
        {
            Response.Redirect("Etape1.aspx?guid=" + Guid);
        }
    }
}