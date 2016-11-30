using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetTetrisSession1Tp3
{
    public partial class FrmOption : Form
    {
        public int nbreLignes { set { numericUpDownNbreLignes.Value = value; } get { return (int)numericUpDownNbreLignes.Value; } }
        public int nbreColonnes { set { numericUpDownNbreColonnes.Value = value; } get { return (int)numericUpDownNbreColonnes.Value; } }
        public SolidBrush couleur1JeuArrierePlan { set { pictureBoxCouleurFond1.BackColor = value.Color; } get { return new SolidBrush(pictureBoxCouleurFond1.BackColor); } }
        public SolidBrush couleur2JeuArrierePlan { set { pictureBoxCouleurFond2.BackColor = value.Color; } get { return new SolidBrush(pictureBoxCouleurFond2.BackColor); } }
        public Keys keysBougerADroite { set { keysBougerADroite = value; textBoxToucheDroite.Text = value.ToString(); } get { return keysBougerADroite; } }
        public Keys keysBougerAGauche { set { keysBougerAGauche = value; textBoxToucheGauche.Text = value.ToString(); } get { return keysBougerAGauche; } }
        public Keys keysChute { set { keysChute = value; textBoxToucheChute.Text = value.ToString(); } get { return keysChute; } }
        public Keys keysReserve { set { keysReserve = value; textBoxToucheReserve.Text = value.ToString(); } get { return keysReserve; } }
        public Keys keysRotation { set { keysRotation = value; textBoxToucheRotation.Text = value.ToString(); } get { return keysRotation; } }
        public FrmOption()
        {
            InitializeComponent();
            openFileDialogMusique.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            textBoxToucheDroite.Text = Keys.Right.ToString();
            textBoxToucheGauche.Text = Keys.Left.ToString();
            textBoxToucheChute.Text = Keys.Down.ToString();
            textBoxToucheReserve.Text = Keys.C.ToString();
            textBoxToucheRotation.Text = Keys.X.ToString();
        }

        private void buttonFichierMusique_Click(object sender, EventArgs e)
        {
            openFileDialogMusique.ShowDialog();
            textBoxMusiqueNomFichier.Text = openFileDialogMusique.FileName;
        }

        private void pictureBoxCouleurFond1_Click(object sender, EventArgs e)
        {
            if (colorDialogCouleurFond.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCouleurFond1.BackColor = colorDialogCouleurFond.Color;
            }
        }

        private void pictureBoxCouleurFond2_Click(object sender, EventArgs e)
        {
            if (colorDialogCouleurFond.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCouleurFond2.BackColor = colorDialogCouleurFond.Color;
            }
        }

        private void textBoxToucheRotation_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxToucheRotation.Text = e.KeyCode.ToString();
        }
    }
}
