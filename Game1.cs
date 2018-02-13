using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameTraining
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // texture support
        Texture2D texture;
        // position support
        Vector2 position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //this unactivate the fixed time step: this option set the fps as the maximum of gpu speed 
            //when unaactivated
            this.IsFixedTimeStep = true; //default true

            //this allows to set the target elapsed time, is kind of time what is going to be between updates.
            this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33);

            //this unactivate sync with the most comon monitors refresh rate that limit it almost to 60fps
            //what mean if this option in in false the gpu will refresh at the max possible speed. the fps should increase
            //this.graphics.SynchronizeWithVerticalRetrace = false;

            //those events shows the title application on dependence of state (active, unactive)
            
            /*
            this.Activated += (sender, args) => { this.Window.Title = "Active application"; };
            this.Deactivated += (sender, args) => { this.Window.Title = "Unactive application"; };*/
        }

        /// <summary>
        /// this accomplish the same function of the events created on Game1(), showing a message from a method
        /// wich works in the case the application is being foccused 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        //protected override void OnActivated(object sender, EventArgs args)
        //{
        //    this.Window.Title = "Active Application";
        //    base.OnActivated(sender, args); 
        //}

        /// <summary>
        /// this accomplish the same function of the events created on Game1(), showing a message from a method
        /// wich works in the case the application isNn´t being foccused 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        //protected override void OnDeactivated(object sender, EventArgs args)
        //{
        //    this.Window.Title = "Unactive Application";
        //    base.OnDeactivated(sender, args);   
        //}



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            position = new Vector2(0, 0);
            //defines the texture grafics been used and lenght
            texture = new Texture2D(this.GraphicsDevice, 100, 100); 
            //array of colors
            Color[] colorData = new Color[100*100];
            //fills the array created before
            for (int i = 0; i < 10000; i++)
                colorData[i] = Color.Red;
            //set the color to the texture
            texture.SetData<Color>(colorData);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            //it destroys the instance once its no longer neccesary
            texture.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // just works if the screen is focus
            if (IsActive)
            {

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();//ends the loop update, draw. once it is called

                // TODO: Add your update logic here

                //moves the texture 1 pixel by frame
                //position.X += 1;

                position.X += 60.0f*(float)gameTime.ElapsedGameTime.TotalSeconds;
                //reset the positioin if it overcomes the window widht
                if (position.X > this.GraphicsDevice.Viewport.Width)
                    position.X = 0;



                base.Update(gameTime);

            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //this is to visualize the frames per second(fps) in the window tittle
            //if (IsActive)
            //{
            //    var fps = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            //    Window.Title = fps.ToString();
            //}

            //this is to check if the gametime property isRunningSlowly (irs) is true... after I included also 
            //the fps to this tittle
            if (IsActive)
            {
                var fps = 1/gameTime.ElapsedGameTime.TotalSeconds;
                var irs = gameTime.IsRunningSlowly;
                Window.Title = "fps: " + fps.ToString() + "  Is running slowly: " + irs.ToString();
            }

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
