﻿using MelloMario.Objects.Characters;

namespace MelloMario.Objects.Blocks.QuestionStates
{
    internal class Normal : BaseState<Question>, IBlockState
    {
        public Normal(Question owner) : base(owner) { }

        public void Show()
        {
            //do nothing
        }

        public void Hide()
        {
            Owner.State = new Hidden(Owner);
        }

        public void Bump(Mario mario)
        {
            Owner.State = new Bumped(Owner);
        }

        public override void Update(int time) { }
    }
}