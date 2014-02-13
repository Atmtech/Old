namespace GeniteurInformationnel.Entities
{
    public class Colonne
    {
        public string EstUtilise { get; set; }
        public string NomColonne { get; set; }
        public string NomTable { get; set; }
        public string Type { get; set; }
        public string NomSuggere { get; set; }
        public string TableAvecSynonyme { get { return "synPesa" + NomTable; } }
        public string ColonneAvecFonction
        {
            get
            {
                switch (Type)
                {
                    case "varchar":
                        return "[dbo].fnRetournerValeurCaractere(" + NomTable + "." + NomColonne + ")";
                    case "decimal":
                        return "[dbo].fnRetournerValeurDecimal(" + NomTable + "." + NomColonne + ")";
                    case "datetime":
                        return "[dbo].fnRetournerValeurDate(" + NomTable + "." + NomColonne + ", '17530101')";
                    case "int":
                        return "[dbo].fnRetournerValeurEntiere(" + NomTable + "." + NomColonne + ")";
                }

                return "";
            }
        }
    }
}
