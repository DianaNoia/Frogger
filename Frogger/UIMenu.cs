// <copyright file="UIMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frogger
{
    using System;

    /// <summary>
    /// Classe que desenha o texto na consola.
    /// </summary>
    public class UIMenu
    {
        /// <summary>
        /// Método que imprime os controlos.
        /// </summary>
        public static void Controls()
        {
            Console.WriteLine("Play with the arrow keys");
            Console.WriteLine("Reach the top five times to win!");
        }

        /// <summary>
        /// Método que imprime os créditos.
        /// </summary>
        public static void Credits()
        {
            Console.WriteLine("Game made by:");
            Console.WriteLine("\n* Diana Nóia a21703004");
            Console.WriteLine("* Inês Gonçalves a21702076\n");
            Console.WriteLine("Thanks to our teacher: Nuno Fachada :)");
        }

        /// <summary>
        /// Método que desenha o menu.
        /// </summary>
        public void DrawMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine("**************************************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t      FROGGER\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t    1. Play\n\t\t    2. Controls\n\t\t    3. Credits\n\t\t    4. Quit \n");
            Console.WriteLine("**************************************************");

            this.Options();
        }

        /// <summary>
        /// Método para seleção das opções.
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
                        this.DrawMenu();
                        break;
                    case "3":
                        Console.Clear();
                        Credits();
                        Console.ReadKey();
                        Console.Clear();
                        this.DrawMenu();
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
                        this.DrawMenu();
                        break;
                }
            }
        }

        /// <summary>
        /// Método que imprime quantos pontos o jogador fez após este perder o
        /// jogo, e regressa ao menu inicial.
        /// </summary>
        /// <param name="points">Variável points.</param>
        public void LoseGame(int points)
        {
            Console.Clear();
            Console.WriteLine("You lost!");
            Console.WriteLine("You had " + points + " points");
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
            Console.Clear();

            this.DrawMenu();
        }

        /// <summary>
        /// Método que imprime quantos pontos o jogador fez após este ganhar o
        /// jogo, e regressa ao menu inicial.
        /// </summary>
        /// <param name="points">Variável points.</param>
        public void WinGame(int points)
        {
            Console.Clear();
            Console.WriteLine("You won!");
            Console.WriteLine("You had " + points + " points");
            Console.ReadKey();
            Console.Clear();
            this.DrawMenu();
        }
    }
}
