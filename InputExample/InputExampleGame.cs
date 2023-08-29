using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputExample
{
    public class InputExampleGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Ball[] balls;
        InputManager inputMngr;

        /// <summary>
        /// Constructs the game
        /// </summary>
        public InputExampleGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            inputMngr = new InputManager();
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            balls = new Ball[] {
                new Ball(this, Color.Red) { Position = new Vector2(250, 200) },
                new Ball(this, Color.Green) { Position = new Vector2(350, 200) },
                new Ball(this, Color.Blue) { Position = new Vector2(450, 200) }
            };
            base.Initialize();
        }

        /// <summary>
        /// Loads game content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (Ball b in balls) b.LoadContent();
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Update(GameTime gameTime)
        {
            inputMngr.Update(gameTime);
            if (inputMngr.Exit)
            {
                Exit();
            }
            balls[0].Position += inputMngr.Position;
            if (inputMngr.Warp)
            {
                balls[0].Warp();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (Ball b in balls) b.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
