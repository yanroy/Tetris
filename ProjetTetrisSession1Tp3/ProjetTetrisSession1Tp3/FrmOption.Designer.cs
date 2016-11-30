namespace ProjetTetrisSession1Tp3
{
    partial class FrmOption
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
            this.tableLayoutPanelTout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelControles = new System.Windows.Forms.TableLayoutPanel();
            this.labelDroite = new System.Windows.Forms.Label();
            this.labelGauche = new System.Windows.Forms.Label();
            this.labelChute = new System.Windows.Forms.Label();
            this.labelReserve = new System.Windows.Forms.Label();
            this.labelRotation = new System.Windows.Forms.Label();
            this.textBoxToucheDroite = new System.Windows.Forms.TextBox();
            this.textBoxToucheGauche = new System.Windows.Forms.TextBox();
            this.textBoxToucheChute = new System.Windows.Forms.TextBox();
            this.textBoxToucheReserve = new System.Windows.Forms.TextBox();
            this.textBoxToucheRotation = new System.Windows.Forms.TextBox();
            this.groupBoxSon = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelMusique = new System.Windows.Forms.TableLayoutPanel();
            this.labelMusique = new System.Windows.Forms.Label();
            this.textBoxMusiqueNomFichier = new System.Windows.Forms.TextBox();
            this.checkBoxMusiqueOn = new System.Windows.Forms.CheckBox();
            this.buttonFichierMusique = new System.Windows.Forms.Button();
            this.groupBoxConfigurationJeu = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelConfigurationJeu = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownNbreLignes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNbreColonnes = new System.Windows.Forms.NumericUpDown();
            this.labelNbreLignes = new System.Windows.Forms.Label();
            this.labelNbreColonnes = new System.Windows.Forms.Label();
            this.groupBoxCouleursFond = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPersonnaliserCouleursFond = new System.Windows.Forms.TableLayoutPanel();
            this.labelCouleurFond1 = new System.Windows.Forms.Label();
            this.labelCouleurFond2 = new System.Windows.Forms.Label();
            this.pictureBoxCouleurFond1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCouleurFond2 = new System.Windows.Forms.PictureBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.openFileDialogMusique = new System.Windows.Forms.OpenFileDialog();
            this.colorDialogCouleurFond = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanelTout.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            this.tableLayoutPanelControles.SuspendLayout();
            this.groupBoxSon.SuspendLayout();
            this.tableLayoutPanelMusique.SuspendLayout();
            this.groupBoxConfigurationJeu.SuspendLayout();
            this.tableLayoutPanelConfigurationJeu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbreLignes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbreColonnes)).BeginInit();
            this.groupBoxCouleursFond.SuspendLayout();
            this.tableLayoutPanelPersonnaliserCouleursFond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleurFond1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleurFond2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTout
            // 
            this.tableLayoutPanelTout.ColumnCount = 2;
            this.tableLayoutPanelTout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTout.Controls.Add(this.groupBoxControls, 1, 0);
            this.tableLayoutPanelTout.Controls.Add(this.groupBoxSon, 0, 1);
            this.tableLayoutPanelTout.Controls.Add(this.groupBoxConfigurationJeu, 0, 0);
            this.tableLayoutPanelTout.Controls.Add(this.groupBoxCouleursFond, 1, 1);
            this.tableLayoutPanelTout.Controls.Add(this.buttonOk, 1, 2);
            this.tableLayoutPanelTout.Controls.Add(this.buttonAnnuler, 0, 2);
            this.tableLayoutPanelTout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTout.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTout.Name = "tableLayoutPanelTout";
            this.tableLayoutPanelTout.RowCount = 3;
            this.tableLayoutPanelTout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.22129F));
            this.tableLayoutPanelTout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.90566F));
            this.tableLayoutPanelTout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.94969F));
            this.tableLayoutPanelTout.Size = new System.Drawing.Size(598, 292);
            this.tableLayoutPanelTout.TabIndex = 0;
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.tableLayoutPanelControles);
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxControls.Location = new System.Drawing.Point(302, 3);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Size = new System.Drawing.Size(293, 149);
            this.groupBoxControls.TabIndex = 1;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "Configuration des touches";
            // 
            // tableLayoutPanelControles
            // 
            this.tableLayoutPanelControles.ColumnCount = 2;
            this.tableLayoutPanelControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelControles.Controls.Add(this.labelDroite, 0, 0);
            this.tableLayoutPanelControles.Controls.Add(this.labelGauche, 0, 1);
            this.tableLayoutPanelControles.Controls.Add(this.labelChute, 0, 2);
            this.tableLayoutPanelControles.Controls.Add(this.labelReserve, 0, 3);
            this.tableLayoutPanelControles.Controls.Add(this.labelRotation, 0, 4);
            this.tableLayoutPanelControles.Controls.Add(this.textBoxToucheDroite, 1, 0);
            this.tableLayoutPanelControles.Controls.Add(this.textBoxToucheGauche, 1, 1);
            this.tableLayoutPanelControles.Controls.Add(this.textBoxToucheChute, 1, 2);
            this.tableLayoutPanelControles.Controls.Add(this.textBoxToucheReserve, 1, 3);
            this.tableLayoutPanelControles.Controls.Add(this.textBoxToucheRotation, 1, 4);
            this.tableLayoutPanelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControles.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelControles.Name = "tableLayoutPanelControles";
            this.tableLayoutPanelControles.RowCount = 5;
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelControles.Size = new System.Drawing.Size(287, 130);
            this.tableLayoutPanelControles.TabIndex = 0;
            // 
            // labelDroite
            // 
            this.labelDroite.AutoSize = true;
            this.labelDroite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDroite.Location = new System.Drawing.Point(3, 0);
            this.labelDroite.Name = "labelDroite";
            this.labelDroite.Size = new System.Drawing.Size(108, 26);
            this.labelDroite.TabIndex = 0;
            this.labelDroite.Text = "Droite : ";
            // 
            // labelGauche
            // 
            this.labelGauche.AutoSize = true;
            this.labelGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGauche.Location = new System.Drawing.Point(3, 26);
            this.labelGauche.Name = "labelGauche";
            this.labelGauche.Size = new System.Drawing.Size(108, 26);
            this.labelGauche.TabIndex = 1;
            this.labelGauche.Text = "Gauche : ";
            // 
            // labelChute
            // 
            this.labelChute.AutoSize = true;
            this.labelChute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelChute.Location = new System.Drawing.Point(3, 52);
            this.labelChute.Name = "labelChute";
            this.labelChute.Size = new System.Drawing.Size(108, 26);
            this.labelChute.TabIndex = 2;
            this.labelChute.Text = "Chute : ";
            // 
            // labelReserve
            // 
            this.labelReserve.AutoSize = true;
            this.labelReserve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReserve.Location = new System.Drawing.Point(3, 78);
            this.labelReserve.Name = "labelReserve";
            this.labelReserve.Size = new System.Drawing.Size(108, 26);
            this.labelReserve.TabIndex = 3;
            this.labelReserve.Text = "Reserve : ";
            // 
            // labelRotation
            // 
            this.labelRotation.AutoSize = true;
            this.labelRotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRotation.Location = new System.Drawing.Point(3, 104);
            this.labelRotation.Name = "labelRotation";
            this.labelRotation.Size = new System.Drawing.Size(108, 26);
            this.labelRotation.TabIndex = 4;
            this.labelRotation.Text = "Rotation : ";
            // 
            // textBoxToucheDroite
            // 
            this.textBoxToucheDroite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxToucheDroite.Location = new System.Drawing.Point(117, 3);
            this.textBoxToucheDroite.Name = "textBoxToucheDroite";
            this.textBoxToucheDroite.ReadOnly = true;
            this.textBoxToucheDroite.Size = new System.Drawing.Size(167, 20);
            this.textBoxToucheDroite.TabIndex = 5;
            // 
            // textBoxToucheGauche
            // 
            this.textBoxToucheGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxToucheGauche.Location = new System.Drawing.Point(117, 29);
            this.textBoxToucheGauche.Name = "textBoxToucheGauche";
            this.textBoxToucheGauche.ReadOnly = true;
            this.textBoxToucheGauche.Size = new System.Drawing.Size(167, 20);
            this.textBoxToucheGauche.TabIndex = 6;
            // 
            // textBoxToucheChute
            // 
            this.textBoxToucheChute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxToucheChute.Location = new System.Drawing.Point(117, 55);
            this.textBoxToucheChute.Name = "textBoxToucheChute";
            this.textBoxToucheChute.ReadOnly = true;
            this.textBoxToucheChute.Size = new System.Drawing.Size(167, 20);
            this.textBoxToucheChute.TabIndex = 7;
            // 
            // textBoxToucheReserve
            // 
            this.textBoxToucheReserve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxToucheReserve.Location = new System.Drawing.Point(117, 81);
            this.textBoxToucheReserve.Name = "textBoxToucheReserve";
            this.textBoxToucheReserve.ReadOnly = true;
            this.textBoxToucheReserve.Size = new System.Drawing.Size(167, 20);
            this.textBoxToucheReserve.TabIndex = 8;
            // 
            // textBoxToucheRotation
            // 
            this.textBoxToucheRotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxToucheRotation.Location = new System.Drawing.Point(117, 107);
            this.textBoxToucheRotation.Name = "textBoxToucheRotation";
            this.textBoxToucheRotation.ReadOnly = true;
            this.textBoxToucheRotation.Size = new System.Drawing.Size(167, 20);
            this.textBoxToucheRotation.TabIndex = 9;
            this.textBoxToucheRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxToucheRotation_KeyDown);
            // 
            // groupBoxSon
            // 
            this.groupBoxSon.Controls.Add(this.tableLayoutPanelMusique);
            this.groupBoxSon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSon.Location = new System.Drawing.Point(3, 158);
            this.groupBoxSon.Name = "groupBoxSon";
            this.groupBoxSon.Size = new System.Drawing.Size(293, 95);
            this.groupBoxSon.TabIndex = 2;
            this.groupBoxSon.TabStop = false;
            this.groupBoxSon.Text = "Configuration musique";
            // 
            // tableLayoutPanelMusique
            // 
            this.tableLayoutPanelMusique.ColumnCount = 3;
            this.tableLayoutPanelMusique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.40351F));
            this.tableLayoutPanelMusique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.5614F));
            this.tableLayoutPanelMusique.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.03509F));
            this.tableLayoutPanelMusique.Controls.Add(this.labelMusique, 0, 0);
            this.tableLayoutPanelMusique.Controls.Add(this.textBoxMusiqueNomFichier, 1, 0);
            this.tableLayoutPanelMusique.Controls.Add(this.checkBoxMusiqueOn, 0, 1);
            this.tableLayoutPanelMusique.Controls.Add(this.buttonFichierMusique, 2, 0);
            this.tableLayoutPanelMusique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMusique.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelMusique.Name = "tableLayoutPanelMusique";
            this.tableLayoutPanelMusique.RowCount = 2;
            this.tableLayoutPanelMusique.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMusique.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMusique.Size = new System.Drawing.Size(287, 76);
            this.tableLayoutPanelMusique.TabIndex = 0;
            // 
            // labelMusique
            // 
            this.labelMusique.AutoSize = true;
            this.labelMusique.Location = new System.Drawing.Point(5, 5);
            this.labelMusique.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.labelMusique.Name = "labelMusique";
            this.labelMusique.Size = new System.Drawing.Size(53, 13);
            this.labelMusique.TabIndex = 0;
            this.labelMusique.Text = "Musique: ";
            // 
            // textBoxMusiqueNomFichier
            // 
            this.textBoxMusiqueNomFichier.Enabled = false;
            this.textBoxMusiqueNomFichier.Location = new System.Drawing.Point(64, 3);
            this.textBoxMusiqueNomFichier.Name = "textBoxMusiqueNomFichier";
            this.textBoxMusiqueNomFichier.Size = new System.Drawing.Size(176, 20);
            this.textBoxMusiqueNomFichier.TabIndex = 1;
            // 
            // checkBoxMusiqueOn
            // 
            this.checkBoxMusiqueOn.AutoSize = true;
            this.checkBoxMusiqueOn.Location = new System.Drawing.Point(3, 41);
            this.checkBoxMusiqueOn.Name = "checkBoxMusiqueOn";
            this.checkBoxMusiqueOn.Size = new System.Drawing.Size(40, 17);
            this.checkBoxMusiqueOn.TabIndex = 2;
            this.checkBoxMusiqueOn.Text = "On";
            this.checkBoxMusiqueOn.UseVisualStyleBackColor = true;
            // 
            // buttonFichierMusique
            // 
            this.buttonFichierMusique.Location = new System.Drawing.Point(249, 3);
            this.buttonFichierMusique.Name = "buttonFichierMusique";
            this.buttonFichierMusique.Size = new System.Drawing.Size(34, 23);
            this.buttonFichierMusique.TabIndex = 3;
            this.buttonFichierMusique.Text = "...";
            this.buttonFichierMusique.UseVisualStyleBackColor = true;
            this.buttonFichierMusique.Click += new System.EventHandler(this.buttonFichierMusique_Click);
            // 
            // groupBoxConfigurationJeu
            // 
            this.groupBoxConfigurationJeu.Controls.Add(this.tableLayoutPanelConfigurationJeu);
            this.groupBoxConfigurationJeu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConfigurationJeu.Location = new System.Drawing.Point(3, 3);
            this.groupBoxConfigurationJeu.Name = "groupBoxConfigurationJeu";
            this.groupBoxConfigurationJeu.Size = new System.Drawing.Size(293, 149);
            this.groupBoxConfigurationJeu.TabIndex = 3;
            this.groupBoxConfigurationJeu.TabStop = false;
            this.groupBoxConfigurationJeu.Text = "Configuration du jeu";
            // 
            // tableLayoutPanelConfigurationJeu
            // 
            this.tableLayoutPanelConfigurationJeu.ColumnCount = 4;
            this.tableLayoutPanelConfigurationJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.45614F));
            this.tableLayoutPanelConfigurationJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.19298F));
            this.tableLayoutPanelConfigurationJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.64808F));
            this.tableLayoutPanelConfigurationJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.11847F));
            this.tableLayoutPanelConfigurationJeu.Controls.Add(this.numericUpDownNbreLignes, 1, 0);
            this.tableLayoutPanelConfigurationJeu.Controls.Add(this.numericUpDownNbreColonnes, 1, 1);
            this.tableLayoutPanelConfigurationJeu.Controls.Add(this.labelNbreLignes, 0, 0);
            this.tableLayoutPanelConfigurationJeu.Controls.Add(this.labelNbreColonnes, 0, 1);
            this.tableLayoutPanelConfigurationJeu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelConfigurationJeu.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelConfigurationJeu.Name = "tableLayoutPanelConfigurationJeu";
            this.tableLayoutPanelConfigurationJeu.RowCount = 2;
            this.tableLayoutPanelConfigurationJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfigurationJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfigurationJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelConfigurationJeu.Size = new System.Drawing.Size(287, 130);
            this.tableLayoutPanelConfigurationJeu.TabIndex = 0;
            // 
            // numericUpDownNbreLignes
            // 
            this.numericUpDownNbreLignes.Location = new System.Drawing.Point(124, 3);
            this.numericUpDownNbreLignes.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.numericUpDownNbreLignes.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNbreLignes.Name = "numericUpDownNbreLignes";
            this.numericUpDownNbreLignes.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownNbreLignes.TabIndex = 0;
            this.numericUpDownNbreLignes.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // numericUpDownNbreColonnes
            // 
            this.numericUpDownNbreColonnes.Location = new System.Drawing.Point(124, 68);
            this.numericUpDownNbreColonnes.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownNbreColonnes.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNbreColonnes.Name = "numericUpDownNbreColonnes";
            this.numericUpDownNbreColonnes.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownNbreColonnes.TabIndex = 1;
            this.numericUpDownNbreColonnes.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // labelNbreLignes
            // 
            this.labelNbreLignes.AutoSize = true;
            this.labelNbreLignes.Location = new System.Drawing.Point(3, 5);
            this.labelNbreLignes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelNbreLignes.Name = "labelNbreLignes";
            this.labelNbreLignes.Size = new System.Drawing.Size(95, 13);
            this.labelNbreLignes.TabIndex = 2;
            this.labelNbreLignes.Text = "Nombre de lignes :";
            // 
            // labelNbreColonnes
            // 
            this.labelNbreColonnes.AutoSize = true;
            this.labelNbreColonnes.Location = new System.Drawing.Point(3, 70);
            this.labelNbreColonnes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelNbreColonnes.Name = "labelNbreColonnes";
            this.labelNbreColonnes.Size = new System.Drawing.Size(111, 13);
            this.labelNbreColonnes.TabIndex = 3;
            this.labelNbreColonnes.Text = "Nombre de colonnes :";
            // 
            // groupBoxCouleursFond
            // 
            this.groupBoxCouleursFond.Controls.Add(this.tableLayoutPanelPersonnaliserCouleursFond);
            this.groupBoxCouleursFond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCouleursFond.Location = new System.Drawing.Point(302, 158);
            this.groupBoxCouleursFond.Name = "groupBoxCouleursFond";
            this.groupBoxCouleursFond.Size = new System.Drawing.Size(293, 95);
            this.groupBoxCouleursFond.TabIndex = 4;
            this.groupBoxCouleursFond.TabStop = false;
            this.groupBoxCouleursFond.Text = "Personnalisation des couleurs de fond";
            // 
            // tableLayoutPanelPersonnaliserCouleursFond
            // 
            this.tableLayoutPanelPersonnaliserCouleursFond.ColumnCount = 2;
            this.tableLayoutPanelPersonnaliserCouleursFond.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.23404F));
            this.tableLayoutPanelPersonnaliserCouleursFond.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.76596F));
            this.tableLayoutPanelPersonnaliserCouleursFond.Controls.Add(this.labelCouleurFond1, 0, 0);
            this.tableLayoutPanelPersonnaliserCouleursFond.Controls.Add(this.labelCouleurFond2, 0, 1);
            this.tableLayoutPanelPersonnaliserCouleursFond.Controls.Add(this.pictureBoxCouleurFond1, 1, 0);
            this.tableLayoutPanelPersonnaliserCouleursFond.Controls.Add(this.pictureBoxCouleurFond2, 1, 1);
            this.tableLayoutPanelPersonnaliserCouleursFond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPersonnaliserCouleursFond.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelPersonnaliserCouleursFond.Name = "tableLayoutPanelPersonnaliserCouleursFond";
            this.tableLayoutPanelPersonnaliserCouleursFond.RowCount = 2;
            this.tableLayoutPanelPersonnaliserCouleursFond.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPersonnaliserCouleursFond.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPersonnaliserCouleursFond.Size = new System.Drawing.Size(287, 76);
            this.tableLayoutPanelPersonnaliserCouleursFond.TabIndex = 0;
            // 
            // labelCouleurFond1
            // 
            this.labelCouleurFond1.AutoSize = true;
            this.labelCouleurFond1.Location = new System.Drawing.Point(3, 5);
            this.labelCouleurFond1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelCouleurFond1.Name = "labelCouleurFond1";
            this.labelCouleurFond1.Size = new System.Drawing.Size(97, 13);
            this.labelCouleurFond1.TabIndex = 0;
            this.labelCouleurFond1.Text = "Couleur de fond 1: ";
            // 
            // labelCouleurFond2
            // 
            this.labelCouleurFond2.AutoSize = true;
            this.labelCouleurFond2.Location = new System.Drawing.Point(3, 43);
            this.labelCouleurFond2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelCouleurFond2.Name = "labelCouleurFond2";
            this.labelCouleurFond2.Size = new System.Drawing.Size(97, 13);
            this.labelCouleurFond2.TabIndex = 1;
            this.labelCouleurFond2.Text = "Couleur de fond 2: ";
            // 
            // pictureBoxCouleurFond1
            // 
            this.pictureBoxCouleurFond1.BackColor = System.Drawing.Color.Beige;
            this.pictureBoxCouleurFond1.Location = new System.Drawing.Point(109, 3);
            this.pictureBoxCouleurFond1.Name = "pictureBoxCouleurFond1";
            this.pictureBoxCouleurFond1.Size = new System.Drawing.Size(50, 32);
            this.pictureBoxCouleurFond1.TabIndex = 2;
            this.pictureBoxCouleurFond1.TabStop = false;
            this.pictureBoxCouleurFond1.Click += new System.EventHandler(this.pictureBoxCouleurFond1_Click);
            // 
            // pictureBoxCouleurFond2
            // 
            this.pictureBoxCouleurFond2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxCouleurFond2.Location = new System.Drawing.Point(109, 41);
            this.pictureBoxCouleurFond2.Name = "pictureBoxCouleurFond2";
            this.pictureBoxCouleurFond2.Size = new System.Drawing.Size(50, 32);
            this.pictureBoxCouleurFond2.TabIndex = 3;
            this.pictureBoxCouleurFond2.TabStop = false;
            this.pictureBoxCouleurFond2.Click += new System.EventHandler(this.pictureBoxCouleurFond2_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOk.Location = new System.Drawing.Point(478, 259);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(117, 30);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAnnuler.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAnnuler.Location = new System.Drawing.Point(3, 259);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(117, 30);
            this.buttonAnnuler.TabIndex = 6;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            // 
            // openFileDialogMusique
            // 
            this.openFileDialogMusique.FileName = "openFileDialogMusique";
            // 
            // FrmOption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(598, 292);
            this.Controls.Add(this.tableLayoutPanelTout);
            this.Name = "FrmOption";
            this.Text = "FrmOption";
            this.tableLayoutPanelTout.ResumeLayout(false);
            this.groupBoxControls.ResumeLayout(false);
            this.tableLayoutPanelControles.ResumeLayout(false);
            this.tableLayoutPanelControles.PerformLayout();
            this.groupBoxSon.ResumeLayout(false);
            this.tableLayoutPanelMusique.ResumeLayout(false);
            this.tableLayoutPanelMusique.PerformLayout();
            this.groupBoxConfigurationJeu.ResumeLayout(false);
            this.tableLayoutPanelConfigurationJeu.ResumeLayout(false);
            this.tableLayoutPanelConfigurationJeu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbreLignes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNbreColonnes)).EndInit();
            this.groupBoxCouleursFond.ResumeLayout(false);
            this.tableLayoutPanelPersonnaliserCouleursFond.ResumeLayout(false);
            this.tableLayoutPanelPersonnaliserCouleursFond.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleurFond1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCouleurFond2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTout;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.GroupBox groupBoxSon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMusique;
        private System.Windows.Forms.Label labelMusique;
        private System.Windows.Forms.TextBox textBoxMusiqueNomFichier;
        private System.Windows.Forms.CheckBox checkBoxMusiqueOn;
        private System.Windows.Forms.Button buttonFichierMusique;
        private System.Windows.Forms.GroupBox groupBoxConfigurationJeu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfigurationJeu;
        private System.Windows.Forms.NumericUpDown numericUpDownNbreLignes;
        private System.Windows.Forms.NumericUpDown numericUpDownNbreColonnes;
        private System.Windows.Forms.Label labelNbreLignes;
        private System.Windows.Forms.Label labelNbreColonnes;
        private System.Windows.Forms.GroupBox groupBoxCouleursFond;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPersonnaliserCouleursFond;
        private System.Windows.Forms.Label labelCouleurFond1;
        private System.Windows.Forms.Label labelCouleurFond2;
        private System.Windows.Forms.PictureBox pictureBoxCouleurFond1;
        private System.Windows.Forms.OpenFileDialog openFileDialogMusique;
        private System.Windows.Forms.ColorDialog colorDialogCouleurFond;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.PictureBox pictureBoxCouleurFond2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControles;
        private System.Windows.Forms.Label labelDroite;
        private System.Windows.Forms.Label labelGauche;
        private System.Windows.Forms.Label labelChute;
        private System.Windows.Forms.Label labelReserve;
        private System.Windows.Forms.Label labelRotation;
        private System.Windows.Forms.TextBox textBoxToucheDroite;
        private System.Windows.Forms.TextBox textBoxToucheGauche;
        private System.Windows.Forms.TextBox textBoxToucheChute;
        private System.Windows.Forms.TextBox textBoxToucheReserve;
        private System.Windows.Forms.TextBox textBoxToucheRotation;
    }
}