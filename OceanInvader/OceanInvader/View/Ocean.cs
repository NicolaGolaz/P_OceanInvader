using OceanInvader;

namespace OceanInvader
{
    // La classe AirSpace repr�sente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fen�tre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class Ocean : Form
    {
        public static readonly int WIDTH = 1200;        // Dimensions of the airspace
        public static readonly int HEIGHT = 600;

        // La flotte est l'ensemble des drones qui �voluent dans notre espace a�rien
        private List<Boat> fleet;
        private List<Player> players;

        

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        
        // Initialisation de l'espace a�rien avec un certain nombre de drones
        public Ocean(List<Boat> fleet, List<Player> players)
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(OnKeyDown);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.fleet = fleet;
            this.players = players;


            this.DoubleBuffered = true; // Pour �viter le scintillement lors du rendu


        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            foreach (Player player in players)
            {
                player.Move(e);  // Appel de la m�thode Move du Player
            }
        }



        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.AliceBlue);

            // draw drones
            foreach (Boat boat in fleet)
            {
                boat.Render(airspace);
            }

            foreach (Player player in players)
            {
                player.Render(airspace);
            }


            airspace.Render();
        }

        // Calcul du nouvel �tat apr�s que 'interval' millisecondes se sont �coul�es
        private void Update(int interval)
        {
            foreach (Boat boat in fleet)
            {
                boat.Update(interval);
            }

            

        }

        // M�thode appel�e � chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
  
            this.Update(ticker.Interval);
            this.Render();
            
        }
        
    }
}