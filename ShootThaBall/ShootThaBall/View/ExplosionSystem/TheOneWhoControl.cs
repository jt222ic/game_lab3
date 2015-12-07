using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShootThaBall.View.ExplosionSystem._2dExplosion;
using ShootThaBall.View.ExplosionSystem.Smoke;
using ShootThaBall.View.ExplosionSystem.Splitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View.ExplosionSystem
{
    class TheOneWhoControl
    {
        Texture2D Smoke;
        Texture2D Spark;
        Texture2D Explosion;
        private float seperateTime;

        private SmokeSystem _smokesystem;
        private SplitterSystem _splittersystem;
        private Flame Flame;

        int flameCount = 0;
        //private SplitterParticle s_splitterParticle;  // vetej

        Camera camera;

        SpriteBatch spriteBatch;


        public TheOneWhoControl(ContentManager Content, SpriteBatch spriteBatch, Camera camera)
        {
            Smoke = Content.Load<Texture2D>("particlesmokee.png");
            Spark = Content.Load<Texture2D>("spark.png");
            Explosion = Content.Load<Texture2D>("explosion.png");



            _smokesystem = new SmokeSystem(Smoke);
            _splittersystem = new SplitterSystem(Spark);
            Flame = new Flame(Explosion);

            this.spriteBatch = spriteBatch;
            this.camera = camera;

        }
        public void Updateeverything(float gameTime)
        {


            float timeElapsedSeconds = gameTime;
            Flame.Update(timeElapsedSeconds);
            _splittersystem.Update(timeElapsedSeconds);
            _smokesystem.Update(timeElapsedSeconds);

            seperateTime += gameTime;

            if (seperateTime >= _smokesystem.smokeLife / _smokesystem.Maxparticle)
            {
                _smokesystem.MakeSmoke(Smoke);
                seperateTime = 0;
            }
        }

        public void DrawEverything()
        {
            flameCount++;
            this.spriteBatch.Begin();

            if (flameCount < 24)
            {
                Flame.Draw(this.spriteBatch, this.camera);
            }

            _splittersystem.Draw(Spark, this.camera, this.spriteBatch);
            _smokesystem.Draw(Smoke, this.spriteBatch, this.camera);


            this.spriteBatch.End();
        }
    }
}
