using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GeniteurInformationnel
{
    public class CommandeAjouterTexte
    {
        public Paragraph Paragraph { get; set; }

        public void AjouterParagraphe(Run run)
        {
            Paragraph.Inlines.Add(run);
        }
        public void AjouterLineBreak()
        {
            Paragraph.Inlines.Add(MotCle.LineBreak);
        }

        public void AjouterCommentaire(string commentaire)
        {
            //Paragraph.Inlines.Add(MotCle.LineBreak);
            //AjouterCommandeTab();
            //AjouterParagraphe(MotCle.runCommentaire("/**************"));
            //Paragraph.Inlines.Add(MotCle.LineBreak);
            //AjouterCommandeTab();
            //AjouterParagraphe(MotCle.runCommentaire(commentaire));
            //Paragraph.Inlines.Add(MotCle.LineBreak);
            //AjouterCommandeTab();
            //Paragraph.Inlines.Add(MotCle.LineBreak); Paragraph.Inlines.Add(MotCle.LineBreak); Paragraph.Inlines.Add(MotCle.LineBreak);
            //AjouterParagraphe(MotCle.runCommentaire("*********/"));
           // Paragraph.Inlines.Add(MotCle.LineBreak);
            //AjouterCommandeSelect();
            AjouterParagraphe(MotCle.runTexte("Crevette"));
            Paragraph.Inlines.Add(MotCle.LineBreak);
        }

        public void AjouterCommandeInto(string table)
        {
            Paragraph.Inlines.Add(MotCle.LineBreak);
            AjouterCommandeTab();
            AjouterParagraphe(MotCle.runInto);
            AjouterParagraphe(MotCle.runTexte("#Conformite" + table));
            Paragraph.Inlines.Add(MotCle.LineBreak);
        }
        public void AjouterCommandeDropProcedure(string nomProcedure)
        {
            AjouterParagraphe(MotCle.runIf);
            AjouterParagraphe(MotCle.runExists);
            AjouterParagraphe(MotCle.runTexte("("));
            AjouterParagraphe(MotCle.runSelect);
            AjouterParagraphe(MotCle.runEtoile);
            AjouterParagraphe(MotCle.runFrom);
            AjouterParagraphe(MotCle.runTable("sys.objects"));
            AjouterParagraphe(MotCle.runWhere);
            AjouterParagraphe(MotCle.runObjectId);
            AjouterParagraphe(MotCle.runEgale);
            AjouterParagraphe(MotCle.runObjectId);
            AjouterParagraphe(MotCle.runTexte("("));
            AjouterParagraphe(MotCle.runString("N'[dbo].["));
            AjouterParagraphe(MotCle.runString(nomProcedure));
            AjouterParagraphe(MotCle.runString("]'"));
            AjouterParagraphe(MotCle.runTexte(")"));
            AjouterParagraphe(MotCle.runAnd);
            AjouterParagraphe(MotCle.runType);
            AjouterParagraphe(MotCle.runIn);
            AjouterParagraphe(MotCle.runTexte("("));
            AjouterParagraphe(MotCle.runString("N'P', N'PC'"));
            AjouterParagraphe(MotCle.runTexte(")"));
            AjouterParagraphe(MotCle.runTexte(")"));
            Paragraph.Inlines.Add(new LineBreak()); 
            AjouterParagraphe(MotCle.runDropProcedure);
            AjouterParagraphe(MotCle.runTexte("[dbo].[" + nomProcedure + "]"));
            Paragraph.Inlines.Add(new LineBreak());
            AjouterParagraphe(MotCle.runGo);
        }

        public void AjouterCommandeCreateProcedure(string nomProcedure)
        {
            Paragraph.Inlines.Add(new LineBreak());
            AjouterParagraphe(MotCle.runCreateProcedure);
            AjouterParagraphe(MotCle.runTexte("[dbo].[" + nomProcedure + "]"));
            Paragraph.Inlines.Add(new LineBreak());
            AjouterParagraphe(MotCle.runAS);
            Paragraph.Inlines.Add(new LineBreak());
            AjouterParagraphe(MotCle.runBegin);
            Paragraph.Inlines.Add(new LineBreak());
        }

        public void AjouterCommandeSelect()
        {
            AjouterParagraphe(MotCle.runSelect);
            Paragraph.Inlines.Add(new LineBreak());
        }

        public void AjouterCommandeFrom(string table)
        {
            AjouterCommandeTab();
            AjouterParagraphe(MotCle.runFrom);
            AjouterParagraphe(MotCle.runTexte(table));
            Paragraph.Inlines.Add(new LineBreak());

        }

        public void AjouterCommandeTab()
        {
            AjouterParagraphe(new Run("\t"));
        }

        public void AjouterColonne( string colonne, string typeChamps)
        {
            AjouterCommandeTab();
            AjouterCommandeTab();
            switch (typeChamps)
            {
                case "varchar":
                    AjouterParagraphe(MotCle.runTexte("[dbo].fnRetournerValeurCaractere(" + colonne + ") AS " + colonne + "______,"));
                    break;
                case "decimal":
                    AjouterParagraphe(MotCle.runTexte("[dbo].fnRetournerValeurDecimal(" + colonne + ") AS " + colonne + "______,"));
                    break;
                case "datetime":
                    AjouterParagraphe(MotCle.runTexte("[dbo].fnRetournerValeurDate(" + colonne + ", '17530101') AS " + colonne + "______,"));
                    break;
                case "int":
                    AjouterParagraphe(MotCle.runTexte("[dbo].fnRetournerValeurEntiere(" + colonne + ") AS " + colonne + "______,"));
                    break;
            }
            Paragraph.Inlines.Add(new LineBreak());
        }
    }
}
