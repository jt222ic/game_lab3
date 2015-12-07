using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.Model
{
    class BallSimulation
    {
        public List<Ball> ballinstance = new List<Ball>();
        private const int MaxBalls = 10;
        
        Random rand = new Random();

        public BallSimulation()
        {
            for (int i = 0; i < MaxBalls; i++)
            {
                ballinstance.Add(new Ball(rand));
            }
        }
        public List<Ball> GetBalls()
        {
            return ballinstance;
        }

        public void MakeTheballMove(float time)
        {
           
            foreach (Ball ball in ballinstance)
            {
                ball.movingtheball(time);
                Ballbounching();

                             //uppdatera här för att bollen ska kunna röra sig
            }

        }

        public void Ballbounching()
        {
            foreach (Ball ball in ballinstance)
            {

                if (ball.BallPosition.X <= 0 + ball.Ballsize || ball.BallPosition.X >= 1 - ball.Ballsize)
                {
                    ball.SpeedXturn();                  // do somethign about rotating the speed back
                }
                else if (ball.BallPosition.Y <= 0 + ball.Ballsize || ball.BallPosition.Y >= 1 - ball.Ballsize)
                {
                    ball.SpeedYturn();    // do something about rotating Y axel back
                }
            }
        }
    }
}
