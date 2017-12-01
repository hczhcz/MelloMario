﻿namespace MelloMario.LevelGen.Generators
{
    #region

    using System;
    using System.Collections.Generic;
    using MelloMario.LevelGen.Generators.Terrains;
    using MelloMario.LevelGen.NoiseGenerators;
    using MelloMario.Theming;
    using Microsoft.Xna.Framework;

    #endregion

    internal class Scroll : BaseGenerator
    {
        private readonly IList<IGenerator> terrains;

        public Scroll(
            IListener<IGameObject> scoreListener,
            IListener<ISoundable> soundListener) : base(scoreListener, soundListener)
        {
            terrains = new List<IGenerator>
            {
                new Forest(scoreListener, soundListener),
                new Plain(scoreListener, soundListener),
                new Plain(scoreListener, soundListener), // more plain terrain // TODO: use weighted list
                new Plateau(scoreListener, soundListener),
                new Sky(scoreListener, soundListener),
                new Tunnel(scoreListener, soundListener)
            };
        }

        protected override void OnRequest(IWorld world, Rectangle range)
        {
            // note: top / buttom are locked

            while (world.Boundary.Left > range.Left - Const.GRID)
            {
                Tuple<int, int> pair = PerlinNoiseGenerator.RandomSplit(23333, world.Boundary.Left / Const.GRID - 1, 16);

                Rectangle subRange = new Rectangle(
                    pair.Item1 * Const.GRID,
                    world.Boundary.Top,
                    world.Boundary.Left - pair.Item1 * Const.GRID,
                    world.Boundary.Height);
                terrains[Math.Abs(pair.Item1 * 23333) % terrains.Count].Request(world, subRange); // TODO
                world.Extend(subRange.Width, 0, 0, 0);
            }

            while (world.Boundary.Right < range.Right + Const.GRID)
            {
                Tuple<int, int> pair = PerlinNoiseGenerator.RandomSplit(23333, world.Boundary.Right / Const.GRID, 16);

                Rectangle subRange = new Rectangle(
                    world.Boundary.Right,
                    world.Boundary.Top,
                    pair.Item2 * Const.GRID - world.Boundary.Right,
                    world.Boundary.Height);
                terrains[Math.Abs(pair.Item1 * 23333) % terrains.Count].Request(world, subRange); // TODO
                world.Extend(0, subRange.Width, 0, 0);
            }
        }
    }
}