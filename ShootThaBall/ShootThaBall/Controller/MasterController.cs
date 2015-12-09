using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootThaBall.Model;
using ShootThaBall.View;
using ShootThaBall.View.ExplosionSystem;
using ShootThaBall.View.ExplosionSystem.Smoke;
using System;
using System.Collections.Generic;

namespace ShootThaBall
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BallView ballview;
        BallSimulation ballsimulation;
        Camera camera;
        MouseState prevMousestate;
        MouseState mousestate;
        private List<TheOneWhoControl> Explosion = new List<TheOneWhoControl>();





        TheOneWhoControl Particle;
        

       
      
       

        public MasterController()
        {

            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            camera = new Camera();
            
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 320;
            graphics.ApplyChanges();
            
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            camera.ScaleEverything(graphics.GraphicsDevice.Viewport);
           // boom = this.Content.Load<SoundEffect>("fire.wav");
            //boom = Content.Load<SoundEffect>("fire.wav").CreateInstance();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ballsimulation = new BallSimulation();
            ballview = new BallView(Content, ballsimulation, graphics);
             Particle = new TheOneWhoControl(Content, spriteBatch, camera);

           



            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ballsimulation.MakeTheballMove((float)gameTime.ElapsedGameTime.TotalSeconds);

            // mouse function//

            prevMousestate = mousestate;
            mousestate = Mouse.GetState();

            if(mousestate.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released)
            {
                Explosion.Add(new TheOneWhoControl(Content, spriteBatch, camera));

                   
                    
              //  Particle.DrawEverything();
                Particle.Updateeverything((float)gameTime.ElapsedGameTime.TotalSeconds);


            }
            //else if (mousestate.LeftButton == ButtonState.Released && prevMousestate.LeftButton == ButtonState.Pressed)
            //{

                
            
           




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ballview.Draw(spriteBatch, camera);
           // Particle.Updateeverything((float)gameTime.ElapsedGameTime.TotalSeconds);
            Particle.DrawEverything();
            
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
