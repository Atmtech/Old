using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ATMTECH.Mediator.Entities;
using ATMTECH.Utils.WPF;
using Application = System.Windows.Application;
using Image = System.Windows.Controls.Image;

namespace ATMTECH.Mediator.Client
{
    public class GestionFlowDocument
    {
        public FlowDocumentReader FlowDocumentReader { get; set; }
        public Paragraph Paragraph { get; set; }
        public string ForumCourant { get; set; }

        public static readonly SolidColorBrush CouleurLien = new SolidColorBrush(Colors.Bisque);
        public static readonly SolidColorBrush CouleurNomUtilisateur = new SolidColorBrush(Colors.YellowGreen);
        public static readonly SolidColorBrush CouleurSeparateur = new SolidColorBrush(Colors.YellowGreen);
        public static readonly SolidColorBrush CouleurTexte = new SolidColorBrush(Colors.Gainsboro);
        public static readonly SolidColorBrush CouleurCommandeMe = new SolidColorBrush(Colors.Violet);
        public static readonly SolidColorBrush CouleurForums = new SolidColorBrush(Colors.White);
        public static readonly SolidColorBrush CouleurLiens = new SolidColorBrush(Colors.DarkKhaki);
        public static readonly SolidColorBrush CouleurErreur = new SolidColorBrush(Colors.DarkOrange);
        public static readonly SolidColorBrush CouleurNoir = new SolidColorBrush(Colors.Black);

        private static readonly Regex _reURL = new Regex(@"(?#Protocol)(?:(?:ht|f)tp(?:s?)\:\/\/|~/|/)?(?#Username:Password)(?:\w+:\w+@)?(?#Subdomains)(?:(?:[-\w]+\.)+(?#TopLevel Domains)(?:com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum|travel|[a-z]{2}))(?#Port)(?::[\d]{1,5})?(?#Directories)(?:(?:(?:/(?:[-\w~!$+|.,=]|%[a-f\d]{2})+)+|/)+|\?|#)?(?#Query)(?:(?:\?(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)(?:&(?:[-\w~!$+|.,*:]|%[a-f\d{2}])+=(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)*)*(?#Anchor)(?:#(?:[-\w~!$+|.,*:=]|%[a-f\d]{2})*)?");

        public GestionFlowDocument(FlowDocumentReader flowDocumentReader, Paragraph paragraph, string forumCourant)
        {
            FlowDocumentReader = flowDocumentReader;
            Paragraph = paragraph;
            ForumCourant = forumCourant;
        }

