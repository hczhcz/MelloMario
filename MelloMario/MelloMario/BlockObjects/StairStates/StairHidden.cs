﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario.BlockObjects.StairStates
{
    class StairHidden : IBlockState
    {
        private StairBlock block;

        public StairHidden(StairBlock block)
        {
            this.block = block;
        }

        public void Show()
        {
            block.State = new StairSilent(block);
        }

        public void Destroy()
        {
            //cant destroy stair blocks
        }

        public void Hide()
        {
            //do nothing
        }

        public void UseUp()
        {
            //stairs cant be used
        }

        public void Bump()
        {
            //do nothing
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //do nothing
        }

        public void Update(GameTime gameTime)
        {
            //do nothing
        }
    }
}
