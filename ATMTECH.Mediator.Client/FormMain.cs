using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATMTECH.Mediator.Client
{
    public partial class FormMain : Form
    {
        public GestionPresentation GestionPresentation { get { return new GestionPresentation(); } }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            GestionFormulaire.GererAffichage(richTextBoxClavardage, textBoxClavardage, e);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void textBoxChat_KeyUp(object sender, KeyEventArgs e)
        {
            GestionPresentation.EnvoyerClavardage(textBoxClavardage, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionPresentation.EnvoyerCommande("/q", "#DEFAULT");
        }



    }
}
