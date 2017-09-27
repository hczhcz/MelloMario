﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MelloMario.MarioObjects;
using MelloMario.BlockObjects;
using MelloMario.EnemyObjects;

namespace MelloMario
{
    public class GameModel
    {
        private List<IController> controllers;
        private List<IGameObject> objects;
        // TODO: Do we need another abstraction layer for mario's actions?
        private Mario mario;

        public GameModel()
        {
        }

        public void LoadControllers(List<IController> controllers)
        {
            this.controllers = controllers;
        }

        public void Bind(GameScript script)
        {
            script.Bind(controllers, mario, objects);
        }

        public void LoadEntities()
        {
            objects = new List<IGameObject>();
            mario = new Mario(new Vector2(100, 100));
            
            objects.Add(mario);
            //temporary hard coded blocks
            BrickBlock blockHidden = new BrickBlock(new Vector2(300, 200));
            blockHidden.State.ChangeToHidden();
            objects.Add(blockHidden);
            objects.Add(new BrickBlock(new Vector2(100, 200)));
            objects.Add(new QuestionBlock(new Vector2(150, 200)));
            objects.Add(new StairBlock(new Vector2(200, 200)));
            objects.Add(new FloorBlock(new Vector2(250, 200)));
            objects.Add(new Goomba(new Vector2(100, 300)));
        }

        public void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            foreach (IGameObject gameObject in objects)
            {
                gameObject.Update(gameTime);
            }

        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject gameObject in objects)
            {
                gameObject.Draw(spriteBatch);
            }
        }
    }
}