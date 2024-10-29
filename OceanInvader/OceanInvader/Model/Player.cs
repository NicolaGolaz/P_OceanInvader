using System;
using System.Windows.Forms;

namespace OceanInvader
{
    public partial class Player
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        private int speed;
      
        public Player(int x, int y)
        {
            X = x;
            Y = y;


        }

        // Méthode pour déplacer le joueur en fonction de l'entrée du clavier
        public void Move(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) // Haut
            {

                if (playerY > 300)
                {

                    Y -= 10;
                    playerY -= 10;
                }
                else
                {
                    Y -= 0;
                }


            }
            if (e.KeyCode == Keys.S) // Bas
            {
                if (playerY < 480)
                {
                    Y += 10;
                    playerY += 10;
                }
                else
                {
                    playerY += 0;
                }
            }
            if (e.KeyCode == Keys.A) // Gauche
            {
                if (playerX > 0)
                {
                    X -= 10;
                    playerX -= 10;
                }
                else
                {
                    X -= 0;
                }
            }
            if (e.KeyCode == Keys.D) // Droite
            {
                if (playerX < 1180)
                {
                    X += 10;
                    playerX += 10;
                }
                else
                {
                    playerX += 0;
                }
            }
        }



    }
}
