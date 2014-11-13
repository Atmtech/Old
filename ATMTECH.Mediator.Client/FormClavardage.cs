using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ATMTECH.Mediator.Entities;

namespace ATMTECH.Mediator.Client
{
    public partial class FormClavardage : Form
    {
        private GestionPresentation _gestionPresentation;
        public GestionPresentation GestionPresentation { get { return _gestionPresentation ?? (_gestionPresentation = new GestionPresentation { RichTextBox = richTextBoxClavardage }); } }


        public FormClavardage()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ActiveControl = textBoxClavardage;
            GestionPresentation.EnvoyerClavardage("/JOIN");
            timerClavardage.Enabled = true;
            GestionPresentation.AfficherClavardage();
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
            IList<Clavardage> clavardages = GestionPresentation.AfficherClavardage();
            if (clavardages != null)
            {
                foreach (Clavardage clavardage in clavardages.Where(clavardage => !GestionPresentation.EstCommande(clavardage.Texte)))
                {
                    FlashWindow.Flash(this);
                    richTextBoxClavardage.SelectionStart = richTextBoxClavardage.Text.Length;
                    richTextBoxClavardage.ScrollToCaret();
                }
                
            }
        }

        private void btnDernierClavardage_Click(object sender, EventArgs e)
        {
            GestionPresentation.AfficherClavardage(50);
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

        private void richTextBoxClavardage_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);

        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                WindowState = FormWindowState.Minimized;
        }

        private void textBoxClavardage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                WindowState = FormWindowState.Minimized;
        }

        private void richTextBoxClavardage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                WindowState = FormWindowState.Minimized;
        }

        private void textBoxClavardage_Leave(object sender, EventArgs e)
        {
            textBoxClavardage.Focus();
        }



    }
}
