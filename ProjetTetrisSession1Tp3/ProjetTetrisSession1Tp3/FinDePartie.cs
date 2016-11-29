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

        private void buttonRejouer_Click(object sender, EventArgs e)
        {

        }

        private void FinDePartie_Load(object sender, EventArgs e)
        {
            lableTest.Text = compteurDeL.ToString();
        }
    }
}
