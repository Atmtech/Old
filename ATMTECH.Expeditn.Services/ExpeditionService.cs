using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Expeditn.Entites;

namespace ATMTECH.Expeditn.Services
{
    public class ExpeditionService : BaseService
    {
        public void Enregistrer(Expedition expedition)
        {
            if (EstValideExpedition(expedition))
                DAOExpedition.Enregistrer(expedition);
        }
        public IList<Expedition> Obtenir()
        {
            return DAOExpedition.Obtenir();
        }

        public Expedition Obtenir(string id)
        {
            return DAOExpedition.Obtenir(id);
        }

        public IList<Expedition> ObtenirMesExpedition(Utilisateur utilisateur)
        {
            IList<Expedition> expeditions = DAOExpedition.Obtenir();
            return expeditions.Where(x => x.ListeUtilisateur.Any(z => z.Id == utilisateur.Id)).ToList();
        }

        public void Enregistrer(Activite activite)
        {
            DAOActivite.Enregistrer(activite);
        }

        public void Enregistrer(Depense depense)
        {
            DAODepense.Enregistrer(depense);
        }

        private decimal ObtenirMontant(Expedition expedition, Utilisateur utilisateur, string typeActivite)
        {
            Depense depense = expedition.ListeDepense.FirstOrDefault(x =>
                x.Utilisateur.Id == utilisateur.Id && x.TypeActivite == typeActivite);
            return depense == null ? 0 : Convert.ToDecimal(depense.Montant);
        }

        private decimal ObtenirSommeMontant(Expedition expedition, Utilisateur utilisateur)
        {
            if (expedition.ListeDepense != null)
                return Convert.ToDecimal(expedition.ListeDepense.Where(x => x.Utilisateur.Id == utilisateur.Id).Sum(x => Convert.ToDecimal(x.Montant)));
            return 0;
        }

        private decimal ObtenirSommeMontant(Expedition expedition, string typeActivite)
        {
            if (expedition.ListeDepense != null)
                return expedition.ListeDepense.Where(x => x.TypeActivite == typeActivite).Sum(x => Convert.ToDecimal(x.Montant));
            return 0;
        }
        private decimal ObtenirSommeMontant(Expedition expedition)
        {
            if (expedition.ListeDepense != null)
                return Convert.ToDecimal(expedition.ListeDepense.Sum(x => Convert.ToDecimal(x.Montant)));
            return 0;
        }

        private string ObtenirHeaderTypeDepense(Expedition expedition, string suffixeEntete)
        {
            string html = string.Empty;

            foreach (string depense in ObtenirListeTypeActiviteDepense(expedition))
            {
                html += "<th> " + suffixeEntete + depense + "</th>" + Environment.NewLine;
            }
            return html;
        }

        private List<string> ObtenirListeTypeActiviteDepense(Expedition expedition)
        {
            if (expedition.ListeDepense != null)
                return expedition.ListeDepense.GroupBy(x => x.TypeActivite).ToList().Select(activiteGroupe => activiteGroupe.Key).ToList();
            return new List<string>();
        }

        private int ObtenirNombreTotalPresenceActivite(Expedition expedition, string typeActivite)
        {
            int i = 0;
            foreach (Activite activite in expedition.ListeActivite)
            {
                if (activite.TypeActivite == typeActivite)
                {
                    if (activite.ListeUtilisateur != null)
                    {
                        i += activite.ListeUtilisateur.Count();
                    }
                }
            }
            return i;
        }

