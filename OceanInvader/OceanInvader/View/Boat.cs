using OceanInvader.Helpers;

namespace OceanInvader
{
    // Cette partie de la classe Drone définit comment on peut voir un drone

    public partial class Boat
    {
       
        Image boatImg = Image.FromFile(@"..\..\..\Images\Boat.png");


        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(boatImg, new Rectangle(x, y, 70, 100));                    
        }

        // De manière textuelle
       

    }
}
