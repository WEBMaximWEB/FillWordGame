using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace FillWords.Logic
{
    public static class NewGame
    {
        public static void DrawNewGame()
        {
            Console.Clear();
            PlayerName();
            while (true)
            {
                char[,] board = WordGeneration.GetWordGeneration(8);
                for (int i = 0; i < Sneak.listWords.Count; i++)
                    Console.WriteLine(Sneak.listWords[i]);
                //Menu.Back();
                Task.Delay(120).Wait();
                Console.SetCursorPosition(0, 0);
            }
        }

        public static void PlayerName()
        {
            Console.WriteLine("Как вас зовут?");
            string name = Console.ReadLine();
            Console.Clear();
        }
    }
}
