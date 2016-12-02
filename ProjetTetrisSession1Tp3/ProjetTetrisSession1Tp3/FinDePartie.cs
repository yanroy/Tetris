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
    // Yannick
    // Variables publiques utilisées pour compter le nombre de blocs dans la partie.
    public partial class FinDePartie : Form
    {
        public int compteurDeCarre = 0;
        public int compteurDeLigne = 0;
        public int compteurDeT = 0;
        public int compteurDeL = 0;
        public int compteurDeJ = 0;
        public int compteurDeS = 0;
        public int compteurDeZ = 0;
        public FinDePartie()
        {
            InitializeComponent();
        }       
        // Affichage des nombres de blocs par partie.
        private void FinDePartie_Load(object sender, EventArgs e)
        {
            int total = compteurDeCarre + compteurDeLigne + compteurDeT + compteurDeL + compteurDeJ + compteurDeS + compteurDeZ;
            float PcCarre = compteurDeCarre / total * 100;

            labelCarre.Text = compteurDeCarre.ToString();
            labelLigne.Text = compteurDeLigne.ToString();
            labelT.Text     =     compteurDeT.ToString();
            labelL.Text     =     compteurDeL.ToString();                                   
            labelJ.Text     =     compteurDeJ.ToString();
            labelS.Text     =     compteurDeS.ToString();
            labelZ.Text     =     compteurDeZ.ToString();
        }
    }
}
