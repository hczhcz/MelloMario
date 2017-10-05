﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Collections.Generic;
using MelloMario.Controllers;
using MelloMario.Commands;
using MelloMario.MarioObjects;
using MelloMario.Factories;

namespace MelloMario
{
    public class GameScript
    {
        public GameScript()
        {
        }

        public void Bind(List<IController> controllers, Mario mario, IGameObject[,] objects)
        {
            ICommandFactory factory = CommandFactory.Instance;

            foreach (IController controller in controllers)
            {
                if (controller is KeyboardController)
                {
                    //controller.AddCommand(Keys.Escape, factory.CreateGameModelCommand("Pause", objects));
                    //controller.AddCommand(Keys.A, factory.CreateMarioCommand("Jump", mario));
                    controller.AddCommand(Keys.Down, factory.CreateMarioCommand("Crouch", mario));
                    controller.AddCommand(Keys.Up, factory.CreateMarioCommand("Jump", mario));
                    controller.AddCommand(Keys.Left, factory.CreateMarioCommand("Left", mario));
                    controller.AddCommand(Keys.Right, factory.CreateMarioCommand("Right", mario));
                    controller.AddCommand(Keys.Space, factory.CreateMarioCommand("Action", mario));

                    controller.AddCommand(Keys.S, factory.CreateMarioCommand("Crouch", mario));
                    controller.AddCommand(Keys.W, factory.CreateMarioCommand("Jump", mario));
                    controller.AddCommand(Keys.A, factory.CreateMarioCommand("Left", mario));
                    controller.AddCommand(Keys.D, factory.CreateMarioCommand("Right", mario));

                    //commands for changing block/mario state
                    controller.AddCommand(Keys.X, factory.CreateMiscCommand("UsedBlock", objects));
                    controller.AddCommand(Keys.OemQuestion, factory.CreateMiscCommand("QuestionBlock", objects));
                    controller.AddCommand(Keys.B, factory.CreateMiscCommand("BrickBlock", objects));
                    controller.AddCommand(Keys.H, factory.CreateMiscCommand("HiddenBlock", objects));

                    controller.AddCommand(Keys.Y, factory.CreateMarioCommand("StandardState", mario));
                    controller.AddCommand(Keys.U, factory.CreateMarioCommand("SuperState", mario));
                    controller.AddCommand(Keys.I, factory.CreateMarioCommand("FireState", mario));
                    controller.AddCommand(Keys.O, factory.CreateMarioCommand("DeadState", mario));
                }
                else
                if (controller is GamepadController)
                {
                    // controller.AddCommand(Buttons.Start, factory.CreateGameModelCommand("Pause", model));
                    controller.AddCommand(Buttons.A, factory.CreateMarioCommand("Jump", mario));
                    controller.AddCommand(Buttons.DPadDown, factory.CreateMarioCommand("Crouch", mario));
                    controller.AddCommand(Buttons.DPadLeft, factory.CreateMarioCommand("Left", mario));
                    controller.AddCommand(Buttons.DPadRight, factory.CreateMarioCommand("Right", mario));
                    controller.AddCommand(Buttons.B, factory.CreateMarioCommand("Action", mario));
                }
            }
        }
    }
}
