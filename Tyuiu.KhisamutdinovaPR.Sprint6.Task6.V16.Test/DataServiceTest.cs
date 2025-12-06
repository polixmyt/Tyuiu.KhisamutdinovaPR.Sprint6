using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task6.V16.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void CollectTextFromFile_ReturnsWordsWithLetterV()
        {
            DataService ds = new DataService();

            // создаём временный файл с тестовым текстом
            string tempPath = Path.GetTempFileName();
            // здесь 4 слова с буквой «в»/«В»: "Вася", "любит", "весну", "ветер"
            File.WriteAllText(tempPath, "Вася очень любит весну и тёплый ветер.");

            try
            {
                string result = ds.CollectTextFromFile(tempPath);

                string expected = "Вася любит весну ветер";

                Assert.AreEqual(expected, result);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }
    }
}