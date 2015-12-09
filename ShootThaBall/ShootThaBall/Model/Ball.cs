using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.Model
{
    class Ball
    {

        public float Ballsize = 0.05f;
        public Vector2 BallCordination = new Vector2(0.5f, 0.2f);
        public Vector2 Ballspeed = new Vector2(0.5f, 0.4f);
        private Vector2 randomDirection;
        public Vector2 maxspeed = new Vector2(0.9f, 0.8f);


        public Ball(Random rand)
        {
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);

            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * maxspeed);

            Ballspeed = randomDirection;

        }
        public Vector2 GetBallSpeed
        {
            get
            {
                return Ballspeed;
            }
        }

        public Vector2 BallPosition
        {
            get
            {
                return BallCordination;
            }
        }

        public void movingtheball(float time)
        {
            BallCordination += Ballspeed * time;
        }

        public void SpeedXturn()
        {
            Ballspeed.X = -Ballspeed.X;
        }
        public void SpeedYturn()
        {
            Ballspeed.Y = -Ballspeed.Y;
        }
    }
}

