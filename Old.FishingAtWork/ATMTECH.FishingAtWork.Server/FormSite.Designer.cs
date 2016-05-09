namespace ATMTECH.FishingAtWork.Server
{
    partial class FormSite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSite = new System.Windows.Forms.Label();
            this.pnlCoordinate = new System.Windows.Forms.Panel();
            this.btnShowCoordinate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSite.ForeColor = System.Drawing.Color.Black;
            this.lblSite.Location = new System.Drawing.Point(9, 15);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(41, 13);
            this.lblSite.TabIndex = 0;
            this.lblSite.Text = "label1";
            // 
            // pnlCoordinate
            // 
            this.pnlCoordinate.Location = new System.Drawing.Point(12, 44);
            this.pnlCoordinate.Name = "pnlCoordinate";
            this.pnlCoordinate.Size = new System.Drawing.Size(800, 600);
            this.pnlCoordinate.TabIndex = 2;
            this.pnlCoordinate.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCoordinate_Paint);
            // 
            // btnShowCoordinate
            // 
            this.btnShowCoordinate.Location = new System.Drawing.Point(641, 10);
            this.btnShowCoordinate.Name = "btnShowCoordinate";
            this.btnShowCoordinate.Size = new System.Drawing.Size(171, 23);
            this.btnShowCoordinate.TabIndex = 3;
            this.btnShowCoordinate.Text = "Rafraichir coordonnées";
            this.btnShowCoordinate.UseVisualStyleBackColor = true;
            this.btnShowCoordinate.Click += new System.EventHandler(this.btnShowCoordinate_Click);
            // 
            // FormSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(826, 656);
            this.Controls.Add(this.btnShowCoordinate);
            this.Controls.Add(this.pnlCoordinate);
            this.Controls.Add(this.lblSite);
            this.Name = "FormSite";
            this.Text = "Site";
            this.Load += new System.EventHandler(this.FormDisplayMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.Panel pnlCoordinate;
        private System.Windows.Forms.Button btnShowCoordinate;
    }
}