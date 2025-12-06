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
        public void LoadFromDataFile_ReturnOnlyNegativeValues()
        {
            // arrange
            DataService ds = new DataService();

            // временный файл с числами (и +, и -)
            string tempPath = Path.GetTempFileName();
            File.WriteAllText(
                tempPath,
                "7 2.58 16.62 -3.36 14 3.09 -6 6.13 9.24 12.88 2.39 9.88 9 8.73 11 13 -4 18 20");

            try
            {
                // act
                double[] actual = ds.LoadFromDataFile(tempPath);

                // в этом наборе отрицательные: -3.36, -6, -4
                double[] expected = { -3.36, -6.0, -4.0 };

                // assert
                Assert.AreEqual(expected.Length, actual.Length);

                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i], actual[i], 0.001, $"Index {i} mismatch");
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