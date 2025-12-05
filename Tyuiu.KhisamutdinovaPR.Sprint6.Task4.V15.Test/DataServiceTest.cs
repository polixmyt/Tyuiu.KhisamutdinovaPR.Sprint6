using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task4.V15.Lib;
using System;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task4.V15.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void GetMassFunction_ReturnsCorrectLength()
        {
            DataService ds = new DataService();
            int start = -5;
            int stop = 5;

            double[] res = ds.GetMassFunction(start, stop);

            Assert.AreEqual(11, res.Length); // от -5 до 5 включительно
        }

        [TestMethod]
        public void GetMassFunction_CheckPointX0()
        {
            DataService ds = new DataService();
            int start = -5;
            int stop = 5;

            double[] res = ds.GetMassFunction(start, stop);

            // индекс x = 0: от -5 до 5 → 0 это шестой элемент
            int index0 = 0 - start; // 0 - (-5) = 5

            // F(0) = sin(0) + 2*0/3 - cos(0)*4*0 = 0
            double expected = 0.0;

            Assert.AreEqual(expected, res[index0], 0.01);
        }
    }
}