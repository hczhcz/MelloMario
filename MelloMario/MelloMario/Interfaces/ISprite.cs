﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario
{
    interface ISprite
    {
        Texture2D texture { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch,Vector2 location);
        
    }
}
