using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ATMTECH.WPF.Themes;
using GeniteurInformationnel.Entities;
using GeniteurInformationnel.Services;

namespace GeniteurInformationnel
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public CommandeAjouterTexte AjouterTexte { get { return new CommandeAjouterTexte { Paragraph = paragrapheConformite }; } }
        public GeniteurInformationnelService GeniteurInformationnelService
        {
            get
            {
                return new GeniteurInformationnelService { NomBDSelectionne = NomBDSelectionne, NomServeurSelectionne = NomServeurSelectionne, NomTableSelectionne = NomTableSelectionne };
            }
        }

        public string NomServeurSelectionne { get { return cbxServeur.SelectedValue != null ? cbxServeur.SelectedValue.ToString() : "SQLV1-DEV\\DEV1"; } }
        public string NomBDSelectionne { get { return cbxBDSource.SelectedValue != null ? cbxBDSource.SelectedValue.ToString() : "master"; } }
        public string NomTableSelectionne { get { return cbxNomTable.SelectedValue != null ? cbxNomTable.SelectedValue.ToString() : ""; } }
       
        private void ConstructionConformite()
        {
            //paragrapheConformite.Inlines.Clear();
            //string[] readText = File.ReadAllLines(@"C:\Dev\Atmtech\GeniteurInformationnel\TemplateConformite.txt");
            //foreach (string s in readText)
            //{
            //    string valeurTexteRemplace = RemplacerTexte(s);
            //    AjouterTexte.AjouterParagraphe(MotCle.runTexte(valeurTexteRemplace));
            //    paragrapheConformite.Inlines.Add(new LineBreak());
            //}
        }
      
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            IList<Serveur> serveurs = GeniteurInformationnelService.ObtenirListeServeur();
            foreach (Serveur serveur in serveurs)
            {
                cbxServeur.Items.Add(serveur.NomServeur);
            }

            this.ApplyTheme("ExpressionDark");
            AfficherEtapeParametreInitiaux();
        }
        private void cbxServeurSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IList<BaseDonnee> baseDonnees = GeniteurInformationnelService.ObtenirListeBD();
            cbxBDSource.Items.Clear();
            foreach (BaseDonnee baseDonnee in baseDonnees)
            {
                cbxBDSource.Items.Add(baseDonnee.NomBD);
            }
        }
        private void cbxBDSourceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IList<Tables> nomTables = GeniteurInformationnelService.ObtenirListeTable();
            foreach (Tables nomTable in nomTables)
            {
                cbxNomTable.Items.Add(nomTable.NomTable);
            }
        }
    

        private void AfficherEtapeSelectionColonne()
        {
            grdEtapeParametreInitiaux.Visibility = Visibility.Hidden;
            grdEtapeSelectionCleRecherche.Visibility = Visibility.Hidden;
            grdEtapeSelectionColonne.Visibility = Visibility.Visible;
            grdEtapefinale.Visibility = Visibility.Hidden;

            IList<Colonne> colonnes = GeniteurInformationnelService.ObtenirListeColonne();
            lstColonne.ItemsSource = colonnes;
        }
        private void AfficherEtapeParametreInitiaux()
        {
            grdEtapeParametreInitiaux.Visibility = Visibility.Visible;
            grdEtapeSelectionCleRecherche.Visibility = Visibility.Hidden;
            grdEtapeSelectionColonne.Visibility = Visibility.Hidden;
            grdEtapefinale.Visibility = Visibility.Hidden;
        }
        private void AfficherEtapeFinale()
        {
            grdEtapeParametreInitiaux.Visibility = Visibility.Hidden;
            grdEtapeSelectionCleRecherche.Visibility = Visibility.Hidden;
            grdEtapeSelectionColonne.Visibility = Visibility.Hidden;
            grdEtapefinale.Visibility = Visibility.Visible;
        }
        private void AfficherEtapeCleRecherche()
        {
            grdEtapeParametreInitiaux.Visibility = Visibility.Hidden;
            grdEtapeSelectionCleRecherche.Visibility = Visibility.Visible;
            grdEtapeSelectionColonne.Visibility = Visibility.Hidden;
            grdEtapefinale.Visibility = Visibility.Hidden;
        }
        private void btnEtapePrecedenteClick(object sender, RoutedEventArgs e)
        {
            if (grdEtapeParametreInitiaux.Visibility == Visibility.Visible)
            {
                // rien
            }
            if (grdEtapeSelectionCleRecherche.Visibility == Visibility.Visible)
            {
                AfficherEtapeSelectionColonne();
                return;
            }
            if (grdEtapeSelectionColonne.Visibility == Visibility.Visible)
            {
                AfficherEtapeParametreInitiaux();
                return;
            }
            if (grdEtapefinale.Visibility == Visibility.Visible)
            {
                AfficherEtapeCleRecherche();
            }
        }
        private void btnEtapeSuivanteClick(object sender, RoutedEventArgs e)
        {
            if (grdEtapeParametreInitiaux.Visibility == Visibility.Visible)
            {
                AfficherEtapeSelectionColonne();
                return;
            }
            if (grdEtapeSelectionCleRecherche.Visibility == Visibility.Visible)
            {
                AfficherEtapeFinale();
                return;
            }
            if (grdEtapeSelectionColonne.Visibility == Visibility.Visible)
            {
                AfficherEtapeCleRecherche();
                return;
            }
            if (grdEtapefinale.Visibility == Visibility.Visible)
            {
                // rien
            }
        }


        private void cbxNomTableSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtNomProcedureStockeConformite.Text = "spED_Obtenir" + NomTableSelectionne;
            txtNomProcedureStockeDistribution.Text = "spED_Distribue" + NomTableSelectionne;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IList<Jointure> st = GeniteurInformationnelService.ObtenirListeDesTableJoinEpure("Immeuble");
            foreach (Jointure jointure in st)
            {
                txtTest.Text += jointure.LibelleJointure + "\r";
            }
        }
    }
}
