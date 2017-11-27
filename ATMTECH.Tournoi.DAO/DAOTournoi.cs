using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMTECH.Tournoi.Entites;

namespace ATMTECH.Tournoi.DAO
{
    public class DAOTournoi : BaseDAO
    {
        private static Random rng = new Random();

        public IList<MatchSerie> ObtenirMatchSerie(Serie serie)
        {
            DataSet matchSerie = ObtenirDonneesMssql("SELECT * FROM MatchSerie WHERE Serie = " + serie.Id + " order by ronde");
            IList<MatchSerie> matchSeries = new List<MatchSerie>();
            IList<Equipe> equipes = ObtenirEquipe();
            
            foreach (DataRow dataRow in matchSerie.Tables[0].Rows)
            {
                MatchSerie match = new MatchSerie
                {
                    Serie = serie,
                    Id = (int)dataRow["Id"],
                    Local = equipes.FirstOrDefault(x => x.Id == (int)dataRow["Local"]),
                    Visiteur = equipes.FirstOrDefault(x => x.Id == (int)dataRow["Visiteur"]),
                    NombreButLocalMatch1 = (int)dataRow["NombreButLocalMatch1"],
                    NombreButLocalMatch2 = (int)dataRow["NombreButLocalMatch2"],
                    NombreButLocalMatch3 = (int)dataRow["NombreButLocalMatch3"],
                    NombreButVisiteurMatch1 = (int)dataRow["NombreButVisiteurMatch1"],
                    NombreButVisiteurMatch2 = (int)dataRow["NombreButVisiteurMatch2"],
                    NombreButVisiteurMatch3 = (int)dataRow["NombreButVisiteurMatch3"],
                    Message = dataRow["Message"].ToString(),
                    Ronde = Convert.ToInt32(dataRow["Ronde"].ToString())
                };
                matchSeries.Add(match);
            }
            return matchSeries;
        }
        public IList<MatchSaison> ObtenirMatchSaisonReguliere(Saison saison)
        {
            DataSet matchSaison = ObtenirDonneesMssql("SELECT * FROM MatchSaison WHERE Saison = " + saison.Id);
            IList<MatchSaison> matchSaisons = new List<MatchSaison>();
            IList<Equipe> equipes = ObtenirEquipe();
            Equipe equipeNull = new Equipe { Id = 0, Nom = "Aucun" };
            foreach (DataRow dataRow in matchSaison.Tables[0].Rows)
            {
                MatchSaison match = new MatchSaison
                {
                    Id = (int)dataRow["Id"],
                    Date = (DateTime)dataRow["Date"],
                    Gagnant = equipes.FirstOrDefault(x => x.Id == (int)dataRow["Gagnant"]),
                    Perdant = equipes.FirstOrDefault(x => x.Id == (int)dataRow["Perdant"]),
                    Local = equipes.FirstOrDefault(x => x.Id == (int)dataRow["Local"]),
                    Visiteur = equipes.FirstOrDefault(x => x.Id == (int)dataRow["Visiteur"]),
                    NombreButGagnant = (int)dataRow["NombreButGagnant"],
                    NombreButPerdant = (int)dataRow["NombreButPerdant"],
                    NombrePointGagnant = (int)dataRow["NombrePointGagnant"],
                    NombrePointPerdant = (int)dataRow["NombrePointPerdant"],
                    PerteEnSurtemps = (int)dataRow["PerteEnSurtemps"],
                    Message = dataRow["Message"].ToString()
                };



                if (match.Gagnant != null && match.Perdant != null)
                {
                    if (match.Gagnant.Id == match.Visiteur.Id) match.NombreButVisiteur = match.NombreButGagnant;
                    if (match.Perdant.Id == match.Visiteur.Id) match.NombreButVisiteur = match.NombreButPerdant;

                    if (match.Gagnant.Id == match.Local.Id) match.NombreButLocal = match.NombreButGagnant;
                    if (match.Perdant.Id == match.Local.Id) match.NombreButLocal = match.NombreButPerdant;
                }
                else
                {
                    match.Gagnant = equipeNull;
                    match.Perdant = equipeNull;
                }


                matchSaisons.Add(match);
            }
            return matchSaisons.OrderBy(x => x.Date).ToList();
        }
        public IList<Equipe> ObtenirEquipe()
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT * FROM Equipe");
            IList<Equipe> retour = new List<Equipe>();
            IList<Saison> obtenirSaison = ObtenirSaison();

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Equipe equipe = new Equipe
                {
                    Id = (int)dataRow["Id"],
                    Nom = dataRow["Nom"].ToString(),
                    Saison = obtenirSaison.FirstOrDefault(x => x.Id == (int)dataRow["Saison"]),

                };
                retour.Add(equipe);
            }
            return retour;
        }
        public IList<Saison> ObtenirSaison()
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT * FROM Saison");
            IList<Saison> retour = new List<Saison>();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Saison equipe = new Saison
                {
                    Id = (int)dataRow["Id"],
                    Nom = dataRow["Nom"].ToString(),

                };
                retour.Add(equipe);
            }
            return retour;
        }
        public bool EstPresentAujourdhui(Equipe equipe)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT * FROM Presence WHERE Date = Convert(date, getdate())  and Equipe = " + equipe.Id);
            return dataSet.Tables[0].Rows.Count > 0;
        }
        public IList<EquipeSaison> ObtenirEquipeSaisonReguliere(Saison saison)
        {
            IList<EquipeSaison> retour = new List<EquipeSaison>();
            IList<MatchSaison> obtenirMatchSaison = ObtenirMatchSaisonReguliere(saison);
            IList<Equipe> obtenirEquipe = ObtenirEquipe();
            foreach (Equipe equipe in obtenirEquipe)
            {
                EquipeSaison equipeSaison = new EquipeSaison
                {
                    Equipe = equipe,
                    NombreDefaite = obtenirMatchSaison.Count(x => { return x.Perdant != null && x.Perdant.Id == equipe.Id; }),
                    NombreVictoire = obtenirMatchSaison.Count(x => { return x.Gagnant != null && x.Gagnant.Id == equipe.Id; }),
                    NombrePartieJoue = obtenirMatchSaison.Count(x => { return x.Gagnant != null && x.Gagnant.Id == equipe.Id; }) + obtenirMatchSaison.Count(x => { return x.Perdant != null && x.Perdant.Id == equipe.Id; }),
                    Saison = saison,
                    NombreDefaiteEnSurTemps = obtenirMatchSaison.Count(x => x.Perdant.Id == equipe.Id && x.PerteEnSurtemps == 1),
                };

                equipeSaison.EstPresentAujourdhui = EstPresentAujourdhui(equipe);

                equipeSaison.NombrePoint = obtenirMatchSaison.Where(x => x.Gagnant.Id == equipe.Id).Sum(x => x.NombrePointGagnant) + obtenirMatchSaison.Where(x => x.Perdant.Id == equipe.Id).Sum(x => x.NombrePointPerdant);
                equipeSaison.NombreButPour = obtenirMatchSaison.Where(x => x.Gagnant.Id == equipe.Id).Sum(x => x.NombreButGagnant) + obtenirMatchSaison.Where(x => x.Perdant.Id == equipe.Id).Sum(x => x.NombreButPerdant);
                equipeSaison.NombreButContre = obtenirMatchSaison.Where(x => x.Gagnant.Id == equipe.Id).Sum(x => x.NombreButPerdant) + obtenirMatchSaison.Where(x => x.Perdant.Id == equipe.Id).Sum(x => x.NombreButGagnant);

                if ((decimal)equipeSaison.NombrePartieJoue > 0)
                {
                    decimal round = Decimal.Round((decimal)equipeSaison.NombreVictoire / (decimal)equipeSaison.NombrePartieJoue, 3);
                    if (round == 1)
                    {
                        equipeSaison.PourcentageVictoire = "1.000";
                    }
                    else
                    {
                        equipeSaison.PourcentageVictoire = round == 0 ? "0.000" : round.ToString();
                    }

                }

                else
                {
                    equipeSaison.PourcentageVictoire = "0.000";
                }
                retour.Add(equipeSaison);
            }
            return retour.OrderByDescending(x => x.NombrePoint).ToList();
        }
        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
        public void ConstruireCalendrier(Saison saison, int nombreMatchParJour, DateTime dateDepart, int nombreMatchAvecChacun)
        {

            ExecuterSql("DELETE FROM MatchSaison");
            CreerMatchSaison(saison, nombreMatchAvecChacun);

            IList<MatchSaison> obtenirMatchSaison = ObtenirMatchSaisonReguliere(saison);
            Shuffle(obtenirMatchSaison);
            Shuffle(obtenirMatchSaison);
            Shuffle(obtenirMatchSaison);
            Shuffle(obtenirMatchSaison);

            int compteurMatch = 0;
            DateTime date = dateDepart;// Convert.ToDateTime("2017-10-11");
            foreach (MatchSaison match in obtenirMatchSaison)
            {
                compteurMatch += 1;
                ExecuterSql("UPDATE MatchSaison SET Date = '" + date + "' WHERE Id = " + match.Id);
                if (compteurMatch == nombreMatchParJour)
                {
                    compteurMatch = 0;
                    if (date.DayOfWeek == DayOfWeek.Wednesday)
                        date = GetNextWeekday(date, DayOfWeek.Monday);
                    else
                    {
                        date = GetNextWeekday(date, DayOfWeek.Wednesday);
                    }
                }
            }
        }
        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }



        private void CreerMatchSaison(Saison saison, int nombreMatchAvecChacun)
        {
            IList<Equipe> equipes = ObtenirEquipe().Where(x => x.Saison.Id == saison.Id).ToList();

            if (nombreMatchAvecChacun == 1)
            {

            }
            string sql = "INSERT INTO MatchSaison (Saison,Date,Local,Visiteur,.Gagnant,Perdant, NombreButGagnant, NombreButPerdant,NombrePointGagnant, NombrePointPerdant) VALUES ({0},'1753-01-01',{1},{2},0,0,0,0,0,0)";
            //for (int i = 0; i < nombreMatchAvecChacun; i++)
            //{
            foreach (Equipe equipeA in equipes)
            {
                bool estEquipeALocal = true;
                foreach (Equipe equipeB in equipes.Where(x => x.Id != equipeA.Id))
                {
                    if (estEquipeALocal)
                    {
                        ExecuterSql(string.Format(sql, saison.Id, equipeA.Id, equipeB.Id));
                        estEquipeALocal = false;
                    }
                    else
                    {
                        ExecuterSql(string.Format(sql, saison.Id, equipeB.Id, equipeA.Id));
                        estEquipeALocal = true;
                    }
                }
            }
            //}
        }

    }
}

