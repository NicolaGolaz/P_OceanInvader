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
        
        public void Update()
        {
            zoneY -= ZoneSpeed;
        }
    }
}
