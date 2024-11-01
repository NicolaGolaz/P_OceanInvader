using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class ProjectileBoat
    {
        public Rectangle HitBox = new Rectangle();
        public bool IsDestroyed { get; set; } = false;


        private int projSpeed = 3;
        public void Update()
        {
            projBoatY += projSpeed;
            HitBox = new Rectangle(projBoatX + 20, projBoatY + 50, 30, 40);
        }
    }
}
  