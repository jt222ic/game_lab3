using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View.ExplosionSystem._2dExplosion
{
    class Flame
    {
        int NumbersOfFrame = 48;
        float maxTime = 1f;
        float timeElapsed;
        int frameX;
        float frameY;
        int numberFrameX = 4;
        int numberFrameY = 10;
        private Texture2D TrueFlame;
        int frame;
        Vector2 scale = new Vector2(20f, 50f);


        public Flame(Texture2D FlameExplosion)
        {

            TrueFlame = FlameExplosion;

            frameX = TrueFlame.Width / numberFrameX;                // hitta logiska modellen delar upp det i frame 6x4 i bitar av bilden i x och y led
            frameY = TrueFlame.Height / numberFrameY;


        }


        public void Draw(SpriteBatch spritebatch, Camera camera)
        {
            // spritebatch.Begin();
            frameX = frame % numberFrameX;   //teachc0de
            frameY = frame / numberFrameX;
            Rectangle test = new Rectangle(frameX * 128, (int)frameY * 128, TrueFlame.Width / numberFrameX, TrueFlame.Height / numberFrameY);
            Vector2 scale = camera.ScaleObject2d(TrueFlame.Width / numberFrameX, TrueFlame.Height / numberFrameY);// TExture2d width and height dela med numbersof frames
            spritebatch.Draw(TrueFlame, new Vector2(100, 100), test, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);

            /// hittar inte animationens position, tittar på youtube eller använder av variabeln numberofFrame x eller number of frameY

            //  spritebatch.End();

        }

        public void Update(float Elapsedtime)
        {


            timeElapsed += Elapsedtime;
            float percentAnimated = timeElapsed / maxTime;
            frame = (int)(percentAnimated * NumbersOfFrame);

            if (timeElapsed > maxTime)
            {
                if (frame > 3)
                {
                    frame = 0;
                }
                else
                {
                    frame++;
                }

            }
        }
    }
}
