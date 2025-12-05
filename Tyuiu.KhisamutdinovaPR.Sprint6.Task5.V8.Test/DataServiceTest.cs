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
        public void LoadFromDataFile_ReturnsOnlyNegativeValues()
        {
            // arrange
            DataService ds = new DataService();

            // создаём временный файл с тестовыми данными
            string tempPath = Path.GetTempFileName();
            // 2.5 -3.3 10 -6 8.2
            File.WriteAllText(tempPath, "2.5 -3.3 10 -6 8.2");

            try
            {
                // act
                double[] result = ds.LoadFromDataFile(tempPath);

                // assert
                Assert.AreEqual(2, result.Length);
                Assert.AreEqual(-3.3, result[0], 0.001);
                Assert.AreEqual(-6.0, result[1], 0.001);
            }
            finally
            {
                // удаляем временный файл
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
        }
    }
}