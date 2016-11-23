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
        SolidBrush couleur1JeuArrierePlan = new SolidBrush(Color.Beige);
        SolidBrush couleur2JeuArrierePlan = new SolidBrush(Color.DarkGray);
        int grosseurDesBlocs = 28;
        Keys keysBougerADroite = Keys.Right;
        Keys keysBougerAGauche = Keys.Left;
        Keys keysTournerSensAntihoraire = Keys.X;
        Keys keysTournerSensHoraire = Keys.Z;
        public FormPrincipal()
        {
            InitializeComponent();
            panelJeu.Focus();
        }
        void DessinerJeu()
        {
            Graphics graphicsPanelJeu = panelJeu.CreateGraphics();
            Bitmap imageJeu = new Bitmap(panelJeu.Size.Width, panelJeu.Size.Height);
            Graphics graphicsImageJeu = Graphics.FromImage(imageJeu);
            SolidBrush solidBrushUtilise = couleur1JeuArrierePlan;
            //Faire le dessinage du jeu ici-----------
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    graphicsImageJeu.FillRectangle(solidBrushUtilise, grosseurDesBlocs * j, grosseurDesBlocs * i, grosseurDesBlocs, grosseurDesBlocs);
                    solidBrushUtilise = solidBrushUtilise == couleur1JeuArrierePlan ? couleur2JeuArrierePlan : couleur1JeuArrierePlan;
                }
            }
            //-----------------------------------------
            graphicsPanelJeu.DrawImage(imageJeu, 0, 0);
            graphicsPanelJeu.Dispose();
            imageJeu.Dispose();
            graphicsImageJeu.Dispose();
        }

        private void timerDescenteBloc_Tick(object sender, EventArgs e)
        {
            //Faire les opérations de descente ici.
            DessinerJeu();
        }

        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == keysBougerADroite)
            {
                //Bouger à droite
            }
            else if (e.KeyCode == keysBougerAGauche)
            {
                //Bouger à gauche
            }
            else if (e.KeyCode == keysTournerSensAntihoraire)
            {
                //Tourner antihoraire
            }
            else if(e.KeyCode == keysTournerSensHoraire)
            {
                //Tourner horaire
            }
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
    }
}
