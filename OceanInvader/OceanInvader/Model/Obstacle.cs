using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanInvader
{
    public partial class Obstacle
    {
        public int objX = 200;
        public int objY = 300;
        private DateTime timerObject = DateTime.MinValue;
       

        public Rectangle HitBox = new Rectangle();



        public Obstacle(int ObjX)
        {
            this.objX = ObjX;          
        }



        public void Update()
        {
            HitBox = new Rectangle(objX , objY , 120, 5);


        }

    }
}
