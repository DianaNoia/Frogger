using System;

namespace Frogger
{
    /// <summary>
    /// Classe que inicia o programa
    /// </summary>
    class Program
    {
        /// <summary>
        ///  Método que inicia o jogo
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Instância da classe GameManager()
            GameManager gm = new GameManager();
            // Chama o método GameLoop()
            gm.GameLoop();
        }
    }
}