        public void AjouterTexteQuitte(Clavardage clavardage)
        {
            Run runUserName = new Run(clavardage.Utilisateur.NomUtilisateur) { Foreground = CouleurNomUtilisateur, ToolTip = clavardage.Date.ToString() };
            Run runTexte = new Run(" a quitté") { Foreground = CouleurNomUtilisateur };
            LineBreak lineBreak = new LineBreak();
            Paragraph.Inlines.Add(runUserName);
            Paragraph.Inlines.Add(runTexte);
            Paragraph.Inlines.Add(lineBreak);

            FlowDocumentReaderScrollToEnd();

        }
        public void AjouterTexteConnecte(Clavardage clavardage)
        {
            Run runUserName = new Run(clavardage.Utilisateur.NomUtilisateur) { Foreground = CouleurNomUtilisateur, ToolTip = clavardage.Date.ToString() };
            Run runTexte = new Run(" est connecté") { Foreground = CouleurNomUtilisateur };
            Run runForums = new Run("(" + ForumCourant + ")") { Foreground = new SolidColorBrush(Colors.White) };
            LineBreak lineBreak = new LineBreak();

            Paragraph.Inlines.Add(runUserName);
            Paragraph.Inlines.Add(runTexte);
            Paragraph.Inlines.Add(runForums);
            Paragraph.Inlines.Add(AjouterImage("lien.png"));
            Paragraph.Inlines.Add(lineBreak);

            FlowDocumentReaderScrollToEnd();
        }
        public void AjouterTexteCommande(Clavardage clavardage)
        {
            if (clavardage.Texte.IndexOf("/q") == 0)
            {
                AjouterTexteQuitte(clavardage);
            }
            if (clavardage.Texte.IndexOf("/JOIN") == 0)
            {
                AjouterTexteConnecte(clavardage);
            }
            if (clavardage.Texte.IndexOf("/me") == 0)
            {
                AjouterTexteMe(clavardage);
            }
            if (clavardage.Texte.IndexOf("/update") == 0)
            {
                //Application.Current.Shutdown();
            }
        }
        public void AjouterTexteLog(Clavardage clavardage)
        {
            const string symboleSeparateur = ">";
            Run runUserName = new Run(clavardage.Utilisateur.NomUtilisateur) { Foreground = CouleurNomUtilisateur, ToolTip = clavardage.Date.ToString() };
            Run runSeparateur = new Run(symboleSeparateur) { Foreground = CouleurSeparateur };
            Run runTexte = new Run(clavardage.Texte) { Foreground = CouleurTexte };
            LineBreak lineBreak = new LineBreak();

            Paragraph.Inlines.Add(runUserName);
            Paragraph.Inlines.Add(runSeparateur);
            Paragraph.Inlines.Add(runTexte);
            if (EstUrlMatch(clavardage))
            {
                AjouterHyperlink(clavardage);
            }

            Paragraph.Inlines.Add(lineBreak);

            FlowDocumentReaderScrollToEnd();

            //if (clavardage.Texte.IndexOf("Vince") != -1)
            //{
            //    ObtenirNotification(clavardage);
            //}
        }
        public void AjouterTexteMe(Clavardage clavardage)
        {
            Run runUserName = new Run(clavardage.Utilisateur.NomUtilisateur) { Foreground = CouleurCommandeMe, ToolTip = clavardage.Date.ToString() };
            Run runTexte = new Run(clavardage.Texte.Substring(3, clavardage.Texte.Length - 3)) { Foreground = CouleurCommandeMe };
            LineBreak lineBreak = new LineBreak();
            Paragraph.Inlines.Add(runUserName);
            Paragraph.Inlines.Add(runTexte);
            Paragraph.Inlines.Add(lineBreak);
            FlowDocumentReaderScrollToEnd();
        }
        public void AjouterErreur(string erreur)
        {
            Run runTexte = new Run(erreur) { Foreground = CouleurErreur, Background = CouleurNoir };
            LineBreak lineBreak = new LineBreak();
            Paragraph.Inlines.Add(runTexte);
            Paragraph.Inlines.Add(lineBreak);
            FlowDocumentReaderScrollToEnd();
        }
        private void ObtenirNotification(Clavardage clavardage)
        {
            NotifyIcon notifyIcon = new NotifyIcon
                {
                    Icon = SystemIcons.Application,
                    BalloonTipTitle = @"Message de: " + clavardage.Utilisateur.NomUtilisateur + @" à " + clavardage.Date,
                    BalloonTipText = clavardage.Texte,
                    BalloonTipIcon = ToolTipIcon.Info,
                    Visible = true
                };
            notifyIcon.ShowBalloonTip(5000);
        }
        private void FlowDocumentReaderScrollToEnd()
        {
            var scrollViewer = FlowDocumentReader.FindFirstVisualDescendantOfType<ScrollViewer>();
            scrollViewer.ScrollToEnd();
        }

        private Image AjouterImage(string imageSrc)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(imageSrc, UriKind.Relative));
            Image image = new Image {Source = bitmap, Width = 16, Height = 16};
            return image;
        }

        private bool EstUrlMatch(Clavardage clavardage)
        {
            return _reURL.Matches(clavardage.Texte).Count > 0;
        }
        private void AjouterHyperlink(Clavardage clavardage)
        {
            foreach (Match match in _reURL.Matches(clavardage.Texte))
            {
                string lien = match.Value;

                Run runTexte = new Run(" - ") { Foreground = CouleurTexte };
                Paragraph.Inlines.Add(runTexte);

                Run run = new Run("Ouvrir le lien") { Foreground = CouleurLiens };
                Hyperlink hlink = new Hyperlink(run);
                if (lien.ToLower().IndexOf("http://") < 0)
                    lien = "http://" + lien;

                hlink.NavigateUri = new Uri(lien);
                hlink.RequestNavigate += OnUrlClick;
                Paragraph.Inlines.Add(hlink);


            }
        }
        private void OnUrlClick(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}
