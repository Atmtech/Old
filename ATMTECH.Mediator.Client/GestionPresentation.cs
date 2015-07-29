using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services;
using FastColoredTextBoxNS;

namespace ATMTECH.Mediator.Client
{
    public class GestionPresentation
    {
        public ClavardageService ClavardageService { get { return new ClavardageService(); } }
        public Utilisateur Utilisateur { get; set; }
        public int ClavardageCourant { get; set; }
        public RichTextBox RichTextBox { get; set; }
        public FastColoredTextBox FastColoredTextBox { get; set; }
        public const string FORUMS = "#DEFAULT";

        public Style GreenYellowStyle = new TextStyle(Brushes.GreenYellow, null, FontStyle.Regular);
        public Style WhiteStyle = new TextStyle(Brushes.White, null, FontStyle.Regular);
        public Style PaleVioletRedStyle = new TextStyle(Brushes.PaleVioletRed, null, FontStyle.Regular);
        public Style Link = new TextStyle(Brushes.Red, Brushes.Purple, FontStyle.Underline);

        public GestionPresentation()
        {
            Utilisateur = ClavardageService.ObtenirUtilisateurCourant();
        }
        public void AjouterTexte(string text, Style style)
        {
            FastColoredTextBox.AppendText(text, style);
        }
        public void AjouterSautLigne()
        {
            AjouterTexte(Environment.NewLine, WhiteStyle);
        }
        public void AfficherClavardage(int nombre)
        {
            int plageInitial = ClavardageCourant - 100;

            //IList<Clavardage> clavardages = ObtenirClavardage(plageInitial).Where(x => x.Type != "COMMAND").OrderByDescending(x => x.NoClavardage).Take(nombre).OrderBy(x => x.NoClavardage).ToList();
            IList<Clavardage> clavardages = ObtenirClavardage(plageInitial).OrderByDescending(x => x.NoClavardage).Take(nombre).OrderBy(x => x.NoClavardage).ToList();

            FastColoredTextBox.Clear();

            foreach (Clavardage clavardage in clavardages)
            {
                ClavardageCourant = clavardage.NoClavardage;

                if (EstCommande(clavardage.Texte))
                {
                    if (clavardage.Texte.ToLower().IndexOf("/join") == 0)
                    {
                        AjouterTexte(string.Format("{0} est connecté", clavardage.Utilisateur.NomUtilisateur), GreenYellowStyle);
                        AjouterSautLigne();
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/me") == 0)
                    {
                        AjouterTexte(clavardage.Texte.Substring(3, clavardage.Texte.Length - 3), PaleVioletRedStyle);
                        AjouterSautLigne();
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/q") == 0)
                    {
                        AjouterTexte(string.Format("{0} est déconnecté", clavardage.Utilisateur.NomUtilisateur), GreenYellowStyle);
                        AjouterSautLigne();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(clavardage.Texte))
                    {
                        AjouterTexte(clavardage.Utilisateur.NomUtilisateur + "> ", GreenYellowStyle);
                        AjouterTexte(clavardage.Texte, WhiteStyle);
                        AjouterSautLigne();
                    }
                }
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
                        AjouterTexte(string.Format("{0} est connecté", clavardage.Utilisateur.NomUtilisateur), GreenYellowStyle);
                        AjouterSautLigne();
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/me") == 0)
                    {
                        AjouterTexte(clavardage.Texte.Substring(3, clavardage.Texte.Length - 3), PaleVioletRedStyle);
                        AjouterSautLigne();
                    }
                    if (clavardage.Texte.ToLower().IndexOf("/q") == 0)
                    {
                        AjouterTexte(string.Format("{0} est déconnecté", clavardage.Utilisateur.NomUtilisateur), GreenYellowStyle);
                        AjouterSautLigne();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(clavardage.Texte))
                    {
                        AjouterTexte(clavardage.Utilisateur.NomUtilisateur + "> ", GreenYellowStyle);
                        AjouterTexte(clavardage.Texte, WhiteStyle);
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
        public IList<Clavardage> ObtenirClavardage(int clavardage)
        {
            return ClavardageService.ObtenirClavardage(clavardage);
        }
        public bool EstUnLien(Place place)
        {
            var mask = FastColoredTextBox.GetStyleIndexMask(new[] { Link });
            if (place.iChar < FastColoredTextBox.GetLineLength(place.iLine))
                if ((FastColoredTextBox[place].style & mask) != 0)
                    return true;

            return false;

        }
        public DateTime ObtenirDateClavardage(int noLigneToolTip)
        {
            return ClavardageService.ObtenirDateClavardage(ClavardageService.ObtenirMaximumClavardage() - noLigneToolTip);
        }
    }
}

