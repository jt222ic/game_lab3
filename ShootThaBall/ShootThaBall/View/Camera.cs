using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View
{
    class Camera
    {

        private float sizeOfftheField = 250;
        private int bordersize = 29;
        public float scale;
        private float scaleX;
        private float scaleY;


        public void ScaleEverything(Viewport viewport)
        {
            scaleX = viewport.Width - bordersize * 2;
            scaleY = viewport.Height - bordersize * 2;

            if (scaleX < scaleY)
            {
                scale = scaleX;
            }
            else if (scaleX > scaleY)
            {
                scale = scaleY;
            }
            
        }

        public Vector2 VisualCoord(float x, float y)
        {
            float visualX = x * scaleX + bordersize;
            float visualY = y * scaleY + bordersize;

            return new Vector2(visualX, visualY);
        }

        public Vector2 GetCrossHairVisualCoord(float x, float y)
        {

            float visualX = x * scaleX;
            float visualY = y * scaleY;

            return new Vector2(visualX, visualY);

        }

        public float ScaleObject(float width, float radius)  
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
        public Vector2 getLogicalCord(float x, float y)
        {
            float screenX = x / scaleX;// + bordersize;
            float screenY = y / scaleY;
            
           
            return new Vector2(screenX, screenY);
        }

        
        public Vector2 ScaleObjects(float width, float height)
        {


            return new Vector2(scaleX / width , scaleY / height );
        }


    }
}

