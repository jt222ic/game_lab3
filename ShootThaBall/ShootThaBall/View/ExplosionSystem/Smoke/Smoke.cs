using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View.ExplosionSystem.Smoke
{
    class Smoke
    {

        public Texture2D smokey;
        private Vector2 randomDirection;
        private float maxspeed = 0.2f;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0f, -0.8f);
        private Vector2 position = new Vector2(0.5f, 0.8f);



        float timeLived = 0;
        float lifePercent;
        private float MaxTimeToLive = 3f;
        private float size;
        private float minSize = 0;
        private float maxSize = 10;
        public float fade = 1;


        public Smoke(Texture2D smoke, Random rand)
        {
            smokey = smoke;
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            size = 0;
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxspeed);
            velocity = randomDirection;


        }

        public void SmokeFade(float MaxTimetoLive)
        {

            timeLived = 0;
            fade = 0;
            MaxTimetoLive = timeLived;


        }


        public bool TimeEnd()
        {
            return timeLived >= MaxTimeToLive;
        }

        public void Draw(Texture2D smoke, SpriteBatch spriteBatch, Camera camera)
        {

            //spriteBatch.Begin();
            Vector2 Visual = camera.VisualCoord(position.X, position.Y);
            Color color = new Color(fade, fade, fade, fade);
            spriteBatch.Draw(smoke, Visual, null, color, 0, new Vector2(0, 0), size, SpriteEffects.None, 0);                   // visuella koordinationer stööre 
                                                                                                                               // spriteBatch.End();
                                                                                                                               // spriteBatch.Draw(smoke, new Vector2(0, 0), Color.White);s
        }

        public void Update(float elapsedTime)
        {
            timeLived += elapsedTime;
            lifePercent = timeLived / MaxTimeToLive;
            size = minSize + lifePercent * maxSize;


            fade -= elapsedTime / MaxTimeToLive;
            velocity = velocity + acceleration * elapsedTime;
            position = position + velocity * elapsedTime;


        }
    }
}
