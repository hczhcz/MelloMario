﻿namespace MelloMario.Objects.Items.SuperMushroomStates
{
    using System;

    [Serializable]
    internal class Normal : BaseState<SuperMushroom>, IItemState
    {
        public Normal(SuperMushroom owner) : base(owner)
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
