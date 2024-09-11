using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OceanInvader.View
{
    internal class Player
    {

        private int boatX = 100; // Position initiale du bateau en X
        private int boatY = 100; // Position initiale du bateau en Y
        private int boatWidth = 50; // Largeur du bateau
        private int boatHeight = 30; // Hauteur du bateau
        public void Render(Graphics g)
        {
            
            Brush boatBrush = Brushes.Blue;
            g.FillRectangle(boatBrush, boatX, boatY, boatWidth, boatHeight);
        }
    }
}
