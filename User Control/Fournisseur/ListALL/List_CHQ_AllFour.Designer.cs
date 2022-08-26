namespace Store_Management_System.User_Control.Fournisseur.List
{
    partial class List_CHQ_AllFour
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ID_CHQ_FOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_CMD_FOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDFOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fournisseur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATEDONNEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATEPAYER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTANTTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_CHQ_FOUR,
            this.ID_CMD_FOUR,
            this.IDFOUR,
            this.Fournisseur,
            this.DATEDONNEE,
            this.DATEPAYER,
            this.MONTANT,
            this.MONTANTTOTAL});
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(1129, 611);
            this.DataGridView.TabIndex = 2;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            // 
            // ID_CHQ_FOUR
            // 
            this.ID_CHQ_FOUR.FillWeight = 20.30457F;
            this.ID_CHQ_FOUR.HeaderText = "ID_CHQ_FOUR";
            this.ID_CHQ_FOUR.Name = "ID_CHQ_FOUR";
            // 
            // ID_CMD_FOUR
            // 
            this.ID_CMD_FOUR.FillWeight = 20.30457F;
            this.ID_CMD_FOUR.HeaderText = "ID_CMD_FOUR";
            this.ID_CMD_FOUR.Name = "ID_CMD_FOUR";
            // 
            // IDFOUR
            // 
            this.IDFOUR.FillWeight = 20.30457F;
            this.IDFOUR.HeaderText = "IDFOUR";
            this.IDFOUR.Name = "IDFOUR";
            // 
            // Fournisseur
            // 
            this.Fournisseur.FillWeight = 20.30457F;
            this.Fournisseur.HeaderText = "Fournisseur";
            this.Fournisseur.Name = "Fournisseur";
            // 
            // DATEDONNEE
            // 
            this.DATEDONNEE.FillWeight = 20.30457F;
            this.DATEDONNEE.HeaderText = "DATE DONNÉE";
            this.DATEDONNEE.Name = "DATEDONNEE";
            // 
            // DATEPAYER
            // 
            this.DATEPAYER.FillWeight = 20.30457F;
            this.DATEPAYER.HeaderText = "DATE A PAYER";
            this.DATEPAYER.Name = "DATEPAYER";
            // 
            // MONTANT
            // 
            this.MONTANT.FillWeight = 20.30457F;
            this.MONTANT.HeaderText = "MONTANT CHQ";
            this.MONTANT.Name = "MONTANT";
            // 
            // MONTANTTOTAL
            // 
            this.MONTANTTOTAL.FillWeight = 20.30457F;
            this.MONTANTTOTAL.HeaderText = "MONTANT TOTAL CMD";
            this.MONTANTTOTAL.Name = "MONTANTTOTAL";
            // 
            // List_CHQ_AllFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridView);
            this.Name = "List_CHQ_AllFour";
            this.Size = new System.Drawing.Size(1129, 611);
            this.Load += new System.EventHandler(this.List_CHQ_AllFour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CHQ_FOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CMD_FOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fournisseur;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATEDONNEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATEPAYER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTANT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTANTTOTAL;
    }
}
