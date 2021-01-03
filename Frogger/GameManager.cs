using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Frogger
{
    /// <summary>
    /// Classe que gere o jogo
    /// </summary>
    class GameManager
    {
        /// <summary>
        /// Instância do menu
        /// </summary>
        private UIMenu menu;
        /// <summary>
        /// Instância do sapo
        /// </summary>
        private Frog frog = new Frog();
        /// <summary>
        /// Instância do obstáculo
        /// </summary>
        private Obstacle obstacle = new Obstacle();

        /// <summary>
        /// Método que inicia o jogo
        /// </summary>
        private void Start()
        {
            menu = new UIMenu();

            Console.SetWindowSize(50, 25);
            Console.SetBufferSize(50, 25);
            Console.CursorVisible = false;
            obstacle.GameOver = false;
            menu.DrawMenu();
        }

        /// <summary>
        /// Método que corre todas as frames do jogo
        /// </summary>
        public void GameLoop()
        {
            Start();

            // Enquanto que o jogo não acabar, imprime os dados e corre o
            // método Update();
            while (!obstacle.GameOver)
            {
                obstacle.RenderLives();
                obstacle.RenderPoints();
                obstacle.RenderFinishNum();
                Update();
                Thread.Sleep(120);
                Console.Clear();
            }

            Console.Clear();
            GameLoop();
        }

        /// <summary>
        /// Método que atualiza o jogo
        /// </summary>
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
