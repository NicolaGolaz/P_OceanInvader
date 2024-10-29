using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class Projectile
    {
        public Rectangle HitBox = new Rectangle();

        private int projSpeed = 20;
        public void Update()
        {
            projY -= projSpeed;
            HitBox = new Rectangle(projX, projY, 15, 30);

        }
    }
}
