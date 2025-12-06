// Author: Хисамутдинова Полина
// Project: Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Test
// Description: Тесты для DataService (Task7, Sprint6)

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ReplaceNegativeInSecondColumnWithOne_WorksCorrectly()
        {
            int[,] input =
            {
                { -9, -4, 17, -1, -20 },
                { -19, 18, -4,  2,  14 },
                { -12, 16, -2,  7,  18 }
            };

            int[,] expected =
            {
                { -9, 1, 17, -1, -20 },
                { -19, 18, -4, 2, 14 },
                { -12, 1, -2, 7, 18 }
            };

            DataService ds = new DataService();
            int[,] actual = ds.ReplaceNegativeInSecondColumnWithOne(input);

            // Сравниваем как одномерные массивы
            CollectionAssert.AreEqual(
                expected.Cast<int>().ToArray(),
                actual.Cast<int>().ToArray());
        }
    }
}