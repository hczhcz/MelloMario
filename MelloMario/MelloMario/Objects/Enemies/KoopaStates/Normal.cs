﻿namespace MelloMario.Objects.Enemies.KoopaStates
{
    using System;

    [Serializable]
    internal class Normal : BaseState<Koopa>, IKoopaState
    {
        public Normal(Koopa owner) : base(owner)
        {
        }

        public void Show()
        {
        }

        public void JumpOn()
        {
            Owner.State = new Defeated(Owner);
        }

        public void Defeat()
        {
            Owner.State = new Defeated(Owner);
        }

        public override void Update(int time)
        {
        }

        public void Pushed()
        {
            //can't push normal koopa
        }
    }
}
