using System;

namespace Frogger
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.GameLoop();
        }
    }
}