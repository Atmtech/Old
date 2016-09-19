using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.Pass.Entites;

namespace ATMTECH.Pass.DAO
{
    public class DAOPass : BaseDao
    {
        public IList<Entites.Pass> ObtenirPass(int id)
        {
            DataSet dataSet = ObtenirDonneesMssql("SELECT Id, Emplacement, MotDePasse FROM Pass WHERE Utilisateur  = " + id);
            return (from DataRow dataRow in dataSet.Tables[0].Rows
                    select
                        new Entites.Pass
                        {
                            Id = Convert.ToInt32(dataRow["Id"].ToString()),
                            Emplacement = dataRow["Emplacement"].ToString(),
                            MotDePasse = dataRow["MotDePasse"].ToString(),
                        }).ToList();
        }

    }
}
