﻿using ATMTECH.Entities;
using ATMTECH.Web;

namespace ATMTECH.Scrum.WebSite
{
    public class PageBaseScrum : PageBase
    {

        public void ShowMessage(Message message)
        {
            //FenetreDialogue window = (FenetreDialogue)Master.FindControl("windowMessage");
            //TitreLabelAvance titreLabelAvance = (TitreLabelAvance) window.FindControl("lblMessage");

            //window.Titre = message.Title;
            //titreLabelAvance.Text = message.Description;
            //window.OuvrirFenetre();
        }

    }


}