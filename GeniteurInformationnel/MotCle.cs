using System.Windows.Documents;
using System.Windows.Media;

namespace GeniteurInformationnel
{
    public class MotCle
    {
        public static readonly SolidColorBrush CouleurCommentaire = new SolidColorBrush(Colors.DarkOliveGreen);
        public static readonly SolidColorBrush CouleurTexte = new SolidColorBrush(Colors.White);
        public static readonly SolidColorBrush CouleurString = new SolidColorBrush(Colors.Red);
        public static readonly SolidColorBrush CouleurTable = new SolidColorBrush(Colors.YellowGreen);
        public static readonly SolidColorBrush CouleurCommandeSQL = new SolidColorBrush(Colors.CornflowerBlue);
        public static readonly SolidColorBrush CouleurCommandeFonctionSQL = new SolidColorBrush(Colors.Gray);
        public static readonly SolidColorBrush CouleurObjectId = new SolidColorBrush(Colors.Fuchsia);

        public static LineBreak LineBreak = new LineBreak();
        public static Run runIf = new Run("IF ") { Foreground = CouleurCommandeSQL };
        public static Run runExists = new Run("EXISTS ") { Foreground = CouleurCommandeFonctionSQL };
        public static Run runEtoile = new Run("* ") { Foreground = CouleurCommandeFonctionSQL };
        public static Run runEgale = new Run("= ") { Foreground = CouleurCommandeFonctionSQL };
        public static Run runSelect = new Run("SELECT ") { Foreground = CouleurCommandeSQL };
        public static Run runWhere = new Run("WHERE ") { Foreground = CouleurCommandeSQL };
        public static Run runFrom = new Run("FROM ") { Foreground = CouleurCommandeSQL };
        public static Run runDropProcedure = new Run("DROP PROCEDURE ") { Foreground = CouleurCommandeSQL };
        public static Run runCreateProcedure = new Run("CREATE PROCEDURE ") { Foreground = CouleurCommandeSQL };
        public static Run runType = new Run("type ") { Foreground = CouleurCommandeSQL };
        public static Run runAnd = new Run(" and ") { Foreground = CouleurCommandeFonctionSQL };
        public static Run runIn = new Run("in ") { Foreground = CouleurCommandeFonctionSQL };
        public static Run runAS = new Run("AS ") { Foreground = CouleurCommandeSQL };
        public static Run runBegin = new Run("BEGIN" ) { Foreground = CouleurCommandeSQL };
        public static Run runInto = new Run("INTO ") { Foreground = CouleurCommandeSQL };
        public static Run runEnd= new Run("END") { Foreground = CouleurCommandeSQL };
        public static Run runExec = new Run("exec ") { Foreground = CouleurCommandeSQL };
        public static Run runOn = new Run("ON ") { Foreground = CouleurCommandeSQL };
        public static Run runRight = new Run("RIGHT ") { Foreground = CouleurCommandeFonctionSQL };
        public static Run runTruncateTable = new Run("TRUNCATE TABLE ") { Foreground = CouleurCommandeSQL };
        public static Run runGo = new Run("GO") { Foreground = CouleurCommandeSQL };
        public static Run runObjectId = new Run("object_id ") { Foreground = CouleurObjectId };
        
        public static Run runString(string texteString)
        {
            return new Run(texteString) { Foreground = CouleurString };
        }

        public static Run runTable(string table)
        {
            return new Run(table) { Foreground = CouleurTable };
        }
        public static Run runTexte(string texte)
        {
            return new Run(texte) {Foreground = CouleurTexte};
        }

        public static Run runCommentaire(string commentaire)
        {
            return new Run(commentaire) { Foreground = CouleurCommentaire };
        }
    }
}
