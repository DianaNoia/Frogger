using System;
using System.Collections.Generic;
using System.Text;

namespace Frogger
{
    /// <summary>
    /// Classe que coloca e faz dos obstáculos no mundo
    /// </summary>
    class Obstacle
    {
        /// <summary>
        /// Colunas
        /// </summary>
        private int col;
        /// <summary>
        /// Linhas
        /// </summary>
        private int row;
        /// <summary>
        /// Vidas do sapo, começa com 3
        /// </summary>
        private int lives = 3;
        /// <summary>
        /// Variável que guarda o número de vezes que o jogador chegou ao topo
        /// </summary>
        private int finish = 0;

        /// <summary>
        /// Variável booleana que verifica se o jogador passou pela safezone
        /// </summary>
        private bool passed = false;
        /// <summary>
        /// Variável booleana que verifica se o jogador já chegou ao topo
        /// </summary>
        private bool finished = false;

        /// <summary>
        /// Propriedade auto-implementada que guarda os pontos, começa a 0
        /// </summary>
        public int Points { get; set; } = 0;
        /// <summary>
        /// Propriedade auto-implementada para o Game Over
        /// </summary>
        public bool GameOver { get; set; }

        //private HighScores hs = new HighScores();

        /// <summary>
        /// Lista de Tuples para os carros
        /// </summary>
        private List<(int col, int row)> cars = new List<(int, int)>();
        /// <summary>
        /// Lista de Tuples para os autocarros
        /// </summary>
        private List<(int col, int row)> buses = new List<(int, int)>();

        /// <summary>
        /// Construtor da classe, coloca os obstáculos na consola
        /// </summary>
        public Obstacle()
        {
            col = 0;
            row = 0;

            cars.Add((col, 17));
            cars.Add((25, 17));
            buses.Add((46, 16));
            buses.Add((20, 16));
            cars.Add((4, 15));
            cars.Add((15, 15));
            cars.Add((30, 15));
            buses.Add((40, 14));
            buses.Add((26, 14));
            buses.Add((5, 14));
            cars.Add((1, 13));
            cars.Add((10, 13));
            cars.Add((20, 13));
            cars.Add((32, 13));
            buses.Add((18, 12));
            buses.Add((2, 12));
            cars.Add((4, 10));
            cars.Add((20, 10));
            cars.Add((35, 10));
            buses.Add((6, 9));
            buses.Add((26, 9));
            cars.Add((10, 8));
            cars.Add((26, 8));
            buses.Add((20, 7));
            buses.Add((30, 7));
            buses.Add((5, 7));
            cars.Add((23, 6));
            cars.Add((6, 6));
            cars.Add((18, 6));
            cars.Add((36, 6));
            buses.Add((8, 5));
            buses.Add((16, 5));
            buses.Add((36, 5));
        }

        /// <summary>
        /// Método que faz render dos carros
        /// </summary>
        private void RenderCar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\u2580\u2580\u2580\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Método que faz render dos autocarros
        /// </summary>
        private void RenderBus()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Método que faz render da safezone
        /// </summary>
        public void RenderSafeZone()
        {
            col = 0;
            row = 11;
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");
        }

        /// <summary>
        /// Método que faz render da zona final
        /// </summary>
        public void RenderEndZone()
        {
            col = 0;
            row = 4;
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580\u2580" +
                "\u2580\u2580\u2580\u2580\u2580\u2580\u2580");
        }

        /// <summary>
        /// Método que faz render dos pontos
        /// </summary>
        public void RenderPoints()
        {
            col = 0;
            row = 0;

            Console.SetCursorPosition(col, row);
            Console.WriteLine("Points: " + Points);
        }

        /// <summary>
        /// Método que faz render das vidas
        /// </summary>
        public void RenderLives()
        {
            col = 0;
            row = 1;

            Console.SetCursorPosition(col, row);
            Console.WriteLine("Lives: " + lives);
        }

        /// <summary>
        /// Método que faz render de quantas vezes o jogador passou pela zona
        /// final
        /// </summary>
        public void RenderFinishNum()
        {
            col = 0;
            row = 2;

            Console.SetCursorPosition(col, row);
            Console.WriteLine("Finish times: " + finish);
        }

