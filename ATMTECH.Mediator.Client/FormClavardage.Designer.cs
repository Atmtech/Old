namespace ATMTECH.Mediator.Client
{
    partial class FormClavardage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClavardage));
            this.richTextBoxClavardage = new System.Windows.Forms.RichTextBox();
            this.textBoxClavardage = new System.Windows.Forms.TextBox();
            this.timerClavardage = new System.Windows.Forms.Timer(this.components);
            this.btnDernierClavardage = new System.Windows.Forms.Button();
            this.btnZoomPlus = new System.Windows.Forms.Button();
            this.btnZoomMoins = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.richTextBoxClavardage.Location = new System.Drawing.Point(3, 7);
            this.richTextBoxClavardage.Name = "richTextBoxClavardage";
            this.richTextBoxClavardage.ReadOnly = true;
            this.richTextBoxClavardage.ShowSelectionMargin = true;
            this.richTextBoxClavardage.Size = new System.Drawing.Size(836, 188);
            this.richTextBoxClavardage.TabIndex = 0;
            this.richTextBoxClavardage.Text = "";
            this.richTextBoxClavardage.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxClavardage_LinkClicked);
            this.richTextBoxClavardage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxClavardage_KeyDown);
            // 
            // textBoxClavardage
            // 
            this.textBoxClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClavardage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxClavardage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClavardage.ForeColor = System.Drawing.Color.White;
            this.textBoxClavardage.Location = new System.Drawing.Point(5, 196);
            this.textBoxClavardage.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxClavardage.Name = "textBoxClavardage";
            this.textBoxClavardage.Size = new System.Drawing.Size(662, 20);
            this.textBoxClavardage.TabIndex = 1;
            this.textBoxClavardage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClavardage_KeyDown);
            this.textBoxClavardage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyUp);
            this.textBoxClavardage.Leave += new System.EventHandler(this.textBoxClavardage_Leave);
            // 
            // timerClavardage
            // 
            this.timerClavardage.Interval = 1000;
            this.timerClavardage.Tick += new System.EventHandler(this.timerClavardage_Tick);
            // 
            // btnDernierClavardage
            // 
            this.btnDernierClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDernierClavardage.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDernierClavardage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDernierClavardage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDernierClavardage.ForeColor = System.Drawing.Color.White;
            this.btnDernierClavardage.Location = new System.Drawing.Point(745, 195);
            this.btnDernierClavardage.Name = "btnDernierClavardage";
            this.btnDernierClavardage.Size = new System.Drawing.Size(94, 22);
            this.btnDernierClavardage.TabIndex = 2;
            this.btnDernierClavardage.Text = "50 derniers";
            this.btnDernierClavardage.UseVisualStyleBackColor = true;
            this.btnDernierClavardage.Click += new System.EventHandler(this.btnDernierClavardage_Click);
            // 
            // btnZoomPlus
            // 
            this.btnZoomPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomPlus.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnZoomPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomPlus.ForeColor = System.Drawing.Color.White;
            this.btnZoomPlus.Location = new System.Drawing.Point(670, 195);
            this.btnZoomPlus.Name = "btnZoomPlus";
            this.btnZoomPlus.Size = new System.Drawing.Size(35, 22);
            this.btnZoomPlus.TabIndex = 3;
            this.btnZoomPlus.Text = "A+";
            this.btnZoomPlus.UseVisualStyleBackColor = true;
            this.btnZoomPlus.Click += new System.EventHandler(this.btnZoomPlus_Click);
            // 
            // btnZoomMoins
            // 
            this.btnZoomMoins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomMoins.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnZoomMoins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomMoins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomMoins.ForeColor = System.Drawing.Color.White;
            this.btnZoomMoins.Location = new System.Drawing.Point(706, 195);
            this.btnZoomMoins.Name = "btnZoomMoins";
            this.btnZoomMoins.Size = new System.Drawing.Size(38, 22);
            this.btnZoomMoins.TabIndex = 4;
            this.btnZoomMoins.Text = "A-";
            this.btnZoomMoins.UseVisualStyleBackColor = true;
            this.btnZoomMoins.Click += new System.EventHandler(this.btnZoomMoins_Click);
            // 
            // FormClavardage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(841, 219);
            this.Controls.Add(this.btnZoomMoins);
            this.Controls.Add(this.btnZoomPlus);
            this.Controls.Add(this.btnDernierClavardage);
            this.Controls.Add(this.textBoxClavardage);
            this.Controls.Add(this.richTextBoxClavardage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClavardage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mediator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxClavardage;
        private System.Windows.Forms.TextBox textBoxClavardage;
        private System.Windows.Forms.Timer timerClavardage;
        private System.Windows.Forms.Button btnDernierClavardage;
        private System.Windows.Forms.Button btnZoomPlus;
        private System.Windows.Forms.Button btnZoomMoins;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

