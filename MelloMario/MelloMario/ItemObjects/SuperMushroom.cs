﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.ItemObjects.SuperMushroomStates;

namespace MelloMario.ItemObjects
{
    class SuperMushroom : BaseGameObject
    {
        private IItemState state;

        private void OnStateChanged()
        {
            // TODO: load different sprites base on the state
            ShowSprite(SpriteFactory.Instance.CreateSuperMushroomSprite());
        }

        protected override void OnSimulation(GameTime time)
        {
        }

        protected override void OnCollision(IGameObject target)
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

        public SuperMushroom(Point location) : base(location, new Point(32, 32))
        {
            state = new SuperMushroomNormal(this);
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
