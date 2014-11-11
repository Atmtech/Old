namespace ATMTECH.Mediator.Client
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.richTextBoxClavardage = new System.Windows.Forms.RichTextBox();
            this.textBoxClavardage = new System.Windows.Forms.TextBox();
            this.timerClavardage = new System.Windows.Forms.Timer(this.components);
            this.btnDernierClavardage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxClavardage
            // 
            this.richTextBoxClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxClavardage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.richTextBoxClavardage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxClavardage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBoxClavardage.ForeColor = System.Drawing.Color.White;
            this.richTextBoxClavardage.Location = new System.Drawing.Point(0, 12);
            this.richTextBoxClavardage.Name = "richTextBoxClavardage";
            this.richTextBoxClavardage.ReadOnly = true;
            this.richTextBoxClavardage.ShowSelectionMargin = true;
            this.richTextBoxClavardage.Size = new System.Drawing.Size(840, 175);
            this.richTextBoxClavardage.TabIndex = 0;
            this.richTextBoxClavardage.Text = "";
            // 
            // textBoxClavardage
            // 
            this.textBoxClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClavardage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxClavardage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClavardage.ForeColor = System.Drawing.Color.White;
            this.textBoxClavardage.Location = new System.Drawing.Point(4, 195);
            this.textBoxClavardage.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxClavardage.Name = "textBoxClavardage";
            this.textBoxClavardage.Size = new System.Drawing.Size(757, 20);
            this.textBoxClavardage.TabIndex = 1;
            this.textBoxClavardage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyUp);
            // 
            // timerClavardage
            // 
            this.timerClavardage.Interval = 1000;
            this.timerClavardage.Tick += new System.EventHandler(this.timerClavardage_Tick);
            // 
            // btnDernierClavardage
            // 
            this.btnDernierClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDernierClavardage.FlatAppearance.BorderSize = 0;
            this.btnDernierClavardage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDernierClavardage.ForeColor = System.Drawing.Color.White;
            this.btnDernierClavardage.Location = new System.Drawing.Point(764, 194);
            this.btnDernierClavardage.Name = "btnDernierClavardage";
            this.btnDernierClavardage.Size = new System.Drawing.Size(75, 22);
            this.btnDernierClavardage.TabIndex = 2;
            this.btnDernierClavardage.Text = "50 derniers";
            this.btnDernierClavardage.UseVisualStyleBackColor = true;
            this.btnDernierClavardage.Click += new System.EventHandler(this.btnDernierClavardage_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(841, 219);
            this.Controls.Add(this.btnDernierClavardage);
            this.Controls.Add(this.textBoxClavardage);
            this.Controls.Add(this.richTextBoxClavardage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Mediator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxClavardage;
        private System.Windows.Forms.TextBox textBoxClavardage;
        private System.Windows.Forms.Timer timerClavardage;
        private System.Windows.Forms.Button btnDernierClavardage;
    }
}

