using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class GameManager
    {
        private bool GameOver { get; set; }
        UIMenu menu = new UIMenu();

        private void Start()
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.CursorVisible = false;

            GameOver = false;

            menu.DrawMenu();
        }
        public void GameLoop()
        {
            Start();

            while (!GameOver)
            {
                Update();
            }

            Console.Clear();
            GameLoop();
        }

        public void Update()
        {
            //chama o jogo
        }
    }
}
