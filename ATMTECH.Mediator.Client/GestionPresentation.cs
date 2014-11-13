using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services;

namespace ATMTECH.Mediator.Client
{
    public class GestionPresentation
    {
        public ClavardageService ClavardageService { get { return new ClavardageService(); } }
        public Utilisateur Utilisateur { get; set; }
        public int ClavardageCourant { get; set; }
        public RichTextBox RichTextBox { get; set; }
        public const string FORUMS = "#DEFAULT";

        public GestionPresentation()
        {
            Utilisateur = ClavardageService.ObtenirUtilisateurCourant();
        }

        public void AjouterTexte(string text, Color color)
        {
            RichTextBox.SelectionStart = RichTextBox.TextLength;
            RichTextBox.SelectionLength = 0;
            RichTextBox.SelectionColor = color;
            RichTextBox.AppendText(text);
            RichTextBox.SelectionColor = RichTextBox.ForeColor;
            
        }
        public void AjouterSautLigne()
        {
            AjouterTexte(Environment.NewLine, Color.White);
        }
        public void AfficherClavardage(int nombre)
        {
            int plageInitial = ClavardageCourant - 100;

            IList<Clavardage> clavardages = ObtenirClavardage(plageInitial).Where(x => x.Type != "COMMAND").Take(nombre).OrderBy(x => x.NoClavardage).ToList();

            RichTextBox.Clear();

            foreach (Clavardage clavardage in clavardages)
            {
                AjouterTexte(clavardage.Utilisateur.NomUtilisateur + " > ", Color.GreenYellow);
                AjouterTexte(clavardage.Texte, Color.White);
                AjouterTexte(Environment.NewLine, Color.White);
                RichTextBox.SelectionStart = RichTextBox.Text.Length;
                RichTextBox.ScrollToCaret();
            }
        }
        public IList<Clavardage> AfficherClavardage()
        {
            IList<Clavardage> clavardages = ObtenirClavardage(ClavardageCourant);
            if (clavardages == null) return null;
            foreach (Clavardage clavardage in clavardages)
            {
                ClavardageCourant = clavardage.NoClavardage;

                if (EstCommande(clavardage.Texte))
                {
                    if (clavardage.Texte.ToLower().IndexOf("/join") == 0)
                    {
                        AjouterTexte(string.Format("{0} est connecté", clavardage.Utilisateur.NomUtilisateur), Color.GreenYellow);
                        AjouterSautLigne();
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/me") == 0)
                    {
                        AjouterTexte(clavardage.Texte.Substring(3, clavardage.Texte.Length - 3), Color.PaleVioletRed);
                        AjouterSautLigne();
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/q") == 0)
                    {
                        AjouterTexte(string.Format("{0} est déconnecté", clavardage.Utilisateur.NomUtilisateur), Color.GreenYellow);
                        AjouterSautLigne();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(clavardage.Texte))
                    {
                        AjouterTexte(clavardage.Utilisateur.NomUtilisateur + "> ", Color.GreenYellow);
                        AjouterTexte(clavardage.Texte, Color.White);
                        AjouterSautLigne();
                        
                    }
                }

                
            }
            return clavardages;
        }
        public bool EstCommande(string texte)
        {
            return texte.Substring(0, 1) == "/";
        }
        public void EnvoyerClavardage(string texte)
        {
            Clavardage clavardage = new Clavardage
                {
                    NoUtilisateur = Utilisateur.NoUtilisateur,
                    Date = DateTime.Now,
                    Texte = texte,
                    Forums = FORUMS,
                    Type = EstCommande(texte) ? "COMMAND" : "CHAT"
                };
            ClavardageService.EnvoyerClavardage(clavardage);
        }

        public IList<Clavardage> ObtenirListeClavardage(int nombreAnterieur)
        {
            return ClavardageService.ObtenirListeClavardage(nombreAnterieur);
        }
        public IList<Clavardage> ObtenirClavardage(int clavardage)
        {
            return ClavardageService.ObtenirClavardage(clavardage);
        }

    }
}
