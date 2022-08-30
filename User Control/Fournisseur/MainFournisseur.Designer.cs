namespace Store_Management_System.User_Control.Fournisseur
{
    partial class MainFournisseur
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
            this.MenuPanel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Display_Panel = new System.Windows.Forms.Panel();
            this.MenuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel1
            // 
            this.MenuPanel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.MenuPanel1.Controls.Add(this.label1);
            this.MenuPanel1.Controls.Add(this.button5);
            this.MenuPanel1.Controls.Add(this.button4);
            this.MenuPanel1.Controls.Add(this.button3);
            this.MenuPanel1.Controls.Add(this.button1);
            this.MenuPanel1.Controls.Add(this.button2);
            this.MenuPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel1.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel1.Name = "MenuPanel1";
            this.MenuPanel1.Size = new System.Drawing.Size(1132, 140);
            this.MenuPanel1.TabIndex = 0;
            this.MenuPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(24, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Richbond";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(874, 62);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(742, 62);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Cheque";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(596, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Ajouter Produit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ajouter Commande";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Afficher Liste Commande";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Display_Panel
            // 
            this.Display_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display_Panel.Location = new System.Drawing.Point(0, 140);
            this.Display_Panel.Name = "Display_Panel";
            this.Display_Panel.Size = new System.Drawing.Size(1132, 583);
            this.Display_Panel.TabIndex = 1;
            this.Display_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Display_Panel_Paint);
            // 
            // MainFournisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Display_Panel);
            this.Controls.Add(this.MenuPanel1);
            this.Name = "MainFournisseur";
            this.Size = new System.Drawing.Size(1132, 723);
            this.Load += new System.EventHandler(this.Fournisseur_Load);
            this.MenuPanel1.ResumeLayout(false);
            this.MenuPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel Display_Panel;
    }
}
