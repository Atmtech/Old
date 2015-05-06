using System;
using System.Linq;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class ExpeditionPage : PageBase<ExpeditionPresenter, IExpeditionPresenter>, IExpeditionPresenter
    {
        public int IdExpedition
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.EXPEDITION)); }
        }
        public Expedition Expedition
        {
            set
            {
                txtTitreExpedition.Text = value.Nom;
                txtDateDebut.Text = value.DateDebut.ToString();
                txtDateFin.Text = value.DateFin.ToString();
                txtPays.Text = value.Pays;
                txtRegion.Text = value.Region;
                txtdescriptionExpedition.Text = value.Description;
                lblBudget.Text = string.Format("{0:C}", value.Budget);

                dataListeParticipant.DataSource = value.Participant.OrderByDescending(x=>x.EstAdministrateurExpedition);
                dataListeParticipant.DataBind();

                dataListEtape.DataSource = value.Etape;
                dataListEtape.DataBind();
            }
        }
    }
}