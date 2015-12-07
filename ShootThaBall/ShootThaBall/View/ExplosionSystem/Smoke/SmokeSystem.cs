using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View.ExplosionSystem.Smoke
{
    class SmokeSystem
    {

        //public Smoke[] particle;    // in an array
        public List<Smoke> particle = new List<Smoke>();
        Random rand = new Random();
        Smoke smokeObject;
        public int Maxparticle = 200;
        Texture2D SMOKE;
        public float smokeLife = 5;
        public int particlelife = 1;
        public float respawn = 2;

        public SmokeSystem(Texture2D smoke)
        {
            SMOKE = smoke;
            smokeObject = new Smoke(smoke, rand);
        }

        public void MakeSmoke(Texture2D smoke)
        {
            if (particle.Count < Maxparticle)
            {
                Smoke newsmoke = new Smoke(smoke, rand);
                particle.Add(newsmoke);
            }
        }
        public void Draw(Texture2D smokeTexture, SpriteBatch spriteBatch, Camera camera)
        {
            foreach (Smoke s in particle)
            {
                s.Draw(smokeTexture, spriteBatch, camera);
            }
        }
        public void Update(float TimeDuration)
        {
            foreach (Smoke s in particle)
            {
                s.Update(TimeDuration);
                if (s.TimeEnd())
                {
                    s.SmokeFade(TimeDuration);
                }
            }
        }
    }
}
