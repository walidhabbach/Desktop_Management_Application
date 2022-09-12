namespace Store_Management_System.User_Control
{
    partial class MenuFournisseur
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
            this.OperationPanel = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.Button();
            this.PanelFourListe = new System.Windows.Forms.Panel();
            this.MainPanel_Four = new System.Windows.Forms.Panel();
            this.OperationPanel.SuspendLayout();
            this.MainPanel_Four.SuspendLayout();
            this.SuspendLayout();
            // 
            // OperationPanel
            // 
            this.OperationPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.OperationPanel.Controls.Add(this.comboBox2);
            this.OperationPanel.Controls.Add(this.button3);
            this.OperationPanel.Controls.Add(this.button2);
            this.OperationPanel.Controls.Add(this.Add);
            this.OperationPanel.Controls.Add(this.Display);
            this.OperationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OperationPanel.Location = new System.Drawing.Point(0, 0);
            this.OperationPanel.Name = "OperationPanel";
            this.OperationPanel.Size = new System.Drawing.Size(1129, 140);
            this.OperationPanel.TabIndex = 5;
            this.OperationPanel.TabStop = false;
            this.OperationPanel.Text = "Operations";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Tous"});
            this.comboBox2.Location = new System.Drawing.Point(733, 54);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 28);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(537, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "Lister Commande Four";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(348, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Lister Cheque Fournisseur";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(201, 54);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(120, 28);
            this.Add.TabIndex = 2;
            this.Add.Text = "Ajouter Four";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(51, 54);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(124, 28);
            this.Display.TabIndex = 0;
            this.Display.Text = "Afficher";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // PanelFourListe
            // 
            this.PanelFourListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFourListe.Location = new System.Drawing.Point(0, 140);
            this.PanelFourListe.Name = "PanelFourListe";
            this.PanelFourListe.Size = new System.Drawing.Size(1129, 580);
            this.PanelFourListe.TabIndex = 6;
            this.PanelFourListe.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelFourListe_Paint);
            // 
            // MainPanel_Four
            // 
            this.MainPanel_Four.Controls.Add(this.PanelFourListe);
            this.MainPanel_Four.Controls.Add(this.OperationPanel);
            this.MainPanel_Four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel_Four.Location = new System.Drawing.Point(0, 0);
            this.MainPanel_Four.Name = "MainPanel_Four";
            this.MainPanel_Four.Size = new System.Drawing.Size(1129, 720);
            this.MainPanel_Four.TabIndex = 0;
            // 
            // MenuFournisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainPanel_Four);
            this.Name = "MenuFournisseur";
            this.Size = new System.Drawing.Size(1129, 720);
            this.Load += new System.EventHandler(this.MenuFournisseur_Load);
            this.OperationPanel.ResumeLayout(false);
            this.MainPanel_Four.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox OperationPanel;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel PanelFourListe;
        private System.Windows.Forms.Panel MainPanel_Four;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
