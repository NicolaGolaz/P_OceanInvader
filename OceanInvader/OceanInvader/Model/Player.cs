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
        private int playerSpeed = 6;

        private bool movingUp = false;    
        private bool movingDown = false;   
        private bool movingLeft = false;   
        private bool movingRight = false;  

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            PlayerHp = 10;
        }

        // Méthode pour mettre à jour l'état des déplacements
        public void UpdateMovement()
        {
            // Déplacement vers le haut
            if (movingUp && Y > 400)  
            {
                Y -= playerSpeed;
            }

            // Déplacement vers le bas
            if (movingDown && Y < 510) 
            {
                Y += playerSpeed;
            }

            // Déplacement vers la gauche
            if (movingLeft && X > 0)   
            {
                X -= playerSpeed;
            }

            // Déplacement vers la droite
            if (movingRight && X < 1140) 
            {
                X += playerSpeed;
            }
        }

        // Méthode pour gérer l'appui sur une touche
        public void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) // Haut
            {
                movingUp = true;  
            }
            if (e.KeyCode == Keys.S) // Bas
            {
                movingDown = true; 
            }
            if (e.KeyCode == Keys.A) // Gauche
            {
                movingLeft = true; 
            }
            if (e.KeyCode == Keys.D) // Droite
            {
                movingRight = true; 
            }
        }

        // Méthode pour gérer le relâchement d'une touche
        public void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) // Haut
            {
                movingUp = false;  
            }
            if (e.KeyCode == Keys.S) // Bas
            {
                movingDown = false; 
            }
            if (e.KeyCode == Keys.A) // Gauche
            {
                movingLeft = false; 
            }
            if (e.KeyCode == Keys.D) // Droite
            {
                movingRight = false; 
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
