﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.MarioObjects.DirectionStates;
using MelloMario.MarioObjects.MovementStates;
using MelloMario.MarioObjects.PowerUpStates;

namespace MelloMario.MarioObjects
{
    class Mario : BaseGameObject
    {
        private IMarioDirectionState directionState;
        public IMarioMovementState movementState;
        public IMarioPowerUpState powerUpState;

        private void OnStateChanged()
        {
        }

        protected override void OnSimulation(GameTime time)
        {
        }

        protected override void OnCollision(IGameObject target)
        {
        }

        public IMarioDirectionState DirectionState
        {
            get
            {
                return directionState;
            }
            set
            {
                directionState = value;
                OnStateChanged();
            }
        }
        public IMarioMovementState MovementState
        {
            get
            {
                return movementState;
            }
            set
            {
                movementState = value;
                OnStateChanged();
            }
        }
        public IMarioPowerUpState PowerUpState
        {
            get
            {
                return powerUpState;
            }
            set
            {
                powerUpState = value;
                OnStateChanged();
            }
        }

        public Mario(Point location) : base(location, new Point(32, 32))
        {
            ShowResized(SpriteFactory.Instance.CreateMarioSprite("FireIdleRight", false), ResizeModeX.Center, ResizeModeY.Bottom);
        }

        public void TurnLeft()
        {
            DirectionState.TurnLeft();
        }
        public void TurnRight()
        {
            DirectionState.TurnRight();
        }
        public void Crouch()
        {
            MovementState.Crouch();
        }
        public void Idle()
        {
            MovementState.Idle();
        }
        public void Jump()
        {
            MovementState.Jump();
        }
        public void Walk()
        {
            MovementState.Walk();
        }
        public void UpgradeToSuper()
        {
            PowerUpState.UpgradeToSuper();
        }
        public void UpgradeToFire()
        {
            PowerUpState.UpgradeToFire();
        }
        public void Downgrade()
        {
            PowerUpState.Downgrade();
        }
        public void Kill()
        {
            PowerUpState.Kill();
        }
    }
}
