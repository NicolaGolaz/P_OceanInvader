﻿using OceanInvader.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OceanInvader
{
    public partial class Player
    {

        private int playerX = 600; // Position initiale du bateau en X
        private int playerY = 400; // Position initiale du bateau en Y
        private int playerWidth = 60; // Largeur du bateau
        private int playerHeight = 60; // Hauteur du bateau
        public Rectangle HitBox = new Rectangle();

        private Pen droneBrush = new Pen(new SolidBrush(Color.Red), 3);

        private Image playerImage; // Image du joueur

        Image boatImg = Image.FromFile(@"..\..\..\Images\Vaisseau.png");

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            HitBox = new Rectangle(X, Y, 60, 60);
            drawingSpace.Graphics.DrawImage(boatImg, new Rectangle(X, Y, playerWidth, playerHeight));
        }
    }
}
