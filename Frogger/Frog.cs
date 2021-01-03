using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    /// <summary>
    /// Classe que gera o Sapo 
    /// </summary>
    class Frog
    {
        /// <summary>
        /// Posição em X do Sapo, começa a 25
        /// </summary>
        public int frogPosX = 25;
        /// <summary>
        /// Posição em Y do Sapo, começa a 18
        /// </summary>
        public int frogPosY = 18;

        /// <summary>
        /// Método que dá render ao Sapo
        /// </summary>
        private void RenderFrog()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Método que apaga o Sapo
        /// </summary>
        private void EraseFrog()
        {
            Console.SetCursorPosition(frogPosX, frogPosY);
            Console.Write(" ");
        }

        /// <summary>
        /// Método que move o Sapo
        /// </summary>
        public void MoveFrog()
        {
            ConsoleKeyInfo keyinfo;

            Console.SetCursorPosition(frogPosX, frogPosY);

            frogPosX = Console.CursorLeft;
            frogPosY = Console.CursorTop;

            RenderFrog();

            // Enquanto que a key pressionada estiver disponivél
            while (Console.KeyAvailable)
            {
                // Se uma das keys for pressionada e não for Escape
                if ((keyinfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    // Aceita o input da key e move o Sapo de acordo com a 
                    // direção escolhida
                    switch (keyinfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            int x = frogPosX + 1;
                            if (frogPosX < 49)
                            {
                                EraseFrog();
                                Console.SetCursorPosition(x, frogPosY);
                                frogPosX = Console.CursorLeft;
                                RenderFrog();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            int x2 = frogPosX - 1;
                            if (frogPosX > 0)
                            {
                                EraseFrog();
                                Console.SetCursorPosition(x2, frogPosY);
                                frogPosX = Console.CursorLeft;
                                RenderFrog();
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            int y = frogPosY - 1;
                            if (frogPosY > 0)
                            {
                                EraseFrog();
                                Console.SetCursorPosition(frogPosX, y);
                                frogPosY = Console.CursorTop;
                                RenderFrog();
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            int y2 = frogPosY + 1;
                            if (frogPosY < 24)
                            {
                                EraseFrog();
                                Console.SetCursorPosition(frogPosX, y2);
                                frogPosY = Console.CursorTop;
                                RenderFrog();
                            }
                            break;
                    }
                }
            }
        }
    }
}
