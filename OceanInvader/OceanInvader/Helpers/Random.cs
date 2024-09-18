using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public static class Random1
    {
        static Random random = new Random();

        public static int RandomX()
        {
            int randomInt = random.Next(0, 1180);
            return randomInt;
        }
        public static int RandomY()
        {
            int randomInt = random.Next(0, 1180);
            return randomInt;
        }


    }
}
