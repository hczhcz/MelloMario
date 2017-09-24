﻿using MelloMario.Commands;

namespace MelloMario
{
    internal class StdStateCommand : ICommand
    {
        private GameModel model;

        public StdStateCommand(GameModel model)
        {
            this.model = model;
        }

        public void Execute()
        {
            model.Mario.changeToStandardState();
        }
    }
}