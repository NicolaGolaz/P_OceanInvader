using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class Projectile
    {

        private int projSpeed = 5;
        public void Update()
        {
            projY -= projSpeed;
            
        }
    }
}
