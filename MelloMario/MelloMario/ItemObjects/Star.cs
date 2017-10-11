﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.ItemObjects.StarStates;

namespace MelloMario.ItemObjects
{
    class Star : BaseGameObject
    {
        private IItemState state;

        private void OnStateChanged()
        {
            ShowSprite(SpriteFactory.Instance.CreateStarSprite());
        }

        protected override void OnSimulation(GameTime time)
        {
        }

        protected override void OnCollision(IGameObject target, CollisionMode mode)
        {
        }

        public IItemState State
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

        public Star(Point location) : base(location, new Point(32, 32))
        {
            state = new Normal(this);
            OnStateChanged();
        }

        public void Show()
        {
            State.Show();
        }
        public void Collect()
        {
            State.Collect();
        }
    }
}
