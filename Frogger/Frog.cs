// <copyright file="Frog.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frogger
{
    using System;

    /// <summary>
    /// Classe que gera o Sapo.
    /// </summary>
    public class Frog
    {
        /// <summary>
        /// Gets or sets posição em X do Sapo, começa a 25.
        /// </summary>
        public int FrogPosX { get; set; } = 25;

        /// <summary>
        /// Gets or sets posição em Y do Sapo, começa a 18.
        /// </summary>
        public int FrogPosY { get; set; } = 18;

        /// <summary>
        /// Método que move o Sapo.
        /// </summary>
        public void MoveFrog()
        {
            ConsoleKeyInfo keyinfo;

            Console.SetCursorPosition(this.FrogPosX, this.FrogPosY);

            this.FrogPosX = Console.CursorLeft;
            this.FrogPosY = Console.CursorTop;

            RenderFrog();

            // Enquanto que a key pressionada estiver disponivél
            while (Console.KeyAvailable)
            {
                keyinfo = Console.ReadKey(true);

                // Se uma das keys for pressionada e não for Escape
                if (keyinfo.Key != ConsoleKey.Escape)
                {
                    // Aceita o input da key e move o Sapo de acordo com a
                    // direção escolhida
                    switch (keyinfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            int x = this.FrogPosX + 1;
                            if (this.FrogPosX < 49)
                            {
                                this.EraseFrog();
                                Console.SetCursorPosition(x, this.FrogPosY);
                                this.FrogPosX = Console.CursorLeft;
                                RenderFrog();
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            int x2 = this.FrogPosX - 1;
                            if (this.FrogPosX > 0)
                            {
                                this.EraseFrog();
                                Console.SetCursorPosition(x2, this.FrogPosY);
                                this.FrogPosX = Console.CursorLeft;
                                RenderFrog();
                            }

                            break;
                        case ConsoleKey.UpArrow:
                            int y = this.FrogPosY - 1;
                            if (this.FrogPosY > 0)
                            {
                                this.EraseFrog();
                                Console.SetCursorPosition(this.FrogPosX, y);
                                this.FrogPosY = Console.CursorTop;
                                RenderFrog();
                            }

                            break;
                        case ConsoleKey.DownArrow:
                            int y2 = this.FrogPosY + 1;
                            if (this.FrogPosY < 24)
                            {
                                this.EraseFrog();
                                Console.SetCursorPosition(this.FrogPosX, y2);
                                this.FrogPosY = Console.CursorTop;
                                RenderFrog();
                            }

                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Método que dá render ao Sapo.
        /// </summary>
        private static void RenderFrog()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Método que apaga o Sapo.
        /// </summary>
        private void EraseFrog()
        {
            Console.SetCursorPosition(this.FrogPosX, this.FrogPosY);
            Console.Write(" ");
        }
    }
}
