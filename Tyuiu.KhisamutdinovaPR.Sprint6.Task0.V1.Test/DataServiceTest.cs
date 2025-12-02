using Tyuiu.KhisamutdinovaPR.Sprint6.Task0.V1.Lib;

namespace Tyuiu.KhisamutdinovaPR.Sprint6.Task0.V1.Test
{
    [TestClass]
    public sealed class DataServiceTest 
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataService ds = new DataService();
            double res = ds.Calculate(3);
            double wait = 0.103;
            Assert.AreEqual(wait, res);
        }
    }
}
