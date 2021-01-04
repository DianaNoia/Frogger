// <copyright file="Obstacle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frogger
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Classe que coloca e faz dos obstáculos no mundo.
    /// </summary>
    public class Obstacle
    {
        /// <summary>
        /// Lista de Tuples para os carros.
        /// </summary>
        private readonly List<(int col, int row)> cars =
            new List<(int, int)>();

        /// <summary>
        /// Lista de Tuples para os autocarros.
        /// </summary>
        private readonly List<(int col, int row)> buses =
            new List<(int, int)>();

        /// <summary>
        /// Colunas.
        /// </summary>
        private int col;

        /// <summary>
        /// Linhas.
        /// </summary>
        private int row;

        /// <summary>
        /// Vidas do sapo, começa com 3.
        /// </summary>
        private int lives = 3;

        /// <summary>
        /// Variável que guarda o número de vezes que o jogador chegou ao topo.
        /// </summary>
        private int finish;

        /// <summary>
        /// Variável booleana que verifica se o jogador passou pela safezone.
        /// </summary>
        private bool passed;

        /// <summary>
        /// Variável booleana que verifica se o jogador já chegou ao topo.
        /// </summary>
        private bool finished;

        /// <summary>
        /// Initializes a new instance of the <see cref="Obstacle"/> class.
        /// </summary>
        public Obstacle()
        {
            this.col = 0;
            this.row = 0;

            this.cars.Add((this.col, 17));
            this.cars.Add((25, 17));
            this.buses.Add((46, 16));
            this.buses.Add((20, 16));
            this.cars.Add((4, 15));
            this.cars.Add((15, 15));
            this.cars.Add((30, 15));
            this.buses.Add((40, 14));
            this.buses.Add((26, 14));
            this.buses.Add((5, 14));
            this.cars.Add((1, 13));
            this.cars.Add((10, 13));
            this.cars.Add((20, 13));
            this.cars.Add((32, 13));
            this.buses.Add((18, 12));
            this.buses.Add((2, 12));
            this.cars.Add((4, 10));
            this.cars.Add((20, 10));
            this.cars.Add((35, 10));
            this.buses.Add((6, 9));
            this.buses.Add((26, 9));
            this.cars.Add((10, 8));
            this.cars.Add((26, 8));
            this.buses.Add((20, 7));
            this.buses.Add((30, 7));
            this.buses.Add((5, 7));
            this.cars.Add((23, 6));
            this.cars.Add((6, 6));
            this.cars.Add((18, 6));
            this.cars.Add((36, 6));
            this.buses.Add((8, 5));
            this.buses.Add((16, 5));
            this.buses.Add((36, 5));
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets a value
        /// indicating  os pontos, começa a 0.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets a value
        /// indicating o Game Over.
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// Método que faz render da safezone.
        /// </summary>
        public void RenderSafeZone()
        {
            this.col = 0;
            this.row = 11;
            Console.SetCursorPosition(this.col, this.row);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");
        }

        /// <summary>
        /// Método que faz render da zona final.
        /// </summary>
        public void RenderEndZone()
        {
            this.col = 0;
            this.row = 4;
            Console.SetCursorPosition(this.col, this.row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");
        }

        /// <summary>
        /// Método que faz render dos pontos.
        /// </summary>
        public void RenderPoints()
        {
            this.col = 0;
            this.row = 0;

            Console.SetCursorPosition(this.col, this.row);
            Console.WriteLine("Points: " + this.Points);
        }

        /// <summary>
        /// Método que faz render das vidas.
        /// </summary>
        public void RenderLives()
        {
            this.col = 0;
            this.row = 1;

            Console.SetCursorPosition(this.col, this.row);
            Console.WriteLine("Lives: " + this.lives);
        }

        /// <summary>
        /// Método que faz render de quantas vezes o jogador passou pela zona
        /// final.
        /// </summary>
        public void RenderFinishNum()
        {
            this.col = 0;
            this.row = 2;

            Console.SetCursorPosition(this.col, this.row);
            Console.WriteLine("Finish times: " + this.finish);
        }

        /// <summary>
        /// Método que verifica que se o jogador passou pela safezone e atribui
        /// 100 pontos quando o faz.
        /// </summary>
        /// <param name="frog">Variável frog.</param>
        public void SafeZoneCleared(Frog frog)
        {
            if (frog == null)
            {
                throw new ArgumentNullException(nameof(frog));
            }

            // Se a posição do sapo for igual à posição da safezone e ele ainda
            // não tiver passado por lá recebe 500 pontos
            if (frog.FrogPosY == 11 && !this.passed)
            {
                this.passed = true;
                this.Points = this.Points + 100;
            }
        }

        /// <summary>
        /// Método que verifica que se o jogador chegou à zona final e atribui
        /// 500 pontos quando o faz. Se chegar ao final 5 vezes o jogo acaba e
        /// faz reset às variáveis.
        /// </summary>
        /// <param name="frog">Variável frog.</param>
        /// <param name="menu">Variável menu.</param>
        public void EndZoneReached(Frog frog, UIMenu menu)
        {
            if (frog == null)
            {
                throw new ArgumentNullException(nameof(frog));
            }

            // Se a posição do user for igual à posição da endzone e o jogo não
            // tiver acabado
            if (frog.FrogPosY == 4 && !this.finished)
            {
                // Finished fica verdadeiro e o jogador recebe 500 pontos
                this.finished = true;
                this.Points += 500;

                // Se o user não tiver chegado à endzone 5 vezes o jogo
                // continua e o sapo volta à posição inicial
                if (this.finish < 4)
                {
                    this.finish++;
                    this.RenderFinishNum();
                    frog.FrogPosX = 25;
                    frog.FrogPosY = 18;
                    Console.SetCursorPosition(frog.FrogPosX, frog.FrogPosY);
                    this.finished = false;
                    this.passed = false;
                }

                // Se o user tiver chegado à endzone 5 vezes o jogo acaba e
                // aparece o ecrã de ganhar o jogo, e os valores do jogador
                // dão reset
                else if (this.finish == 4)
                {
                    if (menu == null)
                    {
                        throw new ArgumentNullException(nameof(menu));
                    }

                    this.RenderFinishNum();
                    menu.WinGame(this.Points);
                    this.Points = 0;
                    this.lives = 3;
                    frog.FrogPosX = 25;
                    frog.FrogPosY = 18;
                    Console.SetCursorPosition(frog.FrogPosX, frog.FrogPosY);
                    this.finished = false;
                    this.passed = false;
                    this.finish = 0;
                }
            }
        }

        /// <summary>
        /// Método que move os obstáculos.
        /// </summary>
        public void MoveObstacles()
        {
            Console.SetCursorPosition(this.col, this.row);

            // Percorre a lista de carros e move-os
            for (int i = 0; i < this.cars.Count; i++)
            {
                if (this.cars[i].col + 1 == 50)
                {
                    this.cars[i] = (0, this.cars[i].row);
                }

                this.cars[i] = (this.cars[i].col + 1, this.cars[i].row);
                Console.SetCursorPosition(this.cars[i].col, this.cars[i].row);
                RenderCar();
            }

            // Percorre a lista de autocarros e move-os
            for (int i = 0; i < this.buses.Count; i++)
            {
                if (this.buses[i].col == 0)
                {
                    this.buses[i] = (44, this.buses[i].row);
                }

                this.buses[i] = (this.buses[i].col - 1, this.buses[i].row);
                Console.SetCursorPosition(this.buses[i].col, this.buses[i].row);
                RenderBus();
            }
        }

        /// <summary>
        /// Método que deteta a colisão do user com os obstáculos, e retira 1
        /// vida a cada colisão. Se as vidas chegarem a 0, o jogo acaba.
        /// </summary>
        /// <param name="frog">Variável frog.</param>
        /// <param name="menu">Variável menu.</param>
        public void ObstacleCollision(Frog frog, UIMenu menu)
        {
            int x = 0;
            int y = 0;

            if (frog == null)
            {
                throw new ArgumentNullException(nameof(frog));
            }

            x = frog.FrogPosX;
            y = frog.FrogPosY;

            // Percorre a lista de carros
            for (int i = 0; i < this.cars.Count; i++)
            {
                // Se a posição do jogador e do carro forem iguais, o jogador
                // perde uma vida e volta à posição inicial
                if (y == this.cars[i].row && x >= this.cars[i].col &&
                    x <= this.cars[i].col + 2)
                {
                    this.lives--;
                    this.RenderLives();

                    frog.FrogPosX = 25;
                    frog.FrogPosY = 18;
                    Console.SetCursorPosition(frog.FrogPosX, frog.FrogPosY);

                    // Se as vidas do jogador chegarem a 0 o jogo acaba e é
                    // mostrado um ecrã de derrota
                    if (this.lives == 0)
                    {
                        if (menu == null)
                        {
                            throw new ArgumentNullException(nameof(menu));
                        }

                        menu.LoseGame(this.Points);
                        this.lives = 3;
                        this.Points = 0;
                    }
                }
            }

            // Percorre a lista de autocarros
            for (int i = 0; i < this.buses.Count; i++)
            {
                // Se a posição do jogador e do autocarro forem iguais, o
                // jogador perde uma vida e volta à posição inicial
                if (y == this.buses[i].row && x >= this.buses[i].col &&
                    x <= this.buses[i].col + 5)
                {
                    this.lives--;
                    this.RenderLives();

                    frog.FrogPosX = 25;
                    frog.FrogPosY = 18;
                    Console.SetCursorPosition(frog.FrogPosX, frog.FrogPosY);

                    // Se as vidas do jogador chegarem a 0 o jogo acaba e é
                    // mostrado um ecrã de derrota
                    if (this.lives == 0)
                    {
                        if (menu == null)
                        {
                            throw new ArgumentNullException(nameof(menu));
                        }

                        menu.LoseGame(this.Points);
                        this.lives = 3;
                        this.Points = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Método que faz render dos carros.
        /// </summary>
        private static void RenderCar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u2580\u2580\u2580\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Método que faz render dos autocarros.
        /// </summary>
        private static void RenderBus()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
