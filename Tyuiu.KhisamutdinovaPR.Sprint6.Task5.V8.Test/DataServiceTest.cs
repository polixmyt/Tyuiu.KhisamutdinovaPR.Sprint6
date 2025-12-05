using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void LoadFromDataFile_ParseAllNumbersCorrectly()
        {
            DataService ds = new DataService();

            // создаём временный файл с несколькими числами
            string tempPath = Path.GetTempFileName();
            // здесь специально и с точкой, и с запятой:
            File.WriteAllText(tempPath, " -13  -19  9,82  -9.71  -0,11  -17,36  -12  -12,35 ");

            try
            {
                double[] res = ds.LoadFromDataFile(tempPath);

                Assert.AreEqual(8, res.Length);

                double[] expected = { -13.0, -19.0, 9.82, -9.71, -0.11, -17.36, -12.0, -12.35 };

                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i], res[i], 0.001, $"Index {i} mismatch");
                }
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }
    }
}