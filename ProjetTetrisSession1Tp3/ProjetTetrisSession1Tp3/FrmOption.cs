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
    //Simon
    public partial class FrmOption : Form
    {
        public int nbreLignes { set { numericUpDownNbreLignes.Value = value; } get { return (int)numericUpDownNbreLignes.Value; } }
        public int nbreColonnes { set { numericUpDownNbreColonnes.Value = value; } get { return (int)numericUpDownNbreColonnes.Value; } }
        public SolidBrush couleur1JeuArrierePlan { set { pictureBoxCouleurFond1.BackColor = value.Color; } get { return new SolidBrush(pictureBoxCouleurFond1.BackColor); } }
        public SolidBrush couleur2JeuArrierePlan { set { pictureBoxCouleurFond2.BackColor = value.Color; } get { return new SolidBrush(pictureBoxCouleurFond2.BackColor); } }
        public Keys keysBougerADroite = Keys.Right;
        public Keys keysBougerAGauche = Keys.Left;
        public Keys keysChute = Keys.Down;
        public Keys keysReserve = Keys.C;
        public Keys keysRotation = Keys.Up;
        public bool jouerMusique = false;
        public string musiqueChemin = "";
        public FrmOption()
        {
            InitializeComponent();
            openFileDialogMusique.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            textBoxToucheDroite.Text = keysBougerADroite.ToString();
            textBoxToucheGauche.Text = keysBougerAGauche.ToString();
            textBoxToucheChute.Text = keysChute.ToString();
            textBoxToucheReserve.Text = keysReserve.ToString();
            textBoxToucheRotation.Text = keysRotation.ToString();
            textBoxToucheDroite.Text = keysBougerADroite.ToString();
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
            keysRotation = e.KeyCode;
        }

        private void textBoxToucheReserve_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxToucheReserve.Text = e.KeyCode.ToString();
            keysReserve = e.KeyCode;
        }

        private void textBoxToucheChute_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxToucheChute.Text = e.KeyCode.ToString();
            keysChute = e.KeyCode;
        }

        private void textBoxToucheGauche_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxToucheGauche.Text = e.KeyCode.ToString();
            keysBougerAGauche = e.KeyCode;
        }

        private void textBoxToucheDroite_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxToucheDroite.Text = e.KeyCode.ToString();
            keysBougerADroite = e.KeyCode;
        }

        private void checkBoxMusiqueOn_CheckedChanged(object sender, EventArgs e)
        {
            jouerMusique = checkBoxMusiqueOn.CheckState == CheckState.Checked ? true : false;
        }

        private void textBoxMusiqueNomFichier_TextChanged(object sender, EventArgs e)
        {
            musiqueChemin = textBoxMusiqueNomFichier.Text;
        }
    }
}
