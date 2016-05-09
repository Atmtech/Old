namespace ATMTECH.FishingAtWork.Server
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
            this.timerTrip = new System.Windows.Forms.Timer(this.components);
            this.lstSite = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstStatus = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusTotalCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.cmbTimer = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnSetTimer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timerOnline = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerTrip
            // 
            this.timerTrip.Enabled = true;
            this.timerTrip.Interval = 1000;
            this.timerTrip.Tick += new System.EventHandler(this.timerTrip_Tick);
            // 
            // lstSite
            // 
            this.lstSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8});
            this.lstSite.Location = new System.Drawing.Point(13, 35);
            this.lstSite.Name = "lstSite";
            this.lstSite.Size = new System.Drawing.Size(959, 143);
            this.lstSite.TabIndex = 1;
            this.lstSite.UseCompatibleStateImageBehavior = false;
            this.lstSite.View = System.Windows.Forms.View.Details;
            this.lstSite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSite_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Site";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre de pêcheur";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre de capture";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Total espèces";
            this.columnHeader8.Width = 100;
            // 
            // lstStatus
            // 
            this.lstStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader7});
            this.lstStatus.Location = new System.Drawing.Point(12, 194);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(960, 218);
            this.lstStatus.TabIndex = 3;
            this.lstStatus.UseCompatibleStateImageBehavior = false;
            this.lstStatus.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Journée ";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Site";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Pêcheur";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Leurre";
            this.columnHeader6.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Espèce";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Poids";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatusTotalCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 440);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "caca";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatusTotalCount
            // 
            this.lblStatusTotalCount.Name = "lblStatusTotalCount";
            this.lblStatusTotalCount.Size = new System.Drawing.Size(0, 17);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 419);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(38, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Erreur:";
            // 
            // cmbTimer
            // 
            this.cmbTimer.FormattingEnabled = true;
            this.cmbTimer.Items.AddRange(new object[] {
            "100",
            "500",
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "6000",
            "7000",
            "8000",
            "9000",
            "10000"});
            this.cmbTimer.Location = new System.Drawing.Point(62, 8);
            this.cmbTimer.Name = "cmbTimer";
            this.cmbTimer.Size = new System.Drawing.Size(51, 21);
            this.cmbTimer.TabIndex = 6;
            this.cmbTimer.Text = "1000";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(13, 11);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(36, 13);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Timer:";
            // 
            // btnSetTimer
            // 
            this.btnSetTimer.Location = new System.Drawing.Point(119, 6);
            this.btnSetTimer.Name = "btnSetTimer";
            this.btnSetTimer.Size = new System.Drawing.Size(75, 23);
            this.btnSetTimer.TabIndex = 8;
            this.btnSetTimer.Text = "Appliquer";
            this.btnSetTimer.UseVisualStyleBackColor = true;
            this.btnSetTimer.Click += new System.EventHandler(this.btnSetTimer_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(816, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Les espèces";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // timerOnline
            // 
            this.timerOnline.Enabled = true;
            this.timerOnline.Interval = 5000;
            this.timerOnline.Tick += new System.EventHandler(this.timerOnline_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetTimer);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.cmbTimer);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lstStatus);
            this.Controls.Add(this.lstSite);
            this.Name = "FormMain";
            this.Text = "FishingAtWork server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerTrip;
        private System.Windows.Forms.ListView lstSite;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lstStatus;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusTotalCount;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ComboBox cmbTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnSetTimer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timerOnline;

    }
}

