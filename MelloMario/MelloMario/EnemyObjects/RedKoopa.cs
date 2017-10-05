﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.EnemyObjects.KoopaStates;

namespace MelloMario.EnemyObjects
{
    class RedKoopa : BaseGameObject
    {
        private IKoopaState state;

        private void OnStateChanged()
        {
            // TODO: load different sprites base on the state
            ShowSprite(SpriteFactory.Instance.CreateRedKoopaSprite("Normal"));
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

        public RedKoopa(Point location) : base(location, new Point(32, 32))
        {
            state = new RedKoopaNormal(this);
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
