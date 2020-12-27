using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Obstacle
    {
        private int col = 0;
        private int row = 0;

        private void RenderCar()
        {
            Console.WriteLine("\u2580\u2580");
        }

        private void RenderBus()
        {
            Console.WriteLine("\u2580\u2580\u2580\u2580");
        }

        private void RenderTruck()
        {
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580");
        }

        public void RenderSafeZone()
        {
            col = 0;
            row = 25;
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580");

        }

        private void MoveObstacles()
        {

        }
    }
}
