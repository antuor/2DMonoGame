using IsometricMonoGame.core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace IsometricMonoGame.Core
{
    public class GameCore : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;

        private List<GameObject> gameObjects = null;
        private Dictionary<string, Texture2D> spritesStorage = new Dictionary<string, Texture2D>();

        private IEnumerable<GameObject> GameObjects { get => gameObjects; }

        internal Dictionary<string, Texture2D> SpritesStorage { get => spritesStorage; }

        public GameCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            string fileName = "config.dat";
            ConfigurationAccess.InitializeConfig(fileName);
            InitializeGameObjects();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesStorage["player"] = Content.Load<Texture2D>(@"Sprites/Sprite-Temp");
            spritesStorage["mines"] = Content.Load<Texture2D>(@"Sprites/Rectangle");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            player.Move(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Matrix.CreateScale(2.0f));
            foreach (GameObject go in GameObjects)
                go.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void InitializeGameObjects()
        {
            player = new Player(this);
            gameObjects = new List<GameObject>()
                {
                    player,
                    new Mine(this, new Vector2(100, 100)),
                    new Mine(this, new Vector2(200, 200))
                };
        }
    }
}
