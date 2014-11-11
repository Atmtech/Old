using System;
using System.Windows.Forms;

namespace ATMTECH.Mediator.Client
{
    public partial class FormMain : Form
    {
        private GestionPresentation _gestionPresentation;
        public GestionPresentation GestionPresentation { get { return _gestionPresentation ?? (_gestionPresentation = new GestionPresentation()); } }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GestionPresentation.EnvoyerClavardage("/JOIN");
            timerClavardage.Enabled = true;
            GestionPresentation.AfficherClavardage(richTextBoxClavardage);
            textBoxClavardage.Focus();
        }

        private void textBoxChat_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(textBoxClavardage.Text)) return;
            GestionPresentation.EnvoyerClavardage(textBoxClavardage.Text);
            textBoxClavardage.Text = "";
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionPresentation.EnvoyerClavardage("/q");
        }

        private void timerClavardage_Tick(object sender, EventArgs e)
        {
            GestionPresentation.AfficherClavardage(richTextBoxClavardage);
        }

        private void btnDernierClavardage_Click(object sender, EventArgs e)
        {
            GestionPresentation.AfficherClavardage(richTextBoxClavardage, 50);
        }

        private void timerFocus_Tick(object sender, EventArgs e)
        {
            textBoxClavardage.Focus();
            timerFocus.Enabled = false;
        }

        private void btnZoomPlus_Click(object sender, EventArgs e)
        {
            richTextBoxClavardage.ZoomFactor += (float)0.1;
        }

        private void btnZoomMoins_Click(object sender, EventArgs e)
        {
            if (richTextBoxClavardage.ZoomFactor >= 0.8)
                richTextBoxClavardage.ZoomFactor -= (float)0.1;
        }



    }
}
