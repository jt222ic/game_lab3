using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShootThaBall.Model;
using ShootThaBall.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.View
{
    class BallView
    {
        Texture2D ball;
        Texture2D background;
        //Camera camera;
        BallSimulation b_ballsimunlation;



        public BallView(ContentManager content, BallSimulation ballsimunlation, GraphicsDeviceManager graphics)
        {
            b_ballsimunlation = ballsimunlation;

            ball = content.Load<Texture2D>("Ball.png");
            background = new Texture2D(graphics.GraphicsDevice, 1, 1);
            background.SetData<Color>(new Color[]
            {
                Color.White
            });
            //.Load<Texture2D>("Final.jpg");
            //amera = new Camera();


        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, camera.getGameArea(), Color.HotPink);
            
            foreach (Ball BallList in b_ballsimunlation.GetBalls())
            {
                Random rand = new Random();


               
                Vector2 ballanimation = BallList.position();
                var ballposition = camera.VisualCoord(BallList.BallPosition.X - BallList.Ballsize, BallList.BallPosition.Y - BallList.Ballsize);
                float scale = camera.ScaleObject(ball.Width,BallList.Ballsize);
             
                spriteBatch.Draw(ball, ballposition, null, Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);

            }
            // innehållet.
            spriteBatch.End();
        }

    }
}

