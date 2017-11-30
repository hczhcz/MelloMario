﻿namespace MelloMario
{
    #region

    using System;
    using Microsoft.Xna.Framework;

    #endregion

#if WINDOWS || LINUX
    /// <summary>
    ///     The main class.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Game game = new Game1();
            //Game game = new NoiseGame();
            game.Run();
            game.Dispose();
        }
    }
#endif
}
