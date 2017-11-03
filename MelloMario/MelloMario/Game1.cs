﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MelloMario.Controllers;
using MelloMario.Factories;
using MelloMario.LevelGen;

namespace MelloMario
{
    /// <summary>
    /// This is the main type for Mello Mario game.
    /// </summary>
    class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private LevelIOJson reader;
        private GameModel model;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferHeight = 600;
            reader = new LevelIOJson("Content/ExampleLevel.json");
            model = new GameModel(this, reader);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            IEnumerable<IController> controllers = new List<IController>
            {
                new GamepadController(),
                new KeyboardController()
            };

            model.LoadControllers(controllers);

            model.Reset(); // Create the level for the first time
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";
            base.LoadContent();

            SpriteFactory.Instance.LoadAllTextures(Content);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.BindSpriteBatch(spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            reader.Dispose();
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime time)
        {
            base.Update(time);

            model.Update(time);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(time);

            spriteBatch.Begin();
            model.Draw(time);
            spriteBatch.End();
        }

        // game controlling

        public void ToggleFullScreen()
        {
            graphics.ToggleFullScreen();
        }
    }
}
