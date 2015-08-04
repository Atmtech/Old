using System;
using System.Web.UI;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.WebSite.UserControls
{
    public partial class MessageInformation : UserControl
    {

        public Message Message
        {
            set
            {
                if (value != null)
                {
                    if (value.MessageType == Message.MESSAGE_TYPE_ERROR)
                    {
                        pnlMessageInformationErreur.Visible = true;
                        lblMessageInformationErreur.Text = value.Description;
                        return;
                    }

                    if (value.MessageType == Message.MESSAGE_TYPE_SUCCESS)
                    {
                        pnlMessageInformationSucces.Visible = true;
                        lblMessageInformationSucces.Text = value.Description;
                        return;
                    }
                }

                pnlMessageInformationErreur.Visible = false;
                pnlMessageInformationSucces.Visible = false;
            }
        }
    }
}