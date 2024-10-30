using System;
using System.Windows.Forms;

namespace OceanInvader
{
    public partial class Player
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        private int playerHp;
        public int PlayerHp { get { return playerHp; } private set { playerHp = value; } }
        private int playerSpeed = 8;

        public Player(int x, int y)
        {
           
            X = x;
            Y = y;
            PlayerHp = 10;
           
        }

        // Méthode pour déplacer le joueur en fonction de l'entrée du clavier
        public void Move(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) // Haut
            {

                if (playerY > 300)
                {

                    Y -= playerSpeed;
                    playerY -= playerSpeed;
                }
                else
                {
                    Y -= 0;
                }


            }
            if (e.KeyCode == Keys.S) // Bas
            {
                if (playerY < 410)
                {
                    Y += playerSpeed;
                    playerY += playerSpeed;
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
                    X -= playerSpeed;
                    playerX -= playerSpeed;
                }
                else
                {
                    X -= 0;
                }
            }
            if (e.KeyCode == Keys.D) // Droite
            {
                if (playerX < 1140)
                {
                    X += playerSpeed;
                    playerX += playerSpeed;
                }
                else
                {
                    playerX += 0;
                }
            }
        }
        public void TakeDamage(int value)
        {         
            playerHp -= value;
        }
        public void Heal(int value)
        {
            if (playerHp + value > 10)
            {
                playerHp = 10;
            }
            else
            {
                playerHp += value;
            }
        }
    }
}
