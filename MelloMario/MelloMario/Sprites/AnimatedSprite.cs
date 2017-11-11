﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MelloMario.Sprites
{
    class AnimatedSprite : BaseTextureSprite
    {
        private int columns;
        private int rows;

        private int width;
        private int height;

        private int frames;
        private int elapsed;
        private int interval;

        private void UpdateSourceRectangle()
        {
            int x = frames % columns;
            int y = frames / columns;

            ChangeSource(new Point(width * x / columns, height * y / rows));
        }

        protected override void OnAnimate(int time)
        {
            elapsed += time;

            if (elapsed >= interval)
            {
                UpdateSourceRectangle();
                OnFrame();

                frames += 1;
                if (frames == rows * columns)
                {
                    frames = 0;
                }

                elapsed -= interval;
            }
        }

        protected virtual void OnFrame()
        {
            // nothing by default
        }

        public AnimatedSprite(SpriteBatch spriteBatch, Texture2D texture, int interval, int columns, int rows, ZIndex zIndex = ZIndex.item) : base(
            spriteBatch, texture, new Point(), new Point(texture.Width / columns, texture.Height / rows), zIndex
        )
        {
            this.interval = interval;
            this.columns = columns;
            this.rows = rows;
            width = texture.Width;
            height = texture.Height;
            frames = 0;
            elapsed = 0;
        }
    }
}
