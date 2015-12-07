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
        private Vector2 BallCordination = new Vector2(0.5f, 0.2f);
        private Vector2 Ballspeed = new Vector2(0.4f, 0.4f);
        Vector2 velocity;
        Vector2 randomDirection;  
        


        public Ball(Random rand)
        {
            randomDirection = new Vector2((float)rand.NextDouble() - 0.05f, (float)rand.NextDouble() - 0.5f);
            // code from smoke effect re-use
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * 0.5f);
            velocity = randomDirection;
        }

        public Vector2 GetBallSpeed
        {
            get
            {
                return Ballspeed;
            }
        }
        public Vector2 position()
        {
            return BallPosition;
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

