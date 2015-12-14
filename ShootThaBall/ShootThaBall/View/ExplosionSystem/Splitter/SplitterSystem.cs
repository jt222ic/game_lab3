using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View.ExplosionSystem.Splitter
{
    class SplitterSystem
    {
        public SplitterParticle[] particles;
        private const int maxParticles = 100;
        SplitterParticle sParticle = new SplitterParticle();
        Vector2 startPosition;

        Random test = new Random();

        public SplitterSystem(Texture2D sprites, Vector2 startPosition) // skicka in i ny position
        {
            this.startPosition = startPosition;
            particles = new SplitterParticle[maxParticles];
            for (int i = 0; i < maxParticles; i++)
            {
                particles[i] = new SplitterParticle(sprites, test, startPosition);  // ingen argument ännu en skickar 100 gånger
            }
        }

        public void Update(float totalSeconds)
        {
            //  sParticle.Update(totalSeconds);
            for (int i = 0; i < maxParticles; i++)
            {
                particles[i].Update(totalSeconds);
            }
        }
        //splittersystem.Draw(spark, camera, spriteBatch);
        public void Draw(Texture2D spark, Camera camera, SpriteBatch spriteBatch)
        {

            // sParticle.Draw(spark, camera, spriteBatch);
            for (int i = 0; i < maxParticles; i++)
            {
                particles[i].Draw(spark, camera, spriteBatch);
            }
        }
    }
}
