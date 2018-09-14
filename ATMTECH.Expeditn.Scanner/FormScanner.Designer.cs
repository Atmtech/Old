namespace ATMTECH.Expeditn.Scanner
{
    partial class FormScanner
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
            this.btnScan = new System.Windows.Forms.Button();
            this.lsvScan = new System.Windows.Forms.ListView();
            this.DateDepart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateFin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Utilisateur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeScan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.DarkCyan;
            this.btnScan.FlatAppearance.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnScan.ForeColor = System.Drawing.Color.White;
            this.btnScan.Location = new System.Drawing.Point(12, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(133, 32);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Démarrer scan";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lsvScan
            // 
            this.lsvScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lsvScan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DateDepart,
            this.DateFin,
            this.Utilisateur,
            this.TypeScan,
            this.Url});
            this.lsvScan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvScan.ForeColor = System.Drawing.Color.White;
            this.lsvScan.FullRowSelect = true;
            this.lsvScan.Location = new System.Drawing.Point(12, 50);
            this.lsvScan.Name = "lsvScan";
            this.lsvScan.Size = new System.Drawing.Size(1249, 465);
            this.lsvScan.TabIndex = 50;
            this.lsvScan.UseCompatibleStateImageBehavior = false;
            this.lsvScan.View = System.Windows.Forms.View.Details;
            // 
            // DateDepart
            // 
            this.DateDepart.Text = "Date départ";
            this.DateDepart.Width = 200;
            // 
            // DateFin
            // 
            this.DateFin.Text = "Date fin";
            this.DateFin.Width = 200;
            // 
            // Utilisateur
            // 
            this.Utilisateur.Text = "Utilisateur";
            this.Utilisateur.Width = 200;
            // 
            // TypeScan
            // 
            this.TypeScan.Text = "Type de scan";
            this.TypeScan.Width = 100;
            // 
            // Url
            // 
            this.Url.Text = "Url";
            this.Url.Width = 400;
            // 
            // FormScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1273, 527);
            this.Controls.Add(this.lsvScan);
            this.Controls.Add(this.btnScan);
            this.Name = "FormScanner";
            this.Text = "Scanner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormScanner_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListView lsvScan;
        private System.Windows.Forms.ColumnHeader Utilisateur;
        private System.Windows.Forms.ColumnHeader TypeScan;
        private System.Windows.Forms.ColumnHeader Url;
        private System.Windows.Forms.ColumnHeader DateDepart;
        private System.Windows.Forms.ColumnHeader DateFin;
    }
}

