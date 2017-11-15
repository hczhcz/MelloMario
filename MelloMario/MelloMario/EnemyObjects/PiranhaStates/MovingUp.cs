﻿using MelloMario.Interfaces.Objects.States;

namespace MelloMario.EnemyObjects.PiranhaStates
{
    class MovingUp : BaseState<Piranha>, IPiranhaState
    {
        private int initialY;
        public override void Update(int time)
        {
            if (Owner.Boundary.Y <= initialY - 48)
            {
                Owner.State = new Show(Owner);
            }
        }

        public void Defeat()
        {
            Owner.State = new Defeated(Owner);
        }
        public MovingUp(Piranha owner) : base(owner)
        {
            initialY = owner.Boundary.Y;
        }
    }
}
