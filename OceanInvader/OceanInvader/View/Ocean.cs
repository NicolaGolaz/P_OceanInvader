using OceanInvader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;

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
        private DateTime lastAttaqueTime1 = DateTime.MinValue;
       
        public double remainingTimeCoolDown = 0;

        private bool isGameOver = false;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Pink), 3);
        private int playerScore = 0;



        private Image backgroundimage;

        private Label cooldownLabel;
        private Label gameOverLabel;
        private Label scoreLabel;



        Image backgroundImage = Image.FromFile(@"..\..\..\Images\Ocean.png");

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;



        // Initialisation de l'espace aérien avec un certain nombre de drones
        public Ocean(List<Boat> fleet, List<Player> players, List<Projectile> projectiles, List<AttaqueZone> attaqueZones, List<Obstacle> obstacles, List<ProjectileBoat> projectileBoats)
        {
            InitializeComponent();
            this.ClientSize = new Size(WIDTH, HEIGHT);
            CenterToScreen();

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
            gameOverLabel.Location = new Point((WIDTH / 2) - 200, (HEIGHT / 2) - 50); // Ajustement de la position
            gameOverLabel.Size = new Size(400, 100); // Ajustement de la taille

            // Initialisation du label
            scoreLabel = new Label();
            scoreLabel.Location = new Point(5, 5);
            scoreLabel.Size = new Size(80, 17);
            scoreLabel.Text = "Score : " + playerScore;
            scoreLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            scoreLabel.ForeColor = Color.Black;
            scoreLabel.BackColor = Color.LightGoldenrodYellow;
            scoreLabel.TextAlign = ContentAlignment.TopCenter;
            this.Controls.Add(scoreLabel);

            // Bouton pour quitter le niveau et revenir au menu principal
            Button exitButton = new Button();  // Création d'un nouveau bouton
            exitButton.Text = "Quitter";        // Texte du bouton
            exitButton.Location = new Point(WIDTH - 100, 10); // Position du bouton en haut à droite
            exitButton.Size = new Size(80, 30); // Taille du bouton
            exitButton.TabStop = false; // Permet au bouton de ne pas recevoir le focus de la touche tab
            exitButton.Click += (sender, e) =>
            {
                this.Close(); // Ferme le niveau en cours d'éxécution
            };
            this.Controls.Add(exitButton); // **Ajout du bouton au formulaire**

            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);  // <-- Modifié ici

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

        // Méthode pour gérer les touches appuyer 
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            foreach (Player player in players)
            {
                    player.OnKeyDown(e);  // Appel de la méthode Move du Player
                
            }
        }

        // Méthode pour gérer les touches relâchées
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            foreach (Player player in players)
            {
                player.OnKeyUp(e); 
            }
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            // Initialisation du background
            airspace.Graphics.DrawImage(backgroundImage, new Rectangle(0, 0, WIDTH, HEIGHT));
            // Dessine la zone de mouvement du joueur
            airspace.Graphics.DrawRectangle(droneBrush, new Rectangle(0, 410, 1200, 1200)); 

            // draw drones
            foreach (Boat boat in new List<Boat>(fleet))
            {
                boat.Render(airspace);
            }

            foreach (Player player in players)
            {
                player.Render(airspace);
                if (player.PlayerHp == 0)
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
                foreach (Boat boat in fleet)
                {
                    if (boat.HitBox.IntersectsWith(attaqueZone.HitBox))
                    {
                        boat.IsDestroyed = true;
                    }
                }
                attaqueZone.Render(airspace);
            }
            attaqueZones.RemoveAll(b => b.IsDestroyed); // Déstruction des projectiles 
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Render(airspace);
            }
            foreach (ProjectileBoat projectileBoat in new List<ProjectileBoat>(projectileBoats))
            {
                projectileBoat.Render(airspace);
                if (projectileBoat.projBoatY > 600)
                {
                    projectileBoat.IsDestroyed = true;
                }

                foreach (Player player in players)
                {
                    // Condition pour voir si le projectile doit être détruit 
                    if (projectileBoat.HitBox.IntersectsWith(player.HitBox))
                    {                                                 
                        player.TakeDamage(Program.niveau);                                                                                       
                        projectileBoat.IsDestroyed = true; 
                    }
                }
            }
            projectileBoats.RemoveAll(b => b.IsDestroyed); // Déstruction des projectiles 

            if (isGameOver == true)
            {
                return;
            }
            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (Player player in players)
            {
                player.UpdateMovement(); // Met a jour la position du joueur
            }

            foreach (Projectile projectile in projectiles)
            {
                projectile.Update();
            }
            foreach (Boat boat in fleet)
            {
                if (boat.y > 340)
                {
                    isGameOver = true;
                    this.Controls.Add(gameOverLabel); // Ajoutez le label au formulaire
                }
                boat.Update(interval);
                foreach (Projectile projectile in projectiles)
                {
                    if (boat.HitBox.IntersectsWith(projectile.HitBox))
                    {
                        foreach (Player player in players)
                        {
                            if (Program.niveau == 2)
                            {
                                player.Heal(1);
                            }
                            else if (Program.niveau == 3)
                            {
                                player.Heal(2);
                            }
                        }
                        playerScore += 1;
                        scoreLabel.Text = "Score : " + playerScore;
                        this.Controls.Add(scoreLabel);
                        boat.IsDestroyed = true;
                        projectile.IsDestroyed = true;
                    }
                }
            }
            fleet.RemoveAll(b => b.IsDestroyed);
            projectiles.RemoveAll(b => b.IsDestroyed);
            
            cooldownLabel.Text = "Cooldown restant : " + Math.Floor(AttaqueZone.remainingTimeCoolDown) + " secondes";
            foreach (AttaqueZone attaqueZone in attaqueZones)
            {
                attaqueZone.Update();
                AttaqueZone.CoolDown();
                cooldownLabel.Text = "Cooldown restant : "+ Math.Floor(AttaqueZone.remainingTimeCoolDown) +" secondes";
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
            foreach (ProjectileBoat projectileBoat in projectileBoats)
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

        /// <summary>
        /// Description : 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ocean_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double timeSinceLastAttaque1 = (DateTime.Now - lastAttaqueTime1).TotalSeconds;
                if ((DateTime.Now - lastAttaqueTime1).TotalSeconds >= 0.5)
                {
                    Projectile projectile = new Projectile(player);
                    projectiles.Add(projectile);
                    lastAttaqueTime1 = DateTime.Now;
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
                
               
                    AttaqueZone attaqueZone = new AttaqueZone(player);
                    attaqueZones.Add(attaqueZone);
                    AttaqueZone.lastAttaqueTime2 = DateTime.Now;
                
               
            }
        }
    }
}