using System;
using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.CalculPeche.Views;
using ATMTECH.CalculPeche.Views.Interface;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.WebSite
{
    public partial class Default : PageBase<AccueilPresenter, IAccueilPresenter>, IAccueilPresenter
    {
        public void ShowMessage(Message message)
        {
            //throw new NotImplementedException();
        }

        public IList<Expedition> Expeditions
        {
            set
            {
                FillDropDown(ddlExpedition, value, "Nom");
                ExpeditionSelectionne = ddlExpedition.SelectedValue;
            }
        }

        public IList<ParticipantPresenceExpedition> ParticipantPresenceExpeditions
        {
            set
            {
                grvPresence.DataSource = value; 
                grvPresence.DataBind();
            }
        }

        public IList<ParticipantRepasExpedition> ParticipantRepasExpeditions
        {
            set
            {
                grvRepas.DataSource = value;
                grvRepas.DataBind();
            }
        }
        public IList<ParticipantBateauExpedition> ParticipantBateauExpeditions
        {
            set
            {
                grvBateau.DataSource = value;
                grvBateau.DataBind();
            }
        }

        public string ExpeditionSelectionne
        {
            get { return Session["ExpeditionSelectionneId"].ToString(); }
            set { Session["ExpeditionSelectionneId"] = ddlExpedition.SelectedValue; }
        }

        protected void ddlExpeditionChanged(object sender, EventArgs e)
        {
            ExpeditionSelectionne = ddlExpedition.SelectedValue;
        }
    }
}