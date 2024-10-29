using OceanInvader.Helpers;

namespace OceanInvader
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Boat
    {
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);
      

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawRectangle(droneBrush, new Rectangle(x - 4, y - 2, 16, 16));
           
        }

        // De manière textuelle
       

    }
}
