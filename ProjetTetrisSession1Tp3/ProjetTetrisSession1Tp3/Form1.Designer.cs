namespace ProjetTetrisSession1Tp3
{
    partial class FormPrincipal
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
            this.timerDescenteBloc = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelJeu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelProchainBloc = new System.Windows.Forms.Panel();
            this.pictureBoxEntete = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boutonPersonnaliseOption = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.boutonPersonnaliseNouvellePartie = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntete)).BeginInit();
            this.SuspendLayout();
            // 
            // timerDescenteBloc
            // 
            this.timerDescenteBloc.Enabled = true;
            this.timerDescenteBloc.Tick += new System.EventHandler(this.timerDescenteBloc_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::ProjetTetrisSession1Tp3.Properties.Resources.ImageDeFond;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panelJeu);
            this.panel1.Location = new System.Drawing.Point(220, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 621);
            this.panel1.TabIndex = 3;
            // 
            // panelJeu
            // 
            this.panelJeu.BackColor = System.Drawing.SystemColors.Control;
            this.panelJeu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelJeu.Location = new System.Drawing.Point(33, 2);
            this.panelJeu.Name = "panelJeu";
            this.panelJeu.Size = new System.Drawing.Size(336, 616);
            this.panelJeu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::ProjetTetrisSession1Tp3.Properties.Resources.ImageDeFond;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panelProchainBloc);
            this.panel2.Controls.Add(this.boutonPersonnaliseOption);
            this.panel2.Controls.Add(this.boutonPersonnaliseNouvellePartie);
            this.panel2.Location = new System.Drawing.Point(15, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 616);
            this.panel2.TabIndex = 2;
            // 
            // panelProchainBloc
            // 
            this.panelProchainBloc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(159)))));
            this.panelProchainBloc.Location = new System.Drawing.Point(40, 132);
            this.panelProchainBloc.Name = "panelProchainBloc";
            this.panelProchainBloc.Size = new System.Drawing.Size(112, 56);
            this.panelProchainBloc.TabIndex = 2;
            // 
            // pictureBoxEntete
            // 
            this.pictureBoxEntete.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEntete.BackgroundImage = global::ProjetTetrisSession1Tp3.Properties.Resources.ImageDeFondEnTete;
            this.pictureBoxEntete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEntete.Location = new System.Drawing.Point(15, 3);
            this.pictureBoxEntete.Name = "pictureBoxEntete";
            this.pictureBoxEntete.Size = new System.Drawing.Size(607, 119);
            this.pictureBoxEntete.TabIndex = 1;
            this.pictureBoxEntete.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(159)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 58);
            this.label1.TabIndex = 4;
            this.label1.Text = "TETRIS SIM AND YAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boutonPersonnaliseOption
            // 
            this.boutonPersonnaliseOption.BackColor = System.Drawing.Color.ForestGreen;
            this.boutonPersonnaliseOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonPersonnaliseOption.Location = new System.Drawing.Point(21, 86);
            this.boutonPersonnaliseOption.Name = "boutonPersonnaliseOption";
            this.boutonPersonnaliseOption.Size = new System.Drawing.Size(150, 40);
            this.boutonPersonnaliseOption.TabIndex = 1;
            this.boutonPersonnaliseOption.TabStop = false;
            this.boutonPersonnaliseOption.Text = "Option";
            this.boutonPersonnaliseOption.UseVisualStyleBackColor = false;
            this.boutonPersonnaliseOption.Click += new System.EventHandler(this.boutonPersonnaliseOption_Click);
            // 
            // boutonPersonnaliseNouvellePartie
            // 
            this.boutonPersonnaliseNouvellePartie.BackColor = System.Drawing.Color.ForestGreen;
            this.boutonPersonnaliseNouvellePartie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonPersonnaliseNouvellePartie.Location = new System.Drawing.Point(21, 40);
            this.boutonPersonnaliseNouvellePartie.Name = "boutonPersonnaliseNouvellePartie";
            this.boutonPersonnaliseNouvellePartie.Size = new System.Drawing.Size(150, 40);
            this.boutonPersonnaliseNouvellePartie.TabIndex = 0;
            this.boutonPersonnaliseNouvellePartie.TabStop = false;
            this.boutonPersonnaliseNouvellePartie.Text = "Nouvelle Partie";
            this.boutonPersonnaliseNouvellePartie.UseVisualStyleBackColor = false;
            this.boutonPersonnaliseNouvellePartie.Click += new System.EventHandler(this.boutonPersonnaliseNouvellePartie_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(634, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBoxEntete);
            this.DoubleBuffered = true;
            this.Name = "FormPrincipal";
            this.Text = "Tetris ";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelJeu;
        private System.Windows.Forms.PictureBox pictureBoxEntete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelProchainBloc;
        private System.Windows.Forms.Timer timerDescenteBloc;
        private BoutonPersonnalise boutonPersonnaliseOption;
        private BoutonPersonnalise boutonPersonnaliseNouvellePartie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

