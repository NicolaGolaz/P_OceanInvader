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
      

        public Projectile(Player player)
        {
            this.player = player;
            this.projX = player.X+14;
            this.projY = player.Y;
           
        }

        
        private Pen droneBrush = new Pen(new SolidBrush(Color.Green), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(projectileImg, new Rectangle(projX, projY, 15, 30));
           
        }
    }
}
