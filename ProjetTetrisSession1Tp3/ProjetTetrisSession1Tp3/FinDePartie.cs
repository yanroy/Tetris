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
        public bool test = true;
        public int compteurDeCarre = 0;
        public int compteurDeLigne = 0;
        public int compteurDeT = 0;
        public FinDePartie()
        {
            InitializeComponent();
        }
    }
}
