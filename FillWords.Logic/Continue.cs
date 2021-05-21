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
                int index = 1;
                for(int i = 0; i < size; i++)
                {
                    for(int j = 0; j < size; j++)
                    {
                        board[i, j] = saveBoard[index][0];
                        index++;
                    }
                }
            }
            return board;
        }

        public static void WriteOnFile(char[,] board , int size)
        {
            string path = "board.txt";
            string[] arr = new string[size * size + 1];
            int index = 1;
            arr[0] = size.ToString();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[index] = board[i, j].ToString();
                }
            }
            File.WriteAllLines(path, arr);
        }
    }
}
