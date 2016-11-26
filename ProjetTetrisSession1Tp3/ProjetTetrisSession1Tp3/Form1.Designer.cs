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
            this.panelJeu = new System.Windows.Forms.Panel();
            this.pictureBoxEntete = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelProchainBloc = new System.Windows.Forms.Panel();
            this.boutonPersonnaliseOption = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.boutonPersonnaliseNouvellePartie = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.timerDescenteBloc = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntete)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelJeu
            // 
            this.panelJeu.BackColor = System.Drawing.SystemColors.Control;
            this.panelJeu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelJeu.Location = new System.Drawing.Point(257, 131);
            this.panelJeu.Name = "panelJeu";
            this.panelJeu.Size = new System.Drawing.Size(336, 616);
            this.panelJeu.TabIndex = 0;
            // 
            // pictureBoxEntete
            // 
            this.pictureBoxEntete.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBoxEntete.Location = new System.Drawing.Point(15, 3);
            this.pictureBoxEntete.Name = "pictureBoxEntete";
            this.pictureBoxEntete.Size = new System.Drawing.Size(607, 119);
            this.pictureBoxEntete.TabIndex = 1;
            this.pictureBoxEntete.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panelProchainBloc.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panelProchainBloc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProchainBloc.Location = new System.Drawing.Point(40, 132);
            this.panelProchainBloc.Name = "panelProchainBloc";
            this.panelProchainBloc.Size = new System.Drawing.Size(112, 112);
            this.panelProchainBloc.TabIndex = 2;
            // 
            // boutonPersonnaliseOption
            // 
            this.boutonPersonnaliseOption.BackColor = System.Drawing.Color.ForestGreen;
            this.boutonPersonnaliseOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonPersonnaliseOption.Location = new System.Drawing.Point(21, 86);
            this.boutonPersonnaliseOption.Name = "boutonPersonnaliseOption";
            this.boutonPersonnaliseOption.Size = new System.Drawing.Size(150, 40);
            this.boutonPersonnaliseOption.TabIndex = 1;
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
            this.boutonPersonnaliseNouvellePartie.Text = "Nouvelle Partie";
            this.boutonPersonnaliseNouvellePartie.UseVisualStyleBackColor = false;
            // 
            // timerDescenteBloc
            // 
            this.timerDescenteBloc.Enabled = true;
            this.timerDescenteBloc.Tick += new System.EventHandler(this.timerDescenteBloc_Tick);
            // 
            // FormPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBoxEntete);
            this.Controls.Add(this.panelJeu);
            this.DoubleBuffered = true;
            this.Name = "FormPrincipal";
            this.Text = "Tetris ";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntete)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelJeu;
        private System.Windows.Forms.PictureBox pictureBoxEntete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelProchainBloc;
        private System.Windows.Forms.Timer timerDescenteBloc;
        private BoutonPersonnalise boutonPersonnaliseOption;
        private BoutonPersonnalise boutonPersonnaliseNouvellePartie;
    }
}

