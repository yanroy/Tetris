﻿//Rôle: Jeu tetris qui fait des rotations anti horaire et accélérère à chaque 4 lignes complètées.
//Auteur : Simon Robidas et Yannick Roy-Fontaine
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace ProjetTetrisSession1Tp3
{
    public partial class FormPrincipal : Form
    {
        #region Variables partagées
        FrmOption frmOption = new FrmOption();

        //Variables de la musique
        WindowsMediaPlayer musique = new WindowsMediaPlayer();
        string musiqueChemin = "musique/Original Tetris theme (Tetris Soundtrack).mp3";
        bool jouerMusique = true;
        Thread threadMusique;
        public DateTime tempsDebutDeJeu; 
        int compteurDeCarre2 = 0;
        int compteurDeLigne2 = 0;
        int compteurDeT2 = 0;
        int compteurDeL2 = 0;
        int compteurDeJ2 = 0;
        int compteurDeS2 = 0;
        int compteurDeZ2 = 0;
        int meilleurScore = 0;

        //Variables du score
        int score = 0;
        int nbreLignesCompletes = 0;
        int niveau = 0;
        bool nbreDeLignesCompletesDejaAtteind = false;
        Random rnd = new Random();
        //Variables pour dessiner le jeu.
        SolidBrush couleur1JeuArrierePlan = new SolidBrush(Color.FromArgb(158, 12, 19));
        SolidBrush couleur2JeuArrierePlan = new SolidBrush(Color.Black);
        const int grosseurDesBlocs = 28;
        Bitmap imageJeu;
        //Pour avoir la bonne image à partir du type, faire - 1. Il n'a pas d'image pour le type none.
        Bitmap[] imageBlocs = new Bitmap[] {Properties.Resources.Gele, Properties.Resources.carre, Properties.Resources.ligne, Properties.Resources.T,
                                            Properties.Resources.L, Properties.Resources.J, Properties.Resources.S, Properties.Resources.Z, };
        //Variables pour le déplacement
        Deplacement deplacement = Deplacement.None;
        Keys keysBougerADroite = Keys.Right;
        Keys keysBougerAGauche = Keys.Left;
        Keys keysTournerSensAntihoraire = Keys.Up;
        Keys keysMettreEnReserve = Keys.C;
        Keys keysChute = Keys.Down;
        bool blocDejaMisEnReserve = false;

        //Variables pour garder les informations des blocs
        TypeBloc[,] tableauDeBlocs;
        int nbreLignes = 22;
        int nbreColonnes = 12;
        int[] blocActifIEnJeu;
        int[] blocActifJEnJeu;
        int[] blocActifIProchain;
        int[] blocActifJProchain;
        int[] blocActifIReserve;
        int[] blocActifJReserve;
        TypeBloc blocActifEnJeu = TypeBloc.None;
        TypeBloc blocActifProchain = TypeBloc.None;
        TypeBloc blocActifReserve = TypeBloc.None;

        //Variables du jeu en pause
        bool jeuSurPause = false;
        const string pauseText = "Pause";

        //Rotation antihorraire
        int status = 0;
        int[] operateurRotationI;
        int[] operateurRotationJ;

        //Vitesse du timer
        const int vitesseAuDebut = 500;
        int vitesse = vitesseAuDebut;

        //Score Temporaire
        public Point[] scoreTemporaireLocation;
        public int[] scoreTemporaire;
        int lignePredefiniePoint = 2;
        #endregion
        /// <summary>
        /// Initialisation des contrôles/Test unitaire.
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            EnleverLignesCompletes_Test();
            Tester_BougerBlocAntiHoraire();
            Tester_InformerFinDePartie();
            threadMusique = new Thread(new ThreadStart(gererMusique));
            threadMusique.Start();
        }       
        //Simon
        /// <summary>
        /// Initialiser le jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            InitialiserJeu();
        }
        //Simon
        /// <summary>
        /// Méthode pour initialiser/reinitialiser le jeu.
        /// </summary>
        void InitialiserJeu()
        {
            tempsDebutDeJeu = DateTime.Now;
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            blocActifIReserve = new int[4];
            blocActifJReserve = new int[4];
            operateurRotationI = new int[4];
            operateurRotationJ = new int[4];
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];
            blocActifReserve = TypeBloc.None;
            score = 0;
            niveau = 0;
            nbreLignesCompletes = 0;
            vitesse = vitesseAuDebut;
            blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
            TransformerProchainBlocEnActifEnJeu();
            blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
            DessinerJeu();
            JouerMusique();
        }
        //Simon
        /// <summary>
        /// Generer un tetriminos dans les tableaux spécifiés.
        /// </summary>
        /// <param name="blocAGenerer">Le type de bloc à générer Carre/J/Ligne/L/S/T/Z</param>
        /// <param name="blocActifIVariable">Les coordonnées en i où le bloc va être généré</param>
        /// <param name="blocActifJVariable">Les coordonnées en j où le bloc va être généré</param>
        /// <returns>Retourne le type du bloc généré</returns>
        TypeBloc GenererBloc(TypeBloc blocAGenerer, int[] blocActifIVariable, int[] blocActifJVariable)
        {
            status = 0;
            TypeBloc blocActifVariable = blocAGenerer;
            switch (blocActifVariable)
            {
                case TypeBloc.Carre:
                    blocActifVariable = TypeBloc.Carre;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 1;
                    blocActifJVariable[1] = 2;
                    blocActifJVariable[2] = 1;
                    blocActifJVariable[3] = 2;
                    break;
                case TypeBloc.J:
                    blocActifVariable = TypeBloc.J;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 1;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 0;
                    blocActifJVariable[1] = 0;
                    blocActifJVariable[2] = 1;
                    blocActifJVariable[3] = 2;
                    break;
                case TypeBloc.L:
                    blocActifVariable = TypeBloc.L;

                    blocActifIVariable[0] = 1;
                    blocActifIVariable[1] = 1;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 0;

                    blocActifJVariable[0] = 0;
                    blocActifJVariable[1] = 1;
                    blocActifJVariable[2] = 2;
                    blocActifJVariable[3] = 2;
                    break;
                case TypeBloc.Ligne:
                    blocActifVariable = TypeBloc.Ligne;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 0;
                    blocActifIVariable[3] = 0;

                    blocActifJVariable[0] = 0;
                    blocActifJVariable[1] = 1;
                    blocActifJVariable[2] = 2;
                    blocActifJVariable[3] = 3;
                    break;
                case TypeBloc.S:
                    blocActifVariable = TypeBloc.S;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 2;
                    blocActifJVariable[1] = 1;
                    blocActifJVariable[2] = 1;
                    blocActifJVariable[3] = 0;
                    break;
                case TypeBloc.T:
                    blocActifVariable = TypeBloc.T;

                    blocActifIVariable[0] = 1;
                    blocActifIVariable[1] = 1;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 0;

                    blocActifJVariable[0] = 0;
                    blocActifJVariable[1] = 1;
                    blocActifJVariable[2] = 2;
                    blocActifJVariable[3] = 1;
                    break;
                case TypeBloc.Z:
                    blocActifVariable = TypeBloc.Z;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 0;
                    blocActifJVariable[1] = 1;
                    blocActifJVariable[2] = 1;
                    blocActifJVariable[3] = 2;
                    break;
            }
            return blocActifVariable;
        }
        //Simon
        /// <summary>
        /// Determine un tetriminos valide soit du Carre au Z.
        /// </summary>
        /// <returns>Retourne le bloc choisi.</returns>
        TypeBloc ChoisirBlocAleatoirement()
        {
            return (TypeBloc)rnd.Next((int)TypeBloc.Carre, (int)TypeBloc.Z + 1);
        }
        //Simon et Yannick
        /// <summary>
        /// Transforme le bloc prochain actif en bloc actif en jeu.
        /// </summary>
        void TransformerProchainBlocEnActifEnJeu()
        {
            blocActifEnJeu = blocActifProchain;
            // Yannick
            // Verification pour statistiques.
            if (blocActifEnJeu == TypeBloc.Ligne)
            {
                compteurDeLigne2++;
            }
            if (blocActifEnJeu == TypeBloc.Carre)
            {
                compteurDeCarre2++;
            }
            if (blocActifEnJeu == TypeBloc.T)
            {
                compteurDeT2++;
            }
            if (blocActifEnJeu == TypeBloc.L)
            {
                compteurDeL2++;
            }
            if (blocActifEnJeu == TypeBloc.J)
            {
                compteurDeJ2++;
            }
            if (blocActifEnJeu == TypeBloc.S)
            {
                compteurDeS2++;
            }
            if (blocActifEnJeu == TypeBloc.Z)
            {
                compteurDeZ2++;
            }

            //Simon
            for (int i =0; i < blocActifIEnJeu.Length;i++)
            {
                blocActifIEnJeu[i] = blocActifIProchain[i];
                blocActifJEnJeu[i] = blocActifJProchain[i] + tableauDeBlocs.GetLength(1) / 2 -2;
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
            }
        }

        //Simon
        /// <summary>
        /// Timer principal du jeu. Gère la descente du bloc actif, la génération de nouveau bloc, l'affichage du jeu/stats et la fin de partie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDescenteBloc_Tick(object sender, EventArgs e)
        {
            score++;
            meilleurScore = meilleurScore < score ? score : meilleurScore;
            if (DeterminerSiLeBlocPeutBouger(Deplacement.Down))
            {
                BougerBlocActif(Deplacement.Down);
            }
            else
            {  
                for(int i = 0;i < blocActifIEnJeu.Length;i++)
                {
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu + 7;
                }
                EnleverLignesCompletes();
                timerDescenteBloc.Interval = vitesse;
                if (VerifierSiTransformerProchainBlocEnActifPossible() == true)
                {
                    TransformerProchainBlocEnActifEnJeu();
                    blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
                }
                else
                {
                    timerDescenteBloc.Stop();                    
                    InformerFinDePartie();
                }
                blocDejaMisEnReserve = false;
            }
            DessinerJeu();
        }
        //Simon 
        /// <summary>
        /// Lecture de touches au clavier pour que le form et non les boutons les lise. (Key down et key up)
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(jeuSurPause)
            {
                timerDescenteBloc.Interval = vitesse;
                return false;
            }
            else if (keyData == keysBougerADroite && DeterminerSiLeBlocPeutBouger(Deplacement.Right))
            {
                BougerBlocActif(Deplacement.Right);
                DessinerJeu();
                timerDescenteBloc.Interval = vitesse;
                return true;
            }
            else if (keyData == keysBougerAGauche && DeterminerSiLeBlocPeutBouger(Deplacement.Left))
            {
                BougerBlocActif(Deplacement.Left);
                DessinerJeu();
                timerDescenteBloc.Interval = vitesse;
                return true;
            }
            else if (keyData == keysTournerSensAntihoraire)
            {
                // Yannick
                deplacement = Deplacement.AntiHoraire;
                timerDescenteBloc.Interval = vitesse;
                return true;
            }
            else if(keyData == keysMettreEnReserve)
            {
                MettreBlocActifEnJeuEnReserve();
                DessinerJeu();
                timerDescenteBloc.Interval = vitesse;
                return true;
            }
            else if(keyData == keysChute)
            {
                timerDescenteBloc.Interval = 1;
            }
            return base.ProcessDialogKey(keyData);
        }

        //Simon
        /// <summary>
        /// Dessine tout ce qu'il y a à dessiner
        /// </summary>
        void DessinerJeu()
        {
            Graphics graphicsPanelJeu = panelJeu.CreateGraphics();
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            //Faire le dessinage du jeu ici-----------
            DessinerFondJeu();
            DessinerLesBlocs();
            DessinerProchainBloc();
            DessinerBlocEnReserve();
            DessinerScoreTemporaire();
            labelMeilleurScoreNombre.Text = meilleurScore.ToString();
            labelNiveauNombre.Text = niveau.ToString();
            labelScoreNombre.Text = score.ToString();
            if (vitesse == 1)
            {
                labelVitessePourcentage.Text = 1.ToString("p");
            }
            else
            {
                labelVitessePourcentage.Text = ((1 - ((double)vitesse / vitesseAuDebut))).ToString("p");
            }
            //-----------------------------------------
            graphicsPanelJeu.DrawImage(imageJeu, 0, 0);
        }
        //Simon
        /// <summary>
        /// Dessine l'arrière de la planche de jeu
        /// </summary>
        void DessinerFondJeu()
        {
            Graphics graphicsImageJeu = Graphics.FromImage(imageJeu);
            SolidBrush solidBrushUtilise = couleur1JeuArrierePlan;
            for (int i = 0; i < tableauDeBlocs.GetLength(0); i++)
            {
                for (int j = 0; j < tableauDeBlocs.GetLength(1); j++)
                {
                    graphicsImageJeu.FillRectangle(new SolidBrush(Color.Black), 0,0,panelJeu.Width,panelJeu.Height);
                }
            }
            for (int i = 0; i < tableauDeBlocs.GetLength(0); i++)
            {
                for (int j = 0; j < tableauDeBlocs.GetLength(1); j++)
                {
                    graphicsImageJeu.FillRectangle(solidBrushUtilise, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                    solidBrushUtilise = solidBrushUtilise == couleur1JeuArrierePlan ? couleur2JeuArrierePlan : couleur1JeuArrierePlan;
                }
            }
        }
        //Simon
        /// <summary>
        /// Dessine les blocs du tableau de blocs actifs
        /// </summary>
        void DessinerLesBlocs()
        {
            Graphics graphicsImageJeu = Graphics.FromImage(imageJeu);
            for (int i = 0; i < nbreLignes; i++)
            {
                for (int j = 0; j < nbreColonnes; j++)
                {
                    switch (tableauDeBlocs[i, j])
                    {
                        case TypeBloc.Carre:
                            graphicsImageJeu.DrawImage(imageBlocs[1], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Gele:
                            graphicsImageJeu.DrawImage(imageBlocs[0], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.J:
                            graphicsImageJeu.DrawImage(imageBlocs[5], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.L:
                            graphicsImageJeu.DrawImage(imageBlocs[4], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Ligne:
                            graphicsImageJeu.DrawImage(imageBlocs[2], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.S:
                            graphicsImageJeu.DrawImage(imageBlocs[6], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.T:
                            graphicsImageJeu.DrawImage(imageBlocs[3], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Z:
                            graphicsImageJeu.DrawImage(imageBlocs[7], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;

                        case TypeBloc.GeleCarre:
                            graphicsImageJeu.DrawImage(imageBlocs[1], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.GeleJ:
                            graphicsImageJeu.DrawImage(imageBlocs[5], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.GeleL:
                            graphicsImageJeu.DrawImage(imageBlocs[4], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.GeleLigne:
                            graphicsImageJeu.DrawImage(imageBlocs[2], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.GeleS:
                            graphicsImageJeu.DrawImage(imageBlocs[6], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.GeleT:
                            graphicsImageJeu.DrawImage(imageBlocs[3], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.GeleZ:
                            graphicsImageJeu.DrawImage(imageBlocs[7], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                    }
                }
            }
        }
        //Simon
        /// <summary>
        /// Dessine le prochain bloc sur son panel
        /// </summary>
        void DessinerProchainBloc()
        {
            Graphics graphicsProchainBloc = panelProchainBloc.CreateGraphics();
            Bitmap prochainBlocImage = new Bitmap(panelProchainBloc.Size.Width,panelProchainBloc.Size.Height);
            Graphics graphicsProchainBlocImage = Graphics.FromImage(prochainBlocImage);
            graphicsProchainBlocImage.FillRectangle(new SolidBrush(panelProchainBloc.BackColor), 0,0,panelProchainBloc.Width,panelProchainBloc.Height);
            for(int i = 0; i < blocActifIProchain.Length; i++)
            {
                    graphicsProchainBlocImage.DrawImage(imageBlocs[(int)blocActifProchain - 1], grosseurDesBlocs * blocActifJProchain[i], grosseurDesBlocs * blocActifIProchain[i], grosseurDesBlocs, grosseurDesBlocs);
            }
            graphicsProchainBloc.DrawImage(prochainBlocImage,0,0);
        }
        //Simon
        /// <summary>
        /// Dessine le bloc en reserve sur son panel
        /// </summary>
        void DessinerBlocEnReserve()
        {
            Graphics graphicsReserveBloc = panelBlocReserve.CreateGraphics();
            Bitmap reserveBlocImage = new Bitmap(panelBlocReserve.Size.Width, panelBlocReserve.Size.Height);
            Graphics graphicsReserveBlocImage = Graphics.FromImage(reserveBlocImage);
            graphicsReserveBlocImage.FillRectangle(new SolidBrush(panelBlocReserve.BackColor), 0, 0, panelBlocReserve.Width, panelBlocReserve.Height);
            //Il n'a pas d'image pour le TypeBloc.None
            if(blocActifReserve != TypeBloc.None)
            {
                for (int i = 0; i < blocActifIReserve.Length; i++)
                {
                    graphicsReserveBlocImage.DrawImage(imageBlocs[(int)blocActifReserve - 1], grosseurDesBlocs * blocActifJReserve[i], grosseurDesBlocs * blocActifIReserve[i], grosseurDesBlocs, grosseurDesBlocs);
                }
            }
            graphicsReserveBloc.DrawImage(reserveBlocImage, 0, 0);
        }
        //Simon
        /// <summary>
        /// Dessine les scores temporaires situés dans le tableau créé à cette usure.
        /// </summary>
        void DessinerScoreTemporaire()
        {
            for(int i =0; i < scoreTemporaire.Length; i++)
            {
                if(scoreTemporaire[i] != 0)
                {
                    Graphics graphicsScoreTemporaire = Graphics.FromImage(imageJeu);
                    graphicsScoreTemporaire.DrawString("+"+scoreTemporaire[i].ToString(), labelProchain.Font, new SolidBrush(Color.FromArgb(237, 28, 36)), scoreTemporaireLocation[i]);
                }
            }
        }
        //Simon
        /// <summary>
        /// Efface les blocs actifs en jeu.
        /// </summary>
        void EffacerBlocActifEnJeu()
        {
            for(int i = 0; i < blocActifIEnJeu.Length;i++)
            {
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
            }
        }        
        //Simon
        /// <summary>
        /// Dessine le jeu lors que le panel est dessiné.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelJeu_Paint(object sender, PaintEventArgs e)
        {
            DessinerJeu();
        }
        //Simon
        /// <summary>
        /// Dessine le prochain bloc lorsque le panel est dessiné. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelProchainBloc_Paint(object sender, PaintEventArgs e)
        {
            DessinerProchainBloc();
        }


        //Simon et Yannick
        /// <summary>
        /// Détermine si le bloc peut faire le mouvement paramètré. Seul les mouvements Down, AntiHoraire, Right et Left sont pris en charge.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Retourne true si le bloc peut bouger.</returns>
        bool DeterminerSiLeBlocPeutBouger(Deplacement direction)
        {
            bool deplacementTester = false;
            if(direction == Deplacement.Down)
            {
                for(int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    if(blocActifIEnJeu[i] + 1 >= tableauDeBlocs.GetLength(0) || (int)tableauDeBlocs[blocActifIEnJeu[i] + 1, blocActifJEnJeu[i]] >=9)
                    {
                        return false;
                    }
                }
                deplacementTester = true;
            }
            else if(direction == Deplacement.Right)
            {
                for(int i = 0; i < blocActifJEnJeu.Length; i++)
                {
                    if (blocActifJEnJeu[i] + 1 >= tableauDeBlocs.GetLength(1) || (int)tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i] + 1] >= 9)
                    {
                        return false;
                    }
                }
                deplacementTester = true;
            }
            else if (direction == Deplacement.Left)
            {
                for (int i = 0; i < blocActifJEnJeu.Length; i++)
                {
                    if (blocActifJEnJeu[i] - 1 < 0 || (int)tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i] - 1] >= 9)
                    {
                        return false;
                    }
                }
                deplacementTester = true;
            }
            //Yannick
            else if (direction == Deplacement.AntiHoraire)
            {
                for (int i = 0; i < operateurRotationI.Length; i++)
                {
                    if (blocActifIEnJeu[i] + operateurRotationI[i] < 0 || 
                        blocActifJEnJeu[i] + operateurRotationJ[i] < 0 || 
                        blocActifIEnJeu[i] + operateurRotationI[i] > tableauDeBlocs.GetLength(0) - 1 || 
                        blocActifJEnJeu[i] + operateurRotationJ[i] > tableauDeBlocs.GetLength(1) - 1 ||
                        (int)tableauDeBlocs[blocActifIEnJeu[i] + operateurRotationI[i], blocActifJEnJeu[i] + operateurRotationJ[i]] >= 9)
                    {
                        return false;
                    }
                }
                deplacementTester = true;
            }
            Debug.Assert(deplacementTester, "Le déplacement n'est pas pris en charge par la méthode");
            return true;
        }
        //Simon
        /// <summary>
        /// Bouge le bloc selon le deplacement entré en paramètre. Seul les mouvements Down, AntiHoraire, Right et Left sont pris en charge.
        /// </summary>
        /// <param name="direction"></param>
        void BougerBlocActif(Deplacement direction)
        {
            if(direction == Deplacement.Down)
            {
                for(int i = 0; i < blocActifIEnJeu.Length;i++)
                {
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                }
                for (int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    blocActifIEnJeu[i]++;
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
                }
            }
            else if(direction == Deplacement.Right)
            {
                for (int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                }
                for (int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    blocActifJEnJeu[i]++;
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
                }
            }
            else if (direction == Deplacement.Left)
            {
                for (int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                }
                for (int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    blocActifJEnJeu[i]--;
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
                }
            }

            else if (direction == Deplacement.AntiHoraire)
            {
                BougerBlocAntiHoraire();
                //FairePivoterLeBlocHorairement();
            }

        }  
        //Simon (pour eviter le easy spin)
        /// <summary>
        /// Timer de la rotation afin d'empêcher une rotation répétée trop rapide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRotation_Tick(object sender, EventArgs e)
        {
            switch(deplacement)
            {

                case Deplacement.AntiHoraire:
                    BougerBlocActif(Deplacement.AntiHoraire);
                    break;
            }
            DessinerJeu();
            deplacement = Deplacement.None;
        }
        //Yannick 

        /// <summary>
        /// Faire pivoter les blocs de manière anti horaire.
        /// </summary>

        void BougerBlocAntiHoraire()
        {
            switch (blocActifEnJeu)
            {
                case TypeBloc.Carre:
                    for (int i =0; i < operateurRotationI.Length; i++)
                    {
                        operateurRotationI[i] = 0;
                        operateurRotationJ[i] = 0;
                    }
                    break;
                case TypeBloc.Ligne:
                    switch (status)
                    {
                        case 0:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = -2;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = -2;
                            break;

                        case 1:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 2;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = -2;
                            break;

                        case 2:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 2;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 2;
                            break;

                        case 3:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = -2;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 2;
                            break;
                    }
                    
                    break;
                case TypeBloc.T:
                    switch (status)
                    {
                        case 0:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = 1;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = -1;
                            break;
                        case 1:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 1;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = 1;
                            break;
                        case 2:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = -1;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 1;
                            break;
                        case 3:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = -1;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = -1;
                            break;
                    }
                    break;
                case TypeBloc.L:
                    switch(status)
                    {
                        case 0:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = 0;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = -2;
                            break;
                        case 1:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 2;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = 0;
                            break;
                        case 2:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 0;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 2;
                            break;
                        case 3:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = -2;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 0;
                            break;
                    }
                    break;
                case TypeBloc.J:
                    switch (status)
                    {
                        case 0:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 2;
                            operateurRotationI[1] = 1;
                            operateurRotationI[2] = 0;
                            operateurRotationI[3] = -1;

                            operateurRotationJ[0] = 0;
                            operateurRotationJ[1] = 1;
                            operateurRotationJ[2] = 0;
                            operateurRotationJ[3] = -1;
                            break;
                        case 1:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 0;
                            operateurRotationI[1] = -1;
                            operateurRotationI[2] = 0;
                            operateurRotationI[3] = 1;

                            operateurRotationJ[0] = 2;
                            operateurRotationJ[1] = 1;
                            operateurRotationJ[2] = 0;
                            operateurRotationJ[3] = -1;
                            break;
                        case 2:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -2;
                            operateurRotationI[1] = -1;
                            operateurRotationI[2] = 0;
                            operateurRotationI[3] = 1;

                            operateurRotationJ[0] = 0;
                            operateurRotationJ[1] = -1;
                            operateurRotationJ[2] = 0;
                            operateurRotationJ[3] = 1;
                            break;
                        case 3:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 0;
                            operateurRotationI[1] = 1;
                            operateurRotationI[2] = 0;
                            operateurRotationI[3] = -1;

                            operateurRotationJ[0] = -2;
                            operateurRotationJ[1] = -1;
                            operateurRotationJ[2] = 0;
                            operateurRotationJ[3] = 1;
                            break;
                    }
                    break;
                case TypeBloc.S:
                    switch (status)
                    {
                        case 0:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = 0;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 2;
                            break;
                        case 1:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = -2;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = 0;
                            break;
                        case 2:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 0;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = -2;
                            break;
                        case 3:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 2;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 0;
                            break;
                    }
                    break;
                case TypeBloc.Z:
                    switch (status)
                    {
                        case 0:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = -2;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 0;
                            break;
                        case 1:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = -1;
                            operateurRotationI[3] = 0;

                            operateurRotationJ[0] = 1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = -2;
                            break;
                        case 2:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = -1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 2;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = -1;
                            operateurRotationJ[3] = 0;
                            break;
                        case 3:
                            for (int i = 0; i < blocActifIEnJeu.Length; i++)
                            {
                                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.None;
                            }
                            operateurRotationI[0] = 1;
                            operateurRotationI[1] = 0;
                            operateurRotationI[2] = 1;
                            operateurRotationI[3] = 0;

                            operateurRotationJ[0] = -1;
                            operateurRotationJ[1] = 0;
                            operateurRotationJ[2] = 1;
                            operateurRotationJ[3] = 2;
                            break;
                    }
                    break;

            }

            if (DeterminerSiLeBlocPeutBouger(Deplacement.AntiHoraire))
            {
                if(status == 3)
                {
                    status = 0;
                }
                else
                {
                    status++;
                }
                for (int i = 0; i < operateurRotationI.Length; i++)
                {
                    blocActifIEnJeu[i] += operateurRotationI[i];
                    blocActifJEnJeu[i] += operateurRotationJ[i];
                }
            }
            
            for (int i = 0; i < blocActifIEnJeu.Length; i++)
            {
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
            }
        }

        //Simon 
        /// <summary>
        /// Faire pivoter le bloc horairement. (Méthode non utilisée ni optimisée)
        /// </summary>
        void FairePivoterLeBlocHorairement()
        {
            if(blocActifEnJeu != TypeBloc.Carre)
            {

                EffacerBlocActifEnJeu();
                int[] nvBlocX = new int[4];
                int[] nvBlocY = new int[4];
                int centreX = 0;
                int centreY = 0;
                int operateurDeSensDeRotationX = 1;
                int operateurDeSensDeRotationY = -1;
                if (blocActifEnJeu == TypeBloc.T)
                {
                    operateurDeSensDeRotationX = -1;
                    operateurDeSensDeRotationY = 1;
                }
                else
                {
                    operateurDeSensDeRotationX = 1;
                    operateurDeSensDeRotationY = -1;
                }
                if (blocActifEnJeu == TypeBloc.J)
                {
                    centreX = blocActifIEnJeu[2];
                    centreY = blocActifJEnJeu[2];
                }
                else
                {
                    centreX = blocActifIEnJeu[1];
                    centreY = blocActifJEnJeu[1];
                }
                for (int i = 0; i < nvBlocX.Length; i++)
                {
                    nvBlocX[i] = (blocActifJEnJeu[i] - centreY) * operateurDeSensDeRotationX + centreX;
                    nvBlocY[i] = (blocActifIEnJeu[i] - centreX) * operateurDeSensDeRotationY + centreY;
                    blocActifIEnJeu[i] = nvBlocX[i];
                    blocActifJEnJeu[i] = nvBlocY[i];
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
                }
            }
        }
        //Simon
        /// <summary>
        /// Mettre le bloc actif en jeu en reserve.
        /// </summary>
        void MettreBlocActifEnJeuEnReserve()
        {
            if (blocDejaMisEnReserve == false && blocActifReserve == TypeBloc.None)
            {
                blocActifReserve = GenererBloc(blocActifEnJeu, blocActifIReserve, blocActifJReserve);
                EffacerBlocActifEnJeu();
                TransformerProchainBlocEnActifEnJeu();
                blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
                blocDejaMisEnReserve = true;
            }
            else if(blocDejaMisEnReserve == false)
            {
                TypeBloc temporaire = blocActifReserve;
                blocActifReserve = GenererBloc(blocActifEnJeu, blocActifIReserve, blocActifJReserve);

                EffacerBlocActifEnJeu();
                blocActifEnJeu = GenererBloc(temporaire, blocActifIEnJeu, blocActifJEnJeu);
                for(int i =0; i < blocActifJEnJeu.Length;i++)
                {
                    blocActifJEnJeu[i] = blocActifJEnJeu[i] + tableauDeBlocs.GetLength(1) / 2 - 2;
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
                }
                blocDejaMisEnReserve = true;
            }
        }

        //Simon
        /// <summary>
        /// Assigne un pointage et une position dans les tableaux pour les scores temporaires.
        /// </summary>
        /// <param name="locationScore"></param>
        /// <param name="score"></param>
        void AttribuerScore(Point locationScore, int score)
        {
            int positionScore = -1;
            for(int i =0; i < scoreTemporaire.Length; i++)
            {
                if(scoreTemporaire[i] == 0)
                {
                    positionScore = i;
                }
            }
            if(positionScore != -1)
            {
                scoreTemporaireLocation[positionScore] = locationScore;
                scoreTemporaire[positionScore] = score;
                this.score += score;
                labelScoreNombre.Text = this.score.ToString();
                ScoreThread scoreThread = new ScoreThread(positionScore, this);
                Thread threadScore = new Thread(new ThreadStart(scoreThread.ScoreTimer));
                threadScore.Start();
            }
        }
        //Simon
        /// <summary>
        /// Choisie une position en J aléatoire dans un intervalle défini et une position en I prédéfinie.
        /// </summary>
        /// <returns>Retourne la position choisie.</returns>
        Point ChoisirPointAleatoireSurLignePredefinie()
        {
            return new Point(rnd.Next(0, tableauDeBlocs.GetLength(1) * grosseurDesBlocs - (3 * grosseurDesBlocs)), lignePredefiniePoint * grosseurDesBlocs );
        }

        //Simon
        /// <summary>
        /// Enleve les lignees complètées.
        /// </summary>
        void EnleverLignesCompletes()
        {
            int scoreTemporaireEnleverLigne = 0;
            int nbreLignesFaitesEnUnCoup = 0;
            for(int i = 0; i < tableauDeBlocs.GetLength(0);i++)
            {
                if (EstUneLigneComplete(i))
                {
                    nbreLignesCompletes++;
                    nbreDeLignesCompletesDejaAtteind = false;
                    nbreLignesFaitesEnUnCoup++;
                    DecalerLignes(i);
                    bool ligneCompleteI = true;
                    for(int j = 0; j < tableauDeBlocs.GetLength(1); j++)
                    {
                        if(tableauDeBlocs[i,j] == TypeBloc.None)
                        {
                            ligneCompleteI = false;
                        }
                    }
                    Debug.Assert(!ligneCompleteI, "La ligne " + i + " ne devrait pas être complète.");
                }
                if (nbreLignesCompletes != 0 && nbreLignesCompletes % 4 == 0 && !nbreDeLignesCompletesDejaAtteind)
                {
                    niveau++;

                    nbreDeLignesCompletesDejaAtteind = true;
                }
            }
            if(nbreLignesFaitesEnUnCoup != 0)
            {
                scoreTemporaireEnleverLigne = (int)((int)Math.Pow(1.8, nbreLignesFaitesEnUnCoup) * (300 * (1 + (double)niveau/10)));
                AttribuerScore(ChoisirPointAleatoireSurLignePredefinie(), scoreTemporaireEnleverLigne);
            }
            vitesse = vitesseAuDebut - (vitesseAuDebut/10)*niveau;
            if (vitesse <= 0)
            {
                vitesse = 1;
            }
        }
        //Simon
        /// <summary>
        /// Determine si la ligne entrée en paramètre est complète.
        /// </summary>
        /// <param name="ligne"></param>
        /// <returns></returns>
        bool EstUneLigneComplete(int ligne)
        {
            int compteurBlocsGeles = 0;
            for(int j = 0; j < tableauDeBlocs.GetLength(1);j++)
            {
                if((int)tableauDeBlocs[ligne,j] >= 9)
                {
                    compteurBlocsGeles++;
                }
            }
            return compteurBlocsGeles == tableauDeBlocs.GetLength(1) ? true : false;
        }
        //Simon
        /// <summary>
        /// Décale les lignes à partir de la ligne de départ paramètrée. (Supprime la ligne de départ)
        /// </summary>
        /// <param name="ligneDeDepart"></param>
        void DecalerLignes(int ligneDeDepart)
        {
            for(int i = ligneDeDepart; i > 1;i--)
            {
                for(int j = 0; j < tableauDeBlocs.GetLength(1); j++)
                {
                    tableauDeBlocs[i, j] = tableauDeBlocs[i - 1, j];
                }
            }
        }
        //Simon
        /// <summary>
        /// Test unitaire de la méthode EnleverLignesCompletes 
        /// </summary>
        void EnleverLignesCompletes_Test()
        {
            // Retrait d’une ligne complète seule dans la surface de jeu.
            tableauDeBlocs = new TypeBloc[22, 12];
            score = 0;
            niveau = 0;
            vitesse = vitesseAuDebut;
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];

            for(int i = 0; i < tableauDeBlocs.GetLength(1);i++)
            {
                tableauDeBlocs[5, i] = TypeBloc.GeleJ;
            }

            EnleverLignesCompletes();

            for(int i =0; i < tableauDeBlocs.GetLength(1); i++)
            {
                Debug.Assert(tableauDeBlocs[5, i] != TypeBloc.GeleJ, "Le bloc 5," + i + " n'est pas supposé être gelé");    
            }
            //Retrait d’une ligne complète avec des blocs à décaler. 
            tableauDeBlocs = new TypeBloc[22, 12];
            score = 0;
            niveau = 0;
            vitesse = vitesseAuDebut;
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];

            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                tableauDeBlocs[5, i] = TypeBloc.GeleJ;
            }
            tableauDeBlocs[4, 1] = TypeBloc.GeleJ;
            tableauDeBlocs[4, 6] = TypeBloc.GeleJ;
            EnleverLignesCompletes();

            Debug.Assert(tableauDeBlocs[5, 1] == TypeBloc.GeleJ, "Le bloc à la position 5,1 est supposé être gelé");
            Debug.Assert(tableauDeBlocs[5, 6] == TypeBloc.GeleJ, "Le bloc à la position 5,6 est supposé être gelé");
            //Retrait de deux lignes complètes consécutives
            tableauDeBlocs = new TypeBloc[22, 12];
            score = 0;
            niveau = 0;
            vitesse = vitesseAuDebut;
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];

            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                tableauDeBlocs[5, i] = TypeBloc.GeleJ;
                tableauDeBlocs[6, i] = TypeBloc.GeleJ;
            }
            EnleverLignesCompletes();
            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                Debug.Assert(tableauDeBlocs[5, i] != TypeBloc.GeleJ, "Le bloc 5," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[6, i] != TypeBloc.GeleJ, "Le bloc 6," + i + " n'est pas supposé être gelé");
            }
            //Retrait de deux lignes complètes non consécutives. 
            tableauDeBlocs = new TypeBloc[22, 12];
            score = 0;
            niveau = 0;
            vitesse = vitesseAuDebut;
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];

            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                tableauDeBlocs[5, i] = TypeBloc.GeleJ;
                tableauDeBlocs[7, i] = TypeBloc.GeleJ;
            }
            EnleverLignesCompletes();
            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                Debug.Assert(tableauDeBlocs[5, i] != TypeBloc.GeleJ, "Le bloc 5," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[7, i] != TypeBloc.GeleJ, "Le bloc 7," + i + " n'est pas supposé être gelé");
            }
            //Retrait de trois lignes complètes.
            tableauDeBlocs = new TypeBloc[22, 12];
            score = 0;
            niveau = 0;
            vitesse = vitesseAuDebut;
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];

            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                tableauDeBlocs[5, i] = TypeBloc.GeleJ;
                tableauDeBlocs[6, i] = TypeBloc.GeleJ;
                tableauDeBlocs[7, i] = TypeBloc.GeleJ;
            }
            EnleverLignesCompletes();
            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                Debug.Assert(tableauDeBlocs[5, i] != TypeBloc.GeleJ, "Le bloc 5," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[6, i] != TypeBloc.GeleJ, "Le bloc 6," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[7, i] != TypeBloc.GeleJ, "Le bloc 7," + i + " n'est pas supposé être gelé");
            }
            //Retrait de quatre lignes complètes. 
            tableauDeBlocs = new TypeBloc[22, 12];
            score = 0;
            niveau = 0;
            vitesse = vitesseAuDebut;
            scoreTemporaire = new int[3];
            scoreTemporaireLocation = new Point[3];

            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                tableauDeBlocs[5, i] = TypeBloc.GeleJ;
                tableauDeBlocs[6, i] = TypeBloc.GeleJ;
                tableauDeBlocs[7, i] = TypeBloc.GeleJ;
                tableauDeBlocs[8, i] = TypeBloc.GeleJ;
            }
            EnleverLignesCompletes();
            for (int i = 0; i < tableauDeBlocs.GetLength(1); i++)
            {
                Debug.Assert(tableauDeBlocs[5, i] != TypeBloc.GeleJ, "Le bloc 5," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[6, i] != TypeBloc.GeleJ, "Le bloc 6," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[7, i] != TypeBloc.GeleJ, "Le bloc 7," + i + " n'est pas supposé être gelé");
                Debug.Assert(tableauDeBlocs[8, i] != TypeBloc.GeleJ, "Le bloc 8," + i + " n'est pas supposé être gelé");
            }
        }

        // Yannick
        /// <summary>
        /// Vérifier si transformer le prochain bloc aftif est possible ou non.
        /// </summary>
        /// <returns> Un booléen qui détermine si c'est possible (true) ou non (false). </returns>
        bool VerifierSiTransformerProchainBlocEnActifPossible()
        {
            bool possible = true;
            for (int i = 0; i < blocActifIProchain.Length; i++)
            {
                if ((int)tableauDeBlocs[blocActifIProchain[i], blocActifJProchain[i] + tableauDeBlocs.GetLength(1) / 2 - 2] >= 9)
                {
                    possible = false;
                }
            }
            return possible;
        }
        
        /// <summary>
        /// Informer le joueur que la partie est terminée, puis ouvrir le formulaire de statistiques.
        /// </summary>
        void InformerFinDePartie()
        {
            FinDePartie frmFinDePartie = new FinDePartie();
            frmFinDePartie.tempsDebutDeJeu = tempsDebutDeJeu;
            frmFinDePartie.compteurDeCarre = compteurDeCarre2;
            frmFinDePartie.compteurDeJ = compteurDeJ2;
            frmFinDePartie.compteurDeL = compteurDeL2;
            frmFinDePartie.compteurDeLigne = compteurDeLigne2;
            frmFinDePartie.compteurDeS = compteurDeS2;
            frmFinDePartie.compteurDeT = compteurDeT2;
            frmFinDePartie.compteurDeZ = compteurDeZ2;
            if (frmFinDePartie.ShowDialog() == DialogResult.OK)
            {
               
                InitialiserJeu();
                timerDescenteBloc.Start();
            }
           
        }

        //Simon
        /// <summary>
        /// Ouvre le formulaire de configuration et gère l'échange d'information entre les deux formulaires.
        /// </summary>
        void ConfigurerJeu()
        {
            frmOption.nbreColonnes = nbreColonnes;
            nbreLignes = frmOption.nbreLignes;
            frmOption.couleur1JeuArrierePlan = couleur1JeuArrierePlan;
            frmOption.couleur2JeuArrierePlan = couleur2JeuArrierePlan;
            frmOption.keysBougerADroite = keysBougerADroite;
            frmOption.keysBougerAGauche = keysBougerAGauche;
            frmOption.keysChute = keysChute;
            frmOption.keysReserve = keysMettreEnReserve;
            frmOption.keysRotation = keysTournerSensAntihoraire;
            frmOption.jouerMusique = jouerMusique;
            frmOption.musiqueChemin = musiqueChemin;
            if (frmOption.ShowDialog() == DialogResult.OK)
            {
                nbreColonnes = frmOption.nbreColonnes;
                nbreLignes = frmOption.nbreLignes;
                couleur1JeuArrierePlan = frmOption.couleur1JeuArrierePlan;
                couleur2JeuArrierePlan = frmOption.couleur2JeuArrierePlan;
                keysBougerADroite = frmOption.keysBougerADroite;
                keysBougerAGauche = frmOption.keysBougerAGauche;
                keysChute = frmOption.keysChute;
                keysMettreEnReserve = frmOption.keysReserve;
                keysTournerSensAntihoraire = frmOption.keysRotation;
                InitialiserJeu();
            }
            musiqueChemin = frmOption.musiqueChemin;
            jouerMusique = frmOption.jouerMusique;

            ReprendreLeJeu();
        }
        //Simon
        /// <summary>
        /// Pause le jeu.
        /// </summary>
        void PauserLeJeu()
        {
            jeuSurPause = true;
            timerDescenteBloc.Enabled = false;
            timerRotation.Enabled = false;
            Brush brush = new SolidBrush(Color.FromArgb(200,Color.Black));
            Graphics graphicsPauseJeu = panelJeu.CreateGraphics();
            graphicsPauseJeu.FillRectangle(brush, ClientRectangle);
            graphicsPauseJeu.DrawString(pauseText, labelTitre.Font,new SolidBrush(Color.White), panelJeu.Width/2 - graphicsPauseJeu.MeasureString(pauseText, labelTitre.Font).Width/2, 100);
            graphicsPauseJeu.Dispose();
        }
        //Simon
        /// <summary>
        /// Reprend le jeu.
        /// </summary>
        void ReprendreLeJeu()
        {
            DessinerJeu();
            jeuSurPause = false;
            timerDescenteBloc.Enabled = true;
            timerRotation.Enabled = true;
        }

        //Simon
        /// <summary>
        /// Fait la configuration du jeu lorsque le bouton option est clické.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonPersonnaliseOption_Click(object sender, EventArgs e)
        {
            PauserLeJeu();
            ConfigurerJeu();
            DessinerJeu();
        }
        //Simon
        /// <summary>
        /// Fait une nouvelle partie lorsque le bouton nouvelle partie est clické.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonPersonnaliseNouvellePartie_Click(object sender, EventArgs e)
        {
            PauserLeJeu();
            if (MessageBox.Show("Toute partie en cours sera perdu, voulez-vous vraiment faire une nouvelle partie?",
                "Nouvelle partie",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                InitialiserJeu();
            }
            ReprendreLeJeu();
            DessinerJeu();
        }
        //Simon
        /// <summary>
        /// Quitte le jeu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boutonPersonnaliseQuitter_Click(object sender, EventArgs e)
        {

            PauserLeJeu();
            if(MessageBox.Show("Aucune donnée sera préservée, voulez-vous vraiment quitter le jeu?", "Quitter le jeu",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                ArreterMusique();
                threadMusique.Abort();
                Application.Exit();
            }
            ReprendreLeJeu();
        }

        //Simon
        /// <summary>
        /// Faire jouer la musique.
        /// </summary>
        void JouerMusique()
        {
            jouerMusique = true;
            musique.URL = musiqueChemin;
            musique.controls.play();
        }
        //Simon
        /// <summary>
        /// Arrête la musique.
        /// </summary>
        void ArreterMusique()
        {
            jouerMusique = false;
            musique.controls.stop();
        }
        //Simon
        /// <summary>
        /// Gère la musique.
        /// </summary>
        void gererMusique()
        {
            while(true)
            {
                try
                {
                    if(jouerMusique && musique.playState == WMPPlayState.wmppsStopped)
                    {
                        JouerMusique();
                    }
                    else if (musique.playState == WMPPlayState.wmppsPlaying && !jouerMusique)
                    {
                        ArreterMusique();
                    }
                }
                catch
                {

                }
                Thread.Sleep(100);
            }
        }

        // Yannick
        /// <summary>
        /// Tester la rotation des blocs.
        /// </summary>
        void Tester_BougerBlocAntiHoraire()
        {
            // Rotation d’un bloc seul placé au centre de la surface de jeu.

            // Initialisation des variables.
            tempsDebutDeJeu = DateTime.Now;
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            operateurRotationI = new int[4];
            operateurRotationJ = new int[4];
            blocActifEnJeu = TypeBloc.Ligne;
            status = 0;

            blocActifIEnJeu[0] = 10;
            blocActifIEnJeu[1] = 10;
            blocActifIEnJeu[2] = 10;
            blocActifIEnJeu[3] = 10;

            blocActifJEnJeu[0] = 4;
            blocActifJEnJeu[1] = 5;
            blocActifJEnJeu[2] = 6;
            blocActifJEnJeu[3] = 7;

            for (int i = 0; i < blocActifIEnJeu.Length; i++)
            {
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.Ligne;
            }

            // Appel de la fonction.
            BougerBlocAntiHoraire();

            // Vérification
            Debug.Assert(
                tableauDeBlocs[11, 05] == TypeBloc.Ligne &&
                tableauDeBlocs[10, 05] == TypeBloc.Ligne &&
                tableauDeBlocs[09, 05] == TypeBloc.Ligne &&
                tableauDeBlocs[08, 05] == TypeBloc.Ligne
                , "erreur de rotation d'une ligne au milieu du tableau.");

            // Rotation d’un bloc seul placé à gauche de la surface de jeu.

            // Initialisation des variables.
            tempsDebutDeJeu = DateTime.Now;
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            operateurRotationI = new int[4];
            operateurRotationJ = new int[4];
            blocActifEnJeu = TypeBloc.Ligne;
            blocActifProchain = TypeBloc.Ligne;
            status = 0;

            blocActifIEnJeu[0] = 10;
            blocActifIEnJeu[1] = 10;
            blocActifIEnJeu[2] = 10;
            blocActifIEnJeu[3] = 10;

            blocActifJEnJeu[0] = 0;
            blocActifJEnJeu[1] = 1;
            blocActifJEnJeu[2] = 2;
            blocActifJEnJeu[3] = 3;

            for (int i = 0; i < blocActifIEnJeu.Length; i++)
            {
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.Ligne;
            }

            // Appel de la fonction.
            BougerBlocAntiHoraire();

            // Vérification
            Debug.Assert(
                tableauDeBlocs[11, 01] == TypeBloc.Ligne &&
                tableauDeBlocs[10, 01] == TypeBloc.Ligne &&
                tableauDeBlocs[09, 01] == TypeBloc.Ligne &&
                tableauDeBlocs[08, 01] == TypeBloc.Ligne
                , "erreur de rotation d'une ligne à la gauche du tableau.");

            // Rotation d’un bloc seul placé à droite de la surface de jeu.

            // Initialisation des variables.
            tempsDebutDeJeu = DateTime.Now;
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            operateurRotationI = new int[4];
            operateurRotationJ = new int[4];
            blocActifEnJeu = TypeBloc.Ligne;
            blocActifProchain = TypeBloc.Ligne;
            status = 0;

            blocActifIEnJeu[0] = 10;
            blocActifIEnJeu[1] = 10;
            blocActifIEnJeu[2] = 10;
            blocActifIEnJeu[3] = 10;

            blocActifJEnJeu[0] = 8;
            blocActifJEnJeu[1] = 9;
            blocActifJEnJeu[2] = 10;
            blocActifJEnJeu[3] = 11;

            for (int i = 0; i < blocActifIEnJeu.Length; i++)
            {
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.Ligne;
            }

            // Appel de la fonction.
            BougerBlocAntiHoraire();

            // Vérification
            Debug.Assert(
                tableauDeBlocs[11, 09] == TypeBloc.Ligne &&
                tableauDeBlocs[10, 09] == TypeBloc.Ligne &&
                tableauDeBlocs[09, 09] == TypeBloc.Ligne &&
                tableauDeBlocs[08, 09] == TypeBloc.Ligne
                , "erreur de rotation d'une ligne à la droite du tableau.");

        }

        // Yannick 
        /// <summary>
        /// Tester la détection de fin de partie.
        /// </summary>
        void Tester_InformerFinDePartie()
        {
            // Détection de la fin de la partie (partie terminée)

            // Initialisation des variables.
            tempsDebutDeJeu = DateTime.Now;
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            operateurRotationI = new int[4];
            operateurRotationJ = new int[4];
            blocActifEnJeu = TypeBloc.Ligne;
            blocActifProchain = GenererBloc(TypeBloc.Carre, blocActifIProchain, blocActifJProchain);
            status = 0;

            blocActifIEnJeu[0] = 0;
            blocActifIEnJeu[1] = 0;
            blocActifIEnJeu[2] = 0;
            blocActifIEnJeu[3] = 0;

            blocActifJEnJeu[0] = 4;
            blocActifJEnJeu[1] = 5;
            blocActifJEnJeu[2] = 6;
            blocActifJEnJeu[3] = 7;

            for (int i = 0; i < blocActifIEnJeu.Length; i++)
            {
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.GeleLigne;
            }

            
            // Appel de la fonction et vérification
            Debug.Assert(VerifierSiTransformerProchainBlocEnActifPossible() == false,"Erreur dans la detection de fin de partie (partie terminée)");

            // Détection de la fin de la partie (partie non terminée)

            // Initialisation des variables.
            tempsDebutDeJeu = DateTime.Now;
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            operateurRotationI = new int[4];
            operateurRotationJ = new int[4];
            blocActifEnJeu = TypeBloc.Ligne;
            blocActifProchain = GenererBloc(TypeBloc.Carre, blocActifIProchain, blocActifJProchain);
            status = 0;

            // Appel de la fonction et vérification
            Debug.Assert(VerifierSiTransformerProchainBlocEnActifPossible(), "Erreur dans la detection de fin de partie (partie terminée)");
        }
    }   
}
