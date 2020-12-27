using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class UIMenu
    {
        public void DrawMenu()
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);

            Console.WriteLine("******************");
            Console.WriteLine("\tFrogger");
            Console.WriteLine("\t \n1. Play \n2. Controls \n3. Credits \n4. Highscores \n5. Quit \n");
            Console.WriteLine("******************");

            Options();
        }

        public void Options()
        {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        // showgaem
                        return;
                    case "2":
                        Console.Clear();
                        Controls();
                        Console.ReadKey();
                        Console.Clear();
                        DrawMenu();
                        break;
                    case "3":
                        Console.Clear();
                        Credits();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        // higscores
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Environment.Exit(0);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong input! Do better");
                        Console.ReadLine();
                        Console.Clear();
                        // gm.Gameloop
                        break;
                }
            }
        }
        public void Controls()
        {
            Console.WriteLine("Play with the arrow keys");
            Console.WriteLine("Reach the top five times to win!");
        }
        public void Credits()
        {
            Console.WriteLine("Game made by:");
            Console.WriteLine("Diana Nóia a21703004");
            Console.WriteLine("Inês Gonçalves a21702076");
            Console.WriteLine("Thanks to our teacher: Nuno Fachada :)");
        }
    }
}
