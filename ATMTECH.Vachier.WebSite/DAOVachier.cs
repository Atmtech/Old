using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.Vachier.WebSite
{
    public class DAOVachier : BaseDAO
    {

        public void SupprimerInsulte(Insulte insulte)
        {
            IMongoCollection<Insulte> mongoCollection = Database.GetCollection<Insulte>("Insulte");
            mongoCollection.DeleteOneAsync(a => a.Id == insulte.Id);
        }

        public void AjouterInsulte(string titre, string description, string insultetexte, string repertoire)
        {
            if (!string.IsNullOrEmpty(description))
            {
                IMongoCollection<Insulte> mongoCollection = Database.GetCollection<Insulte>("Insulte");

                string ip = HttpContext.Current.Request.UserHostName;
                Localisation localisation = new Localisation();
                if (ip != "127.0.0.1" && ip != "::1")
                {
                    localisation = new DAOLogger().ObtenirInformationLocalisation(ip);
                    if (localisation.Ip.IndexOf("5.188.211", StringComparison.Ordinal) >= 0)
                    {
                        return;
                    }
                }
                Insulte insulte = new Insulte
                {
                    DateCreation = DateTime.Now,
                    Description = description + " " + insultetexte,
                    Localisation = localisation,
                    Titre = titre
                };
                mongoCollection.InsertOneAsync(insulte);
                ViderCache();
            }
        }

        public bool EstExclus(string description, string repertoire)
        {
            string jsonInput = System.IO.File.ReadAllText(repertoire + @"\exclusion.json");
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            List<Exclusion> exclusion = jsonSerializer.Deserialize<List<Exclusion>>(jsonInput);
            return exclusion.Any(exclusion1 => description.Contains(exclusion1.Url));
        }

        public List<Insulte> ObtenirTop10Merdeux()
        {
            return ObtenirInsulte().OrderByDescending(x => x.NombreJaime).Take(10).ToList();
        }

        public void AjouterInsulte(Insulte insulte)
        {
            IMongoCollection<Insulte> mongoCollection = Database.GetCollection<Insulte>("Insulte");
            mongoCollection.InsertOneAsync(insulte);
        }


        public IList<Insulte> ObtenirInsulte()
        {
            if (HttpContext.Current.Session["Insultes"] == null)
            {
                IMongoCollection<Insulte> mongoCollection = Database.GetCollection<Insulte>("Insulte");
                HttpContext.Current.Session["Insultes"] = mongoCollection.AsQueryable().ToList();
            }
            return (IList<Insulte>)HttpContext.Current.Session["Insultes"];
        }

        public IList<Insulte> ObtenirInsulte(int depart)
        {
            return ObtenirInsulte().OrderByDescending(x => x.DateCreation).Skip(depart).Take(10).ToList();
        }

        public void SupprimerCollectionInsulte()
        {
            Database.DropCollection("Insulte");
            ViderCache();
        }

        public void ConvertirAncienVersNouveau(string connectionString)
        {

            string sql = "select Isnull(Convert(varchar(1000),Vachier.Description),'')  +' ' + Isnull(Convert(varchar(1000), Insulte.Description), '') as Nouvelle,  					     " +
                         "Vachier.DateCreated as DateCreation, IsNull(Ip, '') as Ip,                         " +
                         "JaimeTaMerde as NombreJaime, Isnull(CountryName, '') as Pays, Isnull(Region, '') as Region, Isnull(PostalCode, '') as CodePostal, Isnull(City, '') as Ville                        " +
                         " from Vachier inner join Insulte on Insulte.Id = Vachier.Insulte                         " +
                         "order by JaimeTaMerde desc";


            DataSet dataSet = ObtenirDataSet(connectionString, sql);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Localisation localisation = new Localisation
                {
                    DateCreation = Convert.ToDateTime(dataRow["DateCreation"]),
                    Ip = dataRow["Ip"].ToString(),
                    Pays = dataRow["Pays"].ToString(),
                    Region = dataRow["Region"].ToString(),
                    Ville = dataRow["Ville"].ToString(),
                    CodePostal = dataRow["CodePostal"].ToString(),
                };
                Insulte insulte = new Insulte
                {
                    DateCreation = Convert.ToDateTime(dataRow["DateCreation"]),
                    Description = dataRow["Nouvelle"].ToString(),
                    Localisation = localisation,
                    Titre = String.Empty,
                    NombreJaime = Convert.ToInt32(dataRow["NombreJaime"]),
                };

                AjouterInsulte(insulte);
            }

            ViderCache();
        }

        public IList<string> ObtenirFormuleDeMarde()
        {
            List<string> retour = new List<string>
            {
                "va donc chier",
                "se fait chier dessus solidement",
                "se fait faire un bukkake de marde",
                "te roule dans la marde"
            };
            return retour;
        }

        private DataSet ObtenirDataSet(string connectionString, string sql)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        if (sqlConnection.State == ConnectionState.Open)
                        {
                            sqlCommand.CommandType = CommandType.Text;
                            sqlDataAdapter.SelectCommand = sqlCommand;
                            sqlDataAdapter.Fill(dataSet);
                        }
                    }
                }
            }
            return dataSet;
        }

        public void AjouterJaimeInsulte(string id)
        {
            IMongoCollection<Insulte> mongoCollection = Database.GetCollection<Insulte>("Insulte");
            Task<Insulte> singleAsync = mongoCollection.Find(x => x.Id == ObjectId.Parse(id)).SingleAsync();
            int resultNombreJaime = singleAsync.Result.NombreJaime;
            var updoneresult = mongoCollection.UpdateOneAsync(
                Builders<Insulte>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<Insulte>.Update.Set("NombreJaime", resultNombreJaime + 1));
            ViderCache();
        }

        public string ObtenirNombreTotalVote()
        {
            return ObtenirInsulte().Sum(x => x.NombreJaime).ToString();
        }

        public string ObtenirNombreTotalVille()
        {
            IList<LocalisationTopGroupe> retour = new List<LocalisationTopGroupe>();
            foreach (var test in ObtenirInsulte().GroupBy(x => x.AffichagePaysRegionVille).Select(group => new
            {
                Metric = group.Key,
                Count = group.Count()
            }).OrderByDescending(x => x.Count))
            {
                retour.Add(new LocalisationTopGroupe { Compte = test.Count, Localisation = test.Metric });
            }

            return retour.Sum(x => x.Compte).ToString();
        }

        public IList<LocalisationTopGroupe> ObtenirTop10Localisation()
        {
            IList<LocalisationTopGroupe> retour = new List<LocalisationTopGroupe>();
            foreach (var test in ObtenirInsulte().GroupBy(x => x.AffichagePaysRegionVille).Select(group => new
            {
                Metric = group.Key,
                Count = group.Count()
            }).OrderByDescending(x => x.Count))
            {
                if (test.Metric.Trim() != ",")
                    retour.Add(new LocalisationTopGroupe { Compte = test.Count, Localisation = test.Metric });
            }

            return retour.Take(10).ToList();
        }

        private void ViderCache()
        {
            HttpContext.Current.Session["Insultes"] = null;
        }

        public void SupprimerCollectionLocalisation()
        {
            Database.DropCollection("Localisation");
            ViderCache();
        }
    }

}