using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services;

namespace ATMTECH.Mediator.Client
{
    public class GestionPresentation
    {
        public ClavardageService ClavardageService { get { return new ClavardageService(); } }

        public static void AjouterTexte(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void AfficherClavardage(Clavardage clavardage)
        {

        }
        public static void AfficherErreur(string erreur)
        {

        }

        public void EnvoyerClavardage(TextBox textBox, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(textBox.Text)) return;

            Clavardage clavardage = new Clavardage
                {
                    NoUtilisateur = 0,
                    Date = DateTime.Now,
                    Texte = textBox.Text,
                    Forums = "#DEFAULT",
                    Type = textBox.Text.IndexOf("/me") == 0 ? "COMMAND" : "CHAT"
                };
            ClavardageService.EnvoyerClavardage(clavardage);

            textBox.Text = "";
        }
        public IList<Clavardage> ObtenirClavardage(int clavardage)
        {
            return ClavardageService.ObtenirClavardage(clavardage);
        }
        public void EnvoyerCommande(string command, string forums)
        {
            Clavardage clavardage = new Clavardage
                {
                    NoUtilisateur = 0,
                    Date = DateTime.Now,
                    Texte = command,
                    Forums = forums,
                    Type = "COMMAND"
                };
            ClavardageService.EnvoyerClavardage(clavardage);
        }
        public IList<Clavardage> ObtenirListeClavardage(int nombreAnterieur)
        {
            return ClavardageService.ObtenirListeClavardage(nombreAnterieur);
        }

    }
}
