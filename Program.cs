using System;
using System.IO;
using System.Text.Json;

namespace C1gameProject
{
    public static class Program
    {
        public static Game1 game;
        public static Player player;
        static void Main()
        {
            using (game = new Game1())
                game.Run();

           
        }
    }
}
