using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class AttaqueZone
    {
        private int ZoneSpeed = 8;
        private const int COOLDOWN = 10;
        public Rectangle HitBox = new Rectangle();
        public static DateTime lastAttaqueTime2 = DateTime.MinValue;
        public static double remainingTimeCoolDown;

        public void Update()
        {         
                
            zoneY -= ZoneSpeed;
        }

        public static bool CoolDown()
        {  
            double timeSinceLastAttaque2 = (DateTime.Now - lastAttaqueTime2).TotalSeconds;
            if (timeSinceLastAttaque2 >= COOLDOWN-1)
            {
                remainingTimeCoolDown = 0;
                return true;
            }
            else if (timeSinceLastAttaque2 < COOLDOWN)
            {
                double remainingTimeCoolDownMethode = COOLDOWN - timeSinceLastAttaque2;
                remainingTimeCoolDown = remainingTimeCoolDownMethode;           
                return false;
            }          
            else return false;
        }
    }
}
