namespace Store_Management_System.User_Control.Fournisseur.List
{
    partial class List_Cmd_AllFour
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
            this.ID_CMD_FOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDFOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENTREPRISE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATECMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESPECE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCHEQUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTANT_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTRESTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTAVANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_CMD_FOUR,
            this.IDFOUR,
            this.ENTREPRISE,
            this.DESCRIPTION,
            this.STATUT,
            this.DATECMD,
            this.PESPECE,
            this.PCHEQUE,
            this.MONTANT_TOTAL,
            this.MTRESTE,
            this.MTAVANCE});
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(1129, 611);
            this.DataGridView.TabIndex = 1;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            // 
            // ID_CMD_FOUR
            // 
            this.ID_CMD_FOUR.HeaderText = "ID_CMD_FOUR";
            this.ID_CMD_FOUR.Name = "ID_CMD_FOUR";
            // 
            // IDFOUR
            // 
            this.IDFOUR.HeaderText = "IDFOUR";
            this.IDFOUR.Name = "IDFOUR";
            this.IDFOUR.Visible = false;
            // 
            // ENTREPRISE
            // 
            this.ENTREPRISE.HeaderText = "ENTREPRISE";
            this.ENTREPRISE.Name = "ENTREPRISE";
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.HeaderText = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            // 
            // STATUT
            // 
            this.STATUT.HeaderText = "STATUT";
            this.STATUT.Name = "STATUT";
            // 
            // DATECMD
            // 
            this.DATECMD.HeaderText = "DATECMD";
            this.DATECMD.Name = "DATECMD";
            // 
            // PESPECE
            // 
            this.PESPECE.HeaderText = "PESPECE";
            this.PESPECE.Name = "PESPECE";
            // 
            // PCHEQUE
            // 
            this.PCHEQUE.HeaderText = "PCHEQUE";
            this.PCHEQUE.Name = "PCHEQUE";
            // 
            // MONTANT_TOTAL
            // 
            this.MONTANT_TOTAL.HeaderText = "MONTANT TOTAL";
            this.MONTANT_TOTAL.Name = "MONTANT_TOTAL";
            // 
            // MTRESTE
            // 
            this.MTRESTE.HeaderText = "MTRESTE";
            this.MTRESTE.Name = "MTRESTE";
            // 
            // MTAVANCE
            // 
            this.MTAVANCE.HeaderText = "MTAVANCE";
            this.MTAVANCE.Name = "MTAVANCE";
            // 
            // List_Cmd_AllFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridView);
            this.Name = "List_Cmd_AllFour";
            this.Size = new System.Drawing.Size(1129, 611);
            this.Load += new System.EventHandler(this.List_Cmd_AllFour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_CMD_FOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTREPRISE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATECMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESPECE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCHEQUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTANT_TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTRESTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTAVANCE;
    }
}
