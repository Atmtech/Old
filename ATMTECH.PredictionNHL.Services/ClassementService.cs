using ATMTECH.PredictionNHL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.PredictionNHL.Services
{
    public class ClassementService : BaseService
    {

        private Game ObtenirGame(NhlSchedule ceduleTotal, int gamePrimaryKey)
        {
            foreach (Date dateCedule in ceduleTotal.dates)
            {
                foreach (Game game in dateCedule.games)
                {
                    if (game.gamePk == gamePrimaryKey) return game;
                }
            }
            return null;
        }

        public IList<Classement> ObtenirClassement(string dateDepart)
        {
            if (Convert.ToDateTime(dateDepart) > DateTime.Now) return null;
            NhlSchedule ceduleTotal = new NhlService().ObtenirCedule(dateDepart, DateTime.Now.ToShortDateString());
            IList<Prediction> predictions = new PredictionService().ObtenirPrediction();
            IList<Classement> classements = new List<Classement>();
            foreach (Utilisateur utilisateur in new UtilisateurService().Obtenir())
            {
                classements.Add(new Classement
                {
                    Utilisateur = utilisateur,
                    Pointage = 0,
                    NombreVictoire = 0,
                    NombreEchec = 0,
                    NombreTotalPrediction = 0
                });

                foreach (Prediction prediction in predictions.Where(x => x.Utilisateur.Courriel == utilisateur.Courriel))
                {
                    bool estPredictionVisiteurGagnant = false;
                    if (prediction.PointageVisiteur > prediction.PointageLocal) estPredictionVisiteurGagnant = true;
                    Game game = ObtenirGame(ceduleTotal, prediction.GamePrimaryKey);
                    bool estVisiteurGagnant = false;
                    if (game.teams.away.score > game.teams.home.score) estVisiteurGagnant = true;

                    Classement classement = classements.FirstOrDefault(x => x.Utilisateur.Courriel == prediction.Utilisateur.Courriel);
                    if (estVisiteurGagnant == estPredictionVisiteurGagnant)
                    {
                        classement.Pointage += 2;
                        classement.NombreVictoire += 1;
                    }
                    else
                    {
                        classement.NombreEchec += 1;
                    }
                    classement.NombreTotalPrediction += 1;
                }
            }

            return classements.OrderByDescending(x => x.Pointage).ToList();
        }
    }


}
