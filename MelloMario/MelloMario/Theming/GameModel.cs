﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MelloMario.LevelGen;
using System;
using MelloMario.Containers;
using MelloMario.Scripts;

namespace MelloMario
{
    class GameModel : IGameModel
    {
        private IDictionary<string, IGameWorld> worlds;
        private IGameWorld currentWorld;
        private string currentWorldIndex;

        private IEnumerable<IController> controllers;
        private IPlayer player;
        private LevelIOJson reader;
        private bool isPaused;
        private Game1 game;

        public GameModel(Game1 game, LevelIOJson reader)
        {
            this.worlds = new Dictionary<string, IGameWorld>();
            currentWorldIndex = "Main";
            this.game = game;
            this.reader = reader;
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
                currentWorld = worlds[index];
            }
            else
            {
                Tuple<IGameWorld, IPlayer> pair = reader.Load(index);
                worlds.Add(currentWorldIndex, currentWorld);
                currentWorld = pair.Item1;
            }

            player.Spawn(currentWorld);
        }

        public void Reset()
        {
            reader.SetModel(this);
            using (currentWorld) { }
            Tuple<IGameWorld, IPlayer> pair = reader.Load();
            currentWorld = pair.Item1;
            player = pair.Item2;
            
            isPaused = false;
            new PlayingScript().Bind(controllers, this, player);
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

                foreach (IGameObject obj in currentWorld.ScanNearby(player.Sensing))
                {
                    updating.Add(obj);
                }

                foreach (IGameObject obj in updating)
                {
                    obj.Update(time);
                }

                currentWorld.Update();
            }
        }

        public void Draw(int time)
        {
            foreach (ZIndex zIndex in Enum.GetValues(typeof(ZIndex)))
            {
                foreach (IGameObject obj in currentWorld.ScanNearby(player.Viewport))
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
