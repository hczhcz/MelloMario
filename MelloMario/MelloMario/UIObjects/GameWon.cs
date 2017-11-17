﻿using MelloMario.Factories;
using MelloMario.Theming;
using Microsoft.Xna.Framework;

namespace MelloMario.UIObjects
{
    class GameWon : BaseUIObject
    {
        private ISprite splashSprite;
        private ISprite textSprite;
        private string Text;

        protected override void OnUpdate(int time)
        {
        }

        protected override void OnDraw(int time)
        {
            splashSprite.Draw(time, new Rectangle(0, 0, GameConst.SCREEN_WIDTH, GameConst.SCREEN_HEIGHT));
            textSprite.Draw(time, new Rectangle(10, 10, 80, 80));
            ISprite text = SpriteFactory.Instance.CreateTextSprite("You won!\n\nPress R to restart\n\nPress Q to quit");
            text.Draw(time, new Rectangle(200, 200, 200, 80));

        }

        public GameWon(IPlayer player) : base(player)
        {
            splashSprite = SpriteFactory.Instance.CreatSplashSprite();
            Text = "MARIO        " + "   WORLD    TIME\n"
                + Player.Score.ToString().PadLeft(6, '0') + "    *"
                + Player.Coins.ToString().PadLeft(2, '0') + "    "
                + "1-1" + "      ";
            textSprite = SpriteFactory.Instance.CreateTextSprite(Text);
        }
    }
}
