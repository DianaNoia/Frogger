using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    class Obstacle
    {
        private int col;
        private int row;

        // Lista de Tuples
        private List<(int col, int row)> cars = new List<(int, int)>();
        private List<(int col, int row)> buses = new List<(int, int)>();

        public Obstacle()
        {
            col = 0;
            row = 0;

            cars.Add((col, 22));
            cars.Add((15, 22));
            buses.Add((46, 21));
            cars.Add((col, 20));
            cars.Add((15, 20));
            cars.Add((30, 20));
            buses.Add((46, 19));
            buses.Add((20, 19));

        }

        private void RenderCar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u2580\u2580\u2580\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void RenderBus()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RenderSafeZone()
        {
            col = 0;
            row = 12;
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");

        }

        public void MoveObstacles()
        {
            Console.SetCursorPosition(col, row);

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].col + 1 == 50)
                {
                    cars[i] = (0, cars[i].row);
                }
                cars[i] = (cars[i].col + 1, cars[i].row);
                Console.SetCursorPosition(cars[i].col, cars[i].row);
                RenderCar();

            }

            for (int i = 0; i < buses.Count; i++)
            {
                if (buses[i].col == 0)
                {
                    buses[i] = (44, buses[i].row);
                }
                buses[i] = (buses[i].col - 1, buses[i].row);
                Console.SetCursorPosition(buses[i].col, buses[i].row);
                RenderBus();


            }
        }
    }
}
