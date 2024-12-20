﻿namespace OceanInvader
{
    partial class Ocean
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ocean));
            ticker = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // ticker
            // 
            ticker.Enabled = true;
            ticker.Tick += NewFrame;
            ticker.Interval = 1;
            // 
            // Ocean
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(479, 163);
            Name = "Ocean";
            Text = "AirSpace";           
            MouseClick += Ocean_MouseUp;
            MouseDown += Ocean_MouseDown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer ticker;
    }
}