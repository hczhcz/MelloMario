﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloMario
{
    interface ICommandFactory
    {
        ICommand createGameModelCommand(string actionName, GameModel model);
        ICommand createMarioCommand(string actionName, MarioObjects.Mario mario);
    }
}
