// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frogger
{
    /// <summary>
    /// Classe que inicia o programa.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///  Método que inicia o jogo.
        /// </summary>
        public static void Main()
        {
            // Instância da classe GameManager()
            GameManager gm = new GameManager();

            // Chama o método GameLoop()
            gm.GameLoop();
        }
    }
}