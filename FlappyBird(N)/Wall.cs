using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird_N_
{
    class Wall
    {
        public float x;
        public float y;
        public float size_X;
        public float size_Y;
        public Image wall_image;

        public Wall(float x, float y, bool Rotated = false)
        {
            this.x = x;
            this.y = y;
            size_X = 60;
            size_Y = 180;
            wall_image = new Bitmap("C:\\Users\\Alexander\\Desktop\\tube.png");
            if (Rotated == true)
            {
                wall_image.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }
    }
}
