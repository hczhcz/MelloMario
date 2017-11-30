﻿namespace MelloMario.LevelGen.Terrains
{
    #region

    using System;
    using MelloMario.Objects.Blocks;
    using MelloMario.Theming;
    using Microsoft.Xna.Framework;

    #endregion

    internal class Forest : IGenerator
    {
        private readonly IListener<IGameObject> listener;

        public Forest(IListener<IGameObject> listener)
        {
            this.listener = listener;
        }

        public void Request(IWorld world, Rectangle range)
        {
            for (int i = 1; i < 2 + Math.Abs(range.Left * 23456789 / 32767) % 5; ++i)
            {
                world.Add(new Floor(world, new Point(range.Left, range.Bottom - i * Const.GRID), listener));
            }
        }
    }
}
