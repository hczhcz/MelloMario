﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MelloMario
{
    interface IPlayer
    {
        IGameWorld World { get; }
        ICharacter Character { get; }

        int Coins { get; }
        int Score { get; }
        int Lifes { get; }
        int TimeRemain { get; }

        void AddCoin();
        void AddLife();
        void AddScore(int delta);
        void Init(string type, IGameWorld newWorld, Theming.Listener listener); // TODO: interface should not depend on implementation; make listener an interface?
        void Spawn(IGameWorld newWorld, Point newLocation);
        void Reset(string type, Theming.Listener listener);
        void Win();
        void Update(int time);
        void Draw(int time, SpriteBatch spriteBatch);
    }
}
