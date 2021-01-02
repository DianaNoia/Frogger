using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Frogger
{
    class GameManager
    {
        //private HighScores hs = new HighScores();
        private UIMenu menu;
        private Frog frog = new Frog();
        private Obstacle obstacle = new Obstacle();

        private void Start()
        {
            menu = new UIMenu();

            Console.SetWindowSize(50, 25);
            Console.SetBufferSize(50, 25);
            Console.CursorVisible = false;

            obstacle.GameOver = false;

            menu.DrawMenu();
        }

        public void GameLoop()
        {
            Start();

            while (!obstacle.GameOver)
            {
                obstacle.RenderLives();
                obstacle.RenderPoints();
                obstacle.RenderFinishNum();
                Update();
                Thread.Sleep(120);
                Console.Clear();
            }

            //hs.InputScore(obstacle.Points);
            Console.Clear();
            GameLoop();
        }

        public void Update()
        {
            obstacle.RenderSafeZone();
            obstacle.RenderEndZone();
            obstacle.MoveObstacles();
            frog.MoveFrog();
            obstacle.ObstacleCollision(frog, menu);
            obstacle.SafeZoneCleared(frog);
            obstacle.EndZoneReached(frog, menu);
        }
    }
}
