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
        private int playerWidth = 70; // Largeur du bateau
        private int playerHeight = 100; // Hauteur du bateau
        public Rectangle HitBox = new Rectangle();
       

        private Pen hitBoxBrush = new Pen(new SolidBrush(Color.Red), 3);

        Image playerImg = Image.FromFile(@"..\..\..\Images\Player.png");

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            HitBox = new Rectangle(X+18, Y+8, 30, 70);
            drawingSpace.Graphics.DrawImage(playerImg, new Rectangle(X, Y, playerWidth, playerHeight));
          // drawingSpace.Graphics.DrawRectangle(hitBoxBrush,new Rectangle(X + 18, Y+8, 30, 70)); // Dessine l'HitBox
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Brush brush = Brushes.White;          
            Point hpPosition = new Point(X, Y - 20);            
            drawingSpace.Graphics.DrawString($"HP: {playerHp}", font, brush, hpPosition);
        }
    }
}