        public string GenererAffichageDepense(Expedition expedition)
        {
            if (expedition.ListeDepense == null) return string.Empty;
            string html = "<h2> Dépenses par participants</h2>";

            string htmlDepenseParParticipant = "<TABLE class='table table-dark table-hover table-striped'>";
            htmlDepenseParParticipant += "<thead>" + Environment.NewLine;
            htmlDepenseParParticipant += "<th>Participants</th>" + Environment.NewLine;
            htmlDepenseParParticipant += "{0}";
            htmlDepenseParParticipant += "<th>($) Total</th>" + Environment.NewLine;
            htmlDepenseParParticipant += "</thead>" + Environment.NewLine;
            htmlDepenseParParticipant += "<tbody>" + Environment.NewLine;
            htmlDepenseParParticipant += "{1}";
            htmlDepenseParParticipant += "<tr><td>Grand Total:</td>{2}";
            htmlDepenseParParticipant += "<td>{3}</td>";
            htmlDepenseParParticipant += "</tr>";
            htmlDepenseParParticipant += "</tbody>" + Environment.NewLine;
            htmlDepenseParParticipant += "</TABLE>";


            string htmlListeDepense = string.Empty;
            foreach (Utilisateur utilisateur in expedition.ListeUtilisateur)
            {
                htmlListeDepense += "<tr><td>" + utilisateur.Affichage + "</td>" + Environment.NewLine;
                foreach (string typeActivite in ObtenirListeTypeActiviteDepense(expedition))
                {
                    htmlListeDepense += "<td>" + string.Format("{0:C}", ObtenirMontant(expedition, utilisateur, typeActivite)) + "</td>" + Environment.NewLine;
                }
                htmlListeDepense += "<td>" + string.Format("{0:C}", ObtenirSommeMontant(expedition, utilisateur)) + "</td>" + Environment.NewLine;
                htmlListeDepense += "</tr>" + Environment.NewLine;
            }

            string htmlSommeTotalTypeDepense = string.Empty;
            foreach (string s in ObtenirListeTypeActiviteDepense(expedition))
            {
                htmlSommeTotalTypeDepense += "<td>" + string.Format("{0:C}", ObtenirSommeMontant(expedition, s)) + "</td>";
            }
            html += string.Format(htmlDepenseParParticipant, ObtenirHeaderTypeDepense(expedition, "($) "), htmlListeDepense, htmlSommeTotalTypeDepense, string.Format("{0:C}", ObtenirSommeMontant(expedition)));

            html += "<h2> Répartitions des dépenses</h2>";

            string htmlRepartitionDepenseParParticipant = "<TABLE class='table table-dark table-hover table-striped'>";
            htmlRepartitionDepenseParParticipant += "<thead>" + Environment.NewLine;
            htmlRepartitionDepenseParParticipant += "<th>Participants</th>" + Environment.NewLine;
            htmlRepartitionDepenseParParticipant += "{0}";
            htmlRepartitionDepenseParParticipant += "<th>($) Total</th>" + Environment.NewLine;
            htmlRepartitionDepenseParParticipant += "</thead>" + Environment.NewLine;
            htmlRepartitionDepenseParParticipant += "<tbody>" + Environment.NewLine;
            htmlRepartitionDepenseParParticipant += "{1}";
            htmlRepartitionDepenseParParticipant += "<tr>";
            htmlRepartitionDepenseParParticipant += "<td>Grand Total:</td>{2}";
            htmlRepartitionDepenseParParticipant += "<td>{3}</td>";
            htmlRepartitionDepenseParParticipant += "</tr>";
            htmlRepartitionDepenseParParticipant += "</tbody>" + Environment.NewLine;
            htmlRepartitionDepenseParParticipant += "</TABLE>";

            string htmlListeRepartitionDepense = string.Empty;
            decimal montantTotalRepartitionDepense = 0;

            Dictionary<Utilisateur, decimal> montantUtiliseActivite = new Dictionary<Utilisateur, decimal>();
            foreach (Utilisateur utilisateur in expedition.ListeUtilisateur)
            {
                decimal montantTotalDuUtilisateur = 0;
                htmlListeRepartitionDepense += "<tr><td>" + utilisateur.Affichage + "</td>" + Environment.NewLine;
                foreach (string typeActivite in ObtenirListeTypeActiviteDepense(expedition))
                {
                    int nombreTotalPresenceActivite = ObtenirNombreTotalPresenceActivite(expedition, typeActivite);
                    int nombrePresenceUtilisateurActivite = 0;
                    foreach (Activite activite in expedition.ListeActivite.Where(x => x.TypeActivite == typeActivite))
                    {
                        if (activite.ListeUtilisateur != null)
                        {
                            if (activite.ListeUtilisateur.Any(x => x.Id == utilisateur.Id))
                            {
                                nombrePresenceUtilisateurActivite++;
                            }
                        }
                    }
                    decimal pourcentage = Math.Round((Convert.ToDecimal(nombrePresenceUtilisateurActivite) /
                                    Convert.ToDecimal(nombreTotalPresenceActivite)), 2);
                    decimal montantDu = ObtenirSommeMontant(expedition, typeActivite) * pourcentage;
                    htmlListeRepartitionDepense += "<td>" + nombrePresenceUtilisateurActivite + "/" + nombreTotalPresenceActivite + " :: " + pourcentage * 100 + " % :: " + string.Format("{0:C}", montantDu) + "</td>" + Environment.NewLine;
                    montantTotalDuUtilisateur += montantDu;
                }
                montantTotalRepartitionDepense += montantTotalDuUtilisateur;
                montantUtiliseActivite.Add(utilisateur, montantTotalDuUtilisateur);
                htmlListeRepartitionDepense += "<td>" + string.Format("{0:C}", montantTotalDuUtilisateur) + "</td>" + Environment.NewLine;
                htmlListeRepartitionDepense += "</tr>" + Environment.NewLine;
            }

            string htmlSommeTotalTypeDepenseRepartition = string.Empty;
            foreach (string s in ObtenirListeTypeActiviteDepense(expedition))
            {
                htmlSommeTotalTypeDepenseRepartition += "<td></td>";
            }

            html += string.Format(htmlRepartitionDepenseParParticipant, ObtenirHeaderTypeDepense(expedition, "(% / $) "), htmlListeRepartitionDepense, htmlSommeTotalTypeDepenseRepartition, string.Format("{0:C}", montantTotalRepartitionDepense));


            html += "<h2> Montant dû entre les participants</h2> ";

            string htmlMontantDu = "<TABLE class='table table-dark table-hover table-striped'>";
            htmlMontantDu += "<thead>" + Environment.NewLine;
            htmlMontantDu += "<th>Participants</th>" + Environment.NewLine;
            htmlMontantDu += "</thead>" + Environment.NewLine;
            htmlMontantDu += "<tbody>" + Environment.NewLine;
            htmlMontantDu += "{0}";
            htmlMontantDu += "</tbody>" + Environment.NewLine;
            htmlMontantDu += "</TABLE>";

            Utilisateur utilisateurQuiALePlusDepenser = expedition.ListeDepense
                .FirstOrDefault(x => Convert.ToDecimal(x.Montant) == expedition.ListeDepense.Max(z => Convert.ToDecimal(z.Montant))).Utilisateur;
            string htmlMontantDuTd = string.Empty;
            foreach (KeyValuePair<Utilisateur, decimal> keyValuePair in montantUtiliseActivite)
            {
                if (keyValuePair.Key.Id != utilisateurQuiALePlusDepenser.Id)
                {
                    decimal devoir = keyValuePair.Value - ObtenirSommeMontant(expedition, keyValuePair.Key);
                    htmlMontantDuTd += "<tr><td>" + keyValuePair.Key.Affichage + "</td><td>Doit</td><td>" + string.Format("{0:C}", devoir) + "</td><td>" + utilisateurQuiALePlusDepenser.Affichage + "</td></tr>";
                }
            }
            html += string.Format(htmlMontantDu, htmlMontantDuTd);



            return html;
        }

        private bool EstValideExpedition(Expedition expedition)
        {
            return true;
        }
    }

}