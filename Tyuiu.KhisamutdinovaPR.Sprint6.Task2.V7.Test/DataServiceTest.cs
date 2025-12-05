using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task2.V7.Lib;
using System;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task2.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void GetMassFunction_LengthAndValuesCorrect()
        {
            DataService ds = new DataService();

            int start = -5;
            int stop = 5;

            double[] res = ds.GetMassFunction(start, stop);

            // Должно быть 11 значений: -5, -4, ..., 5
            Assert.AreEqual(11, res.Length);

            // Проверим несколько опорных точек (приблизительно)
            // значения заранее посчитаны той же формулой с округлением до 2 знаков:
            // x = -5 → -9.10
            // x =  0 →  2.00
            // x =  5 → 13.10
            Assert.AreEqual(-9.10, res[0], 0.01);
            Assert.AreEqual(2.00, res[5], 0.01);
            Assert.AreEqual(13.10, res[10], 0.01);
        }
    }
}