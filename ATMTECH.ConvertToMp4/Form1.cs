using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NReco.VideoConverter;

namespace ATMTECH.ConvertToMp4
{
    public partial class FormMain : Form
    {
        public string Resultat { set; get; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                // Open the selected file to read.
                lblFileName.Text = openFileDialog1.FileName;

            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            FFMpegConverter ffMpegConverter = new FFMpegConverter();

            ffMpegConverter.ConvertProgress += FfMpegConverterOnConvertProgress;
            timer1.Enabled = true;
            ffMpegConverter.ConvertMedia(lblFileName.Text, lblFileName.Text + ".mp4", Format.mp4);
        }

        private void FfMpegConverterOnConvertProgress(object sender, ConvertProgressEventArgs convertProgressEventArgs)
        {
            textBox1.Invoke(new Action(() => { textBox1.Text += "1"; }));

            Resultat += convertProgressEventArgs.Processed.Seconds.ToString();
            //textBox1.Invalidate();
            //textBox1.Text += Resultat;
            //textBox1.Update();
            //Invoke(new Action(() => textBox1.Text = "Completed!"));


            //Action action = new Action(Test);
            //action.Invoke();
            //textBox1.Invoke(new Action(Test));
            //progressBar1.Invoke(new Action(() =>
            //{

            //    progressBar1.PerformStep();// = convertProgressEventArgs.Processed.Seconds; //Or whatever calculation you want
            //    Application.DoEvents();
            //}));

            //   lblTotalDuration.Text = convertProgressEventArgs.TotalDuration.ToString();
            //  progressBar1.Value += 1;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //textBox1.Invalidate();
            //textBox1.Text += Resultat;
            //textBox1.Update();
            //Invoke(new Action(() => textBox1.Text = Resultat));

        }
    }
}
