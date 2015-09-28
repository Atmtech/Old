using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ATMTECH.Mediator.DAO;
using ATMTECH.Mediator.Entities;
using ATMTECH.Mediator.Services;
using FastColoredTextBoxNS;
using Char = FastColoredTextBoxNS.Char;

namespace ATMTECH.Mediator.Client
{
    public partial class FormClavardage : Form
    {
        private GestionPresentation _gestionPresentation;

        public GestionPresentation GestionPresentation
        {
            get
            {
                return _gestionPresentation ??
                       (_gestionPresentation =
                        new GestionPresentation { FastColoredTextBox = fastColoredTextBoxClavardage });
            }
        }

        private Boolean fastColoredTextBoxAutoScroll = true;
        private FormWindowState LastWindowState = FormWindowState.Minimized;

        public FormClavardage()
        {
            InitializeComponent();
        }

        private void FormClavardage_Load(object sender, EventArgs e)
        {
            ActiveControl = txtClavardage;
            GestionPresentation.EnvoyerClavardage("/JOIN");
            timerClavardage.Enabled = true;
            GestionPresentation.AfficherClavardage();
        }

        private void FormClavardage_Activated(object sender, EventArgs e)
        {
            txtClavardage.Focus();
        }

        private void FormClavardage_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionPresentation.EnvoyerClavardage("/q");
        }

        private void FormClavardage_SizeChanged(object sender, EventArgs e)
        {
            if (fastColoredTextBoxAutoScroll) fastColoredTextBoxClavardage.GoEnd();
        }

        private void timerClavardage_Tick(object sender, EventArgs e)
        {

            if (new DAOServeur().EstServeurExistant())
            {

                IList<Clavardage> clavardages = GestionPresentation.AfficherClavardage();
                if (clavardages != null)
                {
                    foreach (Clavardage clavardage in clavardages.Where(clavardage => !GestionPresentation.EstCommande(clavardage.Texte)))
                    {
                        if (PlatformInvocationService.IsActive(Handle) == false) FlashWindow.Flash(this, 3);
                    }
                }

                if (fastColoredTextBoxAutoScroll) fastColoredTextBoxClavardage.GoEnd();
            }
            else
            {
                GestionPresentation.AjouterTexte("Le serveur n'est pas disponible ... Tentative de reconnection dans 10 secondes", GestionPresentation.RedStyle);
                GestionPresentation.AjouterSautLigne();
                timerClavardage.Enabled = false;
                txtClavardage.Enabled = false;
                timerReconnection.Enabled = true;
                RafraichirControle();
            }
        }

        private void textBoxChat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(txtClavardage.Text)) return;


            if (new DAOServeur().EstServeurExistant())
            {
                GestionPresentation.EnvoyerClavardage(txtClavardage.Text);
                txtClavardage.Text = "";
            }
            else
            {
                GestionPresentation.AjouterTexte("Le serveur n'est pas disponible ...", GestionPresentation.RedStyle);
                GestionPresentation.AjouterSautLigne();
                timerClavardage.Enabled = false;
                RafraichirControle();
            }
        }

        private void btnDernierClavardage_Click(object sender, EventArgs e)
        {
            GestionPresentation.AfficherClavardage(50);
        }

        private void fastColoredTextBoxClavardage_Click(object sender, EventArgs e)
        {
            fastColoredTextBoxAutoScroll = false;
        }

        private void fastColoredTextBoxClavardage_Scroll(object sender, ScrollEventArgs e)
        {
            fastColoredTextBoxClavardage.Focus();
            fastColoredTextBoxAutoScroll = false;
        }

        private void fastColoredTextBoxClavardage_Leave(object sender, EventArgs e)
        {
            fastColoredTextBoxAutoScroll = true;
        }

        private void FormClavardage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) WindowState = FormWindowState.Minimized;
        }

        private void fastColoredTextBoxClavardage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) WindowState = FormWindowState.Minimized;
        }

        private void textBoxClavardage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) WindowState = FormWindowState.Minimized;
        }

        private void btnDernierClavardage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) WindowState = FormWindowState.Minimized;
        }

        private void FormClavardage_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;

                if (WindowState == FormWindowState.Maximized) txtClavardage.Focus();
                if (WindowState == FormWindowState.Normal) txtClavardage.Focus();
            }
        }

        private void fastColoredTextBoxClavardage_MouseMove(object sender, MouseEventArgs e)
        {
            var p = fastColoredTextBoxClavardage.PointToPlace(e.Location);
            fastColoredTextBoxClavardage.Cursor = GestionPresentation.EstUnLien(p) ? Cursors.Hand : Cursors.IBeam;
        }

        private void fastColoredTextBoxClavardage_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(GestionPresentation.Link);
            e.ChangedRange.SetStyle(GestionPresentation.Link, @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?");
        }

        private void fastColoredTextBoxClavardage_MouseDown(object sender, MouseEventArgs e)
        {
            var p = fastColoredTextBoxClavardage.PointToPlace(e.Location);
            if (GestionPresentation.EstUnLien(p))
            {
                Process.Start(fastColoredTextBoxClavardage.GetRange(p, p).GetFragment(@"[\S]").Text);
            }
        }

        private void fastColoredTextBoxClavardage_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            int noLigneToolTip = fastColoredTextBoxClavardage.LinesCount - e.Place.iLine - 2;

            try
            {
                if (noLigneToolTip >= 0)
                    e.ToolTipText = GestionPresentation.ObtenirDateClavardage(noLigneToolTip).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void timerReconnection_Tick(object sender, EventArgs e)
        {
            if (new DAOServeur().EstServeurExistant())
            {
                timerReconnection.Enabled = false;
                timerClavardage.Enabled = true;
                txtClavardage.Enabled = true;
            }
            else
            {
                GestionPresentation.AjouterTexte("Tentative de reconnection après 10 secondes ...", GestionPresentation.RedStyle);
                GestionPresentation.AjouterSautLigne();
                RafraichirControle();
            }
        }

        private void RafraichirControle()
        {
            txtClavardage.Refresh();
            fastColoredTextBoxClavardage.Refresh();
            Refresh();
        }



    }
}
