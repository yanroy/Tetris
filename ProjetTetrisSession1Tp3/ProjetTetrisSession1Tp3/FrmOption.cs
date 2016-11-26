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
    public partial class FrmOption : Form
    {
        public string Musique { get { return textBoxMusiqueNomFichier.Text; } }
        public bool MusiqueOn { get { return checkBoxMusiqueOn.CheckState == CheckState.Checked ? true : false; } }
        public FrmOption()
        {
            InitializeComponent();
            openFileDialogMusique.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        }

        private void buttonFichierMusique_Click(object sender, EventArgs e)
        {
            openFileDialogMusique.ShowDialog();
            textBoxMusiqueNomFichier.Text = openFileDialogMusique.FileName;
        }
    }
}
