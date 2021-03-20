using System;
using System.IO;
using System.Threading.Tasks;
namespace FillWords.Logic
{
    public static class Rating
    {
        public static string[] GetRating()
        {
            string path = "rating.txt";
            return File.ReadAllLines(path);
        }

        public static void CheckRating(int ratingValue, string name)
        {
            string[] ArrString = File.ReadAllLines("ratingValue.txt");
            int[] Arr = new int[ArrString.Length];
            for(int i = 0; i < ArrString.Length; i++)
                Arr[i] = Int32.Parse(ArrString[i]);
            for(int i = 0; i < Arr.Length; i++)
            {
                if (ratingValue > Arr[i])
                {
                    Arr[i] = ratingValue;
                    WriteOnFile(i, name);
                }
            }
            for (int i = 0; i < ArrString.Length; i++)
                ArrString[i] = Convert.ToString(Arr[i]);
            File.WriteAllLines("ratingValue.txt", ArrString);
        }

        private static void WriteOnFile(int index, string name)
        {
            string path = "rating.txt";
            string[] Arr = File.ReadAllLines(path);
            Arr[index] = name;
            File.WriteAllLines(path, Arr);
        }
    }
}
