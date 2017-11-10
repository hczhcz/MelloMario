﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MelloMario.Sprites
{
    abstract class BaseTextureSprite : BaseSprite
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Point source;
        private Color color;

        protected abstract void OnAnimate(int time);

        protected void ChangeSource(Point newSource)
        {
            source = newSource;
        }

        protected void ChangeColor(Color newColor)
        {
            color = newColor;
        }

        protected override void OnDraw(int time, Rectangle destination)
        {
            OnAnimate(time);

            // TODO
            //switch (zIndex)
            //{
            //    case ZIndex.hud:
            //        offset.X = 0;
            //        offset.Y = 0;
            //        break;
            //    case ZIndex.background0:
            //        offset.X = offset.X / 3;
            //        offset.Y = offset.Y * 2 / 3;
            //        break;
            //    case ZIndex.background1:
            //        offset.X = offset.X / 2;
            //        offset.Y = offset.Y * 3 / 4;
            //        break;
            //    case ZIndex.background2:
            //        offset.X = offset.X * 2 / 3;
            //        break;
            //    case ZIndex.background3:
            //        offset.X = offset.X * 3 / 4;
            //        break;
            //}

            spriteBatch.Draw(texture, destination, new Rectangle(source, PixelSize), color);
        }

        public BaseTextureSprite(SpriteBatch spriteBatch, Texture2D texture, Point source, Point size, ZIndex activeZIndex) : base(size, activeZIndex)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.source = source;
            color = Color.White;
        }
    }
}
