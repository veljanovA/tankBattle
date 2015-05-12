﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TankTrouble
{
    public enum Direction { Up, Down, Left, Right }
    public enum TankColor { Green, Red }

    public partial class Form1 : Form
    {
  
        
        Scene scene;
        bool drawScene;
       
        Rectangle playGame;
        Rectangle aboutUs;
        Rectangle howToPlay;
        Rectangle quitGame;
        bool canPress;
        bool drawGameBtn, drawAboutBtn, drawHowToBtn, drawQuitBtn;
        Timer t;
        SoundPlayer menuMusic;
       
        public Form1()
        {
            
           
      
            load();
        }

        public void load()
        {
            InitializeComponent();
           
            DoubleBuffered = true;
            scene = new Scene();
            this.Height = Scene.FIELD_HEIGHT + 2 * Scene.frame_HEIGHT;
            this.Width = Scene.FIELD_WIDTH + 2 * Scene.frame_width + Scene.sidePanel;
              labelPlayer1.Location = new Point(Scene.FIELD_WIDTH + 2 * Scene.frame_width, 200);
            labelPlayer2.Location = new Point(Scene.FIELD_WIDTH + 2 * Scene.frame_width, Scene.FIELD_HEIGHT - 100);
            drawScene = false;
            scene.Game();
             t = new Timer();
            t.Tick += new EventHandler(timer_tick);
            t.Interval = 25;
            t.Start();

            //Menu buttons

            playGame = new Rectangle(980, 100, 222, 55);
            aboutUs = new Rectangle(980, 254, 222, 55);
            howToPlay = new Rectangle(980, 177, 222, 55);
            quitGame = new Rectangle(980, 331, 222, 55);

            menuMusic = new SoundPlayer(global::TankTrouble.Properties.Resources.warMusic2);
            menuMusic.PlayLooping();

        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if(canPress)
            scene.keyDown(sender, e);    
            Invalidate();
                
              
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(canPress)
            scene.keyPressed(sender, e);
            Invalidate();
        }
        
       
        // tick of main timer , starts with game
        public void timer_tick(object sender, EventArgs e)
        {
            if (scene.timerTick())
            {
                t.Stop();
                while (Controls.Count > 0)
                {
                    Controls[0].Dispose();
                }
              
                load();
            }
            else Invalidate();
        }


       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
           
            graphics.FillRectangle(Brushes.Transparent, playGame);
            graphics.FillRectangle(Brushes.Transparent, howToPlay);
            graphics.FillRectangle(Brushes.Transparent, aboutUs);
            graphics.FillRectangle(Brushes.Transparent, quitGame);

            Pen p = new Pen(Color.Lime, 4);

            if (drawGameBtn)
                graphics.DrawRectangle(p, playGame);
            else if (drawAboutBtn)
                graphics.DrawRectangle(p, aboutUs);
            else if (drawHowToBtn)
                graphics.DrawRectangle(p, howToPlay);
            else if (drawQuitBtn)
                graphics.DrawRectangle(p, quitGame);
            
            if (drawScene)
            {
              
                scene.Draw(graphics);
               
            }
            p.Dispose();
            labelPlayer1.Text = "Blue Tank "+scene.countPlayer1.ToString();
            labelPlayer2.Text = "Red Tank "+scene.countPlayer2.ToString();
        }

       

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            scene.keyUp(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Play game
            if (e.Location.X > playGame.Left && e.Location.X < playGame.Right && e.Location.Y > playGame.Top && e.Location.Y < playGame.Bottom)
            {
                drawScene = true;
                canPress = true;
                labelPlayer1.Visible = true;
                labelPlayer2.Visible = true;
                menuMusic.Stop();
            }
               

            //How to play
            if (e.Location.X > aboutUs.Left && e.Location.X < aboutUs.Right && e.Location.Y > aboutUs.Top && e.Location.Y < aboutUs.Bottom)
            {
                MessageBox.Show(string.Format("Проект по Визуелно Програмирање\n\n\nИзработиле:\n\nИгнатиј Гичевски\nАлександар Велјанов\nАлександар Богданоски"), "About Us");
            }

            //About us
            if (e.Location.X > howToPlay.Left && e.Location.X < howToPlay.Right && e.Location.Y > howToPlay.Top && e.Location.Y < howToPlay.Bottom)
            {
                Form2 f = new Form2();
                f.Show();
            }

            //Quit game
            if (e.Location.X > quitGame.Left && e.Location.X < quitGame.Right && e.Location.Y > quitGame.Top && e.Location.Y < quitGame.Bottom)
                this.Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Play game
            if (e.Location.X > playGame.Left && e.Location.X < playGame.Right && e.Location.Y > playGame.Top && e.Location.Y < playGame.Bottom)
                drawGameBtn = true;
            else
                drawGameBtn = false;

            //How to play
            if (e.Location.X > aboutUs.Left && e.Location.X < aboutUs.Right && e.Location.Y > aboutUs.Top && e.Location.Y < aboutUs.Bottom)
            {
                drawAboutBtn = true;
            }
            else
                drawAboutBtn = false;

            //About us
            if (e.Location.X > howToPlay.Left && e.Location.X < howToPlay.Right && e.Location.Y > howToPlay.Top && e.Location.Y < howToPlay.Bottom)
            {
                drawHowToBtn = true;
            }
            else
                drawHowToBtn = false;

            //Quit game
            if (e.Location.X > quitGame.Left && e.Location.X < quitGame.Right && e.Location.Y > quitGame.Top && e.Location.Y < quitGame.Bottom)
                drawQuitBtn = true;
            else
                drawQuitBtn = false;
        }

        
    }
}
