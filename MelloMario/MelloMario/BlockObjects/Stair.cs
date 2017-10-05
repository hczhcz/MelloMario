﻿using Microsoft.Xna.Framework;
using MelloMario.Factories;
using MelloMario.BlockObjects.StairStates;

namespace MelloMario.BlockObjects
{
    class Stair : BaseGameObject
    {
        private IBlockState state;

        private void OnStateChanged()
        {
            if (state is StairHidden)
            {
                HideSprite();
            }
            if (state is StairNormal)
            {
                ShowSprite(SpriteFactory.Instance.CreateStairSprite());
            }
        }

        protected override void OnSimulation(GameTime time)
        {
        }

        protected override void OnCollision(IGameObject target)
        {
        }

        public IBlockState State
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

        public Stair(Point location) : base(location, new Point(32, 32))
        {
            state = new StairNormal(this);
            OnStateChanged();
        }

        public void Show()
        {
            State.Show();
        }
        public void Hide()
        {
            State.Hide();
        }
        public void Bump()
        {
            State.Bump();
        }
        public void Destroy()
        {
            State.Destroy();
        }
        public void UseUp()
        {
            State.UseUp();
        }
    }
}
