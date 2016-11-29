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
            this.panelConteneurPanelJeu = new System.Windows.Forms.Panel();
            this.panelJeu = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelConteneurProchain = new System.Windows.Forms.Panel();
            this.labelProchain = new System.Windows.Forms.Label();
            this.panelProchainBloc = new System.Windows.Forms.Panel();
            this.panelStatistique = new System.Windows.Forms.Panel();
            this.pictureBoxEntete = new System.Windows.Forms.PictureBox();
            this.labelTitre = new System.Windows.Forms.Label();
            this.panelConteneurBlocReserve = new System.Windows.Forms.Panel();
            this.labelBlocReserve = new System.Windows.Forms.Label();
            this.panelBlocReserve = new System.Windows.Forms.Panel();
            this.boutonPersonnaliseQuitter = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.boutonPersonnaliseOption = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.boutonPersonnaliseNouvellePartie = new ProjetTetrisSession1Tp3.BoutonPersonnalise();
            this.panelConteneurPanelJeu.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelConteneurProchain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntete)).BeginInit();
            this.panelConteneurBlocReserve.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDescenteBloc
            // 
            this.timerDescenteBloc.Enabled = true;
            this.timerDescenteBloc.Tick += new System.EventHandler(this.timerDescenteBloc_Tick);
            // 
            // panelConteneurPanelJeu
            // 
            this.panelConteneurPanelJeu.BackColor = System.Drawing.Color.Transparent;
            this.panelConteneurPanelJeu.BackgroundImage = global::ProjetTetrisSession1Tp3.Properties.Resources.ImageDeFond;
            this.panelConteneurPanelJeu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelConteneurPanelJeu.Controls.Add(this.panelJeu);
            this.panelConteneurPanelJeu.Location = new System.Drawing.Point(220, 128);
            this.panelConteneurPanelJeu.Name = "panelConteneurPanelJeu";
            this.panelConteneurPanelJeu.Size = new System.Drawing.Size(402, 621);
            this.panelConteneurPanelJeu.TabIndex = 3;
            // 
            // panelJeu
            // 
            this.panelJeu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(159)))));
            this.panelJeu.Location = new System.Drawing.Point(33, 2);
            this.panelJeu.Name = "panelJeu";
            this.panelJeu.Size = new System.Drawing.Size(336, 616);
            this.panelJeu.TabIndex = 0;
            this.panelJeu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelJeu_Paint);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.BackgroundImage = global::ProjetTetrisSession1Tp3.Properties.Resources.ImageDeFond;
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenu.Controls.Add(this.panelConteneurBlocReserve);
            this.panelMenu.Controls.Add(this.panelConteneurProchain);
            this.panelMenu.Controls.Add(this.panelStatistique);
            this.panelMenu.Controls.Add(this.boutonPersonnaliseQuitter);
            this.panelMenu.Controls.Add(this.boutonPersonnaliseOption);
            this.panelMenu.Controls.Add(this.boutonPersonnaliseNouvellePartie);
            this.panelMenu.Location = new System.Drawing.Point(15, 131);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(199, 616);
            this.panelMenu.TabIndex = 2;
            // 
            // panelConteneurProchain
            // 
            this.panelConteneurProchain.Controls.Add(this.labelProchain);
            this.panelConteneurProchain.Controls.Add(this.panelProchainBloc);
            this.panelConteneurProchain.Location = new System.Drawing.Point(43, 132);
            this.panelConteneurProchain.Name = "panelConteneurProchain";
            this.panelConteneurProchain.Size = new System.Drawing.Size(112, 86);
            this.panelConteneurProchain.TabIndex = 6;
            // 
            // labelProchain
            // 
            this.labelProchain.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProchain.Location = new System.Drawing.Point(0, 0);
            this.labelProchain.Name = "labelProchain";
            this.labelProchain.Size = new System.Drawing.Size(112, 30);
            this.labelProchain.TabIndex = 3;
            this.labelProchain.Text = "Prochain";
            this.labelProchain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelProchainBloc
            // 
            this.panelProchainBloc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(159)))));
            this.panelProchainBloc.Location = new System.Drawing.Point(0, 30);
            this.panelProchainBloc.Name = "panelProchainBloc";
            this.panelProchainBloc.Size = new System.Drawing.Size(112, 56);
            this.panelProchainBloc.TabIndex = 2;
            this.panelProchainBloc.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProchainBloc_Paint);
            // 
            // panelStatistique
            // 
            this.panelStatistique.BackColor = System.Drawing.Color.Black;
            this.panelStatistique.Location = new System.Drawing.Point(25, 404);
            this.panelStatistique.Name = "panelStatistique";
            this.panelStatistique.Size = new System.Drawing.Size(146, 145);
            this.panelStatistique.TabIndex = 4;
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
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(159)))));
            this.labelTitre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitre.Font = new System.Drawing.Font("Perpetua Titling MT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.Location = new System.Drawing.Point(30, 32);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(720, 72);
            this.labelTitre.TabIndex = 4;
            this.labelTitre.Text = "TETRIS SIM AND YAN";
            this.labelTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelConteneurBlocReserve
            // 
            this.panelConteneurBlocReserve.Controls.Add(this.labelBlocReserve);
            this.panelConteneurBlocReserve.Controls.Add(this.panelBlocReserve);
            this.panelConteneurBlocReserve.Location = new System.Drawing.Point(43, 229);
            this.panelConteneurBlocReserve.Name = "panelConteneurBlocReserve";
            this.panelConteneurBlocReserve.Size = new System.Drawing.Size(112, 86);
            this.panelConteneurBlocReserve.TabIndex = 7;
            // 
            // labelBlocReserve
            // 
            this.labelBlocReserve.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlocReserve.Location = new System.Drawing.Point(0, 0);
            this.labelBlocReserve.Name = "labelBlocReserve";
            this.labelBlocReserve.Size = new System.Drawing.Size(112, 30);
            this.labelBlocReserve.TabIndex = 3;
            this.labelBlocReserve.Text = "Reserve";
            this.labelBlocReserve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBlocReserve
            // 
            this.panelBlocReserve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(51)))), ((int)(((byte)(159)))));
            this.panelBlocReserve.Location = new System.Drawing.Point(0, 30);
            this.panelBlocReserve.Name = "panelBlocReserve";
            this.panelBlocReserve.Size = new System.Drawing.Size(112, 56);
            this.panelBlocReserve.TabIndex = 2;
            // 
            // boutonPersonnaliseQuitter
            // 
            this.boutonPersonnaliseQuitter.BackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseQuitter.DisplayText = "Quitter";
            this.boutonPersonnaliseQuitter.FlatAppearance.BorderSize = 0;
            this.boutonPersonnaliseQuitter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonPersonnaliseQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonPersonnaliseQuitter.Location = new System.Drawing.Point(21, 555);
            this.boutonPersonnaliseQuitter.Name = "boutonPersonnaliseQuitter";
            this.boutonPersonnaliseQuitter.Size = new System.Drawing.Size(150, 40);
            this.boutonPersonnaliseQuitter.TabIndex = 3;
            this.boutonPersonnaliseQuitter.UseVisualStyleBackColor = false;
            this.boutonPersonnaliseQuitter.Click += new System.EventHandler(this.boutonPersonnaliseQuitter_Click);
            // 
            // boutonPersonnaliseOption
            // 
            this.boutonPersonnaliseOption.BackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseOption.DisplayText = "Option";
            this.boutonPersonnaliseOption.FlatAppearance.BorderSize = 0;
            this.boutonPersonnaliseOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonPersonnaliseOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonPersonnaliseOption.Location = new System.Drawing.Point(21, 86);
            this.boutonPersonnaliseOption.Name = "boutonPersonnaliseOption";
            this.boutonPersonnaliseOption.Size = new System.Drawing.Size(150, 40);
            this.boutonPersonnaliseOption.TabIndex = 1;
            this.boutonPersonnaliseOption.TabStop = false;
            this.boutonPersonnaliseOption.UseVisualStyleBackColor = false;
            this.boutonPersonnaliseOption.Click += new System.EventHandler(this.boutonPersonnaliseOption_Click);
            // 
            // boutonPersonnaliseNouvellePartie
            // 
            this.boutonPersonnaliseNouvellePartie.BackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseNouvellePartie.DisplayText = "Nouvelle Partie";
            this.boutonPersonnaliseNouvellePartie.FlatAppearance.BorderSize = 0;
            this.boutonPersonnaliseNouvellePartie.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseNouvellePartie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.boutonPersonnaliseNouvellePartie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boutonPersonnaliseNouvellePartie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boutonPersonnaliseNouvellePartie.Location = new System.Drawing.Point(21, 40);
            this.boutonPersonnaliseNouvellePartie.Name = "boutonPersonnaliseNouvellePartie";
            this.boutonPersonnaliseNouvellePartie.Size = new System.Drawing.Size(150, 40);
            this.boutonPersonnaliseNouvellePartie.TabIndex = 0;
            this.boutonPersonnaliseNouvellePartie.TabStop = false;
            this.boutonPersonnaliseNouvellePartie.UseVisualStyleBackColor = false;
            this.boutonPersonnaliseNouvellePartie.Click += new System.EventHandler(this.boutonPersonnaliseNouvellePartie_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(634, 761);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.panelConteneurPanelJeu);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.pictureBoxEntete);
            this.DoubleBuffered = true;
            this.Name = "FormPrincipal";
            this.Text = "Tetris ";
            this.panelConteneurPanelJeu.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelConteneurProchain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEntete)).EndInit();
            this.panelConteneurBlocReserve.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelJeu;
        private System.Windows.Forms.PictureBox pictureBoxEntete;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelProchainBloc;
        private System.Windows.Forms.Timer timerDescenteBloc;
        private BoutonPersonnalise boutonPersonnaliseOption;
        private BoutonPersonnalise boutonPersonnaliseNouvellePartie;
        private System.Windows.Forms.Panel panelConteneurPanelJeu;
        private System.Windows.Forms.Label labelTitre;
        private BoutonPersonnalise boutonPersonnaliseQuitter;
        private System.Windows.Forms.Panel panelStatistique;
        private System.Windows.Forms.Panel panelConteneurProchain;
        private System.Windows.Forms.Label labelProchain;
        private System.Windows.Forms.Panel panelConteneurBlocReserve;
        private System.Windows.Forms.Label labelBlocReserve;
        private System.Windows.Forms.Panel panelBlocReserve;
    }
}

