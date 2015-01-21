using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
  //          DirectoryInfo di = new DirectoryInfo(@"C:\dev\Atmtech\");
//            FileInfo[] files = di.GetFiles("*.dll");
            foreach (string enumerateFile in Directory.EnumerateFiles(@"C:\dev\Atmtech\", "*.dll", SearchOption.AllDirectories))
            {
                if (enumerateFile.IndexOf(@"Library\") == -1)
                {
                    txtDisplay.Text += enumerateFile + Environment.NewLine;
                    File.Delete(enumerateFile);
                }
                
            }
        }
    }
}
