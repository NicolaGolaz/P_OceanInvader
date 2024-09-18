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
            List<Player> players = new List<Player>();
            Player player = new Player(600, 500);
            players.Add(player);

            for (int i = 0; i < 10; i++)
            {

                Boat boat = new Boat();
                boat.x = Random1.RandomX();
                boat.y = 0;
                boat.name = "Joe";
                fleet.Add(boat);

            }



                

                // Démarrage
                Application.Run(new Ocean(fleet, players));
            

        }
    }
}