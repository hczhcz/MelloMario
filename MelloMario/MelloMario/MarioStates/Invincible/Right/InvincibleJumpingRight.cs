﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario
{
    class InvincibleJumpingRight : IMarioState
    {
        Mario mario;
        ContentManager content;
        bool setStatic;
        ISpriteFactory spriteCreation;
        ISprite sprite;
        public InvincibleJumpingRight(Mario mario, ContentManager content)
        {
            this.mario = mario;
            this.content = content;
            setStatic = true;
            spriteCreation = new SpriteFactory();
            sprite = spriteCreation.createSprite("InvincibleJumpingRight", setStatic, content);


        }

        public void die()
        {
            mario.setMarioState(new Dead(mario, content));
        }

        public void changeToFireState()
        {
            mario.setMarioState(new FireJumpingRight(mario, content));
        }

        public void changeToStandardState()
        {
            mario.setMarioState(new StandardJumpingRight(mario,content));
        }

        public void changeToInvincibleState()
        {
            
        }

        public void changeToSuperState()
        {
            mario.setMarioState(new SuperJumpingRight(mario,content));
        }

        public void down()
        {
            mario.setMarioState(new InvincibleIdleRight(mario,content));
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch,location);
        }

        public void fall()
        {
            mario.setMarioState(new InvincibleFallingRight(mario,content));
        }

        public void idle()
        {
            mario.setMarioState(new InvincibleIdleRight(mario,content));
        }

        public void left()
        {
            mario.setMarioState(new InvincibleIdleLeft(mario,content));
        }

        public void right()
        {
            //nothing to do here
        }

        public void up()
        {
            //nothing to do here
        }

        public void Update()
        {
            
        }
    }
}
