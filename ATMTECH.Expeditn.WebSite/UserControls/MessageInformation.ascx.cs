using System;
using System.Web.UI;

namespace ATMTECH.Expeditn.WebSite.UserControls
{
    public partial class MessageInformation : UserControl
    {
        public string Message { get; set; }
        public bool EstVisible { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessageInformation.Text = Message;
            pnlMessageInformation.Visible = EstVisible;
        }
    }
}