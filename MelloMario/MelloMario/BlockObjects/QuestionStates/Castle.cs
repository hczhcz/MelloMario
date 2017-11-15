﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MelloMario.BlockObjects.QuestionStates
{
    class Castle : BaseGameObject
    {
        
        public Castle(IGameWorld world, Point location, Point size) : base(world, location, Point.Zero)
        {
        }

        protected override void OnUpdate(int time)
        {
        }

        protected override void OnSimulation(int time)
        {
        }

        protected override void OnDraw(int time, Rectangle viewport)
        {
        }
    }
}