using System;
using System.Collections.Generic;
using System.IO;

namespace FillWords.Logic
{
    public static class Sneak
    {
        public static Stack<int> x = new Stack<int>();
        public static Stack<int> y = new Stack<int>();
        public static Stack<int> len = new Stack<int>();

        public static List<string> listWords = new List<string>();
    }
    
    public static class WordGeneration
    {
        public static char[,] GetWordGeneration(int width)
        {
            string[,] board = new string[width, width];
            Random rnd = new Random();
            while (CheckFieldArea(board, width))
            {
                int maxCount = rnd.Next(2, 19);
                int count = 0;
                board = AddStartLetter(board, width);
                count++;
                while (count <= maxCount && CheckAllDerections(board, width, Sneak.x.Peek(), Sneak.y.Peek()))
                {
                    board = AddLetter(board, width, Sneak.x.Peek(), Sneak.y.Peek());
                    count++;
                }
                while (!CheckField(board, width))
                {

                    board[Sneak.x.Pop(), Sneak.y.Pop()] = null;
                    count--;
                    if (count < 3)
                    {
                        while (count != 0)
                        {
                            board[Sneak.x.Pop(), Sneak.y.Pop()] = null;
                            count--;
                        }
                    }
                }
                if (count != 0)
                    Sneak.len.Push(count);
            }
            return WriteWordsInBoard(width);
        }

        public static char[,] WriteWordsInBoard(int width)
        {
            char[,] board = new char[width, width];
            string[] words = File.ReadAllLines("word" + "s" + ".txt");
            Random rnd = new Random();
            while (Sneak.len.Count != 0)
            {
                int len = Sneak.len.Pop();
                string word;
                do
                {
                    word = words[rnd.Next(words.Length)];
                } while (word.Length != len);
                Sneak.listWords.Add(word);
                foreach (char c in word)
                {
                    board[Sneak.x.Pop(), Sneak.y.Pop()] = c;
                }
            }
            return board;
        }

        static bool CheckField(string[,] board, int width)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (board[i, j] == null)
                        if (!CheckAllDerections(board, width, i, j))
                            return false;
                }
            }
            return true;
        }

        static bool CheckFieldArea(string[,] board, int width)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (board[i, j] == null)
                        return true;
                }
            }
            return false;
        }

        static bool CheckDerections(string[,] board, int width, int x, int y, int direction)
        {
            switch (direction)
            {
                case 0:
                    if (x < width - 1)
                        if (board[x + 1, y] == null)
                            return true;
                    break;
                case 1:
                    if (x > 0)
                        if (board[x - 1, y] == null)
                            return true;
                    break;
                case 2:
                    if (y < width - 1)
                        if (board[x, y + 1] == null)
                            return true;
                    break;
                case 3:
                    if (y > 0)
                        if (board[x, y - 1] == null)
                            return true;
                    break;
            }
            return false;
        }

        public static bool CheckAllDerections(string[,] board, int width, int x, int y)
        {
            if (CheckDerections(board, width, x, y, 0))
                return true;
            else if (CheckDerections(board, width, x, y, 1))
                return true;
            else if (CheckDerections(board, width, x, y, 2))
                return true;
            else if (CheckDerections(board, width, x, y, 3))
                return true;
            else
                return false;
        }

        static string[,] AddStartLetter(string[,] board, int width)
        {
            Random rnd = new Random();
            int x, y;
            do
            {
                x = rnd.Next(width);
                y = rnd.Next(width);
            } while (board[x, y] != null);
            board[x, y] = "s";
            Sneak.x.Push(x);
            Sneak.y.Push(y);
            return board;
        }

        static string[,] AddLetter(string[,] board, int width, int x, int y)
        {
            //if (!CheckAllDerections(board, width, x, y))
            {
                Random rnd = new Random();
                int derection;
                do
                {
                    derection = rnd.Next(4);

                } while (!CheckDerections(board, width, x, y, derection));
                switch (derection)
                {
                    case 0:
                        board[x + 1, y] = "s";
                        x++;
                        break;
                    case 1:
                        board[x - 1, y] = "s";
                        x--;
                        break;
                    case 2:
                        board[x, y + 1] = "s";
                        y++;
                        break;
                    case 3:
                        board[x, y - 1] = "s";
                        y--;
                        break;
                }
                Sneak.x.Push(x);
                Sneak.y.Push(y);
            }
            return board;
        }
    }
}
