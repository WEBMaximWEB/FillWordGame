using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace FillWords.Logic
{
    class Continue
    {
        public static void DrawContinue()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Здесь будет Продолжить игру");
                Menu.Back();
                Task.Delay(120).Wait();
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
