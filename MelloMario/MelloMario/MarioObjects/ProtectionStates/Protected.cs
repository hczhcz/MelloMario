﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MelloMario.MarioObjects.ProtectionStates
{
    class Protected : BaseState<Mario>, IMarioProtectionState
    {
        public Protected(Mario owner) : base(owner)
        {
        }

        public void Star()
        {

        }

        public override void Update(GameTime time)
        {

        }
    }
}