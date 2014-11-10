using System.Drawing;
using System.Windows.Forms;

namespace ATMTECH.Mediator.Client
{
    public class GestionFormulaire
    {
        public static void GererAffichage(RichTextBox richTextbox, TextBox textBox, PaintEventArgs e)
        {
            richTextbox.BorderStyle = BorderStyle.None;
            textBox.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.Gray);
            Graphics g = e.Graphics;
            const int variance = 1;
            g.DrawRectangle(p, new Rectangle(textBox.Location.X - variance, textBox.Location.Y - variance, textBox.Width + variance, textBox.Height + variance));
            g.DrawRectangle(p, new Rectangle(richTextbox.Location.X - variance, richTextbox.Location.Y - variance, richTextbox.Width + variance, richTextbox.Height + variance));
            textBox.AutoSize = false;
            textBox.Size = new Size(textBox.Width, 17);

            textBox.Focus();
        }
    }
}
