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
        public bool IsDestroyed { get; set; } = false;

        private int projSpeed = 8;
        public void Update()
        {
            projY -= projSpeed;
            HitBox = new Rectangle(projX , projY+10, 15, 20);

        }
    }
}
