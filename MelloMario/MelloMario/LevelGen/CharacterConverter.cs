﻿using MelloMario.MarioObjects;
using MelloMario.Theming;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MelloMario.LevelGen
{
    class CharacterConverter : JsonConverter
    {
        private JToken jsonToken;
        private PlayerMario mario;
        private IGameSession gameSession;
        private IGameWorld gameWorld;
        private Stack<PlayerMario> characterStack;
        private Point startPoint;
        private string state;
        private int grid;
        private Listener listener;

        public CharacterConverter(IGameSession gameSession, IGameWorld gameWorld, Listener listener, int gridSize)
        {
            this.gameSession = gameSession;
            this.gameWorld = gameWorld;
            this.listener = listener;
            grid = gridSize;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(EncapsulatedObject<PlayerMario>).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            jsonToken = JToken.Load(reader);
            characterStack = new Stack<PlayerMario>();
            startPoint = jsonToken["SpawnPoint"].ToObject<Point>();
            state = jsonToken["State"].ToObject<string>();
            startPoint.X = startPoint.X * grid;
            startPoint.Y = startPoint.Y * grid;
            mario = new PlayerMario(gameSession, gameWorld, startPoint, listener);
            characterStack.Push(mario);
            //TODO: Change with IDictionary to change the state of each characters
            switch (state)
            {
                //TODO: Finish switch statement
                case "FireMario":
                    mario.UpgradeToFire();
                    break;
                case "SuperMario":
                    mario.UpgradeToSuper();
                    break;
                default:
                    //Do nothing
                    break;
            }
            return new EncapsulatedObject<PlayerMario>(characterStack);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
