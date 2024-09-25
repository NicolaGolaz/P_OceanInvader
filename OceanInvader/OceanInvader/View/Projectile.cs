using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class Projectile
    {

        private Player player;
        private int projX;
        private int projY;

        public Projectile(Player player)
        {
            this.player = player;
            int projX = player.X;
            int projY = player.Y;
        }
        

        private Pen droneBrush = new Pen(new SolidBrush(Color.Red), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawRectangle(droneBrush, new Rectangle(projX,projY, 10, 20));

        }
    }
}
