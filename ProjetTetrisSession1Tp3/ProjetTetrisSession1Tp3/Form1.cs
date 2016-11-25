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
        Random rnd = new Random();
        SolidBrush couleur1JeuArrierePlan = new SolidBrush(Color.Beige);
        SolidBrush couleur2JeuArrierePlan = new SolidBrush(Color.DarkGray);
        int grosseurDesBlocs = 28;
        Keys keysBougerADroite = Keys.Right;
        Keys keysBougerAGauche = Keys.Left;
        Keys keysTournerSensAntihoraire = Keys.X;
        Keys keysTournerSensHoraire = Keys.Z;
        public int nbreLignes = 22;
        public int nbreColonnes = 12;
        TypeBloc[,] tableauDeBlocs;
        int[] BlocActifI;
        int[] BlocActifJ;
        TypeBloc blocActif = TypeBloc.None;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            BlocActifI = new int[4];
            BlocActifJ = new int[4];
        }
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
        private void timerDescenteBloc_Tick(object sender, EventArgs e)
        {
            if (DeterminerSiLeBlocPeutDescendre())
            {
                DescendreBlocActif();
            }
            else
            {
                for(int i = 0;i < BlocActifI.Length;i++)
                {
                    tableauDeBlocs[BlocActifI[i], BlocActifJ[i]] = TypeBloc.Gelé;
                }
                GenererBlocAleatoire();
            }
            DessinerJeu();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == keysBougerADroite)
            {
                //Bouger à droite
                return true;
            }
            else if (keyData == keysBougerAGauche)
            {
                //Bouger à gauche
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
        void DessinerFondJeu(Bitmap imageJeu)
        {
            Graphics graphicsImageJeu = Graphics.FromImage(imageJeu);
            SolidBrush solidBrushUtilise = couleur1JeuArrierePlan;
            for (int i = 0; i < nbreLignes; i++)
            {
                for (int j = 0; j < nbreColonnes; j++)
                {
                    graphicsImageJeu.FillRectangle(solidBrushUtilise, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                    solidBrushUtilise = solidBrushUtilise == couleur1JeuArrierePlan ? couleur2JeuArrierePlan : couleur1JeuArrierePlan;
                }
            }
            graphicsImageJeu.Dispose();
        }
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
                            graphicsImageJeu.DrawImage(Properties.Resources.carre, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Gelé:
                            graphicsImageJeu.DrawImage(Properties.Resources.Gele, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.J:
                            graphicsImageJeu.DrawImage(Properties.Resources.J, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.L:
                            graphicsImageJeu.DrawImage(Properties.Resources.L, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Ligne:
                            graphicsImageJeu.DrawImage(Properties.Resources.ligne, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.S:
                            graphicsImageJeu.DrawImage(Properties.Resources.S, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.T:
                            graphicsImageJeu.DrawImage(Properties.Resources.T, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                        case TypeBloc.Z:
                            graphicsImageJeu.DrawImage(Properties.Resources.Z, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                            break;
                    }
                }
            }
            graphicsImageJeu.Dispose();
        }
        void GenererBlocAleatoire()
        {
            switch (ChoisirBlocAleatoirement())
            {
                case TypeBloc.Carré:
                    blocActif = TypeBloc.Carré;

                    BlocActifI[0] = 0;
                    BlocActifI[1] = 0;
                    BlocActifI[2] = 1;
                    BlocActifI[3] = 1;

                    BlocActifJ[0] = 5;
                    BlocActifJ[1] = 6;
                    BlocActifJ[2] = 5;
                    BlocActifJ[3] = 6;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.Carré;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.Carré;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.Carré;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.Carré;
                    break;
                case TypeBloc.J:
                    blocActif = TypeBloc.J;

                    BlocActifI[0] = 0;
                    BlocActifI[1] = 0;
                    BlocActifI[2] = 0;
                    BlocActifI[3] = 1;

                    BlocActifJ[0] = 4;
                    BlocActifJ[1] = 5;
                    BlocActifJ[2] = 6;
                    BlocActifJ[3] = 6;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.J;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.J;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.J;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.J;
                    break;
                case TypeBloc.L:
                    blocActif = TypeBloc.L;

                    BlocActifI[0] = 1;
                    BlocActifI[1] = 1;
                    BlocActifI[2] = 1;
                    BlocActifI[3] = 0;

                    BlocActifJ[0] = 4;
                    BlocActifJ[1] = 5;
                    BlocActifJ[2] = 6;
                    BlocActifJ[3] = 6;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.L;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.L;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.L;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.L;
                    break;
                case TypeBloc.Ligne:
                    blocActif = TypeBloc.Ligne;

                    BlocActifI[0] = 0;
                    BlocActifI[1] = 0;
                    BlocActifI[2] = 0;
                    BlocActifI[3] = 0;

                    BlocActifJ[0] = 4;
                    BlocActifJ[1] = 5;
                    BlocActifJ[2] = 6;
                    BlocActifJ[3] = 7;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.Ligne;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.Ligne;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.Ligne;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.Ligne;
                    break;
                case TypeBloc.S:
                    blocActif = TypeBloc.S;

                    BlocActifI[0] = 0;
                    BlocActifI[1] = 0;
                    BlocActifI[2] = 1;
                    BlocActifI[3] = 1;

                    BlocActifJ[0] = 6;
                    BlocActifJ[1] = 5;
                    BlocActifJ[2] = 5;
                    BlocActifJ[3] = 4;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.S;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.S;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.S;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.S;
                    break;
                case TypeBloc.T:
                    blocActif = TypeBloc.T;

                    BlocActifI[0] = 0;
                    BlocActifI[1] = 0;
                    BlocActifI[2] = 0;
                    BlocActifI[3] = 1;

                    BlocActifJ[0] = 4;
                    BlocActifJ[1] = 5;
                    BlocActifJ[2] = 6;
                    BlocActifJ[3] = 5;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.T;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.T;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.T;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.T;
                    break;
                case TypeBloc.Z:
                    blocActif = TypeBloc.Z;

                    BlocActifI[0] = 0;
                    BlocActifI[1] = 0;
                    BlocActifI[2] = 1;
                    BlocActifI[3] = 1;

                    BlocActifJ[0] = 4;
                    BlocActifJ[1] = 5;
                    BlocActifJ[2] = 5;
                    BlocActifJ[3] = 6;

                    tableauDeBlocs[BlocActifI[0], BlocActifJ[0]] = TypeBloc.Z;
                    tableauDeBlocs[BlocActifI[1], BlocActifJ[1]] = TypeBloc.Z;
                    tableauDeBlocs[BlocActifI[2], BlocActifJ[2]] = TypeBloc.Z;
                    tableauDeBlocs[BlocActifI[3], BlocActifJ[3]] = TypeBloc.Z;
                    break;
            }
        }
        TypeBloc ChoisirBlocAleatoirement()
        {
            return (TypeBloc)rnd.Next(2, (int)TypeBloc.Z + 1);
        }
        bool DeterminerSiLeBlocPeutDescendre()
        {
            for(int i = 0; i < BlocActifI.Length; i++)
            {
                if(BlocActifI[i] + 1 >= tableauDeBlocs.GetLength(0) || tableauDeBlocs[BlocActifI[i] + 1, BlocActifJ[i]] == TypeBloc.Gelé)
                {
                    return false;
                }
            }
            return true;
        }
        void DescendreBlocActif()
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
        void InitialiserJeu()
        {
            GenererBlocAleatoire();
            DessinerJeu();
        }
        private void panelJeu_Paint(object sender, PaintEventArgs e)
        {
            InitialiserJeu();
        }

        private void boutonPersonnaliseOption_Click(object sender, EventArgs e)
        {

        }
    }
}
