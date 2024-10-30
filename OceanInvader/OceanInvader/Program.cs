using OceanInvader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.CompilerServices;

namespace OceanInvader
{
    internal static class Program
    {
        private static System.Timers.Timer SpawnTimer1;
        private static System.Timers.Timer SpawnTimer2;
        private static readonly object fleetLock = new object();
        public static int niveau = 0;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Afficher le menu principal
            Application.Run(new MainMenu());
        }

        
        public static void StartGame(int difficulty)
        {
            niveau = difficulty;
           
            // Création de la flotte de drones
            List<ProjectileBoat> projectileBoats = new List<ProjectileBoat>();
            List<Boat> fleet = new List<Boat>();
            List<Player> players = new List<Player>();
            
            Player player = new Player(600, 500);
            players.Add(player);
          
            // Configurer les timers selon la difficulté
            int spawnInterval1 = 1000; // Valeur par défaut
            int spawnInterval2 = 1000; // Valeur par défaut

            // Définir les intervalles de spawn selon la difficulté choisie
            switch (difficulty)
            {
                case 1: // Niveau 1
                    spawnInterval1 = 8000;
                    spawnInterval2 = 3000;
                    break;
                case 2: // Niveau 2
                    spawnInterval1 = 7000;
                    spawnInterval2 = 2000;
                    break;
                case 3: // Niveau 3
                    spawnInterval1 = 6000;
                    spawnInterval2 = 1500;
                    break;
            }

            // Initialisation et configuration du Timer pour générer des ennemis
            SpawnTimer1 = new System.Timers.Timer(spawnInterval1);
            SpawnTimer1.Elapsed += (sender, e) =>
            {
                lock (fleetLock)
                {
                    Boat boat = new Boat();
                    boat.x = Random1.RandomX();
                    boat.y = 0;
                    fleet.Add(boat);
                }
            };
            SpawnTimer1.AutoReset = true;
            SpawnTimer1.Enabled = true;

            // Configuration du Timer pour les projectiles
            SpawnTimer2 = new System.Timers.Timer(spawnInterval2);
            SpawnTimer2.Elapsed += (sender, e) =>
            {
                List<Boat> fleetCopy;
                lock (fleetLock)
                {
                    fleetCopy = new List<Boat>(fleet);
                }
                foreach (Boat boat1 in fleetCopy)
                {
                    ProjectileBoat projectileBoat = new ProjectileBoat(boat1);
                    projectileBoats.Add(projectileBoat);
                }
            };
            SpawnTimer2.AutoReset = true;
            SpawnTimer2.Enabled = true;

            List<Projectile> projectiles = new List<Projectile>();
            List<AttaqueZone> attaqueZones = new List<AttaqueZone>();
            List<Obstacle> obstacles = new List<Obstacle>
            {
                new Obstacle(200),
                new Obstacle(800)
            };
            
            // Démarrage du jeu sans une nouvelle Application.Run
            Ocean oceanForm = new Ocean(fleet, players, projectiles, attaqueZones, obstacles, projectileBoats);
            oceanForm.Show(); // Utiliser Show() pour afficher le formulaire           
        }
    }

    public class MainMenu : Form
    {
        // Le menu permettant de choisir entre les différent niveau 
        public MainMenu()
        {
            Text = "Menu Principal";
            Size = new Size(300, 250);
            CenterToScreen();

            // Bouton pour le niveau facile
            Button level1Button = new Button
            {
                Text = "Niveau 1",
                Location = new Point(90, 30),
                Size = new Size(100, 30)
            };
            level1Button.Click += (sender, e) => StartGame(1);

            // Bouton pour le niveau normal
            Button level2Button = new Button
            {
                Text = "Niveau 2",
                Location = new Point(90, 70),
                Size = new Size(100, 30)
            };
            level2Button.Click += (sender, e) => StartGame(2);

            // Bouton pour le niveau difficile
            Button level3Button = new Button
            {
                Text = "Niveau 3",
                Location = new Point(90, 110),
                Size = new Size(100, 30)
            };
            level3Button.Click += (sender, e) => StartGame(3);

            // Bouton pour quitter
            Button exitButton = new Button
            {
                Text = "Quitter",
                Location = new Point(90, 150),
                Size = new Size(100, 30)
            };
            exitButton.Click += (sender, e) => Application.Exit();

            // Ajouter les boutons au Form
            Controls.Add(level1Button);
            Controls.Add(level2Button);
            Controls.Add(level3Button);
            Controls.Add(exitButton);
        }

        private void StartGame(int difficulty)
        {
            Program.StartGame(difficulty);
        }
    }
}
