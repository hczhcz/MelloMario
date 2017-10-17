﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.ItemObjects.FireFlowerStates;

namespace MelloMario.ItemObjects
{
    class FireFlower : BaseGameObject
    {
        private IItemState state;

        private void OnStateChanged()
        {
            ShowSprite(SpriteFactory.Instance.CreateFireFlowerSprite());
        }

        protected override void OnSimulation(GameTime time)
        {
        }

        protected override void OnCollision(IGameObject target, CollisionMode mode)
        {
        }

        protected override void OnOut(CollisionMode mode)
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
        public FireFlower(IGameWorld world, Point location, bool isUnveil) : base(world, location, new Point(32, 32))
        {
            if(isUnveil)
            {
                state = new Unveil(this);
            }
            else
            {
                state = new Normal(this);
            }
            OnStateChanged();
        }
        public FireFlower(IGameWorld world, Point location) : this (world, location, false)
        {
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
