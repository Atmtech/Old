using System;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Error : PageBase<ErreurPresenter, IErreurPresenter>, IErreurPresenter
    {
        public Message Message
        {
            get { return ((Message)Session["MessageEnvoye"]); }
            set { Session["MessageEnvoye"] = value; }
        }

        public void AfficherMessage()
        {
            if (Message.MESSAGE_TYPE_SUCCESS == Message.MessageType)
            {
                pnlSuccess.Visible = true;
                lblSuccess.Text = Message.Description;
            }
            if (Message.MESSAGE_TYPE_ERROR == Message.MessageType)
            {
                pnlError.Visible = true;
                lblError.Text = Message.Description;
            }
        }

        protected void btnRetourAccueilClick(object sender, EventArgs e)
        {
            Presenter.RetourAccueil();
        }
    }
}