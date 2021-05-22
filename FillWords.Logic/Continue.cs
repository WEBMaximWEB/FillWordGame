using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FillWords.Logic
{
    public static class Continue
    {
        public static char[,] StartContinue()
        {
            int size = 0;
            string path = "board.txt";
            string[] saveBoard = File.ReadAllLines(path);
            char[,] board = new char[size,size];
            if (saveBoard.Length == 0)
            {
                return board;
            }
            else
            {
                size = Convert.ToInt32(saveBoard[0]);
                board = new char[size, size];
                int index = 1;
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        string str = saveBoard[index];
                        board[i, j] = str[0];
                        index++;
                    }
                }
            }
            return board;
        }

        public static void WriteOnFile(char[,] board , int size)
        {
            string path = "board.txt";
            File.WriteAllText(path, string.Empty);

            string[] arr = new string[size * size + 1];
            int index = 1;
            arr[0] = size.ToString();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[index] = board[i, j].ToString();
                    index++;
                }
            }
            File.WriteAllLines(path, arr);
        }

        public static bool CheckFile()
        {
            string path = "board.txt";
            string[] arr = File.ReadAllLines(path);
            if (arr.Length == 0)
                return false;
            else
                return true;
        }
    }
}
