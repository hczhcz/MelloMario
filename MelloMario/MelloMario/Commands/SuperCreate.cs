﻿namespace MelloMario.Commands
{
    class SuperCreate : BaseCommand<ICharacter>
    {
        public SuperCreate(ICharacter character) : base(character)
        {
        }

        public override void Execute()
        {
            Receiver.SuperCreate();
        }
    }
}
