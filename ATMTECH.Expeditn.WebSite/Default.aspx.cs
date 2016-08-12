using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Default1 : PageBase<AccueilPresenter, IAccueilPresenter>, IAccueilPresenter
    {
        public IList<Expedition> Expeditions
        {
            set
            {
                if (value != null)
                {
                    listeExpedition.DataSource = value;
                    listeExpedition.DataBind();
                }
            }
        }
    }
}