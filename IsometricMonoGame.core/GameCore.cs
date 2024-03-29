﻿using MonoGame.Core.GameModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGame.Core
{
    public class GameCore : Game
    {
        private GraphicsDeviceManager graphics;
        private Player player;
        private Camera camera;

        private List<GameObject> gameObjects = null;
        private readonly Dictionary<string, Texture2D> spritesStorage = new Dictionary<string, Texture2D>();

        private IEnumerable<GameObject> GameObjects { get => gameObjects; }
        
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
            Configuration config = ConfigurationAccess.GetCurrentConfig();
            camera = new Camera(player, GraphicsDevice, spritesStorage, 
                config.playerFramePercentWidth, config.playerFramePercentHeight);

            spritesStorage[Player.CommonSpriteNameRight] = Content.Load<Texture2D>(@"Sprites/Sprite-Temp");
            spritesStorage[Player.CommonSpriteNameLeft] = Content.Load<Texture2D>(@"Sprites/Sprite-TempLeft");
            spritesStorage[Mine.CommonSpriteName] = Content.Load<Texture2D>(@"Sprites/Sprite-Mine");
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
            camera.Begin();
            foreach (GameObject go in GameObjects)
                camera.Draw(go);
            camera.End();
            base.Draw(gameTime);
        }

        private void InitializeGameObjects()
        {
            player = new Player();
            gameObjects = new List<GameObject>()
                {
                    player,
                    new Mine(new Vector2(100, 100)),
                    new Mine(new Vector2(200, 200))
                };
        }
    }
}
