using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShootThaBall.Model
{
    class BallSimulation
    {
        private List<Ball> ballinstance = new List<Ball>();
        Random rand = new Random();
        private int max = 10;


        public BallSimulation()
        {

            for (int i = 0; i < max; i++)
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

                Ballbounching(ball);               // just varför!?!?!? istället för att foreach i ballbouncing???
                ball.movingtheball(time);
            }


        }

        public void Ballbounching(Ball ball)
        {        // varför inte foreacha här?!?!!? i en lista?????? måste istället kalla på från update.....
           

                if (ball.BallPosition.X <= 0 + ball.Ballsize || ball.BallPosition.X >= 1 - ball.Ballsize)
                {
                    ball.SpeedXturn();  // do somethign about rotating the speed back
                }
                else if (ball.BallPosition.Y <= 0 + ball.Ballsize || ball.BallPosition.Y >= 1 - ball.Ballsize)
                {
                    ball.SpeedYturn(); // do something about rotating Y axel back
                }
            
        }

    }
}

