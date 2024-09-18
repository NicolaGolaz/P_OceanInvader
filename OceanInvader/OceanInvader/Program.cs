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

            // Création de la flotte de drones
            List<Boat> fleet = new List<Boat>();
            Boat boat = new Boat();
            boat.x = 350;
            boat.y = 0;
            boat.name = "Joe";
            fleet.Add(boat);


            boat = new Boat();
            boat.x = 150;
            boat.y = 0;
            boat.name = "jack";
            fleet.Add(boat);

            List<Player> players = new List<Player>();
            Player player = new Player(600, 400);


            players.Add(player);

            // Démarrage
            Application.Run(new Ocean(fleet, players));

        }
    }
}