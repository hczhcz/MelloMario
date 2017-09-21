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
    class InvincibleWalkingRight : IMarioState
    {
        Mario mario;
        ISpriteFactory spriteCreation;
        ISprite sprite;
        bool setToStatic;
        ContentManager content;

        public InvincibleWalkingRight(Mario newMario, ContentManager content)
        {
            mario = newMario;
            spriteCreation = new SpriteFactory();
            setToStatic = false;
            sprite = spriteCreation.createSprite("InvincibleWalkingRight", setToStatic, content);
            this.content = content;
        }

        public void die()
        {
            mario.setMarioState(new Dead(mario, content));
        }

        public void changeToFireState()
        {
            //nothing here
        }

        public void changeToStandardState()
        {
            mario.setMarioState(new StandardWalkingRight(mario,content));
        }

        public void changeToInvincibleState()
        {
            mario.setMarioState(new FireWalkingRight(mario, content));
        }

        public void changeToSuperState()
        {
            mario.setMarioState(new SuperWalkingRight(mario,content));
        }

        public void down()
        {
            mario.setMarioState(new InvincibleCrouchingRight(mario,content));
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch,location);
        }

        public void fall()
        {
            //nothing here
        }

        public void idle()
        {
            mario.setMarioState(new InvincibleIdleRight(mario,content));
        }

        public void left()
        {
            mario.setMarioState(new InvincibleWalkingLeft(mario,content));
        }

        public void right() { 
     
           //nothing here
        }

        public void up()
        {
            mario.setMarioState(new InvincibleJumpingRight(mario,content));
        }

        public void Update()
        {
            
        }
    }
}
