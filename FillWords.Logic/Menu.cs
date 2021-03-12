using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace FillWords.Logic
{
    public static class Menu
    {
        public static void DrawMenu()
        {
            int flag = 0;
            Console.CursorVisible = false; // Чтобы не было мигающего курсора.

            Console.Clear();
            while (true)
            {
                Console.WriteLine("FillWord");
                MenuRendering(flag);
                int i = ItemSelection(flag);
                if (i == 42)
                {
                    switch (flag)
                    {
                        case 0:
                            NewGame.DrawNewGame();
                            break;
                        case 1:
                            Continue.DrawContinue();
                            break;
                        case 2:
                            Rating.DrawRating();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                    flag = flag + i;

                Task.Delay(120).Wait();
                Console.SetCursorPosition(0, 0);
            }
        }

        private static void MenuRendering(int flag)
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
        private static int ItemSelection(int flag)
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

        public static void Back()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
                DrawMenu();
        }
    }
}