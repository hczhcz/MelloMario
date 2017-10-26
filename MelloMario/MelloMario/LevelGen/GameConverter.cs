﻿using MelloMario.Factories;
using MelloMario.MarioObjects;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloMario.LevelGen
{
    //Using for deserialize json to a single GameWorld(Map)
    class GameConverter : JsonConverter
    {
        private string index;
        private GameModel gameModel;
        JsonSerializer serializers;

        private GameWorld world;
        private IGameCharacter character;
        public GameConverter(string index, GameModel gameModel)
        {
            this.index = index;
            this.gameModel = gameModel;
            serializers = new JsonSerializer();
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken jsonToken = JToken.Load(reader);
            JToken MapList = jsonToken.Value<JToken>("Maps");
            JToken MapToBeLoaded = null;
            //Get item "Maps"
            foreach (var obj in MapList)
            {
                if (obj.Value<String>("Index") == index)
                {
                    MapToBeLoaded = obj;
                    break;
                }
            }
            Point mapSize = MapToBeLoaded.Value<JToken>("Size").ToObject<Point>();


            IList<JToken> Structures = MapToBeLoaded.Value<JToken>("Structures").ToList();
            world = new GameWorld(MapToBeLoaded.Value<int>("Grid"), mapSize);
            serializers.Converters.Add(new BaseGameObjectConverter(world));
            serializers.Converters.Add(new CharacterConverter(world));

            foreach (var jToken in Structures)
            {
                var gameObjs = jToken.ToObject<EncapsulatedObject<IGameObject>>(serializers);
                foreach (var gameObj in gameObjs.RealObj)
                {
                    world.AddObject(gameObj);
                }
            }

            IList<JToken> Characters = MapToBeLoaded.Value<JToken>("Characters").ToList();
            foreach (var obj in Characters)
            {
                var temp = obj.ToObject<EncapsulatedObject<PlayerMario>>(serializers);
                character = temp.RealObj.Pop();
                world.AddObject(character);
                //TODO: Add support for IEnumerables<IGameCharacter>
                //else if (temp is IEnumerable<IGameCharacter> gameCharacters)
                //{
                //    foreach (var gameChar in gameCharacters)
                //    {
                //        gameWorld.AddObject(gameChar);
                //    }
                //}
            }
            return new Tuple<IGameWorld, IGameCharacter>(world, character);
        }
        //TODO: Add serialize method and change CanWrite 
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
