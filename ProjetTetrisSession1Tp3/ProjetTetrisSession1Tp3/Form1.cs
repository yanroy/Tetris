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
        Bitmap[] imageBlocs = new Bitmap[] {Properties.Resources.Gele, Properties.Resources.carre, Properties.Resources.ligne, Properties.Resources.T,
                                            Properties.Resources.L, Properties.Resources.J, Properties.Resources.S, Properties.Resources.Z, };
        TypeBloc[,] tableauDeBlocs;
        int[] blocActifIEnJeu;
        int[] blocActifJEnJeu;
        int[] blocActifIProchain;
        int[] blocActifJProchain;
        TypeBloc blocActifEnJeu = TypeBloc.None;
        TypeBloc blocActifProchain = TypeBloc.None;
        bool jeuSurPause = false;
        Bitmap imageJeu;
        string pauseText = "Pause";
        public FormPrincipal()
        {
            InitializeComponent();
        }
        //Simon
        void DessinerJeu()
        {
            Graphics graphicsPanelJeu = panelJeu.CreateGraphics();
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            //Faire le dessinage du jeu ici-----------
            DessinerFondJeu();
            DessinerLesBlocs();
            //-----------------------------------------
            graphicsPanelJeu.DrawImage(imageJeu, 0, 0);
            graphicsPanelJeu.Dispose();
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
                for(int i = 0;i < blocActifIEnJeu.Length;i++)
                {
                    tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = TypeBloc.Gelé;
                }
                EnleverLignesCompletes();
                TransformerProchainBlocEnActif();
                blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
            }
            DessinerJeu();
            DessinerProchainBloc();
        }
        //Simon
        void EnleverLignesCompletes()
        {
            for(int i = 0; i < tableauDeBlocs.GetLength(0);i++)
            {
                if (EstUneLigneComplete(i))
                {
                    DecalerLignes(i);
                }
            }
        }
        //Simon
        bool EstUneLigneComplete(int ligne)
        {
            int compteurBlocsGeles = 0;
            for(int j = 0; j < tableauDeBlocs.GetLength(1);j++)
            {
                if(tableauDeBlocs[ligne,j] == TypeBloc.Gelé)
                {
                    compteurBlocsGeles++;
                }
            }
            return compteurBlocsGeles == tableauDeBlocs.GetLength(1) ? true : false;
        }
        //Simon
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
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(jeuSurPause)
            {
                return false;
            }
            else if (keyData == keysBougerADroite && DeterminerSiLeBlocPeutBouger(Deplacement.Right))
            {
                BougerBlocActif(Deplacement.Right);
                DessinerJeu();
                return true;
            }
            else if (keyData == keysBougerAGauche && DeterminerSiLeBlocPeutBouger(Deplacement.Left))
            {
                BougerBlocActif(Deplacement.Left);
                DessinerJeu();
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
            graphicsImageJeu.Dispose();
        }
        //Simon
        void DessinerLesBlocs()
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
                    }
                }
            }
            graphicsImageJeu.Dispose();
        }
        //Simon
        TypeBloc GenererBloc(TypeBloc blocAGenerer, int[] blocActifIVariable, int[] blocActifJVariable)
        {
            TypeBloc blocActifVariable = blocAGenerer;
            switch (blocActifVariable)
            {
                case TypeBloc.Carré:
                    blocActifVariable = TypeBloc.Carré;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 2 - 1;
                    blocActifJVariable[1] = 2;
                    blocActifJVariable[2] = 2 - 1;
                    blocActifJVariable[3] = 2;
                    break;
                case TypeBloc.J:
                    blocActifVariable = TypeBloc.J;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 1;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 2 - 2;
                    blocActifJVariable[1] = 2 - 2;
                    blocActifJVariable[2] = 2 - 1;
                    blocActifJVariable[3] = 2;
                    break;
                case TypeBloc.L:
                    blocActifVariable = TypeBloc.L;

                    blocActifIVariable[0] = 1;
                    blocActifIVariable[1] = 1;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 0;

                    blocActifJVariable[0] = 2 - 2;
                    blocActifJVariable[1] = 2 - 1;
                    blocActifJVariable[2] = 2;
                    blocActifJVariable[3] = 2;
                    break;
                case TypeBloc.Ligne:
                    blocActifVariable = TypeBloc.Ligne;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 0;
                    blocActifIVariable[3] = 0;

                    blocActifJVariable[0] = 2 - 2;
                    blocActifJVariable[1] = 2 - 1;
                    blocActifJVariable[2] = 2;
                    blocActifJVariable[3] = 2 + 1;
                    break;
                case TypeBloc.S:
                    blocActifVariable = TypeBloc.S;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 2;
                    blocActifJVariable[1] = 2 - 1;
                    blocActifJVariable[2] = 2 - 1;
                    blocActifJVariable[3] = 2 - 2;
                    break;
                case TypeBloc.T:
                    blocActifVariable = TypeBloc.T;

                    blocActifIVariable[0] = 1;
                    blocActifIVariable[1] = 1;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 0;

                    blocActifJVariable[0] = 2 - 2;
                    blocActifJVariable[1] = 2 - 1;
                    blocActifJVariable[2] = 2;
                    blocActifJVariable[3] = 2 - 1;
                    break;
                case TypeBloc.Z:
                    blocActifVariable = TypeBloc.Z;

                    blocActifIVariable[0] = 0;
                    blocActifIVariable[1] = 0;
                    blocActifIVariable[2] = 1;
                    blocActifIVariable[3] = 1;

                    blocActifJVariable[0] = 2 - 2;
                    blocActifJVariable[1] = 2 - 1;
                    blocActifJVariable[2] = 2 - 1;
                    blocActifJVariable[3] = 2;
                    break;
            }
            return blocActifVariable;
        }
        //Simon
        void TransformerProchainBlocEnActif()
        {
            blocActifEnJeu = blocActifProchain;

            for(int i =0; i < blocActifIEnJeu.Length;i++)
            {
                blocActifIEnJeu[i] = blocActifIProchain[i];
                blocActifJEnJeu[i] = blocActifJProchain[i] + tableauDeBlocs.GetLength(1) / 2 - 2;
                tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i]] = blocActifEnJeu;
            }
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
                for(int i = 0; i < blocActifIEnJeu.Length; i++)
                {
                    if(blocActifIEnJeu[i] + 1 >= tableauDeBlocs.GetLength(0) || tableauDeBlocs[blocActifIEnJeu[i] + 1, blocActifJEnJeu[i]] == TypeBloc.Gelé)
                    {
                        return false;
                    }
                }
            }
            else if(direction == Deplacement.Right)
            {
                for(int i = 0; i < blocActifJEnJeu.Length; i++)
                {
                    if (blocActifJEnJeu[i] + 1 >= tableauDeBlocs.GetLength(1) || tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i] + 1] == TypeBloc.Gelé)
                    {
                        return false;
                    }
                }
            }
            else if (direction == Deplacement.Left)
            {
                for (int i = 0; i < blocActifJEnJeu.Length; i++)
                {
                    if (blocActifJEnJeu[i] - 1 < 0 || tableauDeBlocs[blocActifIEnJeu[i], blocActifJEnJeu[i] - 1] == TypeBloc.Gelé)
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
        }
        //Simon
        void InitialiserJeu()
        {
            imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            tableauDeBlocs = new TypeBloc[nbreLignes, nbreColonnes];
            blocActifIEnJeu = new int[4];
            blocActifJEnJeu = new int[4];
            blocActifIProchain = new int[4];
            blocActifJProchain = new int[4];
            blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
            TransformerProchainBlocEnActif();
            blocActifProchain = GenererBloc(ChoisirBlocAleatoirement(), blocActifIProchain, blocActifJProchain);
            DessinerJeu();
        }
        //Simon
        void ConfigurerJeu()
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
            ReprendreLeJeu();
        }
        //Simon
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
            graphicsProchainBloc.Dispose();
            prochainBlocImage.Dispose();
            graphicsProchainBlocImage.Dispose();
        }
        //Simon
        void PauserLeJeu()
        {
            jeuSurPause = true;
            timerDescenteBloc.Enabled = false;
            Brush brush = new SolidBrush(Color.FromArgb(200,Color.Black));
            Graphics graphicsPauseJeu = panelJeu.CreateGraphics();
            graphicsPauseJeu.FillRectangle(brush, ClientRectangle);
            graphicsPauseJeu.DrawString(pauseText, labelTitre.Font,new SolidBrush(Color.White), panelJeu.Width/2 - graphicsPauseJeu.MeasureString(pauseText, labelTitre.Font).Width/2, 100);
            graphicsPauseJeu.Dispose();
        }
        //Simon
        void ReprendreLeJeu()
        {
            jeuSurPause = false;
            timerDescenteBloc.Enabled = true;
        }
        //Simon
        private void boutonPersonnaliseOption_Click(object sender, EventArgs e)
        {
            PauserLeJeu();
            ConfigurerJeu();
            DessinerJeu();
        }
        // Yannick
        bool DetectionDeFinDePartie()
        {
            bool partieEstFinnie = false;
            return partieEstFinnie;
        }
        //Simon
        private void boutonPersonnaliseNouvellePartie_Click(object sender, EventArgs e)
        {
            PauserLeJeu();
            if (MessageBox.Show("Toute partie en cours sera perdu, voulez-vous vraiment faire une nouvelle partie?","Nouvelle partie",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                InitialiserJeu();
            }
            ReprendreLeJeu();
            DessinerJeu();
        }
        //Simon
        private void panelJeu_Paint(object sender, PaintEventArgs e)
        {
            InitialiserJeu();
        }
        //Simon
        private void panelProchainBloc_Paint(object sender, PaintEventArgs e)
        {
            DessinerProchainBloc();
        }
        //Simon
        private void boutonPersonnaliseQuitter_Click(object sender, EventArgs e)
        {
            PauserLeJeu();
            if(MessageBox.Show("Aucune donnée sera préservée, voulez-vous vraiment quitter le jeu.", "Quitter le jeu",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();
            }
            DessinerJeu();
            ReprendreLeJeu();
        }
    }
}
