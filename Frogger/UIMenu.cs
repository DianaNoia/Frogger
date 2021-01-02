﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Frogger
{
    class UIMenu
    {
        Obstacle obstacle = new Obstacle();

        //private HighScores hs;

        //public UIMenu(HighScores hs)
        //{
        //    this.hs = hs;
        //}

        public void DrawMenu()
        {
            //Animations();
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("**************************************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t      FROGGER\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t    1. Play\n\t\t    2. Controls\n\t\t    3. Credits\n\t\t    4. Highscores\n\t\t    5. Quit \n");
            Console.WriteLine("**************************************************");

            Options();
        }

        //private void Animations()
        //{
        //    //for (int i = 0; i < 1; i++)
        //    //{
        //    for (int j = 0; j < 1; j++)
        //    {
        //        Console.Clear();
        //        string buffer = "".PadLeft(j);
        //        Console.WriteLine(buffer + @" @ @ ", Console.ForegroundColor = ConsoleColor.DarkGreen);
        //        Console.WriteLine(buffer + @"\(_)/", Console.ForegroundColor = ConsoleColor.DarkGreen);
        //        Console.WriteLine(buffer + @" / \ ", Console.ForegroundColor = ConsoleColor.DarkGreen);
        //        Console.ForegroundColor = ConsoleColor.White;
        //
        //    }
        //
        //    Thread.Sleep(100);
        //    //}
        //}

        public void Options()
        {
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
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
                        Console.Clear();
                        DrawMenu();
                        break;
                    case "4":
                        Console.Clear();
                        //hs.ReadScores();
                        Console.ReadKey();
                        Console.Clear();
                        DrawMenu();
                        break;
                    case "5":
                        Console.Clear();
                        Environment.Exit(0);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong input! Try again");
                        Console.ReadLine();
                        Console.Clear();
                        DrawMenu();
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

        public void LoseGame(int points, bool gameover)
        {
            Console.Clear();
            Console.WriteLine("You lost!");
            Console.WriteLine($"You had " + points + " points");
            Console.WriteLine("Press any key to go back");

            Console.ReadKey();
            Console.Clear();

            gameover = obstacle.GameOver;
            gameover = true;

            DrawMenu();
        }

        public void WinGame(int points)
        {
            Console.Clear();
            Console.WriteLine("You won!");
            Console.WriteLine($"You had " + points + " points");
            Console.ReadKey();
            Console.Clear();
            DrawMenu();
        }
    }
}
