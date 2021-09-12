using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird_N_
{
    class Bird
    {
        public float x;
        public float y;
        public float size;
        public float flight;
        public Image bird_image;
        public bool play;
        public int score;

        public Bird(float x, float y)
        {
            this.x = x;
            this.y = y;
            size = 50;
            bird_image = new Bitmap(FlappyBird_N_.Properties.Resources.bird);
            flight = 0.1f;
            play = true;
        }
    }
}
