using OceanInvader;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Timers;

namespace OceanInvader
{
    internal static class Program
    {
        private static System.Timers.Timer SpawnTimer1;
        private static System.Timers.Timer SpawnTimer2;
        private static readonly object fleetLock = new object();


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



            // Cr�ation de la flotte de drones
            List<ProjectileBoat> projectileBoats = new List<ProjectileBoat>();
            List<Boat> fleet = new List<Boat>();
            List<Player> players = new List<Player>();
            Player player = new Player(600, 500);
            players.Add(player);



            // **Initialisation et configuration du Timer pour g�n�rer des ennemis de mani�re infinie**
            SpawnTimer1 = new System.Timers.Timer(7000); // Intervalle en millisecondes (6 seconde)
            SpawnTimer1.Elapsed += (sender, e) =>
            {
                lock (fleetLock)  // Verrouille l'acc�s pendant la modification
                {
                    Boat boat = new Boat();
                    boat.x = Random1.RandomX();
                    boat.y = 0;
                    fleet.Add(boat);
                }

            };
            SpawnTimer1.AutoReset = true; // Pour que le Timer se d�clenche de mani�re r�p�t�e
            SpawnTimer1.Enabled = true;   // Activation du Timer

            // **Initialisation et configuration du Timer pour g�n�rer des ennemis de mani�re infinie**
            SpawnTimer2 = new System.Timers.Timer(2000); // Intervalle en millisecondes (2 seconde)
            SpawnTimer2.Elapsed += (sender, e) =>
            {
                List<Boat> fleetCopy;
                lock (fleetLock)  // Verrouille l'acc�s pendant la copie
                {
                    // Cr�e une copie de `fleet` pour �viter les conflits de modification
                    fleetCopy = new List<Boat>(fleet);
                }
                foreach (Boat boat1 in fleetCopy)
                {
                    ProjectileBoat projectileBoat = new ProjectileBoat(boat1);
                    projectileBoats.Add(projectileBoat);
                }
            };
            SpawnTimer2.AutoReset = true; // Pour que le Timer se d�clenche de mani�re r�p�t�e
            SpawnTimer2.Enabled = true;   // Activation du Timer




            List<Projectile> projectiles = new List<Projectile>();

            List<AttaqueZone> attaqueZones = new List<AttaqueZone>();

            List<Obstacle> obstacles = new List<Obstacle>();
            Obstacle obstacle = new Obstacle(200);
            obstacles.Add(obstacle);
            Obstacle obstacle2 = new Obstacle(800);
            obstacles.Add(obstacle2);

            // D�marrage
            Application.Run(new Ocean(fleet, players, projectiles, attaqueZones, obstacles, projectileBoats));


        }
    }
}