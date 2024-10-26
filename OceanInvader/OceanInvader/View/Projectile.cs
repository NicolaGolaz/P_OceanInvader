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
        private Image projectileImg = Image.FromFile(@"..\..\..\Images\Projectile.png");
        public Rectangle HitBox { get; set; }

        public Projectile(Player player)
        {
            this.player = player;
            this.projX = player.X;
            this.projY = player.Y;
            HitBox = new Rectangle(projX, projY, 10, 20);
        }


        private Pen droneBrush = new Pen(new SolidBrush(Color.Green), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(projectileImg, new Rectangle(projX, projY, 10, 20));
        }
    }
}
