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
            this.timerClavardage = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fastColoredTextBoxClavardage = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tableLayoutPanelMediator = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxClavardage = new System.Windows.Forms.TextBox();
            this.btnDernierClavardage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxClavardage)).BeginInit();
            this.tableLayoutPanelMediator.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerClavardage
            // 
            this.timerClavardage.Interval = 1000;
            this.timerClavardage.Tick += new System.EventHandler(this.timerClavardage_Tick);
            // 
            // fastColoredTextBoxClavardage
            // 
            this.fastColoredTextBoxClavardage.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBoxClavardage.AutoScrollMinSize = new System.Drawing.Size(0, 12);
            this.fastColoredTextBoxClavardage.BackBrush = null;
            this.fastColoredTextBoxClavardage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fastColoredTextBoxClavardage.CharHeight = 12;
            this.fastColoredTextBoxClavardage.CharWidth = 6;
            this.tableLayoutPanelMediator.SetColumnSpan(this.fastColoredTextBoxClavardage, 2);
            this.fastColoredTextBoxClavardage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBoxClavardage.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBoxClavardage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBoxClavardage.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.fastColoredTextBoxClavardage.ForeColor = System.Drawing.Color.White;
            this.fastColoredTextBoxClavardage.IsReplaceMode = false;
            this.fastColoredTextBoxClavardage.Location = new System.Drawing.Point(3, 3);
            this.fastColoredTextBoxClavardage.Name = "fastColoredTextBoxClavardage";
            this.fastColoredTextBoxClavardage.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBoxClavardage.ReadOnly = true;
            this.fastColoredTextBoxClavardage.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBoxClavardage.ShowLineNumbers = false;
            this.fastColoredTextBoxClavardage.Size = new System.Drawing.Size(835, 183);
            this.fastColoredTextBoxClavardage.TabIndex = 0;
            this.fastColoredTextBoxClavardage.WordWrap = true;
            this.fastColoredTextBoxClavardage.Zoom = 100;
            this.fastColoredTextBoxClavardage.ToolTipNeeded += new System.EventHandler<FastColoredTextBoxNS.ToolTipNeededEventArgs>(this.fastColoredTextBoxClavardage_ToolTipNeeded);
            this.fastColoredTextBoxClavardage.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBoxClavardage_TextChangedDelayed);
            this.fastColoredTextBoxClavardage.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fastColoredTextBoxClavardage_Scroll);
            this.fastColoredTextBoxClavardage.Click += new System.EventHandler(this.fastColoredTextBoxClavardage_Click);
            this.fastColoredTextBoxClavardage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fastColoredTextBoxClavardage_KeyDown);
            this.fastColoredTextBoxClavardage.Leave += new System.EventHandler(this.fastColoredTextBoxClavardage_Leave);
            this.fastColoredTextBoxClavardage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fastColoredTextBoxClavardage_MouseDown);
            this.fastColoredTextBoxClavardage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fastColoredTextBoxClavardage_MouseMove);
            // 
            // tableLayoutPanelMediator
            // 
            this.tableLayoutPanelMediator.ColumnCount = 2;
            this.tableLayoutPanelMediator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMediator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelMediator.Controls.Add(this.fastColoredTextBoxClavardage, 0, 0);
            this.tableLayoutPanelMediator.Controls.Add(this.textBoxClavardage, 0, 1);
            this.tableLayoutPanelMediator.Controls.Add(this.btnDernierClavardage, 1, 1);
            this.tableLayoutPanelMediator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMediator.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMediator.Name = "tableLayoutPanelMediator";
            this.tableLayoutPanelMediator.RowCount = 2;
            this.tableLayoutPanelMediator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMediator.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMediator.Size = new System.Drawing.Size(841, 219);
            this.tableLayoutPanelMediator.TabIndex = 6;
            // 
            // textBoxClavardage
            // 
            this.textBoxClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClavardage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxClavardage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClavardage.ForeColor = System.Drawing.Color.White;
            this.textBoxClavardage.Location = new System.Drawing.Point(5, 194);
            this.textBoxClavardage.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxClavardage.Name = "textBoxClavardage";
            this.textBoxClavardage.Size = new System.Drawing.Size(791, 20);
            this.textBoxClavardage.TabIndex = 1;
            this.textBoxClavardage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClavardage_KeyDown);
            this.textBoxClavardage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyUp);
            // 
            // btnDernierClavardage
            // 
            this.btnDernierClavardage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDernierClavardage.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDernierClavardage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDernierClavardage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDernierClavardage.ForeColor = System.Drawing.Color.White;
            this.btnDernierClavardage.Location = new System.Drawing.Point(804, 194);
            this.btnDernierClavardage.Name = "btnDernierClavardage";
            this.btnDernierClavardage.Size = new System.Drawing.Size(34, 22);
            this.btnDernierClavardage.TabIndex = 4;
            this.btnDernierClavardage.Text = "50";
            this.btnDernierClavardage.UseVisualStyleBackColor = true;
            this.btnDernierClavardage.Click += new System.EventHandler(this.btnDernierClavardage_Click);
            this.btnDernierClavardage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDernierClavardage_KeyDown);
            // 
            // FormClavardage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(841, 219);
            this.Controls.Add(this.tableLayoutPanelMediator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClavardage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mediator";
            this.Activated += new System.EventHandler(this.FormClavardage_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClavardage_FormClosed);
            this.Load += new System.EventHandler(this.FormClavardage_Load);
            this.SizeChanged += new System.EventHandler(this.FormClavardage_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormClavardage_KeyDown);
            this.Resize += new System.EventHandler(this.FormClavardage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxClavardage)).EndInit();
            this.tableLayoutPanelMediator.ResumeLayout(false);
            this.tableLayoutPanelMediator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerClavardage;
        private System.Windows.Forms.ToolTip toolTip1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxClavardage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMediator;
        private System.Windows.Forms.TextBox textBoxClavardage;
        private System.Windows.Forms.Button btnDernierClavardage;
    }
}

