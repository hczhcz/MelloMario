﻿namespace MelloMario.Objects.Items.FireFlowerStates
{
    using System;

    [Serializable]
    internal class Normal : BaseState<FireFlower>, IItemState
    {
        public Normal(FireFlower owner) : base(owner)
        {
        }

        public void Show()
        {
        }

        public void Collect()
        {
        }

        public override void Update(int time)
        {
        }
    }
}
