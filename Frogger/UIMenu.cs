using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Frogger
{
    /// <summary>
    /// Classe que desenha o texto na consola
    /// </summary>
    class UIMenu
    {
        /// <summary>
        /// Instância do obstacle
        /// </summary>
        Obstacle obstacle = new Obstacle();
        
        /// <summary>
        /// Método que desenha o menu
        /// </summary>
        public void DrawMenu()
        {
            //Animations();

            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("**************************************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t      FROGGER\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t    1. Play\n\t\t    2. Controls\n\t\t    3. Credits\n\t\t    4. Quit \n");
            Console.WriteLine("**************************************************");

            Options();
        }

        /// <summary>
        /// Método para seleção das opções
        /// </summary>
        public void Options()
        {
            while (true)
            {
                // Aceita input do user e seleciona as diferentes opções
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

        /// <summary>
        /// Método que imprime os controlos
        /// </summary>
        public void Controls()
        {
            Console.WriteLine("Play with the arrow keys");
            Console.WriteLine("Reach the top five times to win!");
        }

        /// <summary>
        /// Método que imprime os créditos
        /// </summary>
        public void Credits()
        {
            Console.WriteLine("Game made by:");
            Console.WriteLine("\n* Diana Nóia a21703004");
            Console.WriteLine("* Inês Gonçalves a21702076\n");
            Console.WriteLine("Thanks to our teacher: Nuno Fachada :)");
        }

        /// <summary>
        /// Método que imprime quantos pontos o jogador fez após este perder o
        /// jogo, e regressa ao menu inicial.
        /// </summary>
        /// <param name="points"></param>
        /// <param name="gameover"></param>
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

        /// <summary>
        /// Método que imprime quantos pontos o jogador fez após este ganhar o
        /// jogo, e regressa ao menu inicial.
        /// </summary>
        /// <param name="points"></param>
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