        /// <summary>
        /// Método que verifica que se o jogador passou pela safezone e atribui
        /// 100 pontos quando o faz
        /// </summary>
        /// <param name="frog"></param>
        public void SafeZoneCleared(Frog frog)
        {
            // Se a posição do sapo for igual à posição da safezone e ele ainda
            // não tiver passado por lá recebe 500 pontos
            if (frog.frogPosY == 11 && !passed)
            {
                passed = true;
                Points = Points + 100;
            }
        }

        /// <summary>
        /// Método que verifica que se o jogador chegou à zona final e atribui
        /// 500 pontos quando o faz. Se chegar ao final 5 vezes o jogo acaba e
        /// faz reset às variáveis.
        /// </summary>
        /// <param name="frog"></param>
        /// <param name="menu"></param>
        public void EndZoneReached(Frog frog, UIMenu menu)
        {
            // Se a posição do user for igual à posição da endzone e o jogo não
            // tiver acabado
            if (frog.frogPosY == 4 && !finished)
            {
                // Finished fica verdadeiro e o jogador recebe 500 pontos
                finished = true;
                Points = Points + 500;

                // Se o user não tiver chegado à endzone 5 vezes o jogo
                // continua e o sapo volta à posição inicial
                if (finish < 4)
                {
                    finish++;
                    RenderFinishNum();
                    frog.frogPosX = 25;
                    frog.frogPosY = 18;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);
                    finished = false;
                    passed = false;
                }
                // Se o user tiver chegado à endzone 5 vezes o jogo acaba e 
                // aparece o ecrã de ganhar o jogo, e os valores do jogador
                // dão reset
                else if (finish == 4)
                {
                    RenderFinishNum();
                    menu.WinGame(Points);
                    Points = 0;
                    lives = 3;
                    frog.frogPosX = 25;
                    frog.frogPosY = 18;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);
                    finished = false;
                    passed = false;
                    finish = 0;
                }
            }
        }

        /// <summary>
        /// Método que move os obstáculos
        /// </summary>
        public void MoveObstacles()
        {
            Console.SetCursorPosition(col, row);

            // Percorre a lista de carros e move-os
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

            // Percorre a lista de autocarros e move-os
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

        /// <summary>
        /// Método que deteta a colisão do user com os obstáculos, e retira 1
        /// vida a cada colisão. Se as vidas chegarem a 0, o jogo acaba.
        /// </summary>
        /// <param name="frog"></param>
        /// <param name="menu"></param>
        public void ObstacleCollision(Frog frog, UIMenu menu)
        {
            int x = 0;
            int y = 0;

            x = frog.frogPosX;
            y = frog.frogPosY;

            // Percorre a lista de carros
            for (int i = 0; i < cars.Count; i++)
            {
                // Se a posição do jogador e do carro forem iguais, o jogador 
                // perde uma vida e volta à posição inicial
                if (y == cars[i].row && x >= cars[i].col &&
                    x <= cars[i].col + 2)
                {
                    lives = lives - 1;
                    RenderLives();

                    frog.frogPosX = 25;
                    frog.frogPosY = 18;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);

                    // Se as vidas do jogador chegarem a 0 o jogo acaba e é 
                    // mostrado um ecrã de derrota
                    if (lives == 0)
                    {
                        menu.LoseGame(Points, GameOver);
                        lives = 3;
                        Points = 0;
                    }
                }
            }

            // Percorre a lista de autocarros
            for (int i = 0; i < buses.Count; i++)
            {
                // Se a posição do jogador e do autocarro forem iguais, o
                // jogador perde uma vida e volta à posição inicial
                if (y == buses[i].row && x >= buses[i].col &&
                    x <= buses[i].col + 5)
                {
                    lives = lives - 1;
                    RenderLives();

                    frog.frogPosX = 25;
                    frog.frogPosY = 18;
                    Console.SetCursorPosition(frog.frogPosX, frog.frogPosY);

                    // Se as vidas do jogador chegarem a 0 o jogo acaba e é 
                    // mostrado um ecrã de derrota
                    if (lives == 0)
                    {
                        menu.LoseGame(Points, GameOver);
                        lives = 3;
                        Points = 0;
                    }
                }
            }
        }
    }
}
