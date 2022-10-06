using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void ValidTransactionTest()
        {
            Payment payment = new Payment();
            bool actual  = payment.ValidTransaction(10.00m,10.00m);
            Assert.IsTrue(actual);
        }
    }
}