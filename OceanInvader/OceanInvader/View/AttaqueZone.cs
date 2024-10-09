using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class AttaqueZone
    {

        private Player player;
        private int zoneX;
        private int zoneY;

        public AttaqueZone(Player player)
        {
            this.player = player;
            this.zoneX = player.X;
            this.zoneY = player.Y;
        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Blue), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawRectangle(droneBrush, new Rectangle(zoneX, zoneY, 80, 5));
           

        }

    }
}
