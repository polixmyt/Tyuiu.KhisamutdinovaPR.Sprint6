using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task3.V30.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task3.V30.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void Calculate_ReplaceEvenInLastRow_Correct()
        {
            // arrange: исходная матрица
            int[,] matrix =
            {
                { -9,  -4,  17,  -1, -20 },
                { -19, 18,  -4,   2,  14 },
                { -12, 16,  -2,   7,  18 },
                { -16, 15,   4,  12, -13 },
                { -15, -4, -16,   1, -14 }
            };

            // ожидаемый результат (в 5-й строке чётные заменены на 0)
            int[,] expected =
            {
                { -9,  -4,  17,  -1, -20 },
                { -19, 18,  -4,   2,  14 },
                { -12, 16,  -2,   7,  18 },
                { -16, 15,   4,  12, -13 },
                { -15,  0,   0,   1,   0 }
            };

            DataService ds = new DataService();

            // act
            int[,] actual = ds.Calculate(matrix);

            // assert: сравним каждый элемент
            int rows = actual.GetLength(0);
            int cols = actual.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j],
                        $"Mismatch at [{i},{j}]");
                }
            }
        }
    }
}