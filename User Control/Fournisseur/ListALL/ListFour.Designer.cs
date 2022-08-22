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
            this.components = new System.ComponentModel.Container();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.dataBaseMagasinDataSet = new Store_Management_System.DataBaseMagasinDataSet();
            this.dataBaseMagasinDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseMagasinDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseMagasinDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DataGridView.Location = new System.Drawing.Point(34, 23);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(890, 446);
            this.DataGridView.TabIndex = 0;
            // 
            // dataBaseMagasinDataSet
            // 
            this.dataBaseMagasinDataSet.DataSetName = "DataBaseMagasinDataSet";
            this.dataBaseMagasinDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataBaseMagasinDataSetBindingSource
            // 
            this.dataBaseMagasinDataSetBindingSource.DataSource = this.dataBaseMagasinDataSet;
            this.dataBaseMagasinDataSetBindingSource.Position = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IDFOUR";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ENTREPRISE";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TELEPHONE";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "CATEGORIE";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ADRESSE";
            this.Column5.Name = "Column5";
            // 
            // ListFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridView);
            this.Name = "ListFour";
            this.Size = new System.Drawing.Size(945, 508);
            this.Load += new System.EventHandler(this.ListFour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseMagasinDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseMagasinDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.BindingSource dataBaseMagasinDataSetBindingSource;
        private DataBaseMagasinDataSet dataBaseMagasinDataSet;
    }
}
