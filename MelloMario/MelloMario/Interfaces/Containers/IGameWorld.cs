﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MelloMario
{
    internal interface IGameWorld : IContainer<IGameObject>
    {
        string Id { get; }
        Rectangle Boundary { get; }

        IEnumerable<IGameObject> ScanNearby(Rectangle range);
        Point GetInitialPoint();
        Point GetRespawnPoint(Point location);
    }
}