namespace Store_Management_System.User_Control.Fournisseur.ListALL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.IDFOUR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENTREPRISE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEPHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADRESSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDFOUR,
            this.ENTREPRISE,
            this.TELEPHONE,
            this.CATEGORIE,
            this.ADRESSE});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.EnableHeadersVisualStyles = false;
            this.DataGridView.GridColor = System.Drawing.Color.DarkGray;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.RowHeadersWidth = 40;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView.RowTemplate.Height = 50;
            this.DataGridView.Size = new System.Drawing.Size(1008, 504);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            this.DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            this.DataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellMouseEnter);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.DataGridView);
            this.panel1.Location = new System.Drawing.Point(61, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 504);
            this.panel1.TabIndex = 1;
            // 
            // ListFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panel1);
            this.Name = "ListFour";
            this.Size = new System.Drawing.Size(1143, 614);
            this.Load += new System.EventHandler(this.ListFour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFOUR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTREPRISE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEPHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADRESSE;
        private System.Windows.Forms.Panel panel1;
    }
}
