using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetTetrisSession1Tp3
{
    public class BoutonPersonnalise: Button
    {
        private string displayText;
        //***********************************Important******************************\\
        // Je n'utilise pas la méthode de base, 
        // car je ne connais pas l'algorithme pour afficher le texte et donc je ne peut pas le modifier.
        [Description("Le texte montré sur le bouton - À utiliser à la place de Text")]
        public string DisplayText
        {
            get
            {
                return displayText;
            }

            set
            {
                displayText = value;
            }
        }
        private bool isActive = false;
        public BoutonPersonnalise()
        {
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }
        /// <summary>
        /// Override la méthode pour afficher le texte voulu. 
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            #region brush setting
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(ClientRectangle);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Red;
            Color[] colors = { Color.Transparent };
            brush.SurroundColors = colors;
            #endregion brushSetting
            if (isActive)
            {
                pe.Graphics.FillEllipse(brush, ClientRectangle);
            }
            drawtext(pe);
        }
        /// <summary>
        /// "Active le contrôle"
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isActive = true;
        }
        /// <summary>
        /// "Désactive le contrôle"
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isActive = false;
        }
        /// <summary>
        /// Dessine le text à afficher
        /// </summary>
        /// <param name="pe"></param>
        void drawtext(PaintEventArgs pe)
        {
            FontFamily fml = new FontFamily("Perpetua Titling MT");
            Font font = new Font("Perpetua Titling MT", Font.Size);
            SizeF sizeString = pe.Graphics.MeasureString(displayText, font);
            PointF thePoint = new PointF();
            thePoint.X = (Size.Width - sizeString.Width) / 2;
            thePoint.Y = (Size.Height - sizeString.Height) / 2;
            if (Enabled == false)
            {
                pe.Graphics.DrawString(displayText, font, new SolidBrush(Color.Gray), thePoint);
            }
            else
            {
                pe.Graphics.DrawString(displayText, font, new SolidBrush(Color.Black), thePoint);
            }
        }
    }
}
