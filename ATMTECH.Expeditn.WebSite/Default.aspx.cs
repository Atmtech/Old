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
                    //foreach (Expedition expedition in value)
                    //{
                    //    string html = string.Empty;
                    //    html+= "<section class='3u 6u(medium) 12u$(xsmall) profile'>";
                    //    html += "</section>";
                    //}
                    //  <section class="3u 6u(medium) 12u$(xsmall) profile">
                    //    <img src="http://fabricetremblay.ca/perso/TCAT/04.jpg" alt="" />
                    //    <h4>Labrieville 2015</h4>
                    //    <p>2015-01-01</p>
                    //</section>
                }

                

            }
        }
    }
}