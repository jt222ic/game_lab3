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
        Texture2D crosshair;
        Aim aim;
        TheOneWhoControl Particle;
        Vector2 mousePosition;
        ClickExplosion Click;

       
      
       

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
             Particle = new TheOneWhoControl(Content, spriteBatch, camera, mousePosition);
            aim = new Aim();
            crosshair = Content.Load<Texture2D>("crosshair.png");
            Click = new ClickExplosion(Content,spriteBatch,camera);


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
            Click.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            
            prevMousestate = mousestate;
            mousestate = Mouse.GetState();

             mousePosition = camera.getLogicalCord(mousestate.X, mousestate.Y);  // mouse moving position

          //mousePosition = new Vector2(mousestate.X, mousestate.Y);

            if (mousestate.LeftButton == ButtonState.Pressed && prevMousestate.LeftButton == ButtonState.Released)
            {
                aim.Update(mousePosition);
                if (mousePosition.X <= 1f && mousePosition.X >= 0f && mousePosition.Y <= 1f && mousePosition.Y >= 0f)   // innanför 0.0 och 1.0
                {
                   ballsimulation.BallGotHit(mousePosition.X, mousePosition.Y, aim.CrosshairSize / 2);
                   Click.CreateExplosion(mousePosition);
                   Particle.OnClick(new Vector2(mousestate.X, mousestate.Y));
                }
            }
            
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
           
            aim.Update(mousePosition);
            aim.DrawCrosshair(spriteBatch, camera, crosshair);
            Click.Draw();
                                     // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
       
        
    }
}
