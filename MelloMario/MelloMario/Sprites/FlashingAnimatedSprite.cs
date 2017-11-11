﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace MelloMario.Sprites
{
    class FlashingAnimatedSprite : AnimatedSprite
    {
        protected override void OnFrame()
        {
            Toggle();
        }

        public FlashingAnimatedSprite(SpriteBatch spriteBatch, Texture2D texture, int interval, int columns, int rows, ZIndex activeZIndex = ZIndex.item) : base(
            spriteBatch, texture, interval, columns, rows, activeZIndex
        )
        {
        }
    }
}
