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
        public int projBoatX;
        public int projBoatY;
        private Image projectileBoatImg = Image.FromFile(@"..\..\..\Images\projectileBoat.png");


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
            drawingSpace.Graphics.DrawImage(projectileBoatImg, new Rectangle(projBoatX + 20, projBoatY + 50, 30, 40));

        }
    }
}
