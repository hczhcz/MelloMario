﻿using Microsoft.Xna.Framework;

namespace MelloMario.MarioObjects.MovementStates
{
    class Jumping : BaseTimedState<Mario>, IMarioMovementState
    {
        private IMarioMovementState previous;
        private bool finished;

        protected override void OnTimer(GameTime time)
        {
            finished = true;
        }

        public bool Finished
        {
            get
            {
                return finished;
            }
            set
            {
                finished = value; // TODO: use a better solution for "free jump/fall"
            }
        }

        public Jumping(Mario owner) : base(owner, 250)
        {
            previous = owner.MovementState;
            finished = false;
        }

        public void Crouch()
        {
            Owner.MovementState = new Crouching(Owner);
        }
        public void Idle()
        {
            previous = new Standing(Owner);
        }
        public void Land()
        {
            Owner.MovementState = previous;
        }
        public void Jump()
        {

        }
        public void Walk()
        {
            previous = new Walking(Owner);
        }
    }
}
