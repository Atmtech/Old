using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeniteurInformationnel.DAO;
using GeniteurInformationnel.Entities;

namespace GeniteurInformationnel.Services
{
    public class GeniteurInformationnelService
    {

        public string NomServeurSelectionne { get; set; }
        public string NomBDSelectionne { get; set; }
        public string NomTableSelectionne { get; set; }

        public DAOGeniteurInformationnel DAOGeniteurInformationnel
        {
            get
            {
                DAOGeniteurInformationnel daoGeniteurInformationnel = new DAOGeniteurInformationnel { NomBDSelectionne = NomBDSelectionne, NomServeurSelectionne = NomServeurSelectionne, NomTableSelectionne = NomTableSelectionne};
                return daoGeniteurInformationnel;
            }
        }

        public IList<Serveur> ObtenirListeServeur()
        {
            return DAOGeniteurInformationnel.ObtenirListeServeur();
        }
        public IList<BaseDonnee> ObtenirListeBD()
        {
            return DAOGeniteurInformationnel.ObtenirListeBD();
        }

        public IList<Tables> ObtenirListeTable()
        {
            return DAOGeniteurInformationnel.ObtenirListeTable();
        }

        public IList<Colonne> ObtenirListeColonne()
        {
            return DAOGeniteurInformationnel.ObtenirListeColonne();
        }

        public IList<Colonne> ObtenirListeColonne(string table)
        {
            return DAOGeniteurInformationnel.ObtenirListeColonne(table);
        }

        public string ObtenirTypeColonne(string colonne)
        {
            return DAOGeniteurInformationnel.ObtenirTypeColonne(colonne);
            
        }

        public string ObtenirLeftJoin(string table)
        {
            return DAOGeniteurInformationnel.ObtenirLeftJoin(table);
        }


        public IList<Jointure> ObtenirListeDesTableJoinEpure(string table)
        {

            IList<Jointure> liste = DAOGeniteurInformationnel.ObtenirListeDesTableJoin(table);
            IList<Jointure> listeRetour = new List<Jointure>();
            foreach (Jointure jointure in liste.OrderBy(x=>x.Niveau).ThenBy(x=>x.NomTable))
            {
                if (listeRetour.Count(x => x.NomTable == jointure.NomTable) > 0)
                {
                    jointure.LibelleJointure = "\t\t AND " +
                        jointure.LibelleJointure.Substring(jointure.LibelleJointure.IndexOf(" on ") + 3, jointure.LibelleJointure.Length - jointure.LibelleJointure.IndexOf(" on ") - 3);
                    listeRetour.Add(jointure);
                }
                else
                {
                    listeRetour.Add(jointure);
                }
            }
            return listeRetour;
        }

        public string GenerationScriptConformite()
        {
            return "";
        }

        private string RemplacerCleRecherche(string texteInitial)
        {
            return "exec spED_CreerCleRecherche 'xxxx', @ColonneCle1='xxx', @ColonneCle2='xx'";
        }
        private string RemplacerLeftJoin(string texteInitial)
        {
            if (texteInitial.IndexOf("%LeftJoin%") >= 0)
            {
                string leftJoin = SortirLesLeftJoinConformite();
                return string.IsNullOrEmpty(leftJoin) ? "" : leftJoin;
            }
            return string.Empty;
        }
        private string RemplacerSchema(string texteInitial)
        {
            return "Pesa" + NomTableSelectionne;
        }
        private string RemplacerColonne(string texteInitial)
        {
            if (texteInitial.IndexOf("%Colonnes%") >= 0)
            {
                return SortirLesColonnesDuSelectDeConformite();
            }
            return string.Empty;
        }
        private string RemplacerTexte(string texteInitial)
        {
            texteInitial = texteInitial.Replace("%NomProcedureStocke%", "spED_Obtenir" + NomTableSelectionne);
            texteInitial = texteInitial.Replace("%NomTable%", NomTableSelectionne);
            texteInitial = texteInitial.Replace("%CleRecherche%", RemplacerCleRecherche(texteInitial));
            texteInitial = texteInitial.Replace("%LeftJoin%", RemplacerLeftJoin(texteInitial));
            texteInitial = texteInitial.Replace("%Schema%", RemplacerSchema(texteInitial));
            texteInitial = texteInitial.Replace("%Colonnes%", RemplacerColonne(texteInitial));
            return texteInitial;
        }


        private string SortirLesLeftJoinConformite()
        {
            return ObtenirLeftJoin(NomTableSelectionne);
        }
        private string SortirLesColonnesDuSelectDeConformite()
        {
            string colonnes = string.Empty;
            //foreach (var item in lstColonne.Items)
            //{
            //    if (item is CheckBox)
            //    {
            //        CheckBox checkBox = (item as CheckBox);

            //        if (checkBox.IsChecked != null && (bool)checkBox.IsChecked)
            //        {
            //            string colonne = checkBox.Content.ToString();

            //            string typeChamps = GeniteurInformationnelService.ObtenirTypeColonne(colonne);
            //            switch (typeChamps)
            //            {
            //                case "varchar":
            //                    colonnes += "\t\t[dbo].fnRetournerValeurCaractere(" + colonne + ") AS " + colonne + "______,\r";
            //                    break;
            //                case "decimal":
            //                    colonnes += "\t\t[dbo].fnRetournerValeurDecimal(" + colonne + ") AS " + colonne + "______,\r";
            //                    break;
            //                case "datetime":
            //                    colonnes += "\t\t[dbo].fnRetournerValeurDate(" + colonne + ", '17530101') AS " + colonne + "______,\r";
            //                    break;
            //                case "int":
            //                    colonnes += "\t\t[dbo].fnRetournerValeurEntiere(" + colonne + ") AS " + colonne + "______,\r";
            //                    break;
            //            }

            //        }
            //    }
            //}
            return colonnes;
        }
     
    }
}
