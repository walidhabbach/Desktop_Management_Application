namespace Store_Management_System.User_Control.Fournisseur.ListFour
{
    partial class ListFour
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
            this.IDFOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENTREPRISE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEPHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADRESSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDFOUR,
            this.ENTREPRISE,
            this.TELEPHONE,
            this.CATEGORIE,
            this.ADRESSE});
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(1129, 611);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            this.DataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentDoubleClick);
            this.DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentDoubleClick);
            // 
            // IDFOUR
            // 
            this.IDFOUR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IDFOUR.FillWeight = 30F;
            this.IDFOUR.HeaderText = "IDFOUR";
            this.IDFOUR.Name = "IDFOUR";
            this.IDFOUR.Width = 110;
            // 
            // ENTREPRISE
            // 
            this.ENTREPRISE.FillWeight = 30.47376F;
            this.ENTREPRISE.HeaderText = "ENTREPRISE";
            this.ENTREPRISE.Name = "ENTREPRISE";
            // 
            // TELEPHONE
            // 
            this.TELEPHONE.FillWeight = 30.47376F;
            this.TELEPHONE.HeaderText = "TELEPHONE";
            this.TELEPHONE.Name = "TELEPHONE";
            // 
            // CATEGORIE
            // 
            this.CATEGORIE.FillWeight = 30.47376F;
            this.CATEGORIE.HeaderText = "CATEGORIE";
            this.CATEGORIE.Name = "CATEGORIE";
            // 
            // ADRESSE
            // 
            this.ADRESSE.FillWeight = 30.47376F;
            this.ADRESSE.HeaderText = "ADRESSE";
            this.ADRESSE.Name = "ADRESSE";
            // 
            // ListFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.DataGridView);
            this.Name = "ListFour";
            this.Size = new System.Drawing.Size(1129, 611);
            this.Load += new System.EventHandler(this.ListFour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTREPRISE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEPHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADRESSE;
    }
}
