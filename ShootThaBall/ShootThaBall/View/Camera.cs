using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View
{
    class Camera
    {

        private float sizeOfftheField = 250;
        private int bordersize = 64;
        public float scale;
        private float scaleX;
        private float scaleY;


        public void ScaleEverything(Viewport viewport)
        {
            scaleX = viewport.Width;
            scaleY = viewport.Height;

            if (scaleX < scaleY)
            {
                scale = scaleX;
            }
            else if (scaleX > scaleY)
            {
                scale = scaleY;
            }

            scaleX = scale - bordersize * 2;
            scaleY = scale - bordersize * 2;
        }

        public Vector2 VisualCoord(float x, float y)
        {
            float visualX = x * scaleX + bordersize;
            float visualY = y * scaleY + bordersize;

            return new Vector2(visualX, visualY);
        }

        public float ScaleObject(int width, float radius)   // scale 10% of the screeen size
        {
            return sizeOfftheField * 2 * radius / (float)width;

        }


        public Rectangle getGameArea()
        {
            return new Rectangle(bordersize, bordersize, (int)scaleX, (int)scaleY);
        }
        public Vector2 ScaleObject2d(int width, int height)
        {
            return new Vector2(scaleX / width, scaleY / height);
        }
    }
}

