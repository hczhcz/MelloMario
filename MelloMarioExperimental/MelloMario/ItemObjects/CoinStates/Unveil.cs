﻿using Microsoft.Xna.Framework.Audio;
using MelloMario.Sounds;

namespace MelloMario.ItemObjects.CoinStates
{
    class Unveil : BaseTimedState<Coin>, IItemState
    {
        private float elapsed;
        private float realOffset;
        private SoundEffectInstance coinSound;

        protected override void OnTimer(int time)
        {
            Owner.Collect();
        }

        public Unveil(Coin owner) : base(owner, 250)
        {
            elapsed = 0f;
            coinSound = SoundController.Coin.CreateInstance();
        }

        public void Show()
        {
            Owner.State = new Normal(Owner);
        }

        public void Collect()
        {
        }

        public override void Update(int time)
        {
            coinSound.Play();
            elapsed += time;
            realOffset += 128 * time / 500f;

            while (realOffset > 1)
            {
                Owner.UnveilMove(-1);
                --realOffset;
            }

            base.Update(time);
        }
    }
}