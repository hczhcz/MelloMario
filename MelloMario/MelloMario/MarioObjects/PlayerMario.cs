﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.MarioObjects.MovementStates;
using MelloMario.MarioObjects.PowerUpStates;
using MelloMario.MarioObjects.ProtectionStates;
using MelloMario.BlockObjects;
using MelloMario.EnemyObjects;

namespace MelloMario.MarioObjects
{
    class PlayerMario : Mario, IGameCharacter
    {
        private Vector2 userInput;

        protected override void OnUpdate(GameTime time)
        {
            ApplyForce(userInput);
            userInput.X = 0;
            userInput.Y = 0;

            base.OnUpdate(time);
        }

        public Rectangle Viewport
        {
            get
            {
                // TODO
                return new Rectangle(0, 0, 0, 0);
            }
        }

        public PlayerMario(IGameWorld world, Point location) : base(world, location)
        {
        }

        public void Left()
        {
            if (!(MovementState is Crouching))
            {
                userInput.X -= FORCE_INPUT;
            }
            if (MovementState is Standing)
            {
                MovementState.Walk();
            }
        }

        public void LeftPress()
        {
            if (Facing == FacingMode.right)
            {
                ChangeFacing(FacingMode.left);
            }
        }

        public void LeftRelease()
        {
            if (MovementState is Walking)
            {
                MovementState.Idle();
            }
        }

        public void Right()
        {
            if (!(MovementState is Crouching))
            {
                userInput.X += FORCE_INPUT;
            }
            if (MovementState is Standing)
            {
                MovementState.Walk();
            }
        }

        public void RightPress()
        {
            if (Facing == FacingMode.left)
            {
                ChangeFacing(FacingMode.right);
            }
        }

        public void RightRelease()
        {
            if (MovementState is Walking)
            {
                MovementState.Idle();
            }
        }

        public void Jump()
        {
            userInput.Y -= FORCE_INPUT;
            userInput.Y -= FORCE_G;

            MovementState.Jump();
        }

        public void JumpPress()
        {
            // TODO: add accelerate time limit
        }

        public void JumpRelease()
        {
        }

        public void Crouch()
        {
            MovementState.Crouch();
        }

        public void CrouchPress()
        {
        }

        public void CrouchRelease()
        {
            MovementState.Idle();
        }

        public void Action()
        {
            throw new System.NotImplementedException();
        }
    }
}
