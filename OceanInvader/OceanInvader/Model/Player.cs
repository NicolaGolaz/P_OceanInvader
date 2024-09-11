using System;
using System.Windows.Forms;

namespace BoatMovement
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; }
        public int Height { get; }
        private int speed;

        public Player(int x, int y, int width, int height, int speed)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            this.speed = speed;
        }

        public void Move(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) // Haut
            {
                Y -= speed;
            }
            if (e.KeyCode == Keys.S) // Bas
            {
                Y += speed;
            }
            if (e.KeyCode == Keys.A) // Gauche
            {
                X -= speed;
            }
            if (e.KeyCode == Keys.D) // Droite
            {
                X += speed;
            }
        }
    }
}
