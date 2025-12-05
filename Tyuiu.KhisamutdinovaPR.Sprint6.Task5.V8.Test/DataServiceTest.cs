using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Lib;
using System.Collections.Generic;
using System.Linq;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task5.V8.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestNegativeNumbers()
        {
            DataService ds = new DataService();

            List<double> values = new List<double>()
            {
                2.5, -3.3, 10, -6, 8.2
            };

            List<double> result = ds.GetNegative(values);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(-3.3));
            Assert.IsTrue(result.Contains(-6));
        }
    }
}