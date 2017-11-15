﻿using MelloMario.Theming;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario.Sprites
{
    class FlashingAnimatedSprite : AnimatedSprite
    {
        protected override void OnFrame()
        {
            Toggle();
        }

        public FlashingAnimatedSprite(SpriteBatch spriteBatch, Texture2D texture, int columns, int rows, int x = 0, int y = 0, int width = 2, int height = 2, int interval = GameConst.ANIMATION_INTERVAL, ZIndex zIndex = ZIndex.item) : base(
            spriteBatch, texture, columns, rows, x, y, width, height, interval, zIndex
        )
        {
        }
    }
}