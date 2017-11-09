﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MelloMario.LevelGen;
using System;
using MelloMario.Containers;
using MelloMario.Scripts;
using MelloMario.Theming;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario
{
    class GameModel : IGameModel
    {
        private Game1 game;
        private IDictionary<string, IGameWorld> worlds;
        private IEnumerable<IController> controllers;
        private IPlayer player;
        private bool isPaused;

        public GameModel(Game1 game)
        {
            this.game = game;
            worlds = new Dictionary<string, IGameWorld>();
        }

        public void LoadControllers(IEnumerable<IController> newControllers)
        {
            controllers = newControllers;
        }

        public void ToggleFullScreen()
        {
            game.ToggleFullScreen();
        }

        public void Pause()
        {
            isPaused = true;

            new PausedScript().Bind(controllers, this, player);
        }

        public void Resume()
        {
            isPaused = false;

            new PlayingScript().Bind(controllers, this, player);
        }

        public void SwitchWorld(string index)
        {
            if (worlds.ContainsKey(index))
            {
                player.Spawn(worlds[index]);
            }
            else
            {
                LevelIOJson reader = new LevelIOJson("Content/ExampleLevel.json", game.GraphicsDevice);
                reader.SetModel(this);
                Tuple<IGameWorld, IPlayer> pair = reader.Load(index);
                worlds.Add(index, pair.Item1);

                player.Spawn(pair.Item1);
            }
        }

        public void Reset()
        {
            GameDatabase.Clear();

            LevelIOJson reader = new LevelIOJson("Content/ExampleLevel.json", game.GraphicsDevice);
            reader.SetModel(this);
            Tuple<IGameWorld, IPlayer> pair = reader.Load("Main");
            worlds.Add("Main", pair.Item1);

            Tuple<IGameWorld, IPlayer> pair = reader.Load(currentWorldIndex);
            currentWorld = pair.Item1;
            pair.Item1.Add(Factories.GameObjectFactory.Instance.CreateGameObject("EndFlagTop", currentWorld, new Point(10 * 32, 13 * 32)));
            pair.Item1.Add(Factories.GameObjectFactory.Instance.CreateGameObject("EndFlag", currentWorld, new Point(10 * 32, 14 * 32)));

            player = pair.Item2;
            player.Spawn(pair.Item1);

            Resume();
        }

        public void Quit()
        {
            game.Exit();
        }

        public void Update(int time)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }


            if (!isPaused)
            {
                // reserved for multiplayer
                ISet<IGameObject> updating = new HashSet<IGameObject>();

                foreach (IGameObject obj in player.CurrentWorld.ScanNearby(player.Sensing))
                {
                    updating.Add(obj);
                }

                foreach (IGameObject obj in updating)
                {
                    obj.Update(time);
                }

                player.CurrentWorld.Update();
            }
        }

        public void Draw(int time)
        {
            foreach (ZIndex zIndex in Enum.GetValues(typeof(ZIndex)))
            {
                foreach (IGameObject obj in player.CurrentWorld.ScanNearby(player.Viewport))
                {
                    if (isPaused)
                    {
                        obj.Draw(0, player.Viewport, zIndex);
                    }
                    else
                    {
                        obj.Draw(time, player.Viewport, zIndex);
                    }
                }
            }
        }
    }
}
