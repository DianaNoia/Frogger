using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Frogger
{
    class GameManager
    {
        public bool GameOver { get; set; }
        private UIMenu menu = new UIMenu();
        private Frog frog = new Frog();
        private Obstacle obstacle = new Obstacle();

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
                Thread.Sleep(120);
                Console.Clear();
            }

            Console.Clear();
            GameLoop();
        }

        public void Update()
        {
            obstacle.RenderSafeZone();
            obstacle.MoveObstacles();
            frog.MoveFrog();
            obstacle.ObstacleCollision(frog, menu);
        }
    }
}
