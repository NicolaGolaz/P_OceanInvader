using OceanInvader;
using System.Drawing.Imaging;

namespace OceanInvader
{
    internal static class Program
    {
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
            List<Boat> fleet = new List<Boat>();
            List<Player> players = new List<Player>();
            Player player = new Player(600, 500);
            players.Add(player);

            

                Boat boat = new Boat();
                boat.x = Random1.RandomX();
                boat.y = 0;
                boat.name = "Joe";
                fleet.Add(boat);

            List<Projectile> projectiles = new List<Projectile>();


                

                // D�marrage
                Application.Run(new Ocean(fleet, players, projectiles));
            

        }
    }
}