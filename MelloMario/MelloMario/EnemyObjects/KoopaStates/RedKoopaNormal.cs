﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloMario.EnemyObjects.KoopaStates
{
    class RedKoopaNormal : IKoopaState
    {
        private ISprite redKoopa;
        private RedKoopa enemyRedKoopa;
        public RedKoopaNormal(RedKoopa koopaRed)
        {
            enemyRedKoopa = koopaRed;
            redKoopa = SpriteFactory.Instance.CreateRedKoopaSprite("Normal");
        }
        public void Show()
        {

        }

        public void JumpOn()
        {
            enemyRedKoopa.State = new RedKoopaJumpOn(enemyRedKoopa);
        }

        public void Defeat()
        {
            enemyRedKoopa.State = new RedKoopaDefeated(enemyRedKoopa);
        }

        public void Update(GameTime gameTime)
        {
            redKoopa.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            redKoopa.Draw(spriteBatch, location);
        }
    }
}
