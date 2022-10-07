using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void ValidTransactionTest()
        {
            Payment payment = new Payment();
            bool actual = payment.ValidTransaction(10.00m, 10.00m);
            Assert.IsTrue(actual);
        }







        
        [DataRow(0, "")]
        [DataRow(90, "3Q 1D 1N")]
        [DataRow(99, "3Q 2D 4P")]
        [TestMethod]
        public void SmallestChange_Test(int int_change, string str_change)
        {
            Payment PaymentToTest = new Payment();
            var actual = PaymentToTest.SmallestChange(int_change);

            Assert.AreEqual(str_change, actual);
        }
    }
}
