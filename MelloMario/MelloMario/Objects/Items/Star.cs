﻿namespace MelloMario.Objects.Items
{
    #region

    using MelloMario.Factories;
    using MelloMario.Objects.Blocks;
    using MelloMario.Objects.Blocks.BrickStates;
    using MelloMario.Objects.Characters;
    using MelloMario.Objects.Items.StarStates;
    using MelloMario.Objects.UserInterfaces;
    using MelloMario.Theming;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    internal class Star : BasePhysicalObject
    {
        private bool collected;
        private IItemState state;

        public Star(
            IGameWorld world,
            Point location,
            IListener<IGameObject> listener,
            bool isUnveil = false) : base(world, location, listener, new Point(32, 32), 32)
        {
            collected = false;

            if (isUnveil)
            {
                state = new Unveil(this);
                UpdateSprite();
                RemoveSelf();
            }
            else
            {
                state = new StarStates.Normal(this);
                UpdateSprite();
            }
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
                UpdateSprite();
            }
        }

        private void UpdateSprite()
        {
            ShowSprite(SpriteFactory.Instance.CreateStarSprite());
        }

        protected override void OnUpdate(int time)
        {
            state.Update(time);
        }

        protected override void OnSimulation(int time)
        {
            if (state is StarStates.Normal)
            {
                ApplyGravity();

                if (Facing == FacingMode.left)
                {
                    SetHorizontalVelocity(-Const.VELOCITY_STAR_H);
                }
                else
                {
                    SetHorizontalVelocity(Const.VELOCITY_STAR_H);
                }
            }

            base.OnSimulation(time);
        }

        protected override void OnCollision(
            IGameObject target,
            CollisionMode mode,
            CollisionMode modePassive,
            CornerMode corner,
            CornerMode cornerPassive)
        {
            if (state is StarStates.Normal)
            {
                switch (target)
                {
                    case Mario mario:
                        if (state is OneUpMushroomStates.Normal)
                        {
                            Collect();
                        }
                        break;
                    case Brick brick when brick.State is Hidden:
                        break;
                    case Question question when question.State is Blocks.QuestionStates.Hidden:
                        break;
                    case IGameObject obj when target is Brick
                    || target is Question
                    || target is Floor
                    || target is Pipeline
                    || target is Stair:
                        if (mode == CollisionMode.Top)
                        {
                            Bounce(mode, new Vector2());
                        }
                        if (mode == CollisionMode.Left
                            || mode == CollisionMode.InnerLeft && corner == CornerMode.Center)
                        {
                            Bounce(mode, new Vector2(), 1);
                            Facing = FacingMode.right;
                        }
                        else if (mode == CollisionMode.Right
                            || mode == CollisionMode.InnerRight && corner == CornerMode.Center)
                        {
                            Bounce(mode, new Vector2(), 1);
                            Facing = FacingMode.left;
                        }
                        if (mode == CollisionMode.Bottom
                            || mode == CollisionMode.InnerBottom && corner == CornerMode.Center)
                        {
                            Bounce(mode, new Vector2());
                            ApplyVerticalFriction(Const.VELOCITY_STAR_V);
                        }
                        break;
                }
            }
        }

        protected override void OnCollideWorld(CollisionMode mode, CollisionMode modePassive)
        {
        }

        protected override void OnDraw(int time, SpriteBatch spriteBatch)
        {
        }

        public void Collect()
        {
            if (!collected)
            {
                //TODO:Move this into soundcontroller
                //SoundManager.SizeUp.Play();
                ScorePoints(Const.SCORE_POWER_UP);
                new PopingUpPoints(World, Boundary.Location, Const.SCORE_POWER_UP);
            }
            collected = true;
            RemoveSelf();
            //State.Collect();
        }

        public void UnveilMove(int delta)
        {
            Move(new Point(0, delta));
        }
    }
}
