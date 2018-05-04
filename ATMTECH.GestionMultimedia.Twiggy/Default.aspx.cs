using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.GestionMultimedia.Twiggy
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveClick(object sender, EventArgs e)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(txtUrl.Text, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (txtUrl.Text.ToLower().IndexOf("youtube.com", StringComparison.Ordinal) >= 0 ||
                txtUrl.Text.ToLower().IndexOf("dailymotion.com", StringComparison.Ordinal) >= 0 ||
                txtUrl.Text.ToLower().IndexOf("vimeo.com", StringComparison.Ordinal) >= 0)
            {



                if (result)
                {
                    new DAOGestionMultimediaTwiggy().AjouterMultimedia(txtNoGroupe.Text, txtStudents.Text, txtVideoStyle.Text, txtUrl.Text);
                    pnlInformation.Visible = false;
                    pnlThankYou.Visible = true;
                }
                else
                {
                    lblInvalideUrl.Visible = true;
                }
            }
            else
            {
                lblInvalideUrl.Visible = true;
            }


        }
    }
}