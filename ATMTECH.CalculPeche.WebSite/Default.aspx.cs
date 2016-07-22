using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
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
                string html = "<table><tr>";
                List<DateTime> dateTimes = value.Select(x => x.Date).OrderBy(x => x.Date).Distinct().ToList();
                foreach (DateTime date in dateTimes)
                {
                    html += string.Format("<td style='vertical-align:top'><b><u>{0}</u></b><br>", date.ToShortDateString());
                    IList<ParticipantPresenceExpedition> participantPresenceExpeditions = value.Where(x => x.EstPresence && x.Date == date).ToList();
                    foreach (ParticipantPresenceExpedition participantPresenceExpedition in participantPresenceExpeditions)
                    {
                        html += string.Format("{0}<br>", participantPresenceExpedition.Participant.Nom);
                    }
                    html += "</td>";
                }
                html += "</tr>";
                html += "</table>";
                placeholderPresence.Controls.Add(new Literal { Text = html });
            }
        }
        public IList<ParticipantRepasExpedition> ParticipantRepasExpeditions
        {
            set
            {
                string html = "<table><tr>";
                List<DateTime> dateTimes = value.Select(x => x.Date).OrderBy(x => x.Date).Distinct().ToList();
                foreach (DateTime date in dateTimes)
                {
                    html += string.Format("<td style='vertical-align:top'><b><u>{0}</u></b><br>", date.ToShortDateString());
                    IList<ParticipantRepasExpedition> participantRepasExpeditions = value.Where(x => x.Date == date).ToList();
                    foreach (ParticipantRepasExpedition participantRepasExpedition in participantRepasExpeditions)
                    {
                        if (participantRepasExpedition.NombreRepas > 0)
                        {
                            html += string.Format("{0} : <b>{1}</b> <br>", participantRepasExpedition.Participant.Nom, participantRepasExpedition.NombreRepas);
                        }
                    }
                    html += "</td>";
                }
                html += "</tr>";
                html += "</table>";
                placeholderRepas.Controls.Add(new Literal { Text = html });
            }
        }
        public IList<ParticipantBateauExpedition> ParticipantBateauExpeditions
        {
            set
            {
                string html = "<table><tr>";
                List<DateTime> dateTimes = value.Select(x => x.Date).OrderBy(x => x.Date).Distinct().ToList();
                foreach (DateTime date in dateTimes)
                {
                    html += string.Format("<td style='vertical-align:top;'><b><u>{0}</u></b><br>", date.ToShortDateString());
                    IList<ParticipantBateauExpedition> participantBateauExpeditions = value.Where(x => x.EstBateau && x.Date == date).ToList();
                    foreach (ParticipantBateauExpedition participantBateauExpedition in participantBateauExpeditions)
                    {
                        html += string.Format("{0}<br>", participantBateauExpedition.Participant.Nom);
                    }
                    html += "</td>";
                }
                html += "</tr>";
                html += "</table>";
                placeholderBateau.Controls.Add(new Literal { Text = html });

            }
        }
        public IList<ParticipantExpedition> ParticipantExpeditions
        {
            set
            {
                string html = "<table><tr><th>Nom</th><th>Automobile</th><th>Propane</th><th>Bateau</th><th>Nourriture</th><th>Total<th></tr>";
                foreach (ParticipantExpedition participantExpedition in value)
                {
                    if (participantExpedition.Total > 0)
                    {
                        html += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", participantExpedition.Participant.Nom,
                            participantExpedition.MontantAutomobile.ToString("C"),
                            participantExpedition.MontantPropane.ToString("C"),
                            participantExpedition.MontantBateau.ToString("C"),
                            participantExpedition.MontantNourriture.ToString("C"),
                            participantExpedition.Total.ToString("C"));
                    }
                }

                html += string.Format("<tr style='border-top:double 1px gray;border-bottom:double 1px gray;font-weight:bold;'><td>Grand total:</td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><tr>",
                    value.Sum(x => x.MontantAutomobile).ToString("C"),
                    value.Sum(x => x.MontantPropane).ToString("C"),
                    value.Sum(x => x.MontantBateau).ToString("C"),
                    value.Sum(x => x.MontantNourriture).ToString("C"),
                    value.Sum(x => x.Total).ToString("C"));

                html += "</table>";

                placeholderArgent.Controls.Add(new Literal { Text = html });
            }
        }
        public IList<Repartition> Repartitions
        {
            set
            {
                string html = "<table><tr>" +
                                "<th>Nom</th>" +
                                "<th>% repas</th>" +
                                "<th>% présence</th>" +
                                "<th>% bateau</th>" +
                                "<th>% automobile</th>" +
                                "<th>Repas</th>" +
                                "<th>Automobile</th>" +
                                "<th>Bateau</th>" +
                                "<th>Propane</th>" +
                                "<th>Total</th>" +
                              "</tr>";
                foreach (Repartition repartition in value)
                {
                    html += String.Format("<tr>" +
                                        "<td>{0}</td>" +
                                        "<td>{1}/{2} = {3}%</td>" +
                                        "<td>{4}/{5} = {6}%</td>" +
                                        "<td>{7}/{8} = {9}%</td>" +
                                        "<td>{10}/{11} = {12}%</td>" +
                                        "<td>{13}</td>" +
                                        "<td>{14}</td>" +
                                        "<td>{15}</td>" +
                                        "<td>{16}</td>" +
                                        "<td>{17}</td>" +
                                          "</tr>",
                        repartition.Nom,
                        repartition.NombreRepas,
                        repartition.NombreTotalRepas,
                        Math.Round(repartition.PourcentageRepas * 100, 2),

                        repartition.NombrePresence,
                        repartition.NombreTotalJour,
                        Math.Round(repartition.PourcentagePropane * 100, 2),

                        repartition.NombreBateau,
                        repartition.NombreTotalSortieBateau,
                        Math.Round(repartition.PourcentageBateau * 100, 2),

                        repartition.NombreAutomobile,
                        repartition.NombreTotalAutomobile,
                        Math.Round(repartition.PourcentageAutomobile * 100, 2),

                        repartition.TotalRepas.ToString("C"),
                        repartition.TotalAutomobile.ToString("C"),
                        repartition.TotalBateau.ToString("C"),
                        repartition.TotalPropane.ToString("C"),
                        repartition.GrandTotal.ToString("C")
                        );
                }
                html += "</table>";
                placeholderRepartition.Controls.Add(new Literal { Text = html });
            }
        }
        public IList<MontantDu> MontantDus
        {
            set
            {
                string html = "<table style='width:400px;'>";
                foreach (MontantDu montantDu in value)
                {
                    html += string.Format("<tr>" +
                        "<td>{0}</td>" +
                        "<td>Doit</td>" +
                        "<td><b>{1}</b></td>" +
                        "<td>à {2}</td>" +
                        "</tr>",
                        montantDu.ParticipantPayeur.Nom,
                        montantDu.Montant.ToString("C"),
                        montantDu.ParticipantPaye.Nom
                        );
                }
                html += "</table>";

                placeHolderMontantDu.Controls.Add(new Literal { Text = html });
            }
        }
        public Expedition Expedition
        {
            set
            {
                string html = string.Format("<table>" +
                                            "<tr><td>Nom</td><td>{0}</td></tr>" +
                                            "<tr><td>Date début</td><td>{1}</td></tr>" +
                                            "<tr><td>Date fin</td><td>{2}</td></tr></table>", value.Nom, value.DateDebut, value.DateFin);
                placeholderGeneral.Controls.Add(new Literal { Text = html });
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
            Presenter.Rafraichir();
        }
    }
}