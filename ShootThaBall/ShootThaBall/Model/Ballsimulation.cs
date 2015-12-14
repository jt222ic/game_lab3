using Microsoft.Xna.Framework;
using ShootThaBall.View;
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
        int counter = 0;

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
                    ball.movingtheball(time);
                    Ballbounching(ball);
            }
        }
        public void BallGotHit(float mousepositionX, float mousepositionY, float crosshairSize)
        {
            Vector2 hej = new Vector2(mousepositionX, mousepositionY);
            Console.WriteLine(hej);

            foreach (Ball ball in ballinstance)
            {
                if(ball.BallAlive)
                {
                    
                    if (ball.BallPosition.X + ball.Ballsize > mousepositionX - crosshairSize && 
                        ball.BallPosition.X - ball.Ballsize < mousepositionX + crosshairSize && 
                        ball.BallPosition.Y + ball.Ballsize > mousepositionY - crosshairSize && 
                        ball.BallPosition.Y - ball.Ballsize > mousepositionY + crosshairSize)
                    {
                        counter++;
                       
                        Console.WriteLine("ball got hit the invi cursor{0}",counter);
                        ball.BallAlive = false;
                        

                    }
                }
                
            }
        }

        public void Ballbounching(Ball ball)
        {        // varför inte foreacha här?!?!!? i en lista?????? måste istället kalla på från update.....

            if (ball.BallAlive)
            {

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
   
}

