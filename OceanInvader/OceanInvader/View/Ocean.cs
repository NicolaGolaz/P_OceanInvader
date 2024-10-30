using OceanInvader;
using System.Drawing;
using System.Windows.Forms;

namespace OceanInvader
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class Ocean : Form
    {
        public static readonly int WIDTH = 1200;        // Dimensions of the airspace
        public static readonly int HEIGHT = 600;

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private List<Boat> fleet;
        private List<Player> players;
        public List<Projectile> projectiles;
        public List<AttaqueZone> attaqueZones;
        public List<Obstacle> obstacles;
        public List<ProjectileBoat> projectileBoats;
        private Player player;
        private DateTime lastAttaqueTime = DateTime.MinValue;
        private bool isGameOver = false;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Pink), 3);



        private Image backgroundimage;

        private Label cooldownLabel;
        private Label gameOverLabel;



        Image backgroundImage = Image.FromFile(@"..\..\..\Images\Ocean.png");

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;



        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Ocean(List<Boat> fleet, List<Player> players, List<Projectile> projectiles, List<AttaqueZone> attaqueZones, List<Obstacle> obstacles, List<ProjectileBoat> projectileBoats)
        {
            InitializeComponent();
            this.ClientSize = new Size(WIDTH, HEIGHT);


            // backgroundimage = Image.FromFile(@"..\..\..\Images\Mer.jpg");

            // Initialisation du label
            cooldownLabel = new Label();
            cooldownLabel.Location = new Point(500, 570); // Ajustement de la position 
            cooldownLabel.Size = new Size(200, 20); // Ajustement de la taille
            this.Controls.Add(cooldownLabel); // Ajoute le label au formulaire

            // Initialisation du label
            gameOverLabel = new Label();
            gameOverLabel.Text = "Game Over";
            gameOverLabel.Font = new Font("Arial", 20, FontStyle.Bold); // Police grande et en gras
            gameOverLabel.ForeColor = Color.Red; // Texte en rouge
            gameOverLabel.BackColor = Color.Black; // Fond noir
            gameOverLabel.TextAlign = ContentAlignment.MiddleCenter; // Centrer le texte
            gameOverLabel.AutoSize = false; // Permet de définir une taille précise pour le label
            gameOverLabel.Location = new Point((WIDTH/2)-200, (HEIGHT/2)-50); // Ajustement de la position
            gameOverLabel.Size = new Size(400, 100); // Ajustement de la taille

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
            

            this.player = players.FirstOrDefault(); // Assigne le premier joueur de la liste à la variable player


            this.DoubleBuffered = true; // Pour éviter le scintillement lors du rendu
            this.projectileBoats = projectileBoats;
        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            foreach (Player player in players)
            {
                player.Move(e);  // Appel de la méthode Move du Player
            }
        }



        // Affichage de la situation actuelle
        private void Render()
        {

            airspace.Graphics.DrawImage(backgroundImage, new Rectangle(0, 0, WIDTH, HEIGHT));
            airspace.Graphics.DrawRectangle(droneBrush,new Rectangle(0 , 410, 1200, 1200)); // Dessine l'HitBox



            // draw drones
            foreach (Boat boat in new List<Boat>(fleet))
            {
                boat.Render(airspace);
            }

            foreach (Player player in players)
            {
                player.Render(airspace);
                if (player.playerHp == 0)
                {
                    isGameOver = true;
                    this.Controls.Add(gameOverLabel); // Ajoutez le label au formulaire
                    
                }
            }

            foreach (Projectile projectile in projectiles)
            {
                projectile.Render(airspace);
            }
            foreach (AttaqueZone attaqueZone in attaqueZones)
            {
                attaqueZone.Render(airspace);
            }
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Render(airspace);
            }
            foreach(ProjectileBoat projectileBoat in new List<ProjectileBoat>(projectileBoats))
            {
                projectileBoat.Render(airspace);
                foreach (Player player in players)
                {
                    if (projectileBoat.HitBox.IntersectsWith(player.HitBox))
                    {
                        player.playerHp -= 1;
                        projectileBoat.IsDestroyed = true;
                    }
                   
                }
            }
            projectileBoats.RemoveAll(b => b.IsDestroyed);

            if (isGameOver == true)
            {
                return;
            }

            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.Update();
            }
            foreach (Boat boat in fleet)
            {
                
                boat.Update(interval);
                foreach (Projectile projectile in projectiles)
                {
                    if (boat.HitBox.IntersectsWith(projectile.HitBox))
                    {
                        boat.IsDestroyed = true;
                        projectile.IsDestroyed = true;
                    }
                }
            }
            fleet.RemoveAll(b => b.IsDestroyed);
            projectiles.RemoveAll(b => b.IsDestroyed);

            foreach (AttaqueZone attaqueZone in attaqueZones)
            {
                attaqueZone.Update();
            }
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Update();
                foreach (ProjectileBoat projectileBoat in projectileBoats)
                {
                    if (obstacle.HitBox.IntersectsWith(projectileBoat.HitBox))
                    {
                        projectileBoat.IsDestroyed = true;
                    }
                }
                foreach (Projectile projectile in projectiles)
                {
                    if (obstacle.HitBox.IntersectsWith(projectile.HitBox))
                    {
                        projectile.IsDestroyed = true;
                    }
                }
            }
            projectiles.RemoveAll(b => b.IsDestroyed);
            projectileBoats.RemoveAll(b => b.IsDestroyed);
            foreach(ProjectileBoat projectileBoat in projectileBoats)
            {
                projectileBoat.Update();
            }
            if (isGameOver == true)
            {
                return;
            }

        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }

        private void Ocean_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double timeSinceLastAttaque1 = (DateTime.Now - lastAttaqueTime).TotalSeconds;
                if ((DateTime.Now - lastAttaqueTime).TotalSeconds >= 0.5)
                {
                    Projectile projectile = new Projectile(player);
                    projectiles.Add(projectile);
                    lastAttaqueTime = DateTime.Now;
                }
                else
                {
                    double remainingTimeCoolDown = 10 - timeSinceLastAttaque1;
                }
            }
        }

        private void Ocean_MouseUp(object sender, MouseEventArgs f)
        {
            if (f.Button == MouseButtons.Right)
            {
                double timeSinceLastAttaque2 = (DateTime.Now - lastAttaqueTime).TotalSeconds;
                if ((DateTime.Now - lastAttaqueTime).TotalSeconds >= 10)
                {
                    AttaqueZone attaqueZone = new AttaqueZone(player);
                    attaqueZones.Add(attaqueZone);
                    lastAttaqueTime = DateTime.Now;
                }
                else
                {
                    double remainingTimeCoolDown = 10 - timeSinceLastAttaque2;
                    cooldownLabel.Text = $"Cooldown restant : {remainingTimeCoolDown:F1} secondes";
                }
            }
        }      
    }
}