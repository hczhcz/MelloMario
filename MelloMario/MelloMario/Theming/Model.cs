﻿using System.Collections.Generic;
using MelloMario.Controls.Scripts;
using MelloMario.Containers;
using MelloMario.LevelGen;
using MelloMario.MiscObjects;
using MelloMario.Sounds;
using MelloMario.UIObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario.Theming
{
    internal class Model : IGameModel
    {
        private readonly Game1 game;
        private readonly IListener listener;
        private readonly Session session;
        private ICamera activeCamera;
        private IEnumerable<IController> controllers;
        private InfiniteGenerator infiniteGenerator;
        private string mapPath = "Content/Level1.json";
        public bool IsPaused { get; private set; }

        //TODO: temporary public
        //note: we will have an extra class called Player which contains these information
        public IObject Splash;

        private int splashElapsed; // TODO: for sprint 4, refactor later

        public Model(Game1 game)
        {
            this.game = game;
            session = new Session();
            ActivePlayer = new Player(session);
            listener = new Listener(this, ActivePlayer);
            Database.Initialize(session);
            SoundController.Initialize(this);
        }

        public Matrix GetActiveViewMatrix
        {
            get
            {
                return activeCamera.GetViewMatrix(new Vector2(1f));
            }
        }

        //TODO: Change with multiplayer
        public IPlayer ActivePlayer { get; }

        public void ToggleFullScreen()
        {
            game.ToggleFullScreen();
        }

        public void Pause()
        {
            IsPaused = true;
            new PausedScript().Bind(controllers, this, ActivePlayer.Character);
            splashElapsed = -1;
        }

        public void Init()
        {
            activeCamera = new Camera();

            ActivePlayer.Init("Mario", LoadLevel("Main"), listener, activeCamera);
            IsPaused = true;
            new PlayingScript().Bind(controllers, this, ActivePlayer.Character);

            Splash = new GameStart(ActivePlayer); // TODO: move these constructors to the factory
            new StartScript().Bind(controllers, this, ActivePlayer.Character);
            splashElapsed = -1;
        }

        public void Resume()
        {
            IsPaused = false;
            new PlayingScript().Bind(controllers, this, ActivePlayer.Character);

            Splash = new HUD(ActivePlayer);
        }

        public void Reset()
        {
            // TODO: "forced" version of LoadLevel()
            game.Reset();
            Resume();
        }

        public void Quit()
        {
            game.Exit();
        }

        public void Infinite()
        {
            mapPath = "Content/Infinite.json";
            splashElapsed = 0;
            ActivePlayer.Init("Mario", LoadLevel("Main"), listener, activeCamera);
            IsPaused = false;
            Resume();
        }

        public void Normal()
        {
            mapPath = "Content/Level1.json";
            splashElapsed = 0;
            ActivePlayer.Init("Mario", LoadLevel("Main"), listener, activeCamera);
            IsPaused = false;
            Resume();
        }

        public void Update(int time)
        {
            UpdateController();
            Database.Update();
            SoundController.Update();
            if (IsPaused)
            {
                if (splashElapsed < 0)
                {
                    return;
                }
                splashElapsed += time;
                if (splashElapsed >= 1000 * 2)
                {
                    Resume();
                }
                return;
            }
            //TODO: Pause state should not stop updating camera
            UpdateGameObjects(time);
            UpdateContainers();
            infiniteGenerator.Update(time);
        }

        public void Draw(int time, SpriteBatch spriteBatch)
        {
            IPlayer player = ActivePlayer;

            foreach (IGameObject obj in player.Character.CurrentWorld.ScanNearby(player.Camera.Viewport))
            {
                obj.Draw(IsPaused ? 0 : time, spriteBatch);
            }

            Splash.Draw(time, spriteBatch);
        }

        public void LoadControllers(IEnumerable<IController> newControllers)
        {
            controllers = newControllers;
        }

        public IGameWorld LoadLevel(string id)
        {
            foreach (IGameWorld world in session.ScanWorlds())
            {
                if (world.ID == id)
                {
                    return world;
                }
            }

            // IGameWorld newWorld = new GameWorld(id, new Point(50, 20), new Point(1, 1), new List<Point>());

            LevelIOJson reader = new LevelIOJson(mapPath, listener);
            reader.SetModel(this);

            IGameWorld newWorld = reader.Load(id);
            infiniteGenerator = new InfiniteGenerator(newWorld, listener, activeCamera);
            return newWorld;
        }

        public void Transist()
        {
            ActivePlayer.Reset("Mario", listener);

            IsPaused = true;
            new TransistScript().Bind(controllers, this, ActivePlayer.Character);

            Splash = new GameOver(ActivePlayer);
            splashElapsed = 0;
        }

        public void TransistGameWon()
        {
            ActivePlayer.Win();

            IsPaused = true;
            new TransistScript().Bind(controllers, this, ActivePlayer.Character);

            Splash = new GameWon(ActivePlayer);
            splashElapsed = -1;
        }

        private void UpdateController()
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
        }

        private void UpdateGameObjects(int time)
        {
            // reserved for multiplayer
            ISet<IObject> updating = new HashSet<IObject>();

            foreach (IPlayer player in session.ScanPlayers())
            {
                player.Update(time);
                foreach (IGameObject obj in player.Character.CurrentWorld.ScanNearby(player.Character.Sensing))
                {
                    updating.Add(obj);
                }
            }

            updating.Add(Splash);

            foreach (IObject obj in updating)
            {
                obj.Update(time);
            }
        }

        private void UpdateContainers()
        {
            session.Update();
            foreach (IGameWorld world in session.ScanWorlds())
            {
                world.Update();
            }
        }
    }
}
