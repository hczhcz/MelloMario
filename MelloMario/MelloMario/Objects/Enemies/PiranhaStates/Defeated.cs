﻿using MelloMario.Interfaces.Objects.States;

namespace MelloMario.Objects.Enemies.PiranhaStates
{
    internal class Defeated : BaseState<Piranha>, IPiranhaState
    {
        public Defeated(Piranha owner) : base(owner) { }

        public void Defeat()
        {
            //Do nothing
        }

        public override void Update(int time) { }
    }
}
