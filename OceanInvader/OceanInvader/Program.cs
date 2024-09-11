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
            List<Boat> fleet= new List<Boat>();
            Boat drone = new Boat();
            drone.x = 150;
            drone.y = 150;
            drone.name = "Joe";
            fleet.Add(drone);

            drone = new Boat();
            drone.x = 250;
            drone.y = 250;
            drone.name = "Joe2";
            fleet.Add(drone);

            // Démarrage
            Application.Run(new Ocean(fleet));
        }
    }
}