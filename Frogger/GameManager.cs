// <copyright file="GameManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frogger
{
    using System;
    using System.Threading;

    /// <summary>
    /// Classe que gere o jogo.
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Instância do sapo.
        /// </summary>
        private readonly Frog frog = new Frog();

        /// <summary>
        /// Instância do obstáculo.
        /// </summary>
        private readonly Obstacle obstacle = new Obstacle();

        /// <summary>
        /// Instância do menu.
        /// </summary>
        private UIMenu menu;

        /// <summary>
        /// Método que corre todas as frames do jogo.
        /// </summary>
        public void GameLoop()
        {
            this.Start();

            // Enquanto que o jogo não acabar, imprime os dados e corre o
            // método Update()
            while (!this.obstacle.GameOver)
            {
                this.obstacle.RenderLives();
                this.obstacle.RenderPoints();
                this.obstacle.RenderFinishNum();
                this.Update();
                Thread.Sleep(120);
                Console.Clear();
            }

            Console.Clear();
            this.GameLoop();
        }

        /// <summary>
        /// Método que atualiza o jogo.
        /// </summary>
        public void Update()
        {
            this.obstacle.RenderSafeZone();
            this.obstacle.RenderEndZone();
            this.obstacle.MoveObstacles();
            this.frog.MoveFrog();
            this.obstacle.ObstacleCollision(this.frog, this.menu);
            this.obstacle.SafeZoneCleared(this.frog);
            this.obstacle.EndZoneReached(this.frog, this.menu);
        }

        /// <summary>
        /// Método que inicia o jogo.
        /// </summary>
        private void Start()
        {
            this.menu = new UIMenu();

            Console.SetWindowSize(50, 25);
            Console.SetBufferSize(50, 25);
            Console.CursorVisible = false;
            this.obstacle.GameOver = false;
            this.menu.DrawMenu();
        }
    }
}
