﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Frogger
{
    class GameManager
    {
        private bool GameOver { get; set; }
        UIMenu menu = new UIMenu();

        Frog frog = new Frog();
        Obstacle obstacle = new Obstacle();

        private void Start()
        {
            Console.SetWindowSize(50, 25);
            Console.SetBufferSize(50, 25);
            Console.CursorVisible = false;

            GameOver = false;

            menu.DrawMenu();
        }

        public void GameLoop()
        {
            Start();

            while (!GameOver)
            {
                Update();
                Console.Clear();
                Thread.Sleep(120);
            }

            Console.Clear();
            GameLoop();
        }

        public void Update()
        {
            frog.MoveFrog();
            obstacle.RenderSafeZone();
            obstacle.MoveObstacles();
        }
    }
}
