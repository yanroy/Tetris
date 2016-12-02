using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetTetrisSession1Tp3
{
    //Simon
    public class ScoreThread
    {
        int posScore;
        FormPrincipal frmPrincipal;
        public ScoreThread(int posScore, FormPrincipal frmPrincipal)
        {
            this.posScore = posScore;
            this.frmPrincipal = frmPrincipal;
        }
        public void ScoreTimer()
        {
            Thread.Sleep(4000);
            frmPrincipal.scoreTemporaire[posScore] = 0;
        }
    }
}
