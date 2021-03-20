using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace FillWords.Logic
{
    public static class Menu
    {
        public static void MenuRendering(int flag)
        {
            string[] text = new[] { "Новая игра", "Продолжить", "Рейтинг", "Выход" };
            for (int i = 0; i < text.Length; i++)
            {
                if (flag == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green; //меняем текст
                    Console.WriteLine(text[i]);
                    Console.ResetColor(); // сбрасываем в стандартный
                }
                else
                    Console.WriteLine(text[i]);
            }
        }
        public static int ItemSelection(int flag)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if ((key == ConsoleKey.S || key == ConsoleKey.DownArrow) && flag < 3)
                return 1;
            else if ((key == ConsoleKey.W || key == ConsoleKey.UpArrow) && flag > 0)
                return -1;
            else if (key == ConsoleKey.Enter)
                return 42;
            else
                return 0;
        }
    }
}