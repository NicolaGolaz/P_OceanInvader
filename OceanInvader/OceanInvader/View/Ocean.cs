using OceanInvader;
using System.Drawing;
using System.Windows.Forms;

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
        public List<Projectile> projectiles;
        public List<AttaqueZone> attaqueZones;
        public List<Obstacle> obstacles;
        private Player player;
        private DateTime lastAttaqueTime = DateTime.MinValue;

        private Image backgroundimage;

        private Label cooldownLabel;



        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;



        // Initialisation de l'espace a�rien avec un certain nombre de drones
        public Ocean(List<Boat> fleet, List<Player> players, List<Projectile> projectiles, List<AttaqueZone> attaqueZones, List<Obstacle> obstacles)
        {
            InitializeComponent();
            this.ClientSize = new Size(WIDTH, HEIGHT);
            // backgroundimage = Image.FromFile(@"..\..\..\Images\Mer.png");

            // Initialisation du label
            cooldownLabel = new Label();
            cooldownLabel.Location = new Point(500, 570); // Ajustez la position selon vos besoins
            cooldownLabel.Size = new Size(200, 20); // Ajustez la taille
            this.Controls.Add(cooldownLabel); // Ajoutez le label au formulaire

           

            this.KeyDown += new KeyEventHandler(OnKeyDown);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.fleet = fleet;
            this.players = players;
            this.projectiles = projectiles;
            this.attaqueZones = attaqueZones;
            this.obstacles = obstacles;

            this.player = players.FirstOrDefault(); // Assigne le premier joueur de la liste � la variable player


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

            foreach (Projectile projectile in projectiles)
            {
                projectile.Render(airspace);
            }
            foreach (AttaqueZone attaqueZone in attaqueZones)
            {
                attaqueZone.Render(airspace);
            }
            foreach(Obstacle obstacle in obstacles)
            { 
                obstacle.Render(airspace); 
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
            foreach (Projectile projectile in projectiles)
            {
                projectile.Update();
            }
            foreach (AttaqueZone attaqueZone in attaqueZones)
            {
                attaqueZone.Update();
            }
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Update();
            }

        }

        // M�thode appel�e � chaque frame
        private void NewFrame(object sender, EventArgs e)
        {


            this.Update(ticker.Interval);
            this.Render();
            
        }

        private void Ocean_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Projectile projectile = new Projectile(player);
                projectiles.Add(projectile);


            }
        }

        private void Ocean_MouseUp(object sender, MouseEventArgs f)
        {
            if (f.Button == MouseButtons.Right)
            {
                double timeSinceLastAttaque = (DateTime.Now - lastAttaqueTime).TotalSeconds;
                if ((DateTime.Now - lastAttaqueTime).TotalSeconds >= 10)
                {
                    AttaqueZone attaqueZone = new AttaqueZone(player);
                    attaqueZones.Add(attaqueZone);
                    lastAttaqueTime = DateTime.Now;
                }
                else
                {

                    double remainingTimeCoolDown = 10 - timeSinceLastAttaque;
                    cooldownLabel.Text = $"Cooldown restant : {remainingTimeCoolDown:F1} secondes";
                }




            }
        }

    }
}