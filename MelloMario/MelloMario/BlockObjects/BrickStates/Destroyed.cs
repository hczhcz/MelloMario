﻿using Microsoft.Xna.Framework;
using MelloMario.MarioObjects;

namespace MelloMario.BlockObjects.BrickStates
{
    class Destroyed : BaseTimedState<Brick>, IBlockState
    {
        protected override void OnTimer(int time)
        {
            Owner.Remove();
        }

        public Destroyed(Brick owner) : base(owner, 1000)
        {
        }

        public void Show()
        {
            Owner.State = new Normal(Owner);
        }

        public void Hide()
        {
            Owner.State = new Hidden(Owner);
        }

        public void Bump(Mario mario)
        {
            // do nothing
        }
    }
}
