﻿using MelloMario.BlockObjects;
using MelloMario.ItemObjects;
using MelloMario.Factories;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MelloMario.LevelGen
{
    class BaseGameObjectConverter : JsonConverter
    {
        private GameWorld gameWorld;
        private int grid;
        public BaseGameObjectConverter(GameWorld parentGameWorld, int gridSize)
        {
            gameWorld = parentGameWorld;
            grid = gridSize;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(EncapsulatedObject<IGameObject>).IsAssignableFrom(objectType) || objectType is IGameObject;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken gameObjToken = JToken.Load(reader);
            string gameObjectType = gameObjToken["Type"].ToObject<string>();
            Point startPoint = gameObjToken["Point"].ToObject<Point>();
            int rows = gameObjToken["Quantity"]["X"].ToObject<int>();
            int columns = gameObjToken["Quantity"]["Y"].ToObject<int>();
            IDictionary<Point, Tuple<bool, string>> Properties = null;
            var propertiesJToken = gameObjToken["Properties"];
            if (propertiesJToken != null && propertiesJToken.HasValues)
            {
                Properties = propertiesJToken.ToDictionary(
                  token => token["Index"].ToObject<Point>(),
                  token => new Tuple<bool, string>(
                      token["isHidden"].ToObject<bool>(),
                      token["ItemValue"].ToObject<string>()));
            }
            var objectStack = new Stack<IGameObject>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Point location = new Point((startPoint.X + i) * grid, (startPoint.Y + j) * grid);
                    Tuple<bool, string> property;
                    if (Properties == null || !Properties.TryGetValue(new Point(i, j), out property))
                    {
                        property = new Tuple<bool, string>(false, "");
                    }
                    switch (gameObjectType)
                    {
                        //TODO: Add items parameter in constructors for Brick and Question
                        case "Brick":
                            objectStack.Push(new Brick(gameWorld, location));
                            break;
                        case "Question":
                            objectStack.Push(new Question(gameWorld, location));
                            break;
                        case "Pipeline":
                            objectStack.Push(new Pipeline(gameWorld, location, property.Item2));
                            break;
                        case "Floor":
                            objectStack.Push(new Floor(gameWorld, location));
                            break;
                        case "Stair":
                            objectStack.Push(new Stair(gameWorld, location));
                            break;
                        default:
                            objectStack.Push(GameObjectFactory.Instance.CreateGameObject(gameObjectType, gameWorld, location));
                            break;
                    }
                }
            }
            return new EncapsulatedObject<IGameObject>(objectStack);
        }
        //TODO: Add serialize method and change CanWrite 
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
