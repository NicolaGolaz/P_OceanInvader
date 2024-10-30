using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class Obstacle
    {
       
        protected SolidBrush obstacleBrush = new SolidBrush(Color.Black);
        private Pen hitBoxBrush = new Pen(new SolidBrush(Color.Red), 3);


        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(obstacleBrush, new Rectangle(objX, objY, 120, 5));
            drawingSpace.Graphics.DrawRectangle(hitBoxBrush,new Rectangle(objX , objY, 120, 5)); // Dessine l'HitBox


        }
    }
}
