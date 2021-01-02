using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Frog
    {
        public int frogPosX = 25;
        public int frogPosY = 18;

        private void RenderFrog()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\u2580");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void EraseFrog()
        {
            Console.SetCursorPosition(frogPosX, frogPosY);
            Console.Write(" ");
        }

        public void MoveFrog()
        {
            ConsoleKeyInfo keyinfo;

            Console.SetCursorPosition(frogPosX, frogPosY);

            frogPosX = Console.CursorLeft;
            frogPosY = Console.CursorTop;

            RenderFrog();

            while (Console.KeyAvailable)
            {
                if ((keyinfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
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
