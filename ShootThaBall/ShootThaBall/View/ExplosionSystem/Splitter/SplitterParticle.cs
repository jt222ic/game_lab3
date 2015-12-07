using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View.ExplosionSystem.Splitter
{
    class SplitterParticle
    {
        // fält//
        Random rand = new Random();
        private float maxspeed = 130f;
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0f, 440f);
        private Vector2 position = new Vector2(200f, 200f);
        public Texture2D nowsprites;
        public Vector2 randomDirection;// = new Vector2(0.4f,0.4f);



        public SplitterParticle(Texture2D newsprites, Random rand)
        {
            nowsprites = newsprites;
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);

            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxspeed);
            velocity = randomDirection * 100;                                               // ska tillägga max speed senare
        }
        public SplitterParticle()
        {

        }

        public void Update(float elapsedTime)
        {
            velocity = velocity + acceleration * elapsedTime;
            position = position + velocity * elapsedTime;

        }

        public void Draw(Texture2D spark, Camera camera, SpriteBatch spriteBatch)
        {
            Vector2 vector = camera.VisualCoord(position.X, position.Y);
            // spriteBatch.Begin();
            spriteBatch.Draw(spark, position, null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0); // visuella koordinationer stööre 
                                                                                                                 // spriteBatch.End();
        }
    }
}
