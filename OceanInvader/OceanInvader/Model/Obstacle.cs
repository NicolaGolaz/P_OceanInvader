using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class Obstacle
    {
        private int objX = 200;
        private int objY = 300;

        public void Update()
        {
            if (objX > 0)
            {
                objX -= 3;
            }
            if (objX == 1 || objX > 1)
            {
                objX += 2;
            }
        }

    }
}
