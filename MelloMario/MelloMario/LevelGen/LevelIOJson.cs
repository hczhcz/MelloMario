﻿using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace MelloMario.LevelGen
{
    class LevelIOJson
    {
        // Note: As File.ReadAllText will take care of dispose itself,
        // there is no need to implement IDisposable

        private string path;
        private GameModel model;
        private string levelString;
        private GraphicsDevice graphicsDevice;
        private GameConverter gameConverter;
        public LevelIOJson(string jsonPath, GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            path = jsonPath;
        }

        public void SetModel(GameModel model)
        {
            this.model = model;
        }

        public Tuple<IGameWorld, IPlayer> Load(string index)
        {
            levelString = File.ReadAllText(path);
            gameConverter = new GameConverter(model, graphicsDevice, index);
            return JsonConvert.DeserializeObject<Tuple<IGameWorld, IPlayer>>(levelString, gameConverter);

        }
    }
}
