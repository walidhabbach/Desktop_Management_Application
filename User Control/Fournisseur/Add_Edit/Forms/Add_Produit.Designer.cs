namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    partial class Add_Produit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Produit));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DPRIXVENTE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DESIGNATION = new System.Windows.Forms.TextBox();
            this.PRIXACHAT = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FOURNISSEURLABEL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IDPRODUIT = new System.Windows.Forms.TextBox();
            this.PRIXVENTE = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 46);
            this.panel2.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "         Ajouter un Nouveau Produit";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(447, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // DPRIXVENTE
            // 
            this.DPRIXVENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPRIXVENTE.Location = new System.Drawing.Point(32, 210);
            this.DPRIXVENTE.Multiline = true;
            this.DPRIXVENTE.Name = "DPRIXVENTE";
            this.DPRIXVENTE.Size = new System.Drawing.Size(181, 24);
            this.DPRIXVENTE.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "DESIGNATION";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "PRIXACHAT";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "PRIXVENTE";
            // 
            // Add
            // 
            this.Add.AutoSize = true;
            this.Add.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add.FlatAppearance.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add.Location = new System.Drawing.Point(147, 259);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(174, 38);
            this.Add.TabIndex = 26;
            this.Add.Text = "Enregistrer";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "DPRIXVENTE";
            // 
            // DESIGNATION
            // 
            this.DESIGNATION.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DESIGNATION.Location = new System.Drawing.Point(269, 73);
            this.DESIGNATION.Multiline = true;
            this.DESIGNATION.Name = "DESIGNATION";
            this.DESIGNATION.Size = new System.Drawing.Size(183, 25);
            this.DESIGNATION.TabIndex = 22;
            // 
            // PRIXACHAT
            // 
            this.PRIXACHAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PRIXACHAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRIXACHAT.Location = new System.Drawing.Point(32, 141);
            this.PRIXACHAT.Multiline = true;
            this.PRIXACHAT.Name = "PRIXACHAT";
            this.PRIXACHAT.Size = new System.Drawing.Size(181, 25);
            this.PRIXACHAT.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.FOURNISSEURLABEL);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.IDPRODUIT);
            this.panel1.Controls.Add(this.PRIXVENTE);
            this.panel1.Controls.Add(this.DPRIXVENTE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DESIGNATION);
            this.panel1.Controls.Add(this.PRIXACHAT);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(7, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 309);
            this.panel1.TabIndex = 33;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(116, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 25);
            this.textBox1.TabIndex = 33;
            // 
            // FOURNISSEURLABEL
            // 
            this.FOURNISSEURLABEL.AutoSize = true;
            this.FOURNISSEURLABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FOURNISSEURLABEL.Location = new System.Drawing.Point(9, 12);
            this.FOURNISSEURLABEL.Name = "FOURNISSEURLABEL";
            this.FOURNISSEURLABEL.Size = new System.Drawing.Size(101, 20);
            this.FOURNISSEURLABEL.TabIndex = 32;
            this.FOURNISSEURLABEL.Text = "Fournisseur :";
            this.FOURNISSEURLABEL.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "ID PRODUIT";
            this.label6.UseWaitCursor = true;
            // 
            // IDPRODUIT
            // 
            this.IDPRODUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDPRODUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDPRODUIT.Location = new System.Drawing.Point(31, 73);
            this.IDPRODUIT.Multiline = true;
            this.IDPRODUIT.Name = "IDPRODUIT";
            this.IDPRODUIT.Size = new System.Drawing.Size(182, 25);
            this.IDPRODUIT.TabIndex = 31;
            // 
            // PRIXVENTE
            // 
            this.PRIXVENTE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRIXVENTE.Location = new System.Drawing.Point(269, 141);
            this.PRIXVENTE.Multiline = true;
            this.PRIXVENTE.Name = "PRIXVENTE";
            this.PRIXVENTE.Size = new System.Drawing.Size(183, 25);
            this.PRIXVENTE.TabIndex = 29;
            // 
            // Add_Produit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(491, 368);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Produit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produit";
            this.Load += new System.EventHandler(this.Add_Produit_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox DPRIXVENTE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DESIGNATION;
        private System.Windows.Forms.TextBox PRIXACHAT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PRIXVENTE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IDPRODUIT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label FOURNISSEURLABEL;
    }
}