﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario.Sprites
{
    class StaticSprite : BaseTextureSprite
    {
        protected override void OnAnimate(int time)
        {
            // Do nothing
        }

        public StaticSprite(SpriteBatch spriteBatch, Texture2D texture, ZIndex activeZIndex = ZIndex.item) : base(
            spriteBatch, texture, new Point(), new Point(texture.Width, texture.Height), activeZIndex
        )
        {
        }
    }
}
