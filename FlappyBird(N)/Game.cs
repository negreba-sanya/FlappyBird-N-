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
            timer.Start();
            Start();
            Invalidate();            
        }

        public void Start()
        {
            bird = new Bird(200,200);
            wall_1 = new Wall(400, -50, true);
            wall_2 = new Wall(400, 300);
            label1.Text = "Счет: 0";
            timer.Start();
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
            if (e.KeyCode == Keys.Space)
            {
                if (bird.play == true)
                {
                    gravity = 0;
                    bird.flight = -0.16f;
                }
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
                Random random = new Random();
                int y = random.Next(-100,0);
                wall_1 = new Wall(600, y, true);
                wall_2 = new Wall(600, y+350);
                bird.score++;
                label1.Text = "Счет: "+bird.score;

            }
        }

        private bool Collision(Bird bird, Wall wall)
        {
            PointF point = new PointF();
            point.X = (bird.x + bird.size / 2) - (wall.x + wall.size_X / 2);
            point.Y = (bird.y + bird.size / 2) - (wall.y + wall.size_Y / 2);
            if (Math.Abs(point.X) <= bird.size / 2 + wall.size_X / 2)
            {
                if (Math.Abs(point.Y) <= bird.size / 2 + wall.size_Y / 2)
                {
                    return true;
                }
            }
            return false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (bird.y > 510)
            {
                gravity = 0;
                bird.play = false;
                timer.Stop();
                Start();
            }

            if (Collision(bird, wall_1) == true || Collision(bird, wall_2) == true)
            {
                gravity = 0;
                bird.play = false;
                timer.Stop();
                Start();
            }

            if (bird.flight != 0.1f)
                bird.flight += 0.005f;
            gravity += bird.flight;
            bird.y += gravity;

            if (bird.play == true)
            {
                MoveWall();
            }

            Invalidate();
        }
    }
}
