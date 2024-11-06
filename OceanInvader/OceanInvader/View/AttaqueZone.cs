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
        private Image attaqueZoneImg = Image.FromFile(@"..\..\..\Images\AttaqueZone.png");
        public bool IsDestroyed { get; set; } = false;


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
            HitBox = new Rectangle(zoneX-13, zoneY, 90, 30);        
            drawingSpace.Graphics.DrawImage(attaqueZoneImg, new Rectangle(zoneX, zoneY, 60, 40));
            drawingSpace.Graphics.DrawImage(attaqueZoneImg, new Rectangle(zoneX+30, zoneY, 60, 40));
            drawingSpace.Graphics.DrawImage(attaqueZoneImg, new Rectangle(zoneX - 30, zoneY, 60, 40));

            //    drawingSpace.Graphics.DrawRectangle(droneBrush, new Rectangle(zoneX, zoneY, 80, 5));


        }

    }
}
