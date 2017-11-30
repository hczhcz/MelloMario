﻿namespace MelloMario.Objects.Enemies.ThwompStates
{
    #region

    using System;

    #endregion

    internal class MovingDown : BaseState<Thwomp>, IState
    {
        private readonly int initialY;

        public MovingDown(Thwomp owner) : base(owner)
        {
            initialY = owner.Boundary.Y;
        }

        public override void Update(int time)
        {
            if (Owner.Boundary.Y >= initialY)
            {
                Owner.State = new Normal(Owner);
            }
        }
    }
}
