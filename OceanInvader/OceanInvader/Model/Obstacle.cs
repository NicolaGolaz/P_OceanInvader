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
        private DateTime timerObject = DateTime.MinValue;
        int i = 0;

        public void Update()
        {
            
            i++;
            if ((DateTime.Now - timerObject).TotalSeconds < 5)
            {              
                if (i % 2 == 0 || i%4==0)
                {
                    objX -= 2;
                    objX -= 3;

                }


                else
                {
                    objX += 2;
                    objX += 3;
                }
            }
           

                timerObject = DateTime.Now;
        }

    }
}
