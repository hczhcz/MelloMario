﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.EnemyObjects.KoopaStates;

namespace MelloMario.EnemyObjects
{
    class GreenKoopa : BaseGameObject
    {
        private IKoopaState state;

        private void OnStateChanged()
        {
            // TODO: load different sprites base on the state
            ShowSprite(SpriteFactory.Instance.CreateGreenKoopaSprite("Normal"));
        }

        protected override void OnSimulation(GameTime time)
        {
        }

        protected override void OnCollision(IGameObject target)
        {
        }

        public IKoopaState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnStateChanged();
            }
        }

        public GreenKoopa(Point location) : base(location, new Point(32, 32))
        {
            state = new GreenKoopaNormal(this);
            OnStateChanged();
        }

        public void Show()
        {
            State.Show();
        }
        public void JumpOn()
        {
            State.JumpOn();
        }
        public void Defeat()
        {
            State.Defeat();
        }
    }
}
