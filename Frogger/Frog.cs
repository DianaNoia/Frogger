using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Frog
    {
        public int frogPosX;
        public int frogPosY;

        public void RenderFrog()
        {
            Console.WriteLine("\u2580");
        }

        public void MoveFrog()
        {
            ConsoleKeyInfo keyinfo;
            frogPosX = 50;
            frogPosY = 25;

            Console.SetCursorPosition(frogPosX, frogPosY);

            frogPosX = Console.CursorLeft;
            frogPosY = Console.CursorTop;

            while (true)
            {
                if ((keyinfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (keyinfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            int x = frogPosX + 1;
                            if (frogPosX < 99)
                            {
                                Console.SetCursorPosition(x, frogPosY);
                                frogPosX = Console.CursorLeft;
                                RenderFrog();
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            int x2 = frogPosX - 1;
                            if (frogPosX > 0)
                            {
                                Console.SetCursorPosition(x2, frogPosY);
                                frogPosX = Console.CursorLeft;
                                RenderFrog();
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            int y = frogPosY - 1;
                            if (frogPosY > 0)
                            {
                                Console.SetCursorPosition(frogPosX, y);
                                frogPosY = Console.CursorTop;
                                RenderFrog();
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            int y2 = frogPosY + 1;
                            if (frogPosY < 49)
                            {
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
