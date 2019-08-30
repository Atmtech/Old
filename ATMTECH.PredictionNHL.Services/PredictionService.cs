using ATMTECH.PredictionNHL.DAO;
using ATMTECH.PredictionNHL.Entites;
using System;
using System.Collections.Generic;

namespace ATMTECH.PredictionNHL.Services
{
    public class PredictionService : BaseService
    {
        public void Enregistrer(Prediction prediction)
        {
            if (prediction.PointageLocal == prediction.PointageVisiteur)
                throw new Exception("Vous ne pouvez pas saisir un pointage nul");
            new DAOPrediction().Enregistrer(prediction);
        }

        public IList<Prediction> ObtenirPrediction(string id)
        {
            return new DAOPrediction().ObtenirPrediction(id);
        }

        public IList<Prediction> ObtenirPrediction()
        {
            return new DAOPrediction().Obtenir();
        }


    }
}
