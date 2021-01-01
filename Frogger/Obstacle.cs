﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    class Obstacle
    {
        private int col;
        private int row;
        private int lives = 3;
        private int finish = 0;

        private bool passed = false;
        private bool finished = false;

        public int Points { get; set; } = 0;
        public bool GameOver { get; set; }

        // Lista de Tuples
        private List<(int col, int row)> cars = new List<(int, int)>();
        private List<(int col, int row)> buses = new List<(int, int)>();

        public Obstacle()
        {
            col = 0;
            row = 0;

            cars.Add((col, 22));
            cars.Add((25, 22));
            buses.Add((46, 21));
            buses.Add((20, 21));
            cars.Add((4, 20));
            cars.Add((15, 20));
            cars.Add((30, 20));
            buses.Add((40, 19));
            buses.Add((26, 19));
            buses.Add((5, 19));
            cars.Add((1, 18));
            cars.Add((10, 18));
            cars.Add((20, 18));
            cars.Add((32, 18));
            buses.Add((18, 17));
            buses.Add((2, 17));
            cars.Add((4, 15));
            cars.Add((20, 15));
            cars.Add((35, 15));
            buses.Add((6, 14));
            buses.Add((26, 14));
            cars.Add((10, 13));
            cars.Add((26, 13));
            buses.Add((20, 12));
            buses.Add((30, 12));
            buses.Add((5, 12));
            cars.Add((23, 11));
            cars.Add((6, 11));
            cars.Add((18, 11));
            cars.Add((36, 11));
            buses.Add((8, 10));
            buses.Add((16, 10));
            buses.Add((36, 10));

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
            row = 16;
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");
        }
        public void RenderEndZone()
        {
            col = 0;
            row = 9;
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");
        }

        public void RenderPoints()
        {
            col = 0;
            row = 0;

            Console.SetCursorPosition(col, row);
            Console.WriteLine("Points: " + Points);
        }

        public void RenderLives()
        {
            col = 0;
            row = 1;

            Console.SetCursorPosition(col, row);
            Console.WriteLine("Lives: " + lives);
        }

        public void SafeZoneCleared(Frog frog)
        {
            if (frog.frogPosY == 16 && !passed)
            {
                passed = true;
                Points = Points + 100;
            }
        }

        public void EndZoneReached(Frog frog, UIMenu menu)
        {
            if (frog.frogPosY == 9 && !finished)
            {
                finished = true;
                Points = Points + 500;

                if (finish < 4)
                {
                    finish++;
                    frog.frogPosX = 25;
                    frog.frogPosY = 23;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);
                    finished = false;
                    passed = false;
                }
                else if (finish == 4)
                {
                    menu.WinGame(Points);
                    Points = 0;
                    lives = 3;
                    frog.frogPosX = 25;
                    frog.frogPosY = 23;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);
                    finished = false;
                    passed = false;
                    finish = 0;
                }
            }
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

        public void ObstacleCollision(Frog frog, UIMenu menu)
        {
            int x = 0;
            int y = 0;

            x = frog.frogPosX;
            y = frog.frogPosY;

            for (int i = 0; i < cars.Count; i++)
            {
                if (y == cars[i].row && x >= cars[i].col &&
                    x <= cars[i].col + 2)
                {
                    lives = lives - 1;
                    RenderLives();

                    frog.frogPosX = 25;
                    frog.frogPosY = 23;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);

                    if (lives == 0)
                    {
                        menu.LoseGame(Points, GameOver);
                    }
                }
            }

            for (int i = 0; i < buses.Count; i++)
            {
                if (y == buses[i].row && x >= buses[i].col &&
                    x <= buses[i].col + 5)
                {
                    lives = lives - 1;
                    RenderLives();

                    frog.frogPosX = 25;
                    frog.frogPosY = 23;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);

                    if (lives == 0)
                    {
                        menu.LoseGame(Points, GameOver);
                    }
                }
            }
        }
    }
}
