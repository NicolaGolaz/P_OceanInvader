using OceanInvader.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OceanInvader
{
    public partial class Player
    {

        private int playerX = 600; // Position initiale du bateau en X
        private int playerY = 400; // Position initiale du bateau en Y
        private int playerWidth = 30; // Largeur du bateau
        private int playerHeight = 30; // Hauteur du bateau

        private Pen droneBrush = new Pen(new SolidBrush(Color.Red), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawRectangle(droneBrush, new Rectangle(X , Y, playerHeight, playerWidth));
            
        }

       
    }
}
