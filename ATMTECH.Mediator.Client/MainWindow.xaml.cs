using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ATMTECH.Mediator.Entities;
using ATMTECH.WPF.Themes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace ATMTECH.Mediator.Client
{
    public partial class MainWindow
    {
        public const string TYPE_LOG_COMMAND = "COMMAND";
        public const string TYPE_LOG_CHAT = "CHAT";
        public Utilisateur UtilisateurAuthentifie { get; set; }

        private DispatcherTimer _timer;
        private int _chatCourant;
        private string _forumCourant;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MediatorPresenter MediatorPresenter { get { return new MediatorPresenter(); } }
        public GestionFlowDocument GestionFlowDocument { get { return new GestionFlowDocument(flowDocumentReader, paragrapheLog, _forumCourant); } }

        private void txtLog_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key != Key.Enter) return;
                if (string.IsNullOrWhiteSpace(txtClavardage.Text)) return;
                MediatorPresenter.EnvoyerClavardage(UtilisateurAuthentifie.NoUtilisateur, txtClavardage.Text, "#DEFAULT");
                txtClavardage.Text = "";
                DemarrerTimer();
            }
            catch (Exception ex)
            {
                GestionFlowDocument.AjouterErreur(ex.Message);
                ArreterTimer();
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                WindowState = WindowState.Minimized;
        }
        private void ObtenirUtilisateurAuthentifie()
        {
            try
            {
                Utilisateur utilisateur = MediatorPresenter.ClavardageService.ObtenirUtilisateur().FirstOrDefault(x => x.NomUtilisateur2 == Environment.UserName);
                if (utilisateur != null)
                {
                    UtilisateurAuthentifie = utilisateur;
                    MediatorPresenter.EnvoyerCommande(UtilisateurAuthentifie.NoUtilisateur, "/JOIN", "#DEFAULT");
                    return;
                }

                GestionFlowDocument.AjouterErreur(string.Format("Vous nêtes pas défini sur le serveur de BD votre nom d'hôte {0} n'existe pas", Environment.MachineName));
                ArreterTimer();
                txtClavardage.IsEnabled = false;
            }
            catch (Exception ex)
            {
                GestionFlowDocument.AjouterErreur(ex.Message);
                ArreterTimer();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer = new DispatcherTimer();
                _timer.Tick += delegate { ObtenirClavardage(); };

                DemarrerTimer();
                ObtenirUtilisateurAuthentifie();
                this.ApplyTheme("ExpressionDark");
                _forumCourant = "#DEFAULT";

                txtClavardage.Focus();
            }
            catch (Exception ex)
            {
                GestionFlowDocument.AjouterErreur(ex.Message);
                ArreterTimer();
            }


        }
        private void DemarrerTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Start();
            OuvrirLumiere();
        }
        private void ObtenirClavardage()
        {
            try
            {
                IList<Clavardage> clavardages = MediatorPresenter.ObtenirClavardage(_chatCourant);
                if (clavardages == null) return;
                _chatCourant = clavardages.Max(x => x.NoClavardage);
                AfficherClavardage(clavardages);
            }
            catch (Exception ex)
            {
                GestionFlowDocument.AjouterErreur(ex.Message);
                ArreterTimer();
            }
        }

        private void OuvrirLumiere()
        {
            lumiereOn.Visibility = Visibility.Visible;
            lumiereOff.Visibility = Visibility.Hidden;
        }

        private void FermerLumiere()
        {
            lumiereOn.Visibility = Visibility.Hidden;
            lumiereOff.Visibility = Visibility.Visible;
        }

        private void ArreterTimer()
        {
            FermerLumiere();
            _timer.Stop();
        }

        private void ObtenirListeClavardage()
        {
            try
            {
                int nombreAnterieur = 10;
                if (!string.IsNullOrEmpty(cboNombreClavardageAnterieur.Text))
                {
                    nombreAnterieur = Convert.ToInt32(cboNombreClavardageAnterieur.Text);
                }
                IList<Clavardage> clavardages = MediatorPresenter.ObtenirListeClavardage(nombreAnterieur);
                if (clavardages == null) return;
                GestionFlowDocument.AjouterErreur("=======================");
                AfficherClavardage(clavardages);
                GestionFlowDocument.AjouterErreur("=======================");

            }
            catch (Exception ex)
            {
                GestionFlowDocument.AjouterErreur(ex.Message);
                ArreterTimer();
            }
        }

        private void AfficherClavardage(IList<Clavardage> clavardages)
        {
            foreach (Clavardage clavardage in clavardages)
            {
                switch (clavardage.Type)
                {
                    case TYPE_LOG_CHAT:
                        GestionFlowDocument.AjouterTexteLog(clavardage);
                        if (clavardage.NoUtilisateur != UtilisateurAuthentifie.NoUtilisateur)
                        {
                            FlashWindow.Flash();
                        }
                        break;
                    default:
                        GestionFlowDocument.AjouterTexteCommande(clavardage);
                        break;
                }
            }
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            MediatorPresenter.EnvoyerCommande(UtilisateurAuthentifie.NoUtilisateur, "/q", "#DEFAULT");
        }

        private void btnObtenir10DernierClick(object sender, RoutedEventArgs e)
        {
            ObtenirListeClavardage();
        }

        private void txtLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Escape)
                ArreterTimer();
        }
    }

}
