using NUnit.Framework;
using System.Collections.Generic;

namespace FillWords.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 0)]
        [TestCase(2, 0)]
        [TestCase(12, 3)]
        [TestCase(12, 12)]
        public void Test1(int x, int y)
        {
            string[,] board = new string[12, 12];
            Assert.IsTrue(FillWords.Logic.WordGeneration.CheckAllDerections(board, 12, x, y));
        }

        public static string[,] board = new string[12, 12];
        //[TestCase(board, "8", ExpectedResult = 8)]

        /*
        public static IEnumerable<TestCaseData> TestCase
        {
            get
            {
                yield return TestCaseData("");
            }
        }*/
    }
}