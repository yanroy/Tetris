using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetTetrisSession1Tp3
{
    public partial class FormPrincipal : Form
    {
        FrmOption fmrOption = new FrmOption();
        Random rnd = new Random();
        SolidBrush couleur1JeuArrierePlan = new SolidBrush(Color.Beige);
        SolidBrush couleur2JeuArrierePlan = new SolidBrush(Color.DarkGray);
        int grosseurDesBlocs = 28;
        Keys keysBougerADroite = Keys.Right;
        Keys keysBougerAGauche = Keys.Left;
        Keys keysTournerSensAntihoraire = Keys.X;
        Keys keysTournerSensHoraire = Keys.Z;
        int nbreLignes = 22;
        int nbreColonnes = 12;
        // 0: Gelé | 1: carré | 2: J | 3: L | 4: Ligne | 5: S | 6: T | 7: Z
        Bitmap[] imageBlocs = new Bitmap[] {Properties.Resources.Gele, Properties.Resources.carre, Properties.Resources.J, Properties.Resources.L,
                                            Properties.Resources.ligne, Properties.Resources.S, Properties.Resources.T, Properties.Resources.Z, };
        TypeBloc[,] tableauDeBlocs;
        int[] BlocActifI;
        int[] BlocActifJ;
        int[] BlocActifIProchain;
        int[] BlocActifJProchain;
        TypeBloc blocActif = TypeBloc.None;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            InitialiserJeu();
        }
        //Simon
        void DessinerJeu()
        {
            Graphics graphicsPanelJeu = panelJeu.CreateGraphics();
            Bitmap imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            //Faire le dessinage du jeu ici-----------
            DessinerFondJeu(imageJeu);
            DessinerLesBlocs(imageJeu);
            //-----------------------------------------
            graphicsPanelJeu.DrawImage(imageJeu, 0, 0);
            graphicsPanelJeu.Dispose();
            imageJeu.Dispose();
        }
        //Simon
        private void timerDescenteBloc_Tick(object sender, EventArgs e)
        {
            if (DeterminerSiLeBlocPeutBouger(Deplacement.Down))
            {
                BougerBlocActif(Deplacement.Down);
            }
            else
            {
                for(int i = 0;i < BlocActifI.Length;i++)
                {
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = TypeBloc.Gelé;
                }
                TransformerProchainBlocEnActif();
                GenererBlocAleatoire();
            }
            DessinerJeu();
        }
        //Simon
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == keysBougerADroite && DeterminerSiLeBlocPeutBouger(Deplacement.Right))
            {
                BougerBlocActif(Deplacement.Right);
                return true;
            }
            else if (keyData == keysBougerAGauche && DeterminerSiLeBlocPeutBouger(Deplacement.Left))
            {
                BougerBlocActif(Deplacement.Left);
                return true;
            }
            else if (keyData == keysTournerSensAntihoraire)
            {
                //Tourner antihoraire
                return true;
            }
            else if (keyData == keysTournerSensHoraire)
            {
                //Tourner horaire
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        //Simon
        void DessinerFondJeu(Bitmap imageJeu)
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
            graphicsImageJeu.Dispose();
        }
        //Simon
        void DessinerLesBlocs(Bitmap imageJeu)
        {
            Graphics graphicsImageJeu = Graphics.FromImage(imageJeu);
            for (int i = 0; i < nbreLignes; i++)
            {
                for (int j = 0; j < nbreColonnes; j++)
                {
                    switch (tableauDeBlocs[i, j])
                    {
                        case TypeBloc.Carré:
                            graphicsImageJeu.DrawImage(imageBlocs[1], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Gelé:
                            graphicsImageJeu.DrawImage(imageBlocs[0], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.J:
                            graphicsImageJeu.DrawImage(imageBlocs[2], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.L:
                            graphicsImageJeu.DrawImage(imageBlocs[3], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Ligne:
                            graphicsImageJeu.DrawImage(imageBlocs[4], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.S:
                            graphicsImageJeu.DrawImage(imageBlocs[5], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.T:
                            graphicsImageJeu.DrawImage(imageBlocs[6], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Z:
                            graphicsImageJeu.DrawImage(imageBlocs[7], grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                    }
                }
            }
            graphicsImageJeu.Dispose();
        }
        //Simon
        void GenererBlocAleatoire()
        {
            switch (ChoisirBlocAleatoirement())
            {
                case TypeBloc.Carré:
                    blocActif = TypeBloc.Carré;

                    BlocActifIProchain[0] = 0;
                    BlocActifIProchain[1] = 0;
                    BlocActifIProchain[2] = 1;
                    BlocActifIProchain[3] = 1;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2;
                    break;
                case TypeBloc.J:
                    blocActif = TypeBloc.J;

                    BlocActifIProchain[0] = 0;
                    BlocActifIProchain[1] = 0;
                    BlocActifIProchain[2] = 0;
                    BlocActifIProchain[3] = 1;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2 - 2;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2;
                    break;
                case TypeBloc.L:
                    blocActif = TypeBloc.L;

                    BlocActifIProchain[0] = 1;
                    BlocActifIProchain[1] = 1;
                    BlocActifIProchain[2] = 1;
                    BlocActifIProchain[3] = 0;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2 - 2;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2;
                    break;
                case TypeBloc.Ligne:
                    blocActif = TypeBloc.Ligne;

                    BlocActifIProchain[0] = 0;
                    BlocActifIProchain[1] = 0;
                    BlocActifIProchain[2] = 0;
                    BlocActifIProchain[3] = 0;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2 - 2;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2 + 1;
                    break;
                case TypeBloc.S:
                    blocActif = TypeBloc.S;

                    BlocActifIProchain[0] = 0;
                    BlocActifIProchain[1] = 0;
                    BlocActifIProchain[2] = 1;
                    BlocActifIProchain[3] = 1;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2 - 2;
                    break;
                case TypeBloc.T:
                    blocActif = TypeBloc.T;

                    BlocActifIProchain[0] = 0;
                    BlocActifIProchain[1] = 0;
                    BlocActifIProchain[2] = 0;
                    BlocActifIProchain[3] = 1;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2 - 2;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    break;
                case TypeBloc.Z:
                    blocActif = TypeBloc.Z;

                    BlocActifIProchain[0] = 0;
                    BlocActifIProchain[1] = 0;
                    BlocActifIProchain[2] = 1;
                    BlocActifIProchain[3] = 1;

                    BlocActifJProchain[0] = tableauDeBlocs.GetLength(1) / 2 - 2;
                    BlocActifJProchain[1] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[2] = tableauDeBlocs.GetLength(1) / 2 - 1;
                    BlocActifJProchain[3] = tableauDeBlocs.GetLength(1) / 2;
                    break;
            }
        }
        //Simon
        void TransformerProchainBlocEnActif()
        {
            BlocActifI[0] = BlocActifIProchain[0];
            BlocActifI[1] = BlocActifIProchain[1];
            BlocActifI[2] = BlocActifIProchain[2];
            BlocActifI[3] = BlocActifIProchain[3];

            BlocActifJ[0] = BlocActifJProchain[0];
            BlocActifJ[1] = BlocActifJProchain[1];
            BlocActifJ[2] = BlocActifJProchain[2];
            BlocActifJ[3] = BlocActifJProchain[3];

            tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = blocActif;
            tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = blocActif;
            tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = blocActif;
            tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = blocActif;
        }
        //Simon
        TypeBloc ChoisirBlocAleatoirement()
        {
            return (TypeBloc)rnd.Next(2, (int)TypeBloc.Z + 1);
        }
        //Simon
        bool DeterminerSiLeBlocPeutBouger(Deplacement direction)
        {
            if(direction == Deplacement.Down)
            {
                for(int i = 0; i < BlocActifI.Length; i++)
                {
                    if(BlocActifI[i] + 1 >= tableauDeBlocs.GetLength(0) || tableauDeBlocs[BlocActifI[i] + 1, BlocActifJ[i]] == TypeBloc.Gelé)
                    {
                        return false;
                    }
                }
            }
            else if(direction == Deplacement.Right)
            {
                for(int i = 0; i < BlocActifJ.Length; i++)
                {
                    if (BlocActifJ[i] + 1 >= tableauDeBlocs.GetLength(1) || tableauDeBlocs[BlocActifI[i], BlocActifJ[i] + 1] == TypeBloc.Gelé)
                    {
                        return false;
                    }
                }
            }
            else if (direction == Deplacement.Left)
            {
                for (int i = 0; i < BlocActifJ.Length; i++)
                {
                    if (BlocActifJ[i] - 1 < 0 || tableauDeBlocs[BlocActifI[i], BlocActifJ[i] - 1] == TypeBloc.Gelé)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Simon
        void BougerBlocActif(Deplacement direction)
        {
            if(direction == Deplacement.Down)
            {
                for(int i = 0; i < BlocActifI.Length;i++)
                {
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = TypeBloc.None;
                }
                for (int i = 0; i < BlocActifI.Length; i++)
                {
                    BlocActifI[i]++;
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = blocActif;
                }
            }
            else if(direction == Deplacement.Right)
            {
                for (int i = 0; i < BlocActifI.Length; i++)
                {
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = TypeBloc.None;
                }
                for (int i = 0; i < BlocActifI.Length; i++)
                {
                    BlocActifJ[i]++;
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = blocActif;
                }
            }
            else if (direction == Deplacement.Left)
            {
                for (int i = 0; i < BlocActifI.Length; i++)
                {
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = TypeBloc.None;
                }
                for (int i = 0; i < BlocActifI.Length; i++)
                {
                    BlocActifJ[i]--;
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = blocActif;
                }
            }
        }
        //Simon
        void InitialiserJeu()
        {
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            BlocActifI = new int[4];
            BlocActifJ = new int[4];
            BlocActifIProchain = new int[4];
            BlocActifJProchain = new int[4];
            GenererBlocAleatoire();
            TransformerProchainBlocEnActif();
            GenererBlocAleatoire();
            DessinerJeu();
        }
        //Simon
        private void ConfigurerJeu()
        {
            if(fmrOption.ShowDialog() == DialogResult.OK)
            {
                nbreColonnes = fmrOption.nbreColonnes;
                nbreLignes = fmrOption.nbreLignes;
                for (int i = 0; i < imageBlocs.Length; i++)
                {
                    imageBlocs[i] = fmrOption.imageBlocs[i];
                }
                couleur1JeuArrierePlan = fmrOption.couleur1JeuArrierePlan;
                couleur2JeuArrierePlan = fmrOption.couleur2JeuArrierePlan;
                timerDescenteBloc.Interval = fmrOption.vitesse;
                InitialiserJeu();
            }
            else
            {
                fmrOption.nbreColonnes = nbreColonnes;
                nbreLignes = fmrOption.nbreLignes;
                for (int i = 0; i < imageBlocs.Length; i++)
                {
                    fmrOption.imageBlocs[i] = imageBlocs[i];
                }
                fmrOption.couleur1JeuArrierePlan = couleur1JeuArrierePlan;
                fmrOption.couleur2JeuArrierePlan = couleur2JeuArrierePlan;
                fmrOption.vitesse = timerDescenteBloc.Interval;
            }
        }
        //Simon
        private void boutonPersonnaliseOption_Click(object sender, EventArgs e)
        {
            ConfigurerJeu();
        }

        // Yannick
        bool DetectionDeFinDePartie()
        {
            bool partieEstFinnie = false;
            return partieEstFinnie;
        } 
    }
}
