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

        public GestionPresentation()
        {
            Utilisateur = ClavardageService.ObtenirUtilisateurCourant();
        }

        public void AjouterTexte(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public void AfficherClavardage(RichTextBox box, int nombre)
        {
            int plageInitial = ClavardageCourant - 100;

            IList<Clavardage> clavardages = ObtenirClavardage(plageInitial).Where(x => x.Type != "COMMAND").Take(nombre).OrderByDescending(x => x.NoClavardage).ToList();
            AjouterTexte(box, "====================================================", Color.Turquoise);
            AjouterTexte(box, Environment.NewLine, Color.White);
            AjouterTexte(box, "Début historique de " + nombre + " clavardage", Color.Turquoise);
            AjouterTexte(box, Environment.NewLine, Color.White);
            AjouterTexte(box, "====================================================", Color.Turquoise);
            AjouterTexte(box, Environment.NewLine, Color.White);
            foreach (Clavardage clavardage in clavardages)
            {
                AjouterTexte(box, clavardage.Utilisateur.NomUtilisateur + " (" + clavardage.Date + ") > ", Color.GreenYellow);
                AjouterTexte(box, clavardage.Texte, Color.White);
                AjouterTexte(box, Environment.NewLine, Color.White);
                box.SelectionStart = box.Text.Length;
                box.ScrollToCaret();
            }
            AjouterTexte(box, "====================================================", Color.Turquoise);
            AjouterTexte(box, Environment.NewLine, Color.White);
        }
        public void AfficherClavardage(RichTextBox box)
        {
            IList<Clavardage> clavardages = ObtenirClavardage(ClavardageCourant);
            if (clavardages == null) return;
            foreach (Clavardage clavardage in clavardages)
            {
                ClavardageCourant = clavardage.NoClavardage;

                if (EstCommande(clavardage.Texte))
                {
                    if (clavardage.Texte.ToLower().IndexOf("/join") == 0)
                    {
                        AjouterTexte(box, string.Format("{0} est connecté", clavardage.Utilisateur.NomUtilisateur), Color.GreenYellow);
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/me") == 0)
                    {
                        AjouterTexte(box, clavardage.Texte.Substring(3, clavardage.Texte.Length - 3), Color.PaleVioletRed);
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/q") == 0)
                    {
                        AjouterTexte(box, string.Format("{0} est déconnecté", clavardage.Utilisateur.NomUtilisateur), Color.GreenYellow);
                    }
                }
                else
                {
                    AjouterTexte(box, clavardage.Utilisateur.NomUtilisateur + "> ", Color.GreenYellow);
                    AjouterTexte(box, clavardage.Texte, Color.White);
                }
                AjouterTexte(box, Environment.NewLine, Color.White);
                box.SelectionStart = box.Text.Length;
                box.ScrollToCaret();
            }
        }

        private bool EstCommande(string texte)
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
                    Forums = "#DEFAULT",
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
