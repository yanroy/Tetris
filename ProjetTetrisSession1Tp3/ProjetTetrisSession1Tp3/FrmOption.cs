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
        public int vitesse { set { numericUpDownVitesse.Value = value; } get { return (int)numericUpDownVitesse.Value; } }
        public int nbreLignes { set { numericUpDownNbreLignes.Value = value; } get { return (int)numericUpDownNbreLignes.Value; } }
        public int nbreColonnes { set { numericUpDownNbreColonnes.Value = value; } get { return (int)numericUpDownNbreColonnes.Value; } }
        public Bitmap[] imageBlocs {
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    pictureBoxBlocGele.BackgroundImage = value[0];
                    pictureBoxBlocCarre.BackgroundImage = value[0];
                    pictureBoxBlocJ.BackgroundImage = value[0];
                    pictureBoxBlocL.BackgroundImage = value[0];
                    pictureBoxBlocLigne.BackgroundImage = value[0];
                    pictureBoxBlocS.BackgroundImage = value[0];
                    pictureBoxBlocT.BackgroundImage = value[0];
                    pictureBoxBlocZ.BackgroundImage = value[0];
                }
            }
            get
            {
                Bitmap[] imageBlocs = new Bitmap[] { (Bitmap)pictureBoxBlocGele.BackgroundImage, (Bitmap)pictureBoxBlocCarre.BackgroundImage,
                    (Bitmap)pictureBoxBlocLigne.BackgroundImage, (Bitmap)pictureBoxBlocT.BackgroundImage, (Bitmap)pictureBoxBlocL.BackgroundImage,
                    (Bitmap)pictureBoxBlocJ.BackgroundImage, (Bitmap)pictureBoxBlocS.BackgroundImage, (Bitmap)pictureBoxBlocZ.BackgroundImage, };
                return imageBlocs;
            }
        }
        public SolidBrush couleur1JeuArrierePlan { set { pictureBoxCouleurFond1.BackColor = value.Color; } get { return new SolidBrush(pictureBoxCouleurFond1.BackColor); } }
        public SolidBrush couleur2JeuArrierePlan { set { pictureBoxCouleurFond2.BackColor = value.Color; } get { return new SolidBrush(pictureBoxCouleurFond2.BackColor); } }
        public FrmOption()
        {
            InitializeComponent();
            openFileDialogMusique.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            openFileDialogImages.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        private void buttonFichierMusique_Click(object sender, EventArgs e)
        {
            openFileDialogMusique.ShowDialog();
            textBoxMusiqueNomFichier.Text = openFileDialogMusique.FileName;
        }


        private void pictureBoxBlocGele_Click(object sender, EventArgs e)
        {
            if(openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocGele.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocCarre_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocCarre.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocJ_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocJ.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocL_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocL.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocLigne_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocLigne.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocS_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocS.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocT_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocT.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
        }

        private void pictureBoxBlocZ_Click(object sender, EventArgs e)
        {
            if (openFileDialogImages.ShowDialog() == DialogResult.OK)
            {
                pictureBoxBlocZ.BackgroundImage = Image.FromFile(Path.GetFullPath(openFileDialogImages.FileName));
            }
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
    }
}
