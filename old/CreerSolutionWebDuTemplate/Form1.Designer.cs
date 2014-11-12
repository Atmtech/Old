namespace CreerSolutionWebDuTemplate
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreer = new System.Windows.Forms.Button();
            this.txtProjet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(392, 10);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(75, 23);
            this.btnCreer.TabIndex = 0;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // txtProjet
            // 
            this.txtProjet.Location = new System.Drawing.Point(12, 10);
            this.txtProjet.Name = "txtProjet";
            this.txtProjet.Size = new System.Drawing.Size(373, 20);
            this.txtProjet.TabIndex = 1;
            this.txtProjet.Text = "Template";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(479, 44);
            this.Controls.Add(this.txtProjet);
            this.Controls.Add(this.btnCreer);
            this.Name = "Form1";
            this.Text = "Créer solution web à partir du template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreer;
        private System.Windows.Forms.TextBox txtProjet;
    }
}

