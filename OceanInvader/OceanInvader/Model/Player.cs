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
                Y -= 5;
            }
            if (e.KeyCode == Keys.S) // Bas
            {
                Y += 5;
            }
            if (e.KeyCode == Keys.A) // Gauche
            {
                X -= 5;
            }
            if (e.KeyCode == Keys.D) // Droite
            {
                X += 5;
            }
        }



    }
}
