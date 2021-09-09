using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird_N_
{
    public partial class Game : Form
    {
        Bird bird;
        Wall wall_1;
        Wall wall_2;
        float gravity;

        public Game()
        {
            InitializeComponent();
            Start();
            Invalidate();
            timer.Enabled = true;
        }

        public void Start()
        {
            bird = new Bird(200,200);
            wall_1 = new Wall(400, -50, true);
            wall_2 = new Wall(400, 300);
        }
        
        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(bird.bird_image, bird.x, bird.y, bird.size, bird.size);            
            graphics.DrawImage(wall_1.wall_image, wall_1.x, wall_1.y, wall_1.size_X, wall_1.size_Y);
            graphics.DrawImage(wall_2.wall_image, wall_2.x, wall_2.y, wall_2.size_X, wall_2.size_Y);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gravity = 0;
                bird.flight = -0.16f;
            }
        }

        public void MoveWall()
        {
            wall_1.x -= 5;
            wall_2.x -= 5;
            Create();
        }

        public void Create()
        {
            if(bird.x > wall_1.x+300)
            {
                wall_1 = new Wall(600, -50, true);
                wall_2 = new Wall(600, 300);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (bird.flight != 0.1f)
                bird.flight += 0.005f;
            gravity += bird.flight;
            bird.y += gravity;
            MoveWall();
            Invalidate();
        }
    }
}
