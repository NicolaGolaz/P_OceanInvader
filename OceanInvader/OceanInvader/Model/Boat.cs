using Microsoft.VisualBasic.Devices;

namespace OceanInvader
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Boat
    {
        Random alea = new Random();
        public Rectangle HitBox = new Rectangle();
        public bool IsDestroyed { get; set; } = false;


        public int x;                                // Position en X depuis la gauche de l'espace aérien
        public int y;                                 // Position en Y depuis le haut de l'espace aérien


        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées

        public void Update(int interval)
        {
            HitBox = new Rectangle(x , y , 50, 70);


            if (y < 580 && x > 0 && x < 1180)
            {
                y += 1;                                    // Il s'est déplacé de 2 pixels vers la droite
              //  x += alea.Next(-10, 10);                     // Il s'est déplacé d'une valeur aléatoire vers le haut ou le bas
                
            }
            else if (x < 0)
            {
                y += 1;                                    // Il s'est déplacé de 2 pixels vers la droite
              //  x += 20;                     // Il s'est déplacé d'une valeur aléatoire vers le haut ou le bas
                
            }
            else if (x < 0)
            {
                y += 1;                                    // Il s'est déplacé de 2 pixels vers la droite
              //  x += 20;                     // Il s'est déplacé d'une valeur aléatoire vers le haut ou le bas
               
            }
            else if (x > 1180)
            {
                y += 1;                                    // Il s'est déplacé de 2 pixels vers la droite
               // x -= 20;                     // Il s'est déplacé d'une valeur aléatoire vers le haut ou le bas
                
            }
            else if (y > 580)
            {
                return;
            }

        }

    }
}
