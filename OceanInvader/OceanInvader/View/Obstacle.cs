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


        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(obstacleBrush, new Rectangle(objX, objY, 50, 5));


        }
    }
}
