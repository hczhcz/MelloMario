﻿namespace MelloMario.Commands
{
    class Reset : BaseCommand<IGameModel>
    {
        public Reset(IGameModel model) : base(model)
        {
        }

        public override void Execute()
        {
            Receiver.Reset();
        }
    }
}
