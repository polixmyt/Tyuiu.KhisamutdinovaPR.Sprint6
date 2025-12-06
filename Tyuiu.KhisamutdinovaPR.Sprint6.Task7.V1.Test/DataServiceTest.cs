using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task7.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestGetMatrix()
        {
            // создаём временный csv-файл
            string tempPath = Path.Combine(Path.GetTempPath(), "TestTask7V1.csv");

            // Матрица из условия:
            // -9 -4 17 -1 -20
            // -19 18 -4 2 14
            // -12 16 -2 7 18
            var sb = new StringBuilder();
            sb.AppendLine("-9;-4;17;-1;-20");
            sb.AppendLine("-19;18;-4;2;14");
            sb.AppendLine("-12;16;-2;7;18");
            File.WriteAllText(tempPath, sb.ToString(), Encoding.UTF8);

            DataService ds = new DataService();

            int[,] actual = ds.GetMatrix(tempPath);

            int[,] expected =
            {
                { -9,  1, 17, -1, -20 },
                { -19, 18, -4,  2,  14 },
                { -12,  1, -2,  7,  18 }
            };

            CollectionAssert.AreEqual(
                expected.Cast<int>().ToArray(),
                actual.Cast<int>().ToArray());
        }
    }
}