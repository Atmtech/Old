﻿using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
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
            else if (Message.MESSAGE_TYPE_ERROR == Message.MessageType)
            {
                pnlError.Visible = true;
                lblError.Text = Message.Description;
            }
            else
            {
                pnlError.Visible = true;
                lblError.Text = Message.Description;
            }
        }

       
    }
}