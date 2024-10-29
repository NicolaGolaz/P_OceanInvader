using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class ProjectileBoat
    {
        private Boat boat;
        private int projBoatX;
        private int projBoatY;
        private Image projectileBoatImg = Image.FromFile(@"..\..\..\Images\Projectile.png");


        public ProjectileBoat(Boat boat)
        {
            this.boat = boat;
            this.projBoatX = boat.x;
            this.projBoatY = boat.y;

        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Green), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(projectileBoatImg, new Rectangle(projBoatX, projBoatY, 10, 20));

        }
    }
}
