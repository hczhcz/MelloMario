﻿using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using MelloMario.Factories;

namespace MelloMario.Scripts
{
    class PlayingScript : IScript
    {
        public PlayingScript()
        {
        }

        public void Bind(IEnumerable<IController> controllers, IGameCharacter character, IGameModel model)
        {
            ICommandFactory factory = CommandFactory.Instance;

            foreach (IController controller in controllers)
            {
                controller.Reset();

                controller.AddCommand(Keys.Space, factory.CreateGameCharacterCommand("Action", character)); // Needs to be implemented
                controller.AddCommand(Keys.Down, factory.CreateGameCharacterCommand("Crouch", character), KeyBehavior.hold);
                controller.AddCommand(Keys.Down, factory.CreateGameCharacterCommand("CrouchPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.Down, factory.CreateGameCharacterCommand("CrouchRelease", character), KeyBehavior.release);
                controller.AddCommand(Keys.Up, factory.CreateGameCharacterCommand("Jump", character), KeyBehavior.hold);
                controller.AddCommand(Keys.Up, factory.CreateGameCharacterCommand("JumpPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.Up, factory.CreateGameCharacterCommand("JumpRelease", character), KeyBehavior.release);
                controller.AddCommand(Keys.Left, factory.CreateGameCharacterCommand("Left", character), KeyBehavior.hold);
                controller.AddCommand(Keys.Left, factory.CreateGameCharacterCommand("LeftPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.Left, factory.CreateGameCharacterCommand("LeftRelease", character), KeyBehavior.release);
                controller.AddCommand(Keys.Right, factory.CreateGameCharacterCommand("Right", character), KeyBehavior.hold);
                controller.AddCommand(Keys.Right, factory.CreateGameCharacterCommand("RightPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.Right, factory.CreateGameCharacterCommand("RightRelease", character), KeyBehavior.release);

                controller.AddCommand(Keys.S, factory.CreateGameCharacterCommand("Crouch", character), KeyBehavior.hold);
                controller.AddCommand(Keys.S, factory.CreateGameCharacterCommand("CrouchPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.S, factory.CreateGameCharacterCommand("CrouchRelease", character), KeyBehavior.release);
                controller.AddCommand(Keys.Z, factory.CreateGameCharacterCommand("Jump", character), KeyBehavior.hold);
                controller.AddCommand(Keys.Z, factory.CreateGameCharacterCommand("JumpPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.Z, factory.CreateGameCharacterCommand("JumpRelease", character), KeyBehavior.release);
                controller.AddCommand(Keys.A, factory.CreateGameCharacterCommand("Left", character), KeyBehavior.hold);
                controller.AddCommand(Keys.A, factory.CreateGameCharacterCommand("LeftPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.A, factory.CreateGameCharacterCommand("LeftRelease", character), KeyBehavior.release);
                controller.AddCommand(Keys.D, factory.CreateGameCharacterCommand("Right", character), KeyBehavior.hold);
                controller.AddCommand(Keys.D, factory.CreateGameCharacterCommand("RightPress", character), KeyBehavior.press);
                controller.AddCommand(Keys.D, factory.CreateGameCharacterCommand("RightRelease", character), KeyBehavior.release);

                // game control commands
                controller.AddCommand(Keys.Q, factory.CreateGameControlCommand("Quit", model), KeyBehavior.press);
                controller.AddCommand(Keys.R, factory.CreateGameControlCommand("Reset", model), KeyBehavior.press);
                controller.AddCommand(Keys.P, factory.CreateGameControlCommand("Pause", model), KeyBehavior.press);
                controller.AddCommand(Keys.F12, factory.CreateGameControlCommand("ToggleFullScreen", model), KeyBehavior.press);

                controller.AddCommand(Buttons.B, factory.CreateGameCharacterCommand("Action", character));
                controller.AddCommand(Buttons.DPadDown, factory.CreateGameCharacterCommand("Crouch", character), KeyBehavior.hold);
                controller.AddCommand(Buttons.DPadDown, factory.CreateGameCharacterCommand("CrouchPress", character), KeyBehavior.press);
                controller.AddCommand(Buttons.DPadDown, factory.CreateGameCharacterCommand("CrouchRelease", character), KeyBehavior.release);
                controller.AddCommand(Buttons.A, factory.CreateGameCharacterCommand("Jump", character), KeyBehavior.hold);
                controller.AddCommand(Buttons.A, factory.CreateGameCharacterCommand("JumpPress", character), KeyBehavior.press);
                controller.AddCommand(Buttons.A, factory.CreateGameCharacterCommand("JumpRelease", character), KeyBehavior.release);
                controller.AddCommand(Buttons.DPadLeft, factory.CreateGameCharacterCommand("Left", character), KeyBehavior.hold);
                controller.AddCommand(Buttons.DPadLeft, factory.CreateGameCharacterCommand("LeftPress", character), KeyBehavior.press);
                controller.AddCommand(Buttons.DPadLeft, factory.CreateGameCharacterCommand("LeftRelease", character), KeyBehavior.release);
                controller.AddCommand(Buttons.DPadRight, factory.CreateGameCharacterCommand("Right", character), KeyBehavior.hold);
                controller.AddCommand(Buttons.DPadRight, factory.CreateGameCharacterCommand("RightPress", character), KeyBehavior.press);
                controller.AddCommand(Buttons.DPadRight, factory.CreateGameCharacterCommand("RightRelease", character), KeyBehavior.release);

            }
        }
    }
}