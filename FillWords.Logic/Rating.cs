using System;
using System.Threading.Tasks;
namespace FillWords.Logic
{
    class Rating
    {
        public static void DrawRating()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Здесь будет Рейтинг игроков");
                Menu.Back();
                Task.Delay(120).Wait();
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
